using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NAudio.Wave;
using System.Windows.Forms.VisualStyles;
using System.Data;
using Microsoft.Win32;
using System.Media;

namespace TIMP
{
    /// <summary>
    /// Description of TimpForm.
    /// </summary>
    public partial class TimpForm : Form
    {
        /// <summary>
        /// The notify icon.
        /// </summary>
        NotifyIcon notifyIcon;

        /// <summary>
        /// The timp application context.
        /// </summary>
        TimpApplicationContext timpApplicationContext;

        /// <summary>
        /// The close flag.
        /// </summary>
        bool closeFlag = false;

        /// <summary>
        /// The stop flag.
        /// </summary>
        bool stopFlag = false;

        /// <summary>
        /// The output device.
        /// </summary>
        private WaveOutEvent outputDevice;

        /// <summary>
        /// The audio file.
        /// </summary>
        private AudioFileReader audioFile;

        /// <summary>
        /// The directory path.
        /// </summary>
        private string directoryPath;

        /// <summary>
        /// The player data table.
        /// </summary>
        DataTable playerDataTable = new DataTable();

        /// <summary>
        /// The open with timp key list.
        /// </summary>
        private List<string> openWithTimpKeyList = new List<string> { @"Software\Classes\directory\shell\Open with TIMP" };

        /// <summary>
        /// The sound player.
        /// </summary>
        private SoundPlayer soundPlayer = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TIMP.TimpForm"/> class.
        /// </summary>
        /// <param name="timpApplicationContext">Timp application context.</param>
        public TimpForm(TimpApplicationContext timpApplicationContext)
        {
            // Open in lower-right corner
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);

            // Set the notify icon
            this.notifyIcon = timpApplicationContext.notifyIcon;

            // Set the TIMP application context 
            this.timpApplicationContext = timpApplicationContext;

            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();

            // The invisible button
            Button closeButton = new Button();
            closeButton.Click += OnCloseButtonClick;

            // Set cancel button
            this.CancelButton = closeButton;

            /* Declare the data table columns */

            // Add columns to the plaer's data table
            this.playerDataTable.Columns.Add("Title", typeof(string));
            this.playerDataTable.Columns.Add("Duration", typeof(TimeSpan));
            this.playerDataTable.Columns.Add("Artist", typeof(string));
            this.playerDataTable.Columns.Add("Album", typeof(string));
            this.playerDataTable.Columns.Add("Year", typeof(string));
            this.playerDataTable.Columns.Add("Path", typeof(string));
        }

        /// <summary>
        /// Processes the play command.
        /// </summary>
        private void ProcessPlayCommand(string[] timpArguments)
        {
            // Check if a directory has been passed for play
            if (timpArguments.Length > 1 && timpArguments[0].ToLowerInvariant() == "/play")
            {
                // Check if it's current directory
                if (timpArguments[1].ToLowerInvariant() == "current")
                {
                    // Process current directory
                    this.ProcessDirectory(Application.StartupPath);
                }
                else if (Directory.Exists(timpArguments[1])) // Check if directory exists
                {
                    // Process passed directory
                    this.ProcessDirectory(timpArguments[1]);
                }

                // Play the first track
                this.PlayFirst();
            }
        }

        /// <summary>
        /// Plays the passed sound file.
        /// </summary>
        /// <param name="filePath">File path.</param>
        private void PlaySoundFile(string filePath)
        {
            // Dispose of any previous player
            this.DisposeSoundPlayer();

            // Set instance player afresh
            this.soundPlayer = new SoundPlayer(filePath);

            // Play the passed file
            this.soundPlayer.Play();
        }

        /// <summary>
        /// Disposes the sound player.
        /// </summary>
        private void DisposeSoundPlayer()
        {
            // Check for previous player
            if (this.soundPlayer != null)
            {
                // Stop it
                this.soundPlayer.Stop();

                // Dispose of it
                this.soundPlayer.Dispose();

                // Reset instance variable
                this.soundPlayer = null;
            }
        }

        /// <summary>
        /// Processes the client message.
        /// </summary>
        /// <param name="timpArguments">Timp arguments.</param>
        public void ProcessClientMessage(string[] timpArguments)
        {
            // Advise by sound


            // Switch the passed TIMP arguments
            switch (timpArguments[0].ToLowerInvariant())
            {
                // Exit
                case "/exit":
                    // Hide tray icon and exit
                    this.ExitTimp();

                    break;

                // Next
                case "/next":
                    this.PlayNext();

                    break;

                // Previous
                case "/prev":
                    this.PlayPrev();

                    break;

                // Stop
                case "/stop":
                    this.Stop();

                    break;

                // Pause
                case "/pause":
                    this.NAudioPause();

                    break;

                // Play
                case "/play":
                    // Check for a single argument
                    if (timpArguments.Length == 1)
                    {
                        // Trigger play action
                        this.PlayPause(true);
                    }
                    else
                    {
                        // Check for an integer/index
                        if (int.TryParse(timpArguments[1], out int index))
                        {
                            // Adjust for human / 1-based
                            index--;

                            // Play by index
                            this.PlayByIndex(index);
                        }
                        else
                        {
                            // Play command
                            this.ProcessPlayCommand(timpArguments);
                        }
                    }

                    break;

                // Autoplay
                case "/autoplay":
                    this.autoplayToolStripMenuItem.Checked = true;

                    break;

                // No autoplay
                case "/noautoplay":
                    this.autoplayToolStripMenuItem.Checked = false;

                    break;

                // Play/Pause
                case "/playpause":
                    // Trigger with pause
                    this.PlayPause(false);

                    break;

                // Shuffle
                case "/shuffle":
                    // Shuffle the items
                    this.ShuffleItems(true);

                    break;

                // Sort
                case "/sort":
                    // Sort the items
                    this.SortItems(true);

                    break;

                // Show
                case "/show":
                    // Relocate and show the form
                    this.RelocateAndShow();

                    break;

                // Hide
                case "/hide":
                    // Hide the form
                    this.Hide();

                    break;

                // First
                case "/first":
                    // Play the first track
                    this.PlayFirst();

                    break;

                // Last
                case "/last":
                    // Play the last track
                    this.PlayLast();

                    break;

                // Loop one
                case "/loopone":
                    // Click the menu item
                    this.looponeToolStripMenuItem.PerformClick();

                    break;

                // Loop list
                case "/looplist":
                    // Click the menu item
                    this.looplistToolStripMenuItem.PerformClick();

                    break;

                // No loop
                case "/noloop":
                    // Click the menu item
                    this.noLoopToolStripMenuItem.PerformClick();

                    break;

                // Unrecognized
                default:

                    break;
            }
        }

        /// <summary>
        /// Plays the first track.
        /// </summary>
        private void PlayFirst()
        {
            // Check there is at least one loaded track
            if (this.playerDataTable.Rows.Count > 0)
            {
                // Play first track
                this.PlayByIndex(0);
            }
        }

        /// <summary>
        /// Plays the last track.
        /// </summary>
        private void PlayLast()
        {
            // Check there is at least one loaded track
            if (this.playerDataTable.Rows.Count > 0)
            {
                // Play last track
                this.PlayByIndex(this.playerDataTable.Rows.Count - 1);
            }
        }

        /// <summary>
        /// Triggers play or pause
        /// </summary>
        /// <param name="isPlay">If set to <c>true</c> is play.</param>
        private void PlayPause(bool isPlay)
        {
            // Play action
            switch (this.GetPlaybackState())
            {
                // Playing
                case PlaybackState.Playing:
                    // Check for pause
                    if (!isPlay)
                    {
                        // Pause playback
                        this.outputDevice.Pause();
                    }

                    break;

                // Paused
                case PlaybackState.Paused:
                    // Resume playback
                    this.outputDevice.Play();

                    break;

                // Stopped
                case PlaybackState.Stopped:
                    // Check there's a track selected
                    if (this.playerDataGridView.SelectedRows.Count > 0)
                    {
                        // Play current selection
                        this.PlayByIndex(this.playerDataGridView.SelectedRows[0].Index);
                    }

                    break;
            }
        }

        /// <summary>
        /// Gets the state of the playback.
        /// </summary>
        /// <returns>The playback state.</returns>
        private PlaybackState GetPlaybackState()
        {
            // Check fr an output device
            if (this.outputDevice != null)
            {
                // Return the current playback state
                return this.outputDevice.PlaybackState;
            }

            // Default return
            return PlaybackState.Stopped;
        }

        /// <summary>
        /// Handles the timp form load.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnTimpFormLoad(object sender, EventArgs e)
        {
            // Bind the data table
            this.playerDataGridView.DataSource = this.playerDataTable;

            // Relocate and hide the form
            this.RelocateAndHide();

            /* Commands */

            // Set the arguments
            string[] args = Environment.GetCommandLineArgs();

            // Check for passed arguments
            if (args.Length > 1)
            {
                // Pre-process start-up commands
                switch (args[1].ToLowerInvariant())
                {
                    // Play
                    case "/play":
                        // Process play command, skipping the first element / passed exe
                        this.ProcessPlayCommand(args.Skip(1).ToArray());

                        break;

                    // Autostart
                    case "/autostart":
                        // Hide it
                        this.Hide();

                        break;

                    // Exit
                    case "/exit":
                        // Shut down timp
                        this.ExitTimp();

                        break;
                }
            }

            /* Settings data */

            //# Loop mode
            this.loopModeCheckBox.Checked = true;
            this.sortShuffleCheckBox.Checked = true;
            this.addToExplorerToolStripMenuItem.PerformClick();

            // Open registry key
            using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", false))
            {
                // Toggle check box by app value presence
                this.startOnLogonToolStripMenuItem.Checked = registryKey.GetValueNames().Contains("TIMP");
            }
        }

        /// <summary>
        /// Handles the main notify icon click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        public void OnMainNotifyIconClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Relocate and show
                this.RelocateAndShow();
            }
        }

        /// <summary>
        /// and relocates the main form.
        /// </summary>
        private void RelocateAndHide()
        {
            // Open in lower-right corner
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);

            // Hide the form
            this.Hide();
        }

        /// <summary>
        /// Relocates and shows the main form.
        /// </summary>
        private void RelocateAndShow()
        {
            // Open in lower-right corner
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);

            // Make topmost
            this.TopMost = true;

            // Show the form
            this.Show();

            // Reset topmost
            this.TopMost = false;
        }

        /// <summary>
        /// Handles the close button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnCloseButtonClick(object sender, EventArgs e)
        {
            // Hide the form
            this.Hide();
        }

        /// <summary>
        /// Handles the timp form form closing.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnTimpFormFormClosing(object sender, FormClosingEventArgs e)
        {
            // Hide the form
            this.Hide();

            // Remove Explorer menu
            if (this.addToExplorerToolStripMenuItem.Checked)
            {
                // Uncheck
                this.addToExplorerToolStripMenuItem.PerformClick();
            }

            // Set it to the opposite of close flag
            e.Cancel = !closeFlag;
        }

        /// <summary>
        /// Handles the notify icon context menu strip item clicked.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnNotifyIconContextMenuStripItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Switch the menu items
            switch (e.ClickedItem.Name)
            {
                // Open folder to populate list box with supported music files
                case "openFolderToolStripMenuItem":
                    // Open the directory
                    this.OpenDirectory();

                    // Halt flow
                    break;

                // Exit
                case "exitToolStripMenuItem":
                    // Hide tray icon and exit
                    this.ExitTimp();

                    // Halt flow
                    break;
            }
        }

        /// <summary>
        /// Opens the directory.
        /// </summary>
        private void OpenDirectory()
        {
            // Reset selected path
            this.folderBrowserDialog.SelectedPath = string.Empty;

            // Show folder browser dialog
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK && this.folderBrowserDialog.SelectedPath.Length > 0)
            {
                // Process selected directory
                this.ProcessDirectory(this.folderBrowserDialog.SelectedPath);

                // Play the first track
                this.PlayFirst();
            }
        }

        /// <summary>
        /// Exits the timp.
        /// </summary>
        private void ExitTimp()
        {
            // Set close flag
            this.closeFlag = true;

            // Hide tray icon
            this.notifyIcon.Visible = false;

            // Exit application
            this.timpApplicationContext.ExitThread();
        }

        /// <summary>
        /// Processes the directory.
        /// </summary>
        /// <param name="passedDirectoryPath">Passed directory path.</param>
        private void ProcessDirectory(string passedDirectoryPath)
        {
            // Set files by extension
            FileInfo[] files = new DirectoryInfo(passedDirectoryPath).EnumerateFiles("*.*", this.scansubdirectoriesToolStripMenuItem.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly).Where(file => new string[] { ".mp3", ".wav", ".aif" }.Contains(file.Extension.ToLower())).ToArray();

            // Check there are files
            if (files.Length > 0)
            {
                // Set directory path
                this.directoryPath = passedDirectoryPath;

                // Set files list
                List<string> filesList = files.Select(f => f.FullName).ToList();

                // Stop any playing
                this.Stop();

                // Clear data table
                this.playerDataTable.Clear();

                /* Add files to list box */

                // Iterate files sequentially
                for (int i = 0; i < filesList.Count; i++)
                {
                    // Add row
                    this.playerDataTable.Rows.Add(Path.GetFileNameWithoutExtension(filesList[i]), new TimeSpan(), string.Empty, string.Empty, string.Empty, filesList[i]);
                }

                // TODO Check if must shuffle [Can be taken out later to keep a single responsibility]
                if (this.shuffledToolStripMenuItem.Checked)
                {
                    // Shuffle files list
                    this.ShuffleItems(false);
                }

                // TODO Process file tags to populate listview

                // Update track count
                this.tracksToolStripStatusLabel.Text = this.playerDataTable.Rows.Count.ToString();
            }
        }

        /// <summary>
        /// Sorts the items.
        /// </summary>
        /// <param name="playAfter">If set to <c>true</c> play after.</param>
        private void SortItems(bool playAfter)
        {
            // Check there's something to work with
            if (this.playerDataTable.Rows.Count < 2)
            {
                // Halt flow
                return;
            }

            // Sort by title
            var dataView = this.playerDataTable.AsDataView();

            dataView.Sort = "Title ASC";

            // The index of the row
            int rowIndex = 0;

            // The index of the track
            int trackIndex = this.playerDataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0 ? this.playerDataGridView.SelectedRows[0].Index : -1;

            // Check if it's playing
            bool playTrack = this.IsPlaying;

            // Iterate sorted rows
            foreach (DataRow row in dataView.ToTable().Rows)
            {
                // Replace current row
                this.playerDataTable.Rows[rowIndex].ItemArray = row.ItemArray;

                // Raise the index
                rowIndex++;
            }

            // TODO Check if must play track [playAfter logic was inserted after playTrack so the interplay of both can be improved]
            if (playAfter && trackIndex > -1 && playTrack)
            {
                // Play the currently selected track
                this.PlayByIndex(trackIndex);
            }
        }

        /// <summary>
        /// Shuffles the items.
        /// </summary>
        /// <param name="playAfter">If set to <c>true</c> play after.</param>
        private void ShuffleItems(bool playAfter)
        {
            // Check there's something to work with
            if (this.playerDataTable.Rows.Count < 2)
            {
                // Halt flow
                return;
            }

            // The index of the row
            int rowIndex = 0;

            // The index of the track
            int trackIndex = this.playerDataGridView.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0 ? this.playerDataGridView.SelectedRows[0].Index : -1;

            // Check if it's playing
            bool playTrack = this.IsPlaying;

            // Iterate shuffled rows
            foreach (DataRow row in this.playerDataTable.Shuffle().Rows)
            {
                // Replace current row
                this.playerDataTable.Rows[rowIndex].ItemArray = row.ItemArray;

                // Raise the index
                rowIndex++;
            }

            // TODO Check if must play track [playAfter logic was inserted after playTrack so the interplay of both can be improved]
            if (playAfter && trackIndex > -1 && playTrack)
            {
                // Play the currently selected track
                this.PlayByIndex(trackIndex);
            }
        }

        /// <summary>
        /// Plays the previous.
        /// </summary>
        private void PlayPrev()
        {
            // If check for a valid track index
            if (this.playerDataGridView.SelectedRows.Count == 0)
            {
                // Halt flow
                return;
            }

            // Check for the first one
            if (this.playerDataGridView.SelectedRows[0].Index == 0)
            {
                // Check if must loop
                if (this.looplistToolStripMenuItem.Checked)
                {
                    // Loop play / Play and select last one
                    this.PlayByIndex(this.playerDataTable.Rows.Count - 1);
                }
                else
                {
                    // Repeat first track / zero index
                    this.PlayByIndex(0);
                }
            }
            else
            {
                // Play the previous one
                this.PlayByIndex(this.playerDataGridView.SelectedRows[0].Index - 1);
            }
        }

        /// <summary>
        /// Plays the next.
        /// </summary>
        private void PlayNext()
        {
            // If check for a valid track index
            if (this.playerDataGridView.SelectedRows.Count == 0)
            {
                // Halt flow
                return;
            }

            // Check if must play the same song
            if (this.looponeToolStripMenuItem.Checked)
            {
                // Loop the same song
                this.PlayByIndex(this.playerDataGridView.SelectedRows[0].Index);
            } // Check for the last one
            else if (this.playerDataGridView.SelectedRows[0].Index == this.playerDataTable.Rows.Count - 1)
            {
                // Check if must loop the list 
                if (this.looplistToolStripMenuItem.Checked)
                {
                    // Loop list / Play the first one
                    this.PlayByIndex(0);
                } // Else, no list loop == no further play
            } // No loop
            else
            {
                // Play the next one if not at the end of the list
                this.PlayByIndex(this.playerDataGridView.SelectedRows[0].Index + 1);
            }
        }

        /// <summary>
        /// Plays by passed list index
        /// </summary>
        /// <param name="index">Index.</param>
        private void PlayByIndex(int index)
        {
            // Check the index is valid
            if (index > -1 && index < this.playerDataTable.Rows.Count)
            {
                try
                {
                    // Check if it's the same index
                    if (this.playerDataGridView.SelectedRows[0].Index == index)
                    {
                        // Deselect
                        this.playerDataGridView.ClearSelection();
                    }

                    // Select the track to trigger play
                    this.playerDataGridView.Rows[index].Selected = true;
                }
                catch (Exception ex)
                {
                    // TODO Log
                }
            }
        }

        /// <summary>
        /// NAs the udio play new.
        /// </summary>
        /// <param name="audioFilePath">Audio file path.</param>
        private void NAudioPlayNew(string audioFilePath)
        {
            // Check file exists
            if (!File.Exists(audioFilePath))
            {
                // Halt flow
                return;
            }

            // Check for a previous output device
            if (this.GetPlaybackState() != PlaybackState.Stopped)
            {
                // Reset NAudio
                this.NAudioReset();
            }

            // Set the output device
            this.outputDevice = new WaveOutEvent();
            this.outputDevice.PlaybackStopped += this.OnPlaybackStopped;

            // Set the audio file and init
            this.audioFile = new AudioFileReader(audioFilePath);
            this.outputDevice.Init(audioFile);

            // Play it
            this.outputDevice.Play();
        }

        /// <summary>
        /// Stop this instance.
        /// </summary>
        private void Stop()
        {
            // Invoke NAudio's stop routine
            this.NAudioReset();
        }

        /// <summary>
        /// NAs the udio pause.
        /// </summary>
        private void NAudioPause()
        {
            // Check there is an output device
            if (this.outputDevice != null && this.outputDevice.PlaybackState == PlaybackState.Playing)
            {
                // Pause the device
                this.outputDevice.Pause();
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:TIMP.TimpForm"/> is playing.
        /// </summary>
        /// <value><c>true</c> if is playing; otherwise, <c>false</c>.</value>
        private bool IsPlaying => (this.outputDevice.PlaybackState == PlaybackState.Playing);

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:TIMP.TimpForm"/> is paused.
        /// </summary>
        /// <value><c>true</c> if is paused; otherwise, <c>false</c>.</value>
        private bool IsPaused => (this.outputDevice.PlaybackState == PlaybackState.Paused);

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:TIMP.TimpForm"/> is stopped.
        /// </summary>
        /// <value><c>true</c> if is stopped; otherwise, <c>false</c>.</value>
        private bool IsStopped => (this.outputDevice.PlaybackState == PlaybackState.Stopped);

        /// <summary>
        /// NAs the udio reset.
        /// </summary>
        private void NAudioReset()
        {
            // Set the stop flag
            this.stopFlag = true;

            // Reset output device
            if (this.outputDevice != null)
            {
                this.outputDevice.Stop();
                this.outputDevice.Dispose();
                this.outputDevice = null;
            }

            // Reset audio file
            if (this.audioFile != null)
            {
                this.audioFile.Dispose();
                this.audioFile = null;
            }
        }

        /// <summary>
        /// Handles the playback stopped.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="args">Arguments.</param>
        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            // Check for flag
            if (this.stopFlag)
            {
                // Reset flag
                this.stopFlag = false;

                // Halt flow
                return;
            }

            // TODO If nothing is selected, exit the function [May be improved, e.g. using the check above]
            if (this.playerDataGridView.SelectedRows.Count == 0)
            {
                // Halt flow
                return;
            }
            else
            {
                // Check for auto-play
                if (this.autoplayToolStripMenuItem.Checked)
                {
                    // Play the next one
                    this.PlayNext();
                }
            }
        }

        /// <summary>
        /// Handles the toggle tool strip menu item drop down item clicked.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnToggleToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Set tool strip menu item
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)e.ClickedItem;

            // Toggle checked
            toolStripMenuItem.Checked = !toolStripMenuItem.Checked;

            // Check clicked menu item
            toolStripMenuItem.Checked = true;

            /* Handle post-select operations */

            switch (toolStripMenuItem.Name)
            {
                // Add to explorer
                case "addToExplorerToolStripMenuItem":
                    // Perform action
                    if (this.addToExplorerToolStripMenuItem.Checked)
                    {
                        // Add to Windows Explorer
                        this.AddExplorerMenu();
                    }
                    else
                    {
                        // Remove from Windows Explorer
                        this.RemoveExplorerMenu();
                    }

                    break;

                // Start on logon
                case "startOnLogonToolStripMenuItem":
                    // Perform action
                    if (toolStripMenuItem.Name == "startAtLogonToolStripMenuItem")
                    {
                        try
                        {
                            // Open registry key
                            using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
                            {
                                // Check if must write to registry
                                if (this.startOnLogonToolStripMenuItem.Checked)
                                {
                                    // Add app value
                                    registryKey.SetValue("TIMP", $"\"{Application.ExecutablePath}\" /autostart");
                                }
                                else
                                {
                                    // Erase app value
                                    registryKey.DeleteValue("TIMP", false);
                                }
                            }
                        }
                        catch
                        {
                            // Inform user
                            MessageBox.Show("Error when interacting with the Windows registry.", "Registry error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    break;
            }
        }

        /// <summary>
        /// Handles the select tool strip menu item drop down item clicked.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSelectToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Set tool strip menu item
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)e.ClickedItem;

            // Uncheck all
            foreach (ToolStripMenuItem dropDownItem in ((ToolStripMenuItem)sender).DropDownItems)
            {
                dropDownItem.Checked = false;
            }

            // Check clicked menu item
            toolStripMenuItem.Checked = true;

            /* Handle post-select operations */

            switch (toolStripMenuItem.Name)
            {
                // Loop list
                case "looplistToolStripMenuItem":
                    // Set check state
                    this.loopModeCheckBox.CheckState = CheckState.Checked;

                    break;

                // Loop one
                case "looponeToolStripMenuItem":
                    // Set check state
                    this.loopModeCheckBox.CheckState = CheckState.Indeterminate;

                    break;

                // No loop
                case "noLoopToolStripMenuItem":
                    // Set check state
                    this.loopModeCheckBox.CheckState = CheckState.Unchecked;

                    break;

                // Sorted
                case "sortedToolStripMenuItem":
                    // Set check state
                    this.sortShuffleCheckBox.Checked = false;

                    break;

                // Shuffled
                case "shuffledToolStripMenuItem":
                    // Set check state
                    this.sortShuffleCheckBox.Checked = true;

                    break;
            }
        }

        /// <summary>
        /// Handles the open folder tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOpenFolderToolStripMenuItemClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the exit tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the actions tool strip menu item drop down item clicked.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnActionsToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Set tool strip menu item
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)e.ClickedItem;

            // Switch to trigger matching action 
            switch (toolStripMenuItem.Name)
            {
                // Play
                case "playToolStripMenuItem":
                    // Perform action
                    this.PlayPause(true);

                    break;

                // Pause
                case "pauseToolStripMenuItem":
                    // Perform action
                    this.NAudioPause();

                    break;

                // PlayPause
                case "playpauseToolStripMenuItem":
                    // Perform action
                    this.PlayPause(false);

                    break;

                // Stop
                case "stopToolStripMenuItem":
                    // Perform action
                    this.Stop();

                    break;

                // Previous
                case "previousToolStripMenuItem":
                    // Perform action
                    this.PlayPrev();

                    break;

                // Next
                case "nextToolStripMenuItem":
                    // Perform action
                    this.PlayNext();

                    break;

                // Shuffle
                case "shuffleToolStripMenuItem":
                    // Perform action
                    this.ShuffleItems(true);

                    break;

                // Stop
                case "sortToolStripMenuItem":
                    // Perform action
                    this.SortItems(true);

                    break;
            }
        }

        /// <summary>
        /// Handles the play time track bar scroll.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnPlayTimeTrackBarScroll(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the hide button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnHideButtonClick(object sender, EventArgs e)
        {
            // Hide form
            this.Hide();
        }

        /// <summary>
        /// Handles the sort shuffle check box checked changed.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSortShuffleCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            // Act on current check state
            if (this.sortShuffleCheckBox.Checked)
            {
                // Check if must click
                if (this.shuffledToolStripMenuItem.Checked == false)
                {
                    // Click to check it
                    this.shuffledToolStripMenuItem.PerformClick();
                }

                // Shuffle
                this.ShuffleItems(true);
            }
            else
            {
                // Check if must click
                if (this.sortedToolStripMenuItem.Checked == false)
                {
                    // Click to check it
                    this.sortedToolStripMenuItem.PerformClick();
                }

                // Sort
                this.SortItems(true);
            }
        }

        /// <summary>
        /// Handles the first button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnFirstButtonClick(object sender, EventArgs e)
        {
            // Play the first track
            this.PlayFirst();
        }

        /// <summary>
        /// Handles the previous button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnPreviousButtonClick(object sender, EventArgs e)
        {
            // Play the previous track
            this.PlayPrev();
        }

        /// <summary>
        /// Handles the play pause button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnPlayPauseButtonClick(object sender, EventArgs e)
        {
            // Trigger PlayPause
            this.PlayPause(false);
        }

        /// <summary>
        /// Handles the next button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnNextButtonClick(object sender, EventArgs e)
        {
            // Play the next track
            this.PlayNext();
        }

        /// <summary>
        /// Handles the last button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnLastButtonClick(object sender, EventArgs e)
        {
            // Play the last track
            this.PlayLast();
        }

        /// <summary>
        /// Handles the exit button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnExitButtonClick(object sender, EventArgs e)
        {
            // Hide tray icon and exit
            this.ExitTimp();
        }

        /// <summary>
        /// Handles the original thread donation codercom tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOriginalThreadDonationCodercomToolStripMenuItemClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the source code githubcom tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSourceCodeGithubcomToolStripMenuItemClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the about tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAboutToolStripMenuItemClick(object sender, EventArgs e)
        {

        }

        private void OnPlayTimeTrackBarValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the button mouse enter.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnButtonMouseEnter(object sender, EventArgs e)
        {
            // Set tip
            this.tipToolStripStatusLabel.Text = ((Control)sender).Name.Replace("Button", string.Empty).Replace("CheckBox", string.Empty).ToUpper();

            // Append tip info
            switch (((Control)sender).Name)
            {
                // Loop mode check box
                case "loopModeCheckBox":
                    // String to append
                    string append = string.Empty;

                    // Switch on check state
                    switch (this.loopModeCheckBox.CheckState)
                    {
                        // Loop list
                        case CheckState.Checked:
                            // Set append
                            append = ": Loop list";

                            break;

                        // Loop one
                        case CheckState.Indeterminate:
                            // Set append
                            append = ": Loop one";

                            break;

                        // No loop
                        case CheckState.Unchecked:
                            // Set append
                            append = ": No loop";

                            break;
                    }

                    // Append 
                    this.tipToolStripStatusLabel.Text += append;

                    break;

                // Sort/shuffle check box
                case "sortShuffleCheckBox":
                    // Append 
                    this.tipToolStripStatusLabel.Text += this.sortShuffleCheckBox.Checked ? ": Shuffled" : ": Sorted";

                    break;
            }
        }

        /// <summary>
        /// Handles the button mouse leave.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnButtonMouseLeave(object sender, EventArgs e)
        {
            // Clear string
            this.tipToolStripStatusLabel.Text = string.Empty;
        }

        /// <summary>
        /// Handles the player data grid view selection changed.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnPlayerDataGridViewSelectionChanged(object sender, EventArgs e)
        {
            // Skip if nothing is selected
            if (this.playerDataGridView.SelectedRows.Count == 0)
            {
                // Halt flow
                return;
            }

            try
            {
                // Play selected item
                this.NAudioPlayNew(this.playerDataGridView.SelectedRows[0].Cells["Path"].Value.ToString());
            }
            catch (Exception ex)
            {
                // TODO Log
            }
        }

        private void OnPlayerDataGridViewDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        /// <summary>
        /// Handles the player data grid view cell mouse click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnPlayerDataGridViewCellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Check for left click and if item is the same as currently slected
            if (e.Button == MouseButtons.Left && this.playerDataGridView.SelectedRows[0].Index == e.RowIndex)
            {
                // Trigger play
                this.PlayByIndex(e.RowIndex);
            }
        }

        /// <summary>
        /// Handles the loop mode check box check state changed.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnLoopModeCheckBoxCheckStateChanged(object sender, EventArgs e)
        {
            // Act on current check state
            switch (this.loopModeCheckBox.CheckState)
            {
                // Loop list
                case CheckState.Checked:
                    // Check if must click
                    if (this.looplistToolStripMenuItem.Checked == false)
                    {
                        // Click to check it
                        this.looplistToolStripMenuItem.PerformClick();
                    }

                    break;

                // Loop one
                case CheckState.Indeterminate:
                    // Check if must click
                    if (this.looponeToolStripMenuItem.Checked == false)
                    {
                        // Click to check it
                        this.looponeToolStripMenuItem.PerformClick();
                    }

                    break;

                // No loop
                case CheckState.Unchecked:
                    // Check if must click
                    if (this.noLoopToolStripMenuItem.Checked == false)
                    {
                        // Click to check it
                        this.noLoopToolStripMenuItem.PerformClick();
                    }
                    break;
            }
        }
        /// <summary>
        /// Adds the explorer menu.
        /// </summary>
        private void AddExplorerMenu()
        {
            try
            {
                // Iterate openWithTimp registry keys
                foreach (string openWithTimpKey in this.openWithTimpKeyList)
                {
                    // Add openWithTimp command to registry
                    RegistryKey registryKey;
                    registryKey = Registry.CurrentUser.CreateSubKey(openWithTimpKey);
                    registryKey.SetValue("icon", Application.ExecutablePath);
                    registryKey.SetValue("position", "-");
                    registryKey = Registry.CurrentUser.CreateSubKey($"{openWithTimpKey}\\command");
                    registryKey.SetValue(string.Empty, $"{Application.ExecutablePath} /play \"%1\"");
                    registryKey.Close();
                }
            }
            catch (Exception ex)
            {
                // Notify user
                MessageBox.Show($"Error when adding \"Open with TIMP\" context menu to registry.{Environment.NewLine}{Environment.NewLine}Message:{Environment.NewLine}{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Removes the explorer menu.
        /// </summary>
        private void RemoveExplorerMenu()
        {
            try
            {
                // Iterate openWithTimp registry keys 
                foreach (var openWithTimpKey in this.openWithTimpKeyList)
                {
                    // Remove openWithTimp command to registry
                    Registry.CurrentUser.DeleteSubKeyTree(openWithTimpKey);
                }
            }
            catch (Exception ex)
            {
                // Notify user
                MessageBox.Show($"Error when removing \"Open with TIMP\" context menu to registry.{Environment.NewLine}{Environment.NewLine}Message:{Environment.NewLine}{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

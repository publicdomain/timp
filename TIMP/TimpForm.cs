using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NAudio.Wave;
using System.Windows.Forms.VisualStyles;

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
        /// Processes the client message.
        /// </summary>
        /// <param name="timpArguments">Timp arguments.</param>
        public void ProcessClientMessage(string[] timpArguments)
        {
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
                    this.NAudioStop();

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

                // Play/Pause
                case "/playpause":
                    // Trigger with pause
                    this.PlayPause(false);

                    break;

                // TODO Shuffle [Can be simplified by shuffling the items themselves]
                case "/shuffle":
                    // Begin the update
                    this.playerListView.BeginUpdate();

                    // Declare files list
                    var filesList = new List<string>();

                    // Get items into list
                    foreach (ListViewItem item in this.playerListView.Items)
                    {
                        filesList.Add(item.Tag.ToString());
                    }

                    // Clear previous items
                    this.playerListView.Items.Clear();

                    // Shuffle files list
                    filesList.Shuffle();

                    // Add files to list box
                    foreach (var item in filesList)
                    {
                        // Add to the list view
                        this.AddItem(item);
                    }

                    // End the update
                    this.playerListView.EndUpdate();

                    break;

                // Sort
                case "/sort":
                    // Sort and back
                    /*#this.playerListView.Sorted = true;
                    this.playerListView.Sorted = false;#*/

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
            if (this.playerListView.Items.Count > 0)
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
            if (this.playerListView.Items.Count > 0)
            {
                // Play last track
                this.PlayByIndex(this.playerListView.Items.Count - 1);
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
                    if (this.playerListView.SelectedIndices.Count > 0)
                    {
                        // Play current selection
                        this.PlayByIndex(this.playerListView.SelectedIndices[0]);
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
            // Relocate and hide the form
            this.RelocateAndHide();

            // Set the arguments
            string[] args = Environment.GetCommandLineArgs();

            // Check for passed arguments
            if (args.Length > 1)
            {
                // Process play command, skipping the first element / passed exe
                this.ProcessPlayCommand(args.Skip(1).ToArray());
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
                // Check if it's not visible
                if (this.Visible == false)
                {
                    // Relocate and show
                    this.RelocateAndShow();
                }
                else
                {
                    // Hide the form
                    this.Hide();
                }
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

            // Show the form
            this.Show();
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

                // Clear previous items
                this.playerListView.Items.Clear();

                // Reset current player
                //this.NAudioReset();

                // Check if must shuffle
                if (this.shuffledToolStripMenuItem.Checked)
                {
                    // Shuffle files list
                    filesList.Shuffle();
                }

                /* Add files to list box */

                for (int i = 0; i < filesList.Count; i++)
                {
                    this.AddItem(filesList[i]);
                }

                // Process file tags to populate listview
            }
        }

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="itemPath">Item path.</param>
        private void AddItem(string itemPath)
        {
            // Set the item
            var item = new ListViewItem(new[] { Path.GetFileNameWithoutExtension(itemPath), string.Empty, string.Empty })
            {
                // Set the tag
                Tag = itemPath
            };

            // Add to listview
            this.playerListView.Items.Add(item);
        }

        void OnPlayerListBoxClick(object sender, EventArgs e)
        {
            // TODO Use or remove
        }

        void OnPlayerListBoxDoubleClick(object sender, EventArgs e)
        {
            // TODO Use or remove
        }

        /// <summary>
        /// Plays the previous.
        /// </summary>
        private void PlayPrev()
        {
            // If nothing is selected, exit function
            if (this.playerListView.SelectedIndices.Count == 0)
            {
                // Halt flow
                return;
            }

            // Check for the first one
            if (this.playerListView.SelectedIndices[0] == 0)
            {
                // Check if must loop
                if (this.looplistToolStripMenuItem.Checked)
                {
                    // Loop play / Play and select last one
                    this.PlayByIndex(this.playerListView.Items.Count - 1);
                }
            }
            else
            {
                // Play the previous one
                this.PlayByIndex(this.playerListView.SelectedIndices[0] - 1);
            }
        }

        /// <summary>
        /// Plays the next.
        /// </summary>
        private void PlayNext()
        {
            // If nothing is selected, exit function
            if (this.playerListView.SelectedIndices.Count == 0)
            {
                // Halt flow
                return;
            }

            // Check for auto-play
            if (this.autoplayToolStripMenuItem.Checked)
            {
                // Check if must play the same song
                if (this.looponeToolStripMenuItem.Checked)
                {
                    // Loop the same song
                    this.PlayByIndex(this.playerListView.SelectedIndices[0]);
                } // Check for the last one
                else if (this.playerListView.SelectedIndices[0] == this.playerListView.Items.Count - 1)
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
                    // Play the next one if not at the en d of the list
                    this.PlayByIndex(this.playerListView.SelectedIndices[0] + 1);
                }
            }
        }

        /// <summary>
        /// Plays by passed list index
        /// </summary>
        /// <param name="index">Index.</param>
        private void PlayByIndex(int index)
        {
            // Check the index is valid
            if (index > -1 && index < this.playerListView.Items.Count)
            {
                try
                {
                    // Check if it's the same index
                    if (this.playerListView.SelectedIndices[0] == index)
                    {
                        // Deselect
                        this.playerListView.Items[index].Selected = false;

                        // Remove focus
                        this.playerListView.Items[index].Focused = false;
                    }

                    // Focus the item
                    this.playerListView.Focus();

                    // Focus the item
                    this.playerListView.Items[index].Focused = true;

                    // Select the item
                    this.playerListView.Items[index].Selected = true;

                    // Play selected item
                    this.NAudioPlayNew(Path.Combine(this.playerListView.Items[index].Tag.ToString()));

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
        /// NAs the udio stop.
        /// </summary>
        private void NAudioStop()
        {
            // Check there is an output device
            if (this.outputDevice != null)
            {
                // Set the stop flag
                this.stopFlag = true;

                // Stop the device
                this.outputDevice.Stop();

                // Wait until flag is false
                while (this.stopFlag == true)
                {
                    // Loop
                }
            }
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
            // Check if must exit immediately
            if (this.stopFlag)
            {
                // Reset the stop flag
                this.stopFlag = false;

                // Halt flow
                return;
            }

            // TODO If nothing is selected, exit the function [May be improved, e.g. using the check above]
            if (this.playerListView.SelectedItems.Count == 0)
            {
                // Halt flow
                return;
            }
            else
            {
                // Play the next one
                this.PlayNext();
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

        }

        /// <summary>
        /// Handles the sort shuffle check box checked changed.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSortShuffleCheckBoxCheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the first button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnFirstButtonClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the previous button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnPreviousButtonClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the play pause button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnPlayPauseButtonClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the next button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnNextButtonClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the last button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnLastButtonClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the loop mode check box checked changed.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnLoopModeCheckBoxCheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the exit button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnExitButtonClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the player list view selected index changed.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnPlayerListViewSelectedIndexChanged(object sender, EventArgs e)
        {
            /*// Skip if nothing is selected
            if (this.playerListView.SelectedItems.Count == 0)
            {
                // Halt flow
                return;
            }

            try
            {
                // Play selected item
                this.NAudioPlayNew(Path.Combine(this.playerListView.SelectedItems[0].Tag.ToString()));
            }
            catch (Exception ex)
            {
                // TODO Log
            }*/
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

        private void OnPlayerListViewMouseClick(object sender, MouseEventArgs e)
        {

        }

        /// <summary>
        /// Handles the player list view mouse down.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void OnPlayerListViewMouseDown(object sender, MouseEventArgs e)
        {
            // Check for left click
            if (e.Button == MouseButtons.Left)
            {
                // Set hit test info
                ListViewHitTestInfo listViewHitTestInfo = this.playerListView.HitTest(e.Location);

                // Check for an item
                if (listViewHitTestInfo.Item != null)
                {
                    // Play it
                    this.PlayByIndex(listViewHitTestInfo.Item.Index);
                }
            }
        }

        private void OnPlayTimeTrackBarValueChanged(object sender, EventArgs e)
        {

        }

        private void OnButtonMouseEnter(object sender, EventArgs e)
        {
            // Set name
            this.tipToolStripStatusLabel.Text = ((Control)sender).Name.Replace("Button", string.Empty).Replace("CheckBox", string.Empty).ToUpper();
        }

        private void OnButtonMouseLeave(object sender, EventArgs e)
        {
            // Clear string
            this.tipToolStripStatusLabel.Text = string.Empty;
        }
    }
}

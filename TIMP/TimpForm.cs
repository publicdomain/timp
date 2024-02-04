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
        /// <param name="passedNotifyIcon">Passed notify icon.</param>
        public TimpForm(NotifyIcon passedNotifyIcon, TimpApplicationContext timpApplicationContext)
        {
            // Open in lower-right corner
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);

            // Set the notify icon
            this.notifyIcon = passedNotifyIcon;

            // Set the TIMP application context 
            this.timpApplicationContext = timpApplicationContext;

            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();

            //# Hide hotkeys menu item [To be implemented]
            this.usehotkeysToolStripMenuItem.Visible = false;
            //# Hide autoplay menu item [To be implemented]
            this.autoplayToolStripMenuItem.Visible = false;

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
                    this.timpApplicationContext.ExitThread();

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

                // Play
                case "/play":
                    // Check for a single argument
                    if (timpArguments.Length == 1)
                    {
                        // Play action
                        switch (this.GetPlaybackState())
                        {
                            // Playing
                            case PlaybackState.Playing:
                                // Do nothing
                                break;

                            // Paused
                            case PlaybackState.Paused:
                                // Resume playback
                                this.outputDevice.Play();

                                break;

                            // Stopped
                            case PlaybackState.Stopped:
                                // Check there's a track selected
                                if (this.playerListBox.SelectedIndex > -1)
                                {
                                    // Play current selection
                                    this.PlayByIndex(this.playerListBox.SelectedIndex);
                                }

                                break;
                        }
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

                // Shuffle
                case "/shuffle":
                    // Check for

                    break;

                default:
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
                    // Open in lower-right corner
                    Rectangle workingArea = Screen.GetWorkingArea(this);
                    this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);

                    // Show the form
                    this.Show();
                }
                else
                {
                    // Hide the form
                    this.Hide();
                }
            }
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
        /// Handles the player list box selected index changed.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnPlayerListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Play selected one
                this.NAudioPlayNew(Path.Combine(this.directoryPath, this.playerListBox.Items[this.playerListBox.SelectedIndex].ToString()));
            }
            catch (Exception ex)
            {
                // TODO Log
            }
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
                    // Reset selected path
                    this.folderBrowserDialog.SelectedPath = string.Empty;

                    // Show folder browser dialog
                    if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK && this.folderBrowserDialog.SelectedPath.Length > 0)
                    {
                        // Process selected directory
                        this.ProcessDirectory(this.folderBrowserDialog.SelectedPath);
                    }

                    // Halt flow
                    break;

                // Exit
                case "exitToolStripMenuItem":
                    // Set close flag
                    this.closeFlag = true;

                    // Hide tray icon
                    this.notifyIcon.Visible = false;

                    // Exit application
                    Application.Exit();

                    // Halt flow
                    break;

                // Toggle check status
                default:
                    // Set the clicked item
                    ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)e.ClickedItem;

                    // Toggle check state
                    toolStripMenuItem.Checked = !toolStripMenuItem.Checked;

                    // Halt flow
                    break;
            }
        }

        /// <summary>
        /// Processes the directory.
        /// </summary>
        /// <param name="passedDirectoryPath">Passed directory path.</param>
        private void ProcessDirectory(string passedDirectoryPath)
        {
            // Set files by extension
            FileInfo[] files = new DirectoryInfo(passedDirectoryPath).EnumerateFiles("*.*", SearchOption.TopDirectoryOnly).Where(file => new string[] { ".mp3", ".wav", ".aif" }.Contains(file.Extension.ToLower())).ToArray();

            // Check there are files
            if (files.Length > 0)
            {
                // Set directory path
                this.directoryPath = passedDirectoryPath;

                // Set files list
                List<string> filesList = files.Select(f => f.Name).ToList();

                // Clear previous items
                this.playerListBox.Items.Clear();

                // Reset current player
                //this.NAudioReset();

                // Check if must shuffle
                if (this.randomizeToolStripMenuItem.Checked)
                {
                    // Shuffle files list
                    filesList.Shuffle();
                }

                // Add files to list box
                this.playerListBox.Items.AddRange(filesList.ToArray());

                // Check if must autoplay
                if (this.autoplayToolStripMenuItem.Checked)
                {
                    try
                    {
                        // Play first file
                        this.PlayByIndex(0);
                    }
                    catch (Exception ex)
                    {
                        // TODO Log to file
                    }
                }
            }
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
            if (this.playerListBox.SelectedIndex == -1)
            {
                // Halt flow
                return;
            }
            else if (this.playerListBox.SelectedIndex == 0) // Check for the firt one
            {
                // Check if must loop
                if (this.loopToolStripMenuItem.Checked)
                {
                    // Loop play / Play and select last one
                    this.PlayByIndex(this.playerListBox.Items.Count - 1);
                }
            }
            else
            {
                // Play the previous one
                this.PlayByIndex(this.playerListBox.SelectedIndex - 1);
            }
        }

        /// <summary>
        /// Plays the next.
        /// </summary>
        private void PlayNext()
        {
            // If nothing is selected, exit function
            if (this.playerListBox.SelectedIndex == -1)
            {
                // Halt flow
                return;
            }
            else if (this.playerListBox.SelectedIndex == this.playerListBox.Items.Count - 1) // Check for the last one
            {
                // Check if must loop
                if (this.loopToolStripMenuItem.Checked)
                {
                    // Loop play / Play and select first one
                    this.PlayByIndex(0);
                }
            }
            else
            {
                // Play the next one
                this.PlayByIndex(this.playerListBox.SelectedIndex + 1);
            }
        }

        /// <summary>
        /// Handles the player list box mouse click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void OnPlayerListBoxMouseClick(object sender, MouseEventArgs e)
        {
            // TODO Use or remove

            /*// Check for left click
            if (e.Button == MouseButtons.Left)
            {
                // Play selected
                this.PlayByIndex(this.playerListBox.SelectedIndex);
            }*/
        }

        void OnPlayerListBoxMouseDoubleClick(object sender, MouseEventArgs e)
        {
            // TODO Use or remove
        }

        /// <summary>
        /// Plays by passed list index
        /// </summary>
        /// <param name="index">Index.</param>
        private void PlayByIndex(int index)
        {
            // Check the index is valid
            if (index > -1 && index < this.playerListBox.Items.Count)
            {
                // Check if it's the same index
                if (this.playerListBox.SelectedIndex == index)
                {
                    // Deselect
                    this.playerListBox.SelectedIndex = -1;
                }

                // Set index as selected
                this.playerListBox.SelectedIndex = index;
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
        /// NAs the udio play.
        /// </summary>
        private void NAudioPlay()
        {
            // Check there is an output device
            if (this.outputDevice != null)
            {
                // Stop the device
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
        /// Ons the playback stopped.
        /// </summary>
        /// <param name="sender">Sender.</param>
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
            if (this.playerListBox.SelectedIndex == -1)
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
    }
}

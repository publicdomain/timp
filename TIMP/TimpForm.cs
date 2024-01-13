
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
        /// The close flag.
        /// </summary>
        bool closeFlag = false;

        /// <summary>
        /// The output device.
        /// </summary>
        private WaveOutEvent outputDevice;

        /// <summary>
        /// The audio file.
        /// </summary>
        private AudioFileReader audioFile;

        /// <summary>
        /// Play back state.
        /// </summary>
        private enum PlayBackState
        {
            Stopped = 0,
            Playing = 1,
            Paused = 2,
        }

        /// <summary>
        /// The random.
        /// </summary>
        private static Random random = new Random();
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:TIMP.TimpForm"/> class.
        /// </summary>
        /// <param name="passedNotifyIcon">Passed notify icon.</param>
        public TimpForm(NotifyIcon passedNotifyIcon)
        {
            // Set the notify icon
            this.notifyIcon = passedNotifyIcon;

            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();

            // The invisible button
            Button closeButton = new Button();
            closeButton.Click += OnCloseButtonClick;

            // Set cancel button
            this.CancelButton = closeButton;
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
                // Open in lower-right corner
                Rectangle workingArea = Screen.GetWorkingArea(this);
                this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);

                // Show the form
                this.Show();
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
            // TODO Play selected one [May be improved]
            this.NAudioPlayNew(Path.Combine(this.folderBrowserDialog.SelectedPath, this.playerListBox.Items[this.playerListBox.SelectedIndex].ToString()));
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
                        // Clear previous items
                        this.playerListBox.Items.Clear();

                        // Set files by extension
                        FileInfo[] files = new DirectoryInfo(this.folderBrowserDialog.SelectedPath).EnumerateFiles("*.*", SearchOption.TopDirectoryOnly).Where(file => new string[] { ".mp3", ".wav", ".aif" }.Contains(file.Extension.ToLower())).ToArray();

                        // Check there are files
                        if (files.Length > 0)
                        {
                            // Get only file names
                            List<string> filesList = files.Select(f => f.Name).ToList();

                            // Check if must shuffle
                            if(this.randomizeToolStripMenuItem.Checked)
                            {
                                // TODO Shuffle files list [Can be improved by System.Security.Cryptography's RNGCryptoServiceProvider]
                                filesList.OrderBy(a => random.Next()).ToList();
                            }

                            // Add files to list box
                            this.playerListBox.Items.AddRange(filesList.ToArray());

                            // Check if must autoplay
                            if (this.autoplayToolStripMenuItem.Checked)
                            {
                                try
                                {
                                    // Play first file by selected index change
                                    this.playerListBox.SelectedIndex = -1; // Deselect current
                                    this.playerListBox.SelectedIndex = 0; // Trigger selected change event
                                }
                                catch (Exception ex)
                                {
                                    // TODO Log to file
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
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
        /// NAs the udio play new.
        /// </summary>
        /// <param name="audioFilePath">Audio file path.</param>
        private void NAudioPlayNew(string audioFilePath)
        {
            // Check for a previous output device
            if (outputDevice != null)
            {
                // Reset NAudio
                this.NAudioReset();
            }

            // Set the output device
            outputDevice = new WaveOutEvent();
            outputDevice.PlaybackStopped += OnPlaybackStopped;

            // Set the audio file and init
            audioFile = new AudioFileReader(audioFilePath);
            outputDevice.Init(audioFile);

            // Play it
            outputDevice.Play();
        }

        /// <summary>
        /// NAs the udio play.
        /// </summary>
        private void NAudioPlay()
        {
            // TODO Reserved for play/pause
        }

        /// <summary>
        /// NAs the udio play.
        /// </summary>
        private void NAudioPause()
        {
            // TODO Reserved for play/pause
        }

        /// <summary>
        /// Stop NAudio playback.
        /// </summary>
        private void NAudioStop()
        {
            // Stop the output device
            this.outputDevice?.Stop();
        }

        /// <summary>
        /// Ons the playback stopped.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="args">Arguments.</param>
        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            // Dispose by reset
            this.NAudioReset();
        }

        /// <summary>
        /// NAs the udio reset.
        /// </summary>
        private void NAudioReset()
        {
            // Reset output device
            if (this.outputDevice != null)
            {
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
    }
}

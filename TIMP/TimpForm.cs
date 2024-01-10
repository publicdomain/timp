
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

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
            // TODO Add code
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
                        FileInfo[] files = new DirectoryInfo(this.folderBrowserDialog.SelectedPath).EnumerateFiles("*.*", SearchOption.AllDirectories).Where(file => new string[] { ".mp3", ".wav", ".mid" }.Contains(file.Extension.ToLower())).ToArray();

                        // Add to list box
                        this.playerListBox.Items.AddRange(files);
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
                    // TODO Toggle [Can use a single variable]
                    ((ToolStripMenuItem)e.ClickedItem).Checked = !((ToolStripMenuItem)e.ClickedItem).Checked;

                    // Halt flow
                    break;
            }

        }
    }
}

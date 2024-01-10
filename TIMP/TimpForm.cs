
using System;
using System.Drawing;
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
            this.notifyIcon= passedNotifyIcon;

            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();
			
			// The invisible button
			Button closeButton = new Button();
			closeButton.Click += OnCloseButtonClick;
			
            // Set cancel button
            this.CancelButton = closeButton;
		}
		
		/// <summary>
        /// Ons the main notify icon click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        public void OnMainNotifyIconClick(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Left)
			{				
				// Open in lower-right corner
                Rectangle workingArea = Screen.GetWorkingArea(this);
				this.Location = new Point(workingArea.Right - Size.Width, workingArea.Bottom - Size.Height);
				
                // Show the form
                this.Show();	            
            }
        }
		
		/// <summary>
        /// Ons the close button click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void OnCloseButtonClick(object sender, EventArgs e)
		{
            // Hide the form
            this.Hide();
		}
		
		/// <summary>
        /// Ons the timp form form closing.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void OnTimpFormFormClosing(object sender, FormClosingEventArgs e)
		{
			// Hide the form
            this.Hide();

            // Set it to the opposite of close flag
            e.Cancel = !closeFlag;
		}

        /// <summary>
        /// Ons the player list box selected index changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void OnPlayerListBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			// TODO Add code
		}
		
		/// <summary>
        /// Ons the notify icon context menu strip item clicked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void OnNotifyIconContextMenuStripItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			// Switch the menu items
            switch(e.ClickedItem.Name)
            {
                case "exitToolStripMenuItem":
                    // Set close flag
                    this.closeFlag = true;

                    // Hide tray icon
                    this.notifyIcon.Visible = false;

                    // Exit application
                    Application.Exit();

                    // Halt flow
                    break;
            }
        }
	}
}

﻿
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
            // TODO Add code
        }

        /// <summary>
        /// Ons the main notify icon click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        public void OnMainNotifyIconClick(object sender, MouseEventArgs e)
		{
            // TODO Add code
        }

        /// <summary>
        /// Ons the close button click.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void OnCloseButtonClick(object sender, EventArgs e)
		{
            // TODO Add code
        }

        /// <summary>
        /// Ons the timp form form closing.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void OnTimpFormFormClosing(object sender, FormClosingEventArgs e)
		{
            // TODO Add code
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
            // TODO Add code
        }
    }
}

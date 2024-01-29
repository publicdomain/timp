using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using NamedPipeWrapper;
using NAudio.Wave;

namespace TIMP
{
    /// <summary>
    /// Timp application context.
    /// </summary>
    public class TimpApplicationContext : ApplicationContext
    {
        /// <summary>
        /// The notify icon.
        /// </summary>
        NotifyIcon notifyIcon = new NotifyIcon();

        /// <summary>
        /// The timp window.
        /// </summary>
        TimpForm timpWindow;

        /// <summary>
        /// The server.
        /// </summary>
        NamedPipeServer<Arguments> server = new NamedPipeServer<Arguments>("TimpServerPipe");

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TIMP.TimpApplicationContext"/> class.
        /// </summary>
        public TimpApplicationContext()
        {
            // Set TIMP window
            this.timpWindow = new TimpForm(this.notifyIcon, this);

            // Set notify icon
            this.notifyIcon.Icon = this.timpWindow.Icon;
            this.notifyIcon.MouseClick += this.timpWindow.OnMainNotifyIconClick;
            this.notifyIcon.ContextMenuStrip = this.timpWindow.notifyIconContextMenuStrip;
            this.notifyIcon.Visible = true;

            // Set the client message handler
            this.server.ClientMessage += this.OnClientMessage;

            // Start up the server
            this.server.Start();
        }

        /// <summary>
        /// Handles the client message.
        /// </summary>
        /// <param name="conn">Conn.</param>
        /// <param name="arguments">Arguments.</param>
        private void OnClientMessage(NamedPipeConnection<Arguments, Arguments> conn, Arguments arguments)
        {
            // TODO Process arguments.Args
        }
    }
}

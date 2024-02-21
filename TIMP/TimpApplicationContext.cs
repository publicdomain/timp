using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using NamedPipeWrapper;
using NAudio.Wave;
using System.Windows.Input;

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
        public NotifyIcon notifyIcon = new NotifyIcon();

        /// <summary>
        /// The timp window.
        /// </summary>
        private TimpForm timpWindow;

        /// <summary>
        /// The server.
        /// </summary>
        private NamedPipeServer<Arguments> server = new NamedPipeServer<Arguments>("TimpServerPipe");

        /// <summary>
        /// The hotkey native window.
        /// </summary>
        private HotkeyNativeWindow hotkeyNativeWindow = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TIMP.TimpApplicationContext"/> class.
        /// </summary>
        public TimpApplicationContext()
        {
            // Set TIMP window
            this.timpWindow = new TimpForm(this);

            // Set main form
            this.MainForm = this.timpWindow;

            // Hotkeys
            hotkeyNativeWindow = new HotkeyNativeWindow();
            hotkeyNativeWindow.HotkeyPressed += new HotkeyNativeWindow.HotkeyDelegate(HotkeyNativeWindow_HotkeyPressed);

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
        /// Registers the hotkeys.
        /// </summary>
        public void RegisterHotkeys()
        {
            // Proxy it to the hotkey native window
            this.hotkeyNativeWindow.RegisterHotkeys();
        }

        /// <summary>
        /// Handles the native window hotkey pressed event.
        /// </summary>
        /// <param name="hotkeyId">Hotkey identifier.</param>
        private void HotkeyNativeWindow_HotkeyPressed(int hotkeyId)
        {
            switch (hotkeyId)
            {
                // Next
                case 1001:
                    // Play the next track
                    this.timpWindow.PlayNext();

                    break;

                // Previous
                case 1002:
                    // Play the previous track
                    this.timpWindow.PlayPrev();

                    break;

                // PlayPause
                case 1003:
                    // Trigger PlayPause
                    this.timpWindow.PlayPause(false);

                    break;

                // Repeat track
                case 1004:
                    // Play the current track
                    this.timpWindow.RepeatTrack();

                    break;
            }
        }

        /// <summary>
        /// Handles the client message.
        /// </summary>
        /// <param name="conn">Conn.</param>
        /// <param name="arguments">Arguments.</param>
        private void OnClientMessage(NamedPipeConnection<Arguments, Arguments> conn, Arguments arguments)
        {
            // Process client message on TIMP window
            this.timpWindow.ProcessClientMessage(arguments.Args);
        }
    }
}

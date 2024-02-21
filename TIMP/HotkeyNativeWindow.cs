using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TIMP
{
    /// <summary>
    /// Hotkey native window.
    /// </summary>
    public class HotkeyNativeWindow : NativeWindow
    {
        /// <summary>
        /// The wm hotkey.
        /// </summary>
        private const int WM_HOTKEY = 0x0312;

        /// <summary>
        /// The wm destroy.
        /// </summary>
        private const int WM_DESTROY = 0x0002;

        /// <summary>
        /// Registers the hot key.
        /// </summary>
        /// <returns><c>true</c>, if hot key was registered, <c>false</c> otherwise.</returns>
        /// <param name="hWnd">H window.</param>
        /// <param name="id">Identifier.</param>
        /// <param name="fsModifiers">Fs modifiers.</param>
        /// <param name="vk">Vk.</param>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        /// <summary>
        /// Unregisters the hot key.
        /// </summary>
        /// <returns><c>true</c>, if hot key was unregistered, <c>false</c> otherwise.</returns>
        /// <param name="hWnd">H window.</param>
        /// <param name="id">Identifier.</param>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// Key modifier.
        /// </summary>
        [Flags]
        private enum KeyModifier
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            WinKey = 8
        }

        /// <summary>
        /// The hotkey identifiers list.
        /// </summary>
        private List<Int32> hotkeyIdsList = new List<int>();

        /// <summary>
        /// Hotkey delegate.
        /// </summary>
        public delegate void HotkeyDelegate(int hotkeyId);

        /// <summary>
        /// Occurs when hotkey pressed.
        /// </summary>
        public event HotkeyDelegate HotkeyPressed;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:TIMP.HotkeyNativeWindow"/> class.
        /// </summary>
        public HotkeyNativeWindow()
        {
            // Create the handle
            this.CreateHandle(new CreateParams());

            // the application exit event
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
        }

        /// <summary>
        /// Registers the hotkeys.
        /// </summary>
        public void RegisterHotkeys()
        {
            // Register hotkeys
            RegisterAndAdd(1001, (int)(KeyModifier.Control | KeyModifier.Alt), (int)Keys.Right);
            RegisterAndAdd(1002, (int)(KeyModifier.Control | KeyModifier.Alt), (int)Keys.Left);
            RegisterAndAdd(1003, (int)(KeyModifier.Control | KeyModifier.Alt), (int)Keys.Up);
            RegisterAndAdd(1004, (int)(KeyModifier.Control | KeyModifier.Alt), (int)Keys.Down);
        }

        /// <summary>
        /// Registers the and add.
        /// </summary>
        /// <param name="hotkeyId">Hotkey identifier.</param>
        /// <param name="fsModifiers">Fs modifiers.</param>
        /// <param name="vk">Vk.</param>
        private void RegisterAndAdd(Int32 hotkeyId, int fsModifiers, int vk)
        {
            // Register the hotkey
            if (RegisterHotKey(this.Handle, hotkeyId, fsModifiers, vk))
            {
                // Add if on success
                hotkeyIdsList.Add(hotkeyId);
            }
        }

        /// <summary>
        /// Handles the application exit.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnApplicationExit(object sender, EventArgs e)
        {
            // Destroy the handle
            this.DestroyHandle();
        }

        /// <summary>
        /// Windows proc.
        /// </summary>
        /// <param name="m">M.</param>
        protected override void WndProc(ref Message m)
        {
            // Switch the message
            switch (m.Msg)
            {
                // Hotkey was pressed
                case WM_HOTKEY:
                    // Invoke the hotkey pressed event
                    HotkeyPressed?.Invoke(m.WParam.ToInt32());

                    break;

                // The application is exiting 
                case WM_DESTROY:

                    // Unregister all active hotkeys
                    foreach (int hotkeyId in hotkeyIdsList)
                    {
                        // Unregister current hotkey ID
                        UnregisterHotKey(this.Handle, hotkeyId);
                    }

                    break;
            }

            base.WndProc(ref m);
        }

    }
}

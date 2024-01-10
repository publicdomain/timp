using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

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
        /// Initializes a new instance of the <see cref="T:TIMP.TimpApplicationContext"/> class.
        /// </summary>
        public TimpApplicationContext()
        {
            // Set TIMP window
            this.timpWindow = new TimpForm(notifyIcon);

            // Set notify icon
            notifyIcon.Icon = timpWindow.Icon;
            notifyIcon.MouseClick += timpWindow.OnMainNotifyIconClick;
            notifyIcon.ContextMenuStrip = timpWindow.notifyIconContextMenuStrip;
            notifyIcon.Visible = true;
        }
    }
}

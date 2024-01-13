
namespace TIMP
{
	partial class TimpForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimpForm));
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.notifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.randomizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.usehotkeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.playerListBox = new System.Windows.Forms.ListBox();
			this.notifyIconContextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// notifyIconContextMenuStrip
			// 
			this.notifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.openFolderToolStripMenuItem,
									this.randomizeToolStripMenuItem,
									this.usehotkeysToolStripMenuItem,
									this.autoplayToolStripMenuItem,
									this.loopToolStripMenuItem,
									this.exitToolStripMenuItem});
			this.notifyIconContextMenuStrip.Name = "notifyIconContextMenuStrip";
			this.notifyIconContextMenuStrip.Size = new System.Drawing.Size(138, 136);
			this.notifyIconContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnNotifyIconContextMenuStripItemClicked);
			// 
			// openFolderToolStripMenuItem
			// 
			this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
			this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.openFolderToolStripMenuItem.Text = "&Open folder";
			// 
			// randomizeToolStripMenuItem
			// 
			this.randomizeToolStripMenuItem.Checked = true;
			this.randomizeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.randomizeToolStripMenuItem.Name = "randomizeToolStripMenuItem";
			this.randomizeToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.randomizeToolStripMenuItem.Text = "&Randomize";
			// 
			// usehotkeysToolStripMenuItem
			// 
			this.usehotkeysToolStripMenuItem.Checked = true;
			this.usehotkeysToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.usehotkeysToolStripMenuItem.Name = "usehotkeysToolStripMenuItem";
			this.usehotkeysToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.usehotkeysToolStripMenuItem.Text = "Use &hotkeys";
			// 
			// autoplayToolStripMenuItem
			// 
			this.autoplayToolStripMenuItem.Checked = true;
			this.autoplayToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoplayToolStripMenuItem.Name = "autoplayToolStripMenuItem";
			this.autoplayToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.autoplayToolStripMenuItem.Text = "&Autoplay";
			// 
			// loopToolStripMenuItem
			// 
			this.loopToolStripMenuItem.Checked = true;
			this.loopToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.loopToolStripMenuItem.Name = "loopToolStripMenuItem";
			this.loopToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.loopToolStripMenuItem.Text = "&Loop";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
			this.exitToolStripMenuItem.Text = "&Exit";
			// 
			// playerListBox
			// 
			this.playerListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.playerListBox.FormattingEnabled = true;
			this.playerListBox.IntegralHeight = false;
			this.playerListBox.Location = new System.Drawing.Point(0, 0);
			this.playerListBox.Name = "playerListBox";
			this.playerListBox.Size = new System.Drawing.Size(284, 262);
			this.playerListBox.TabIndex = 1;
			this.playerListBox.Click += new System.EventHandler(this.OnPlayerListBoxClick);
			this.playerListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnPlayerListBoxMouseClick);
			this.playerListBox.SelectedIndexChanged += new System.EventHandler(this.OnPlayerListBoxSelectedIndexChanged);
			this.playerListBox.DoubleClick += new System.EventHandler(this.OnPlayerListBoxDoubleClick);
			this.playerListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnPlayerListBoxMouseDoubleClick);
			// 
			// TimpForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.playerListBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "TimpForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Tray Icon Music Player";
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnTimpFormFormClosing);
			this.notifyIconContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ListBox playerListBox;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loopToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem autoplayToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem usehotkeysToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem randomizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
		public System.Windows.Forms.ContextMenuStrip notifyIconContextMenuStrip;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
	}
}

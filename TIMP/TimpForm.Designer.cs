
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
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addToExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startOnLogonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.usehotkeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.shuffledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sortedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.looponeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.looplistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.noLoopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.playerListBox = new System.Windows.Forms.ListBox();
			this.notifyIconContextMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// notifyIconContextMenuStrip
			// 
			this.notifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.openFolderToolStripMenuItem,
									this.toolStripSeparator3,
									this.configToolStripMenuItem,
									this.toolStripSeparator2,
									this.loadToolStripMenuItem,
									this.loopToolStripMenuItem,
									this.toolStripSeparator1,
									this.exitToolStripMenuItem});
			this.notifyIconContextMenuStrip.Name = "notifyIconContextMenuStrip";
			this.notifyIconContextMenuStrip.Size = new System.Drawing.Size(153, 154);
			this.notifyIconContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnNotifyIconContextMenuStripItemClicked);
			// 
			// openFolderToolStripMenuItem
			// 
			this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
			this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.openFolderToolStripMenuItem.Text = "&Open folder";
			this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.OnOpenFolderToolStripMenuItemClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
			// 
			// configToolStripMenuItem
			// 
			this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.autoplayToolStripMenuItem,
									this.addToExplorerToolStripMenuItem,
									this.startOnLogonToolStripMenuItem,
									this.usehotkeysToolStripMenuItem});
			this.configToolStripMenuItem.Name = "configToolStripMenuItem";
			this.configToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.configToolStripMenuItem.Text = "&Config.";
			this.configToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnToggleToolStripMenuItemDropDownItemClicked);
			// 
			// autoplayToolStripMenuItem
			// 
			this.autoplayToolStripMenuItem.Checked = true;
			this.autoplayToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoplayToolStripMenuItem.Name = "autoplayToolStripMenuItem";
			this.autoplayToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.autoplayToolStripMenuItem.Text = "&Autoplay";
			// 
			// addToExplorerToolStripMenuItem
			// 
			this.addToExplorerToolStripMenuItem.Name = "addToExplorerToolStripMenuItem";
			this.addToExplorerToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.addToExplorerToolStripMenuItem.Text = "&Add to explorer";
			// 
			// startOnLogonToolStripMenuItem
			// 
			this.startOnLogonToolStripMenuItem.Name = "startOnLogonToolStripMenuItem";
			this.startOnLogonToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.startOnLogonToolStripMenuItem.Text = "&Start on logon";
			// 
			// usehotkeysToolStripMenuItem
			// 
			this.usehotkeysToolStripMenuItem.Checked = true;
			this.usehotkeysToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.usehotkeysToolStripMenuItem.Name = "usehotkeysToolStripMenuItem";
			this.usehotkeysToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.usehotkeysToolStripMenuItem.Text = "Use &hotkeys";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
			// 
			// loadToolStripMenuItem
			// 
			this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.shuffledToolStripMenuItem,
									this.sortedToolStripMenuItem});
			this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
			this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.loadToolStripMenuItem.Text = "&Load";
			this.loadToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnSelectToolStripMenuItemDropDownItemClicked);
			// 
			// shuffledToolStripMenuItem
			// 
			this.shuffledToolStripMenuItem.Checked = true;
			this.shuffledToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.shuffledToolStripMenuItem.Name = "shuffledToolStripMenuItem";
			this.shuffledToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.shuffledToolStripMenuItem.Text = "&Shuffled";
			// 
			// sortedToolStripMenuItem
			// 
			this.sortedToolStripMenuItem.Name = "sortedToolStripMenuItem";
			this.sortedToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.sortedToolStripMenuItem.Text = "S&orted";
			// 
			// loopToolStripMenuItem
			// 
			this.loopToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.looponeToolStripMenuItem,
									this.looplistToolStripMenuItem,
									this.noLoopToolStripMenuItem});
			this.loopToolStripMenuItem.Name = "loopToolStripMenuItem";
			this.loopToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.loopToolStripMenuItem.Text = "&Loop";
			this.loopToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnSelectToolStripMenuItemDropDownItemClicked);
			// 
			// looponeToolStripMenuItem
			// 
			this.looponeToolStripMenuItem.Name = "looponeToolStripMenuItem";
			this.looponeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.looponeToolStripMenuItem.Text = "Loop &one";
			// 
			// looplistToolStripMenuItem
			// 
			this.looplistToolStripMenuItem.Checked = true;
			this.looplistToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.looplistToolStripMenuItem.Name = "looplistToolStripMenuItem";
			this.looplistToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.looplistToolStripMenuItem.Text = "Loop &list";
			// 
			// noLoopToolStripMenuItem
			// 
			this.noLoopToolStripMenuItem.Name = "noLoopToolStripMenuItem";
			this.noLoopToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.noLoopToolStripMenuItem.Text = "&No loop";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.exitToolStripMenuItem.Text = "&Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExitToolStripMenuItemClick);
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
			this.Load += new System.EventHandler(this.OnTimpFormLoad);
			this.notifyIconContextMenuStrip.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ToolStripMenuItem startOnLogonToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addToExplorerToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem noLoopToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem looplistToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem looponeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sortedToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem shuffledToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ListBox playerListBox;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loopToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem autoplayToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem usehotkeysToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
		public System.Windows.Forms.ContextMenuStrip notifyIconContextMenuStrip;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
	}
}

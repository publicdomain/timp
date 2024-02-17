
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
            if (disposing)
            {
                if (components != null)
                {
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
        	this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.playpauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
        	this.previousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.nextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
        	this.shuffleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
        	this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.autoplayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.addToExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.scansubdirectoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.startOnLogonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.usehotkeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        	this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.shuffledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.sortedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.loopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.looplistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.looponeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.noLoopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        	this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.originalThreadDonationCodercomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.sourceCodeGithubcomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
        	this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.playerDataGridView = new System.Windows.Forms.DataGridView();
        	this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
        	this.hideButton = new System.Windows.Forms.Button();
        	this.firstButton = new System.Windows.Forms.Button();
        	this.previousButton = new System.Windows.Forms.Button();
        	this.playPauseButton = new System.Windows.Forms.Button();
        	this.nextButton = new System.Windows.Forms.Button();
        	this.lastButton = new System.Windows.Forms.Button();
        	this.exitButton = new System.Windows.Forms.Button();
        	this.sortShuffleCheckBox = new System.Windows.Forms.CheckBox();
        	this.loopModeCheckBox = new System.Windows.Forms.CheckBox();
        	this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
        	this.playTimeLabel = new System.Windows.Forms.Label();
        	this.totalTimeLabel = new System.Windows.Forms.Label();
        	this.playTimeTrackBar = new System.Windows.Forms.TrackBar();
        	this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        	this.statusStrip1 = new System.Windows.Forms.StatusStrip();
        	this.tracksTextToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
        	this.tracksToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
        	this.separatorSlashToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
        	this.tipTextToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
        	this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
        	this.tipToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
        	this.notifyIconContextMenuStrip.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.playerDataGridView)).BeginInit();
        	this.tableLayoutPanel3.SuspendLayout();
        	this.tableLayoutPanel2.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.playTimeTrackBar)).BeginInit();
        	this.tableLayoutPanel1.SuspendLayout();
        	this.statusStrip1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// notifyIconContextMenuStrip
        	// 
        	this.notifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.openFolderToolStripMenuItem,
        	        	        	this.actionsToolStripMenuItem,
        	        	        	this.toolStripSeparator3,
        	        	        	this.configToolStripMenuItem,
        	        	        	this.toolStripSeparator2,
        	        	        	this.loadToolStripMenuItem,
        	        	        	this.loopToolStripMenuItem,
        	        	        	this.toolStripSeparator1,
        	        	        	this.helpToolStripMenuItem,
        	        	        	this.exitToolStripMenuItem});
        	this.notifyIconContextMenuStrip.Name = "notifyIconContextMenuStrip";
        	this.notifyIconContextMenuStrip.Size = new System.Drawing.Size(138, 176);
        	this.notifyIconContextMenuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnNotifyIconContextMenuStripItemClicked);
        	// 
        	// openFolderToolStripMenuItem
        	// 
        	this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
        	this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
        	this.openFolderToolStripMenuItem.Text = "&Open folder";
        	this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.OnOpenFolderToolStripMenuItemClick);
        	// 
        	// actionsToolStripMenuItem
        	// 
        	this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.playToolStripMenuItem,
        	        	        	this.pauseToolStripMenuItem,
        	        	        	this.playpauseToolStripMenuItem,
        	        	        	this.stopToolStripMenuItem,
        	        	        	this.toolStripSeparator5,
        	        	        	this.previousToolStripMenuItem,
        	        	        	this.nextToolStripMenuItem,
        	        	        	this.toolStripSeparator4,
        	        	        	this.shuffleToolStripMenuItem,
        	        	        	this.sortToolStripMenuItem});
        	this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
        	this.actionsToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
        	this.actionsToolStripMenuItem.Text = "&Actions";
        	this.actionsToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnActionsToolStripMenuItemDropDownItemClicked);
        	// 
        	// playToolStripMenuItem
        	// 
        	this.playToolStripMenuItem.Name = "playToolStripMenuItem";
        	this.playToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
        	this.playToolStripMenuItem.Text = "&Play";
        	// 
        	// pauseToolStripMenuItem
        	// 
        	this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
        	this.pauseToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
        	this.pauseToolStripMenuItem.Text = "&Pause";
        	// 
        	// playpauseToolStripMenuItem
        	// 
        	this.playpauseToolStripMenuItem.Name = "playpauseToolStripMenuItem";
        	this.playpauseToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
        	this.playpauseToolStripMenuItem.Text = "&Playpause";
        	// 
        	// stopToolStripMenuItem
        	// 
        	this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
        	this.stopToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
        	this.stopToolStripMenuItem.Text = "&Stop";
        	// 
        	// toolStripSeparator5
        	// 
        	this.toolStripSeparator5.Name = "toolStripSeparator5";
        	this.toolStripSeparator5.Size = new System.Drawing.Size(124, 6);
        	// 
        	// previousToolStripMenuItem
        	// 
        	this.previousToolStripMenuItem.Name = "previousToolStripMenuItem";
        	this.previousToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
        	this.previousToolStripMenuItem.Text = "&Previous";
        	// 
        	// nextToolStripMenuItem
        	// 
        	this.nextToolStripMenuItem.Name = "nextToolStripMenuItem";
        	this.nextToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
        	this.nextToolStripMenuItem.Text = "&Next";
        	// 
        	// toolStripSeparator4
        	// 
        	this.toolStripSeparator4.Name = "toolStripSeparator4";
        	this.toolStripSeparator4.Size = new System.Drawing.Size(124, 6);
        	// 
        	// shuffleToolStripMenuItem
        	// 
        	this.shuffleToolStripMenuItem.Name = "shuffleToolStripMenuItem";
        	this.shuffleToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
        	this.shuffleToolStripMenuItem.Text = "&Shuffle";
        	// 
        	// sortToolStripMenuItem
        	// 
        	this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
        	this.sortToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
        	this.sortToolStripMenuItem.Text = "&Sort";
        	// 
        	// toolStripSeparator3
        	// 
        	this.toolStripSeparator3.Name = "toolStripSeparator3";
        	this.toolStripSeparator3.Size = new System.Drawing.Size(134, 6);
        	// 
        	// configToolStripMenuItem
        	// 
        	this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.autoplayToolStripMenuItem,
        	        	        	this.addToExplorerToolStripMenuItem,
        	        	        	this.scansubdirectoriesToolStripMenuItem,
        	        	        	this.startOnLogonToolStripMenuItem,
        	        	        	this.usehotkeysToolStripMenuItem});
        	this.configToolStripMenuItem.Name = "configToolStripMenuItem";
        	this.configToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
        	this.configToolStripMenuItem.Text = "&Config.";
        	this.configToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnToggleToolStripMenuItemDropDownItemClicked);
        	// 
        	// autoplayToolStripMenuItem
        	// 
        	this.autoplayToolStripMenuItem.Checked = true;
        	this.autoplayToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.autoplayToolStripMenuItem.Name = "autoplayToolStripMenuItem";
        	this.autoplayToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
        	this.autoplayToolStripMenuItem.Text = "&Autoplay";
        	// 
        	// addToExplorerToolStripMenuItem
        	// 
        	this.addToExplorerToolStripMenuItem.Name = "addToExplorerToolStripMenuItem";
        	this.addToExplorerToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
        	this.addToExplorerToolStripMenuItem.Text = "&Add to explorer";
        	// 
        	// scansubdirectoriesToolStripMenuItem
        	// 
        	this.scansubdirectoriesToolStripMenuItem.Checked = true;
        	this.scansubdirectoriesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.scansubdirectoriesToolStripMenuItem.Name = "scansubdirectoriesToolStripMenuItem";
        	this.scansubdirectoriesToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
        	this.scansubdirectoriesToolStripMenuItem.Text = "Scan &subdirectories";
        	// 
        	// startOnLogonToolStripMenuItem
        	// 
        	this.startOnLogonToolStripMenuItem.Name = "startOnLogonToolStripMenuItem";
        	this.startOnLogonToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
        	this.startOnLogonToolStripMenuItem.Text = "&Start on logon";
        	// 
        	// usehotkeysToolStripMenuItem
        	// 
        	this.usehotkeysToolStripMenuItem.Checked = true;
        	this.usehotkeysToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.usehotkeysToolStripMenuItem.Name = "usehotkeysToolStripMenuItem";
        	this.usehotkeysToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
        	this.usehotkeysToolStripMenuItem.Text = "Use &hotkeys";
        	// 
        	// toolStripSeparator2
        	// 
        	this.toolStripSeparator2.Name = "toolStripSeparator2";
        	this.toolStripSeparator2.Size = new System.Drawing.Size(134, 6);
        	// 
        	// loadToolStripMenuItem
        	// 
        	this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.shuffledToolStripMenuItem,
        	        	        	this.sortedToolStripMenuItem});
        	this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
        	this.loadToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
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
        	        	        	this.looplistToolStripMenuItem,
        	        	        	this.looponeToolStripMenuItem,
        	        	        	this.noLoopToolStripMenuItem});
        	this.loopToolStripMenuItem.Name = "loopToolStripMenuItem";
        	this.loopToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
        	this.loopToolStripMenuItem.Text = "&Loop";
        	this.loopToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.OnSelectToolStripMenuItemDropDownItemClicked);
        	// 
        	// looplistToolStripMenuItem
        	// 
        	this.looplistToolStripMenuItem.Checked = true;
        	this.looplistToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.looplistToolStripMenuItem.Name = "looplistToolStripMenuItem";
        	this.looplistToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
        	this.looplistToolStripMenuItem.Text = "Loop &list";
        	// 
        	// looponeToolStripMenuItem
        	// 
        	this.looponeToolStripMenuItem.Name = "looponeToolStripMenuItem";
        	this.looponeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
        	this.looponeToolStripMenuItem.Text = "Loop &one";
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
        	this.toolStripSeparator1.Size = new System.Drawing.Size(134, 6);
        	// 
        	// helpToolStripMenuItem
        	// 
        	this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.originalThreadDonationCodercomToolStripMenuItem,
        	        	        	this.sourceCodeGithubcomToolStripMenuItem,
        	        	        	this.toolStripSeparator6,
        	        	        	this.aboutToolStripMenuItem});
        	this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
        	this.helpToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
        	this.helpToolStripMenuItem.Text = "&Help";
        	// 
        	// originalThreadDonationCodercomToolStripMenuItem
        	// 
        	this.originalThreadDonationCodercomToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("originalThreadDonationCodercomToolStripMenuItem.Image")));
        	this.originalThreadDonationCodercomToolStripMenuItem.Name = "originalThreadDonationCodercomToolStripMenuItem";
        	this.originalThreadDonationCodercomToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
        	this.originalThreadDonationCodercomToolStripMenuItem.Text = "&Original thread @ DonationCoder.com";
        	this.originalThreadDonationCodercomToolStripMenuItem.Click += new System.EventHandler(this.OnOriginalThreadDonationCodercomToolStripMenuItemClick);
        	// 
        	// sourceCodeGithubcomToolStripMenuItem
        	// 
        	this.sourceCodeGithubcomToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sourceCodeGithubcomToolStripMenuItem.Image")));
        	this.sourceCodeGithubcomToolStripMenuItem.Name = "sourceCodeGithubcomToolStripMenuItem";
        	this.sourceCodeGithubcomToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
        	this.sourceCodeGithubcomToolStripMenuItem.Text = "Source code @ Github.com";
        	this.sourceCodeGithubcomToolStripMenuItem.Click += new System.EventHandler(this.OnSourceCodeGithubcomToolStripMenuItemClick);
        	// 
        	// toolStripSeparator6
        	// 
        	this.toolStripSeparator6.Name = "toolStripSeparator6";
        	this.toolStripSeparator6.Size = new System.Drawing.Size(275, 6);
        	// 
        	// aboutToolStripMenuItem
        	// 
        	this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        	this.aboutToolStripMenuItem.Size = new System.Drawing.Size(278, 22);
        	this.aboutToolStripMenuItem.Text = "&About...";
        	this.aboutToolStripMenuItem.Click += new System.EventHandler(this.OnAboutToolStripMenuItemClick);
        	// 
        	// exitToolStripMenuItem
        	// 
        	this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        	this.exitToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
        	this.exitToolStripMenuItem.Text = "&Exit";
        	this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExitToolStripMenuItemClick);
        	// 
        	// playerDataGridView
        	// 
        	this.playerDataGridView.AllowUserToAddRows = false;
        	this.playerDataGridView.AllowUserToDeleteRows = false;
        	this.playerDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        	this.playerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.playerDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.playerDataGridView.Location = new System.Drawing.Point(3, 3);
        	this.playerDataGridView.MultiSelect = false;
        	this.playerDataGridView.Name = "playerDataGridView";
        	this.playerDataGridView.ReadOnly = true;
        	this.playerDataGridView.RowHeadersVisible = false;
        	this.playerDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.playerDataGridView.Size = new System.Drawing.Size(378, 155);
        	this.playerDataGridView.StandardTab = true;
        	this.playerDataGridView.TabIndex = 11;
        	this.playerDataGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.OnPlayerDataGridViewCellMouseClick);
        	this.playerDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.OnPlayerDataGridViewDataBindingComplete);
        	this.playerDataGridView.SelectionChanged += new System.EventHandler(this.OnPlayerDataGridViewSelectionChanged);
        	// 
        	// tableLayoutPanel3
        	// 
        	this.tableLayoutPanel3.ColumnCount = 9;
        	this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
        	this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
        	this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
        	this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
        	this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
        	this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
        	this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
        	this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
        	this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
        	this.tableLayoutPanel3.Controls.Add(this.hideButton, 0, 0);
        	this.tableLayoutPanel3.Controls.Add(this.firstButton, 2, 0);
        	this.tableLayoutPanel3.Controls.Add(this.previousButton, 3, 0);
        	this.tableLayoutPanel3.Controls.Add(this.playPauseButton, 4, 0);
        	this.tableLayoutPanel3.Controls.Add(this.nextButton, 5, 0);
        	this.tableLayoutPanel3.Controls.Add(this.lastButton, 6, 0);
        	this.tableLayoutPanel3.Controls.Add(this.exitButton, 8, 0);
        	this.tableLayoutPanel3.Controls.Add(this.sortShuffleCheckBox, 1, 0);
        	this.tableLayoutPanel3.Controls.Add(this.loopModeCheckBox, 7, 0);
        	this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 196);
        	this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
        	this.tableLayoutPanel3.Name = "tableLayoutPanel3";
        	this.tableLayoutPanel3.RowCount = 1;
        	this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.tableLayoutPanel3.Size = new System.Drawing.Size(384, 50);
        	this.tableLayoutPanel3.TabIndex = 3;
        	// 
        	// hideButton
        	// 
        	this.hideButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("hideButton.BackgroundImage")));
        	this.hideButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        	this.hideButton.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.hideButton.Location = new System.Drawing.Point(3, 3);
        	this.hideButton.Name = "hideButton";
        	this.hideButton.Size = new System.Drawing.Size(32, 44);
        	this.hideButton.TabIndex = 7;
        	this.hideButton.UseVisualStyleBackColor = true;
        	this.hideButton.Click += new System.EventHandler(this.OnHideButtonClick);
        	this.hideButton.MouseEnter += new System.EventHandler(this.OnButtonMouseEnter);
        	this.hideButton.MouseLeave += new System.EventHandler(this.OnButtonMouseLeave);
        	// 
        	// firstButton
        	// 
        	this.firstButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("firstButton.BackgroundImage")));
        	this.firstButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        	this.firstButton.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.firstButton.Location = new System.Drawing.Point(79, 3);
        	this.firstButton.Name = "firstButton";
        	this.firstButton.Size = new System.Drawing.Size(32, 44);
        	this.firstButton.TabIndex = 3;
        	this.firstButton.UseVisualStyleBackColor = true;
        	this.firstButton.Click += new System.EventHandler(this.OnFirstButtonClick);
        	this.firstButton.MouseEnter += new System.EventHandler(this.OnButtonMouseEnter);
        	this.firstButton.MouseLeave += new System.EventHandler(this.OnButtonMouseLeave);
        	// 
        	// previousButton
        	// 
        	this.previousButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("previousButton.BackgroundImage")));
        	this.previousButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        	this.previousButton.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.previousButton.Location = new System.Drawing.Point(117, 3);
        	this.previousButton.Name = "previousButton";
        	this.previousButton.Size = new System.Drawing.Size(32, 44);
        	this.previousButton.TabIndex = 1;
        	this.previousButton.UseVisualStyleBackColor = true;
        	this.previousButton.Click += new System.EventHandler(this.OnPreviousButtonClick);
        	this.previousButton.MouseEnter += new System.EventHandler(this.OnButtonMouseEnter);
        	this.previousButton.MouseLeave += new System.EventHandler(this.OnButtonMouseLeave);
        	// 
        	// playPauseButton
        	// 
        	this.playPauseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("playPauseButton.BackgroundImage")));
        	this.playPauseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        	this.playPauseButton.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.playPauseButton.Location = new System.Drawing.Point(155, 3);
        	this.playPauseButton.Name = "playPauseButton";
        	this.playPauseButton.Size = new System.Drawing.Size(70, 44);
        	this.playPauseButton.TabIndex = 0;
        	this.playPauseButton.UseVisualStyleBackColor = true;
        	this.playPauseButton.Click += new System.EventHandler(this.OnPlayPauseButtonClick);
        	this.playPauseButton.MouseEnter += new System.EventHandler(this.OnButtonMouseEnter);
        	this.playPauseButton.MouseLeave += new System.EventHandler(this.OnButtonMouseLeave);
        	// 
        	// nextButton
        	// 
        	this.nextButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("nextButton.BackgroundImage")));
        	this.nextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        	this.nextButton.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.nextButton.Location = new System.Drawing.Point(231, 3);
        	this.nextButton.Name = "nextButton";
        	this.nextButton.Size = new System.Drawing.Size(32, 44);
        	this.nextButton.TabIndex = 2;
        	this.nextButton.UseVisualStyleBackColor = true;
        	this.nextButton.Click += new System.EventHandler(this.OnNextButtonClick);
        	this.nextButton.MouseEnter += new System.EventHandler(this.OnButtonMouseEnter);
        	this.nextButton.MouseLeave += new System.EventHandler(this.OnButtonMouseLeave);
        	// 
        	// lastButton
        	// 
        	this.lastButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lastButton.BackgroundImage")));
        	this.lastButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        	this.lastButton.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.lastButton.Location = new System.Drawing.Point(269, 3);
        	this.lastButton.Name = "lastButton";
        	this.lastButton.Size = new System.Drawing.Size(32, 44);
        	this.lastButton.TabIndex = 4;
        	this.lastButton.UseVisualStyleBackColor = true;
        	this.lastButton.Click += new System.EventHandler(this.OnLastButtonClick);
        	this.lastButton.MouseEnter += new System.EventHandler(this.OnButtonMouseEnter);
        	this.lastButton.MouseLeave += new System.EventHandler(this.OnButtonMouseLeave);
        	// 
        	// exitButton
        	// 
        	this.exitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exitButton.BackgroundImage")));
        	this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        	this.exitButton.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.exitButton.Location = new System.Drawing.Point(345, 3);
        	this.exitButton.Name = "exitButton";
        	this.exitButton.Size = new System.Drawing.Size(36, 44);
        	this.exitButton.TabIndex = 8;
        	this.exitButton.Text = "button9";
        	this.exitButton.UseVisualStyleBackColor = true;
        	this.exitButton.Click += new System.EventHandler(this.OnExitButtonClick);
        	this.exitButton.MouseEnter += new System.EventHandler(this.OnButtonMouseEnter);
        	this.exitButton.MouseLeave += new System.EventHandler(this.OnButtonMouseLeave);
        	// 
        	// sortShuffleCheckBox
        	// 
        	this.sortShuffleCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
        	this.sortShuffleCheckBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("sortShuffleCheckBox.BackgroundImage")));
        	this.sortShuffleCheckBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        	this.sortShuffleCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.sortShuffleCheckBox.Location = new System.Drawing.Point(41, 3);
        	this.sortShuffleCheckBox.Name = "sortShuffleCheckBox";
        	this.sortShuffleCheckBox.Size = new System.Drawing.Size(32, 44);
        	this.sortShuffleCheckBox.TabIndex = 5;
        	this.sortShuffleCheckBox.UseVisualStyleBackColor = true;
        	this.sortShuffleCheckBox.CheckedChanged += new System.EventHandler(this.OnSortShuffleCheckBoxCheckedChanged);
        	this.sortShuffleCheckBox.MouseEnter += new System.EventHandler(this.OnButtonMouseEnter);
        	this.sortShuffleCheckBox.MouseLeave += new System.EventHandler(this.OnButtonMouseLeave);
        	// 
        	// loopModeCheckBox
        	// 
        	this.loopModeCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
        	this.loopModeCheckBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("loopModeCheckBox.BackgroundImage")));
        	this.loopModeCheckBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        	this.loopModeCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.loopModeCheckBox.Location = new System.Drawing.Point(307, 3);
        	this.loopModeCheckBox.Name = "loopModeCheckBox";
        	this.loopModeCheckBox.Size = new System.Drawing.Size(32, 44);
        	this.loopModeCheckBox.TabIndex = 6;
        	this.loopModeCheckBox.ThreeState = true;
        	this.loopModeCheckBox.UseVisualStyleBackColor = true;
        	this.loopModeCheckBox.CheckedChanged += new System.EventHandler(this.OnLoopModeCheckBoxCheckedChanged);
        	this.loopModeCheckBox.MouseEnter += new System.EventHandler(this.OnButtonMouseEnter);
        	this.loopModeCheckBox.MouseLeave += new System.EventHandler(this.OnButtonMouseLeave);
        	// 
        	// tableLayoutPanel2
        	// 
        	this.tableLayoutPanel2.ColumnCount = 3;
        	this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
        	this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
        	this.tableLayoutPanel2.Controls.Add(this.playTimeLabel, 0, 0);
        	this.tableLayoutPanel2.Controls.Add(this.totalTimeLabel, 2, 0);
        	this.tableLayoutPanel2.Controls.Add(this.playTimeTrackBar, 1, 0);
        	this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 161);
        	this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
        	this.tableLayoutPanel2.Name = "tableLayoutPanel2";
        	this.tableLayoutPanel2.RowCount = 1;
        	this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.tableLayoutPanel2.Size = new System.Drawing.Size(384, 35);
        	this.tableLayoutPanel2.TabIndex = 2;
        	// 
        	// playTimeLabel
        	// 
        	this.playTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.playTimeLabel.Location = new System.Drawing.Point(3, 0);
        	this.playTimeLabel.Name = "playTimeLabel";
        	this.playTimeLabel.Size = new System.Drawing.Size(44, 35);
        	this.playTimeLabel.TabIndex = 0;
        	this.playTimeLabel.Text = "00:00";
        	this.playTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// totalTimeLabel
        	// 
        	this.totalTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.totalTimeLabel.Location = new System.Drawing.Point(337, 0);
        	this.totalTimeLabel.Name = "totalTimeLabel";
        	this.totalTimeLabel.Size = new System.Drawing.Size(44, 35);
        	this.totalTimeLabel.TabIndex = 1;
        	this.totalTimeLabel.Text = "00:00";
        	this.totalTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// playTimeTrackBar
        	// 
        	this.playTimeTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.playTimeTrackBar.Location = new System.Drawing.Point(53, 3);
        	this.playTimeTrackBar.Maximum = 100;
        	this.playTimeTrackBar.Name = "playTimeTrackBar";
        	this.playTimeTrackBar.Size = new System.Drawing.Size(278, 29);
        	this.playTimeTrackBar.TabIndex = 10;
        	this.playTimeTrackBar.Scroll += new System.EventHandler(this.OnPlayTimeTrackBarScroll);
        	this.playTimeTrackBar.ValueChanged += new System.EventHandler(this.OnPlayTimeTrackBarValueChanged);
        	// 
        	// tableLayoutPanel1
        	// 
        	this.tableLayoutPanel1.ColumnCount = 1;
        	this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
        	this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
        	this.tableLayoutPanel1.Controls.Add(this.playerDataGridView, 0, 0);
        	this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        	this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        	this.tableLayoutPanel1.RowCount = 4;
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
        	this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
        	this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 266);
        	this.tableLayoutPanel1.TabIndex = 1;
        	// 
        	// statusStrip1
        	// 
        	this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.tracksTextToolStripStatusLabel,
        	        	        	this.tracksToolStripStatusLabel,
        	        	        	this.separatorSlashToolStripStatusLabel,
        	        	        	this.tipTextToolStripStatusLabel,
        	        	        	this.toolStripStatusLabel1,
        	        	        	this.tipToolStripStatusLabel});
        	this.statusStrip1.Location = new System.Drawing.Point(0, 244);
        	this.statusStrip1.Name = "statusStrip1";
        	this.statusStrip1.Size = new System.Drawing.Size(384, 22);
        	this.statusStrip1.TabIndex = 2;
        	this.statusStrip1.Text = "statusStrip1";
        	// 
        	// tracksTextToolStripStatusLabel
        	// 
        	this.tracksTextToolStripStatusLabel.Name = "tracksTextToolStripStatusLabel";
        	this.tracksTextToolStripStatusLabel.Size = new System.Drawing.Size(44, 17);
        	this.tracksTextToolStripStatusLabel.Text = "Tracks:";
        	// 
        	// tracksToolStripStatusLabel
        	// 
        	this.tracksToolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.tracksToolStripStatusLabel.Name = "tracksToolStripStatusLabel";
        	this.tracksToolStripStatusLabel.Size = new System.Drawing.Size(14, 17);
        	this.tracksToolStripStatusLabel.Text = "0";
        	// 
        	// separatorSlashToolStripStatusLabel
        	// 
        	this.separatorSlashToolStripStatusLabel.Name = "separatorSlashToolStripStatusLabel";
        	this.separatorSlashToolStripStatusLabel.Size = new System.Drawing.Size(12, 17);
        	this.separatorSlashToolStripStatusLabel.Text = "/";
        	// 
        	// tipTextToolStripStatusLabel
        	// 
        	this.tipTextToolStripStatusLabel.Name = "tipTextToolStripStatusLabel";
        	this.tipTextToolStripStatusLabel.Size = new System.Drawing.Size(27, 17);
        	this.tipTextToolStripStatusLabel.Text = "Tip:";
        	// 
        	// toolStripStatusLabel1
        	// 
        	this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
        	this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
        	// 
        	// tipToolStripStatusLabel
        	// 
        	this.tipToolStripStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.tipToolStripStatusLabel.Name = "tipToolStripStatusLabel";
        	this.tipToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
        	// 
        	// TimpForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(384, 266);
        	this.Controls.Add(this.statusStrip1);
        	this.Controls.Add(this.tableLayoutPanel1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Name = "TimpForm";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        	this.Text = "Tray Icon Music Player";
        	this.TopMost = true;
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnTimpFormFormClosing);
        	this.Load += new System.EventHandler(this.OnTimpFormLoad);
        	this.notifyIconContextMenuStrip.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.playerDataGridView)).EndInit();
        	this.tableLayoutPanel3.ResumeLayout(false);
        	this.tableLayoutPanel2.ResumeLayout(false);
        	this.tableLayoutPanel2.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.playTimeTrackBar)).EndInit();
        	this.tableLayoutPanel1.ResumeLayout(false);
        	this.statusStrip1.ResumeLayout(false);
        	this.statusStrip1.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.ToolStripStatusLabel tipToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tipTextToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel separatorSlashToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel tracksToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel tracksTextToolStripStatusLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView playerDataGridView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem sourceCodeGithubcomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scansubdirectoriesToolStripMenuItem;
        private System.Windows.Forms.CheckBox loopModeCheckBox;
        private System.Windows.Forms.CheckBox sortShuffleCheckBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button lastButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button playPauseButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button firstButton;
        private System.Windows.Forms.Button hideButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TrackBar playTimeTrackBar;
        private System.Windows.Forms.Label totalTimeLabel;
        private System.Windows.Forms.Label playTimeLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem originalThreadDonationCodercomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shuffleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem nextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playpauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoplayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usehotkeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        public System.Windows.Forms.ContextMenuStrip notifyIconContextMenuStrip;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

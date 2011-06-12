﻿namespace BizHawk.MultiClient
{
    partial class TAStudio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TAStudio));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveProjectAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.recentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.nToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.importTASFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.insertFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveWindowPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.restoreWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TASView = new BizHawk.VirtualListView();
			this.Frame = new System.Windows.Forms.ColumnHeader();
			this.Log = new System.Windows.Forms.ColumnHeader();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.RewindToBeginning = new System.Windows.Forms.ToolStripButton();
			this.RewindButton = new System.Windows.Forms.ToolStripButton();
			this.PauseButton = new System.Windows.Forms.ToolStripButton();
			this.FrameAdvanceButton = new System.Windows.Forms.ToolStripButton();
			this.FastFowardToEnd = new System.Windows.Forms.ToolStripButton();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.StopButton = new System.Windows.Forms.ToolStripButton();
			this.PlayMovieFromBeginning = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.ReadOnlyCheckBox = new System.Windows.Forms.CheckBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.insertFrameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.Pad1 = new BizHawk.MultiClient.VirtualPadNES();
			this.menuStrip1.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.settingsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(789, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectToolStripMenuItem,
            this.openProjectToolStripMenuItem,
            this.saveProjectToolStripMenuItem,
            this.saveProjectAsToolStripMenuItem,
            this.recentToolStripMenuItem,
            this.toolStripSeparator1,
            this.importTASFileToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newProjectToolStripMenuItem
			// 
			this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
			this.newProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.newProjectToolStripMenuItem.Text = "New Project";
			// 
			// openProjectToolStripMenuItem
			// 
			this.openProjectToolStripMenuItem.Name = "openProjectToolStripMenuItem";
			this.openProjectToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openProjectToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.openProjectToolStripMenuItem.Text = "&Open Project";
			// 
			// saveProjectToolStripMenuItem
			// 
			this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
			this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.saveProjectToolStripMenuItem.Text = "&Save Project";
			// 
			// saveProjectAsToolStripMenuItem
			// 
			this.saveProjectAsToolStripMenuItem.Name = "saveProjectAsToolStripMenuItem";
			this.saveProjectAsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.saveProjectAsToolStripMenuItem.Text = "Save Project As";
			// 
			// recentToolStripMenuItem
			// 
			this.recentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nToolStripMenuItem,
            this.toolStripSeparator3,
            this.clearToolStripMenuItem});
			this.recentToolStripMenuItem.Name = "recentToolStripMenuItem";
			this.recentToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.recentToolStripMenuItem.Text = "Recent";
			// 
			// nToolStripMenuItem
			// 
			this.nToolStripMenuItem.Name = "nToolStripMenuItem";
			this.nToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
			this.nToolStripMenuItem.Text = "None";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(107, 6);
			// 
			// clearToolStripMenuItem
			// 
			this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
			this.clearToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
			this.clearToolStripMenuItem.Text = "Clear";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
			// 
			// importTASFileToolStripMenuItem
			// 
			this.importTASFileToolStripMenuItem.Name = "importTASFileToolStripMenuItem";
			this.importTASFileToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.importTASFileToolStripMenuItem.Text = "Import TAS file";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(185, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertFrameToolStripMenuItem});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.editToolStripMenuItem.Text = "&Edit";
			this.editToolStripMenuItem.DropDownOpened += new System.EventHandler(this.editToolStripMenuItem_DropDownOpened);
			// 
			// insertFrameToolStripMenuItem
			// 
			this.insertFrameToolStripMenuItem.Name = "insertFrameToolStripMenuItem";
			this.insertFrameToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.insertFrameToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
			this.insertFrameToolStripMenuItem.Text = "Insert Frame";
			this.insertFrameToolStripMenuItem.Click += new System.EventHandler(this.insertFrameToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveWindowPositionToolStripMenuItem,
            this.restoreWindowToolStripMenuItem,
            this.autoloadToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
			this.settingsToolStripMenuItem.Text = "&Settings";
			this.settingsToolStripMenuItem.DropDownOpened += new System.EventHandler(this.settingsToolStripMenuItem_DropDownOpened);
			// 
			// saveWindowPositionToolStripMenuItem
			// 
			this.saveWindowPositionToolStripMenuItem.Name = "saveWindowPositionToolStripMenuItem";
			this.saveWindowPositionToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.saveWindowPositionToolStripMenuItem.Text = "Save Window Position";
			this.saveWindowPositionToolStripMenuItem.Click += new System.EventHandler(this.saveWindowPositionToolStripMenuItem_Click);
			// 
			// restoreWindowToolStripMenuItem
			// 
			this.restoreWindowToolStripMenuItem.Name = "restoreWindowToolStripMenuItem";
			this.restoreWindowToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.restoreWindowToolStripMenuItem.Text = "Restore Default Settings";
			this.restoreWindowToolStripMenuItem.Click += new System.EventHandler(this.restoreWindowToolStripMenuItem_Click);
			// 
			// autoloadToolStripMenuItem
			// 
			this.autoloadToolStripMenuItem.Name = "autoloadToolStripMenuItem";
			this.autoloadToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.autoloadToolStripMenuItem.Text = "Autoload";
			this.autoloadToolStripMenuItem.Click += new System.EventHandler(this.autoloadToolStripMenuItem_Click);
			// 
			// TASView
			// 
			this.TASView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Frame,
            this.Log});
			this.TASView.GridLines = true;
			this.TASView.ItemCount = 0;
			this.TASView.Location = new System.Drawing.Point(22, 38);
			this.TASView.Name = "TASView";
			this.TASView.selectedItem = -1;
			this.TASView.Size = new System.Drawing.Size(335, 424);
			this.TASView.TabIndex = 1;
			this.TASView.UseCompatibleStateImageBehavior = false;
			this.TASView.View = System.Windows.Forms.View.Details;
			// 
			// Frame
			// 
			this.Frame.Text = "Frame";
			// 
			// Log
			// 
			this.Log.Text = "Log";
			this.Log.Width = 150;
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(172, 3);
			this.toolStripContainer1.Location = new System.Drawing.Point(373, 38);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.Size = new System.Drawing.Size(172, 53);
			this.toolStripContainer1.TabIndex = 2;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RewindToBeginning,
            this.RewindButton,
            this.PauseButton,
            this.FrameAdvanceButton,
            this.FastFowardToEnd});
			this.toolStrip1.Location = new System.Drawing.Point(3, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(125, 25);
			this.toolStrip1.TabIndex = 0;
			// 
			// RewindToBeginning
			// 
			this.RewindToBeginning.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.RewindToBeginning.Image = global::BizHawk.MultiClient.Properties.Resources.BackMore;
			this.RewindToBeginning.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RewindToBeginning.Name = "RewindToBeginning";
			this.RewindToBeginning.Size = new System.Drawing.Size(23, 22);
			this.RewindToBeginning.Text = "<<";
			this.RewindToBeginning.ToolTipText = "Rewind to Beginning";
			this.RewindToBeginning.Click += new System.EventHandler(this.RewindToBeginning_Click);
			// 
			// RewindButton
			// 
			this.RewindButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.RewindButton.Image = global::BizHawk.MultiClient.Properties.Resources.Back;
			this.RewindButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.RewindButton.Name = "RewindButton";
			this.RewindButton.Size = new System.Drawing.Size(23, 22);
			this.RewindButton.Text = "<";
			this.RewindButton.ToolTipText = "Rewind";
			this.RewindButton.Click += new System.EventHandler(this.RewindButton_Click);
			// 
			// PauseButton
			// 
			this.PauseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.PauseButton.Image = global::BizHawk.MultiClient.Properties.Resources.Pause;
			this.PauseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PauseButton.Name = "PauseButton";
			this.PauseButton.Size = new System.Drawing.Size(23, 22);
			this.PauseButton.Text = "Pause Button";
			this.PauseButton.ToolTipText = "Pause";
			this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
			// 
			// FrameAdvanceButton
			// 
			this.FrameAdvanceButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.FrameAdvanceButton.Image = global::BizHawk.MultiClient.Properties.Resources.Forward;
			this.FrameAdvanceButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.FrameAdvanceButton.Name = "FrameAdvanceButton";
			this.FrameAdvanceButton.Size = new System.Drawing.Size(23, 22);
			this.FrameAdvanceButton.Text = ">";
			this.FrameAdvanceButton.ToolTipText = "Frame Advance";
			this.FrameAdvanceButton.Click += new System.EventHandler(this.FrameAdvanceButton_Click);
			// 
			// FastFowardToEnd
			// 
			this.FastFowardToEnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.FastFowardToEnd.Image = global::BizHawk.MultiClient.Properties.Resources.ForwardMore;
			this.FastFowardToEnd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.FastFowardToEnd.Name = "FastFowardToEnd";
			this.FastFowardToEnd.Size = new System.Drawing.Size(23, 22);
			this.FastFowardToEnd.Text = ">>";
			this.FastFowardToEnd.ToolTipText = "Fast Foward To End";
			this.FastFowardToEnd.Click += new System.EventHandler(this.FastForwardToEnd_Click);
			// 
			// toolStrip2
			// 
			this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StopButton,
            this.PlayMovieFromBeginning,
            this.toolStripSeparator4});
			this.toolStrip2.Location = new System.Drawing.Point(3, 25);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(62, 25);
			this.toolStrip2.TabIndex = 1;
			// 
			// StopButton
			// 
			this.StopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.StopButton.Image = global::BizHawk.MultiClient.Properties.Resources.Stop;
			this.StopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.StopButton.Name = "StopButton";
			this.StopButton.Size = new System.Drawing.Size(23, 22);
			this.StopButton.Text = "Stop Movie";
			// 
			// PlayMovieFromBeginning
			// 
			this.PlayMovieFromBeginning.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.PlayMovieFromBeginning.Image = ((System.Drawing.Image)(resources.GetObject("PlayMovieFromBeginning.Image")));
			this.PlayMovieFromBeginning.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.PlayMovieFromBeginning.Name = "PlayMovieFromBeginning";
			this.PlayMovieFromBeginning.Size = new System.Drawing.Size(23, 22);
			this.PlayMovieFromBeginning.Text = "|";
			this.PlayMovieFromBeginning.ToolTipText = "Rewind to Beginning";
			this.PlayMovieFromBeginning.Click += new System.EventHandler(this.PlayMovieFromBeginning_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// ReadOnlyCheckBox
			// 
			this.ReadOnlyCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
			this.ReadOnlyCheckBox.AutoSize = true;
			this.ReadOnlyCheckBox.BackColor = System.Drawing.SystemColors.Control;
			this.ReadOnlyCheckBox.Image = global::BizHawk.MultiClient.Properties.Resources.ReadOnly;
			this.ReadOnlyCheckBox.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.ReadOnlyCheckBox.Location = new System.Drawing.Point(551, 38);
			this.ReadOnlyCheckBox.Name = "ReadOnlyCheckBox";
			this.ReadOnlyCheckBox.Size = new System.Drawing.Size(22, 22);
			this.ReadOnlyCheckBox.TabIndex = 3;
			this.toolTip1.SetToolTip(this.ReadOnlyCheckBox, "Read-only");
			this.ReadOnlyCheckBox.UseVisualStyleBackColor = false;
			this.ReadOnlyCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertFrameToolStripMenuItem1,
            this.toolStripSeparator5,
            this.selectAllToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(148, 54);
			// 
			// insertFrameToolStripMenuItem1
			// 
			this.insertFrameToolStripMenuItem1.Name = "insertFrameToolStripMenuItem1";
			this.insertFrameToolStripMenuItem1.Size = new System.Drawing.Size(147, 22);
			this.insertFrameToolStripMenuItem1.Text = "Insert Frame";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(144, 6);
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
			this.selectAllToolStripMenuItem.Text = "Select All";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.Pad1);
			this.groupBox1.Location = new System.Drawing.Point(373, 108);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(401, 197);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Controllers";
			// 
			// Pad1
			// 
			this.Pad1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Pad1.Location = new System.Drawing.Point(6, 19);
			this.Pad1.Name = "Pad1";
			this.Pad1.Size = new System.Drawing.Size(174, 74);
			this.Pad1.TabIndex = 0;
			// 
			// TAStudio
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(789, 474);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.ReadOnlyCheckBox);
			this.Controls.Add(this.toolStripContainer1);
			this.Controls.Add(this.TASView);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "TAStudio";
			this.Text = "TAStudio";
			this.Load += new System.EventHandler(this.TAStudio_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveProjectAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem importTASFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveWindowPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreWindowToolStripMenuItem;
        private VirtualListView TASView;
		private System.Windows.Forms.ColumnHeader Log;
        private System.Windows.Forms.ToolStripMenuItem recentToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem nToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton FrameAdvanceButton;
        private System.Windows.Forms.ToolStripButton RewindButton;
        private System.Windows.Forms.ToolStripButton PauseButton;
		private System.Windows.Forms.ToolStrip toolStrip2;
		private System.Windows.Forms.ToolStripButton StopButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem autoloadToolStripMenuItem;
		private System.Windows.Forms.CheckBox ReadOnlyCheckBox;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ColumnHeader Frame;
		private System.Windows.Forms.ToolStripButton RewindToBeginning;
		private System.Windows.Forms.ToolStripButton FastFowardToEnd;
		private System.Windows.Forms.ToolStripButton PlayMovieFromBeginning;
		private System.Windows.Forms.ToolStripMenuItem insertFrameToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem insertFrameToolStripMenuItem1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBox1;
		private VirtualPadNES Pad1;
    }
}
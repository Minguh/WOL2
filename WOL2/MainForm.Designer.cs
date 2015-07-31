/*
 * Windows Forms Designer for WOL2 Main Form
 */
using System;
using System.Windows.Forms;
using System.Threading;

namespace WOL2
{
	partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ToolStripMenuItem shutdownTimerToolStripMenuItem;
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStripTools = new System.Windows.Forms.ToolStrip();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.cmGroups = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.wakeGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebootGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.setGroupNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.editTimerToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.wakeGroupTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebootGroupTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownGroupTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmHost = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.wakeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editTimerToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.wakeTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebootTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.assignToGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignGrpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dummy1ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.executeToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dummy1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListLarge = new System.Windows.Forms.ImageList(this.components);
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_NewFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_OpenFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_SaveFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_NewHost = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_EditHost = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_DeleteHost = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_WakeHost = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_RebootHost = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ShutdownHost = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnNote = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMRU = new System.Windows.Forms.ToolStripMenuItem();
            this.mRUToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewHostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCurrentHostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCurrentHostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.openNetworkScannerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanForNewHostsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.periodicallyScanForNewHostsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.editTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xMLFileportableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsRegisrtryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listViewStyleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openOnlineSurveyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tmrAlarm = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showWOL2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.exitWOL2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tmrPeriodicScan = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            shutdownTimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.cmGroups.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.cmHost.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.cmTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            resources.ApplyResources(this.toolStripContainer1, "toolStripContainer1");
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.BottomToolStripPanel, "toolStripContainer1.BottomToolStripPanel");
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.toolStripTools);
            this.toolTip.SetToolTip(this.toolStripContainer1.BottomToolStripPanel, resources.GetString("toolStripContainer1.BottomToolStripPanel.ToolTip"));
            // 
            // toolStripContainer1.ContentPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tabControl);
            this.toolTip.SetToolTip(this.toolStripContainer1.ContentPanel, resources.GetString("toolStripContainer1.ContentPanel.ToolTip"));
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.LeftToolStripPanel, "toolStripContainer1.LeftToolStripPanel");
            this.toolTip.SetToolTip(this.toolStripContainer1.LeftToolStripPanel, resources.GetString("toolStripContainer1.LeftToolStripPanel.ToolTip"));
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.RightToolStripPanel, "toolStripContainer1.RightToolStripPanel");
            this.toolTip.SetToolTip(this.toolStripContainer1.RightToolStripPanel, resources.GetString("toolStripContainer1.RightToolStripPanel.ToolTip"));
            this.toolTip.SetToolTip(this.toolStripContainer1, resources.GetString("toolStripContainer1.ToolTip"));
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.TopToolStripPanel, "toolStripContainer1.TopToolStripPanel");
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolTip.SetToolTip(this.toolStripContainer1.TopToolStripPanel, resources.GetString("toolStripContainer1.TopToolStripPanel.ToolTip"));
            // 
            // toolStripTools
            // 
            resources.ApplyResources(this.toolStripTools, "toolStripTools");
            this.toolStripTools.AllowItemReorder = true;
            this.toolStripTools.Name = "toolStripTools";
            this.toolTip.SetToolTip(this.toolStripTools, resources.GetString("toolStripTools.ToolTip"));
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.ContextMenuStrip = this.cmGroups;
            this.tabControl.Controls.Add(this.tabPageMain);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.toolTip.SetToolTip(this.tabControl, resources.GetString("tabControl.ToolTip"));
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControlSelectedIndexChanged);
            // 
            // cmGroups
            // 
            resources.ApplyResources(this.cmGroups, "cmGroups");
            this.cmGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wakeGroupToolStripMenuItem,
            this.rebootGroupToolStripMenuItem,
            this.shutdownGroupToolStripMenuItem,
            this.toolStripSeparator10,
            this.setGroupNameToolStripMenuItem,
            this.addGroupToolStripMenuItem,
            this.removeGroupToolStripMenuItem,
            this.toolStripSeparator6,
            this.editTimerToolStripMenuItem1});
            this.cmGroups.Name = "contextMenuGroups";
            this.toolTip.SetToolTip(this.cmGroups, resources.GetString("cmGroups.ToolTip"));
            // 
            // wakeGroupToolStripMenuItem
            // 
            resources.ApplyResources(this.wakeGroupToolStripMenuItem, "wakeGroupToolStripMenuItem");
            this.wakeGroupToolStripMenuItem.Name = "wakeGroupToolStripMenuItem";
            this.wakeGroupToolStripMenuItem.Click += new System.EventHandler(this.WakeGroupToolStripMenuItemClick);
            // 
            // rebootGroupToolStripMenuItem
            // 
            resources.ApplyResources(this.rebootGroupToolStripMenuItem, "rebootGroupToolStripMenuItem");
            this.rebootGroupToolStripMenuItem.Name = "rebootGroupToolStripMenuItem";
            this.rebootGroupToolStripMenuItem.Click += new System.EventHandler(this.RebootGroupToolStripMenuItemClick);
            // 
            // shutdownGroupToolStripMenuItem
            // 
            resources.ApplyResources(this.shutdownGroupToolStripMenuItem, "shutdownGroupToolStripMenuItem");
            this.shutdownGroupToolStripMenuItem.Name = "shutdownGroupToolStripMenuItem";
            this.shutdownGroupToolStripMenuItem.Click += new System.EventHandler(this.ShutdownGroupToolStripMenuItemClick);
            // 
            // toolStripSeparator10
            // 
            resources.ApplyResources(this.toolStripSeparator10, "toolStripSeparator10");
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            // 
            // setGroupNameToolStripMenuItem
            // 
            resources.ApplyResources(this.setGroupNameToolStripMenuItem, "setGroupNameToolStripMenuItem");
            this.setGroupNameToolStripMenuItem.Name = "setGroupNameToolStripMenuItem";
            this.setGroupNameToolStripMenuItem.Click += new System.EventHandler(this.SetGroupNameToolStripMenuItemClick);
            // 
            // addGroupToolStripMenuItem
            // 
            resources.ApplyResources(this.addGroupToolStripMenuItem, "addGroupToolStripMenuItem");
            this.addGroupToolStripMenuItem.Name = "addGroupToolStripMenuItem";
            this.addGroupToolStripMenuItem.Click += new System.EventHandler(this.AddGroupToolStripMenuItemClick);
            // 
            // removeGroupToolStripMenuItem
            // 
            resources.ApplyResources(this.removeGroupToolStripMenuItem, "removeGroupToolStripMenuItem");
            this.removeGroupToolStripMenuItem.Name = "removeGroupToolStripMenuItem";
            this.removeGroupToolStripMenuItem.Click += new System.EventHandler(this.RemoveGroupToolStripMenuItemClick);
            // 
            // toolStripSeparator6
            // 
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            // 
            // editTimerToolStripMenuItem1
            // 
            resources.ApplyResources(this.editTimerToolStripMenuItem1, "editTimerToolStripMenuItem1");
            this.editTimerToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wakeGroupTimerToolStripMenuItem,
            this.rebootGroupTimerToolStripMenuItem,
            this.shutdownGroupTimerToolStripMenuItem});
            this.editTimerToolStripMenuItem1.Name = "editTimerToolStripMenuItem1";
            this.editTimerToolStripMenuItem1.Click += new System.EventHandler(this.EditTimerToolStripMenuItem1Click);
            // 
            // wakeGroupTimerToolStripMenuItem
            // 
            resources.ApplyResources(this.wakeGroupTimerToolStripMenuItem, "wakeGroupTimerToolStripMenuItem");
            this.wakeGroupTimerToolStripMenuItem.Name = "wakeGroupTimerToolStripMenuItem";
            this.wakeGroupTimerToolStripMenuItem.Click += new System.EventHandler(this.wakeGroupTimerToolStripMenuItem_Click);
            // 
            // rebootGroupTimerToolStripMenuItem
            // 
            resources.ApplyResources(this.rebootGroupTimerToolStripMenuItem, "rebootGroupTimerToolStripMenuItem");
            this.rebootGroupTimerToolStripMenuItem.Name = "rebootGroupTimerToolStripMenuItem";
            this.rebootGroupTimerToolStripMenuItem.Click += new System.EventHandler(this.rebootGroupTimerToolStripMenuItem_Click);
            // 
            // shutdownGroupTimerToolStripMenuItem
            // 
            resources.ApplyResources(this.shutdownGroupTimerToolStripMenuItem, "shutdownGroupTimerToolStripMenuItem");
            this.shutdownGroupTimerToolStripMenuItem.Name = "shutdownGroupTimerToolStripMenuItem";
            this.shutdownGroupTimerToolStripMenuItem.Click += new System.EventHandler(this.shutdownGroupTimerToolStripMenuItem_Click);
            // 
            // tabPageMain
            // 
            resources.ApplyResources(this.tabPageMain, "tabPageMain");
            this.tabPageMain.Controls.Add(this.listView);
            this.tabPageMain.Name = "tabPageMain";
            this.toolTip.SetToolTip(this.tabPageMain, resources.GetString("tabPageMain.ToolTip"));
            this.tabPageMain.UseVisualStyleBackColor = true;
            // 
            // listView
            // 
            resources.ApplyResources(this.listView, "listView");
            this.listView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView.AllowColumnReorder = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17});
            this.listView.ContextMenuStrip = this.cmHost;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HideSelection = false;
            this.listView.LargeImageList = this.imageListLarge;
            this.listView.Name = "listView";
            this.listView.ShowGroups = false;
            this.listView.ShowItemToolTips = true;
            this.listView.SmallImageList = this.imageListSmall;
            this.listView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView.StateImageList = this.imageListSmall;
            this.toolTip.SetToolTip(this.listView, resources.GetString("listView.ToolTip"));
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListViewColumnClick);
            this.listView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ListViewMouseMove);
            // 
            // columnHeader11
            // 
            resources.ApplyResources(this.columnHeader11, "columnHeader11");
            // 
            // columnHeader12
            // 
            resources.ApplyResources(this.columnHeader12, "columnHeader12");
            // 
            // columnHeader13
            // 
            resources.ApplyResources(this.columnHeader13, "columnHeader13");
            // 
            // columnHeader14
            // 
            resources.ApplyResources(this.columnHeader14, "columnHeader14");
            // 
            // columnHeader15
            // 
            resources.ApplyResources(this.columnHeader15, "columnHeader15");
            // 
            // columnHeader16
            // 
            resources.ApplyResources(this.columnHeader16, "columnHeader16");
            // 
            // columnHeader17
            // 
            resources.ApplyResources(this.columnHeader17, "columnHeader17");
            // 
            // cmHost
            // 
            resources.ApplyResources(this.cmHost, "cmHost");
            this.cmHost.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wakeToolStripMenuItem,
            this.rebootToolStripMenuItem,
            this.shutdownToolStripMenuItem,
            this.toolStripSeparator8,
            this.editToolStripMenuItem1,
            this.editTimerToolStripMenuItem2,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator9,
            this.assignToGroupToolStripMenuItem,
            this.addToGroupToolStripMenuItem,
            this.toolStripSeparator11,
            this.executeToolToolStripMenuItem});
            this.cmHost.Name = "contextMenuHost";
            this.toolTip.SetToolTip(this.cmHost, resources.GetString("cmHost.ToolTip"));
            // 
            // wakeToolStripMenuItem
            // 
            resources.ApplyResources(this.wakeToolStripMenuItem, "wakeToolStripMenuItem");
            this.wakeToolStripMenuItem.Name = "wakeToolStripMenuItem";
            this.wakeToolStripMenuItem.Click += new System.EventHandler(this.WakeToolStripMenuItemClick);
            // 
            // rebootToolStripMenuItem
            // 
            resources.ApplyResources(this.rebootToolStripMenuItem, "rebootToolStripMenuItem");
            this.rebootToolStripMenuItem.Name = "rebootToolStripMenuItem";
            this.rebootToolStripMenuItem.Click += new System.EventHandler(this.RebootToolStripMenuItemClick);
            // 
            // shutdownToolStripMenuItem
            // 
            resources.ApplyResources(this.shutdownToolStripMenuItem, "shutdownToolStripMenuItem");
            this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
            this.shutdownToolStripMenuItem.Click += new System.EventHandler(this.ShutdownToolStripMenuItemClick);
            // 
            // toolStripSeparator8
            // 
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            // 
            // editToolStripMenuItem1
            // 
            resources.ApplyResources(this.editToolStripMenuItem1, "editToolStripMenuItem1");
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.EditToolStripMenuItem1Click);
            // 
            // editTimerToolStripMenuItem2
            // 
            resources.ApplyResources(this.editTimerToolStripMenuItem2, "editTimerToolStripMenuItem2");
            this.editTimerToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wakeTimerToolStripMenuItem,
            this.rebootTimerToolStripMenuItem,
            shutdownTimerToolStripMenuItem});
            this.editTimerToolStripMenuItem2.Name = "editTimerToolStripMenuItem2";
            this.editTimerToolStripMenuItem2.Click += new System.EventHandler(this.EditTimerToolStripMenuItem2Click);
            // 
            // wakeTimerToolStripMenuItem
            // 
            resources.ApplyResources(this.wakeTimerToolStripMenuItem, "wakeTimerToolStripMenuItem");
            this.wakeTimerToolStripMenuItem.Name = "wakeTimerToolStripMenuItem";
            this.wakeTimerToolStripMenuItem.Click += new System.EventHandler(this.wakeTimerToolStripMenuItem_Click);
            // 
            // rebootTimerToolStripMenuItem
            // 
            resources.ApplyResources(this.rebootTimerToolStripMenuItem, "rebootTimerToolStripMenuItem");
            this.rebootTimerToolStripMenuItem.Name = "rebootTimerToolStripMenuItem";
            this.rebootTimerToolStripMenuItem.Click += new System.EventHandler(this.rebootTimerToolStripMenuItem_Click);
            // 
            // shutdownTimerToolStripMenuItem
            // 
            resources.ApplyResources(shutdownTimerToolStripMenuItem, "shutdownTimerToolStripMenuItem");
            shutdownTimerToolStripMenuItem.Name = "shutdownTimerToolStripMenuItem";
            shutdownTimerToolStripMenuItem.Click += new System.EventHandler(this.shutdownTimerToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItemClick);
            // 
            // toolStripSeparator9
            // 
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            // 
            // assignToGroupToolStripMenuItem
            // 
            resources.ApplyResources(this.assignToGroupToolStripMenuItem, "assignToGroupToolStripMenuItem");
            this.assignToGroupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assignGrpMenuItem});
            this.assignToGroupToolStripMenuItem.Name = "assignToGroupToolStripMenuItem";
            // 
            // assignGrpMenuItem
            // 
            resources.ApplyResources(this.assignGrpMenuItem, "assignGrpMenuItem");
            this.assignGrpMenuItem.Name = "assignGrpMenuItem";
            // 
            // addToGroupToolStripMenuItem
            // 
            resources.ApplyResources(this.addToGroupToolStripMenuItem, "addToGroupToolStripMenuItem");
            this.addToGroupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dummy1ToolStripMenuItem1});
            this.addToGroupToolStripMenuItem.Name = "addToGroupToolStripMenuItem";
            // 
            // dummy1ToolStripMenuItem1
            // 
            resources.ApplyResources(this.dummy1ToolStripMenuItem1, "dummy1ToolStripMenuItem1");
            this.dummy1ToolStripMenuItem1.Name = "dummy1ToolStripMenuItem1";
            // 
            // toolStripSeparator11
            // 
            resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            // 
            // executeToolToolStripMenuItem
            // 
            resources.ApplyResources(this.executeToolToolStripMenuItem, "executeToolToolStripMenuItem");
            this.executeToolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dummy1ToolStripMenuItem});
            this.executeToolToolStripMenuItem.Name = "executeToolToolStripMenuItem";
            // 
            // dummy1ToolStripMenuItem
            // 
            resources.ApplyResources(this.dummy1ToolStripMenuItem, "dummy1ToolStripMenuItem");
            this.dummy1ToolStripMenuItem.Name = "dummy1ToolStripMenuItem";
            // 
            // imageListLarge
            // 
            this.imageListLarge.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListLarge.ImageStream")));
            this.imageListLarge.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListLarge.Images.SetKeyName(0, "1353066321_mycomputer_gray.png");
            this.imageListLarge.Images.SetKeyName(1, "1353066321_mycomputer.png");
            // 
            // imageListSmall
            // 
            this.imageListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSmall.ImageStream")));
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListSmall.Images.SetKeyName(0, "1353066318_mycomputer_gray.png");
            this.imageListSmall.Images.SetKeyName(1, "1353066318_mycomputer.png");
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.AllowItemReorder = true;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_NewFile,
            this.toolStripButton_OpenFile,
            this.toolStripButton_SaveFile,
            this.toolStripSeparator1,
            this.toolStripButton_NewHost,
            this.toolStripButton_EditHost,
            this.toolStripButton_DeleteHost,
            this.toolStripSeparator2,
            this.toolStripButton_WakeHost,
            this.toolStripButton_RebootHost,
            this.toolStripButton_ShutdownHost,
            this.toolStripSeparator13,
            this.tbtnNote});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Name = "toolStrip1";
            this.toolTip.SetToolTip(this.toolStrip1, resources.GetString("toolStrip1.ToolTip"));
            // 
            // toolStripButton_NewFile
            // 
            resources.ApplyResources(this.toolStripButton_NewFile, "toolStripButton_NewFile");
            this.toolStripButton_NewFile.Name = "toolStripButton_NewFile";
            this.toolStripButton_NewFile.Click += new System.EventHandler(this.ToolStripButton_NewFileClick);
            // 
            // toolStripButton_OpenFile
            // 
            resources.ApplyResources(this.toolStripButton_OpenFile, "toolStripButton_OpenFile");
            this.toolStripButton_OpenFile.Name = "toolStripButton_OpenFile";
            this.toolStripButton_OpenFile.Click += new System.EventHandler(this.ToolStripButton_OpenFileClick);
            // 
            // toolStripButton_SaveFile
            // 
            resources.ApplyResources(this.toolStripButton_SaveFile, "toolStripButton_SaveFile");
            this.toolStripButton_SaveFile.Name = "toolStripButton_SaveFile";
            this.toolStripButton_SaveFile.Click += new System.EventHandler(this.ToolStripButton_SaveFileClick);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // toolStripButton_NewHost
            // 
            resources.ApplyResources(this.toolStripButton_NewHost, "toolStripButton_NewHost");
            this.toolStripButton_NewHost.Name = "toolStripButton_NewHost";
            this.toolStripButton_NewHost.Click += new System.EventHandler(this.ToolStripButton_NewHostClick);
            // 
            // toolStripButton_EditHost
            // 
            resources.ApplyResources(this.toolStripButton_EditHost, "toolStripButton_EditHost");
            this.toolStripButton_EditHost.Name = "toolStripButton_EditHost";
            this.toolStripButton_EditHost.Click += new System.EventHandler(this.ToolStripButton_EditHostClick);
            // 
            // toolStripButton_DeleteHost
            // 
            resources.ApplyResources(this.toolStripButton_DeleteHost, "toolStripButton_DeleteHost");
            this.toolStripButton_DeleteHost.Name = "toolStripButton_DeleteHost";
            this.toolStripButton_DeleteHost.Click += new System.EventHandler(this.ToolStripButton_DeleteHostClick);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // toolStripButton_WakeHost
            // 
            resources.ApplyResources(this.toolStripButton_WakeHost, "toolStripButton_WakeHost");
            this.toolStripButton_WakeHost.Name = "toolStripButton_WakeHost";
            this.toolStripButton_WakeHost.Click += new System.EventHandler(this.ToolStripButton_WakeHostClick);
            // 
            // toolStripButton_RebootHost
            // 
            resources.ApplyResources(this.toolStripButton_RebootHost, "toolStripButton_RebootHost");
            this.toolStripButton_RebootHost.Name = "toolStripButton_RebootHost";
            this.toolStripButton_RebootHost.Click += new System.EventHandler(this.ToolStripButton_RebootHostClick);
            // 
            // toolStripButton_ShutdownHost
            // 
            resources.ApplyResources(this.toolStripButton_ShutdownHost, "toolStripButton_ShutdownHost");
            this.toolStripButton_ShutdownHost.Name = "toolStripButton_ShutdownHost";
            this.toolStripButton_ShutdownHost.Click += new System.EventHandler(this.ToolStripButton_ShutdownHostClick);
            // 
            // toolStripSeparator13
            // 
            resources.ApplyResources(this.toolStripSeparator13, "toolStripSeparator13");
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            // 
            // tbtnNote
            // 
            resources.ApplyResources(this.tbtnNote, "tbtnNote");
            this.tbtnNote.Name = "tbtnNote";
            this.tbtnNote.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            this.toolTip.SetToolTip(this.menuStrip1, resources.GetString("menuStrip1.ToolTip"));
            // 
            // fileToolStripMenuItem
            // 
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFileToolStripMenuItem,
            this.openFileToolStripMenuItem,
            this.mnuMRU,
            this.saveFileToolStripMenuItem,
            this.toolStripMenuItem2,
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            // 
            // newFileToolStripMenuItem
            // 
            resources.ApplyResources(this.newFileToolStripMenuItem, "newFileToolStripMenuItem");
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.Click += new System.EventHandler(this.NewFileToolStripMenuItemClick);
            // 
            // openFileToolStripMenuItem
            // 
            resources.ApplyResources(this.openFileToolStripMenuItem, "openFileToolStripMenuItem");
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.OpenFileToolStripMenuItemClick);
            // 
            // mnuMRU
            // 
            resources.ApplyResources(this.mnuMRU, "mnuMRU");
            this.mnuMRU.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mRUToolStripMenuItem});
            this.mnuMRU.Name = "mnuMRU";
            // 
            // mRUToolStripMenuItem
            // 
            resources.ApplyResources(this.mRUToolStripMenuItem, "mRUToolStripMenuItem");
            this.mRUToolStripMenuItem.Name = "mRUToolStripMenuItem";
            this.mRUToolStripMenuItem.Click += new System.EventHandler(this.mRUToolStripMenuItem_Click);
            // 
            // saveFileToolStripMenuItem
            // 
            resources.ApplyResources(this.saveFileToolStripMenuItem, "saveFileToolStripMenuItem");
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.SaveFileToolStripMenuItemClick);
            // 
            // toolStripMenuItem2
            // 
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            // 
            // importToolStripMenuItem
            // 
            resources.ApplyResources(this.importToolStripMenuItem, "importToolStripMenuItem");
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromCSVToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            // 
            // fromCSVToolStripMenuItem
            // 
            resources.ApplyResources(this.fromCSVToolStripMenuItem, "fromCSVToolStripMenuItem");
            this.fromCSVToolStripMenuItem.Name = "fromCSVToolStripMenuItem";
            this.fromCSVToolStripMenuItem.Click += new System.EventHandler(this.fromCSVToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            resources.ApplyResources(this.exportToolStripMenuItem, "exportToolStripMenuItem");
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asCSVToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            // 
            // asCSVToolStripMenuItem
            // 
            resources.ApplyResources(this.asCSVToolStripMenuItem, "asCSVToolStripMenuItem");
            this.asCSVToolStripMenuItem.Name = "asCSVToolStripMenuItem";
            this.asCSVToolStripMenuItem.Click += new System.EventHandler(this.AsCSVToolStripMenuItemClick);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // editToolStripMenuItem
            // 
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewHostToolStripMenuItem,
            this.editCurrentHostToolStripMenuItem,
            this.deleteCurrentHostToolStripMenuItem,
            this.toolStripMenuItem1,
            this.openNetworkScannerToolStripMenuItem,
            this.scanForNewHostsToolStripMenuItem,
            this.periodicallyScanForNewHostsToolStripMenuItem,
            this.toolStripSeparator4,
            this.editTimerToolStripMenuItem,
            this.toolStripSeparator5,
            this.einstellungenToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.DropDownOpening += new System.EventHandler(this.editToolStripMenuItem_DropDownOpening);
            // 
            // createNewHostToolStripMenuItem
            // 
            resources.ApplyResources(this.createNewHostToolStripMenuItem, "createNewHostToolStripMenuItem");
            this.createNewHostToolStripMenuItem.Name = "createNewHostToolStripMenuItem";
            this.createNewHostToolStripMenuItem.Click += new System.EventHandler(this.CreateNewHostToolStripMenuItemClick);
            // 
            // editCurrentHostToolStripMenuItem
            // 
            resources.ApplyResources(this.editCurrentHostToolStripMenuItem, "editCurrentHostToolStripMenuItem");
            this.editCurrentHostToolStripMenuItem.Name = "editCurrentHostToolStripMenuItem";
            this.editCurrentHostToolStripMenuItem.Click += new System.EventHandler(this.EditCurrentHostToolStripMenuItemClick);
            // 
            // deleteCurrentHostToolStripMenuItem
            // 
            resources.ApplyResources(this.deleteCurrentHostToolStripMenuItem, "deleteCurrentHostToolStripMenuItem");
            this.deleteCurrentHostToolStripMenuItem.Name = "deleteCurrentHostToolStripMenuItem";
            this.deleteCurrentHostToolStripMenuItem.Click += new System.EventHandler(this.DeleteCurrentHostToolStripMenuItemClick);
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // openNetworkScannerToolStripMenuItem
            // 
            resources.ApplyResources(this.openNetworkScannerToolStripMenuItem, "openNetworkScannerToolStripMenuItem");
            this.openNetworkScannerToolStripMenuItem.Name = "openNetworkScannerToolStripMenuItem";
            this.openNetworkScannerToolStripMenuItem.Click += new System.EventHandler(this.OpenNetworkScannerToolStripMenuItemClick);
            // 
            // scanForNewHostsToolStripMenuItem
            // 
            resources.ApplyResources(this.scanForNewHostsToolStripMenuItem, "scanForNewHostsToolStripMenuItem");
            this.scanForNewHostsToolStripMenuItem.Name = "scanForNewHostsToolStripMenuItem";
            this.scanForNewHostsToolStripMenuItem.Click += new System.EventHandler(this.ScanForNewHostsToolStripMenuItemClick);
            // 
            // periodicallyScanForNewHostsToolStripMenuItem
            // 
            resources.ApplyResources(this.periodicallyScanForNewHostsToolStripMenuItem, "periodicallyScanForNewHostsToolStripMenuItem");
            this.periodicallyScanForNewHostsToolStripMenuItem.Name = "periodicallyScanForNewHostsToolStripMenuItem";
            this.periodicallyScanForNewHostsToolStripMenuItem.Click += new System.EventHandler(this.periodicallyScanForNewHostsToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // editTimerToolStripMenuItem
            // 
            resources.ApplyResources(this.editTimerToolStripMenuItem, "editTimerToolStripMenuItem");
            this.editTimerToolStripMenuItem.Name = "editTimerToolStripMenuItem";
            this.editTimerToolStripMenuItem.Click += new System.EventHandler(this.EditTimerToolStripMenuItemClick);
            // 
            // toolStripSeparator5
            // 
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            // 
            // einstellungenToolStripMenuItem
            // 
            resources.ApplyResources(this.einstellungenToolStripMenuItem, "einstellungenToolStripMenuItem");
            this.einstellungenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xMLFileportableToolStripMenuItem,
            this.windowsRegisrtryToolStripMenuItem});
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            // 
            // xMLFileportableToolStripMenuItem
            // 
            resources.ApplyResources(this.xMLFileportableToolStripMenuItem, "xMLFileportableToolStripMenuItem");
            this.xMLFileportableToolStripMenuItem.Name = "xMLFileportableToolStripMenuItem";
            this.xMLFileportableToolStripMenuItem.Click += new System.EventHandler(this.xMLFileportableToolStripMenuItem_Click);
            // 
            // windowsRegisrtryToolStripMenuItem
            // 
            resources.ApplyResources(this.windowsRegisrtryToolStripMenuItem, "windowsRegisrtryToolStripMenuItem");
            this.windowsRegisrtryToolStripMenuItem.Name = "windowsRegisrtryToolStripMenuItem";
            this.windowsRegisrtryToolStripMenuItem.Click += new System.EventHandler(this.windowsRegisrtryToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItemClick);
            // 
            // viewToolStripMenuItem
            // 
            resources.ApplyResources(this.viewToolStripMenuItem, "viewToolStripMenuItem");
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listViewStyleToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            // 
            // listViewStyleToolStripMenuItem
            // 
            resources.ApplyResources(this.listViewStyleToolStripMenuItem, "listViewStyleToolStripMenuItem");
            this.listViewStyleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeIconsToolStripMenuItem,
            this.smallIconsToolStripMenuItem,
            this.listToolStripMenuItem,
            this.reportToolStripMenuItem});
            this.listViewStyleToolStripMenuItem.Name = "listViewStyleToolStripMenuItem";
            // 
            // largeIconsToolStripMenuItem
            // 
            resources.ApplyResources(this.largeIconsToolStripMenuItem, "largeIconsToolStripMenuItem");
            this.largeIconsToolStripMenuItem.Name = "largeIconsToolStripMenuItem";
            this.largeIconsToolStripMenuItem.Click += new System.EventHandler(this.LargeIconsToolStripMenuItemClick);
            // 
            // smallIconsToolStripMenuItem
            // 
            resources.ApplyResources(this.smallIconsToolStripMenuItem, "smallIconsToolStripMenuItem");
            this.smallIconsToolStripMenuItem.Name = "smallIconsToolStripMenuItem";
            this.smallIconsToolStripMenuItem.Click += new System.EventHandler(this.SmallIconsToolStripMenuItemClick);
            // 
            // listToolStripMenuItem
            // 
            resources.ApplyResources(this.listToolStripMenuItem, "listToolStripMenuItem");
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Click += new System.EventHandler(this.ListToolStripMenuItemClick);
            // 
            // reportToolStripMenuItem
            // 
            resources.ApplyResources(this.reportToolStripMenuItem, "reportToolStripMenuItem");
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Click += new System.EventHandler(this.ReportToolStripMenuItemClick);
            // 
            // helpToolStripMenuItem
            // 
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.toolStripMenuItem3,
            this.checkForUpdatesToolStripMenuItem,
            this.openOnlineSurveyToolStripMenuItem,
            this.toolStripSeparator7,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            // 
            // helpToolStripMenuItem1
            // 
            resources.ApplyResources(this.helpToolStripMenuItem1, "helpToolStripMenuItem1");
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.HelpToolStripMenuItem1Click);
            // 
            // toolStripMenuItem3
            // 
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            resources.ApplyResources(this.checkForUpdatesToolStripMenuItem, "checkForUpdatesToolStripMenuItem");
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.CheckForUpdatesToolStripMenuItemClick);
            // 
            // openOnlineSurveyToolStripMenuItem
            // 
            resources.ApplyResources(this.openOnlineSurveyToolStripMenuItem, "openOnlineSurveyToolStripMenuItem");
            this.openOnlineSurveyToolStripMenuItem.Name = "openOnlineSurveyToolStripMenuItem";
            this.openOnlineSurveyToolStripMenuItem.Click += new System.EventHandler(this.openOnlineSurveyToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            // 
            // aboutToolStripMenuItem
            // 
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Name = "statusStrip1";
            this.toolTip.SetToolTip(this.statusStrip1, resources.GetString("statusStrip1.ToolTip"));
            // 
            // lblStatus
            // 
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.lblStatus.Spring = true;
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // columnHeader5
            // 
            resources.ApplyResources(this.columnHeader5, "columnHeader5");
            // 
            // columnHeader6
            // 
            resources.ApplyResources(this.columnHeader6, "columnHeader6");
            // 
            // columnHeader7
            // 
            resources.ApplyResources(this.columnHeader7, "columnHeader7");
            // 
            // columnHeader8
            // 
            resources.ApplyResources(this.columnHeader8, "columnHeader8");
            // 
            // columnHeader9
            // 
            resources.ApplyResources(this.columnHeader9, "columnHeader9");
            // 
            // columnHeader10
            // 
            resources.ApplyResources(this.columnHeader10, "columnHeader10");
            // 
            // tmrAlarm
            // 
            this.tmrAlarm.Enabled = true;
            this.tmrAlarm.Interval = 1000;
            this.tmrAlarm.Tick += new System.EventHandler(this.TmrAlarmTick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            this.notifyIcon1.ContextMenuStrip = this.cmTray;
            this.notifyIcon1.BalloonTipClosed += new System.EventHandler(this.notifyIcon1_BalloonTipClosed);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // cmTray
            // 
            resources.ApplyResources(this.cmTray, "cmTray");
            this.cmTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showWOL2ToolStripMenuItem,
            this.toolStripSeparator12,
            this.exitWOL2ToolStripMenuItem});
            this.cmTray.Name = "cmTray";
            this.toolTip.SetToolTip(this.cmTray, resources.GetString("cmTray.ToolTip"));
            // 
            // showWOL2ToolStripMenuItem
            // 
            resources.ApplyResources(this.showWOL2ToolStripMenuItem, "showWOL2ToolStripMenuItem");
            this.showWOL2ToolStripMenuItem.Name = "showWOL2ToolStripMenuItem";
            this.showWOL2ToolStripMenuItem.Click += new System.EventHandler(this.showWOL2ToolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            resources.ApplyResources(this.toolStripSeparator12, "toolStripSeparator12");
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            // 
            // exitWOL2ToolStripMenuItem
            // 
            resources.ApplyResources(this.exitWOL2ToolStripMenuItem, "exitWOL2ToolStripMenuItem");
            this.exitWOL2ToolStripMenuItem.Name = "exitWOL2ToolStripMenuItem";
            this.exitWOL2ToolStripMenuItem.Click += new System.EventHandler(this.exitWOL2ToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // tmrPeriodicScan
            // 
            this.tmrPeriodicScan.Interval = 1800000;
            this.tmrPeriodicScan.Tick += new System.EventHandler(this.tmrPeriodicScan_Tick);
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            this.toolTip.ShowAlways = true;
            this.toolTip.ToolTipTitle = "Comment:";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.cmGroups.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.cmHost.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.cmTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripMenuItem asCSVToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem openNetworkScannerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem dummy1ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem executeToolToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private System.Windows.Forms.ToolStripMenuItem shutdownGroupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rebootGroupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem wakeGroupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem assignGrpMenuItem;
		private System.Windows.Forms.ToolStripMenuItem dummy1ToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem addToGroupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem assignToGroupToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editTimerToolStripMenuItem2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rebootToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem wakeToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip cmHost;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
		private System.Windows.Forms.ToolStripStatusLabel lblStatus;
		private System.Windows.Forms.ToolStripMenuItem scanForNewHostsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editTimerToolStripMenuItem1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.Timer tmrAlarm;
		private System.Windows.Forms.ToolStripMenuItem removeGroupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addGroupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem setGroupNameToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip cmGroups;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ToolStripMenuItem editCurrentHostToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem editTimerToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem deleteCurrentHostToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem createNewHostToolStripMenuItem;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ImageList imageListSmall;
		private System.Windows.Forms.ImageList imageListLarge;
		private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem smallIconsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem largeIconsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem listViewStyleToolStripMenuItem;
		
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem saveFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton toolStripButton_ShutdownHost;
		private System.Windows.Forms.ToolStripButton toolStripButton_RebootHost;
		private System.Windows.Forms.ToolStripButton toolStripButton_WakeHost;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_DeleteHost;
		private System.Windows.Forms.ToolStripButton toolStripButton_EditHost;
		private System.Windows.Forms.ToolStripButton toolStripButton_NewHost;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolStripButton_SaveFile;
		private System.Windows.Forms.ToolStripButton toolStripButton_OpenFile;
		private System.Windows.Forms.ToolStripButton toolStripButton_NewFile;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.TabPage tabPageMain;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
	
		#region Event Handler for Toolbar ------------------------------------------------
		
		void ToolStripButton_NewFileClick(object sender, System.EventArgs e)
		{
			CreateNewHostsFile();
		}
		
		void ToolStripButton_OpenFileClick(object sender, System.EventArgs e)
		{
			OpenHostList( null );
		}
		
		void ToolStripButton_SaveFileClick(object sender, System.EventArgs e)
		{
			SaveHostList( null );
		}
		
		void ToolStripButton_NewHostClick(object sender, System.EventArgs e)
		{
			InsertNewHost(null);
		}
		
		void ToolStripButton_EditHostClick(object sender, System.EventArgs e)
		{
			EditSelectedHost();
		}
		
		void ToolStripButton_EditTimerClick(object sender, System.EventArgs e)
		{
			EditSelectedTimer();
		}
		
		void ToolStripButton_DeleteHostClick(object sender, System.EventArgs e)
		{
			RemoveSelectedHosts();
		}

		void ToolStripButton_WakeHostClick(object sender, System.EventArgs e)
		{
			WakeSelectedHosts();
		}
		
		void ToolStripButton_RebootHostClick(object sender, System.EventArgs e)
		{
			RebootSelectedHost();
		}

		void ToolStripButton_ShutdownHostClick(object sender, System.EventArgs e)
		{
			ShutdownSelectedHost();
		}
		
		#endregion
		
		#region Event Handler for Menu ---------------------------------------------------
		
		// File Menu
		
		void NewFileToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			CreateNewHostsFile();
		}
		
		void OpenFileToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			OpenHostList( null );
		}

		void SaveFileToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			SaveHostList( null );
		}

		void ExitToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			this.ExitWOLTool( true );
		}
		
		void AsCSVToolStripMenuItemClick(object sender, EventArgs e)
		{
			DlgCSVExport dlg = new DlgCSVExport( m_Hosts );
			dlg.ShowDialog( this );
		}
		
		// Edit menu
		
		void CreateNewHostToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			InsertNewHost(null);
		}
		
		void EditCurrentHostToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			EditSelectedHost();
		}
		
		void EditTimerToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			EditSelectedTimer();
		}

		
		void DeleteCurrentHostToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			RemoveSelectedHosts();
		}

		void OptionsToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			frmDlgOptions dlg = new frmDlgOptions();
			
			dlg.SetRefreshInterval( m_iOnlineCheckInterval );
            dlg.SetWakeDelay(m_iWakeDelay);
            dlg.SetWOLPort(m_iWakePort);
			dlg.SetPingTimout( m_iPingTimeout );
			dlg.SetAskForSecureOnPwd( m_bAskForSecureOnPwd );
			dlg.SetOpenLastUsedFile( m_bOpenLastFile );
			dlg.SetDoLogging( m_bDoLogging );
			dlg.SetColorizeListView( m_bColorizeListView );
			dlg.SetAutosaveHostlist( m_bAutosaveHostFile );
            dlg.SetMinimizeToTray(m_bMinimizeToTray);
            dlg.SetConfirmNetworkOperations(m_bConfirmNetActions);
            dlg.SetCmdHostStateChanged(m_sHostStateChangedCommand);
            dlg.SetCmdGroupStateChanged(m_sGroupStateChangedCommand);
            dlg.SetUseIpV6(m_bUseIpV6);
            dlg.SetUpdateIPAddresses(m_bUpdateIPInOnlineChecker);

            // Notifications
            dlg.SetAlwaysDisplayNotifications(m_bAlwaysDisplayNotifications);
            dlg.SetDisplayNotifications(m_bDisplayStateNotifications);
            dlg.SetNotificationTimeout(m_iNotificationTimeout);

			// Reboot
			dlg.SetRebootComment( m_sRebootComment );
			dlg.SetRebootDomain( m_sRebootDomain );
			dlg.SetRebootPaswd( m_sRebootPaswd );
			dlg.SetRebootTimeout( m_iRebootTimeout );
			dlg.SetRebootUser( m_sRebootUser );
			dlg.SetForceReboot( m_bForceReboot );
			
			// Shutdown
			dlg.SetShutdownComment( m_sShutdownComment );
			dlg.SetShutdownDomain( m_sShutdownDomain );
			dlg.SetShutdownPaswd( m_sShutdownPaswd );
			dlg.SetShutdownTimeout( m_iShutdownTimeout );
			dlg.SetShutdownUser( m_sShutdownUser );
			dlg.SetForceShutdown( m_bForceShutdown );
			
			// Set WOL Options
			dlg.SetWOLFlags( m_PacketTransferOptions );
			
			// Set Network Scanner Options
			dlg.SetUnresolvedMacOk( m_bUnresolvedMacOk );
			dlg.SetUnresolvedNameOk( m_bUnresolvedNameOk );
			
			// Load tools
			dlg.SetTools( m_Tools );
			
			DialogResult dr = dlg.ShowDialog( this );
			
			if( dr == DialogResult.OK )
			{
				// General Tab
				m_iOnlineCheckInterval = dlg.GetRefreshInterval();
                m_iWakeDelay = dlg.GetWakeDelay();
				m_iPingTimeout = dlg.GetPingTimeout();
				m_bOpenLastFile = dlg.GetOpenLastUsedFile();
                m_bMinimizeToTray = dlg.GetMinimizeToTray();
                m_bConfirmNetActions = dlg.GetConfirmNetworkOperations();
				
				if( dlg.GetDoLogging() != m_bDoLogging )
				{
					MessageBox.Show( MOE.Utility.GetStringFromRes("strLoggingAfterRestart") );
					m_bDoLogging = dlg.GetDoLogging();
				}
				
				m_bColorizeListView = dlg.GetColorizeListView( );
				m_bAutosaveHostFile = dlg.GetAutosaveHostlist();
                m_sHostStateChangedCommand = dlg.GetCmdHostStateChanged();
                m_sGroupStateChangedCommand = dlg.GetCmdGroupStateChanged();
	
				// WOL Tab
				m_bAskForSecureOnPwd = dlg.GetAskForSecureOnPwd();
				m_PacketTransferOptions = dlg.GetWOLFlags();
                m_iWakePort = dlg.GetWOLPort();
				
				// Shutdown
				m_sShutdownComment	= dlg.GetShutdownComment();
				m_iShutdownTimeout	= dlg.GetShutdownTimeout();
				m_sShutdownDomain 	= dlg.GetShutdownDomain();
				m_sShutdownPaswd	= dlg.GetShutdownPaswd();
				m_sShutdownUser		= dlg.GetShutdownUser();
				m_bForceShutdown	= dlg.GetForceShutdown();
				
				// Reboot
				m_sRebootComment	= dlg.GetRebootComment();
				m_iRebootTimeout	= dlg.GetRebootTimeout();
				m_sRebootDomain 	= dlg.GetRebootDomain();
				m_sRebootPaswd		= dlg.GetRebootPaswd();
				m_sRebootUser		= dlg.GetRebootUser();
				m_bForceReboot		= dlg.GetForceReboot();
				
				// Get Network Scanner Options
				m_bUnresolvedMacOk = dlg.GetUnresolvedMacOk( );
				m_bUnresolvedNameOk = dlg.GetUnresolvedNameOk( );

                // Notifications
                m_bAlwaysDisplayNotifications = dlg.GetAlwaysDisplayNotifications();
                m_bDisplayStateNotifications = dlg.GetDisplayNotifications();
                m_iNotificationTimeout = dlg.GetNotificationTimeout();
                m_bUseIpV6 = dlg.GetUseIpV6();
                m_bUpdateIPInOnlineChecker = dlg.GetUpdateIPAddresses();
				
				// Get tools from dlg
				RefreshToolsMenu();
				
				
			}
		}
		
		void OpenNetworkScannerToolStripMenuItemClick(object sender, EventArgs e)
		{
			DlgNetworkScanner dlg = new DlgNetworkScanner( m_Hosts );
			dlg.SetPingTimeout( m_iPingTimeout );
			dlg.SetUnresolvedMacOk( m_bUnresolvedMacOk );
			dlg.SetUnresolvedNameOk( m_bUnresolvedNameOk );
			
			Monitor.Enter( m_LockHosts );
			dlg.ShowDialog( this );
			Monitor.Exit( m_LockHosts );

            if (dlg.ChangedHostList)
                ChangedHostsFile();
			
			RefreshHostList();
		}
		
		
		// View Menu
				
		void LargeIconsToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			listView.View = View.LargeIcon;
		}
		
		void SmallIconsToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			listView.View = View.SmallIcon;
		}
		
		void ListToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			listView.View = View.List;
		}
		
		void ReportToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			listView.View = View.Details;
		}
		
		// Help Menu
		void HelpToolStripMenuItem1Click(object sender, System.EventArgs e)
		{
			try
			{
                string file = MOE.Utility.GetStringFromRes("strHelpFileName");
                System.Diagnostics.Process.Start(file);
			}
			catch( Exception )
			{
                string msg = MOE.Utility.GetStringFromRes("strHelpFileMissing");
                MessageBox.Show(msg);
			}
		}
		
		void CheckForUpdatesToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			CheckForOnlineUpdate();
		}

		void AboutToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			DlgAbout ad = new DlgAbout();
			ad.ShowDialog( this );
				
		}
		
		#endregion
		
		#region Event Handler for ListView -----------------------------------------------
		
		void ListViewDoubleClick(object sender, System.EventArgs e)
		{
			WakeSelectedHosts();
		}
		
		void ListViewKeyDown(object sender, KeyEventArgs e)
		{
			switch( e.KeyCode )
			{
				case Keys.Delete:
					RemoveSelectedHosts();
					break;
			}
		}
		
		void ListViewMouseMove(object sender, MouseEventArgs e)
		{
			ListViewItem itm = listView.GetItemAt( e.X, e.Y );
			if( itm != null )
			{
				WOL2Host h = (WOL2Host)(itm.Tag);
				if( h != null )
					lblStatus.Text = h.ToString() + " - " + h.StateAsString();
			}
		}
		
		void ListViewColumnClick(object sender, ColumnClickEventArgs e)
		{
			ListView myListView = (ListView)sender;

            // Remove the old sort order mark
            ListViewExtensions.SetSortIcon(myListView, m_ListViewSorter.SortColumn, SortOrder.None);


			   // Determine if clicked column is already the column that is being sorted.
			   if ( e.Column == m_ListViewSorter.SortColumn )
			   {
			     // Reverse the current sort direction for this column.
			
			     if (m_ListViewSorter.Order == SortOrder.Ascending)
			     {
			      m_ListViewSorter.Order = SortOrder.Descending;
			     }
			     else
			     {
			      m_ListViewSorter.Order = SortOrder.Ascending;
			     }
			   }
			   else
			   {
			    // Set the column number that is to be sorted; default to ascending.
			    m_ListViewSorter.SortColumn = e.Column;
			    m_ListViewSorter.Order = SortOrder.Ascending;
			   }

            // Make the sort order visible
               ListViewExtensions.SetSortIcon(myListView, m_ListViewSorter.SortColumn, m_ListViewSorter.Order);

			   // Perform the sort with these new sort options.
			   myListView.Sort();

		}
		
		#endregion
		
		#region Event Handler for Tabs ---------------------------------------------------
		
		void TabControlSelectedIndexChanged(object sender, System.EventArgs e)
		{
			listView.Parent = tabControl.SelectedTab;
			
			m_CurrentGroup = (WOL2Group)tabControl.SelectedTab.Tag;
			
			RefreshHostList();
		
		}
		
		#endregion
		
		#region Event handler for Groups Contextmenu -------------------------------------
		void WakeGroupToolStripMenuItemClick(object sender, EventArgs e)
		{
			if( m_CurrentGroup != null )
				WakeGroup( m_CurrentGroup, false );
		}
		
		void RebootGroupToolStripMenuItemClick(object sender, EventArgs e)
		{
			if( m_CurrentGroup != null )
				RebootGroup( m_CurrentGroup, false );
		}
		
		void ShutdownGroupToolStripMenuItemClick(object sender, EventArgs e)
		{
			if( m_CurrentGroup != null )
				ShutdownGroup( m_CurrentGroup, false );
		}
		
		void SetGroupNameToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			RenameCurrentGroup();
		}
		
		void AddGroupToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			AddNewGroup();
		}
		
		void RemoveGroupToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			MOE.InputBoxDialog ib = new MOE.InputBoxDialog();
			ib.FormPrompt = MOE.Utility.GetStringFromRes("strRemoveGroup");
			ib.FormCaption = MOE.Utility.GetStringFromRes("strRemoveGroupTitle");
			if( m_CurrentGroup != null )
				ib.DefaultValue = m_CurrentGroup.GetName();
			ib.ShowDialog( this );
			
			string sGroup = ib.InputResponse;
			if( sGroup.Length != 0 )
				RemoveGroup( sGroup );
		}
		
		void EditTimerToolStripMenuItem1Click(object sender, System.EventArgs e)
		{
			
		}

		
		#endregion
		
		#region Event handler for Host Contextmenu -------------------------------
		void EditToolStripMenuItem1Click(object sender, EventArgs e)
		{
			EditSelectedHost();
		}
	
		void WakeToolStripMenuItemClick(object sender, EventArgs e)
		{
			WakeSelectedHosts();
		}
		
		void RebootToolStripMenuItemClick(object sender, EventArgs e)
		{
			RebootSelectedHost();
		}
		
		void ShutdownToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShutdownSelectedHost();
		}
		
		void EditTimerToolStripMenuItem2Click(object sender, EventArgs e)
		{
			
		}
		
		void DeleteToolStripMenuItemClick(object sender, EventArgs e)
		{
			RemoveSelectedHosts();
		}
		
		void assignToGroupClicked( object sender, EventArgs e )
		{
			ToolStripItem i = (ToolStripItem)sender;
			string sg = i.Text;
			AssignSelectedHostsToGroup( sg );
		}
		
		void addToGroupClicked( object sender, EventArgs e )
		{
			ToolStripItem i = (ToolStripItem)sender;
			string sg = i.Text;
			AddSelectedHostsToGroup( sg );
		}
			
		#endregion
		
		#region Form Event Handlers ------------------------------------------------------
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			// Exit the tool, false prevents double call to Application.Exit();
			ExitWOLTool( false );
		}
		
		#endregion

        private ToolStripMenuItem wakeTimerToolStripMenuItem;
        private ToolStripMenuItem rebootTimerToolStripMenuItem;
        private ToolStripMenuItem wakeGroupTimerToolStripMenuItem;
        private ToolStripMenuItem rebootGroupTimerToolStripMenuItem;
        private ToolStripMenuItem shutdownGroupTimerToolStripMenuItem;
        private NotifyIcon notifyIcon1;
        private ToolStripMenuItem mnuMRU;
        private ToolStripMenuItem mRUToolStripMenuItem;
        private ContextMenuStrip cmTray;
        private ToolStripMenuItem showWOL2ToolStripMenuItem;
        private ToolStripMenuItem exitWOL2ToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator12;
        private ColumnHeader columnHeader17;
        private ToolStripMenuItem einstellungenToolStripMenuItem;
        private ToolStripMenuItem xMLFileportableToolStripMenuItem;
        private ToolStripMenuItem windowsRegisrtryToolStripMenuItem;
        private ToolStrip toolStripTools;
        private ToolStripMenuItem importToolStripMenuItem;
        private ToolStripMenuItem fromCSVToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem periodicallyScanForNewHostsToolStripMenuItem;
        private System.Windows.Forms.Timer tmrPeriodicScan;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripButton tbtnNote;
        private ToolTip toolTip;
        private ToolStripMenuItem openOnlineSurveyToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
				
	}
}

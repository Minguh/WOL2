/*
 * Erstellt mit SharpDevelop.
 * Benutzer: MOE
 * Datum: 05.01.2009
 * Zeit: 15:05
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
namespace WOL2
{
	partial class frmDlgOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDlgOptions));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblWiz = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chkDoLogging = new System.Windows.Forms.CheckBox();
            this.chkColorizeListView = new System.Windows.Forms.CheckBox();
            this.chkOpenLastFile = new System.Windows.Forms.CheckBox();
            this.chkAutosaveHostlist = new System.Windows.Forms.CheckBox();
            this.chkConfirmNetworkOperations = new System.Windows.Forms.CheckBox();
            this.chkMinimizeToTray = new System.Windows.Forms.CheckBox();
            this.chkIpV6 = new System.Windows.Forms.CheckBox();
            this.tabNotify = new System.Windows.Forms.TabPage();
            this.chkUpdateIPAddresses = new System.Windows.Forms.CheckBox();
            this.numPingTimeout = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.numRefreshInterval = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.btnChooseCmdGroup = new System.Windows.Forms.Button();
            this.txtCmdGroupChange = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.chkDisplayNotificationsAlways = new System.Windows.Forms.CheckBox();
            this.txtCmdHostChange = new System.Windows.Forms.TextBox();
            this.btnChooseCmdHost = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtNotificationTimeout = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.chkDisplayNotifications = new System.Windows.Forms.CheckBox();
            this.tabNetScanner = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.chkAddIfMacResolved = new System.Windows.Forms.CheckBox();
            this.chkAddIfNameResolved = new System.Windows.Forms.CheckBox();
            this.tabWOL = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numWakeDelay = new System.Windows.Forms.NumericUpDown();
            this.lblWolDelay = new System.Windows.Forms.Label();
            this.chkAskForSecureOn = new System.Windows.Forms.CheckBox();
            this.rbSendToBCast = new System.Windows.Forms.RadioButton();
            this.rbSendToNetwork = new System.Windows.Forms.RadioButton();
            this.rbSendToNode = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numWolPort = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.tabShutdwnReboot = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.txtShutdownDomain = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCommentShutdown = new System.Windows.Forms.TextBox();
            this.txtUserShutdown = new System.Windows.Forms.TextBox();
            this.txtPasswdShutdown = new System.Windows.Forms.TextBox();
            this.numTimeoutShutdown = new System.Windows.Forms.NumericUpDown();
            this.chkForceShutdown = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.txtRebootDomain = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCommentReboot = new System.Windows.Forms.TextBox();
            this.txtUserReboot = new System.Windows.Forms.TextBox();
            this.txtPasswdReboot = new System.Windows.Forms.TextBox();
            this.numTimeoutReboot = new System.Windows.Forms.NumericUpDown();
            this.chkForceReboot = new System.Windows.Forms.CheckBox();
            this.tabTools = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgLstTools = new System.Windows.Forms.ImageList(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabNotify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPingTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotificationTimeout)).BeginInit();
            this.tabNetScanner.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabWOL.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWakeDelay)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWolPort)).BeginInit();
            this.tabShutdwnReboot.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeoutShutdown)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeoutReboot)).BeginInit();
            this.tabTools.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblWiz);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // lblWiz
            // 
            resources.ApplyResources(this.lblWiz, "lblWiz");
            this.lblWiz.BackColor = System.Drawing.Color.Transparent;
            this.lblWiz.Name = "lblWiz";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabNotify);
            this.tabControl1.Controls.Add(this.tabNetScanner);
            this.tabControl1.Controls.Add(this.tabWOL);
            this.tabControl1.Controls.Add(this.tabShutdwnReboot);
            this.tabControl1.Controls.Add(this.tabTools);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.tabGeneral, "tabGeneral");
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Controls.Add(this.chkDoLogging, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.chkColorizeListView, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.chkOpenLastFile, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkAutosaveHostlist, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkConfirmNetworkOperations, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.chkMinimizeToTray, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.chkIpV6, 0, 0);
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // chkDoLogging
            // 
            resources.ApplyResources(this.chkDoLogging, "chkDoLogging");
            this.tableLayoutPanel1.SetColumnSpan(this.chkDoLogging, 2);
            this.chkDoLogging.Name = "chkDoLogging";
            this.chkDoLogging.UseVisualStyleBackColor = true;
            // 
            // chkColorizeListView
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.chkColorizeListView, 2);
            resources.ApplyResources(this.chkColorizeListView, "chkColorizeListView");
            this.chkColorizeListView.Name = "chkColorizeListView";
            this.chkColorizeListView.UseVisualStyleBackColor = true;
            // 
            // chkOpenLastFile
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.chkOpenLastFile, 2);
            resources.ApplyResources(this.chkOpenLastFile, "chkOpenLastFile");
            this.chkOpenLastFile.Name = "chkOpenLastFile";
            this.chkOpenLastFile.UseVisualStyleBackColor = true;
            // 
            // chkAutosaveHostlist
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.chkAutosaveHostlist, 2);
            resources.ApplyResources(this.chkAutosaveHostlist, "chkAutosaveHostlist");
            this.chkAutosaveHostlist.Name = "chkAutosaveHostlist";
            this.chkAutosaveHostlist.UseVisualStyleBackColor = true;
            // 
            // chkConfirmNetworkOperations
            // 
            resources.ApplyResources(this.chkConfirmNetworkOperations, "chkConfirmNetworkOperations");
            this.tableLayoutPanel1.SetColumnSpan(this.chkConfirmNetworkOperations, 2);
            this.chkConfirmNetworkOperations.Name = "chkConfirmNetworkOperations";
            this.chkConfirmNetworkOperations.UseVisualStyleBackColor = true;
            // 
            // chkMinimizeToTray
            // 
            resources.ApplyResources(this.chkMinimizeToTray, "chkMinimizeToTray");
            this.tableLayoutPanel1.SetColumnSpan(this.chkMinimizeToTray, 2);
            this.chkMinimizeToTray.Name = "chkMinimizeToTray";
            this.chkMinimizeToTray.UseVisualStyleBackColor = true;
            // 
            // chkIpV6
            // 
            resources.ApplyResources(this.chkIpV6, "chkIpV6");
            this.chkIpV6.Name = "chkIpV6";
            this.chkIpV6.UseVisualStyleBackColor = true;
            // 
            // tabNotify
            // 
            this.tabNotify.Controls.Add(this.chkUpdateIPAddresses);
            this.tabNotify.Controls.Add(this.numPingTimeout);
            this.tabNotify.Controls.Add(this.label16);
            this.tabNotify.Controls.Add(this.numRefreshInterval);
            this.tabNotify.Controls.Add(this.label15);
            this.tabNotify.Controls.Add(this.btnChooseCmdGroup);
            this.tabNotify.Controls.Add(this.txtCmdGroupChange);
            this.tabNotify.Controls.Add(this.label18);
            this.tabNotify.Controls.Add(this.chkDisplayNotificationsAlways);
            this.tabNotify.Controls.Add(this.txtCmdHostChange);
            this.tabNotify.Controls.Add(this.btnChooseCmdHost);
            this.tabNotify.Controls.Add(this.label17);
            this.tabNotify.Controls.Add(this.txtNotificationTimeout);
            this.tabNotify.Controls.Add(this.label13);
            this.tabNotify.Controls.Add(this.chkDisplayNotifications);
            resources.ApplyResources(this.tabNotify, "tabNotify");
            this.tabNotify.Name = "tabNotify";
            this.tabNotify.UseVisualStyleBackColor = true;
            // 
            // chkUpdateIPAddresses
            // 
            resources.ApplyResources(this.chkUpdateIPAddresses, "chkUpdateIPAddresses");
            this.chkUpdateIPAddresses.Name = "chkUpdateIPAddresses";
            this.chkUpdateIPAddresses.UseVisualStyleBackColor = true;
            // 
            // numPingTimeout
            // 
            resources.ApplyResources(this.numPingTimeout, "numPingTimeout");
            this.numPingTimeout.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numPingTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPingTimeout.Name = "numPingTimeout";
            this.numPingTimeout.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // numRefreshInterval
            // 
            resources.ApplyResources(this.numRefreshInterval, "numRefreshInterval");
            this.numRefreshInterval.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numRefreshInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRefreshInterval.Name = "numRefreshInterval";
            this.numRefreshInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // btnChooseCmdGroup
            // 
            resources.ApplyResources(this.btnChooseCmdGroup, "btnChooseCmdGroup");
            this.btnChooseCmdGroup.Name = "btnChooseCmdGroup";
            this.btnChooseCmdGroup.UseVisualStyleBackColor = true;
            // 
            // txtCmdGroupChange
            // 
            resources.ApplyResources(this.txtCmdGroupChange, "txtCmdGroupChange");
            this.txtCmdGroupChange.Name = "txtCmdGroupChange";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // chkDisplayNotificationsAlways
            // 
            resources.ApplyResources(this.chkDisplayNotificationsAlways, "chkDisplayNotificationsAlways");
            this.chkDisplayNotificationsAlways.Name = "chkDisplayNotificationsAlways";
            this.chkDisplayNotificationsAlways.UseVisualStyleBackColor = true;
            // 
            // txtCmdHostChange
            // 
            resources.ApplyResources(this.txtCmdHostChange, "txtCmdHostChange");
            this.txtCmdHostChange.Name = "txtCmdHostChange";
            // 
            // btnChooseCmdHost
            // 
            resources.ApplyResources(this.btnChooseCmdHost, "btnChooseCmdHost");
            this.btnChooseCmdHost.Name = "btnChooseCmdHost";
            this.btnChooseCmdHost.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // txtNotificationTimeout
            // 
            resources.ApplyResources(this.txtNotificationTimeout, "txtNotificationTimeout");
            this.txtNotificationTimeout.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.txtNotificationTimeout.Name = "txtNotificationTimeout";
            this.txtNotificationTimeout.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // chkDisplayNotifications
            // 
            resources.ApplyResources(this.chkDisplayNotifications, "chkDisplayNotifications");
            this.chkDisplayNotifications.Name = "chkDisplayNotifications";
            this.chkDisplayNotifications.UseVisualStyleBackColor = true;
            // 
            // tabNetScanner
            // 
            this.tabNetScanner.Controls.Add(this.tableLayoutPanel6);
            resources.ApplyResources(this.tabNetScanner, "tabNetScanner");
            this.tabNetScanner.Name = "tabNetScanner";
            this.tabNetScanner.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Controls.Add(this.groupBox6, 0, 0);
            resources.ApplyResources(this.tableLayoutPanel6, "tableLayoutPanel6");
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.chkAddIfMacResolved);
            this.groupBox6.Controls.Add(this.chkAddIfNameResolved);
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // chkAddIfMacResolved
            // 
            resources.ApplyResources(this.chkAddIfMacResolved, "chkAddIfMacResolved");
            this.chkAddIfMacResolved.Name = "chkAddIfMacResolved";
            this.chkAddIfMacResolved.UseVisualStyleBackColor = true;
            // 
            // chkAddIfNameResolved
            // 
            resources.ApplyResources(this.chkAddIfNameResolved, "chkAddIfNameResolved");
            this.chkAddIfNameResolved.Name = "chkAddIfNameResolved";
            this.chkAddIfNameResolved.UseVisualStyleBackColor = true;
            // 
            // tabWOL
            // 
            this.tabWOL.Controls.Add(this.tableLayoutPanel2);
            resources.ApplyResources(this.tabWOL, "tabWOL");
            this.tabWOL.Name = "tabWOL";
            this.tabWOL.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 0);
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // groupBox3
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.groupBox3, 2);
            this.groupBox3.Controls.Add(this.numWakeDelay);
            this.groupBox3.Controls.Add(this.lblWolDelay);
            this.groupBox3.Controls.Add(this.chkAskForSecureOn);
            this.groupBox3.Controls.Add(this.rbSendToBCast);
            this.groupBox3.Controls.Add(this.rbSendToNetwork);
            this.groupBox3.Controls.Add(this.rbSendToNode);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // numWakeDelay
            // 
            resources.ApplyResources(this.numWakeDelay, "numWakeDelay");
            this.numWakeDelay.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numWakeDelay.Name = "numWakeDelay";
            this.numWakeDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblWolDelay
            // 
            this.lblWolDelay.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.lblWolDelay, "lblWolDelay");
            this.lblWolDelay.Name = "lblWolDelay";
            // 
            // chkAskForSecureOn
            // 
            resources.ApplyResources(this.chkAskForSecureOn, "chkAskForSecureOn");
            this.chkAskForSecureOn.Name = "chkAskForSecureOn";
            this.chkAskForSecureOn.UseVisualStyleBackColor = true;
            // 
            // rbSendToBCast
            // 
            this.rbSendToBCast.Checked = true;
            resources.ApplyResources(this.rbSendToBCast, "rbSendToBCast");
            this.rbSendToBCast.Name = "rbSendToBCast";
            this.rbSendToBCast.TabStop = true;
            this.rbSendToBCast.UseVisualStyleBackColor = true;
            // 
            // rbSendToNetwork
            // 
            resources.ApplyResources(this.rbSendToNetwork, "rbSendToNetwork");
            this.rbSendToNetwork.Name = "rbSendToNetwork";
            this.rbSendToNetwork.UseVisualStyleBackColor = true;
            // 
            // rbSendToNode
            // 
            resources.ApplyResources(this.rbSendToNode, "rbSendToNode");
            this.rbSendToNode.Name = "rbSendToNode";
            this.rbSendToNode.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.groupBox2, 2);
            this.groupBox2.Controls.Add(this.numWolPort);
            this.groupBox2.Controls.Add(this.label11);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // numWolPort
            // 
            resources.ApplyResources(this.numWolPort, "numWolPort");
            this.numWolPort.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numWolPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numWolPort.Name = "numWolPort";
            this.numWolPort.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // tabShutdwnReboot
            // 
            this.tabShutdwnReboot.Controls.Add(this.tableLayoutPanel3);
            resources.ApplyResources(this.tabShutdwnReboot, "tabShutdwnReboot");
            this.tabShutdwnReboot.Name = "tabShutdwnReboot";
            this.tabShutdwnReboot.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.groupBox5, 1, 1);
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // label1
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.label1, 2);
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel4);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Controls.Add(this.txtShutdownDomain, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.label9, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblUser, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.txtCommentShutdown, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtUserShutdown, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.txtPasswdShutdown, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.numTimeoutShutdown, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.chkForceShutdown, 0, 5);
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // txtShutdownDomain
            // 
            resources.ApplyResources(this.txtShutdownDomain, "txtShutdownDomain");
            this.txtShutdownDomain.Name = "txtShutdownDomain";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // lblUser
            // 
            resources.ApplyResources(this.lblUser, "lblUser");
            this.lblUser.Name = "lblUser";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtCommentShutdown
            // 
            resources.ApplyResources(this.txtCommentShutdown, "txtCommentShutdown");
            this.txtCommentShutdown.Name = "txtCommentShutdown";
            // 
            // txtUserShutdown
            // 
            resources.ApplyResources(this.txtUserShutdown, "txtUserShutdown");
            this.txtUserShutdown.Name = "txtUserShutdown";
            // 
            // txtPasswdShutdown
            // 
            resources.ApplyResources(this.txtPasswdShutdown, "txtPasswdShutdown");
            this.txtPasswdShutdown.Name = "txtPasswdShutdown";
            this.txtPasswdShutdown.UseSystemPasswordChar = true;
            // 
            // numTimeoutShutdown
            // 
            resources.ApplyResources(this.numTimeoutShutdown, "numTimeoutShutdown");
            this.numTimeoutShutdown.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.numTimeoutShutdown.Name = "numTimeoutShutdown";
            // 
            // chkForceShutdown
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.chkForceShutdown, 2);
            resources.ApplyResources(this.chkForceShutdown, "chkForceShutdown");
            this.chkForceShutdown.Name = "chkForceShutdown";
            this.chkForceShutdown.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tableLayoutPanel5);
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Controls.Add(this.txtRebootDomain, 1, 4);
            this.tableLayoutPanel5.Controls.Add(this.label10, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.txtCommentReboot, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.txtUserReboot, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.txtPasswdReboot, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.numTimeoutReboot, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.chkForceReboot, 0, 5);
            resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            // 
            // txtRebootDomain
            // 
            resources.ApplyResources(this.txtRebootDomain, "txtRebootDomain");
            this.txtRebootDomain.Name = "txtRebootDomain";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txtCommentReboot
            // 
            resources.ApplyResources(this.txtCommentReboot, "txtCommentReboot");
            this.txtCommentReboot.Name = "txtCommentReboot";
            // 
            // txtUserReboot
            // 
            resources.ApplyResources(this.txtUserReboot, "txtUserReboot");
            this.txtUserReboot.Name = "txtUserReboot";
            // 
            // txtPasswdReboot
            // 
            resources.ApplyResources(this.txtPasswdReboot, "txtPasswdReboot");
            this.txtPasswdReboot.Name = "txtPasswdReboot";
            this.txtPasswdReboot.UseSystemPasswordChar = true;
            // 
            // numTimeoutReboot
            // 
            resources.ApplyResources(this.numTimeoutReboot, "numTimeoutReboot");
            this.numTimeoutReboot.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.numTimeoutReboot.Name = "numTimeoutReboot";
            // 
            // chkForceReboot
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.chkForceReboot, 2);
            resources.ApplyResources(this.chkForceReboot, "chkForceReboot");
            this.chkForceReboot.Name = "chkForceReboot";
            this.chkForceReboot.UseVisualStyleBackColor = true;
            // 
            // tabTools
            // 
            this.tabTools.Controls.Add(this.listView1);
            resources.ApplyResources(this.tabTools, "tabTools");
            this.tabTools.Name = "tabTools";
            this.tabTools.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.LabelEdit = true;
            this.listView1.Name = "listView1";
            this.listView1.SmallImageList = this.imgLstTools;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolToolStripMenuItem,
            this.modifyToolToolStripMenuItem,
            this.deleteToolToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // addToolToolStripMenuItem
            // 
            this.addToolToolStripMenuItem.Name = "addToolToolStripMenuItem";
            resources.ApplyResources(this.addToolToolStripMenuItem, "addToolToolStripMenuItem");
            this.addToolToolStripMenuItem.Click += new System.EventHandler(this.AddToolToolStripMenuItemClick);
            // 
            // modifyToolToolStripMenuItem
            // 
            this.modifyToolToolStripMenuItem.Name = "modifyToolToolStripMenuItem";
            resources.ApplyResources(this.modifyToolToolStripMenuItem, "modifyToolToolStripMenuItem");
            this.modifyToolToolStripMenuItem.Click += new System.EventHandler(this.ModifyToolToolStripMenuItemClick);
            // 
            // deleteToolToolStripMenuItem
            // 
            this.deleteToolToolStripMenuItem.Name = "deleteToolToolStripMenuItem";
            resources.ApplyResources(this.deleteToolToolStripMenuItem, "deleteToolToolStripMenuItem");
            this.deleteToolToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolToolStripMenuItemClick);
            // 
            // imgLstTools
            // 
            this.imgLstTools.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.imgLstTools, "imgLstTools");
            this.imgLstTools.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // ofd
            // 
            resources.ApplyResources(this.ofd, "ofd");
            // 
            // frmDlgOptions
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDlgOptions";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabNotify.ResumeLayout(false);
            this.tabNotify.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPingTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRefreshInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNotificationTimeout)).EndInit();
            this.tabNetScanner.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabWOL.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numWakeDelay)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numWolPort)).EndInit();
            this.tabShutdwnReboot.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeoutShutdown)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeoutReboot)).EndInit();
            this.tabTools.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
        private System.Windows.Forms.CheckBox chkAutosaveHostlist;
		private System.Windows.Forms.CheckBox chkAddIfNameResolved;
		private System.Windows.Forms.CheckBox chkAddIfMacResolved;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
		private System.Windows.Forms.TabPage tabNetScanner;
		private System.Windows.Forms.ToolStripMenuItem deleteToolToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem modifyToolToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addToolToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TabPage tabTools;
		private System.Windows.Forms.CheckBox chkOpenLastFile;
		private System.Windows.Forms.CheckBox chkForceReboot;
		private System.Windows.Forms.CheckBox chkForceShutdown;
		private System.Windows.Forms.TextBox txtRebootDomain;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtShutdownDomain;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.NumericUpDown numTimeoutReboot;
		private System.Windows.Forms.TextBox txtPasswdReboot;
		private System.Windows.Forms.TextBox txtUserReboot;
		private System.Windows.Forms.TextBox txtCommentReboot;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.NumericUpDown numTimeoutShutdown;
		private System.Windows.Forms.TextBox txtPasswdShutdown;
		private System.Windows.Forms.TextBox txtUserShutdown;
		private System.Windows.Forms.TextBox txtCommentShutdown;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lblUser;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.TabPage tabShutdwnReboot;
		private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabWOL;
		private System.Windows.Forms.RadioButton rbSendToNode;
		private System.Windows.Forms.RadioButton rbSendToNetwork;
		private System.Windows.Forms.RadioButton rbSendToBCast;
        private System.Windows.Forms.CheckBox chkAskForSecureOn;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblWiz;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tabNotify;
        private System.Windows.Forms.CheckBox chkColorizeListView;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numWakeDelay;
        private System.Windows.Forms.Label lblWolDelay;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.CheckBox chkDoLogging;
        private System.Windows.Forms.CheckBox chkConfirmNetworkOperations;
        private System.Windows.Forms.CheckBox chkMinimizeToTray;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown numPingTimeout;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numRefreshInterval;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnChooseCmdGroup;
        private System.Windows.Forms.TextBox txtCmdGroupChange;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox chkDisplayNotificationsAlways;
        private System.Windows.Forms.TextBox txtCmdHostChange;
        private System.Windows.Forms.Button btnChooseCmdHost;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown txtNotificationTimeout;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox chkDisplayNotifications;
        private System.Windows.Forms.NumericUpDown numWolPort;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkIpV6;
        private System.Windows.Forms.ImageList imgLstTools;
        private System.Windows.Forms.CheckBox chkUpdateIPAddresses;
	}
}

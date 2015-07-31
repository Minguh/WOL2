/*
 * Erstellt mit SharpDevelop.
 * Benutzer: MOE
 * Datum: 16.12.2008
 * Zeit: 14:33
 * 
 * Sie können diese Vorlage unter Extras > Optionen > Codeerstellung > Standardheader ändern.
 */
namespace WOL2
{
	partial class DlgEditHost
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgEditHost));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboWolMode = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnHostLookup = new System.Windows.Forms.Button();
            this.btnLookUpIpV4 = new System.Windows.Forms.Button();
            this.btnIpV6 = new System.Windows.Forms.Button();
            this.txtGroups = new System.Windows.Forms.TextBox();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtSecureOn = new System.Windows.Forms.TextBox();
            this.txtSnMask = new System.Windows.Forms.TextBox();
            this.txtIPv6 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMac = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.chkNotify = new System.Windows.Forms.CheckBox();
            this.chkDHCP = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblWiz = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cboWolMode);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnVerify);
            this.groupBox1.Controls.Add(this.btnHostLookup);
            this.groupBox1.Controls.Add(this.btnLookUpIpV4);
            this.groupBox1.Controls.Add(this.btnIpV6);
            this.groupBox1.Controls.Add(this.txtGroups);
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.txtSecureOn);
            this.groupBox1.Controls.Add(this.txtSnMask);
            this.groupBox1.Controls.Add(this.txtIPv6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtMac);
            this.groupBox1.Controls.Add(this.txtIp);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.chkNotify);
            this.groupBox1.Controls.Add(this.chkDHCP);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // cboWolMode
            // 
            resources.ApplyResources(this.cboWolMode, "cboWolMode");
            this.cboWolMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWolMode.FormattingEnabled = true;
            this.cboWolMode.Items.AddRange(new object[] {
            resources.GetString("cboWolMode.Items"),
            resources.GetString("cboWolMode.Items1"),
            resources.GetString("cboWolMode.Items2"),
            resources.GetString("cboWolMode.Items3")});
            this.cboWolMode.Name = "cboWolMode";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnVerify
            // 
            resources.ApplyResources(this.btnVerify, "btnVerify");
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnHostLookup
            // 
            resources.ApplyResources(this.btnHostLookup, "btnHostLookup");
            this.btnHostLookup.Name = "btnHostLookup";
            this.btnHostLookup.UseVisualStyleBackColor = true;
            this.btnHostLookup.Click += new System.EventHandler(this.btnHostLookup_Click);
            // 
            // btnLookUpIpV4
            // 
            resources.ApplyResources(this.btnLookUpIpV4, "btnLookUpIpV4");
            this.btnLookUpIpV4.Name = "btnLookUpIpV4";
            this.btnLookUpIpV4.UseVisualStyleBackColor = true;
            this.btnLookUpIpV4.Click += new System.EventHandler(this.btnLookUpIpV4_Click);
            // 
            // btnIpV6
            // 
            resources.ApplyResources(this.btnIpV6, "btnIpV6");
            this.btnIpV6.Name = "btnIpV6";
            this.btnIpV6.UseVisualStyleBackColor = true;
            this.btnIpV6.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtGroups
            // 
            resources.ApplyResources(this.txtGroups, "txtGroups");
            this.txtGroups.Name = "txtGroups";
            // 
            // txtComment
            // 
            resources.ApplyResources(this.txtComment, "txtComment");
            this.txtComment.Name = "txtComment";
            // 
            // txtSecureOn
            // 
            resources.ApplyResources(this.txtSecureOn, "txtSecureOn");
            this.txtSecureOn.Name = "txtSecureOn";
            // 
            // txtSnMask
            // 
            resources.ApplyResources(this.txtSnMask, "txtSnMask");
            this.txtSnMask.Name = "txtSnMask";
            // 
            // txtIPv6
            // 
            resources.ApplyResources(this.txtIPv6, "txtIPv6");
            this.txtIPv6.Name = "txtIPv6";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txtMac
            // 
            resources.ApplyResources(this.txtMac, "txtMac");
            this.txtMac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMac.Name = "txtMac";
            // 
            // txtIp
            // 
            resources.ApplyResources(this.txtIp, "txtIp");
            this.txtIp.Name = "txtIp";
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtName.Name = "txtName";
            // 
            // chkNotify
            // 
            resources.ApplyResources(this.chkNotify, "chkNotify");
            this.chkNotify.Name = "chkNotify";
            this.chkNotify.UseVisualStyleBackColor = true;
            // 
            // chkDHCP
            // 
            resources.ApplyResources(this.chkDHCP, "chkDHCP");
            this.chkDHCP.Name = "chkDHCP";
            this.chkDHCP.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblWiz);
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
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // DlgEditHost
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "DlgEditHost";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblWiz;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtGroups;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtSecureOn;
        private System.Windows.Forms.TextBox txtSnMask;
        private System.Windows.Forms.TextBox txtIPv6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMac;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkNotify;
        private System.Windows.Forms.CheckBox chkDHCP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIpV6;
        private System.Windows.Forms.Button btnLookUpIpV4;
        private System.Windows.Forms.Button btnHostLookup;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboWolMode;
	}
}

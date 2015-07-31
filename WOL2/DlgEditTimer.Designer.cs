/*
 * WOL2 Timer modification dialog.
 */
namespace WOL2
{
	partial class DlgEditTimer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgEditTimer));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblWiz = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtHour = new System.Windows.Forms.NumericUpDown();
            this.txtMinute = new System.Windows.Forms.NumericUpDown();
            this.txtSecond = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkTimerEnabled = new System.Windows.Forms.CheckBox();
            this.lblSummary = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbDays = new System.Windows.Forms.CheckedListBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecond)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
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
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.tableLayoutPanel1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.chkEnabled, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnApply, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtHour, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtMinute, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSecond, 1, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // chkEnabled
            // 
            resources.ApplyResources(this.chkEnabled, "chkEnabled");
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
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
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // btnApply
            // 
            resources.ApplyResources(this.btnApply, "btnApply");
            this.btnApply.Name = "btnApply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.LinkLabel1Click);
            // 
            // txtHour
            // 
            resources.ApplyResources(this.txtHour, "txtHour");
            this.txtHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.txtHour.Name = "txtHour";
            // 
            // txtMinute
            // 
            resources.ApplyResources(this.txtMinute, "txtMinute");
            this.txtMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.txtMinute.Name = "txtMinute";
            // 
            // txtSecond
            // 
            resources.ApplyResources(this.txtSecond, "txtSecond");
            this.txtSecond.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.txtSecond.Name = "txtSecond";
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.chkTimerEnabled);
            this.groupBox3.Controls.Add(this.lblSummary);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // chkTimerEnabled
            // 
            resources.ApplyResources(this.chkTimerEnabled, "chkTimerEnabled");
            this.chkTimerEnabled.Name = "chkTimerEnabled";
            this.chkTimerEnabled.UseVisualStyleBackColor = true;
            this.chkTimerEnabled.CheckedChanged += new System.EventHandler(this.ChkTimerEnabledCheckedChanged);
            // 
            // lblSummary
            // 
            resources.ApplyResources(this.lblSummary, "lblSummary");
            this.lblSummary.Name = "lblSummary";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.lbDays);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // lbDays
            // 
            resources.ApplyResources(this.lbDays, "lbDays");
            this.lbDays.FormattingEnabled = true;
            this.lbDays.Items.AddRange(new object[] {
            resources.GetString("lbDays.Items"),
            resources.GetString("lbDays.Items1"),
            resources.GetString("lbDays.Items2"),
            resources.GetString("lbDays.Items3"),
            resources.GetString("lbDays.Items4"),
            resources.GetString("lbDays.Items5"),
            resources.GetString("lbDays.Items6")});
            this.lbDays.Name = "lbDays";
            this.lbDays.SelectedIndexChanged += new System.EventHandler(this.LbDaysSelectedIndexChanged);
            // 
            // DlgEditTimer
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
            this.Name = "DlgEditTimer";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecond)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.CheckBox chkTimerEnabled;
		private System.Windows.Forms.NumericUpDown txtSecond;
		private System.Windows.Forms.NumericUpDown txtMinute;
		private System.Windows.Forms.NumericUpDown txtHour;
		private System.Windows.Forms.CheckBox chkEnabled;
		private System.Windows.Forms.CheckedListBox lbDays;
		private System.Windows.Forms.Label lblSummary;
		// private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblWiz;
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
	}
}

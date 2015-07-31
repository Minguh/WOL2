/*
 * C# Input Box
 * 
 * http://www.knowdotnet.com/articles/inputbox.html
 * 
 */
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MOE
{
  /// <summary>
  /// The input box dialog.
  /// </summary>
  public class InputBoxDialog : System.Windows.Forms.Form
  {

    #region Windows Contols and Constructor

      /// <summary>
    /// Required designer variable.
    ///
    private System.ComponentModel.Container components = null;

    public InputBoxDialog()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
    }

    #endregion

    #region Dispose

    /// <summary>
    /// Clean up any resources being used.
    ///
    protected override void Dispose( bool disposing )
    {
      if( disposing )
      {
        if(components != null)
        {
          components.Dispose();
        }
      }
      base.Dispose( disposing );
    }

    #endregion

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    ///
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputBoxDialog));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblPrompt = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Name = "panel1";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Name = "button1";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.txtInput, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblPrompt, 0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // txtInput
            // 
            resources.ApplyResources(this.txtInput, "txtInput");
            this.txtInput.MinimumSize = new System.Drawing.Size(10, 20);
            this.txtInput.Name = "txtInput";
            // 
            // lblPrompt
            // 
            resources.ApplyResources(this.lblPrompt, "lblPrompt");
            this.lblPrompt.BackColor = System.Drawing.SystemColors.Control;
            this.lblPrompt.MinimumSize = new System.Drawing.Size(10, 10);
            this.lblPrompt.Name = "lblPrompt";
            // 
            // InputBoxDialog
            // 
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.button1;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InputBoxDialog";
            this.Opacity = 0.9D;
            this.Load += new System.EventHandler(this.InputBox_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

    }
    #endregion

    #region Private Variables
    private TableLayoutPanel tableLayoutPanel1;
    private Panel panel1;
    private Button button1;
    private Button btnOK;
    private TableLayoutPanel tableLayoutPanel2;
    private TextBox txtInput;
    private Label lblPrompt;
    string defaultValue = string.Empty;
    #endregion

    #region Public Properties

    public string FormCaption
    {
        get;
        set;
    } // property FormCaption

    public string FormPrompt
    {
        get;
        set;
    } // property FormPrompt
    public string InputResponse
    {
        get;
        set;
    } // property InputResponse
    public string DefaultValue
    {
      get{return defaultValue;}
      set{defaultValue = value;}
    } // property DefaultValue

    #endregion

    #region Form and Control Events
    private void InputBox_Load(object sender, System.EventArgs e)
    {
      this.txtInput.Text=defaultValue;
      this.lblPrompt.Text=FormPrompt;
      this.Text=FormCaption;
      this.txtInput.SelectionStart=0;
      this.txtInput.SelectionLength=this.txtInput.Text.Length;
      this.txtInput.Focus();
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
        this.Close();
    }
    #endregion

    private void btnOK_Click(object sender, EventArgs e)
    {
        InputResponse = this.txtInput.Text;
        this.Close();
    }
  }
}

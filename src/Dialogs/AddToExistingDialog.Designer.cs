using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BindingStudio.Dialogs
{
	public partial class AddToExistingDialog : Form
	{
		private ComboBox comboBox1;
		private Label label1;
		private Button button1;
		private Button btnOk;

		private void InitializeComponent ()
		{
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(53, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(430, 23);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select existing enum to add to:";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(429, 224);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(108, 35);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(315, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cancel";
            // 
            // AddToExistingDialog
            // 
            this.ClientSize = new System.Drawing.Size(549, 271);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnOk);
            this.Name = "AddToExistingDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add to existing enum";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}


namespace BindingStudio.Dialogs
{
	partial class AddApiLevelConstants
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose (bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMapCsv = new System.Windows.Forms.TextBox();
            this.txtApiXml = new System.Windows.Forms.TextBox();
            this.btnSelectMapCsv = new System.Windows.Forms.Button();
            this.btnSelectApiXml = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Existing map.csv:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "New api.xml to add:";
            // 
            // txtMapCsv
            // 
            this.txtMapCsv.Location = new System.Drawing.Point(11, 29);
            this.txtMapCsv.Name = "txtMapCsv";
            this.txtMapCsv.Size = new System.Drawing.Size(447, 23);
            this.txtMapCsv.TabIndex = 2;
            // 
            // txtApiXml
            // 
            this.txtApiXml.Location = new System.Drawing.Point(11, 89);
            this.txtApiXml.Name = "txtApiXml";
            this.txtApiXml.Size = new System.Drawing.Size(447, 23);
            this.txtApiXml.TabIndex = 3;
            // 
            // btnSelectMapCsv
            // 
            this.btnSelectMapCsv.Location = new System.Drawing.Point(464, 29);
            this.btnSelectMapCsv.Name = "btnSelectMapCsv";
            this.btnSelectMapCsv.Size = new System.Drawing.Size(28, 23);
            this.btnSelectMapCsv.TabIndex = 4;
            this.btnSelectMapCsv.Text = "...";
            this.btnSelectMapCsv.UseVisualStyleBackColor = true;
            this.btnSelectMapCsv.Click += new System.EventHandler(this.btnSelectMapCsv_Click);
            // 
            // btnSelectApiXml
            // 
            this.btnSelectApiXml.Location = new System.Drawing.Point(464, 89);
            this.btnSelectApiXml.Name = "btnSelectApiXml";
            this.btnSelectApiXml.Size = new System.Drawing.Size(28, 23);
            this.btnSelectApiXml.TabIndex = 5;
            this.btnSelectApiXml.Text = "...";
            this.btnSelectApiXml.UseVisualStyleBackColor = true;
            this.btnSelectApiXml.Click += new System.EventHandler(this.btnSelectApiXml_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(417, 161);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(336, 161);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // AddApiLevelConstants
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(502, 196);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSelectApiXml);
            this.Controls.Add(this.btnSelectMapCsv);
            this.Controls.Add(this.txtApiXml);
            this.Controls.Add(this.txtMapCsv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddApiLevelConstants";
            this.Text = "AddApiLevelConstants";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtMapCsv;
		private System.Windows.Forms.TextBox txtApiXml;
		private System.Windows.Forms.Button btnSelectMapCsv;
		private System.Windows.Forms.Button btnSelectApiXml;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
	}
}
namespace BindingStudio
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent ()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tsbIgnore = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMethodMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAPILevelConstantsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findAPILevelMethodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportFinalMethodMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpAPILevelUnnamedParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ConstantsFileToolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MethodMapFileToolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Size = new System.Drawing.Size(1984, 1089);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.Text = "splitContainer1";
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(300, 1089);
            this.treeView1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.tsbIgnore});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1984, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(125, 22);
            this.toolStripButton1.Text = "Add to existing enum";
            this.toolStripButton1.Click += new System.EventHandler(this.AddToExistingEnum_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(79, 22);
            this.toolStripButton2.Text = "Create Enum";
            this.toolStripButton2.Click += new System.EventHandler(this.CreateNewEnum_Click);
            // 
            // tsbIgnore
            // 
            this.tsbIgnore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbIgnore.Image = ((System.Drawing.Image)(resources.GetObject("tsbIgnore.Image")));
            this.tsbIgnore.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbIgnore.Name = "tsbIgnore";
            this.tsbIgnore.Size = new System.Drawing.Size(45, 22);
            this.tsbIgnore.Text = "Ignore";
            this.tsbIgnore.Click += new System.EventHandler(this.IgnoreConstant_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1984, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.openMethodMapToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.openToolStripMenuItem.Text = "&Open Constant Map";
            // 
            // openMethodMapToolStripMenuItem
            // 
            this.openMethodMapToolStripMenuItem.Name = "openMethodMapToolStripMenuItem";
            this.openMethodMapToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.openMethodMapToolStripMenuItem.Text = "Open Method Map";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(221, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAPILevelConstantsToolStripMenuItem,
            this.findAPILevelMethodsToolStripMenuItem,
            this.exportFinalMethodMapToolStripMenuItem,
            this.dumpAPILevelUnnamedParametersToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // addAPILevelConstantsToolStripMenuItem
            // 
            this.addAPILevelConstantsToolStripMenuItem.Name = "addAPILevelConstantsToolStripMenuItem";
            this.addAPILevelConstantsToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.addAPILevelConstantsToolStripMenuItem.Text = "Add API Level Constants";
            this.addAPILevelConstantsToolStripMenuItem.Click += new System.EventHandler(this.AddAPILevelConstantsToolStripMenuItem_Click);
            // 
            // findAPILevelMethodsToolStripMenuItem
            // 
            this.findAPILevelMethodsToolStripMenuItem.Name = "findAPILevelMethodsToolStripMenuItem";
            this.findAPILevelMethodsToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.findAPILevelMethodsToolStripMenuItem.Text = "Find API Level Methods";
            this.findAPILevelMethodsToolStripMenuItem.Click += new System.EventHandler(this.FindAPILevelMethodsToolStripMenuItem_Click);
            // 
            // exportFinalMethodMapToolStripMenuItem
            // 
            this.exportFinalMethodMapToolStripMenuItem.Name = "exportFinalMethodMapToolStripMenuItem";
            this.exportFinalMethodMapToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.exportFinalMethodMapToolStripMenuItem.Text = "Export Final Method Map";
            this.exportFinalMethodMapToolStripMenuItem.Click += new System.EventHandler(this.ExportFinalMethodMapToolStripMenuItem_Click);
            // 
            // dumpAPILevelUnnamedParametersToolStripMenuItem
            // 
            this.dumpAPILevelUnnamedParametersToolStripMenuItem.Name = "dumpAPILevelUnnamedParametersToolStripMenuItem";
            this.dumpAPILevelUnnamedParametersToolStripMenuItem.Size = new System.Drawing.Size(275, 22);
            this.dumpAPILevelUnnamedParametersToolStripMenuItem.Text = "Dump API Level Unnamed Parameters";
            this.dumpAPILevelUnnamedParametersToolStripMenuItem.Click += new System.EventHandler(this.DumpAPILevelUnnamedParametersToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.ConstantsFileToolStripLabel,
            this.ToolStripSeparator2,
            this.MethodMapFileToolStripLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1138);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1984, 23);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1963, 18);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ConstantsFileToolStripLabel
            // 
            this.ConstantsFileToolStripLabel.Name = "ConstantsFileToolStripLabel";
            this.ConstantsFileToolStripLabel.Size = new System.Drawing.Size(0, 18);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 23);
            // 
            // MethodMapFileToolStripLabel
            // 
            this.MethodMapFileToolStripLabel.Name = "MethodMapFileToolStripLabel";
            this.MethodMapFileToolStripLabel.Size = new System.Drawing.Size(0, 18);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1984, 1161);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "MainForm";
            this.Text = "Binding Studio";
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openMethodMapToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addAPILevelConstantsToolStripMenuItem;
		private System.Windows.Forms.ToolStripButton tsbIgnore;
		private System.Windows.Forms.ToolStripMenuItem findAPILevelMethodsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportFinalMethodMapToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem dumpAPILevelUnnamedParametersToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel ConstantsFileToolStripLabel;
		private System.Windows.Forms.ToolStripStatusLabel MethodMapFileToolStripLabel;
		private System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
	}
}


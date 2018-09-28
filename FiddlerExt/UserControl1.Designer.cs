namespace onSoft
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Files");
            this.btnCopyCode = new System.Windows.Forms.Button();
            this.txtcode = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPostTemplate = new System.Windows.Forms.Label();
            this.lblGetTemplate = new System.Windows.Forms.Label();
            this.lblBaseTemplate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeFiles = new System.Windows.Forms.TreeView();
            this.dfsNewPath = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCopyCode
            // 
            this.btnCopyCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyCode.Location = new System.Drawing.Point(992, 42);
            this.btnCopyCode.Name = "btnCopyCode";
            this.btnCopyCode.Size = new System.Drawing.Size(65, 23);
            this.btnCopyCode.TabIndex = 2;
            this.btnCopyCode.Text = "Copy Files";
            this.btnCopyCode.UseVisualStyleBackColor = true;
            this.btnCopyCode.Click += new System.EventHandler(this.btnCopyCode_Click);
            // 
            // txtcode
            // 
            this.txtcode.AutoWordSelection = true;
            this.txtcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtcode.Location = new System.Drawing.Point(0, 0);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(768, 452);
            this.txtcode.TabIndex = 3;
            this.txtcode.Text = "";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dfsNewPath);
            this.panel1.Controls.Add(this.lblPostTemplate);
            this.panel1.Controls.Add(this.lblGetTemplate);
            this.panel1.Controls.Add(this.lblBaseTemplate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCopyCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1082, 72);
            this.panel1.TabIndex = 4;
            // 
            // lblPostTemplate
            // 
            this.lblPostTemplate.AutoSize = true;
            this.lblPostTemplate.Location = new System.Drawing.Point(223, 52);
            this.lblPostTemplate.Name = "lblPostTemplate";
            this.lblPostTemplate.Size = new System.Drawing.Size(75, 13);
            this.lblPostTemplate.TabIndex = 6;
            this.lblPostTemplate.Text = "Post Template";
            // 
            // lblGetTemplate
            // 
            this.lblGetTemplate.AutoSize = true;
            this.lblGetTemplate.Location = new System.Drawing.Point(223, 27);
            this.lblGetTemplate.Name = "lblGetTemplate";
            this.lblGetTemplate.Size = new System.Drawing.Size(71, 13);
            this.lblGetTemplate.TabIndex = 5;
            this.lblGetTemplate.Text = "Get Template";
            // 
            // lblBaseTemplate
            // 
            this.lblBaseTemplate.AutoSize = true;
            this.lblBaseTemplate.Location = new System.Drawing.Point(223, 2);
            this.lblBaseTemplate.Name = "lblBaseTemplate";
            this.lblBaseTemplate.Size = new System.Drawing.Size(78, 13);
            this.lblBaseTemplate.TabIndex = 4;
            this.lblBaseTemplate.Text = "Base Template";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "drag and drop session here ...";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 78);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeFiles);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtcode);
            this.splitContainer1.Size = new System.Drawing.Size(1079, 452);
            this.splitContainer1.SplitterDistance = 307;
            this.splitContainer1.TabIndex = 5;
            // 
            // treeFiles
            // 
            this.treeFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeFiles.LabelEdit = true;
            this.treeFiles.Location = new System.Drawing.Point(0, 0);
            this.treeFiles.Name = "treeFiles";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Files";
            this.treeFiles.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeFiles.Size = new System.Drawing.Size(307, 452);
            this.treeFiles.TabIndex = 0;
            this.treeFiles.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeFiles_NodeMouseClick);
            // 
            // dfsNewPath
            // 
            this.dfsNewPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::onSoft.Properties.Settings.Default, "newPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dfsNewPath.Location = new System.Drawing.Point(612, 44);
            this.dfsNewPath.Name = "dfsNewPath";
            this.dfsNewPath.Size = new System.Drawing.Size(374, 20);
            this.dfsNewPath.TabIndex = 7;
            this.dfsNewPath.Text = global::onSoft.Properties.Settings.Default.newPath;
            // 
            // UserControl1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(1082, 533);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.UserControl1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.UserControl1_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.UserControl1_DragOver);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCopyCode;
        private System.Windows.Forms.RichTextBox txtcode;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeFiles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBaseTemplate;
        private System.Windows.Forms.Label lblPostTemplate;
        private System.Windows.Forms.Label lblGetTemplate;
        private System.Windows.Forms.TextBox dfsNewPath;
    }
}

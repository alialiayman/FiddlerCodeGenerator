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
            this.label3 = new System.Windows.Forms.Label();
            this.dfsUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dfsOutputClass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dfsInputClass = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeFiles = new System.Windows.Forms.TreeView();
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
            this.btnCopyCode.Location = new System.Drawing.Point(992, 33);
            this.btnCopyCode.Name = "btnCopyCode";
            this.btnCopyCode.Size = new System.Drawing.Size(65, 23);
            this.btnCopyCode.TabIndex = 2;
            this.btnCopyCode.Text = "Copy";
            this.btnCopyCode.UseVisualStyleBackColor = true;
            this.btnCopyCode.Click += new System.EventHandler(this.btnCopyCode_Click);
            // 
            // txtcode
            // 
            this.txtcode.AutoWordSelection = true;
            this.txtcode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtcode.Location = new System.Drawing.Point(0, 0);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(768, 434);
            this.txtcode.TabIndex = 3;
            this.txtcode.Text = "";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dfsUrl);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dfsOutputClass);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dfsInputClass);
            this.panel1.Controls.Add(this.btnCopyCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1082, 90);
            this.panel1.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Url";
            // 
            // dfsUrl
            // 
            this.dfsUrl.Location = new System.Drawing.Point(46, 14);
            this.dfsUrl.Multiline = true;
            this.dfsUrl.Name = "dfsUrl";
            this.dfsUrl.Size = new System.Drawing.Size(496, 59);
            this.dfsUrl.TabIndex = 7;
            this.toolTip1.SetToolTip(this.dfsUrl, "use {} to add url segments and notice the code change");
            this.dfsUrl.Leave += new System.EventHandler(this.dfsUrl_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(719, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Output Class";
            // 
            // dfsOutputClass
            // 
            this.dfsOutputClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dfsOutputClass.Location = new System.Drawing.Point(792, 53);
            this.dfsOutputClass.Name = "dfsOutputClass";
            this.dfsOutputClass.Size = new System.Drawing.Size(194, 20);
            this.dfsOutputClass.TabIndex = 5;
            this.toolTip1.SetToolTip(this.dfsOutputClass, "Change output class");
            this.dfsOutputClass.Leave += new System.EventHandler(this.dfsOutputClass_Leave);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(727, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Input Class";
            // 
            // dfsInputClass
            // 
            this.dfsInputClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dfsInputClass.Location = new System.Drawing.Point(792, 14);
            this.dfsInputClass.Name = "dfsInputClass";
            this.dfsInputClass.Size = new System.Drawing.Size(194, 20);
            this.dfsInputClass.TabIndex = 3;
            this.toolTip1.SetToolTip(this.dfsInputClass, "Change input class");
            this.dfsInputClass.Leave += new System.EventHandler(this.dfsInputClass_Leave);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 96);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeFiles);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtcode);
            this.splitContainer1.Size = new System.Drawing.Size(1079, 434);
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
            this.treeFiles.Size = new System.Drawing.Size(307, 434);
            this.treeFiles.TabIndex = 0;
            this.treeFiles.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeFiles_NodeMouseClick);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dfsOutputClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dfsInputClass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dfsUrl;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeFiles;
    }
}

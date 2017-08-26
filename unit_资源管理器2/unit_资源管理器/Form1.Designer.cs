namespace unit_资源管理器
{
    partial class From1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tvDrive = new System.Windows.Forms.TreeView();
            this.lvFileList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiShear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsimFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiText = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRename = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvDrive);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvFileList);
            this.splitContainer1.Size = new System.Drawing.Size(632, 453);
            this.splitContainer1.SplitterDistance = 225;
            this.splitContainer1.TabIndex = 0;
            // 
            // tvDrive
            // 
            this.tvDrive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvDrive.Location = new System.Drawing.Point(0, 0);
            this.tvDrive.Name = "tvDrive";
            this.tvDrive.Size = new System.Drawing.Size(225, 453);
            this.tvDrive.TabIndex = 0;
            this.tvDrive.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvDrive_AfterSelect);
            // 
            // lvFileList
            // 
            this.lvFileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvFileList.ContextMenuStrip = this.contextMenuStrip1;
            this.lvFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFileList.LabelEdit = true;
            this.lvFileList.Location = new System.Drawing.Point(0, 0);
            this.lvFileList.Name = "lvFileList";
            this.lvFileList.Size = new System.Drawing.Size(403, 453);
            this.lvFileList.TabIndex = 0;
            this.lvFileList.UseCompatibleStateImageBehavior = false;
            this.lvFileList.View = System.Windows.Forms.View.Details;
            this.lvFileList.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvFileList_AfterLabelEdit);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 86;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "修改日期";
            this.columnHeader2.Width = 82;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "类型";
            this.columnHeader3.Width = 83;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "大小";
            this.columnHeader4.Width = 75;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "路径";
            this.columnHeader5.Width = 71;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCopy,
            this.tsmiPaste,
            this.tsmiDelect,
            this.tsmiShear,
            this.tsmiNew,
            this.tsmiRename});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 136);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // tsmiCopy
            // 
            this.tsmiCopy.Name = "tsmiCopy";
            this.tsmiCopy.Size = new System.Drawing.Size(112, 22);
            this.tsmiCopy.Text = "复制";
            this.tsmiCopy.Click += new System.EventHandler(this.tsmiCopy_Click);
            // 
            // tsmiPaste
            // 
            this.tsmiPaste.Name = "tsmiPaste";
            this.tsmiPaste.Size = new System.Drawing.Size(112, 22);
            this.tsmiPaste.Text = "粘贴";
            this.tsmiPaste.Click += new System.EventHandler(this.tsmiPaste_Click);
            // 
            // tsmiDelect
            // 
            this.tsmiDelect.Name = "tsmiDelect";
            this.tsmiDelect.Size = new System.Drawing.Size(112, 22);
            this.tsmiDelect.Text = "删除";
            this.tsmiDelect.Click += new System.EventHandler(this.tsmiDelect_Click);
            // 
            // tsmiShear
            // 
            this.tsmiShear.Name = "tsmiShear";
            this.tsmiShear.Size = new System.Drawing.Size(112, 22);
            this.tsmiShear.Text = "剪贴";
            this.tsmiShear.Click += new System.EventHandler(this.tsmiShear_Click);
            // 
            // tsmiNew
            // 
            this.tsmiNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsimFile,
            this.tsmiText});
            this.tsmiNew.Name = "tsmiNew";
            this.tsmiNew.Size = new System.Drawing.Size(112, 22);
            this.tsmiNew.Text = "新建";
            // 
            // tsimFile
            // 
            this.tsimFile.Name = "tsimFile";
            this.tsimFile.Size = new System.Drawing.Size(112, 22);
            this.tsimFile.Text = "文件夹";
            this.tsimFile.Click += new System.EventHandler(this.tsimFile_Click);
            // 
            // tsmiText
            // 
            this.tsmiText.Name = "tsmiText";
            this.tsmiText.Size = new System.Drawing.Size(112, 22);
            this.tsmiText.Text = "文本";
            this.tsmiText.Click += new System.EventHandler(this.tsmiText_Click);
            // 
            // tsmiRename
            // 
            this.tsmiRename.Name = "tsmiRename";
            this.tsmiRename.Size = new System.Drawing.Size(112, 22);
            this.tsmiRename.Text = "重命名";
            this.tsmiRename.Click += new System.EventHandler(this.tsmiRename_Click_1);
            // 
            // From1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.splitContainer1);
            this.Name = "From1";
            this.Text = "资源管理器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.From1_FormClosed);
            this.Load += new System.EventHandler(this.From1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvDrive;
        private System.Windows.Forms.ListView lvFileList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopy;
        private System.Windows.Forms.ToolStripMenuItem tsmiPaste;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelect;
        private System.Windows.Forms.ToolStripMenuItem tsmiShear;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripMenuItem tsimFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiText;
        private System.Windows.Forms.ToolStripMenuItem tsmiRename;
    }
}


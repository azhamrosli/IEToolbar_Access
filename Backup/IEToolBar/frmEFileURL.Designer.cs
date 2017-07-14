namespace IEToolBar
{
    partial class frmEFileURL
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDeleteAll = new System.Windows.Forms.ToolStripButton();
            this.tsbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripCboYA = new System.Windows.Forms.ToolStripComboBox();
            this.dgEFURL = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEFURL)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnAdd,
            this.tsbtnEdit,
            this.tsbtnDelete,
            this.tsbtnDeleteAll,
            this.tsbtnRefresh,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripCboYA});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(590, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnAdd
            // 
            this.tsbtnAdd.Image = global::IEToolBar.Properties.Resources.pngNew;
            this.tsbtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAdd.Name = "tsbtnAdd";
            this.tsbtnAdd.Size = new System.Drawing.Size(46, 22);
            this.tsbtnAdd.Text = "Add";
            this.tsbtnAdd.Click += new System.EventHandler(this.tsbtnAdd_Click);
            // 
            // tsbtnEdit
            // 
            this.tsbtnEdit.Image = global::IEToolBar.Properties.Resources.pngEdit;
            this.tsbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEdit.Name = "tsbtnEdit";
            this.tsbtnEdit.Size = new System.Drawing.Size(45, 22);
            this.tsbtnEdit.Text = "Edit";
            this.tsbtnEdit.Click += new System.EventHandler(this.tsbtnEdit_Click);
            // 
            // tsbtnDelete
            // 
            this.tsbtnDelete.Image = global::IEToolBar.Properties.Resources.pngDelete;
            this.tsbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDelete.Name = "tsbtnDelete";
            this.tsbtnDelete.Size = new System.Drawing.Size(58, 22);
            this.tsbtnDelete.Text = "Delete";
            this.tsbtnDelete.Click += new System.EventHandler(this.tsbtnDelete_Click);
            // 
            // tsbtnDeleteAll
            // 
            this.tsbtnDeleteAll.Image = global::IEToolBar.Properties.Resources.pngDelete;
            this.tsbtnDeleteAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDeleteAll.Name = "tsbtnDeleteAll";
            this.tsbtnDeleteAll.Size = new System.Drawing.Size(72, 22);
            this.tsbtnDeleteAll.Text = "Delete All";
            this.tsbtnDeleteAll.Click += new System.EventHandler(this.tsbtnDeleteAll_Click);
            // 
            // tsbtnRefresh
            // 
            this.tsbtnRefresh.Image = global::IEToolBar.Properties.Resources.gifRefresh;
            this.tsbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefresh.Name = "tsbtnRefresh";
            this.tsbtnRefresh.Size = new System.Drawing.Size(65, 22);
            this.tsbtnRefresh.Text = "Refresh";
            this.tsbtnRefresh.Click += new System.EventHandler(this.tsbtnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(59, 22);
            this.toolStripLabel1.Text = "Search By:";
            // 
            // toolStripCboYA
            // 
            this.toolStripCboYA.Name = "toolStripCboYA";
            this.toolStripCboYA.Size = new System.Drawing.Size(121, 25);
            this.toolStripCboYA.SelectedIndexChanged += new System.EventHandler(this.toolStripCboYA_SelectedIndexChanged);
            this.toolStripCboYA.DropDown += new System.EventHandler(this.toolStripCboYA_DropDown);
            // 
            // dgEFURL
            // 
            this.dgEFURL.AllowUserToAddRows = false;
            this.dgEFURL.AllowUserToDeleteRows = false;
            this.dgEFURL.AllowUserToResizeRows = false;
            this.dgEFURL.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgEFURL.BackgroundColor = System.Drawing.Color.White;
            this.dgEFURL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEFURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgEFURL.Location = new System.Drawing.Point(0, 25);
            this.dgEFURL.MultiSelect = false;
            this.dgEFURL.Name = "dgEFURL";
            this.dgEFURL.ReadOnly = true;
            this.dgEFURL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEFURL.Size = new System.Drawing.Size(590, 289);
            this.dgEFURL.TabIndex = 5;
            this.dgEFURL.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEFURL_CellDoubleClick);
            // 
            // frmEFileURL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 314);
            this.Controls.Add(this.dgEFURL);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmEFileURL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TAXcom E-Filing";
            this.Load += new System.EventHandler(this.frmEFileMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEFURL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnAdd;
        private System.Windows.Forms.ToolStripButton tsbtnEdit;
        private System.Windows.Forms.ToolStripButton tsbtnDelete;
        private System.Windows.Forms.DataGridView dgEFURL;
        private System.Windows.Forms.ToolStripButton tsbtnRefresh;
        private System.Windows.Forms.ToolStripComboBox toolStripCboYA;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsbtnDeleteAll;
    }
}
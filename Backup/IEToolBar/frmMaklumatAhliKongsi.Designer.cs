namespace IEToolBar
{
    partial class frmMaklumatAhliKongsi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaklumatAhliKongsi));
            this.tsMAK = new System.Windows.Forms.ToolStrip();
            this.tsbtnFill = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dgEFMAK = new System.Windows.Forms.DataGridView();
            this.tsMAK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEFMAK)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMAK
            // 
            this.tsMAK.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnFill,
            this.toolStripButton1});
            this.tsMAK.Location = new System.Drawing.Point(0, 0);
            this.tsMAK.Name = "tsMAK";
            this.tsMAK.Size = new System.Drawing.Size(527, 25);
            this.tsMAK.TabIndex = 4;
            this.tsMAK.Text = "toolStrip1";
            // 
            // tsbtnFill
            // 
            this.tsbtnFill.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFill.Image")));
            this.tsbtnFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFill.Name = "tsbtnFill";
            this.tsbtnFill.Size = new System.Drawing.Size(66, 22);
            this.tsbtnFill.Text = "Fill Form";
            this.tsbtnFill.Click += new System.EventHandler(this.tsbtnFill_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::IEToolBar.Properties.Resources.gifRefresh;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(65, 22);
            this.toolStripButton1.Text = "Refresh";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // dgEFMAK
            // 
            this.dgEFMAK.AllowUserToAddRows = false;
            this.dgEFMAK.AllowUserToDeleteRows = false;
            this.dgEFMAK.AllowUserToResizeRows = false;
            this.dgEFMAK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgEFMAK.BackgroundColor = System.Drawing.Color.White;
            this.dgEFMAK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEFMAK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgEFMAK.Location = new System.Drawing.Point(0, 25);
            this.dgEFMAK.MultiSelect = false;
            this.dgEFMAK.Name = "dgEFMAK";
            this.dgEFMAK.ReadOnly = true;
            this.dgEFMAK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEFMAK.Size = new System.Drawing.Size(527, 241);
            this.dgEFMAK.TabIndex = 5;
            this.dgEFMAK.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEFMAK_CellContentClick);
            // 
            // frmMaklumatAhliKongsi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 266);
            this.Controls.Add(this.dgEFMAK);
            this.Controls.Add(this.tsMAK);
            this.Name = "frmMaklumatAhliKongsi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maklumat Ahli Kongsi";
            this.tsMAK.ResumeLayout(false);
            this.tsMAK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEFMAK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMAK;
        private System.Windows.Forms.ToolStripButton tsbtnFill;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridView dgEFMAK;
    }
}
namespace IEToolBar
{
    partial class frmRKTRKS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRKTRKS));
            this.tsRKTRKS = new System.Windows.Forms.ToolStrip();
            this.tsbtnFill = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dgEFRKTRKS = new System.Windows.Forms.DataGridView();
            this.tsRKTRKS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEFRKTRKS)).BeginInit();
            this.SuspendLayout();
            // 
            // tsRKTRKS
            // 
            this.tsRKTRKS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnFill,
            this.toolStripButton1});
            this.tsRKTRKS.Location = new System.Drawing.Point(0, 0);
            this.tsRKTRKS.Name = "tsRKTRKS";
            this.tsRKTRKS.Size = new System.Drawing.Size(527, 25);
            this.tsRKTRKS.TabIndex = 0;
            this.tsRKTRKS.Text = "toolStrip1";
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
            // dgEFRKTRKS
            // 
            this.dgEFRKTRKS.AllowUserToAddRows = false;
            this.dgEFRKTRKS.AllowUserToDeleteRows = false;
            this.dgEFRKTRKS.AllowUserToResizeRows = false;
            this.dgEFRKTRKS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgEFRKTRKS.BackgroundColor = System.Drawing.Color.White;
            this.dgEFRKTRKS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEFRKTRKS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgEFRKTRKS.Location = new System.Drawing.Point(0, 25);
            this.dgEFRKTRKS.MultiSelect = false;
            this.dgEFRKTRKS.Name = "dgEFRKTRKS";
            this.dgEFRKTRKS.ReadOnly = true;
            this.dgEFRKTRKS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEFRKTRKS.Size = new System.Drawing.Size(527, 241);
            this.dgEFRKTRKS.TabIndex = 1;
            this.dgEFRKTRKS.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEFRKTRKS_CellDoubleClick);
            // 
            // frmRKTRKS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 266);
            this.Controls.Add(this.dgEFRKTRKS);
            this.Controls.Add(this.tsRKTRKS);
            this.Name = "frmRKTRKS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RKT/ RKS";
            this.tsRKTRKS.ResumeLayout(false);
            this.tsRKTRKS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEFRKTRKS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsRKTRKS;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton tsbtnFill;
        private System.Windows.Forms.DataGridView dgEFRKTRKS;
    }
}
namespace IEToolBar
{
    partial class frmHK3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHK3));
            this.tsHK3 = new System.Windows.Forms.ToolStrip();
            this.tsbtnFill = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dgEFHK3 = new System.Windows.Forms.DataGridView();
            this.tsHK3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEFHK3)).BeginInit();
            this.SuspendLayout();
            // 
            // tsHK3
            // 
            this.tsHK3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnFill,
            this.toolStripButton1});
            this.tsHK3.Location = new System.Drawing.Point(0, 0);
            this.tsHK3.Name = "tsHK3";
            this.tsHK3.Size = new System.Drawing.Size(527, 25);
            this.tsHK3.TabIndex = 1;
            this.tsHK3.Text = "toolStrip1";
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
            // dgEFHK3
            // 
            this.dgEFHK3.AllowUserToAddRows = false;
            this.dgEFHK3.AllowUserToDeleteRows = false;
            this.dgEFHK3.AllowUserToResizeRows = false;
            this.dgEFHK3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgEFHK3.BackgroundColor = System.Drawing.Color.White;
            this.dgEFHK3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEFHK3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgEFHK3.Location = new System.Drawing.Point(0, 25);
            this.dgEFHK3.MultiSelect = false;
            this.dgEFHK3.Name = "dgEFHK3";
            this.dgEFHK3.ReadOnly = true;
            this.dgEFHK3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEFHK3.Size = new System.Drawing.Size(527, 241);
            this.dgEFHK3.TabIndex = 2;
            this.dgEFHK3.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEFHK3_CellContentDoubleClick);
            // 
            // frmHK3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 266);
            this.Controls.Add(this.dgEFHK3);
            this.Controls.Add(this.tsHK3);
            this.MaximizeBox = false;
            this.Name = "frmHK3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HK-3";
            this.tsHK3.ResumeLayout(false);
            this.tsHK3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEFHK3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsHK3;
        private System.Windows.Forms.ToolStripButton tsbtnFill;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridView dgEFHK3;


    }
}
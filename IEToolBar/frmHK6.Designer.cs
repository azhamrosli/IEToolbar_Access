namespace IEToolBar
{
    partial class frmHK6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHK6));
            this.tsHK6 = new System.Windows.Forms.ToolStrip();
            this.tsbtnFill = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dgEFHK6 = new System.Windows.Forms.DataGridView();
            this.tsHK6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEFHK6)).BeginInit();
            this.SuspendLayout();
            // 
            // tsHK6
            // 
            this.tsHK6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnFill,
            this.toolStripButton1});
            this.tsHK6.Location = new System.Drawing.Point(0, 0);
            this.tsHK6.Name = "tsHK6";
            this.tsHK6.Size = new System.Drawing.Size(527, 25);
            this.tsHK6.TabIndex = 1;
            this.tsHK6.Text = "toolStrip1";
            // 
            // tsbtnFill
            // 
            this.tsbtnFill.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFill.Image")));
            this.tsbtnFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFill.Name = "tsbtnFill";
            this.tsbtnFill.Size = new System.Drawing.Size(73, 22);
            this.tsbtnFill.Text = "Fill Form";
            this.tsbtnFill.Click += new System.EventHandler(this.tsbtnFill_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::IEToolBar.Properties.Resources.gifRefresh;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(66, 22);
            this.toolStripButton1.Text = "Refresh";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // dgEFHK6
            // 
            this.dgEFHK6.AllowUserToAddRows = false;
            this.dgEFHK6.AllowUserToDeleteRows = false;
            this.dgEFHK6.AllowUserToResizeRows = false;
            this.dgEFHK6.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgEFHK6.BackgroundColor = System.Drawing.Color.White;
            this.dgEFHK6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEFHK6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgEFHK6.Location = new System.Drawing.Point(0, 25);
            this.dgEFHK6.MultiSelect = false;
            this.dgEFHK6.Name = "dgEFHK6";
            this.dgEFHK6.ReadOnly = true;
            this.dgEFHK6.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgEFHK6.Size = new System.Drawing.Size(527, 241);
            this.dgEFHK6.TabIndex = 2;
            this.dgEFHK6.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEFHK6_CellContentDoubleClick);
            // 
            // frmHK6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 266);
            this.Controls.Add(this.dgEFHK6);
            this.Controls.Add(this.tsHK6);
            this.MaximizeBox = false;
            this.Name = "frmHK6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HK-6";
            this.Load += new System.EventHandler(this.frmHK6_Load);
            this.tsHK6.ResumeLayout(false);
            this.tsHK6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgEFHK6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsHK6;
        private System.Windows.Forms.ToolStripButton tsbtnFill;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.DataGridView dgEFHK6;


    }
}
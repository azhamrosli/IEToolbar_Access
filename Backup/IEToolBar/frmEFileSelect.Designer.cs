namespace IEToolBar
{
    partial class frmEFileSelect
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
            this.dgTaxPayer = new System.Windows.Forms.DataGridView();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblPosition = new System.Windows.Forms.Label();
            this.chkKeep = new System.Windows.Forms.CheckBox();
            this.cboAuditor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboForm = new System.Windows.Forms.ComboBox();
            this.cboYA = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripCboForm = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripCboYA = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripCboBy = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTxtText = new System.Windows.Forms.ToolStripTextBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTaxAgent = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgTaxPayer)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgTaxPayer
            // 
            this.dgTaxPayer.AllowUserToAddRows = false;
            this.dgTaxPayer.AllowUserToDeleteRows = false;
            this.dgTaxPayer.AllowUserToResizeRows = false;
            this.dgTaxPayer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgTaxPayer.BackgroundColor = System.Drawing.Color.White;
            this.dgTaxPayer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTaxPayer.Location = new System.Drawing.Point(0, 25);
            this.dgTaxPayer.MultiSelect = false;
            this.dgTaxPayer.Name = "dgTaxPayer";
            this.dgTaxPayer.ReadOnly = true;
            this.dgTaxPayer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgTaxPayer.Size = new System.Drawing.Size(692, 300);
            this.dgTaxPayer.TabIndex = 0;
            this.dgTaxPayer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTaxPayer_CellDoubleClick);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(554, 420);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(60, 25);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(620, 420);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(60, 25);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(18, 70);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(96, 13);
            this.lblPosition.TabIndex = 7;
            this.lblPosition.Text = "Tax Agent Position";
            // 
            // chkKeep
            // 
            this.chkKeep.AutoSize = true;
            this.chkKeep.Checked = true;
            this.chkKeep.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeep.Location = new System.Drawing.Point(525, 15);
            this.chkKeep.Name = "chkKeep";
            this.chkKeep.Size = new System.Drawing.Size(89, 17);
            this.chkKeep.TabIndex = 4;
            this.chkKeep.Text = "Keep Record";
            this.chkKeep.UseVisualStyleBackColor = true;
            // 
            // cboAuditor
            // 
            this.cboAuditor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAuditor.FormattingEnabled = true;
            this.cboAuditor.Location = new System.Drawing.Point(122, 13);
            this.cboAuditor.Name = "cboAuditor";
            this.cboAuditor.Size = new System.Drawing.Size(357, 21);
            this.cboAuditor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Auditor Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 426);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Form Type";
            this.label3.Visible = false;
            // 
            // cboForm
            // 
            this.cboForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboForm.FormattingEnabled = true;
            this.cboForm.Location = new System.Drawing.Point(118, 423);
            this.cboForm.Name = "cboForm";
            this.cboForm.Size = new System.Drawing.Size(100, 21);
            this.cboForm.TabIndex = 5;
            this.cboForm.Visible = false;
            this.cboForm.SelectedIndexChanged += new System.EventHandler(this.cboForm_SelectedIndexChanged);
            // 
            // cboYA
            // 
            this.cboYA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYA.FormattingEnabled = true;
            this.cboYA.Location = new System.Drawing.Point(379, 423);
            this.cboYA.Name = "cboYA";
            this.cboYA.Size = new System.Drawing.Size(100, 21);
            this.cboYA.TabIndex = 1;
            this.cboYA.Visible = false;
            this.cboYA.SelectedIndexChanged += new System.EventHandler(this.cboYA_SelectedIndexChanged);
            this.cboYA.DropDown += new System.EventHandler(this.cboYA_DropDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 426);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Year Assessment";
            this.label1.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.toolStripCboForm,
            this.toolStripLabel4,
            this.toolStripCboYA,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripCboBy,
            this.toolStripLabel2,
            this.toolStripTxtText});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(692, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(58, 22);
            this.toolStripLabel3.Text = "Form Type";
            // 
            // toolStripCboForm
            // 
            this.toolStripCboForm.Name = "toolStripCboForm";
            this.toolStripCboForm.Size = new System.Drawing.Size(75, 25);
            this.toolStripCboForm.SelectedIndexChanged += new System.EventHandler(this.toolStripCboForm_SelectedIndexChanged);
            this.toolStripCboForm.Click += new System.EventHandler(this.toolStripCboForm_Click);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(89, 22);
            this.toolStripLabel4.Text = "Year Assessment";
            // 
            // toolStripCboYA
            // 
            this.toolStripCboYA.Name = "toolStripCboYA";
            this.toolStripCboYA.Size = new System.Drawing.Size(80, 25);
            this.toolStripCboYA.SelectedIndexChanged += new System.EventHandler(this.toolStripCboYA_SelectedIndexChanged);
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
            // toolStripCboBy
            // 
            this.toolStripCboBy.Items.AddRange(new object[] {
            "Reference No",
            "Name",
            "-All Record-"});
            this.toolStripCboBy.Name = "toolStripCboBy";
            this.toolStripCboBy.Size = new System.Drawing.Size(121, 25);
            this.toolStripCboBy.SelectedIndexChanged += new System.EventHandler(this.toolStripCboBy_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(69, 22);
            this.toolStripLabel2.Text = "Search Text:";
            // 
            // toolStripTxtText
            // 
            this.toolStripTxtText.Name = "toolStripTxtText";
            this.toolStripTxtText.Size = new System.Drawing.Size(100, 25);
            this.toolStripTxtText.TextChanged += new System.EventHandler(this.toolStripTxtText_TextChanged);
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(122, 67);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(357, 20);
            this.txtPosition.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboTaxAgent);
            this.groupBox1.Controls.Add(this.txtPosition);
            this.groupBox1.Controls.Add(this.chkKeep);
            this.groupBox1.Controls.Add(this.lblPosition);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboAuditor);
            this.groupBox1.Location = new System.Drawing.Point(0, 320);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(692, 94);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Tax Agent Name";
            // 
            // cboTaxAgent
            // 
            this.cboTaxAgent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTaxAgent.FormattingEnabled = true;
            this.cboTaxAgent.Location = new System.Drawing.Point(122, 40);
            this.cboTaxAgent.Name = "cboTaxAgent";
            this.cboTaxAgent.Size = new System.Drawing.Size(357, 21);
            this.cboTaxAgent.TabIndex = 9;
            // 
            // frmEFileSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 448);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgTaxPayer);
            this.Controls.Add(this.cboYA);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cboForm);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmEFileSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Tax Payer";
            this.Load += new System.EventHandler(this.frmEFileSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTaxPayer)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTaxPayer;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboYA;
        private System.Windows.Forms.ComboBox cboAuditor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkKeep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboForm;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripCboBy;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox toolStripTxtText;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox toolStripCboForm;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripComboBox toolStripCboYA;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTaxAgent;
    }
}
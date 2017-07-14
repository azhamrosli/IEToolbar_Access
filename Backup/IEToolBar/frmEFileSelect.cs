using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IEToolBar
{
    public partial class frmEFileSelect : Form
    {
        private ucToolBar ucParent;

        public frmEFileSelect(ucToolBar ucParent)
        {
            InitializeComponent();
            this.ucParent = ucParent;
        }

        private void frmEFileSelect_Load(object sender, EventArgs e)
        {
            //LoadData();
            //NGOHCS 2009
            cboAuditor.Enabled = false;
            cboTaxAgent.Enabled = false;
            txtPosition.Enabled = false;
            cboYA.Enabled = false;
            chkKeep.Enabled = false;
             string[] strArray = new string[8]; 
             EFilingPublic dsn = new EFilingPublic();
             if (dsn.isExist("TAXSYSTEM", DSNType.System_DSN))
             {
                 strArray[0] = "C";
                 strArray[1] = "R";
                 //PANYW CP204
                 strArray[2] = "CP204";
                 //PANYW CP204 END
                 //NGOHCS CP204A
                 strArray[3] = "CP204A";
                 //NGOHCS CP204A END
             }
             if (dsn.isExist("TAXCOM_B", DSNType.System_DSN))
             {
                 strArray[4] = "B";
                 strArray[5] = "BE";
                 strArray[6] = "M";
             }
             if (dsn.isExist("TAXCOM_P", DSNType.System_DSN))
             {
                 strArray[7] = "P";
             }
             foreach (string strTemp in strArray)
             {
                 if (!(strTemp == null))
                 {
                     cboForm.Items.Add(strTemp);
                     toolStripCboForm.Items.Add(strTemp);
                 }
             }
        }

        private void PopulateTaxPayer()
        {
           dgTaxPayer.DataSource = null;

           switch (cboForm.Text)
           {
               case "C":case "R":
                   EFilingDAL dal = new EFilingDAL();
                   //dgTaxPayer.DataSource = dal.GetTaxPayer(cboYA.Text);
                   if (toolStripCboBy.Text == "Reference No" && toolStripTxtText.Text != "")
                       dgTaxPayer.DataSource = dal.GetTaxPayer(cboYA.Text, toolStripTxtText.Text.ToString());
                   if (toolStripCboBy.Text == "Name" && toolStripTxtText.Text != "")
                       dgTaxPayer.DataSource = dal.GetTaxPayerName(cboYA.Text, toolStripTxtText.Text.ToString());
                   if (toolStripCboBy.Text == "-All Record-")
                       dgTaxPayer.DataSource = dal.GetTaxPayerAll(cboYA.Text, toolStripTxtText.Text.ToString());
                   break;
               case "B":case "BE":
                   EFilingDALB dalB = new EFilingDALB();
                   if (toolStripCboBy.Text == "Reference No" && toolStripTxtText.Text != "")
                       dgTaxPayer.DataSource = dalB.GetTaxPayerB(toolStripTxtText.Text.ToString());//dalB.GetTaxPayerB(cboYA.Text);
                   if (toolStripCboBy.Text == "Name" && toolStripTxtText.Text != "")
                       dgTaxPayer.DataSource = dalB.GetTaxPayerBName(toolStripTxtText.Text.ToString());
                   if (toolStripCboBy.Text == "-All Record-")
                       dgTaxPayer.DataSource = dalB.GetTaxPayerBAll(toolStripTxtText.Text.ToString());
                   break;
               case "M":
                   EFilingDALB dalM = new EFilingDALB();
                   //dgTaxPayer.DataSource = dalM.GetTaxPayerM(cboYA.Text);
                   if (toolStripCboBy.Text == "Reference No" && toolStripTxtText.Text != "")
                       dgTaxPayer.DataSource = dalM.GetTaxPayerM(toolStripTxtText.Text.ToString());//dalB.GetTaxPayerB(cboYA.Text);
                   if (toolStripCboBy.Text == "Name" && toolStripTxtText.Text != "")
                       dgTaxPayer.DataSource = dalM.GetTaxPayerMName(toolStripTxtText.Text.ToString());
                   if (toolStripCboBy.Text == "-All Record-")
                       dgTaxPayer.DataSource = dalM.GetTaxPayerMAll(toolStripTxtText.Text.ToString());
                   break;
               case "P":
                   EFilingDALP dalP = new EFilingDALP();
                   //dgTaxPayer.DataSource = dalP.GetTaxPayer();
                   if (toolStripCboBy.Text == "Reference No" && toolStripTxtText.Text != "")
                       dgTaxPayer.DataSource = dalP.GetTaxPayer(toolStripTxtText.Text.ToString());//dalB.GetTaxPayerB(cboYA.Text);
                   if (toolStripCboBy.Text == "Name" && toolStripTxtText.Text != "")
                       dgTaxPayer.DataSource = dalP.GetTaxPayerName(toolStripTxtText.Text.ToString());
                   if (toolStripCboBy.Text == "-All Record-")
                       dgTaxPayer.DataSource = dalP.GetTaxPayerAll(toolStripTxtText.Text.ToString());
                   break;
               //PANYW CP204
               case "CP204":
                   EFilingDALCP204 dalCP204 = new EFilingDALCP204();
                   if (toolStripCboBy.Text == "Reference No" && toolStripTxtText.Text != "")
                       dgTaxPayer.DataSource = dalCP204.GetCP204TaxPayer(cboYA.Text, toolStripTxtText.Text.ToString());
                   if (toolStripCboBy.Text == "Name" && toolStripTxtText.Text != "")
                       dgTaxPayer.DataSource = dalCP204.GetCP204TaxPayerName(cboYA.Text, toolStripTxtText.Text.ToString());
                   if (toolStripCboBy.Text == "-All Record-")
                       dgTaxPayer.DataSource = dalCP204.GetCP204TaxPayerAll(cboYA.Text, toolStripTxtText.Text.ToString());
                   break;
               //PANYW CP204
               case "CP204A":
                   EFilingDALCP204A dalCP204A = new EFilingDALCP204A();
                   if (toolStripCboBy.Text == "Reference No" && toolStripTxtText.Text != "")
                       dgTaxPayer.DataSource = dalCP204A.GetCP204ATaxPayer(cboYA.Text, toolStripTxtText.Text.ToString());
                   if (toolStripCboBy.Text == "Name" && toolStripTxtText.Text != "")
                       dgTaxPayer.DataSource = dalCP204A.GetCP204ATaxPayerName(cboYA.Text, toolStripTxtText.Text.ToString());
                   if (toolStripCboBy.Text == "-All Record-")
                       dgTaxPayer.DataSource = dalCP204A.GetCP204ATaxPayerAll(cboYA.Text, toolStripTxtText.Text.ToString());
                   break;
               default:
                   EFilingDAL dalC = new EFilingDAL();
                   //dgTaxPayer.DataSource = dalC.GetTaxPayer(cboYA.Text);
                   if (toolStripCboBy.Text == "Reference No" && toolStripTxtText.Text != "")
                       dgTaxPayer.DataSource = dalC.GetTaxPayer(cboYA.Text, toolStripTxtText.Text.ToString());
                   if (toolStripCboBy.Text == "Name" && toolStripTxtText.Text != "")
                       dgTaxPayer.DataSource = dalC.GetTaxPayerName(cboYA.Text, toolStripTxtText.Text.ToString());
                   if (toolStripCboBy.Text == "-All Record-")
                       dgTaxPayer.DataSource = dalC.GetTaxPayerAll(cboYA.Text, toolStripTxtText.Text.ToString());
                   break;
           }
        }

        private void LoadData()
        {
            DataTable dtData = new DataTable();
            cboAuditor.Items.Clear();
            cboTaxAgent.Items.Clear();

            switch (cboForm.Text)
            {
                case "C":
                    EFilingDAL dal = new EFilingDAL();
                    dtData = dal.GetAuditor();
                    foreach (DataRow drData in dtData.Rows)
                    {
                        cboAuditor.Items.Add(drData[0].ToString());
                    }
                    dtData = dal.GetTaxAgent();
                    foreach (DataRow drData in dtData.Rows)
                    {
                        cboTaxAgent.Items.Add(drData[0].ToString());
                    }
                    dtData = dal.GetYA();
                    break;
                case "R":
                    EFilingDAL dalR = new EFilingDAL();
                    dtData = dalR.GetAuditor();
                    foreach (DataRow drData in dtData.Rows)
                    {
                        cboAuditor.Items.Add(drData[0].ToString());
                    }
                    dtData = dalR.GetYA();
                    break;
                case "B":case "BE":case "M":
                    EFilingDALB dalB = new EFilingDALB();
                    dtData = dalB.GetTaxAgent();
                    foreach (DataRow drData in dtData.Rows)
                    {
                        cboTaxAgent.Items.Add(drData[0].ToString());
                    }
                    dtData = dalB.GetYA();
                    break;
                case "P":
                    EFilingDALB dalP = new EFilingDALB();
                    dtData = dalP.GetTaxAgent();
                    foreach (DataRow drData in dtData.Rows)
                    {
                        cboTaxAgent.Items.Add(drData[0].ToString());
                    }
                    dtData = dalP.GetYA();
                    break;
                //PANYW CP204
                case "CP204":
                    EFilingDALCP204 dalCP204 = new EFilingDALCP204(); 
                    dtData = dalCP204.GetTaxAgent();
                    foreach (DataRow drData in dtData.Rows)
                    {
                        cboTaxAgent.Items.Add(drData[0].ToString());
                    }
                    dtData = dalCP204.GetYA();
                    break;
                //PANYW CP204 END
                default:
                    EFilingDAL dalC = new EFilingDAL();
                    dtData = dalC.GetAuditor();
                    foreach (DataRow drData in dtData.Rows)
                    {
                        cboAuditor.Items.Add(drData[0].ToString());
                    }
                    dtData = dalC.GetTaxAgent();
                    foreach (DataRow drData in dtData.Rows)
                    {
                        cboTaxAgent.Items.Add(drData[0].ToString());
                    }
                    dtData = dalC.GetYA();
                    break;
            }
            if (cboTaxAgent.Items.Count > 0)
            {
                cboTaxAgent.SelectedIndex = 0;
            }
            cboYA.Items.Clear();
            foreach (DataRow drData in dtData.Rows)
            {
                cboYA.Items.Add(drData[0].ToString());
                toolStripCboYA.Items.Add(drData[0].ToString());
            }
            if (cboForm.Text == "C")
            {
                toolStripCboYA.Text = "2014";
                cboYA.Text = "2014";
            }
            else if (cboForm.Text == "R")
            {
                toolStripCboYA.Text = "2014";
                cboYA.Text = "2014";
            }
            else
            {
                toolStripCboYA.Text = "2014";
                cboYA.Text = "2014";
            }
            toolStripCboBy.Text = "Name";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (cboYA.Text.Length > 0)
            {
                if (cboForm.Text.Length > 0)
                {
                    switch (cboForm.Text)
                    {
                        case "C":case"R":
                            if (cboAuditor.Text.Length > 0 || cboForm.Text=="R")
                            {
                                if (dgTaxPayer.SelectedRows.Count > 0)
                                {
                                    ucParent.SelectedTaxPayer  = dgTaxPayer.SelectedRows[0].Cells[0].Value.ToString() + " (" + dgTaxPayer.SelectedRows[0].Cells[1].Value.ToString() + ")";
                                    ucParent.strTaxPayer = dgTaxPayer.SelectedRows[0].Cells[0].Value.ToString();
                                    ucParent.strYA = cboYA.Text;
                                    ucParent.strAuditor = cboAuditor.Text;
                                    ucParent.strTaxAgent = cboTaxAgent.Text;
                                    ucParent.strPosition = "";
                                    ucParent.strRecKept = chkKeep.Checked.ToString();
                                    ucParent.strFormType = cboForm.Text;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Please select a tax payer record!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please select auditor!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;
                        case "B":case "BE":case "M":
                            if (dgTaxPayer.SelectedRows.Count > 0)
                            {
                                ucParent.SelectedTaxPayer = dgTaxPayer.SelectedRows[0].Cells[0].Value.ToString() + " (" + dgTaxPayer.SelectedRows[0].Cells[1].Value.ToString() + ")";
                                ucParent.strTaxPayer = dgTaxPayer.SelectedRows[0].Cells[0].Value.ToString();
                                ucParent.strYA = cboYA.Text;
                                ucParent.strTaxAgent = cboTaxAgent.Text;
                                ucParent.strAuditor = "";
                                ucParent.strPosition = "";
                                ucParent.strRecKept = chkKeep.Checked.ToString();
                                ucParent.strFormType = cboForm.Text;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Please select a tax payer record!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;
                        case "P":
                            if (dgTaxPayer.SelectedRows.Count > 0)
                            {
                                ucParent.SelectedTaxPayer = dgTaxPayer.SelectedRows[0].Cells[0].Value.ToString() + " (" + dgTaxPayer.SelectedRows[0].Cells[1].Value.ToString() + ")";
                                ucParent.strTaxPayer = dgTaxPayer.SelectedRows[0].Cells[0].Value.ToString();
                                ucParent.strYA = cboYA.Text;
                                ucParent.strTaxAgent = cboTaxAgent.Text;
                                ucParent.strAuditor = "";
                                ucParent.strPosition = txtPosition.Text;
                                ucParent.strRecKept = chkKeep.Checked.ToString();
                                ucParent.strFormType = cboForm.Text;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Please select a tax payer record!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;
                        //PANYW CP204
                        case "CP204":
                            if (dgTaxPayer.SelectedRows.Count > 0)
                            {
                                ucParent.SelectedTaxPayer = dgTaxPayer.SelectedRows[0].Cells[0].Value.ToString() + " (" + dgTaxPayer.SelectedRows[0].Cells[1].Value.ToString() + ")";
                                ucParent.strTaxPayer = dgTaxPayer.SelectedRows[0].Cells[0].Value.ToString();
                                ucParent.strYA = cboYA.Text;
                                ucParent.strAuditor = "";
                                ucParent.strTaxAgent = cboTaxAgent.Text;
                                ucParent.strPosition = "";
                                ucParent.strRecKept = chkKeep.Checked.ToString();
                                ucParent.strFormType = cboForm.Text;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Please select a tax payer record!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;
                        //PANYW CP204 END
                        case "CP204A":
                            if (dgTaxPayer.SelectedRows.Count > 0)
                            {
                                ucParent.SelectedTaxPayer = dgTaxPayer.SelectedRows[0].Cells[0].Value.ToString() + " (" + dgTaxPayer.SelectedRows[0].Cells[1].Value.ToString() + ")";
                                ucParent.strTaxPayer = dgTaxPayer.SelectedRows[0].Cells[0].Value.ToString();
                                ucParent.strYA = cboYA.Text;
                                ucParent.strAuditor = "";
                                ucParent.strTaxAgent = cboTaxAgent.Text;
                                ucParent.strPosition = "";
                                ucParent.strRecKept = chkKeep.Checked.ToString();
                                ucParent.strFormType = cboForm.Text;
                                ucParent.strCP204AVersion = dgTaxPayer.SelectedRows[0].Cells[5].Value.ToString();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Please select a tax payer record!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Please select form type!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("Please select Year of Assessment!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboYA_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateTaxPayer();
        }

        private void dgTaxPayer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSelect_Click(sender, e);
        }

        private void cboForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboYA.Enabled = true;
    
            if (cboForm.Text == "C")
            {
                chkKeep.Enabled = true;
                txtPosition.Enabled = false;
                cboAuditor.Enabled = true;
                cboTaxAgent.Enabled = true;
            }
            else if (cboForm.Text == "R")
            {
                chkKeep.Enabled = false;
                txtPosition.Enabled = false;
                cboAuditor.Enabled = false;
                cboTaxAgent.Enabled = false;
            }
            else if (cboForm.Text == "BE")
            {
                chkKeep.Enabled = false;
                txtPosition.Enabled = false;
                cboAuditor.Enabled = false;
                cboTaxAgent.Enabled = true;
            }
            else if (cboForm.Text == "P")
            {
                chkKeep.Enabled = true;
                txtPosition.Enabled = true;
                cboAuditor.Enabled = false;
                cboTaxAgent.Enabled = true;
            }
            //PANYW CP204
            else if (cboForm.Text == "CP204")
            {
                chkKeep.Enabled = true;
                txtPosition.Enabled = false;
                cboAuditor.Enabled = false;
                cboTaxAgent.Enabled = true;
            }
            //PANYW CP204 END
            //NGOHCS CP204A
            else if (cboForm.Text == "CP204A")
            {
                chkKeep.Enabled = true;
                txtPosition.Enabled = false;
                cboAuditor.Enabled = false;
                cboTaxAgent.Enabled = true;
            }
            //NGOHCS CP204A END
            else
            {
                chkKeep.Enabled = true;
                txtPosition.Enabled = false;
                cboAuditor.Enabled = false;
                cboTaxAgent.Enabled = true;
            }
            //LoadData();
            if (cboYA.Text != "")
            {
                PopulateTaxPayer();
            }
            LoadData();
        }

        private void cboYA_DropDown(object sender, EventArgs e)
        {
           // LoadData();
        }

        private void toolStripCboForm_Click(object sender, EventArgs e)
        {
            //if (toolStripCboForm.Text != "")
            //    cboForm.Text = toolStripCboForm.Text;
        }

        private void toolStripCboForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripCboForm.Text != "")
                cboForm.Text = toolStripCboForm.Text;
        }

        private void toolStripCboYA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripCboYA.Text != "")
                cboYA.Text = toolStripCboYA.Text;
        }

        private void toolStripTxtText_TextChanged(object sender, EventArgs e)
        {
            PopulateTaxPayer();
        }

        private void toolStripCboBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripCboBy.Text == "-All Record-")
                toolStripTxtText.Text = "";
            PopulateTaxPayer();
        }

    }
}
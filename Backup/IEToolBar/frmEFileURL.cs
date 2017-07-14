using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace IEToolBar
{
    public partial class frmEFileURL : Form
    {
        String strFormType = "";

        public frmEFileURL(string strfrmType)
        {
            InitializeComponent();
            this.strFormType = strfrmType;
        }

        public frmEFileURL()
        {
            InitializeComponent();
            this.strFormType = "C";
        }

        private void frmEFileMain_Load(object sender, EventArgs e)
        {
            this.Text = "TAXcom E-Filing " + strFormType;
            //PopulateDG();
        }

        private void tsbtnAdd_Click(object sender, EventArgs e)
        {
            frmEFileAdd frmAdd = new frmEFileAdd(this , strFormType);
            frmAdd.Show();
        }

        private void LoadYA()
        {
            DataTable dtData = null;
            switch (strFormType)
            {
                case "C":case "R":
                    EFilingDAL dal = new EFilingDAL();
                    dtData = dal.GetYA();
                    break;
                case "B":case "BE":case "M":
                    EFilingDALB  dalB = new EFilingDALB();
                    dtData = dalB.GetYA();
                    break;
                case "P":
                    EFilingDALB dalP = new EFilingDALB();
                    dtData = dalP.GetYA();
                    break;
                //PANYW CP204
                case "CP204":
                    EFilingDALCP204 dalCP204 = new EFilingDALCP204();
                    dtData = dalCP204.GetYA();
                    break;
                //PANYW CP204 END
                //NGOHCS CP204A
                case "CP204A":
                    EFilingDALCP204A dalCP204A = new EFilingDALCP204A();
                    dtData = dalCP204A.GetYA();
                    break;
                //NGOHCS CP204A END
                default:
                    EFilingDAL dalC = new EFilingDAL();
                    dtData = dalC.GetYA();
                    break;
            }
            toolStripCboYA.Items.Clear();
            foreach (DataRow drData in dtData.Rows)
            {
                toolStripCboYA.Items.Add(drData[0].ToString());
            }
        }

        public void PopulateDG()
        {
            dgEFURL.DataSource = null;
            switch (strFormType)
            {
                case "C": case "R":
                    EFilingDAL dal = new EFilingDAL();
                    //PANYW CP204  **Due to CP204 
                    String[] strArrayCR = new string[2];
                    strArrayCR[0] = "C";
                    strArrayCR[1] = "R";
                    dgEFURL.DataSource = dal.LoadAllURL(strArrayCR, toolStripCboYA.Text);
                    //PANYW CP204 END
                    break;
                case "B":
                    EFilingDALB dalB = new EFilingDALB();
                    dgEFURL.DataSource = dalB.LoadAllURL("B", toolStripCboYA.Text);
                    break;
                case "BE":
                    EFilingDALB dalBE = new EFilingDALB();
                    dgEFURL.DataSource = dalBE.LoadAllURL("BE", toolStripCboYA.Text);
                    break;
                case "M":
                    EFilingDALB dalM = new EFilingDALB();
                    dgEFURL.DataSource = dalM.LoadAllURL("M", toolStripCboYA.Text);
                    break;
                case "P":
                    EFilingDALP dalP = new EFilingDALP();
                    dgEFURL.DataSource = dalP.LoadAllURL(toolStripCboYA.Text);
                    break;
                //PANYW CP204
                case "CP204":
                    String[] strArrayCP204 = new string[1];
                    strArrayCP204[0] = "CP204";
                    EFilingDALCP204 dalCP204 = new EFilingDALCP204();
                    dgEFURL.DataSource = dalCP204.LoadAllURL(strArrayCP204, toolStripCboYA.Text);
                    break;
                //PANYW CP204
                //NGOHCS CP204A
                case "CP204A":
                    String[] strArrayCP204A = new string[1];
                    strArrayCP204A[0] = "CP204A";
                    EFilingDALCP204A dalCP204A = new EFilingDALCP204A();
                    dgEFURL.DataSource = dalCP204A.LoadAllURL(strArrayCP204A, toolStripCboYA.Text);
                    break;
                //NGOHCS CP204A
                default:
                    EFilingDAL dalC = new EFilingDAL();
                    dgEFURL.DataSource = dalC.LoadAllURL(toolStripCboYA.Text);
                    break;
            }  
            dgEFURL.Refresh();
        }

        private void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if (dgEFURL.SelectedRows.Count > 0)
            {
                frmEFileAdd frmUpd = new frmEFileAdd(this, dgEFURL.SelectedRows[0].Cells[1].Value.ToString(), dgEFURL.SelectedRows[0].Cells[3].Value.ToString(), dgEFURL.SelectedRows[0].Cells[4].Value.ToString(), dgEFURL.SelectedRows[0].Cells[2].Value.ToString());
                frmUpd.Show();
            }
            else
            {
                MessageBox.Show("Please select a record to update!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            if (dgEFURL.SelectedRows.Count > 0)
            {
                DialogResult dialogResponse;
                dialogResponse=MessageBox.Show("Delete selected record?", "TAXcom E-Filing", MessageBoxButtons.YesNo , MessageBoxIcon.Question);
                if (dialogResponse == DialogResult.Yes)
                {
                    string[] strData = new string[1];
                    switch (strFormType)
                    {
                        case "C":case "R":
                            EFilingDAL dal = new EFilingDAL();
                            strData[0] = dgEFURL.SelectedRows[0].Cells[2].Value.ToString();
                            if (dal.Execute(strData, "DEL") > 0)
                            {
                                MessageBox.Show("URL deleted!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                PopulateDG();
                            }
                            else
                            {
                                MessageBox.Show("Deletes of URL failed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;
                        case "B":case "BE": case "M":
                            EFilingDALB dalB = new EFilingDALB();
                            strData[0] = dgEFURL.SelectedRows[0].Cells[2].Value.ToString();
                            if (dalB.Execute(strData, "DEL") > 0)
                            {
                                MessageBox.Show("URL deleted!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                PopulateDG();
                            }
                            else
                            {
                                MessageBox.Show("Deletes of URL failed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;
                        case "P":
                            EFilingDALP dalP = new EFilingDALP();
                            strData[0] = dgEFURL.SelectedRows[0].Cells[2].Value.ToString();
                            if (dalP.Execute(strData, "DEL") > 0)
                            {
                                MessageBox.Show("URL deleted!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                PopulateDG();
                            }
                            else
                            {
                                MessageBox.Show("Deletes of URL failed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;
                        //PANYW CP204
                        case "CP204":
                            EFilingDALCP204 dalCP204 = new EFilingDALCP204();
                            strData[0] = dgEFURL.SelectedRows[0].Cells[2].Value.ToString();
                            if (dalCP204.Execute(strData, "DEL") > 0)
                            {
                                MessageBox.Show("URL deleted!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                PopulateDG();
                            }
                            else
                            {
                                MessageBox.Show("Deletes of URL failed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;
                        //PANYW CP204 END
                        //NGOHCS CP204A
                        case "CP204A":
                            EFilingDALCP204A dalCP204A = new EFilingDALCP204A();
                            strData[0] = dgEFURL.SelectedRows[0].Cells[2].Value.ToString();
                            if (dalCP204A.Execute(strData, "DEL") > 0)
                            {
                                MessageBox.Show("URL deleted!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                PopulateDG();
                            }
                            else
                            {
                                MessageBox.Show("Deletes of URL failed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            break;
                        //NGOHCS CP204A END
                    }
                   
                }
            }
            else
            {
                MessageBox.Show("Please select a record to delete!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            PopulateDG();
        }

        private void dgEFURL_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbtnEdit_Click(sender, e);
        }

        private void toolStripCboYA_DropDown(object sender, EventArgs e)
        {
            LoadYA();  
        }

        private void toolStripCboYA_SelectedIndexChanged(object sender, EventArgs e)
        {
            EFilingVersionUpgrade dal = new EFilingVersionUpgrade(strFormType,toolStripCboYA.Text);
            dal.VersionUpgrade();
            PopulateDG();
        }

        private void tsbtnDeleteAll_Click(object sender, EventArgs e)
        {
            DialogResult dialogResponse;
            dialogResponse = MessageBox.Show("Delete all record?", "TAXcom E-Filing", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResponse == DialogResult.Yes)
            {
                string[] strData = new string[2];
                switch (strFormType)
                {
                    case "BE":
                    case "B":
                    case "M":
                        EFilingDALB dalB = new EFilingDALB();
                        strData[0] = toolStripCboYA.Text;
                        strData[1] = strFormType;
                        if (dalB.Execute(strData, "DELALL") > 0)
                        {
                            MessageBox.Show("URL deleted!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PopulateDG();
                        }
                        else
                        {
                            MessageBox.Show("Deletes of URL failed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                    case "C":
                    case "R":
                        EFilingDAL dal = new EFilingDAL();
                        strData[0] = toolStripCboYA.Text;
                        strData[1] = strFormType;
                        if (dal.Execute(strData, "DELALL") > 0)
                        {
                            MessageBox.Show("URL for Form C deleted!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PopulateDG();
                        }
                        if (dal.Execute(strData, "DELALLR") > 0)
                        {
                            MessageBox.Show("URL for Form R deleted!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PopulateDG();
                        }
                        else
                        {
                            MessageBox.Show("Deletes of URL failed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                    case "P":
                        EFilingDALP dalP = new EFilingDALP();
                        strData[0] = toolStripCboYA.Text;
                        strData[1] = strFormType;
                        if (dalP.Execute(strData, "DELALL") > 0)
                        {
                            MessageBox.Show("URL deleted!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PopulateDG();
                        }
                        else
                        {
                            MessageBox.Show("Deletes of URL failed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                    case "CP204":
                        EFilingDALCP204 dalCP204 = new EFilingDALCP204();
                        strData[0] = toolStripCboYA.Text;
                        strData[1] = strFormType;
                        if (dalCP204.Execute(strData, "DELALL") > 0)
                        {
                            MessageBox.Show("URL deleted!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PopulateDG();
                        }
                        else
                        {
                            MessageBox.Show("Deletes of URL failed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                    case "CP204A":
                        EFilingDALCP204A dalCP204A = new EFilingDALCP204A();
                        strData[0] = toolStripCboYA.Text;
                        strData[1] = strFormType;
                        if (dalCP204A.Execute(strData, "DELALL") > 0)
                        {
                            MessageBox.Show("URL deleted!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PopulateDG();
                        }
                        else
                        {
                            MessageBox.Show("Deletes of URL failed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                }
            }
        }

    }
}
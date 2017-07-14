using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IEToolBar
{
    public partial class frmEFileAdd : Form
    {
        private frmEFileURL frmParent;
        private string strIndex;
        private Boolean boolEditMode;

        public frmEFileAdd(frmEFileURL frmParent , string strType)
        {
            InitializeComponent();
            LoadYA(strType);
            LoadType(strType);
            cboForm.Text = strType;
            this.frmParent = frmParent;
            boolEditMode = false;
            this.Text = "Add new URL Dcoument";
        }

        public frmEFileAdd(frmEFileURL frmParent, string strURL, string strYA, string strType, string strIndex)
        {
            InitializeComponent();
            LoadYA(strType);
            LoadType(strType);
            this.frmParent = frmParent;
            this.strIndex = strIndex;
            cboForm.Text = strType;
            cboForm.Enabled = false;
            cboYA.Text  = strYA;
            cboYA.Enabled = false;
            txtURL.Text = strURL;
            boolEditMode = true;
            this.Text = "Edit URL Document";
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtURL.Text.Trim().Length > 0 && cboYA.Text.Trim().Length > 0 && cboForm.Text.Length>0)
            {
                switch (cboForm.Text)
                {
                    case "C":case "R":
                        EFilingDAL dal = new EFilingDAL();
                        if (dal.VerifyYA(cboYA.Text) == true)
                        {
                            int intStatus;
                            if (boolEditMode)
                            {
                                string[] strData = new string[2];
                                strData[0] = txtURL.Text.Trim().ToLower();
                                strData[1] = strIndex;
                                intStatus = dal.Execute(strData, "UPD");
                            }
                            else
                            {
                                if (dal.VerifyURL(txtURL.Text.Trim(), cboYA.Text, cboForm.Text) == false)
                                {
                                    int intCount = int.Parse(dal.GetRecCount(cboYA.Text, cboForm.Text)) + 1;
                                    string strPageIndex = cboForm.Text + cboYA.Text + "Page" + intCount.ToString();
                                    string[] strData = new string[4];
                                    strData[0] = txtURL.Text.Trim().ToLower();
                                    strData[1] = cboYA.Text;
                                    strData[2] = strPageIndex;
                                    strData[3] = cboForm.Text;
                                    intStatus = dal.Execute(strData, "ADD");
                                }
                                else
                                {
                                    MessageBox.Show("URL existed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                            }

                            if (intStatus > 0)
                            {
                                if (boolEditMode)
                                {
                                    MessageBox.Show("URL updated!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("URL added!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                frmParent.PopulateDG();
                                this.Close();
                            }
                            else
                            {
                                if (boolEditMode)
                                {
                                    MessageBox.Show("Updates of URL failed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    MessageBox.Show("Adding of URL failed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Year of Assessment!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                    //PANYW CP204
                    case "CP204":
                        EFilingDALCP204 dalCP204 = new EFilingDALCP204();
                        if (dalCP204.VerifyYA(cboYA.Text) == true)
                        {
                            int intStatus;
                            if (boolEditMode)
                            {
                                string[] strData = new string[2];
                                strData[0] = txtURL.Text.Trim().ToLower();
                                strData[1] = strIndex;
                                intStatus = dalCP204.Execute(strData, "UPD");
                            }
                            else
                            {
                                if (dalCP204.VerifyURL(txtURL.Text.Trim(), cboYA.Text, cboForm.Text) == false)
                                {
                                    int intCount = int.Parse(dalCP204.GetRecCount(cboYA.Text, cboForm.Text)) + 1;
                                    string strPageIndex = cboForm.Text + cboYA.Text + "Page" + intCount.ToString();
                                    string[] strData = new string[4];
                                    strData[0] = txtURL.Text.Trim().ToLower();
                                    strData[1] = cboYA.Text;
                                    strData[2] = strPageIndex;
                                    strData[3] = cboForm.Text;
                                    intStatus = dalCP204.Execute(strData, "ADD");
                                }
                                else
                                {
                                    MessageBox.Show("URL existed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                            }

                            if (intStatus > 0)
                            {
                                if (boolEditMode)
                                {
                                    MessageBox.Show("URL updated!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("URL added!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                frmParent.PopulateDG();
                                this.Close();
                            }
                            else
                            {
                                if (boolEditMode)
                                {
                                    MessageBox.Show("Updates of URL failed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    MessageBox.Show("Adding of URL failed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Year of Assessment!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                    //PANYW CP204 END
                    case "CP204A":
                        EFilingDALCP204A dalCP204A = new EFilingDALCP204A();
                        if (dalCP204A.VerifyYA(cboYA.Text) == true)
                        {
                            int intStatus;
                            if (boolEditMode)
                            {
                                string[] strData = new string[2];
                                strData[0] = txtURL.Text.Trim().ToLower();
                                strData[1] = strIndex;
                                intStatus = dalCP204A.Execute(strData, "UPD");
                            }
                            else
                            {
                                if (dalCP204A.VerifyURL(txtURL.Text.Trim(), cboYA.Text, cboForm.Text) == false)
                                {
                                    int intCount = int.Parse(dalCP204A.GetRecCount(cboYA.Text, cboForm.Text)) + 1;
                                    string strPageIndex = cboForm.Text + cboYA.Text + "Page" + intCount.ToString();
                                    string[] strData = new string[4];
                                    strData[0] = txtURL.Text.Trim().ToLower();
                                    strData[1] = cboYA.Text;
                                    strData[2] = strPageIndex;
                                    strData[3] = cboForm.Text;
                                    intStatus = dalCP204A.Execute(strData, "ADD");
                                }
                                else
                                {
                                    MessageBox.Show("URL existed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                            }

                            if (intStatus > 0)
                            {
                                if (boolEditMode)
                                {
                                    MessageBox.Show("URL updated!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("URL added!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                frmParent.PopulateDG();
                                this.Close();
                            }
                            else
                            {
                                if (boolEditMode)
                                {
                                    MessageBox.Show("Updates of URL failed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    MessageBox.Show("Adding of URL failed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Year of Assessment!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                    case "B":case "BE":case "M":
                        EFilingDALB dalB = new EFilingDALB();
                        if (dalB.VerifyYA(cboYA.Text) == true)
                        {
                            int intStatus;
                            if (boolEditMode)
                            {
                                string[] strData = new string[2];
                                strData[0] = txtURL.Text.Trim().ToLower();
                                strData[1] = strIndex;
                                intStatus = dalB.Execute(strData, "UPD");
                            }
                            else
                            {
                                if (dalB.VerifyURL(txtURL.Text.Trim(), cboYA.Text, cboForm.Text) == false)
                                {
                                    int intCount = int.Parse(dalB.GetRecCount(cboYA.Text, cboForm.Text)) + 1;
                                    string strPageIndex = cboForm.Text + cboYA.Text + "Page" + intCount.ToString();
                                    string[] strData = new string[4];
                                    strData[0] = txtURL.Text.Trim().ToLower();
                                    strData[1] = cboYA.Text;
                                    strData[2] = strPageIndex;
                                    strData[3] = cboForm.Text;
                                    intStatus = dalB.Execute(strData, "ADD");
                                }
                                else
                                {
                                    MessageBox.Show("URL existed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                            }

                            if (intStatus > 0)
                            {
                                if (boolEditMode)
                                {
                                    MessageBox.Show("URL updated!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("URL added!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                frmParent.PopulateDG();
                                this.Close();
                            }
                            else
                            {
                                if (boolEditMode)
                                {
                                    MessageBox.Show("Updates of URL failed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    MessageBox.Show("Adding of URL failed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Year of Assessment!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                    case "P":
                        EFilingDALP dalP = new EFilingDALP();
                        EFilingDALB dalB2 = new EFilingDALB();
                        if (dalB2.VerifyYA(cboYA.Text) == true)
                        {
                            int intStatus;
                            if (boolEditMode)
                            {
                                string[] strData = new string[2];
                                strData[0] = txtURL.Text.Trim().ToLower();
                                strData[1] = strIndex;
                                intStatus = dalP.Execute(strData, "UPD");
                            }
                            else
                            {
                                if (dalP.VerifyURL(txtURL.Text.Trim(), cboYA.Text, cboForm.Text) == false)
                                {
                                    int intCount = int.Parse(dalP.GetRecCount(cboYA.Text, cboForm.Text)) + 1;
                                    string strPageIndex = cboForm.Text + cboYA.Text + "Page" + intCount.ToString();
                                    string[] strData = new string[4];
                                    strData[0] = txtURL.Text.Trim().ToLower();
                                    strData[1] = cboYA.Text;
                                    strData[2] = strPageIndex;
                                    strData[3] = cboForm.Text;
                                    intStatus = dalP.Execute(strData, "ADD");
                                }
                                else
                                {
                                    MessageBox.Show("URL existed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                            }

                            if (intStatus > 0)
                            {
                                if (boolEditMode)
                                {
                                    MessageBox.Show("URL updated!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("URL added!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                frmParent.PopulateDG();
                                this.Close();
                            }
                            else
                            {
                                if (boolEditMode)
                                {
                                    MessageBox.Show("Updates of URL failed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    MessageBox.Show("Adding of URL failed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Year of Assessment!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please complete all the fields!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmEFileAdd_Load(object sender, EventArgs e)
        {
            txtURL.Focus();
        }

        private void LoadYA(string strType)
        {
            DataTable dtData = null;
            switch (strType)
            {
                case "C":case "R":
                    EFilingDAL dal = new EFilingDAL();
                    dtData = dal.GetYA();
                    break;
                case "B": case "BE": case "M":
                    EFilingDALB dalB = new EFilingDALB();
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
                case "CP204A":
                    EFilingDALCP204A dalCP204A = new EFilingDALCP204A();
                    dtData = dalCP204A.GetYA();
                    break;
                //PANYW CP204 END
                default:
                    EFilingDAL dalC = new EFilingDAL();
                    dtData = dalC.GetYA();
                    break;
            }      
            foreach (DataRow drData in dtData.Rows )
            {
                cboYA.Items.Add(drData[0].ToString());
            }
        }

        private void LoadType(string strType)
        {
            string[] strArray = new string[3];
            switch (strType)
            {
                case "C":case "R":
                    strArray[0] = "C";
                    strArray[1] = "R";
                    break;
                case "B":
                    strArray[0] = "B";
                    break;
                case "BE":
                    strArray[0] = "BE";
                    break;
                case "M":
                    strArray[0] = "M";
                    break;
                case "P":
                    strArray[0] = "P";
                    break;
                //PANYW CP204
                case "CP204":
                    strArray[0] = "CP204";
                    break;
                //PANYW CP204
                case "CP204A":
                    strArray[0] = "CP204A";
                    break;
                default:
                    strArray[0] = "C";
                    strArray[1] = "R";
                    break;
            }
            foreach (string strTemp in strArray)
            {
                if (!(strTemp == null))
                {
                    cboForm.Items.Add(strTemp);
                }
            }

        }
    }
}
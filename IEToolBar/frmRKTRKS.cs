using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IEToolBar
{
    public partial class frmRKTRKS : Form
    {
        private string strTaxPayer, strYA, strMode;
        private DataSet dsData;
        public frmRKTRKS(string strTaxPayer, string strYA)
        {
            InitializeComponent();
            this.strTaxPayer = strTaxPayer;
            this.strYA = strYA;
            switch(strYA)
            {
                case "2008":
                    GetData();
                    break;
                case "2009":
                    GetData2009();
                    break;
                case "2010":
                    GetData2010();
                    break;
            }
        }

        private void GetData()
        {
            EFilingDAL dal = new EFilingDAL(strTaxPayer,strYA,"","");
            dsData = dal.GetFormData("C2008Page20");
            dal.CloseConn();
            if (dsData.Tables["P20_RKT_RKS_MASTER"].Rows.Count > 0)
            {
                dgEFRKTRKS.DataSource = dsData.Tables["P20_RKT_RKS"];
                if (dsData.Tables["P20_RKT_RKS_MASTER"].Rows[0].ItemArray[0].ToString() == "1")
                {
                    strMode = "RKT";
                    this.Text = strMode;
                }
                else
                {
                    strMode = "RKS";
                    this.Text = strMode;
                }
            }
            else
            {
                strMode = "Unknown";
                this.Text = "No RKT/ RKS record found";
            }
        }

        private void GetData2009()
        {
            EFilingDALC2009 dal = new EFilingDALC2009(strTaxPayer, strYA, "","");
            dsData = dal.GetFormDataC2009("C2009Page19");
            dal.CloseConn();
            if (dsData.Tables["P20_RKT_RKS_MASTER"].Rows.Count > 0)
            {
                dgEFRKTRKS.DataSource = dsData.Tables["P20_RKT_RKS"];
                if (dsData.Tables["P20_RKT_RKS_MASTER"].Rows[0].ItemArray[0].ToString() == "1")
                {
                    strMode = "RKT";
                    this.Text = strMode;
                }
                else
                {
                    strMode = "RKS";
                    this.Text = strMode;
                }
            }
            else
            {
                strMode = "Unknown";
                this.Text = "No RKT/ RKS record found";
            }
        }

        private void GetData2010()
        {
            EFilingDALC2010 dal = new EFilingDALC2010(strTaxPayer, strYA, "", "");
            dsData = dal.GetFormDataC2010("C2010Page19");
            dal.CloseConn();
            if (dsData.Tables["P20_RKT_RKS_MASTER"].Rows.Count > 0)
            {
                dgEFRKTRKS.DataSource = dsData.Tables["P20_RKT_RKS"];
                if (dsData.Tables["P20_RKT_RKS_MASTER"].Rows[0].ItemArray[0].ToString() == "1")
                {
                    strMode = "RKT";
                    this.Text = strMode;
                }
                else
                {
                    strMode = "RKS";
                    this.Text = strMode;
                }
            }
            else
            {
                strMode = "Unknown";
                this.Text = "No RKT/ RKS record found";
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            switch (strYA)
            {
                case "2008":
                    GetData();
                    break;
                case "2009":
                    GetData2009();
                    break;
                case "2010":
                    GetData2010();
                    break;
            }
        }

        private void tsbtnFill_Click(object sender, EventArgs e)
        {
            if (strMode != "Unknown")
            {
                SHDocVw.ShellWindows swTemp = new SHDocVw.ShellWindows();
                Boolean boolTargetFound = false;
                Boolean boolTargetReady = false;
                EFilingDAL dal = new EFilingDAL();

                try
                {
                    foreach (SHDocVw.InternetExplorer ieTemp in swTemp)
                    {
                        string strDocName = dal.GetDocName(ieTemp.LocationURL.ToString().ToLower(), strYA);
                        if (strDocName.Length > 0)
                        {
                            boolTargetFound = true;
                            if (ieTemp.ReadyState.Equals(SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE))
                            {
                                boolTargetReady = true;
                                if (typeof(mshtml.HTMLDocumentClass).IsAssignableFrom(ieTemp.Document.GetType()))
                                {
                                    mshtml.HTMLDocument htmlDoc = ieTemp.Document as mshtml.HTMLDocument;
                                    ProcessDocument(htmlDoc);
                                }
                            }
                        }
                    }
                    if (boolTargetFound == false)
                        MessageBox.Show("No relevant document is found for E-Filling!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else if (boolTargetFound == true && boolTargetReady == false)
                        MessageBox.Show("Document is not ready, please try again!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.ToString()); }
            }
        }

        private void ProcessDocument(mshtml.HTMLDocument htmlDoc)
        {
            Boolean boolFilled = false;
            int intIndex;
            DateTime dtTemp1 = DateTime.Parse(dgEFRKTRKS.SelectedRows[0].Cells[2].Value.ToString());
            DateTime dtTemp2 = DateTime.Parse(dgEFRKTRKS.SelectedRows[0].Cells[3].Value.ToString());
            DateTime dtTemp3 = DateTime.Parse(dsData.Tables["P20_RKT_RKS_ACCPERIOD"].Rows[0].ItemArray[0].ToString());
            DateTime dtTemp4 = DateTime.Parse(dsData.Tables["P20_RKT_RKS_ACCPERIOD"].Rows[0].ItemArray[1].ToString());
            string[] strData = new string[7];
            strData[0] = dgEFRKTRKS.SelectedRows[0].Cells[0].Value.ToString();
            strData[1] = dgEFRKTRKS.SelectedRows[0].Cells[1].Value.ToString();
            strData[2] = dtTemp1.ToString("dd/MM/yyyy");
            strData[3] = dtTemp2.ToString("dd/MM/yyyy");
            strData[4] = dgEFRKTRKS.SelectedRows[0].Cells[4].Value.ToString();
            strData[5] = dtTemp3.ToString("dd/MM/yyyy");
            strData[6] = dtTemp4.ToString("dd/MM/yyyy");

            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
            {
                switch (inpElement1.name)
                {
                    case "txtMula_Asas":
                        inpElement1.value = strData[5];
                        break;
                    case "txtTutup_Asas":
                        inpElement1.value = strData[6];
                        break;
                    case "GridView1$ctl01$txtEmpty_No_Rujukan2":
                        inpElement1.value = strData[0];
                        boolFilled = true;
                        break;
                    case "GridView1$ctl01$txtEmpty_Nama_Sykt2":
                        inpElement1.value = strData[1];
                        break;
                    case "GridView1$ctl01$txtEmpty_Mula_Asas2":
                        inpElement1.value = strData[2];
                        break;
                    case "GridView1$ctl01$txtEmpty_Tutup_Asas2":
                        inpElement1.value = strData[3];
                        break;
                    case "GridView1$ctl01$txtEmpty_Amaun_Diserah2":
                        inpElement1.value = strData[4].Replace(",","");
                        break;
                    case "GridView1$ctl01$Button1":
                        inpElement1.click();
                        break;
                }
            }

            for (intIndex = 3; intIndex < 20; intIndex++)
            {
                if (boolFilled == true)
                { break; }
                else
                {
                    string strRefno = "GridView1$ctl" + intIndex.ToString("0#") + "$txtNoRujukan2_Add";
                    string strCompanyName = "GridView1$ctl" + intIndex.ToString("0#") + "$txtNama_Sykt2_Add";
                    string strPeriodFrom = "GridView1$ctl" + intIndex.ToString("0#") + "$txtMula_Asas2_Add";
                    string strPeriodTo = "GridView1$ctl" + intIndex.ToString("0#") + "$txtTutup_Asas2_Add";
                    string strAmount = "GridView1$ctl" + intIndex.ToString("0#") + "$txtAmaun_Diserah2_Add";

                    foreach (mshtml.HTMLInputElement inpElement2 in htmlDoc.getElementsByTagName("input"))
                    {
                        if (inpElement2.name.ToString() == strRefno)
                        {
                            inpElement2.value = strData[0];
                            boolFilled = true;
                        }
                        else if (inpElement2.name.ToString() == strCompanyName)
                        {
                            inpElement2.value = strData[1];
                        }
                        else if (inpElement2.name.ToString() == strPeriodFrom)
                        {
                            inpElement2.value = strData[2];
                        }
                        else if (inpElement2.name.ToString() == strPeriodTo)
                        {
                            inpElement2.value = strData[3];
                        }
                        else if (inpElement2.name.ToString() == strAmount)
                        {
                            inpElement2.value = strData[4].Replace(",", "");
                        }
                    }
                }
            }

            if (boolFilled == true)
            {
                intIndex = intIndex - 1;
                string strLnkAdd = "GridView1_ctl" + intIndex.ToString("0#") + "_btnAdd";
                foreach (mshtml.HTMLAnchorElement ancElement in htmlDoc.getElementsByTagName("a"))
                {
                    if (ancElement.id != null)
                    {
                        if (ancElement.id.ToString() == strLnkAdd)
                        {
                            ancElement.click();
                        }
                    }
                }
            }
        }

        private void dgEFRKTRKS_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbtnFill_Click(sender, e);
        }

    }
}
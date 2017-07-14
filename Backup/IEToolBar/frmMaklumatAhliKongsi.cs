using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IEToolBar
{
    public partial class frmMaklumatAhliKongsi : Form
    {
        private string strTaxPayer, strYA, strFormType;
        private DataSet dsData;

        public frmMaklumatAhliKongsi(string strTaxPayer, string strYA, string strFormType)
        {
            InitializeComponent();
            this.strTaxPayer = strTaxPayer;
            this.strYA = strYA;
            this.strFormType = strFormType;
            GetData();
        }

        private void GetData2008()
        {
            EFilingDALP dalP = new EFilingDALP(strTaxPayer, strYA,"");
            if (strFormType == "P")
            {
                dsData = dalP.GetFormDataP("P2008Page7");
            }
            dalP.CloseConn();
            if (dsData.Tables["P6_TAXP_PARTNERS"].Rows.Count > 0)
            {
                dgEFMAK.DataSource = dsData.Tables["P6_TAXP_PARTNERS"];
            }
            else
            {
                this.Text = "No Maklumat Ahli Kongsi record found";
            }
        }

        private void GetData2009()
        {
            EFilingDALP2009 dalP = new EFilingDALP2009(strTaxPayer, strYA, "");
            if (strFormType == "P")
            {
                dsData = dalP.GetFormDataP2009("P2009Page7");
            }
            dalP.CloseConn();
            if (dsData.Tables["P6_TAXP_PARTNERS"].Rows.Count > 0)
            {
                dgEFMAK.DataSource = dsData.Tables["P6_TAXP_PARTNERS"];
            }
            else
            {
                this.Text = "No Maklumat Ahli Kongsi record found";
            }
        }

        private void GetData2010()
        {
            EFilingDALP2010 dalP = new EFilingDALP2010(strTaxPayer, strYA, "");
            if (strFormType == "P")
            {
                dsData = dalP.GetFormDataP2010("P2010Page7");
            }
            dalP.CloseConn();
            if (dsData.Tables["P6_TAXP_PARTNERS"].Rows.Count > 0)
            {
                dgEFMAK.DataSource = dsData.Tables["P6_TAXP_PARTNERS"];
            }
            else
            {
                this.Text = "No Maklumat Ahli Kongsi record found";
            }
        }

        private void GetData2011()
        {
            //LEESH FEB 2012
            EFilingDALP2011 dalP = new EFilingDALP2011(strTaxPayer, strYA, "");
            if (strFormType == "P")
            {
                dsData = dalP.GetFormDataP2011("P2011Page7");
            }
            dalP.CloseConn();
            if (dsData.Tables["P6_TAXP_PARTNERS"].Rows.Count > 0)
            {
                dgEFMAK.DataSource = dsData.Tables["P6_TAXP_PARTNERS"];
            }
            else
            {
                this.Text = "No Maklumat Ahli Kongsi record found";
            }
            //LEESH END
        }

        private void GetData2012()
        {
            //LEESH FEB 2012
            EFilingDALP2012 dalP = new EFilingDALP2012(strTaxPayer, strYA, "");
            if (strFormType == "P")
            {
                dsData = dalP.GetFormDataP2012("P2012Page7");
            }
            dalP.CloseConn();
            if (dsData.Tables["P6_TAXP_PARTNERS"].Rows.Count > 0)
            {
                dgEFMAK.DataSource = dsData.Tables["P6_TAXP_PARTNERS"];
            }
            else
            {
                this.Text = "No Maklumat Ahli Kongsi record found";
            }
            //LEESH END
        }

        private void GetData2013()
        {
            //LEESH FEB 2012
            EFilingDALP2013 dalP = new EFilingDALP2013(strTaxPayer, strYA, "");
            if (strFormType == "P")
            {
                dsData = dalP.GetFormDataP2013("P2013Page7");
            }
            dalP.CloseConn();
            if (dsData.Tables["P6_TAXP_PARTNERS"].Rows.Count > 0)
            {
                dgEFMAK.DataSource = dsData.Tables["P6_TAXP_PARTNERS"];
            }
            else
            {
                this.Text = "No Maklumat Ahli Kongsi record found";
            }
            //LEESH END
        }

        private void GetData2014()
        {
            //LEESH FEB 2012
            EFilingDALP2014 dalP = new EFilingDALP2014(strTaxPayer, strYA, "");
            if (strFormType == "P")
            {
                dsData = dalP.GetFormDataP2014("P2014Page7");
            }
            dalP.CloseConn();
            if (dsData.Tables["P6_TAXP_PARTNERS"].Rows.Count > 0)
            {
                dgEFMAK.DataSource = dsData.Tables["P6_TAXP_PARTNERS"];
            }
            else
            {
                this.Text = "No Maklumat Ahli Kongsi record found";
            }
            //LEESH END
        }

        private void GetData()
        {
            switch (this.strYA)
            {
                case "2009":
                    GetData2009();
                    break;
                case "2008":
                    GetData2008();
                    break;
                case "2010":
                    GetData2010(); //weihong
                    break;
                case "2011":
                    GetData2011();
                    break;
                case "2012":
                    GetData2012();
                    break;
                case "2013":
                    GetData2013();
                    break;
                case "2014":
                    GetData2014();
                    break;
            }
        }

        private void ProcessDocument(mshtml.HTMLDocument htmlDoc)
        {
            Boolean boolFilled = false;
            int intIndex =0;
            string[] strData = new string[11];
            if (!String.IsNullOrEmpty(dgEFMAK.SelectedRows[0].Cells[5].Value.ToString()))
                strData[0] = DateTime.Parse(dgEFMAK.SelectedRows[0].Cells[5].Value.ToString()).ToString("dd/MM/yyyy");//tarik masuk
            if (!String.IsNullOrEmpty(dgEFMAK.SelectedRows[0].Cells[6].Value.ToString()))
                strData[1] = DateTime.Parse(dgEFMAK.SelectedRows[0].Cells[6].Value.ToString()).ToString("dd/MM/yyyy");//tarik keluar
            strData[2] = dgEFMAK.SelectedRows[0].Cells[0].Value.ToString();//PREFIX
            strData[3] = dgEFMAK.SelectedRows[0].Cells[1].Value.ToString();//REF
            strData[4] = dgEFMAK.SelectedRows[0].Cells[2].Value.ToString();//NAME
            strData[5] = dgEFMAK.SelectedRows[0].Cells[3].Value.ToString();//IC
            strData[6] = dgEFMAK.SelectedRows[0].Cells[4].Value.ToString();//COUNTRY
            strData[7] = dgEFMAK.SelectedRows[0].Cells[7].Value.ToString();//share
            strData[8] = dgEFMAK.SelectedRows[0].Cells[8].Value.ToString();//b1
            strData[9] = dgEFMAK.SelectedRows[0].Cells[9].Value.ToString();//b2
            strData[10] = dgEFMAK.SelectedRows[0].Cells[10].Value.ToString();//b3


            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
            {
                switch (inpElement1.name)
                {
                    case "ctl00_ContentPlaceHolder2_GridView1_ctl02_Nama":
                        inpElement1.value = strData[4].ToString().ToUpper();
                        break;
                }
            }

            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
            {
                switch (inpElement1.name)
                {
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlEmpty_Negara":
                        inpElement1.value = strData[6];
                        //MessageBox.Show("input1");
                        boolFilled = true;
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_No_kp":
                        inpElement1.value = strData[5];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_No_rujukan":
                        inpElement1.value = strData[3];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlJ_Fail":
                        inpElement1.value = strData[2];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_tarikh_masuk":
                        inpElement1.value = strData[0];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_tarikh_keluar":
                        inpElement1.value = strData[1];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_bhgn_ahli":
                        inpElement1.value = strData[7];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_manfaat1":
                        inpElement1.value = strData[8];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_manfaat2":
                        inpElement1.value = strData[9];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_manfaat3":
                        inpElement1.value = strData[10];
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$Button1":
                        inpElement1.click();
                        break;
                    
                }
            }

                     // ctl00$ContentPlaceHolder2$GridView1$ctl03$txtNama_Add
             for (intIndex = 3; intIndex < 20; intIndex++)
            {
                if (boolFilled == true)
                { break; }
                else
                {
                    string strPrefix = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$ddlJenis_Fail_Add";
                    string strRef = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNoRujukan2_Add";
                    string strName = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNama_Add";
                    string strIC = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNoPengenalan_Add";
                    string strCountry = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNegara_Add";
                    string strDateIn = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtTkhMasuk_Add";
                    string strDateOut = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtTkhKeluar_Add";
                    string strShare = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtBhg_Ahli_Add";
                    string strB1 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat1_Add";
                    string strB2 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat2_Add";
                    string strB3 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat3_Add";

                    //string strNetDiv = "GridView1$ctl" + intIndex.ToString("0#") + "$txtdiv_bersih_Add";

                    foreach (mshtml.HTMLInputElement inpElement2 in htmlDoc.getElementsByTagName("input"))
                    {
                       
                        if (inpElement2.name.ToString() == strRef)
                        {
                            inpElement2.value = strData[3].ToString().ToUpper();
                            boolFilled = true;
                        }
                        
                        else if (inpElement2.name.ToString() == strIC)
                        {
                            inpElement2.value = strData[5];
                            boolFilled = true;
                        }
                        
                        else if (inpElement2.name.ToString() == strDateIn)
                        {
                            inpElement2.value = strData[0];
                            boolFilled = true;
                        }
                        else if (inpElement2.name.ToString() == strDateOut)
                        {
                            inpElement2.value = strData[1];
                            boolFilled = true;
                        }
                        else if (inpElement2.name.ToString() == strShare)
                        {
                            inpElement2.value = strData[7];
                            boolFilled = true;
                        }
                    }


                    foreach (mshtml.HTMLInputElement inpElement2 in htmlDoc.getElementsByTagName("textarea"))
                    {
                        if (inpElement2.name.ToString() == strName)
                        {
                            //inpElement2.value = strData[2];
                            inpElement2.value = strData[4].ToString().ToUpper();
                            boolFilled = true;
                        }
                    }


                    foreach (mshtml.HTMLSelectElement selElement in htmlDoc.getElementsByTagName("select"))
                    {

                        if (selElement.name.ToString() == strCountry)
                        {
                            selElement.value = strData[6];
                            boolFilled = true;
                        }

                        else if (selElement.name.ToString() == strPrefix)
                        {
                            selElement.value = strData[2];
                            boolFilled = true;
                        }
                        else if (selElement.name.ToString() == strB1)
                        {
                            selElement.value = strData[8];
                            boolFilled = true;
                        }

                        else if (selElement.name.ToString() == strB2)
                        {
                            if (strData[9] == "1")
                            {
                                selElement.value = "2";
                                boolFilled = true;
                            }
                            else
                            {
                                selElement.value = "";
                                boolFilled = true;
                            }
                        }

                        else if (selElement.name.ToString() == strB3)
                        {
                            if (strData[10] == "1")
                            {
                                selElement.value = "3";
                                boolFilled = true;
                            }
                            else
                            {
                                selElement.value = "";
                                boolFilled = true;
                            }
                        }
                    }


                }
            }

             if (boolFilled == true)
            {
                
                intIndex = intIndex - 1;
                string strLnkAdd = "ctl00_ContentPlaceHolder2_GridView1_ctl" + intIndex.ToString("0#") + "_btnTambahFooter";
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

        //private void tsbtnFill_Click(object sender, EventArgs e)
        //{
        //    SHDocVw.ShellWindows swTemp = new SHDocVw.ShellWindows();
        //    Boolean boolTargetFound = false;
        //    Boolean boolTargetReady = false;
        //    EFilingDALP dalP = new EFilingDALP();

        //    try
        //    {
        //        foreach (SHDocVw.InternetExplorer ieTemp in swTemp)
        //        {
        //            string strDocName = dalP.GetDocName(ieTemp.LocationURL.ToString().ToLower(), strYA);
        //            if (strDocName.Length > 0)
        //            {
        //                boolTargetFound = true;
        //                if (ieTemp.ReadyState.Equals(SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE))
        //                {
        //                    boolTargetReady = true;
        //                    if (typeof(mshtml.HTMLDocumentClass).IsAssignableFrom(ieTemp.Document.GetType()))
        //                    {
        //                        mshtml.HTMLDocument htmlDoc = ieTemp.Document as mshtml.HTMLDocument;
        //                        ProcessDocument(htmlDoc);
        //                    }
        //                }
        //            }
        //        }
        //        if (boolTargetFound == false)
        //            MessageBox.Show("No relevant document is found for E-Filling!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        else if (boolTargetFound == true && boolTargetReady == false)
        //            MessageBox.Show("Document is not ready, please try again!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //    catch (Exception ex)
        //    { MessageBox.Show(ex.ToString()); }
        //}

        //private void toolStripButton1_Click(object sender, EventArgs e)
        //{
        //    GetData();
        //}

        //private void dgEFMAK_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    tsbtnFill_Click(sender, e);
        //}
       
        private void tsbtnFill_Click(object sender, EventArgs e)
        {
            SHDocVw.ShellWindows swTemp = new SHDocVw.ShellWindows();
            Boolean boolTargetFound = false;
            Boolean boolTargetReady = false;
            EFilingDALP dalP = new EFilingDALP();
            string[] strData = new string[17];

            try
            {
                if (dgEFMAK.SelectedRows.Count > 0)
                {
                    if (!String.IsNullOrEmpty(dgEFMAK.SelectedRows[0].Cells[5].Value.ToString()))
                    {
                        strData[0] = DateTime.Parse(dgEFMAK.SelectedRows[0].Cells[5].Value.ToString()).ToString("dd/MM/yyyy");//tarik masuk
                    }
                    else
                    {
                        strData[0] = "";
                    }
                    if (!String.IsNullOrEmpty(dgEFMAK.SelectedRows[0].Cells[6].Value.ToString()))
                    {
                        strData[1] = DateTime.Parse(dgEFMAK.SelectedRows[0].Cells[6].Value.ToString()).ToString("dd/MM/yyyy");//tarik keluar
                    }
                    else
                    {
                        strData[1] = "";
                    }
                    strData[2] = dgEFMAK.SelectedRows[0].Cells[0].Value.ToString();//PREFIX
                    strData[3] = dgEFMAK.SelectedRows[0].Cells[1].Value.ToString();//REF
                    strData[4] = dgEFMAK.SelectedRows[0].Cells[2].Value.ToString();//NAME
                    strData[5] = dgEFMAK.SelectedRows[0].Cells[3].Value.ToString();//IC
                    strData[6] = dgEFMAK.SelectedRows[0].Cells[4].Value.ToString();//COUNTRY
                    strData[7] = dgEFMAK.SelectedRows[0].Cells[7].Value.ToString();//share
                    strData[8] = dgEFMAK.SelectedRows[0].Cells[8].Value.ToString();//b1
                    strData[9] = dgEFMAK.SelectedRows[0].Cells[9].Value.ToString();//b2
                    strData[10] = dgEFMAK.SelectedRows[0].Cells[10].Value.ToString();//b3
                    strData[11] = dgEFMAK.SelectedRows[0].Cells[11].Value.ToString();//ADJUTED INCOME
                    strData[12] = dgEFMAK.SelectedRows[0].Cells[12].Value.ToString();//BALANCING CHARGE
                    strData[13] = dgEFMAK.SelectedRows[0].Cells[13].Value.ToString();//BALANCING ALLOWANCE
                    strData[14] = dgEFMAK.SelectedRows[0].Cells[14].Value.ToString();//schedule 4
                    strData[15] = dgEFMAK.SelectedRows[0].Cells[15].Value.ToString();//export allowance
                    strData[16] = dsData.Tables["P6_TAXP_PREPARTNER"].Rows[0].ItemArray[0].ToString();
                }
                else
                {
                    MessageBox.Show("No record found for E-Filling!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                foreach (SHDocVw.InternetExplorer ieTemp in swTemp)
                {
                    string strDocName = dalP.GetDocName(ieTemp.LocationURL.ToString().ToLower(), strYA);
                    if (strDocName.Length > 0)
                    {
                        boolTargetFound = true;
                        if (ieTemp.ReadyState.Equals(SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE))
                        {
                            boolTargetReady = true;
                            if (typeof(mshtml.HTMLDocumentClass).IsAssignableFrom(ieTemp.Document.GetType()))
                            {
                                mshtml.HTMLDocument htmlDoc = ieTemp.Document as mshtml.HTMLDocument;
                                EFilingProcessMaklumatAhliKongsi dalMAK = new EFilingProcessMaklumatAhliKongsi(strData, this.strYA);
                                dalMAK.ProcessDocument(htmlDoc);
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

        private void dgEFMAK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbtnFill_Click(sender, e);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }

    }
}
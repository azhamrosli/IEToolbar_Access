using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IEToolBar
{
    public partial class frmHK6 : Form
    {
        private string strTaxPayer, strYA, strFormType;
        private DataSet dsData;
        private string strFrom;

        public frmHK6(string strTaxPayer, string strYA, string strFormType, string strFrom)
        {
            InitializeComponent();
            this.strTaxPayer = strTaxPayer;
            this.strYA = strYA;
            this.strFormType = strFormType;
            this.strFrom = strFrom;
            ////lyeyc
            //if (strFrom == "SPOUSE")
            //{
            //    this.Text = "HK-3 (SPOUSE)";
            //}
            GetData();
            //lyeyc (end)
        }

        private void GetData2015()
        {
            EFilingDALBE2015 dalBE = new EFilingDALBE2015(strTaxPayer, strYA, "");
            EFilingDALB2015 dalB = new EFilingDALB2015(strTaxPayer, strYA, "");
            EFilingDALM2015 dalM = new EFilingDALM2015(strTaxPayer, strYA, "");
            if (strFormType == "B")
            {
                dsData = dalB.GetFormDataB2015("B2015Page4");
            }
            else if (strFormType == "BE")
            {
                dsData = dalBE.GetFormDataBE2015("BE2015Page4");
             
            }
            else if (strFormType == "M")
            {
                //lyeyc
                if (strFrom == "SELF")
                {
                    dsData = dalM.GetFormDataM2015("M2015Page11");
                }
                else
                {
                    dsData = dalM.GetFormDataM2015("M2015Page12");
                }
                //lyeyc (end)
            }

            dalBE.CloseConn();

            if (strFormType == "B" || strFormType == "BE")
            {
                if (strFrom == "SELF")
                {
                    if (dsData == null || dsData.Tables.Count == 0) {
                    }
                    if (dsData.Tables["P12_HK6_MASTER"].Rows.Count > 0)
                    {
                        dgEFHK6.DataSource = dsData.Tables["P12_HK6_MASTER"];
                    }
                    else
                    {
                        this.Text = "No HK-3 record found";
                    }
                }
                else
                {
                    if (dsData.Tables["P12_HK6HW_MASTER"].Rows.Count > 0)
                    {
                        dgEFHK6.DataSource = dsData.Tables["P12_HK6HW_MASTER"];
                    }
                    else
                    {
                        this.Text = "No HK-3 record found";
                    }
                }
            }
            else if (strFormType == "M")
            {
                if (strFrom == "SELF")
                {
                    if (dsData.Tables["P11_HK6_MASTER"].Rows.Count > 0)
                    {
                        dgEFHK6.DataSource = dsData.Tables["P11_HK6_MASTER"];
                    }
                    else
                    {
                        this.Text = "No HK-3 record found";
                    }
                }
                else
                {
                    if (dsData.Tables["P12_HK6HW_MASTER"].Rows.Count > 0)
                    {
                        dgEFHK6.DataSource = dsData.Tables["P12_HK6HW_MASTER"];
                    }
                    else
                    {
                        this.Text = "No HK-3 record found";
                    }
                }
            }
        }
        private void GetData2014()
        {
            EFilingDALBE2014 dalBE = new EFilingDALBE2014(strTaxPayer, strYA, "");
            EFilingDALB2014 dalB = new EFilingDALB2014(strTaxPayer, strYA, "");
            EFilingDALM2014 dalM = new EFilingDALM2014(strTaxPayer, strYA, "");

            if (strFormType == "B")
            {
                dsData = dalB.GetFormDataB2014("B2014Page4");
            }
            else if (strFormType == "BE")
            {
                dsData = dalBE.GetFormDataBE2014("BE2014Page4");
            }
            else if (strFormType == "M")
            {
                //lyeyc
                if (strFrom == "SELF")
                {
                    dsData = dalM.GetFormDataM2014("M2014Page11");
                }
                else
                {
                    dsData = dalM.GetFormDataM2014("M2014Page12");
                }
                //lyeyc (end)
            }

            dalBE.CloseConn();

            if (strFormType == "B" || strFormType == "BE")
            {
                if (strFrom == "SELF")
                {
                    if (dsData.Tables["P12_HK6_MASTER"].Rows.Count > 0)
                    {
                        dgEFHK6.DataSource = dsData.Tables["P12_HK6_MASTER"];
                    }
                    else
                    {
                        this.Text = "No HK-3 record found";
                    }
                }
                else
                {
                    if (dsData.Tables["P12_HK6HW_MASTER"].Rows.Count > 0)
                    {
                        dgEFHK6.DataSource = dsData.Tables["P12_HK6HW_MASTER"];
                    }
                    else
                    {
                        this.Text = "No HK-3 record found";
                    }
                }
            }
            else if (strFormType == "M")
            {
                if (strFrom == "SELF")
                {
                    if (dsData.Tables["P11_HK6_MASTER"].Rows.Count > 0)
                    {
                        dgEFHK6.DataSource = dsData.Tables["P11_HK6_MASTER"];
                    }
                    else
                    {
                        this.Text = "No HK-3 record found";
                    }
                }
                else
                {
                    if (dsData.Tables["P12_HK6HW_MASTER"].Rows.Count > 0)
                    {
                        dgEFHK6.DataSource = dsData.Tables["P12_HK6HW_MASTER"];
                    }
                    else
                    {
                        this.Text = "No HK-3 record found";
                    }
                }
            }
        }

        private void GetData2013()
        {
            EFilingDALBE2013 dalBE = new EFilingDALBE2013(strTaxPayer, strYA, "");
            EFilingDALB2013 dalB = new EFilingDALB2013(strTaxPayer, strYA, "");
            EFilingDALM2013 dalM = new EFilingDALM2013(strTaxPayer, strYA, "");

            if (strFormType == "B")
            {
                dsData = dalB.GetFormDataB2013("B2013Page12");
            }
            else if (strFormType == "BE")
            {
                dsData = dalBE.GetFormDataBE2013("BE2013Page9");
            }
            else if (strFormType == "M")
            {
                //lyeyc
                if (strFrom == "SELF")
                {
                    dsData = dalM.GetFormDataM2013("M2013Page11");
                }
                else
                {
                    dsData = dalM.GetFormDataM2013("M2013Page12");
                }
                //lyeyc (end)
            }

            dalBE.CloseConn();

            if (strFormType == "B" || strFormType == "BE")
            {
                if (strFrom == "SELF")
                {
                    if (dsData.Tables["P12_HK6_MASTER"].Rows.Count > 0)
                    {
                        dgEFHK6.DataSource = dsData.Tables["P12_HK6_MASTER"];
                    }
                    else
                    {
                        this.Text = "No HK-3 record found";
                    }
                }
                else
                {
                    if (dsData.Tables["P12_HK6HW_MASTER"].Rows.Count > 0)
                    {
                        dgEFHK6.DataSource = dsData.Tables["P12_HK6HW_MASTER"];
                    }
                    else
                    {
                        this.Text = "No HK-3 record found";
                    }
                }
            }
            else if (strFormType == "M")
            {
                if (strFrom == "SELF")
                {
                    if (dsData.Tables["P11_HK6_MASTER"].Rows.Count > 0)
                    {
                        dgEFHK6.DataSource = dsData.Tables["P11_HK6_MASTER"];
                    }
                    else
                    {
                        this.Text = "No HK-3 record found";
                    }
                }
                else
                {
                    if (dsData.Tables["P12_HK6HW_MASTER"].Rows.Count > 0)
                    {
                        dgEFHK6.DataSource = dsData.Tables["P12_HK6HW_MASTER"];
                    }
                    else
                    {
                        this.Text = "No HK-3 record found";
                    }
                }
            }
        }

        private void GetData2012()
        {
            EFilingDALBE2012 dalBE = new EFilingDALBE2012(strTaxPayer, strYA, "");
            EFilingDALB2012 dalB = new EFilingDALB2012(strTaxPayer, strYA, "");
            EFilingDALM2012 dalM = new EFilingDALM2012(strTaxPayer, strYA, "");

            if (strFormType == "B")
            {
                dsData = dalB.GetFormDataB2012("B2012Page12");
            }
            else if (strFormType == "BE")
            {
                dsData = dalBE.GetFormDataBE2012("BE2012Page9");
            }
            else if (strFormType == "M")
            {
                //lyeyc
                if (strFrom == "SELF")
                {
                    dsData = dalM.GetFormDataM2012("M2012Page11");
                }
                else
                {
                    dsData = dalM.GetFormDataM2012("M2012Page12");
                }
                //lyeyc (end)
            }

            dalBE.CloseConn();

            if (strFormType == "B" || strFormType == "BE")
            {
                if (strFrom == "SELF")
                {
                    if (dsData.Tables["P12_HK6_MASTER"].Rows.Count > 0)
                    {
                        dgEFHK6.DataSource = dsData.Tables["P12_HK6_MASTER"];
                    }
                    else
                    {
                        this.Text = "No HK-3 record found";
                    }
                }
                else
                {
                    if (dsData.Tables["P12_HK6HW_MASTER"].Rows.Count > 0)
                    {
                        dgEFHK6.DataSource = dsData.Tables["P12_HK6HW_MASTER"];
                    }
                    else
                    {
                        this.Text = "No HK-3 record found";
                    }
                }
            }
            else if (strFormType == "M")
            {
                if (strFrom == "SELF")
                {
                    if (dsData.Tables["P11_HK6_MASTER"].Rows.Count > 0)
                    {
                        dgEFHK6.DataSource = dsData.Tables["P11_HK6_MASTER"];
                    }
                    else
                    {
                        this.Text = "No HK-3 record found";
                    }
                }
                else
                {
                    if (dsData.Tables["P12_HK6HW_MASTER"].Rows.Count > 0)
                    {
                        dgEFHK6.DataSource = dsData.Tables["P12_HK6HW_MASTER"];
                    }
                    else
                    {
                        this.Text = "No HK-3 record found";
                    }
                }
            }
        }

        private void GetData2011()
        {
            EFilingDALBE2011 dalBE = new EFilingDALBE2011(strTaxPayer, strYA, "");
            EFilingDALB2011 dalB = new EFilingDALB2011(strTaxPayer, strYA, "");
            EFilingDALM2011 dalM = new EFilingDALM2011(strTaxPayer, strYA, "");

            if (strFormType == "B")
            {
                dsData = dalB.GetFormDataB2011("B2011Page12");
            }
            else if (strFormType == "BE")
            {
                dsData = dalBE.GetFormDataBE2011("BE2011Page9");
            }
            else if (strFormType == "M")
            {
                //lyeyc
                if (strFrom == "SELF")
                {
                    dsData = dalM.GetFormDataM2011("M2011Page11");
                }
                else
                {
                    dsData = dalM.GetFormDataM2011("M2011Page12");
                }
                //lyeyc (end)
            }

            dalBE.CloseConn();

            if (strFormType == "B" || strFormType == "BE")
            {
                if (strFrom == "SELF")
                {
                    if (dsData.Tables["P12_HK6_MASTER"].Rows.Count > 0)
                    {
                        dgEFHK6.DataSource = dsData.Tables["P12_HK6_MASTER"];
                    }
                    else
                    {
                        this.Text = "No HK-3 record found";
                    }
                }
                else
                {
                    if (dsData.Tables["P12_HK6HW_MASTER"].Rows.Count > 0)
                    {
                        dgEFHK6.DataSource = dsData.Tables["P12_HK6HW_MASTER"];
                    }
                    else
                    {
                        this.Text = "No HK-3 record found";
                    }
                }
            }
            else if (strFormType == "M")
            {
                if (strFrom == "SELF")
                {
                    if (dsData.Tables["P11_HK6_MASTER"].Rows.Count > 0)
                    {
                        dgEFHK6.DataSource = dsData.Tables["P11_HK6_MASTER"];
                    }
                    else
                    {
                        this.Text = "No HK-3 record found";
                    }
                }
                else
                {
                    if (dsData.Tables["P12_HK6HW_MASTER"].Rows.Count > 0)
                    {
                        dgEFHK6.DataSource = dsData.Tables["P12_HK6HW_MASTER"];
                    }
                    else
                    {
                        this.Text = "No HK-3 record found";
                    }
                }
            }
        }

        private void GetData2010()
        {
            EFilingDALBE2010 dalBE = new EFilingDALBE2010(strTaxPayer, strYA, "");
            EFilingDALB2010 dalB = new EFilingDALB2010(strTaxPayer, strYA, "");
            EFilingDALM2010 dalM = new EFilingDALM2010(strTaxPayer, strYA, "");

            if (strFormType == "B")
            {
                dsData = dalB.GetFormDataB2010("B2010Page12");
            }
            else if (strFormType == "BE")
            {
                dsData = dalBE.GetFormDataBE2010("BE2010Page9");
            }
            else if (strFormType == "M")
            {
                dsData = dalM.GetFormDataM2010("M2010Page11");
            }

            dalBE.CloseConn();

            if (strFormType == "B" || strFormType == "BE")
            {
                if (dsData.Tables["P12_HK6_MASTER"].Rows.Count > 0)
                {
                    dgEFHK6.DataSource = dsData.Tables["P12_HK6_MASTER"];
                }
                else
                {
                    this.Text = "No HK-3 record found";
                }
            }
            else if (strFormType == "M")
            {
                if (dsData.Tables["P11_HK6_MASTER"].Rows.Count > 0)
                {
                    dgEFHK6.DataSource = dsData.Tables["P11_HK6_MASTER"];
                }
                else
                {
                    this.Text = "No HK-3 record found";
                }
            }
        }

        private void GetData2009()
        {
            EFilingDALBE2009 dalBE = new EFilingDALBE2009(strTaxPayer, strYA, "");
            EFilingDALB2009 dalB = new EFilingDALB2009(strTaxPayer, strYA, "");
            EFilingDALM2009 dalM = new EFilingDALM2009(strTaxPayer, strYA, "");

            if (strFormType == "B")
            {
                dsData = dalB.GetFormDataB2009("B2009Page12");
            }
            else if (strFormType == "BE")
            {
                dsData = dalBE.GetFormDataBE2009("BE2009Page9");
            }
            else if (strFormType == "M")
            {
                dsData = dalM.GetFormDataM2009("M2009Page11");
            }

            dalBE.CloseConn();

            if (strFormType == "B" || strFormType == "BE")
            {
                if (dsData.Tables["P12_HK6_MASTER"].Rows.Count > 0)
                {
                    dgEFHK6.DataSource = dsData.Tables["P12_HK6_MASTER"];
                }
                else
                {
                    this.Text = "No HK-3 record found";
                }
            }
            else if (strFormType == "M")
            {
                if (dsData.Tables["P11_HK6_MASTER"].Rows.Count > 0)
                {
                    dgEFHK6.DataSource = dsData.Tables["P11_HK6_MASTER"];
                }
                else
                {
                    this.Text = "No HK-3 record found";
                }
            }
        }

        private void GetData2008()
        {            
            EFilingDALB dalB = new EFilingDALB(strTaxPayer, strYA, "");
            if (strFormType == "B" || strFormType == "BE")
            {
                dsData = dalB.GetFormDataB("B2008Page12");
            }
            else if (strFormType == "M")
            {
                dsData = dalB.GetFormDataM("M2008Page11");
            }
            dalB.CloseConn();

            if (strFormType == "B" || strFormType == "BE")
            {
                if (dsData.Tables["P12_HK6_MASTER"].Rows.Count > 0)
                {
                    dgEFHK6.DataSource = dsData.Tables["P12_HK6_MASTER"];
                }
                else
                {
                    this.Text = "No HK-3 record found";
                }
            }
            else if (strFormType == "M")
            {
                if (dsData.Tables["P11_HK6_MASTER"].Rows.Count > 0)
                {
                    dgEFHK6.DataSource = dsData.Tables["P11_HK6_MASTER"];
                }
                else
                {
                    this.Text = "No HK-3 record found";
                }
            }
        }

        private void GetData()
        {
            switch (this.strYA)
            {
                case "2015":
                    GetData2015();
                    break;
                case "2014":
                    GetData2014();
                    break;
                //Simkh 2014
                case "2013":
                    GetData2013();
                    break;
                //Simkh end
                case "2012":
                    GetData2012();
                    break;
                //LEESH FEB 2012
                case "2011":
                    GetData2011();
                    break;
                //LEESH END
                case "2010":
                    GetData2010();
                    break;
                case "2009":
                    GetData2009();
                    break;
                case "2008":
                    GetData2008();
                    break;
            }
            //EFilingDALB dalB = new EFilingDALB(strTaxPayer, strYA, "");
            //if (strFormType == "B" || strFormType == "BE")
            //{
            //    dsData = dalB.GetFormDataB("B2008Page12");
            //}
            //else if (strFormType == "M")
            //{
            //    dsData = dalB.GetFormDataM("M2008Page11");
            //}
            //dalB.CloseConn();
            //if (strFormType == "B" || strFormType == "BE")
            //{
            //    if (dsData.Tables["P12_HK6_MASTER"].Rows.Count > 0)
            //    {
            //        dgEFHK6.DataSource = dsData.Tables["P12_HK6_MASTER"];
            //    }
            //    else
            //    {
            //        this.Text = "No HK-3 record found";
            //    }
            //}
            //else if (strFormType == "M")
            //{
            //    if (dsData.Tables["P11_HK6_MASTER"].Rows.Count > 0)
            //    {
            //        dgEFHK6.DataSource = dsData.Tables["P11_HK6_MASTER"];
            //    }
            //    else
            //    {
            //        this.Text = "No HK-3 record found";
            //    }
            //}
        }

        private void ProcessDocument(mshtml.HTMLDocument htmlDoc)
        {
            Boolean boolFilled = false;
            int intIndex;
            DateTime dtTemp1 = DateTime.Parse(dgEFHK6.SelectedRows[0].Cells[7].Value.ToString());
            //DateTime dtTemp2 = DateTime.Parse(dgEFHK6.SelectedRows[0].Cells[1].Value.ToString());
            string[] strData = new string[9];
            strData[0] = dgEFHK6.SelectedRows[0].Cells[0].Value.ToString();
            strData[1] = dgEFHK6.SelectedRows[0].Cells[1].Value.ToString();
            strData[2] = dgEFHK6.SelectedRows[0].Cells[2].Value.ToString();
            strData[3] = dgEFHK6.SelectedRows[0].Cells[3].Value.ToString();
            strData[4] = dgEFHK6.SelectedRows[0].Cells[4].Value.ToString();
            strData[5] = dgEFHK6.SelectedRows[0].Cells[5].Value.ToString();
            strData[6] = dgEFHK6.SelectedRows[0].Cells[6].Value.ToString();
            strData[7] = dtTemp1.ToString("ddMMyyyy");
            strData[8] = dgEFHK6.SelectedRows[0].Cells[8].Value.ToString();
            strData[9] = dgEFHK6.SelectedRows[0].Cells[9].Value.ToString();

         //   strData[8] = dgEFHK6.SelectedRows[0].Cells[8].Value.ToString();
            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
            {
                switch (inpElement1.name)
                {
                    case "ctl00$ContentPlaceHolder1$GridView1$ctl01$txtEmpty_nama_pembayar":
                        inpElement1.value = strData[4].ToString().ToUpper();
                        break;
                }
            }
            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
            {
                if (inpElement1.name == "txtfaedah")
                {
                        inpElement1.value = strData[8];
                        inpElement1.blur();
                        break;
                }
            }
            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
            {
                switch (inpElement1.name)
                {
                    case "ctl00$ContentPlaceHolder1$GridView1$ctl01$txtEmpty_pendapatan_kasar":
                        inpElement1.value = strData[8];
                        boolFilled = true;
                        break;
                    case "ctl00$ContentPlaceHolder1$GridView1$ctl01$txtEmpty_cukai_dipotong":
                        inpElement1.value = strData[1];
                        break;
                    case "ctl00$ContentPlaceHolder1$GridView1$ctl01$txtEmpty_tkh_bayaran":
                        inpElement1.value = strData[7];
                        break;
                    case "ctl00$ContentPlaceHolder1$GridView1$ctl01$txtEmpty_no_resit":
                        inpElement1.value = strData[6];
                        break;
                    //case "GridView1$ctl01$txtEmpty_div_bersih":
                    //    inpElement1.value = strData[7];
                    //    break;
                    //case "GridView1$ctl01$txtEmpty_div_bersih2":
                    //    inpElement1.value = strData[8];
                    //    break;  
                    //case "txtfaedah":
                    //    inpElement1.value = strData[8];
                    //    inpElement1.blur();
                    //    break;
                    case "ctl00$ContentPlaceHolder1$GridView1$ctl01$btnEmpty_Add":
                        inpElement1.click();
                        break;

                }
            }
            for (intIndex = 3;  ; intIndex++)
            {
                if (boolFilled == true)
                { break; }
                else
                {
                    string strWaranNo = "GridView1$ctl" + intIndex.ToString("0#") + "$txtno_waran_siri_Add";
                    string strCompanyName = "GridView1$ctl" + intIndex.ToString("0#") + "$txtnama_syarikat_Add";
                    string strPaymentDate = "GridView1$ctl" + intIndex.ToString("0#") + "$txtTkh_bayaran_Add";
                    string strYearEnd = "GridView1$ctl" + intIndex.ToString("0#") + "$txtbg_thn_berakhir_Add";
                    string strGrossDiv = "GridView1$ctl" + intIndex.ToString("0#") + "$txtdiv_kasar_Add";
                    string strTaxRate = "GridView1$ctl" + intIndex.ToString("0#") + "$txtkadar_cukai_Add";
                    string strTaxDeduct = "GridView1$ctl" + intIndex.ToString("0#") + "$txtcukai_dipotong_Add";
                    //string strFaedah = "txtfaedah";
                    //string strNetDiv = "GridView1$ctl" + intIndex.ToString("0#") + "$txtdiv_bersih_Add";

                    foreach (mshtml.HTMLInputElement inpElement2 in htmlDoc.getElementsByTagName("input"))
                    {
                        if (inpElement2.name.ToString() == strWaranNo)
                        {
                            inpElement2.value = strData[2];
                            boolFilled = true;
                        }
                        else if (inpElement2.name.ToString() == strCompanyName)
                        {
                            inpElement2.value = strData[3].ToString().ToUpper();
                        }
                        else if (inpElement2.name.ToString() == strPaymentDate)
                        {
                            inpElement2.value = strData[0];
                        }
                        else if (inpElement2.name.ToString() == strYearEnd)
                        {
                            inpElement2.value = strData[1];
                        }
                        else if (inpElement2.name.ToString() == strGrossDiv)
                        {
                            inpElement2.value = strData[4];
                        }
                        else if (inpElement2.name.ToString() == strTaxRate)
                        {
                            inpElement2.value = strData[5];
                        }
                        else if (inpElement2.name.ToString() == strTaxDeduct)
                        {
                            inpElement2.value = strData[6];
                        }
                        //else if (inpElement2.name.ToString() == strFaedah)
                        //{
                        //    inpElement2.value = strData[8];
                        //}
                        //else if (inpElement2.name.ToString() == strNetDiv)
                        //{
                        //    inpElement2.value = strData[7];
                        //}
                    }
                }
            }

            if (boolFilled == true)
            {
                intIndex = intIndex - 1;
                string strLnkAdd = "GridView1_ctl" + intIndex.ToString("0#") + "_btnTambahFooter";
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

        private void tsbtnFill_Click(object sender, EventArgs e)
        {
            SHDocVw.ShellWindows swTemp = new SHDocVw.ShellWindows();
            Boolean boolTargetFound = false;
            Boolean boolTargetReady = false;
            EFilingDALB dalB = new EFilingDALB();
            string[] strData = new string[10];

            if (dgEFHK6.SelectedRows.Count > 0)
            {
                DateTime dtTemp1 = DateTime.Parse(dgEFHK6.SelectedRows[0].Cells[7].Value.ToString());
                strData[0] = dgEFHK6.SelectedRows[0].Cells[0].Value.ToString();
                strData[1] = dgEFHK6.SelectedRows[0].Cells[1].Value.ToString();
                strData[2] = dgEFHK6.SelectedRows[0].Cells[2].Value.ToString();
                strData[3] = dgEFHK6.SelectedRows[0].Cells[3].Value.ToString();
                strData[4] = dgEFHK6.SelectedRows[0].Cells[4].Value.ToString();
                strData[5] = dgEFHK6.SelectedRows[0].Cells[5].Value.ToString();
                strData[6] = dgEFHK6.SelectedRows[0].Cells[6].Value.ToString();
                strData[7] =  dtTemp1.ToString("ddMMyyyy");
                strData[8] = dgEFHK6.SelectedRows[0].Cells[8].Value.ToString();
                strData[9] = dgEFHK6.SelectedRows[0].Cells[9].Value.ToString();

             //   strData[8] = dgEFHK6.SelectedRows[0].Cells[8].Value.ToString();
            }
            else
            {
                MessageBox.Show("No record found for E-Filling!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                foreach (SHDocVw.InternetExplorer ieTemp in swTemp)
                {
                    string strDocName = dalB.GetDocName(ieTemp.LocationURL.ToString().ToLower(), strYA, strFormType);
                    //testing
                    //MessageBox.Show(strDocName.ToString());
                    //if (strDocName == "")
                    //    MessageBox.Show("strDocName is empty");
                    //    strDocName = "BE2010Page3";
                    //endtesting
                    if (strDocName.Length > 0)
                    {
                        boolTargetFound = true;
                        if (ieTemp.ReadyState.Equals(SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE))
                        {
                            boolTargetReady = true;
                            if (typeof(mshtml.HTMLDocumentClass).IsAssignableFrom(ieTemp.Document.GetType()))
                            {
                                mshtml.HTMLDocument htmlDoc = ieTemp.Document as mshtml.HTMLDocument;
                                EFilingProcessHK6 dalProcessFormHK6 = new EFilingProcessHK6(strData, this.strYA);
                                dalProcessFormHK6.ProcessDocument(htmlDoc);
                                //ProcessDocument(htmlDoc);
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
         
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void dgEFHK6_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbtnFill_Click(sender, e);
        }

        private void frmHK6_Load(object sender, EventArgs e)
        {

        }
    }
}
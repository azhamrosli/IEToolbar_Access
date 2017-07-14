using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace IEToolBar
{
    class EFilingProcessR
    {
        string strYA = "";
        string strTaxPayer = "";
        string strAuditor = "";
        string strRecKept = "";
        string strTaxAgent = "";

        public EFilingProcessR()
        {
        }

        public EFilingProcessR(string strTaxPayer, string strYA, string strAuditor, string strRecKept, string strTaxAgent)
        {
            this.strYA = strYA;
            this.strTaxPayer = strTaxPayer;
            this.strAuditor = strAuditor;
            this.strRecKept = strRecKept;
            this.strTaxAgent = strTaxAgent;
        }

        private void ProcessFormR2008(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            try
            {
                EFilingDAL dal = new EFilingDAL(strTaxPayer, strYA, strAuditor, strTaxAgent);
                DataSet dsData = dal.GetFormData(strPageIndex);
                dal.CloseConn();
                string strComparator;

                #region "INPUT"
                foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
                {
                    switch (strPageIndex)
                    {
                        #region "Page 1"
                        case "R2008Page1":
                            switch (inpElement.name)
                            {
                                //ctl00$ContentPlaceHolder2$txtNama_Sykt
                                //ctl00$ContentPlaceHolder2$txtNo_Rujukan
                                //ctl00$ContentPlaceHolder2$TextBox12
                                //ctl00$ContentPlaceHolder2$TextBox12_MaskedEditExtender_ClientState
                                case "ctl00$ContentPlaceHolder2$txtTempoh":
                                    inpElement.value = dsData.Tables["P1_TP_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //ctl00$ContentPlaceHolder2$txtNo_Daftar
                                //ctl00$ContentPlaceHolder2$txtDate
                                case "ctl00$ContentPlaceHolder2$txtTarikh_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_1":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_2":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_3":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_4":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_5":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_6":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_7":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_8":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_9":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_10":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_11":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_12":

                                //    break;
                                //ctl00$ContentPlaceHolder2$txtJumlah_Amaun_Kasar
                                //ctl00$ContentPlaceHolder2$txtJumlah_Cukai_layak
                                //ctl00$ContentPlaceHolder2$txtJumlah_Cukai_Tdk_layak
                                //ctl00$ContentPlaceHolder2$txtJumlah_Amaun_Bersih
                                //ctl00$ContentPlaceHolder2$btnSubmit
                            }
                            break;
                        #endregion

                        #region "Page 2"
                        case "R2008Page2":
                            switch (inpElement.name)
                            {
                                //ctl00$ContentPlaceHolder2$txtdate2
                                //ctl00$ContentPlaceHolder2$txtDate
                                case "ctl00$ContentPlaceHolder2$txtA1":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA1_Tarikh":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_BORANG08"].Rows.Count > 0 && dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[0].ToString() == "2")
                                            inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[2].ToString();
                                        FireInpElementEvent(inpElement, "OnBlur");
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                        FireInpElementEvent(inpElement, "OnBlur");
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA2":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[4].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA4":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        //NGOHCS C2009.1 (SU12)
                                        //inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[5].ToString();
                                        inpElement.value = (double.Parse(dsData.Tables["P2_BORANG08_SEC4A"].Rows[0].ItemArray[0].ToString().Replace(",", "")) +
                                                            double.Parse(dsData.Tables["P2_BORANG08_SEC4A"].Rows[0].ItemArray[1].ToString().Replace(",", ""))).ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA4a":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        //NGOHCS C2009.1 (SU12)
                                        inpElement.value = dsData.Tables["P2_BORANG08_SEC4A"].Rows[0].ItemArray[2].ToString();
                                        //inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[6].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA4b":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        //NGOHCS C2009.1 (SU12)
                                        inpElement.value = dsData.Tables["P2_BORANG08_SEC4A"].Rows[0].ItemArray[3].ToString();
                                        //inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[7].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtA4c":

                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA5":

                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA6":

                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA7":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtA8a":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[8].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA8b":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[9].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA8c":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[10].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA8d":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[11].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtA8e":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtA9a_TT":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[12].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[12].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA9a_KK":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[13].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA9b_TT":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[14].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[14].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA9b_KK":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[15].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA9c_TT":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[16].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[16].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA9c_KK":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[17].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //ctl00$ContentPlaceHolder2$txtA9d
                                //ctl00$ContentPlaceHolder2$txtA11
                                //ctl00$ContentPlaceHolder2$txtA12
                                //ctl00$ContentPlaceHolder2$txtA13_Label
                                //ctl00$ContentPlaceHolder2$txtA13a
                                //ctl00$ContentPlaceHolder2$txtA14
                                //ctl00$ContentPlaceHolder2$txtA15
                                //ctl00$ContentPlaceHolder2$txtA16
                                //ctl00$ContentPlaceHolder2$txtA17
                                case "ctl00$ContentPlaceHolder2$txtA10":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[18].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                            }
                            break;
                        #endregion
                    }
                }
                #endregion

                #region "SELECT"
                foreach (mshtml.HTMLSelectElement selElement in htmlDoc.getElementsByTagName("select"))
                {
                    switch (strPageIndex)
                    {
                        #region "Page 2"
                        case "R2008Page2":
                            switch (selElement.name)
                            {
                                case "ctl00$ContentPlaceHolder2$ddlA1":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[0].ToString() == "1" ? selElement.value = "1" : selElement.value = "2";
                                    else
                                        selElement.value = "0";
                                    FireSelElementEvent(selElement, "OnChange");
                                    break;
                            }
                            break;
                        #endregion
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ProcessFormR2009(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            try
            {
                EFilingDALC2009 dal = new EFilingDALC2009(strTaxPayer, strYA, strAuditor, strTaxAgent);
                DataSet dsData = dal.GetFormDataC2009(strPageIndex);
                dal.CloseConn();
                string strComparator;

                #region "INPUT"
                foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
                {
                    switch (strPageIndex)
                    {
                        #region "Page 1"
                        case "R2009Page1":
                            switch (inpElement.name)
                            {
                                //ctl00$ContentPlaceHolder2$txtNama_Sykt
                                //ctl00$ContentPlaceHolder2$txtNo_Rujukan
                                //ctl00$ContentPlaceHolder2$TextBox12
                                //ctl00$ContentPlaceHolder2$TextBox12_MaskedEditExtender_ClientState
                                case "ctl00$ContentPlaceHolder2$txtTempohDari":
                                    inpElement.value = dsData.Tables["P1_TP_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtTempohHingga":
                                    inpElement.value = dsData.Tables["P1_TP_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //ctl00$ContentPlaceHolder2$txtNo_Daftar
                                //ctl00$ContentPlaceHolder2$txtDate
                                case "ctl00$ContentPlaceHolder2$txtTarikh_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_1":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_2":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_3":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_4":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_5":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_6":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_7":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_8":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_9":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_10":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_11":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_12":

                                //    break;
                                //ctl00$ContentPlaceHolder2$txtJumlah_Amaun_Kasar
                                //ctl00$ContentPlaceHolder2$txtJumlah_Cukai_layak
                                //ctl00$ContentPlaceHolder2$txtJumlah_Cukai_Tdk_layak
                                //ctl00$ContentPlaceHolder2$txtJumlah_Amaun_Bersih
                                //ctl00$ContentPlaceHolder2$btnSubmit
                            }
                            break;
                        #endregion

                        #region "Page 2"
                        case "R2009Page2":
                            switch (inpElement.name)
                            {
                                //ctl00$ContentPlaceHolder2$txtdate2
                                //ctl00$ContentPlaceHolder2$txtDate
                                case "ctl00$ContentPlaceHolder2$txtA1":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA1_Tarikh":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_BORANG08"].Rows.Count > 0 && dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[0].ToString() == "2")
                                            inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[2].ToString();
                                        FireInpElementEvent(inpElement, "OnBlur");
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                        FireInpElementEvent(inpElement, "OnBlur");
                                    }
                                    break;

                                //case "ctl00$ContentPlaceHolder2$txtA5":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[3].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA6":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[4].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA7":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[5].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA8":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[6].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA9":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[7].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;

                                //case "ctl00$ContentPlaceHolder2$txtA4c":

                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA5":

                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA6":

                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA7":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtA2a":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[8].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA2b":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[9].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA2c":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[10].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA2d":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[11].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtA8e":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtA3a_TT":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[12].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[12].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3a_KK":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[13].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3b_TT":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[14].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[14].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3b_KK":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[15].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3c_TT":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[16].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[16].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3c_KK":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[17].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //ctl00$ContentPlaceHolder2$txtA9d
                                //ctl00$ContentPlaceHolder2$txtA11
                                //ctl00$ContentPlaceHolder2$txtA12
                                //ctl00$ContentPlaceHolder2$txtA13_Label
                                //ctl00$ContentPlaceHolder2$txtA13a
                                //ctl00$ContentPlaceHolder2$txtA14
                                //ctl00$ContentPlaceHolder2$txtA15
                                //ctl00$ContentPlaceHolder2$txtA16
                                //ctl00$ContentPlaceHolder2$txtA17
                                case "ctl00$ContentPlaceHolder2$txtA4":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[18].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                            }
                            break;
                        #endregion
                    }
                }
                #endregion

                #region "SELECT"
                foreach (mshtml.HTMLSelectElement selElement in htmlDoc.getElementsByTagName("select"))
                {
                    switch (strPageIndex)
                    {
                        #region "Page 2"
                        case "R2009Page2":
                            switch (selElement.name)
                            {
                                case "ctl00$ContentPlaceHolder2$ddlA1":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[0].ToString() == "1" ? selElement.value = "1" : selElement.value = "2";
                                    else
                                        selElement.value = "0";
                                    FireSelElementEvent(selElement, "OnChange");
                                    break;

                                case "ctl00$ContentPlaceHolder2$ddlA7":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[19].ToString() == "1" ? selElement.value = "2" : selElement.value = "1";
                                    else
                                        selElement.value = "0";
                                    FireSelElementEvent(selElement, "OnChange");
                                    break;
                            }
                            break;
                        #endregion
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ProcessFormR2010(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            try
            {
                EFilingDALC2010 dal = new EFilingDALC2010(strTaxPayer, strYA, strAuditor, strTaxAgent);
                DataSet dsData = dal.GetFormDataC2010(strPageIndex);
                dal.CloseConn();
                string strComparator;

                #region "INPUT"
                foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
                {
                    switch (strPageIndex)
                    {
                        #region "Page 1"
                        case "R2010Page1":
                            switch (inpElement.name)
                            {
                                //ctl00$ContentPlaceHolder2$txtNama_Sykt
                                //ctl00$ContentPlaceHolder2$txtNo_Rujukan
                                //ctl00$ContentPlaceHolder2$TextBox12
                                //ctl00$ContentPlaceHolder2$TextBox12_MaskedEditExtender_ClientState
                                case "ctl00$ContentPlaceHolder2$txtTempohDari":
                                    inpElement.value = dsData.Tables["P1_TP_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtTempohHingga":
                                    inpElement.value = dsData.Tables["P1_TP_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //ctl00$ContentPlaceHolder2$txtNo_Daftar
                                //ctl00$ContentPlaceHolder2$txtDate
                                case "ctl00$ContentPlaceHolder2$txtTarikh_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_1":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_2":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_3":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_4":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_5":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_6":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_7":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_8":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_9":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_10":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_11":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_12":

                                //    break;
                                //ctl00$ContentPlaceHolder2$txtJumlah_Amaun_Kasar
                                //ctl00$ContentPlaceHolder2$txtJumlah_Cukai_layak
                                //ctl00$ContentPlaceHolder2$txtJumlah_Cukai_Tdk_layak
                                //ctl00$ContentPlaceHolder2$txtJumlah_Amaun_Bersih
                                //ctl00$ContentPlaceHolder2$btnSubmit
                            }
                            break;
                        #endregion

                        #region "Page 2"
                        case "R2010Page2":
                            switch (inpElement.name)
                            {
                                //ctl00$ContentPlaceHolder2$txtdate2
                                //ctl00$ContentPlaceHolder2$txtDate
                                case "ctl00$ContentPlaceHolder2$txtA1":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA1_Tarikh":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_BORANG08"].Rows.Count > 0 && dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[0].ToString() == "2")
                                            inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[2].ToString();
                                        FireInpElementEvent(inpElement, "OnBlur");
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                        FireInpElementEvent(inpElement, "OnBlur");
                                    }
                                    break;

                                //case "ctl00$ContentPlaceHolder2$txtA5":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[3].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA6":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[4].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA7":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[5].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA8":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[6].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA9":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[7].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;

                                //case "ctl00$ContentPlaceHolder2$txtA4c":

                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA5":

                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA6":

                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA7":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtA2a":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[8].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA2b":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[9].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA2c":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[10].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA2d":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[11].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtA8e":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtA3a_TT":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[12].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[12].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3a_KK":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[13].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3b_TT":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[14].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[14].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3b_KK":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[15].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3c_TT":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[16].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[16].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3c_KK":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[17].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //ctl00$ContentPlaceHolder2$txtA9d
                                //ctl00$ContentPlaceHolder2$txtA11
                                //ctl00$ContentPlaceHolder2$txtA12
                                //ctl00$ContentPlaceHolder2$txtA13_Label
                                //ctl00$ContentPlaceHolder2$txtA13a
                                //ctl00$ContentPlaceHolder2$txtA14
                                //ctl00$ContentPlaceHolder2$txtA15
                                //ctl00$ContentPlaceHolder2$txtA16
                                //ctl00$ContentPlaceHolder2$txtA17
                                case "ctl00$ContentPlaceHolder2$txtA4":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[18].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                            }
                            break;
                        #endregion
                    }
                }
                #endregion

                #region "SELECT"
                foreach (mshtml.HTMLSelectElement selElement in htmlDoc.getElementsByTagName("select"))
                {
                    switch (strPageIndex)
                    {
                        #region "Page 2"
                        case "R2010Page2":
                            switch (selElement.name)
                            {
                                case "ctl00$ContentPlaceHolder2$ddlA1":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[0].ToString() == "1" ? selElement.value = "1" : selElement.value = "2";
                                    else
                                        selElement.value = "0";
                                    FireSelElementEvent(selElement, "OnChange");
                                    break;

                                case "ctl00$ContentPlaceHolder2$ddlA7":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[19].ToString() == "1" ? selElement.value = "2" : selElement.value = "1";
                                    else
                                        selElement.value = "0";
                                    FireSelElementEvent(selElement, "OnChange");
                                    break;
                            }
                            break;
                        #endregion
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ProcessFormR2011(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            try
            {
                EFilingDALC2011 dal = new EFilingDALC2011(strTaxPayer, strYA, strAuditor, strTaxAgent);
                DataSet dsData = dal.GetFormDataC2011(strPageIndex);
                dal.CloseConn();
                string strComparator;

                #region "INPUT"
                foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
                {
                    switch (strPageIndex)
                    {
                        #region "Page 1"
                        case "R2011Page1":
                            switch (inpElement.name)
                            {
                                //ctl00$ContentPlaceHolder2$txtNama_Sykt
                                //ctl00$ContentPlaceHolder2$txtNo_Rujukan
                                //ctl00$ContentPlaceHolder2$TextBox12
                                //ctl00$ContentPlaceHolder2$TextBox12_MaskedEditExtender_ClientState
                                case "ctl00$ContentPlaceHolder2$txtTempohDari":
                                    inpElement.value = dsData.Tables["P1_TP_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtTempohHingga":
                                    inpElement.value = dsData.Tables["P1_TP_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //ctl00$ContentPlaceHolder2$txtNo_Daftar
                                //ctl00$ContentPlaceHolder2$txtDate
                                case "ctl00$ContentPlaceHolder2$txtTarikh_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_1":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_2":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_3":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_4":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_5":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_6":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_7":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_8":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_9":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_10":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_11":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_12":

                                //    break;
                                //ctl00$ContentPlaceHolder2$txtJumlah_Amaun_Kasar
                                //ctl00$ContentPlaceHolder2$txtJumlah_Cukai_layak
                                //ctl00$ContentPlaceHolder2$txtJumlah_Cukai_Tdk_layak
                                //ctl00$ContentPlaceHolder2$txtJumlah_Amaun_Bersih
                                //ctl00$ContentPlaceHolder2$btnSubmit
                            }
                            break;
                        #endregion

                        #region "Page 2"
                        case "R2011Page2":
                            switch (inpElement.name)
                            {
                                //ctl00$ContentPlaceHolder2$txtdate2
                                //ctl00$ContentPlaceHolder2$txtDate
                                case "ctl00$ContentPlaceHolder2$txtA1":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA1_Tarikh":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_BORANG08"].Rows.Count > 0 && dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[0].ToString() == "2")
                                            inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[2].ToString();
                                        FireInpElementEvent(inpElement, "OnBlur");
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                        FireInpElementEvent(inpElement, "OnBlur");
                                    }
                                    break;

                                //case "ctl00$ContentPlaceHolder2$txtA5":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[3].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA6":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[4].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA7":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[5].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA8":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[6].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA9":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[7].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;

                                //case "ctl00$ContentPlaceHolder2$txtA4c":

                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA5":

                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA6":

                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA7":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtA2a":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[8].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA2b":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[9].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA2c":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[10].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA2d":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[11].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtA8e":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtA3a_TT":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[12].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[12].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3a_KK":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[13].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3b_TT":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[14].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[14].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3b_KK":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[15].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3c_TT":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[16].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[16].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3c_KK":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[17].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //ctl00$ContentPlaceHolder2$txtA9d
                                //ctl00$ContentPlaceHolder2$txtA11
                                //ctl00$ContentPlaceHolder2$txtA12
                                //ctl00$ContentPlaceHolder2$txtA13_Label
                                //ctl00$ContentPlaceHolder2$txtA13a
                                //ctl00$ContentPlaceHolder2$txtA14
                                //ctl00$ContentPlaceHolder2$txtA15
                                //ctl00$ContentPlaceHolder2$txtA16
                                //ctl00$ContentPlaceHolder2$txtA17
                                case "ctl00$ContentPlaceHolder2$txtA4":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[18].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                            }
                            break;
                        #endregion
                    }
                }
                #endregion

                #region "SELECT"
                foreach (mshtml.HTMLSelectElement selElement in htmlDoc.getElementsByTagName("select"))
                {
                    switch (strPageIndex)
                    {
                        #region "Page 2"
                        case "R2011Page2":
                            switch (selElement.name)
                            {
                                case "ctl00$ContentPlaceHolder2$ddlA1":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[0].ToString() == "1" ? selElement.value = "1" : selElement.value = "2";
                                    else
                                        selElement.value = "0";
                                    FireSelElementEvent(selElement, "OnChange");
                                    break;

                                case "ctl00$ContentPlaceHolder2$ddlA7":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[19].ToString() == "1" ? selElement.value = "2" : selElement.value = "1";
                                    else
                                        selElement.value = "0";
                                    FireSelElementEvent(selElement, "OnChange");
                                    break;
                            }
                            break;
                        #endregion
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ProcessFormR2012(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            try
            {
                EFilingDALC2012 dal = new EFilingDALC2012(strTaxPayer, strYA, strAuditor, strTaxAgent);
                DataSet dsData = dal.GetFormDataC2012(strPageIndex);
                dal.CloseConn();
                string strComparator;

                #region "INPUT"
                foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
                {
                    switch (strPageIndex)
                    {
                        #region "Page 1"
                        case "R2012Page1":
                            switch (inpElement.name)
                            {
                                //ctl00$ContentPlaceHolder2$txtNama_Sykt
                                //ctl00$ContentPlaceHolder2$txtNo_Rujukan
                                //ctl00$ContentPlaceHolder2$TextBox12
                                //ctl00$ContentPlaceHolder2$TextBox12_MaskedEditExtender_ClientState
                                case "ctl00$ContentPlaceHolder2$txtTempohDari":
                                    inpElement.value = dsData.Tables["P1_TP_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtTempohHingga":
                                    inpElement.value = dsData.Tables["P1_TP_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //ctl00$ContentPlaceHolder2$txtNo_Daftar
                                //ctl00$ContentPlaceHolder2$txtDate
                                case "ctl00$ContentPlaceHolder2$txtTarikh_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_1":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_2":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_3":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_4":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_5":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_6":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_7":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_8":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_9":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_10":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_11":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_12":

                                //    break;
                                //ctl00$ContentPlaceHolder2$txtJumlah_Amaun_Kasar
                                //ctl00$ContentPlaceHolder2$txtJumlah_Cukai_layak
                                //ctl00$ContentPlaceHolder2$txtJumlah_Cukai_Tdk_layak
                                //ctl00$ContentPlaceHolder2$txtJumlah_Amaun_Bersih
                                //ctl00$ContentPlaceHolder2$btnSubmit
                            }
                            break;
                        #endregion

                        #region "Page 2"
                        case "R2012Page2":
                            switch (inpElement.name)
                            {
                                //ctl00$ContentPlaceHolder2$txtdate2
                                //ctl00$ContentPlaceHolder2$txtDate
                                case "ctl00$ContentPlaceHolder2$txtA1":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA1_Tarikh":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_BORANG08"].Rows.Count > 0 && dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[0].ToString() == "2")
                                            inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[2].ToString();
                                        FireInpElementEvent(inpElement, "OnBlur");
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                        FireInpElementEvent(inpElement, "OnBlur");
                                    }
                                    break;

                                //case "ctl00$ContentPlaceHolder2$txtA5":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[3].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA6":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[4].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA7":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[5].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA8":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[6].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA9":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[7].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;

                                //case "ctl00$ContentPlaceHolder2$txtA4c":

                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA5":

                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA6":

                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA7":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtA2a":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[8].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA2b":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[9].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA2c":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[10].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA2d":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[11].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtA8e":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtA3a_TT":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[12].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[12].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3a_KK":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[13].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3b_TT":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[14].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[14].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3b_KK":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[15].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3c_TT":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[16].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[16].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3c_KK":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[17].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //ctl00$ContentPlaceHolder2$txtA9d
                                //ctl00$ContentPlaceHolder2$txtA11
                                //ctl00$ContentPlaceHolder2$txtA12
                                //ctl00$ContentPlaceHolder2$txtA13_Label
                                //ctl00$ContentPlaceHolder2$txtA13a
                                //ctl00$ContentPlaceHolder2$txtA14
                                //ctl00$ContentPlaceHolder2$txtA15
                                //ctl00$ContentPlaceHolder2$txtA16
                                //ctl00$ContentPlaceHolder2$txtA17
                                case "ctl00$ContentPlaceHolder2$txtA4":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[18].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                            }
                            break;
                        #endregion
                    }
                }
                #endregion

                #region "SELECT"
                foreach (mshtml.HTMLSelectElement selElement in htmlDoc.getElementsByTagName("select"))
                {
                    switch (strPageIndex)
                    {
                        #region "Page 2"
                        case "R2012Page2":
                            switch (selElement.name)
                            {
                                case "ctl00$ContentPlaceHolder2$ddlA1":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[0].ToString() == "1" ? selElement.value = "1" : selElement.value = "2";
                                    else
                                        selElement.value = "0";
                                    FireSelElementEvent(selElement, "OnChange");
                                    break;

                                case "ctl00$ContentPlaceHolder2$ddlA7":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[19].ToString() == "1" ? selElement.value = "2" : selElement.value = "1";
                                    else
                                        selElement.value = "0";
                                    FireSelElementEvent(selElement, "OnChange");
                                    break;
                            }
                            break;
                        #endregion
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ProcessFormR2013(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            try
            {
                EFilingDALC2013 dal = new EFilingDALC2013(strTaxPayer, strYA, strAuditor, strTaxAgent);
                DataSet dsData = dal.GetFormDataC2013(strPageIndex);
                dal.CloseConn();
                string strComparator;

                #region "INPUT"
                foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
                {
                    switch (strPageIndex)
                    {
                        #region "Page 1"
                        case "R2013Page1":
                            switch (inpElement.name)
                            {
                                //ctl00$ContentPlaceHolder2$txtNama_Sykt
                                //ctl00$ContentPlaceHolder2$txtNo_Rujukan
                                //ctl00$ContentPlaceHolder2$TextBox12
                                //ctl00$ContentPlaceHolder2$TextBox12_MaskedEditExtender_ClientState
                                case "ctl00$ContentPlaceHolder2$txtTempohDari":
                                    inpElement.value = dsData.Tables["P1_TP_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtTempohHingga":
                                    inpElement.value = dsData.Tables["P1_TP_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //ctl00$ContentPlaceHolder2$txtNo_Daftar
                                //ctl00$ContentPlaceHolder2$txtDate
                                case "ctl00$ContentPlaceHolder2$txtTarikh_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_1":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_2":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_3":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_4":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_5":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_6":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_7":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_8":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_9":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_10":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_11":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_12":

                                //    break;
                                //ctl00$ContentPlaceHolder2$txtJumlah_Amaun_Kasar
                                //ctl00$ContentPlaceHolder2$txtJumlah_Cukai_layak
                                //ctl00$ContentPlaceHolder2$txtJumlah_Cukai_Tdk_layak
                                //ctl00$ContentPlaceHolder2$txtJumlah_Amaun_Bersih
                                //ctl00$ContentPlaceHolder2$btnSubmit
                            }
                            break;
                        #endregion

                        #region "Page 2"
                        case "R2013Page2":
                            switch (inpElement.name)
                            {
                                //ctl00$ContentPlaceHolder2$txtdate2
                                //ctl00$ContentPlaceHolder2$txtDate
                                case "ctl00$ContentPlaceHolder2$txtA1":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA1_Tarikh":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_BORANG08"].Rows.Count > 0 && dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[0].ToString() == "2")
                                            inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[2].ToString();
                                        FireInpElementEvent(inpElement, "OnBlur");
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                        FireInpElementEvent(inpElement, "OnBlur");
                                    }
                                    break;

                                //case "ctl00$ContentPlaceHolder2$txtA5":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[3].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA6":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[4].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA7":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[5].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA8":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[6].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA9":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[7].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;

                                //case "ctl00$ContentPlaceHolder2$txtA4c":

                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA5":

                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA6":

                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA7":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtA2a":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[8].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA2b":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[9].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA2c":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[10].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA2d":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[11].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtA8e":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtA3a_TT":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[12].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[12].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3a_KK":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[13].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3b_TT":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[14].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[14].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3b_KK":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[15].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3c_TT":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[16].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[16].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3c_KK":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[17].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //ctl00$ContentPlaceHolder2$txtA9d
                                //ctl00$ContentPlaceHolder2$txtA11
                                //ctl00$ContentPlaceHolder2$txtA12
                                //ctl00$ContentPlaceHolder2$txtA13_Label
                                //ctl00$ContentPlaceHolder2$txtA13a
                                //ctl00$ContentPlaceHolder2$txtA14
                                //ctl00$ContentPlaceHolder2$txtA15
                                //ctl00$ContentPlaceHolder2$txtA16
                                //ctl00$ContentPlaceHolder2$txtA17
                                case "ctl00$ContentPlaceHolder2$txtA4":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[18].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                            }
                            break;
                        #endregion
                    }
                }
                #endregion

                #region "SELECT"
                foreach (mshtml.HTMLSelectElement selElement in htmlDoc.getElementsByTagName("select"))
                {
                    switch (strPageIndex)
                    {
                        #region "Page 2"
                        case "R2013Page2":
                            switch (selElement.name)
                            {
                                case "ctl00$ContentPlaceHolder2$ddlA1":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[0].ToString() == "1" ? selElement.value = "1" : selElement.value = "2";
                                    else
                                        selElement.value = "0";
                                    FireSelElementEvent(selElement, "OnChange");
                                    break;

                                case "ctl00$ContentPlaceHolder2$ddlA7":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[19].ToString() == "1" ? selElement.value = "2" : selElement.value = "1";
                                    else
                                        selElement.value = "0";
                                    FireSelElementEvent(selElement, "OnChange");
                                    break;
                            }
                            break;
                        #endregion
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //simkh april 2014
        private void ProcessFormR2014(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            try
            {
                EFilingDALC2014 dal = new EFilingDALC2014(strTaxPayer, strYA, strAuditor, strTaxAgent);
                DataSet dsData = dal.GetFormDataC2014(strPageIndex);
                dal.CloseConn();
                string strComparator;

                #region "INPUT"
                foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
                {
                    switch (strPageIndex)
                    {
                        #region "Page 1"
                        case "R2014Page1":
                            switch (inpElement.name)
                            {
                                //ctl00$ContentPlaceHolder2$txtNama_Sykt
                                //ctl00$ContentPlaceHolder2$txtNo_Rujukan
                                //ctl00$ContentPlaceHolder2$TextBox12
                                //ctl00$ContentPlaceHolder2$TextBox12_MaskedEditExtender_ClientState
                                case "ctl00$ContentPlaceHolder2$txtTempohDari":
                                    inpElement.value = dsData.Tables["P1_TP_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtTempohHingga":
                                    inpElement.value = dsData.Tables["P1_TP_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //ctl00$ContentPlaceHolder2$txtNo_Daftar
                                //ctl00$ContentPlaceHolder2$txtDate
                                case "ctl00$ContentPlaceHolder2$txtTarikh_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_1":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_1":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_2":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_2":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_3":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_3":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_4":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_4":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_5":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_5":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_6":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_6":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_7":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_7":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_8":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_8":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_9":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_9":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_10":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_10":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_11":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_11":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtTarikh_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[0].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Layak_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[2].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_12":
                                    if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
                                        inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[3].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_12":

                                //    break;
                                //ctl00$ContentPlaceHolder2$txtJumlah_Amaun_Kasar
                                //ctl00$ContentPlaceHolder2$txtJumlah_Cukai_layak
                                //ctl00$ContentPlaceHolder2$txtJumlah_Cukai_Tdk_layak
                                //ctl00$ContentPlaceHolder2$txtJumlah_Amaun_Bersih
                                //ctl00$ContentPlaceHolder2$btnSubmit
                            }
                            break;
                        #endregion

                        #region "Page 2"
                        case "R2014Page2":
                            switch (inpElement.name)
                            {
                                //ctl00$ContentPlaceHolder2$txtdate2
                                //ctl00$ContentPlaceHolder2$txtDate
                                case "ctl00$ContentPlaceHolder2$txtA1":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[1].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA1_Tarikh":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_BORANG08"].Rows.Count > 0 && dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[0].ToString() == "2")
                                            inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[2].ToString();
                                        FireInpElementEvent(inpElement, "OnBlur");
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                        FireInpElementEvent(inpElement, "OnBlur");
                                    }
                                    break;

                                //case "ctl00$ContentPlaceHolder2$txtA5":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[3].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA6":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[4].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA7":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[5].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA8":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[6].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA9":
                                //    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                //        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[7].ToString();
                                //    else
                                //        inpElement.value = "";
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;

                                //case "ctl00$ContentPlaceHolder2$txtA4c":

                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA5":

                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA6":

                                //    break;
                                //case "ctl00$ContentPlaceHolder2$txtA7":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtA2a":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[8].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA2b":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[9].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA2c":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[10].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA2d":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[11].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder2$txtA8e":

                                //    break;
                                case "ctl00$ContentPlaceHolder2$txtA3a_TT":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[12].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[12].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3a_KK":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[13].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3b_TT":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[14].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[14].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3b_KK":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[15].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3c_TT":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[16].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[16].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtA3c_KK":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[17].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //ctl00$ContentPlaceHolder2$txtA9d
                                //ctl00$ContentPlaceHolder2$txtA11
                                //ctl00$ContentPlaceHolder2$txtA12
                                //ctl00$ContentPlaceHolder2$txtA13_Label
                                //ctl00$ContentPlaceHolder2$txtA13a
                                //ctl00$ContentPlaceHolder2$txtA14
                                //ctl00$ContentPlaceHolder2$txtA15
                                //ctl00$ContentPlaceHolder2$txtA16
                                //ctl00$ContentPlaceHolder2$txtA17
                                case "ctl00$ContentPlaceHolder2$txtA4":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[18].ToString();
                                    else
                                        inpElement.value = "";
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                            }
                            break;
                        #endregion
                    }
                }
                #endregion

                #region "SELECT"
                foreach (mshtml.HTMLSelectElement selElement in htmlDoc.getElementsByTagName("select"))
                {
                    switch (strPageIndex)
                    {
                        #region "Page 2"
                        case "R2014Page2":
                            switch (selElement.name)
                            {
                                case "ctl00$ContentPlaceHolder2$ddlA1":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[0].ToString() == "1" ? selElement.value = "1" : selElement.value = "2";
                                    else
                                        selElement.value = "0";
                                    FireSelElementEvent(selElement, "OnChange");
                                    break;

                                case "ctl00$ContentPlaceHolder2$ddlA7":
                                    if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
                                        strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[19].ToString() == "1" ? selElement.value = "2" : selElement.value = "1";
                                    else
                                        selElement.value = "0";
                                    FireSelElementEvent(selElement, "OnChange");
                                    break;
                            }
                            break;
                        #endregion
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //simkh end
        
        public void ProcessForm(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            switch (strYA)
            {
                case "2008":
                    ProcessFormR2008(htmlDoc, strPageIndex);
                    break;
                case "2009":
                    ProcessFormR2009(htmlDoc, strPageIndex);
                    break;
                case "2010":
                    ProcessFormR2010(htmlDoc, strPageIndex);
                    break;
                case "2011":
                    ProcessFormR2011(htmlDoc, strPageIndex);
                    break;
                case "2012":
                    ProcessFormR2012(htmlDoc, strPageIndex);
                    break;
                case "2013":
                    ProcessFormR2013(htmlDoc, strPageIndex);
                    break;
                
                //simkh april 2014
                case "2014":
                    ProcessFormR2014(htmlDoc, strPageIndex);
                    break;
                //simkh end
            }
        }

        private void FireSelElementEvent(mshtml.HTMLSelectElement selElement, string strEvent)
        {
            object sender = selElement as object;
            selElement.FireEvent(strEvent, ref sender);
        }

        private void FireInpElementEvent(mshtml.HTMLInputElement inpElement, string strEvent)
        {
            object sender = inpElement as object;
            inpElement.FireEvent(strEvent, ref sender);
        }

        private string SelectState(string strData)
        {
            strData = strData.ToUpper();
            switch (strData)
            {
                case "Johor":
                case "JOHOR": return "JOHOR";
                case "Kedah":
                case "KEDAH": return "KEDAH";
                case "Kelantan":
                case "KELANTAN": return "KELANTAN";
                case "WP Putrajaya":
                case "WP PUTRAJAYA": return "WP PUTRAJAYA";
                case "WP Labuan":
                case "WP LABUAN": return "WP LABUAN";
                case "Kuala Lumpur":
                case "WP Kuala Lumpur":
                case "WP KUALA LUMPUR":
                case "KUALA LUMPUR": return "WP KUALA LUMPUR";
                case "Melaka":
                case "MELAKA": return "MELAKA";
                case "Negeri Sembilan":
                case "NEGERI SEMBILAN": return "NEGERI SEMBILAN";
                case "Pahang":
                case "PAHANG": return "PAHANG";
                case "Perak":
                case "PERAK": return "PERAK";
                case "Perlis":
                case "PERLIS": return "PERLIS";
                case "Pulau Pinang":
                case "PULAU PINANG": return "PULAU PINANG";
                case "Sabah":
                case "SABAH": return "SABAH";
                case "Sarawak":
                case "SARAWAK": return "SARAWAK";
                case "Selangor":
                case "SELANGOR": return "SELANGOR";
                case "Terengganu":
                case "TERENGGANU": return "TERENGGANU";
                case "Wilayah Persekutuan":
                case "WILAYAH PERSEKUTUAN": return "WP KUALA LUMPUR";
                case "Penang":
                case "PENANG": return "PULAU PINANG";
                default: return "SILA PILIH NEGERI";
            }
        }

        private string[] TextSpliter(string strText, int intSize)
        {
            string[] arrText = new string[100];
            string strTempSub = "";
            int intTempSize = intSize;
            int intIndex = 0;


            for (int i = 0; i < strText.Length; i += strTempSub.Length)
            {
                strTempSub = strText.Substring(i);
                if (strTempSub.Length > intSize)
                {
                    if (strTempSub[intSize - 1] == ' ' || strTempSub[intSize] == ' ')
                    {
                        strTempSub = strTempSub.Substring(0, intTempSize);
                    }
                    else
                    {
                        for (int j = intSize - 1; j >= 0; j--)
                        {
                            if (strTempSub[j] == ' ')
                            {
                                strTempSub = strTempSub.Substring(0, j);
                                break;
                            }
                            if (j == 0)
                            {
                                strTempSub = strTempSub.Substring(0, intSize);
                            }
                        }
                    }
                }
                if (strTempSub.Length <= intSize)
                {
                    arrText[intIndex] = strTempSub;
                    intIndex++;
                }
            }
            return arrText;
        }
    }
}

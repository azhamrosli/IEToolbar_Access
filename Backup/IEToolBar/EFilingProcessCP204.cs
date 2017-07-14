using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace IEToolBar
{
    class EFilingProcessCP204
    {
        string strYA = "";
        string strTaxPayer = "";
        string strAuditor = "";
        string strRecKept = "";
        string strTaxAgent = "";

        public EFilingProcessCP204()
        {
        }

        public EFilingProcessCP204(string strTaxPayer, string strYA, string strAuditor, string strRecKept, string strTaxAgent)
        {
            this.strYA = strYA;
            this.strTaxPayer = strTaxPayer;
            this.strAuditor = strAuditor;
            this.strTaxAgent = strTaxAgent;
            this.strRecKept = strRecKept;
    
        }

        public void ProcessForm(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            ProcessFormCP204(htmlDoc, strPageIndex);
        }
         
        private void ProcessFormCP204(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            try
            {
                EFilingDALCP204 dal = new EFilingDALCP204(strTaxPayer, strYA, strAuditor, strTaxAgent);
                DataSet dsData = dal.GetFormDataCP204(strPageIndex);
                dal.CloseConn();
                Boolean boolPindaan = false;
                //Boolean boolNoRecord = false;

                if (dsData.Tables["P1_BORANG_CP204"].Rows.Count > 0)
                {
                    #region "INPUT"
                    foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
                    {
                        
                        //switch (strPageIndex)
                        //{
                            #region "Page 1"
                            //case "CP2042009Page1":

                                string[] arrCorrespondAddress = new string[3];
                                string[] arrCorrespondAddress2 = new string[3];
                                string[] arrTaxAgentAddress = new string[3];

                                    arrCorrespondAddress[0] = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[0].ToString();
                                    arrCorrespondAddress[1] = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[1].ToString();
                                    arrCorrespondAddress[2] = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[2].ToString();
                                    arrCorrespondAddress = TextSpliterAddress(arrCorrespondAddress, 30);

                                if (!String.IsNullOrEmpty(dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[6].ToString()))
                                {
                                    arrCorrespondAddress2[0] = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[6].ToString();
                                    arrCorrespondAddress2[1] = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[7].ToString();
                                    arrCorrespondAddress2[2] = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[8].ToString();
                                    arrCorrespondAddress2 = TextSpliterAddress(arrCorrespondAddress2, 30);
                                    boolPindaan = true;
                                }

                                arrTaxAgentAddress[0] = dsData.Tables["P1_FIRM"].Rows[0].ItemArray[0].ToString();
                                arrTaxAgentAddress[1] = dsData.Tables["P1_FIRM"].Rows[0].ItemArray[1].ToString();
                                arrTaxAgentAddress[2] = dsData.Tables["P1_FIRM"].Rows[0].ItemArray[2].ToString();
                                arrTaxAgentAddress = TextSpliterAddress(arrTaxAgentAddress, 30);

                                switch (inpElement.name)
                                {
                                    case "btnPindaan":
                                        FireInpElementEvent(inpElement, "onclick");                                         
                                        break;
                                    case "txtAlamat1":
                                        if (boolPindaan)
                                        {
                                            inpElement.value = arrCorrespondAddress2[0].ToUpper();
                                        }
                                        else
                                        {
                                            inpElement.value = arrCorrespondAddress[0].ToUpper();
                                        }
                                        break;
                                    case "txtAlamat2":
                                        if (boolPindaan)
                                        {
                                            inpElement.value = arrCorrespondAddress2[1].ToUpper();
                                        }
                                        else
                                        {
                                            inpElement.value = arrCorrespondAddress[1].ToUpper();
                                        }
                                        break;
                                    case "txtAlamat3":
                                        if (boolPindaan)
                                        {
                                            inpElement.value = arrCorrespondAddress2[2].ToUpper();
                                        }
                                        else
                                        {
                                            inpElement.value = arrCorrespondAddress[2].ToUpper();
                                        }
                                        break;
                                    case "txtPoskod":
                                        if (boolPindaan)
                                        {
                                            inpElement.value = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[9].ToString();
                                        }
                                        else
                                        {
                                            inpElement.value = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[3].ToString();
                                        }
                                        break;
                                    case "txtBandar":
                                        if (boolPindaan)
                                        {
                                            inpElement.value = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[10].ToString().ToUpper();
                                            FireInpElementEvent(inpElement, "onchange");
                                        }
                                        else
                                        {
                                            inpElement.value = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[4].ToString().ToUpper();
                                            FireInpElementEvent(inpElement, "onchange");
                                        }
                                        break;
                                    case "txtAnggaran_Cukai2":
                                        inpElement.value = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[12].ToString();
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                    case "txtTAXPAYER_EST_AMT":
                                        inpElement.value = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[12].ToString();
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                    case "TxtTkhMulaAkaun_Tahun":
                                        inpElement.value = dsData.Tables["P1_ACC_PERIOD"].Rows[0].ItemArray[2].ToString();
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                    case "TxtTkhTutupAkaun_Tahun":
                                        inpElement.value = dsData.Tables["P1_ACC_PERIOD"].Rows[0].ItemArray[5].ToString();
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                    case "txtTkhMulaAsas_Tahun":
                                        inpElement.value = dsData.Tables["P1_BASIS_PERIOD"].Rows[0].ItemArray[2].ToString();
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                    case "txtTkhTutupAsas_Tahun":
                                        inpElement.value = dsData.Tables["P1_BASIS_PERIOD"].Rows[0].ItemArray[5].ToString();
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                    //case "btnPindaanSME": //weihong
                                        //if (!String.IsNullOrEmpty(dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[23].ToString()))
                                        //{
                                        //    FireInpElementEvent(inpElement, "onclick");
                                        //}
                                        //break;
                                    case "txtTarikh_SyktBaru":
                                        inpElement.value = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[13].ToString();
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                    case "TxtThnPertama": //weihong Status SME FROM
                                        inpElement.value = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[23].ToString();
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                    case "TxtThnKedua": //weihong Status SME TO
                                        inpElement.value = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[24].ToString();
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                    case "txtTmph_Perakaunan1":
                                        inpElement.value = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[15].ToString();
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                    case "txtTmph_Perakaunan2":
                                        inpElement.value = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[16].ToString();
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                    case "txtTmph_Asas1":
                                        inpElement.value = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[17].ToString();
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                    case "txtTmph_Asas2":
                                        inpElement.value = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[18].ToString();
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                    case "txtTmph_Asas3":
                                        inpElement.value = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[19].ToString();
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                    case "txtTmph_Asas4":
                                        inpElement.value = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[20].ToString();
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                    case "txtTmph_Asas5":
                                        inpElement.value = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[21].ToString();
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                    case "txtTmph_asas6":
                                        inpElement.value = dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[22].ToString();
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                    case "txtAgAdd1":
                                        inpElement.value = arrTaxAgentAddress[0].ToUpper();
                                        break;
                                    case "txtAgAdd2":
                                        inpElement.value = arrTaxAgentAddress[1].ToUpper();
                                        break;
                                    case "txtAgAdd3":
                                        inpElement.value = arrTaxAgentAddress[2].ToUpper();
                                        break;
                                    case "txtAgPostcode":
                                        inpElement.value = dsData.Tables["P1_FIRM"].Rows[0].ItemArray[3].ToString();
                                        break;
                                    case "txtAgCity":
                                        inpElement.value = dsData.Tables["P1_FIRM"].Rows[0].ItemArray[4].ToString().ToUpper();
                                        break;
                                    case "txtAgTelephone":
                                        inpElement.value = dsData.Tables["P1_FIRM"].Rows[0].ItemArray[6].ToString();
                                        break;
                                    case "txtAgDaftar":
                                        inpElement.value = dsData.Tables["P1_FIRM"].Rows[0].ItemArray[7].ToString().ToUpper();
                                        break;
                                    case "txtAgEmail":
                                        inpElement.value = dsData.Tables["P1_FIRM"].Rows[0].ItemArray[8].ToString().ToUpper();
                                        break;
                                    case "txtNo_Telefon":
                                        inpElement.value = dsData.Tables["P1_FIRM"].Rows[0].ItemArray[6].ToString().ToUpper();
                                        break;
                                }
                                //break;
                            
                            #endregion
                        //}

                    }
                    //if (boolNoRecord)
                    //{
                    //    MessageBox.Show("No record found for current document.", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    #endregion

                    #region "SELECT"
                    foreach (mshtml.HTMLSelectElement selElement in htmlDoc.getElementsByTagName("select"))
                    {
                        //switch (strPageIndex)
                        //{
                            #region "Page 1"
                        //case "CP2042009Page1":
                                switch (selElement.name)
                                {
                                    case "ddlNegeri":
                                        if (boolPindaan)
                                        {
                                            selElement.value = SelectState(dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[11].ToString());
                                        }
                                        else
                                        {
                                            selElement.value = SelectState(dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[5].ToString());
                                        }
                                        break;
                                    case "ddlStatus_Akaun":
                                        if (dsData.Tables["P1_BORANG_CP204"].Rows[0].ItemArray[14].ToString() == "1")
                                        {
                                            selElement.value = "Ya";
                                            FireSelElementEvent(selElement, "onblur");
                                        }
                                        else
                                        {
                                            selElement.value = "Tidak";
                                            FireSelElementEvent(selElement, "onblur");
                                        }
                                        break;
                                    case "ddlAgState":
                                        selElement.value = SelectState(dsData.Tables["P1_FIRM"].Rows[0].ItemArray[5].ToString());
                                        break;

                                    case "ddlTkhMulaAkaun_Hari":
                                        selElement.value = dsData.Tables["P1_ACC_PERIOD"].Rows[0].ItemArray[0].ToString();
                                        break;

                                    case "ddlTkhMulaAkaun_Bulan":
                                        selElement.value = dsData.Tables["P1_ACC_PERIOD"].Rows[0].ItemArray[1].ToString();
                                        break;

                                    case "ddlTkhTutupAkaun_Hari":
                                        selElement.value = dsData.Tables["P1_ACC_PERIOD"].Rows[0].ItemArray[3].ToString();
                                        break;

                                    case "ddlTkhTutupAkaun_Bulan":
                                        selElement.value = dsData.Tables["P1_ACC_PERIOD"].Rows[0].ItemArray[4].ToString();
                                        break;

                                    case "ddlTkhMulaAsas_Hari":
                                        selElement.value = dsData.Tables["P1_BASIS_PERIOD"].Rows[0].ItemArray[0].ToString();
                                        break;

                                    case "ddlTkhMulaAsas_Bulan":
                                        selElement.value = dsData.Tables["P1_BASIS_PERIOD"].Rows[0].ItemArray[1].ToString();
                                        break;

                                    case "ddlTkhTutupAsas_Hari":
                                        selElement.value = dsData.Tables["P1_BASIS_PERIOD"].Rows[0].ItemArray[3].ToString();
                                        break;

                                    case "ddlTkhTutupAsas_Bulan":
                                        selElement.value = dsData.Tables["P1_BASIS_PERIOD"].Rows[0].ItemArray[4].ToString();
                                        break;
                                }
                                //break;
 
                            #endregion
                        //}
                    }
                    //if (boolNoRecord)
                    //{
                    //    MessageBox.Show("No record found for current document.", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    #endregion
                }
                else
                {
                    MessageBox.Show("No record found for current document.", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
            string[] arrText = new string[120];
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

        private string[] TextSpliterAddress(string[] strText, int intSize)
        {
            string[] arrText = new string[120];


            for (int intIndex = 0; intIndex < strText.Length; intIndex++)
            {
                if (strText[intIndex].Length > intSize)
                {
                    if (((!strText[intIndex].Trim().EndsWith(",")) &&
                        (intIndex + 1 < (strText.Length))) &&
                         !(intIndex == strText.Length - 1))
                    {
                        strText[intIndex] = strText[intIndex] + ",";
                        if (strText[intIndex].Substring(0, intSize).LastIndexOf(' ') > 0)
                        {
                            strText[intIndex + 1] = strText[intIndex].Substring(
                                strText[intIndex].Substring(0, intSize).LastIndexOf(' ') + 1) + strText[intIndex + 1];

                            arrText[intIndex] = strText[intIndex].Substring(0,
                                strText[intIndex].Substring(0, intSize).LastIndexOf(' '));
                        }
                        else
                        {
                            strText[intIndex + 1] = strText[intIndex].Substring(intSize + 1) + strText[intIndex + 1];
                            arrText[intIndex] = strText[intIndex].Substring(0, intSize);
                        }
                    }
                    else
                    {
                        arrText[intIndex] = strText[intIndex].ToString();
                    }
                }
                else
                {
                    if (((!strText[intIndex].Trim().EndsWith(",")) &&
                        !(intIndex == strText.Length - 1)) &&
                        !(String.IsNullOrEmpty(strText[intIndex + 1])))
                    {
                        arrText[intIndex] = strText[intIndex].ToString() + ",";
                    }
                    else
                    {
                        arrText[intIndex] = strText[intIndex].ToString();
                    }
                }
            }
            return arrText;
        }
    }
}

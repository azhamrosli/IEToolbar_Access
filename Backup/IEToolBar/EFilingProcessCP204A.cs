using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace IEToolBar
{
    class EFilingProcessCP204A
    {
        string strYA = "";
        string strTaxPayer = "";
        string strAuditor = "";
        string strRecKept = "";
        string strTaxAgent = "";
        string strCP204AVersion = "";

        public EFilingProcessCP204A()
        {
        }


        public EFilingProcessCP204A(string strTaxPayer, string strYA, string strAuditor, string strRecKept, string strTaxAgent, string strCP204AVersion)
        {
            this.strYA = strYA;
            this.strTaxPayer = strTaxPayer;
            this.strAuditor = strAuditor;
            this.strTaxAgent = strTaxAgent;
            this.strRecKept = strRecKept;
            this.strCP204AVersion = strCP204AVersion;
        }

        public void ProcessForm(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            ProcessFormCP204A(htmlDoc, strPageIndex);
        }
         
        private void ProcessFormCP204A(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            try
            {
                EFilingDALCP204A dal = new EFilingDALCP204A(strTaxPayer, strYA, strAuditor, strTaxAgent, strCP204AVersion);
                DataSet dsData = dal.GetFormDataCP204A(strPageIndex);
                dal.CloseConn();
                Boolean boolPindaan = false;

                if (dsData.Tables["P1_BORANG_CP204A"].Rows.Count > 0)
                {
                    #region "INPUT"
                    foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
                    {

                            #region "Page 1"

                                string[] arrCorrespondAddress = new string[3];
                                string[] arrCorrespondAddress2 = new string[3];
                                string[] arrTaxAgentAddress = new string[3];

                                    arrCorrespondAddress[0] = dsData.Tables["P1_BORANG_CP204A"].Rows[0].ItemArray[0].ToString();
                                    arrCorrespondAddress[1] = dsData.Tables["P1_BORANG_CP204A"].Rows[0].ItemArray[1].ToString();
                                    arrCorrespondAddress[2] = dsData.Tables["P1_BORANG_CP204A"].Rows[0].ItemArray[2].ToString();
                                    arrCorrespondAddress = TextSpliterAddress(arrCorrespondAddress, 30);

                                if (!String.IsNullOrEmpty(dsData.Tables["P1_BORANG_CP204A"].Rows[0].ItemArray[6].ToString()))
                                {
                                    arrCorrespondAddress2[0] = dsData.Tables["P1_BORANG_CP204A"].Rows[0].ItemArray[6].ToString();
                                    arrCorrespondAddress2[1] = dsData.Tables["P1_BORANG_CP204A"].Rows[0].ItemArray[7].ToString();
                                    arrCorrespondAddress2[2] = dsData.Tables["P1_BORANG_CP204A"].Rows[0].ItemArray[8].ToString();
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
                                            inpElement.value = dsData.Tables["P1_BORANG_CP204A"].Rows[0].ItemArray[9].ToString();
                                        }
                                        else
                                        {
                                            inpElement.value = dsData.Tables["P1_BORANG_CP204A"].Rows[0].ItemArray[3].ToString();
                                        }
                                        break;
                                    case "txtBandar":
                                        if (boolPindaan)
                                        {
                                            inpElement.value = dsData.Tables["P1_BORANG_CP204A"].Rows[0].ItemArray[10].ToString().ToUpper();
                                            FireInpElementEvent(inpElement, "onchange");
                                        }
                                        else
                                        {
                                            inpElement.value = dsData.Tables["P1_BORANG_CP204A"].Rows[0].ItemArray[4].ToString().ToUpper();
                                            FireInpElementEvent(inpElement, "onchange");
                                        }
                                        break;
                                    case "txtPindaanKe":
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_BORANG_CP204A"].Rows[0].ItemArray[25].ToString()))
                                        {
                                            if (dsData.Tables["P1_BORANG_CP204A"].Rows[0].ItemArray[25].ToString() == "T")
                                            {
                                                inpElement.value = "6";
                                            }
                                            else
                                            {
                                                inpElement.value = "9";
                                            }
                                        }
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                    //case "rbrevmonth_0":
                                    //    inpElement.value = dsData.Tables["P1_BORANG_CP204A"].Rows[0].ItemArray[13].ToString();
                                    //    FireInpElementEvent(inpElement, "onclick");
                                    //    break;
                                    //case "rbrevmonth_1":
                                    //    inpElement.value = dsData.Tables["P1_BORANG_CP204A"].Rows[0].ItemArray[23].ToString();
                                    //    FireInpElementEvent(inpElement, "onclick");
                                    //    break;
                                    case "txtTmph_Perakaunan1":
                                        inpElement.value = dsData.Tables["P1_BORANG_CP204A"].Rows[0].ItemArray[15].ToString();
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                    case "txtTmph_Perakaunan2":
                                        inpElement.value = dsData.Tables["P1_BORANG_CP204A"].Rows[0].ItemArray[16].ToString();
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                    case "txtTmph_Asas1":
                                        inpElement.value = dsData.Tables["P1_BORANG_CP204A"].Rows[0].ItemArray[17].ToString();
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                    case "txtTmph_Asas2":
                                        inpElement.value = dsData.Tables["P1_BORANG_CP204A"].Rows[0].ItemArray[18].ToString();
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                    case "txtAnggaran":
                                        inpElement.value = dsData.Tables["P1_BORANG_CP204A"].Rows[0].ItemArray[27].ToString();
                                        FireInpElementEvent(inpElement, "onblur");
                                        break;
                                }
                            #endregion
                    }
                    #endregion

                    #region "SELECT"
                    foreach (mshtml.HTMLSelectElement selElement in htmlDoc.getElementsByTagName("select"))
                    {
                            #region "Page 1"
                                switch (selElement.name)
                                {
                                    case "ddlNegeri":
                                        if (boolPindaan)
                                        {
                                            selElement.value = SelectState(dsData.Tables["P1_BORANG_CP204A"].Rows[0].ItemArray[11].ToString());
                                        }
                                        else
                                        {
                                            selElement.value = SelectState(dsData.Tables["P1_BORANG_CP204A"].Rows[0].ItemArray[5].ToString());
                                        }
                                        break;
                                }
                             #endregion
                    }
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

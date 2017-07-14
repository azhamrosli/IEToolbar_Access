using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BandObjectsLib;
using System.Runtime.InteropServices;
using System.IO;

namespace IEToolBar
{
    [Guid("AE07101B-46D4-4a98-AF68-0333EA26E113")]
    [BandObject("TAXcom E-Filing Toolbar", BandObjectStyle.ExplorerToolbar, HelpText = "TAXcom E-Filing Toolbar")]
    public partial class ucToolBar : BandObject 
    {
        public string strTaxPayer;
        public string strYA;
        public string strPosition;
        public string strAuditor;
        public string strRecKept;
        public string strFormType;
        //NGOHCS 2009
        public string strTaxAgent;
        public string strCP204AVersion;

        int intIndex = 0;

        public ucToolBar()
        {
            InitializeComponent();
        }

        public string SelectedTaxPayer
        {
            set { this.SelectedTaxPayertoolStripLabel.Text = value; }
        }

        //private void ProcessFormC(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        //{
        //    try
        //    {
        //        EFilingDAL dal = new EFilingDAL(strTaxPayer, strYA, strAuditor);
        //        DataSet dsData = dal.GetFormData(strPageIndex);
        //        dal.CloseConn();
        //        int intcount = 0;
        //        Boolean boolLocal = true;
        //        string strComparator;
        //        Boolean boolNoRecord = false;

        //        foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
        //        {
        //            switch (strPageIndex)
        //            {
        //                #region "Page 1"
        //                case "C2008Page1":
        //                    switch (inpElement.name)
        //                    {
        //                        //case "ctl00$ContentPlaceHolder1$txtNama_Sykt":
        //                        //    inpElement.value = dtData1.Rows[0].ItemArray[0].ToString();
        //                        //    break;
        //                        //case "ctl00$ContentPlaceHolder1$txtNo_Rujukan_Cukai":
        //                        //    inpElement.value = dtData1.Rows[0].ItemArray[1].ToString();
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtNo_Majikan":
        //                            inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[2].ToString();
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$HideDate":
        //                        //    inpElement.value = dtData1.Rows[0].ItemArray[3].ToString();
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtNo_Daftar":
        //                            inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[3].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtTarikh_Mula":
        //                            inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[4].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtTarikh_Tutup":
        //                            inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[5].ToString();
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$HideDb_RKT_RKS":
        //                        //    inpElement.value = dtData1.Rows[0].ItemArray[6].ToString();
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$rbdaftar":
        //                            if (intcount == 0)
        //                            {
        //                                if (SelectState(dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()) != "SILA PILIH NEGERI")
        //                                {
        //                                    inpElement.@checked = true;
        //                                    FireInpElementEvent(inpElement, "OnClick");
        //                                    boolLocal = true;
        //                                }
        //                                intcount++;
        //                            }
        //                            else
        //                            {
        //                                if (SelectState(dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()) == "SILA PILIH NEGERI")
        //                                {
        //                                    inpElement.@checked = true;
        //                                    FireInpElementEvent(inpElement, "OnClick");
        //                                    boolLocal = false;
        //                                }
        //                                intcount = 0;
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtO2_alamat1":
        //                            inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[6].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtO2_alamat2":
        //                            inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[7].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtO2_alamat3":
        //                            inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtO2_poskod":
        //                            inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtO2_bandar":
        //                            inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtO2_Negeri":
        //                            if (!boolLocal)
        //                                inpElement.value = dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[4].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtO3":
        //                            inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[11].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$rbsurat":
        //                            if (intcount == 0)
        //                            {
        //                                if (SelectState(dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()) != "SILA PILIH NEGERI")
        //                                {
        //                                    inpElement.@checked = true;
        //                                    FireInpElementEvent(inpElement, "OnClick");
        //                                    boolLocal = true;
        //                                }
        //                                intcount++;
        //                            }
        //                            else
        //                            {
        //                                if (SelectState(dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()) == "SILA PILIH NEGERI")
        //                                {
        //                                    inpElement.@checked = true;
        //                                    FireInpElementEvent(inpElement, "OnClick");
        //                                    boolLocal = false;
        //                                }
        //                                intcount = 0;
        //                            }
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$rbsurat":
        //                        //    break;
        //                        //case "ctl00$ContentPlaceHolder1$btnO4_daftar":
        //                        //    inpElement.value = dtData1.Rows[0].ItemArray[14].ToString();
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtO4_alamat1":
        //                            inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[12].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtO4_alamat2":
        //                            inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[13].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtO4_alamat3":
        //                            inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[14].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtO4_poskod":
        //                            inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[15].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtO4_bandar":
        //                            inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[16].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtO4_Negeri":
        //                            if (!boolLocal)
        //                                inpElement.value = dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[5].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$rbpremis":
        //                            if (intcount == 0)
        //                            {
        //                                if (SelectState(dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[6].ToString()) != "SILA PILIH NEGERI")
        //                                {
        //                                    inpElement.@checked = true;
        //                                    FireInpElementEvent(inpElement, "OnClick");
        //                                    boolLocal = true;
        //                                }
        //                                intcount++;
        //                            }
        //                            else
        //                            {
        //                                if (SelectState(dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[6].ToString()) == "SILA PILIH NEGERI")
        //                                {
        //                                    inpElement.@checked = true;
        //                                    FireInpElementEvent(inpElement, "OnClick");
        //                                    boolLocal = false;
        //                                }
        //                                intcount = 0;
        //                            }
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$rbpremis":
        //                        //    break;
        //                        //case "ctl00$ContentPlaceHolder1$btnO5_daftar":
        //                        //    inpElement.value = dtData1.Rows[0].ItemArray[19].ToString();
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtO5_alamat1":
        //                            inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[17].ToString();
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$btnO5_surat":
        //                        //    inpElement.value = dtData1.Rows[0].ItemArray[25].ToString();
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtO5_alamat2":
        //                            inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[18].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtO5_alamat3":
        //                            inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[19].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtO5_poskod":
        //                            inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[20].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtO5_bandar":
        //                            inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[21].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtO5_Negeri":
        //                            if (!boolLocal)
        //                                inpElement.value = dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[6].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtO7":
        //                            inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[22].ToString();
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$btnSimpan":
        //                        //    inpElement.value = dtData1.Rows[0].ItemArray[31].ToString();
        //                        //    break;
        //                    }
        //                    break;
        //                #endregion

        //                #region "Page 2"
        //                case "C2008Page2":
        //                    if (dsData.Tables["P2_INPUT_DIRECTORS"].Rows.Count > 0)
        //                    {
        //                        switch (inpElement.name)
        //                        {
        //                            case "ctl00$ContentPlaceHolder1$txtO10_Nama1":
        //                                inpElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[0].ItemArray[0].ToString();
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO11_NoKP1":
        //                                inpElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[0].ItemArray[1].ToString();
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO12_NoTel1":
        //                                inpElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[0].ItemArray[2].ToString();
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO13_Norujukan1":
        //                                inpElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[0].ItemArray[4].ToString();
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO14_ekuiti1":
        //                                inpElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[0].ItemArray[5].ToString();
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO15_gaji1":
        //                                inpElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[0].ItemArray[6].ToString();
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO16_elaun1":
        //                                inpElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[0].ItemArray[7].ToString();
        //                                break;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        switch (inpElement.name)
        //                        {
        //                            case "ctl00$ContentPlaceHolder1$txtO10_Nama1":
        //                                inpElement.value = "";
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO11_NoKP1":
        //                                inpElement.value = "";
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO12_NoTel1":
        //                                inpElement.value = "";
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO13_Norujukan1":
        //                                inpElement.value = "";
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO14_ekuiti1":
        //                                inpElement.value = "";
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO15_gaji1":
        //                                inpElement.value = "";
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO16_elaun1":
        //                                inpElement.value = "";
        //                                break;
        //                        }
        //                    }
        //                    if (dsData.Tables["P2_INPUT_DIRECTORS"].Rows.Count > 1)
        //                    {
        //                        switch (inpElement.name)
        //                        {
        //                            case "ctl00$ContentPlaceHolder1$txtO10_Nama2":
        //                                inpElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[1].ItemArray[0].ToString();
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO11_NoKP2":
        //                                inpElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[1].ItemArray[1].ToString();
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO12_NoTel2":
        //                                inpElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[1].ItemArray[2].ToString();
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO13_Norujukan2":
        //                                inpElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[1].ItemArray[4].ToString();
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO14_ekuiti2":
        //                                inpElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[1].ItemArray[5].ToString();
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO15_gaji2":
        //                                inpElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[1].ItemArray[6].ToString();
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO16_elaun2":
        //                                inpElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[1].ItemArray[7].ToString();
        //                                break;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        switch (inpElement.name)
        //                        {
        //                            case "ctl00$ContentPlaceHolder1$txtO10_Nama2":
        //                                inpElement.value = "";
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO11_NoKP2":
        //                                inpElement.value = "";
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO12_NoTel2":
        //                                inpElement.value = "";
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO13_Norujukan2":
        //                                inpElement.value = "";
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO14_ekuiti2":
        //                                inpElement.value = "";
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO15_gaji2":
        //                                inpElement.value = "";
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO16_elaun2":
        //                                inpElement.value = "";
        //                                break;
        //                        }
        //                    }
        //                    if (dsData.Tables["P2_INPUT_DIRECTORS"].Rows.Count > 2)
        //                    {
        //                        switch (inpElement.name)
        //                        {
        //                            case "ctl00$ContentPlaceHolder1$txtO10_Nama3":
        //                                inpElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[2].ItemArray[0].ToString();
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO11_NoKP3":
        //                                inpElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[2].ItemArray[1].ToString();
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO12_NoTel3":
        //                                inpElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[2].ItemArray[2].ToString();
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO13_Norujukan3":
        //                                inpElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[2].ItemArray[4].ToString();
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO14_ekuiti3":
        //                                inpElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[2].ItemArray[5].ToString();
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO15_gaji3":
        //                                inpElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[2].ItemArray[6].ToString();
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO16_elaun3":
        //                                inpElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[2].ItemArray[7].ToString();
        //                                break;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        switch (inpElement.name)
        //                        {
        //                            case "ctl00$ContentPlaceHolder1$txtO10_Nama3":
        //                                inpElement.value = "";
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO11_NoKP3":
        //                                inpElement.value = "";
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO12_NoTel3":
        //                                inpElement.value = "";
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO13_Norujukan3":
        //                                inpElement.value = "";
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO14_ekuiti3":
        //                                inpElement.value = "";
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO15_gaji3":
        //                                inpElement.value = "";
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtO16_elaun3":
        //                                inpElement.value = "";
        //                                break;
        //                        }
        //                    }
        //                    break;
        //                #endregion

        //                case "C2008Page4":
        //                    switch (inpElement.name)
        //                    {
        //                        case "ctl00$ContentPlaceHolder1$txtL1":
        //                            inpElement.value = dsData.Tables["P4_BUSINESS_CODE"].Rows[0].ItemArray[0].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL2":
        //                            strComparator = dsData.Tables["P4_PLFST_SALES"].Rows[0].ItemArray[0].ToString() == "" ? inpElement.value = "0" : inpElement.value = dsData.Tables["P4_PLFST_SALES"].Rows[0].ItemArray[0].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL3":
        //                            strComparator = dsData.Tables["P4_PLFST_OPENSTOCK"].Rows[0].ItemArray[0].ToString() == "" ? inpElement.value = "0" : inpElement.value = dsData.Tables["P4_PLFST_OPENSTOCK"].Rows[0].ItemArray[0].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL4":
        //                            strComparator = dsData.Tables["P4_PLFST_PURCHASE"].Rows[0].ItemArray[0].ToString() == "" ? inpElement.value = "0" : inpElement.value = dsData.Tables["P4_PLFST_PURCHASE"].Rows[0].ItemArray[0].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL4A":
        //                            long lngL4ATotal = 0;
        //                            strComparator = dsData.Tables["P4_EXP_DEPRECIATE"].Rows[0].ItemArray[0].ToString().Trim() == "" ? strComparator = "0" : strComparator = dsData.Tables["P4_EXP_DEPRECIATE"].Rows[0].ItemArray[0].ToString().Replace(",", "");
        //                            lngL4ATotal = lngL4ATotal + long.Parse(strComparator);
        //                            strComparator = dsData.Tables["P4_EXP_ALLOW"].Rows[0].ItemArray[0].ToString() == "" ? strComparator = "0" : strComparator = dsData.Tables["P4_EXP_ALLOW"].Rows[0].ItemArray[0].ToString().Replace(",", "");
        //                            lngL4ATotal = lngL4ATotal + long.Parse(strComparator);
        //                            strComparator = dsData.Tables["P4_EXP_NONALLOW"].Rows[0].ItemArray[0].ToString() == "" ? strComparator = "0" : strComparator = dsData.Tables["P4_EXP_NONALLOW"].Rows[0].ItemArray[0].ToString().Replace(",", "");
        //                            lngL4ATotal = lngL4ATotal + long.Parse(strComparator);
        //                            inpElement.value = lngL4ATotal.ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL5":
        //                            strComparator = dsData.Tables["P4_PLFST_CLOSESTOCK"].Rows[0].ItemArray[0].ToString() == "" ? inpElement.value = "0" : inpElement.value = dsData.Tables["P4_PLFST_CLOSESTOCK"].Rows[0].ItemArray[0].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtL6":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        //case "ctl00$ContentPlaceHolder1$txtL7":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtL8":
        //                            long lngL8=0;
        //                            long OthrIn = 0;                                   
        //                            strComparator = dsData.Tables["P4_PLFST_SALES2"].Rows[0].ItemArray[0].ToString() == "" ? strComparator = "0" : strComparator = dsData.Tables["P4_PLFST_SALES2"].Rows[0].ItemArray[0].ToString().Replace(",", "");
        //                            lngL8 = lngL8 + long.Parse(strComparator);

        //                            strComparator = dsData.Tables["P4_PLFST_OPENSTOCK2"].Rows[0].ItemArray[0].ToString() == "" ? strComparator = "0" : strComparator = dsData.Tables["P4_PLFST_OPENSTOCK2"].Rows[0].ItemArray[0].ToString().Replace(",", "");
        //                            lngL8 = lngL8 - long.Parse(strComparator);
        //                            strComparator = dsData.Tables["P4_PLFST_PURCHASE2"].Rows[0].ItemArray[0].ToString() == "" ? strComparator = "0" : strComparator = dsData.Tables["P4_PLFST_PURCHASE2"].Rows[0].ItemArray[0].ToString().Replace(",", "");
        //                            lngL8 = lngL8 - long.Parse(strComparator);
        //                            strComparator = dsData.Tables["P4_EXP_DEPRECIATE2"].Rows[0].ItemArray[0].ToString() == "" ? strComparator = "0" : strComparator = dsData.Tables["P4_EXP_DEPRECIATE2"].Rows[0].ItemArray[0].ToString().Replace(",", "");
        //                            lngL8 = lngL8 - long.Parse(strComparator);
        //                            strComparator = dsData.Tables["P4_EXP_ALLOW2"].Rows[0].ItemArray[0].ToString() == "" ? strComparator = "0" : strComparator = dsData.Tables["P4_EXP_ALLOW2"].Rows[0].ItemArray[0].ToString().Replace(",", "");
        //                            lngL8 = lngL8 - long.Parse(strComparator);
        //                            strComparator = dsData.Tables["P4_EXP_NONALLOW2"].Rows[0].ItemArray[0].ToString() == "" ? strComparator = "0" : strComparator = dsData.Tables["P4_EXP_NONALLOW2"].Rows[0].ItemArray[0].ToString().Replace(",", "");
        //                            lngL8 = lngL8 - long.Parse(strComparator);
                                   
        //                            strComparator = dsData.Tables["P4_PLFST_CLOSESTOCK2"].Rows[0].ItemArray[0].ToString() == "" ? strComparator = "0" : strComparator = dsData.Tables["P4_PLFST_CLOSESTOCK2"].Rows[0].ItemArray[0].ToString().Replace(",", "");
        //                            lngL8 = lngL8 + long.Parse(strComparator);

        //                            if (lngL8 < 0)
        //                            {
        //                                lngL8 = 0;
                                    
        //                            }

        //                            //lngL8 = long.Parse(dsData.Tables["P4_PROFIT_LOSS"].Rows[0].ItemArray[0].ToString().Replace(",", "")); // other business income

        //                            OthrIn = long.Parse(dsData.Tables["P4_PROFIT_LOSS"].Rows[0].ItemArray[0].ToString().Replace(",", "")); // other business income
        //                            lngL8 = lngL8 + OthrIn;
        //                            inpElement.value = lngL8.ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
                                  
        //                            //if (lngL8 < 0)
        //                            //{
        //                            //    lngL8 = 0;
        //                            //    inpElement.value = lngL8.ToString();
        //                            //    FireInpElementEvent(inpElement, "OnBlur"); 
        //                            //}
        //                            //else
        //                            //{
        //                            //    inpElement.value = lngL8.ToString();
        //                            //    FireInpElementEvent(inpElement, "OnBlur"); 
        //                            //}
        //                            //break;



        //                        case "ctl00$ContentPlaceHolder1$txtL9":
        //                            long lngL9Total = 0;
        //                            //if (dsData.Tables["P4_EXEMPT_DIVIDEND"].Rows.Count > 0)
        //                            //    lngL9Total = lngL9Total + long.Parse(dsData.Tables["P4_EXEMPT_DIVIDEND"].Rows[0].ItemArray[0].ToString().Replace(",", ""));

        //                            if (dsData.Tables["P4_EXEMPT_DIVIDEND"].Rows.Count > 0)
        //                            {
        //                                for (int i = 0; i < dsData.Tables["P4_EXEMPT_DIVIDEND"].Rows.Count; i++)
        //                                {
        //                                    lngL9Total = lngL9Total + long.Parse(dsData.Tables["P4_EXEMPT_DIVIDEND"].Rows[i].ItemArray[0].ToString().Replace(",", ""));
                                        
        //                                }
        //                            }
        //                            lngL9Total = lngL9Total + long.Parse(dsData.Tables["P4_PROFIT_LOSS"].Rows[0].ItemArray[1].ToString().Replace(",", ""));
        //                            inpElement.value = lngL9Total.ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;

                                  
        //                        case "ctl00$ContentPlaceHolder1$txtL10":
        //                            long lngL10Total = 0;
        //                            lngL10Total = lngL10Total + long.Parse(dsData.Tables["P4_PROFIT_LOSS"].Rows[0].ItemArray[2].ToString().Replace(",", ""));
                                   
        //                            //if (dsData.Tables["P4_EXEMPT_DIVIDEND"].Rows.Count > 0)
        //                            //    lngL10Total = lngL10Total - long.Parse(dsData.Tables["P4_EXEMPT_DIVIDEND"].Rows[0].ItemArray[0].ToString().Replace(",", ""));


        //                            if (dsData.Tables["P4_EXEMPT_DIVIDEND"].Rows.Count > 0)
        //                            {
        //                                for (int i = 0; i < dsData.Tables["P4_EXEMPT_DIVIDEND"].Rows.Count; i++)
        //                                {
        //                                    lngL10Total = lngL10Total - long.Parse(dsData.Tables["P4_EXEMPT_DIVIDEND"].Rows[i].ItemArray[0].ToString().Replace(",", ""));
        //                                }
        //                            }
                                    
                                    
                                    
        //                            inpElement.value = lngL10Total.ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;




        //                        case "ctl00$ContentPlaceHolder1$txtL11":
        //                            long lngL11Total = 0;
        //                            lngL11Total = lngL11Total + long.Parse(dsData.Tables["P4_PROFIT_LOSS"].Rows[0].ItemArray[3].ToString().Replace(",", ""));
        //                            lngL11Total = lngL11Total + long.Parse(dsData.Tables["P4_PROFIT_LOSS"].Rows[0].ItemArray[4].ToString().Replace(",", ""));
        //                            inpElement.value = lngL11Total.ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL12":
        //                            inpElement.value = dsData.Tables["P4_PROFIT_LOSS"].Rows[0].ItemArray[5].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL12A":
        //                            inpElement.value = dsData.Tables["P4_PROFIT_LOSS"].Rows[0].ItemArray[6].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL13":
        //                            inpElement.value = dsData.Tables["P4_PROFIT_LOSS"].Rows[0].ItemArray[7].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL14":
        //                            inpElement.value = dsData.Tables["P4_PROFIT_LOSS"].Rows[0].ItemArray[8].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL14A":
        //                            inpElement.value = dsData.Tables["P4_PROFIT_LOSS"].Rows[0].ItemArray[9].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL15":
        //                            inpElement.value = dsData.Tables["P4_PROFIT_LOSS"].Rows[0].ItemArray[10].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL16":
        //                            inpElement.value = dsData.Tables["P4_PROFIT_LOSS"].Rows[0].ItemArray[11].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL17":
        //                            inpElement.value = dsData.Tables["P4_PROFIT_LOSS"].Rows[0].ItemArray[12].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL18":
        //                            inpElement.value = dsData.Tables["P4_PROFIT_LOSS"].Rows[0].ItemArray[13].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL19":
        //                            inpElement.value = dsData.Tables["P4_PROFIT_LOSS"].Rows[0].ItemArray[14].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL20":
        //                            inpElement.value = dsData.Tables["P4_PROFIT_LOSS"].Rows[0].ItemArray[15].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL21":
        //                            inpElement.value = dsData.Tables["P4_PROFIT_LOSS"].Rows[0].ItemArray[16].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtL22":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtL23":
        //                            inpElement.value = dsData.Tables["P4_PROFIT_LOSS"].Rows[0].ItemArray[17].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL24":
        //                            inpElement.value = dsData.Tables["P4_PROFIT_LOSS"].Rows[0].ItemArray[18].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL25":
        //                            if (dsData.Tables["P4_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P4_BUSINESS_SOURCE"].Rows[0].ItemArray[0].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL26":
        //                            if (dsData.Tables["P4_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P4_BUSINESS_SOURCE"].Rows[0].ItemArray[1].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL27":
        //                            if (dsData.Tables["P4_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P4_BUSINESS_SOURCE"].Rows[0].ItemArray[2].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL28":
        //                            if (dsData.Tables["P4_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P4_BUSINESS_SOURCE"].Rows[0].ItemArray[3].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtL29":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtL29A":
        //                            if (dsData.Tables["P4_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P4_BUSINESS_SOURCE"].Rows[0].ItemArray[4].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL30":
        //                            if (dsData.Tables["P4_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P4_BUSINESS_SOURCE"].Rows[0].ItemArray[5].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL31":
        //                            if (dsData.Tables["P4_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P4_BUSINESS_SOURCE"].Rows[0].ItemArray[6].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL32":
        //                            if (dsData.Tables["P4_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P4_BUSINESS_SOURCE"].Rows[0].ItemArray[7].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL32A":
        //                            if (dsData.Tables["P4_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P4_BUSINESS_SOURCE"].Rows[0].ItemArray[8].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL33":
        //                            if (dsData.Tables["P4_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P4_BUSINESS_SOURCE"].Rows[0].ItemArray[9].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL34":
        //                            if (dsData.Tables["P4_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P4_BUSINESS_SOURCE"].Rows[0].ItemArray[10].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL35":
        //                            if (dsData.Tables["P4_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P4_BUSINESS_SOURCE"].Rows[0].ItemArray[11].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtL36":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        //case "ctl00$ContentPlaceHolder1$txtL37":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtL38":
        //                            if (dsData.Tables["P4_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P4_BUSINESS_SOURCE"].Rows[0].ItemArray[12].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL39":
        //                            if (dsData.Tables["P4_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P4_BUSINESS_SOURCE"].Rows[0].ItemArray[13].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL40":
        //                            if (dsData.Tables["P4_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P4_BUSINESS_SOURCE"].Rows[0].ItemArray[14].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL41":
        //                            if (dsData.Tables["P4_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P4_BUSINESS_SOURCE"].Rows[0].ItemArray[15].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL42":
        //                            if (dsData.Tables["P4_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P4_BUSINESS_SOURCE"].Rows[0].ItemArray[16].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtL43":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtL44":
        //                            if (dsData.Tables["P4_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P4_BUSINESS_SOURCE"].Rows[0].ItemArray[17].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtL45":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtL46":
        //                            if (dsData.Tables["P4_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P4_BUSINESS_SOURCE"].Rows[0].ItemArray[18].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL47":
        //                            if (dsData.Tables["P4_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P4_BUSINESS_SOURCE"].Rows[0].ItemArray[19].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtL48":
        //                            if (dsData.Tables["P4_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P4_BUSINESS_SOURCE"].Rows[0].ItemArray[20].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtL49":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        //case "ctl00$ContentPlaceHolder1$txtL50":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                    }
        //                    break;
        //                case "C2008Page5":
        //                    if (dsData.Tables.Contains("P5_INVEST"))
        //                    {
        //                        switch (inpElement.name)
        //                        {
        //                            case "ctl00$ContentPlaceHolder1$txtC1_kod":
        //                                inpElement.value = dsData.Tables["P5_INVEST_BC_CODE"].Rows[0].ItemArray[0].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC1_amaun":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC2_kod":
        //                                inpElement.value = "";
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC2_amaun":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC3_kod":
        //                                inpElement.value = "";
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC3_amaun":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC4_kod":
        //                                inpElement.value = "";
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC4_amaun":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC5_kod":
        //                                inpElement.value = "";
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC5_amaun":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC6_Rujukan":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC6_amaun":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC7_Rujukan":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC7_amaun":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC8_Rujukan":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC8_amaun":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC9_Rujukan":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC9_amaun":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC10_Rujukan":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC10_amaun":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC11":
        //                            //    inpElement.value="1";
        //                            //    break;
        //                            case "ctl00$ContentPlaceHolder1$txtC12":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC13":
        //                            //    inpElement.value="1";
        //                            //    break;
        //                            case "ctl00$ContentPlaceHolder1$txtC14":
        //                                inpElement.value = dsData.Tables["P5_INVEST"].Rows[0].ItemArray[0].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC15":
        //                                //modify by csNgoh C2008.6(SU6)
        //                                long lngC15Total = 0;

        //                                if (dsData.Tables["P5_INVEST"].Rows.Count > 0)
        //                                {
        //                                    strComparator = dsData.Tables["P5_INVEST"].Rows[0].ItemArray[1].ToString().Replace(",", "");
        //                                    lngC15Total = lngC15Total + long.Parse(strComparator);
        //                                    strComparator = dsData.Tables["P5_INVEST"].Rows[0].ItemArray[8].ToString().Replace(",", "");
        //                                    lngC15Total = lngC15Total + long.Parse(strComparator);
        //                                }
        //                                inpElement.value = lngC15Total.ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC16":
        //                                inpElement.value = dsData.Tables["P5_INVEST"].Rows[0].ItemArray[9].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC17":
        //                                inpElement.value = dsData.Tables["P5_INVEST"].Rows[0].ItemArray[10].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC18":
        //                            //    inpElement.value="1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC19":
        //                            //    inpElement.value="1";
        //                            //    break;
        //                            case "ctl00$ContentPlaceHolder1$txtC20":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC21":
        //                            //    inpElement.value="1";
        //                            //    break;
        //                            case "ctl00$ContentPlaceHolder1$txtC22":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC23":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC24":
        //                                inpElement.value = dsData.Tables["P5_INVEST"].Rows[0].ItemArray[2].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC25":
        //                            //    inpElement.value="1";
        //                            //    break;
        //                            case "ctl00$ContentPlaceHolder1$txtC26":
        //                                inpElement.value = dsData.Tables["P5_INVEST"].Rows[0].ItemArray[3].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC27":
        //                                inpElement.value = dsData.Tables["P5_INVEST"].Rows[0].ItemArray[4].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC28":
        //                            //    inpElement.value="1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC29":
        //                            //    inpElement.value="1";
        //                            //    break;
        //                            case "ctl00$ContentPlaceHolder1$txtC30":
        //                                inpElement.value = dsData.Tables["P5_INVEST"].Rows[0].ItemArray[5].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC31":
        //                                inpElement.value = dsData.Tables["P5_INVEST"].Rows[0].ItemArray[6].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC32":
        //                            //    inpElement.value="1";
        //                            //    break;
        //                            case "ctl00$ContentPlaceHolder1$txtC33":
        //                                inpElement.value = dsData.Tables["P5_INVEST"].Rows[0].ItemArray[7].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        switch (inpElement.name)
        //                        {
        //                            case "ctl00$ContentPlaceHolder1$txtC1_kod":
        //                                //if (dsData.Tables["P5_TC_BC_CODE"].Rows.Count>0 && long.Parse(dsData.Tables["P5_TC_BC_AMOUNT"].Rows[0].ItemArray[0].ToString().Replace (",",""))>0)
        //                                if (dsData.Tables["P5_TC_BC_CODE"].Rows.Count > 0)
        //                                    inpElement.value = dsData.Tables["P5_TC_BC_CODE"].Rows[0].ItemArray[0].ToString();
        //                                else
        //                                    inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC1_amaun":
        //                                if (dsData.Tables["P5_TC_BC_AMOUNT"].Rows.Count > 0)
        //                                    inpElement.value = dsData.Tables["P5_TC_BC_AMOUNT"].Rows[0].ItemArray[0].ToString();
        //                                else
        //                                    inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC2_kod":
        //                                //if (dsData.Tables["P5_TC_BC_CODE"].Rows.Count > 1 && long.Parse(dsData.Tables["P5_TC_BC_AMOUNT"].Rows[1].ItemArray[0].ToString().Replace(",", "")) > 0)
        //                                if (dsData.Tables["P5_TC_BC_CODE"].Rows.Count > 1)
        //                                    inpElement.value = dsData.Tables["P5_TC_BC_CODE"].Rows[1].ItemArray[0].ToString();
        //                                else
        //                                    inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC2_amaun":
        //                                if (dsData.Tables["P5_TC_BC_AMOUNT"].Rows.Count > 1)
        //                                    inpElement.value = dsData.Tables["P5_TC_BC_AMOUNT"].Rows[1].ItemArray[0].ToString();
        //                                else
        //                                    inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC3_kod":
        //                                //if (dsData.Tables["P5_TC_BC_CODE"].Rows.Count > 2 && long.Parse(dsData.Tables["P5_TC_BC_AMOUNT"].Rows[2].ItemArray[0].ToString().Replace(",", "")) > 0)
        //                                if (dsData.Tables["P5_TC_BC_CODE"].Rows.Count > 2)
        //                                    inpElement.value = dsData.Tables["P5_TC_BC_CODE"].Rows[2].ItemArray[0].ToString();
        //                                else
        //                                    inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC3_amaun":
        //                                if (dsData.Tables["P5_TC_BC_AMOUNT"].Rows.Count > 2)
        //                                    inpElement.value = dsData.Tables["P5_TC_BC_AMOUNT"].Rows[2].ItemArray[0].ToString();
        //                                else
        //                                    inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC4_kod":
        //                                //if (dsData.Tables["P5_TC_BC_CODE"].Rows.Count > 3 && long.Parse(dsData.Tables["P5_TC_BC_AMOUNT"].Rows[3].ItemArray[0].ToString().Replace(",", "")) > 0)
        //                                if (dsData.Tables["P5_TC_BC_CODE"].Rows.Count > 3)
        //                                    inpElement.value = dsData.Tables["P5_TC_BC_CODE"].Rows[3].ItemArray[0].ToString();
        //                                else
        //                                    inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC4_amaun":
        //                                if (dsData.Tables["P5_TC_BC_AMOUNT"].Rows.Count > 3)
        //                                    inpElement.value = dsData.Tables["P5_TC_BC_AMOUNT"].Rows[3].ItemArray[0].ToString();
        //                                else
        //                                    inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC5_kod":
        //                                //if (dsData.Tables["P5_TC_BC_CODE"].Rows.Count == 5 && long.Parse(dsData.Tables["P5_TC_BC_AMOUNT"].Rows[4].ItemArray[0].ToString().Replace(",", "")) > 0)
        //                                if (dsData.Tables["P5_TC_BC_CODE"].Rows.Count == 5)
        //                                    inpElement.value = dsData.Tables["P5_TC_BC_CODE"].Rows[4].ItemArray[0].ToString();
        //                                else
        //                                    inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC5_amaun":
        //                                if (dsData.Tables["P5_TC_BC_AMOUNT"].Rows.Count == 5)
        //                                    inpElement.value = dsData.Tables["P5_TC_BC_AMOUNT"].Rows[4].ItemArray[0].ToString();
        //                                else if (dsData.Tables["P5_TC_BC_AMOUNT"].Rows.Count > 5)
        //                                {
        //                                    long lngC5Total = 0;
        //                                    for (int i = 4; i < dsData.Tables["P5_TC_BC_AMOUNT"].Rows.Count; i++)
        //                                    {
        //                                        lngC5Total = lngC5Total + long.Parse(dsData.Tables["P5_TC_BC_AMOUNT"].Rows[i].ItemArray[0].ToString().Replace(",", ""));
        //                                    }
        //                                    inpElement.value = lngC5Total.ToString();
        //                                }
        //                                else
        //                                    inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC6_Rujukan":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC6_amaun":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC7_Rujukan":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC7_amaun":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC8_Rujukan":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC8_amaun":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC9_Rujukan":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC9_amaun":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC10_Rujukan":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC10_amaun":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC11":
        //                            //    inpElement.value="1";
        //                            //    break;
        //                            case "ctl00$ContentPlaceHolder1$txtC12":
        //                                inpElement.value = dsData.Tables["P5_TC"].Rows[0].ItemArray[0].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC13":
        //                            //    inpElement.value="1";
        //                            //    break;
        //                            case "ctl00$ContentPlaceHolder1$txtC14":
        //                                inpElement.value = dsData.Tables["P5_TC"].Rows[0].ItemArray[1].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC15":
        //                                long lngC15;
        //                                lngC15 = long.Parse(dsData.Tables["P5_TC"].Rows[0].ItemArray[2].ToString().Replace(",", "").Replace(".",""));
        //                                lngC15 = lngC15 + long.Parse(dsData.Tables["P5_TC"].Rows[0].ItemArray[3].ToString().Replace(",", "").Replace(".", ""));
        //                                inpElement.value = lngC15.ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC16":
        //                                inpElement.value = dsData.Tables["P5_TC"].Rows[0].ItemArray[4].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC17":
        //                                inpElement.value = dsData.Tables["P5_TC"].Rows[0].ItemArray[5].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC18":
        //                            //    inpElement.value="1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC19":
        //                            //    inpElement.value="1";
        //                            //    break;
        //                            case "ctl00$ContentPlaceHolder1$txtC20":
        //                                inpElement.value = dsData.Tables["P5_TC"].Rows[0].ItemArray[6].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC21":
        //                            //    inpElement.value="1";
        //                            //    break;
        //                            case "ctl00$ContentPlaceHolder1$txtC22":
        //                                inpElement.value = dsData.Tables["P5_TC"].Rows[0].ItemArray[7].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC23":
        //                                inpElement.value = dsData.Tables["P5_TC"].Rows[0].ItemArray[8].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC24":
        //                                inpElement.value = dsData.Tables["P5_TC"].Rows[0].ItemArray[9].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC25":
        //                            //    inpElement.value="1";
        //                            //    break;
        //                            case "ctl00$ContentPlaceHolder1$txtC26":
        //                                inpElement.value = dsData.Tables["P5_TC"].Rows[0].ItemArray[10].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC27":
        //                                inpElement.value = dsData.Tables["P5_TC"].Rows[0].ItemArray[11].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC28":
        //                            //    inpElement.value="1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC29":
        //                            //    inpElement.value="1";
        //                            //    break;
        //                            case "ctl00$ContentPlaceHolder1$txtC30":
        //                                inpElement.value = dsData.Tables["P5_TC"].Rows[0].ItemArray[12].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtC31":
        //                                inpElement.value = dsData.Tables["P5_TC"].Rows[0].ItemArray[13].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC32":
        //                            //    inpElement.value="1";
        //                            //    break;
        //                            case "ctl00$ContentPlaceHolder1$txtC33":
        //                                inpElement.value = dsData.Tables["P5_TC"].Rows[0].ItemArray[14].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                        }
        //                    }

        //                    break;
        //                case "C2008Page6":
        //                    if (dsData.Tables["P6_INCOME_TRANSFER"].Rows.Count > 0)
        //                    {
        //                        switch (inpElement.name)
        //                        {
        //                            case "ctl00$ContentPlaceHolder1$txtH1":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[0].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH2":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[1].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH3":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[2].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH4":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[3].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH5":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[4].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH6":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[5].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH6A":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[6].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH7":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[7].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH7A":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[8].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH7B":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[9].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH8":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[10].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH9":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[11].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH10":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[12].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH11":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[13].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH12":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[14].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH13":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[15].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH14":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[16].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH15":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[17].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH16":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[18].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH17":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[19].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH18":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[20].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH19":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[21].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH20":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[22].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH21":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[23].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH22":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[24].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH23":
        //                                inpElement.value = dsData.Tables["P6_INCOME_TRANSFER"].Rows[0].ItemArray[25].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtH24":
        //                            //    inpElement.value="1";
        //                            //    break;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        //MessageBox.Show("No record found for current document.", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        switch (inpElement.name)
        //                        {
        //                            case "ctl00$ContentPlaceHolder1$txtH1":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH2":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH3":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH4":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH5":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH6":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH6A":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH7":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH7A":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH7B":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH8":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH9":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH10":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH11":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH12":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH13":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH14":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH15":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH16":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH17":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH18":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH19":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH20":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH21":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH22":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtH23":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtH24":
        //                            //    inpElement.value="1";
        //                            //    break;
        //                        }
        //                        boolNoRecord = true;
        //                    }
        //                    break;
        //                case "C2008Page7":
        //                    if (dsData.Tables["P7_PRECEDING_YEAR"].Rows.Count > 0)
        //                    {
        //                        switch (inpElement.name)
        //                        {
        //                            case "ctl00$ContentPlaceHolder1$txtJ1":
        //                                inpElement.value = dsData.Tables["P7_PRECEDING_YEAR"].Rows[0].ItemArray[0].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        //MessageBox.Show("No record found for current document.", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        switch (inpElement.name)
        //                        {
        //                            case "ctl00$ContentPlaceHolder1$txtJ1":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                        }
        //                        boolNoRecord = true;
        //                    }
        //                    break;
        //                case "C2008Page8":
        //                    if (dsData.Tables["P8_TC_CA"].Rows.Count > 0)
        //                    {
        //                        switch (inpElement.name)
        //                        {
        //                            case "ctl00$ContentPlaceHolder1$txtE1a":
        //                                if (dsData.Tables["P8_TC_CA"].Rows.Count > 0)
        //                                {
        //                                    inpElement.value = dsData.Tables["P8_TC_CA"].Rows[0].ItemArray[0].ToString();
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                else
        //                                {
        //                                    inpElement.value = "";
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtE1b":
        //                                if (dsData.Tables["P8_TC_CA"].Rows.Count > 0)
        //                                {
        //                                    inpElement.value = dsData.Tables["P8_TC_CA"].Rows[0].ItemArray[1].ToString();
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                else
        //                                {
        //                                    inpElement.value = "";
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtE2a":
        //                                if (dsData.Tables["P8_TC_CA"].Rows.Count > 1)
        //                                {
        //                                    inpElement.value = dsData.Tables["P8_TC_CA"].Rows[1].ItemArray[0].ToString();
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                else
        //                                {
        //                                    inpElement.value = "";
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtE2b":
        //                                if (dsData.Tables["P8_TC_CA"].Rows.Count > 1)
        //                                {
        //                                    inpElement.value = dsData.Tables["P8_TC_CA"].Rows[1].ItemArray[1].ToString();
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                else
        //                                {
        //                                    inpElement.value = "";
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtE3a":
        //                                if (dsData.Tables["P8_TC_CA"].Rows.Count > 2)
        //                                {
        //                                    inpElement.value = dsData.Tables["P8_TC_CA"].Rows[2].ItemArray[0].ToString();
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                else
        //                                {
        //                                    inpElement.value = "";
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtE3b":
        //                                if (dsData.Tables["P8_TC_CA"].Rows.Count > 2)
        //                                {
        //                                    inpElement.value = dsData.Tables["P8_TC_CA"].Rows[2].ItemArray[1].ToString();
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                else
        //                                {
        //                                    inpElement.value = "";
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtE4a":
        //                                if (dsData.Tables["P8_TC_CA"].Rows.Count > 3)
        //                                {
        //                                    inpElement.value = dsData.Tables["P8_TC_CA"].Rows[3].ItemArray[0].ToString();
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                else
        //                                {
        //                                    inpElement.value = "";
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtE4b":
        //                                if (dsData.Tables["P8_TC_CA"].Rows.Count > 3)
        //                                {
        //                                    inpElement.value = dsData.Tables["P8_TC_CA"].Rows[3].ItemArray[1].ToString();
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                else
        //                                {
        //                                    inpElement.value = "";
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtE5a":
        //                                if (dsData.Tables["P8_TC_CA"].Rows.Count == 5)
        //                                {
        //                                    inpElement.value = dsData.Tables["P8_TC_CA"].Rows[4].ItemArray[0].ToString();
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                else if (dsData.Tables["P8_TC_CA"].Rows.Count > 5)
        //                                {
        //                                    long lngE5aTotal = 0;
        //                                    for (int i = 4; i < dsData.Tables["P8_TC_CA"].Rows.Count; i++)
        //                                    {
        //                                        lngE5aTotal = lngE5aTotal + long.Parse(dsData.Tables["P8_TC_CA"].Rows[i].ItemArray[0].ToString().Replace(",", ""));
        //                                    }
        //                                    inpElement.value = lngE5aTotal.ToString();
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                else
        //                                {
        //                                    inpElement.value = "";
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtE5b":
        //                                if (dsData.Tables["P8_TC_CA"].Rows.Count == 5)
        //                                {
        //                                    inpElement.value = dsData.Tables["P8_TC_CA"].Rows[4].ItemArray[1].ToString();
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                else if (dsData.Tables["P8_TC_CA"].Rows.Count > 5)
        //                                {
        //                                    long lngE5bTotal = 0;
        //                                    for (int i = 4; i < dsData.Tables["P8_TC_CA"].Rows.Count; i++)
        //                                    {
        //                                        lngE5bTotal = lngE5bTotal + long.Parse(dsData.Tables["P8_TC_CA"].Rows[i].ItemArray[1].ToString().Replace(",", ""));
        //                                    }
        //                                    inpElement.value = lngE5bTotal.ToString();
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                else
        //                                {
        //                                    inpElement.value = "";
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtE6a":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtE6b":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtE7a":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtE7b":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtE8a":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtE8b":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtE9a":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtE9b":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtE10a":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtE10b":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            case "ctl00$ContentPlaceHolder1$txtE11":
        //                                if (dsData.Tables["P8_CA_ADD"].Rows.Count > 0)
        //                                {
        //                                    string strCAAddRate, strCAAddQC, strADDIARate;
        //                                    double dblE11Total = 0;
        //                                    foreach (DataRow dr in dsData.Tables["P8_CA_ADD"].Rows)
        //                                    {
        //                                        strComparator = dr.ItemArray[0].ToString() == "" ? strCAAddRate = "0" : strCAAddRate = dr.ItemArray[0].ToString().Trim();
        //                                        strComparator = dr.ItemArray[3].ToString() == "" ? strCAAddQC = "0" : strCAAddQC = dr.ItemArray[3].ToString().Replace(",", "");
        //                                        strComparator = dr.ItemArray[2].ToString() == "" ? strADDIARate = "0" : strADDIARate = dr.ItemArray[2].ToString().Trim();
        //                                        dblE11Total = dblE11Total + ((Math.Round(double.Parse(strCAAddRate) / 100 * double.Parse(strCAAddQC))) + (Math.Round(double.Parse(strADDIARate) / 100 * double.Parse(strCAAddQC))));
        //                                    }
        //                                    inpElement.value = dblE11Total.ToString();
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                else
        //                                {
        //                                    inpElement.value = "";
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtE12":
        //                                if (dsData.Tables["P8_CA_DISALLOW"].Rows.Count > 0)
        //                                {
        //                                    inpElement.value = dsData.Tables["P8_CA_DISALLOW"].Rows[0].ItemArray[0].ToString();
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                else
        //                                {
        //                                    inpElement.value = "";
        //                                    FireInpElementEvent(inpElement, "OnBlur");
        //                                }
        //                                break;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        //MessageBox.Show("No record found for current document.", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        switch (inpElement.name)
        //                        {
        //                            case "ctl00$ContentPlaceHolder1$txtE1a":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtE1b":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtE2a":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtE2b":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtE3a":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtE3b":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtE4a":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtE4b":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtE5a":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtE5b":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtE6a":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtE6b":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtE7a":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtE7b":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtE8a":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtE8b":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtE9a":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtE9b":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtE10a":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtE10b":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            case "ctl00$ContentPlaceHolder1$txtE11":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtE12":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                        }
        //                        boolNoRecord = true;
        //                    }
        //                    break;
        //                case "C2008Page9":
        //                    switch (inpElement.name)
        //                    {
        //                        case "ctl00$ContentPlaceHolder1$txtF1a":
        //                            if (dsData.Tables["P9_TC"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P9_TC"].Rows[0].ItemArray[0].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtF1b":
        //                            if (dsData.Tables["P9_TC"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P9_TC"].Rows[0].ItemArray[1].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtF1Aa":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtF1Ab":
        //                            if (dsData.Tables["P9_TC"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P9_TC"].Rows[0].ItemArray[3].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtF2a":
        //                            if (dsData.Tables["P9_LOSS_CLAIM"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P9_LOSS_CLAIM"].Rows[0].ItemArray[0].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtF2b":
        //                            if (dsData.Tables["P9_LOSS_CLAIM"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P9_LOSS_CLAIM"].Rows[0].ItemArray[1].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtF3a":
        //                            if (dsData.Tables["P9_LOSS_CLAIM"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P9_LOSS_CLAIM"].Rows[0].ItemArray[2].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtF3b":
        //                            if (dsData.Tables["P9_LOSS_CLAIM"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P9_LOSS_CLAIM"].Rows[0].ItemArray[3].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtF4a":
        //                            if (dsData.Tables["P9_LOSS_CLAIM"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P9_LOSS_CLAIM"].Rows[0].ItemArray[4].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtF4b":
        //                            if (dsData.Tables["P9_LOSS_CLAIM"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P9_LOSS_CLAIM"].Rows[0].ItemArray[5].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtF5a":
        //                            if (dsData.Tables["P9_LOSS_CLAIM"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P9_LOSS_CLAIM"].Rows[0].ItemArray[6].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtF5b":
        //                            if (dsData.Tables["P9_LOSS_CLAIM"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P9_LOSS_CLAIM"].Rows[0].ItemArray[7].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                    }
        //                    break;
        //                case "C2008Page10":
        //                    if (dsData.Tables["P10_INCENTIVE_CLAIM"].Rows.Count > 0)
        //                    {
        //                        switch (inpElement.name)
        //                        {
        //                            case "ctl00$ContentPlaceHolder1$txtG1a":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[0].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG1b":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[1].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG2a":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[2].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG2b":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[3].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG3a":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[4].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG3b":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[5].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG4a":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[6].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG4b":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[7].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG5a":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[8].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG5b":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[9].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6a":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[10].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6b":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[11].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6Aa":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[12].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6Ab":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[13].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6Ba":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[14].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6Bb":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[15].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6Ca":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[16].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6Cb":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[17].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6Da":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[18].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6Db":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[19].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6Ea":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[20].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6Eb":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[21].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC22":
        //                            //    inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[22].ToString();
        //                            //    FireInpElementEvent(inpElement, "OnBlur");
        //                            //    break;
        //                            case "ctl00$ContentPlaceHolder1$txtG7":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[22].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC23":
        //                            //    inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[24].ToString();
        //                            //    FireInpElementEvent(inpElement, "OnBlur");
        //                            //    break;
        //                            case "ctl00$ContentPlaceHolder1$txtG8":
        //                                inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[23].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtG9":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtG10":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        //MessageBox.Show("No record found for current document.", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                        switch (inpElement.name)
        //                        {
        //                            case "ctl00$ContentPlaceHolder1$txtG1a":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG1b":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG2a":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG2b":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG3a":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG3b":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG4a":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG4b":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG5a":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG5b":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6a":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6b":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6Aa":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6Ab":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6Ba":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6Bb":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6Ca":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6Cb":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6Da":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6Db":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6Ea":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            case "ctl00$ContentPlaceHolder1$txtG6Eb":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC22":
        //                            //    inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[22].ToString();
        //                            //    FireInpElementEvent(inpElement, "OnBlur");
        //                            //    break;
        //                            case "ctl00$ContentPlaceHolder1$txtG7":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtC23":
        //                            //    inpElement.value = dsData.Tables["P10_INCENTIVE_CLAIM"].Rows[0].ItemArray[24].ToString();
        //                            //    FireInpElementEvent(inpElement, "OnBlur");
        //                            //    break;
        //                            case "ctl00$ContentPlaceHolder1$txtG8":
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                                break;
        //                            //case "ctl00$ContentPlaceHolder1$txtG9":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                            //case "ctl00$ContentPlaceHolder1$txtG10":
        //                            //    inpElement.value = "1";
        //                            //    break;
        //                        }
        //                        boolNoRecord = true;
        //                    }
        //                    break;
        //                case "C2008Page11":
        //                    switch (inpElement.name)
        //                    {
        //                        case "ctl00$ContentPlaceHolder1$txtD1_kod":
        //                            if (dsData.Tables["P11_OTHER_EXPENDITURE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P11_OTHER_EXPENDITURE"].Rows[0].ItemArray[0].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtD1_amaun":
        //                            if (dsData.Tables["P11_OTHER_EXPENDITURE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P11_OTHER_EXPENDITURE"].Rows[0].ItemArray[1].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtD2_kod":
        //                            if (dsData.Tables["P11_OTHER_EXPENDITURE"].Rows.Count > 1)
        //                            {
        //                                inpElement.value = dsData.Tables["P11_OTHER_EXPENDITURE"].Rows[1].ItemArray[0].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtD2_amaun":
        //                            if (dsData.Tables["P11_OTHER_EXPENDITURE"].Rows.Count > 1)
        //                            {
        //                                inpElement.value = dsData.Tables["P11_OTHER_EXPENDITURE"].Rows[1].ItemArray[1].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtD3_kod":
        //                            if (dsData.Tables["P11_OTHER_EXPENDITURE"].Rows.Count > 2)
        //                            {
        //                                inpElement.value = dsData.Tables["P11_OTHER_EXPENDITURE"].Rows[2].ItemArray[0].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtD3_amaun":
        //                            if (dsData.Tables["P11_OTHER_EXPENDITURE"].Rows.Count > 2)
        //                            {
        //                                inpElement.value = dsData.Tables["P11_OTHER_EXPENDITURE"].Rows[2].ItemArray[1].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtD4_kod":
        //                            if (dsData.Tables["P11_OTHER_EXPENDITURE"].Rows.Count > 3)
        //                            {
        //                                inpElement.value = dsData.Tables["P11_OTHER_EXPENDITURE"].Rows[3].ItemArray[0].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtD4_amaun":
        //                            if (dsData.Tables["P11_OTHER_EXPENDITURE"].Rows.Count > 3)
        //                            {
        //                                inpElement.value = dsData.Tables["P11_OTHER_EXPENDITURE"].Rows[3].ItemArray[1].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtD5_kod":
        //                            if (dsData.Tables["P11_OTHER_EXPENDITURE"].Rows.Count > 4)
        //                            {
        //                                inpElement.value = dsData.Tables["P11_OTHER_EXPENDITURE"].Rows[4].ItemArray[0].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtD5_amaun":
        //                            if (dsData.Tables["P11_OTHER_EXPENDITURE"].Rows.Count > 4)
        //                            {
        //                                inpElement.value = dsData.Tables["P11_OTHER_EXPENDITURE"].Rows[4].ItemArray[1].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtD6_kod":
        //                            if (dsData.Tables["P11_OTHER_EXPENDITURE"].Rows.Count > 5)
        //                            {
        //                                inpElement.value = dsData.Tables["P11_OTHER_EXPENDITURE"].Rows[5].ItemArray[0].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtD6_amaun":
        //                            if (dsData.Tables["P11_OTHER_EXPENDITURE"].Rows.Count > 5)
        //                            {
        //                                inpElement.value = dsData.Tables["P11_OTHER_EXPENDITURE"].Rows[5].ItemArray[1].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtD7_kod":
        //                            if (dsData.Tables["P11_OTHER_EXPENDITURE"].Rows.Count > 6)
        //                            {
        //                                inpElement.value = dsData.Tables["P11_OTHER_EXPENDITURE"].Rows[6].ItemArray[0].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtD7_amaun":
        //                            if (dsData.Tables["P11_OTHER_EXPENDITURE"].Rows.Count > 6)
        //                            {
        //                                inpElement.value = dsData.Tables["P11_OTHER_EXPENDITURE"].Rows[6].ItemArray[1].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtD8_kod":
        //                            if (dsData.Tables["P11_OTHER_EXPENDITURE"].Rows.Count > 7)
        //                            {
        //                                inpElement.value = dsData.Tables["P11_OTHER_EXPENDITURE"].Rows[7].ItemArray[0].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtD8_amaun":
        //                            if (dsData.Tables["P11_OTHER_EXPENDITURE"].Rows.Count > 7)
        //                            {
        //                                inpElement.value = dsData.Tables["P11_OTHER_EXPENDITURE"].Rows[7].ItemArray[1].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtD9_kod":
        //                            if (dsData.Tables["P11_OTHER_EXPENDITURE"].Rows.Count > 8)
        //                            {
        //                                inpElement.value = dsData.Tables["P11_OTHER_EXPENDITURE"].Rows[8].ItemArray[0].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtD9_amaun":
        //                            if (dsData.Tables["P11_OTHER_EXPENDITURE"].Rows.Count > 8)
        //                            {
        //                                inpElement.value = dsData.Tables["P11_OTHER_EXPENDITURE"].Rows[8].ItemArray[1].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtD10_kod":
        //                            if (dsData.Tables["P11_OTHER_EXPENDITURE"].Rows.Count > 9)
        //                            {
        //                                inpElement.value = dsData.Tables["P11_OTHER_EXPENDITURE"].Rows[9].ItemArray[0].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtD10_amaun":
        //                            if (dsData.Tables["P11_OTHER_EXPENDITURE"].Rows.Count > 9)
        //                            {
        //                                inpElement.value = dsData.Tables["P11_OTHER_EXPENDITURE"].Rows[9].ItemArray[1].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtD11":
        //                        //inpElement.value = "1";
        //                        //  break;
        //                    }
        //                    break;
        //                case "C2008Page12":
        //                    switch (inpElement.name)
        //                    {
        //                        case "ctl00$ContentPlaceHolder1$txtI1":
        //                            if (dsData.Tables["P12_EXEMPT_ACC"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P12_EXEMPT_ACC"].Rows[0].ItemArray[0].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtI2":
        //                            if (dsData.Tables["P12_EXEMPT_ACC"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P12_EXEMPT_ACC"].Rows[0].ItemArray[1].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtI3":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                    }
        //                    break;
        //                case "C2008Page14":
        //                    switch (inpElement.name)
        //                    {
        //                        case "ctl00$ContentPlaceHolder1$txtM1_JumKasar":
        //                            if (dsData.Tables["P14_WITHHOLD"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P14_WITHHOLD"].Rows[0].ItemArray[0].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtM1_JumDiPegang":
        //                            if (dsData.Tables["P14_WITHHOLD"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P14_WITHHOLD"].Rows[0].ItemArray[1].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtM1_JumBersih":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtM2_JumKasar":
        //                            if (dsData.Tables["P14_WITHHOLD"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P14_WITHHOLD"].Rows[0].ItemArray[2].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtM2_JumDiPegang":
        //                            if (dsData.Tables["P14_WITHHOLD"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P14_WITHHOLD"].Rows[0].ItemArray[3].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtM2_JumBersih":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtM3_JumKasar":
        //                            if (dsData.Tables["P14_WITHHOLD"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P14_WITHHOLD"].Rows[0].ItemArray[4].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtM3_JumDiPegang":
        //                            if (dsData.Tables["P14_WITHHOLD"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P14_WITHHOLD"].Rows[0].ItemArray[5].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtM3_JumBersih":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtM4_JumKasar":
        //                            if (dsData.Tables["P14_WITHHOLD"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P14_WITHHOLD"].Rows[0].ItemArray[6].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtM4_JumDiPegang":
        //                            if (dsData.Tables["P14_WITHHOLD"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P14_WITHHOLD"].Rows[0].ItemArray[7].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtM4_JumBersih":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtM5_JumKasar":
        //                            if (dsData.Tables["P14_WITHHOLD"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P14_WITHHOLD"].Rows[0].ItemArray[8].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtM5_JumDiPegang":
        //                            if (dsData.Tables["P14_WITHHOLD"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P14_WITHHOLD"].Rows[0].ItemArray[9].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtM5_JumBersih":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                    }
        //                    break;
        //                case "C2008Page15":
        //                    switch (inpElement.name)
        //                    {
        //                        case "ctl00$ContentPlaceHolder1$txtN1":
        //                            if (dsData.Tables["P15_RELATED"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P15_RELATED"].Rows[0].ItemArray[0].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtN2":
        //                            if (dsData.Tables["P15_RELATED"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P15_RELATED"].Rows[0].ItemArray[1].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtN3":
        //                            if (dsData.Tables["P15_RELATED"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P15_RELATED"].Rows[0].ItemArray[2].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtN4":
        //                            if (dsData.Tables["P15_RELATED"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P15_RELATED"].Rows[0].ItemArray[3].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtN5":
        //                            if (dsData.Tables["P15_RELATED"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P15_RELATED"].Rows[0].ItemArray[4].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtN6":
        //                            if (dsData.Tables["P15_RELATED"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P15_RELATED"].Rows[0].ItemArray[5].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtN7":
        //                            if (dsData.Tables["P15_RELATED"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P15_RELATED"].Rows[0].ItemArray[6].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtN8":
        //                            if (dsData.Tables["P15_RELATED"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P15_RELATED"].Rows[0].ItemArray[7].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtN9":
        //                            if (dsData.Tables["P15_RELATED"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P15_RELATED"].Rows[0].ItemArray[8].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtN10":
        //                            if (dsData.Tables["P15_RELATED"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P15_RELATED"].Rows[0].ItemArray[9].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtN11":
        //                            if (dsData.Tables["P15_RELATED"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P15_RELATED"].Rows[0].ItemArray[10].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtN12":
        //                            if (dsData.Tables["P15_RELATED"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P15_RELATED"].Rows[0].ItemArray[11].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                    }
        //                    break;
        //                case "C2008Page17":
        //                    switch (inpElement.name)
        //                    {
        //                        //case "ctl00$ContentPlaceHolder1$txtMastautin":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        //case "ctl00$ContentPlaceHolder1$txtA1":
        //                        //    inpElement.value = "111";
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtA2_Pecahan":
        //                            inpElement.value = dsData.Tables["P17_TABLE"].Rows[0].ItemArray[0].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtA2_Kadar":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        //case "ctl00$ContentPlaceHolder1$txtA2_Cukai":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtA3_Pecahan":
        //                            inpElement.value = dsData.Tables["P17_TABLE"].Rows[0].ItemArray[1].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtA3_Kadar":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        //case "ctl00$ContentPlaceHolder1$txtA3_Cukai":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtA4_Pecahan":
        //                            inpElement.value = dsData.Tables["P17_TABLE"].Rows[0].ItemArray[2].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtA4_Kadar":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        //case "ctl00$ContentPlaceHolder1$txtA4_Cukai":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtA5_Pecahan":
        //                            inpElement.value = dsData.Tables["P17_TABLE"].Rows[0].ItemArray[3].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtA5_Kadar":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        //case "ctl00$ContentPlaceHolder1$txtA5_Cukai":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtA5A_Pecahan":
        //                            inpElement.value = dsData.Tables["P17_TABLE"].Rows[0].ItemArray[4].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtA5A_Kadar":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        //case "ctl00$ContentPlaceHolder1$txtA5A_Cukai":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtA6_Pecahan":
        //                            inpElement.value = dsData.Tables["P17_TABLE"].Rows[0].ItemArray[5].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtA6_Kadar":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        //case "ctl00$ContentPlaceHolder1$txtA6_Cukai":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtA7_Pecahan":
        //                            inpElement.value = dsData.Tables["P17_TABLE"].Rows[0].ItemArray[6].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtA7_Kadar":
        //                            inpElement.value = dsData.Tables["P17_TABLE"].Rows[0].ItemArray[7].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtA7_Cukai":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        //case "ctl00$ContentPlaceHolder1$txtA8":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtA9":
        //                            inpElement.value = dsData.Tables["P17_TABLE"].Rows[0].ItemArray[8].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtA10":
        //                            inpElement.value = dsData.Tables["P17_TABLE"].Rows[0].ItemArray[9].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtA11":
        //                            inpElement.value = dsData.Tables["P17_TABLE"].Rows[0].ItemArray[10].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtA12":
        //                            inpElement.value = dsData.Tables["P17_TABLE"].Rows[0].ItemArray[11].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtA13":
        //                            inpElement.value = dsData.Tables["P17_TABLE"].Rows[0].ItemArray[12].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtA14":
        //                            inpElement.value = dsData.Tables["P17_TABLE"].Rows[0].ItemArray[13].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtA15":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        //case "ctl00$ContentPlaceHolder1$txtA16_Label":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        //case "ctl00$ContentPlaceHolder1$txtA16":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        //case "ctl00$ContentPlaceHolder1$txtB1":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtB2":
        //                            inpElement.value = dsData.Tables["P17_TABLE"].Rows[0].ItemArray[14].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtB3_label":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                        //case "ctl00$ContentPlaceHolder1$txtB3":
        //                        //    inpElement.value = "1";
        //                        //    break;
        //                    }
        //                    break;
        //                case "C2008Page18":

        //                    string[] arrAuditor = new string[3];
        //                    if (!String.IsNullOrEmpty(dsData.Tables["P18_AUDITOR"].Rows[0].ItemArray[1].ToString()))
        //                    {
        //                        arrAuditor = TextSpliter(dsData.Tables["P18_AUDITOR"].Rows[0].ItemArray[1].ToString(), 40);
        //                    }
        //                    switch (inpElement.name)
        //                    {
        //                        case "ctl00$ContentPlaceHolder1$txtR1":
        //                            inpElement.value = dsData.Tables["P18_AUDITOR"].Rows[0].ItemArray[0].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtR2_Alamat1":
        //                            //inpElement.value = dsData.Tables["P18_AUDITOR"].Rows[0].ItemArray[1].ToString();
        //                            inpElement.value = arrAuditor[0];
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtR2_Alamat2":
        //                            //inpElement.value = "1";
        //                            inpElement.value = arrAuditor[1];
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtR2_Alamat3":
        //                            //inpElement.value = "1";
        //                            inpElement.value = arrAuditor[2];
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtR2_Poskod":
        //                            inpElement.value = dsData.Tables["P18_AUDITOR"].Rows[0].ItemArray[2].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtR2_Bandar":
        //                            inpElement.value = dsData.Tables["P18_AUDITOR"].Rows[0].ItemArray[3].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtR3":
        //                            inpElement.value = dsData.Tables["P18_AUDITOR"].Rows[0].ItemArray[5].ToString();
        //                            break;
        //                    }
        //                    break;
        //                case "C2008Page19":
        //                    switch (inpElement.name)
        //                    {
        //                        //case "ctl00$ContentPlaceHolder1$txtS1":
        //                        //    inpElement.value = dsData.Tables["P19_FIRM"].Rows[0].ItemArray[0].ToString();
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtS2_Alamat1":
        //                            inpElement.value = dsData.Tables["P19_FIRM"].Rows[0].ItemArray[0].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtS2_Alamat2":
        //                            inpElement.value = dsData.Tables["P19_FIRM"].Rows[0].ItemArray[1].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtS2_Alamat3":
        //                            inpElement.value = dsData.Tables["P19_FIRM"].Rows[0].ItemArray[2].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtS2_Poskod":
        //                            inpElement.value = dsData.Tables["P19_FIRM"].Rows[0].ItemArray[3].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtS2_Bandar":
        //                            inpElement.value = dsData.Tables["P19_FIRM"].Rows[0].ItemArray[4].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtS3":
        //                            inpElement.value = dsData.Tables["P19_FIRM"].Rows[0].ItemArray[6].ToString(); ;
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder1$txtS4":
        //                        //    inpElement.value = dsData.Tables["P19_FIRM"].Rows[0].ItemArray[7].ToString();
        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder1$txtS5":
        //                            inpElement.value = dsData.Tables["P19_FIRM"].Rows[0].ItemArray[7].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtS6":
        //                            inpElement.value = dsData.Tables["P19_FIRM"].Rows[0].ItemArray[8].ToString();
        //                            break;
        //                    }
        //                    break;
        //                //case "https://elatihan.hasil.org.my/ec/akuan.aspx":
        //                //    switch (inpElement.name)
        //                //    {
        //                //        case "ctl00$ContentPlaceHolder1$txtNama_Akuan":
        //                //            inpElement.value = "1";
        //                //            break;
        //                //        case "ctl00$ContentPlaceHolder1$txtKP_Akuan":
        //                //            inpElement.value = "1";
        //                //            break;
        //                //        case "ctl00$ContentPlaceHolder1$txtJawatan_Akuan":
        //                //            inpElement.value = "1";
        //                //            break;
        //                //    }
        //                //    break;
        //                case "C2008Page3":
        //                    switch (inpElement.name)
        //                    {
        //                        case "ctl00$ContentPlaceHolder1$txtP1_KP":
        //                            if (dsData.Tables["P3_SYER"].Rows.Count > 0)
        //                                inpElement.value = dsData.Tables["P3_SYER"].Rows[0].ItemArray[0].ToString().Replace("-", "");
        //                            else
        //                                inpElement.value = "";
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtP1_Nama":
        //                            if (dsData.Tables["P3_SYER"].Rows.Count > 0)
        //                                inpElement.value = dsData.Tables["P3_SYER"].Rows[0].ItemArray[1].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtP1_syer":
        //                            if (dsData.Tables["P3_SYER"].Rows.Count > 0)
        //                                inpElement.value = dsData.Tables["P3_SYER"].Rows[0].ItemArray[2].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtP2_KP":
        //                            if (dsData.Tables["P3_SYER"].Rows.Count > 1)
        //                                inpElement.value = dsData.Tables["P3_SYER"].Rows[1].ItemArray[0].ToString().Replace("-", "");
        //                            else
        //                                inpElement.value = "";
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtP2_Nama":
        //                            if (dsData.Tables["P3_SYER"].Rows.Count > 1)
        //                                inpElement.value = dsData.Tables["P3_SYER"].Rows[1].ItemArray[1].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtP2_syer":
        //                            if (dsData.Tables["P3_SYER"].Rows.Count > 1)
        //                                inpElement.value = dsData.Tables["P3_SYER"].Rows[1].ItemArray[2].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtP3_KP":
        //                            if (dsData.Tables["P3_SYER"].Rows.Count > 2)
        //                                inpElement.value = dsData.Tables["P3_SYER"].Rows[2].ItemArray[0].ToString().Replace("-", "");
        //                            else
        //                                inpElement.value = "";
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtP3_Nama":
        //                            if (dsData.Tables["P3_SYER"].Rows.Count > 2)
        //                                inpElement.value = dsData.Tables["P3_SYER"].Rows[2].ItemArray[1].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtP3_syer":
        //                            if (dsData.Tables["P3_SYER"].Rows.Count > 2)
        //                                inpElement.value = dsData.Tables["P3_SYER"].Rows[2].ItemArray[2].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtP4_KP":
        //                            if (dsData.Tables["P3_SYER"].Rows.Count > 3)
        //                                inpElement.value = dsData.Tables["P3_SYER"].Rows[3].ItemArray[0].ToString().Replace("-", "");
        //                            else
        //                                inpElement.value = "";
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtP4_Nama":
        //                            if (dsData.Tables["P3_SYER"].Rows.Count > 3)
        //                                inpElement.value = dsData.Tables["P3_SYER"].Rows[3].ItemArray[1].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtP4_syer":
        //                            if (dsData.Tables["P3_SYER"].Rows.Count > 3)
        //                                inpElement.value = dsData.Tables["P3_SYER"].Rows[3].ItemArray[2].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtP5_KP":
        //                            if (dsData.Tables["P3_SYER"].Rows.Count > 4)
        //                                inpElement.value = dsData.Tables["P3_SYER"].Rows[4].ItemArray[0].ToString().Replace("-", "");
        //                            else
        //                                inpElement.value = "";
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtP5_Nama":
        //                            if (dsData.Tables["P3_SYER"].Rows.Count > 4)
        //                                inpElement.value = dsData.Tables["P3_SYER"].Rows[4].ItemArray[1].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$txtP5_syer":
        //                            if (dsData.Tables["P3_SYER"].Rows.Count > 4)
        //                                inpElement.value = dsData.Tables["P3_SYER"].Rows[4].ItemArray[2].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            break;
        //                    }
        //                    break;
        //            }

        //        }
        //        if (boolNoRecord)
        //        {
        //            MessageBox.Show("No record found for current document.", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
 
        //        foreach (mshtml.HTMLSelectElement selElement in htmlDoc.getElementsByTagName("select"))
        //        {
        //            switch (strPageIndex)
        //            {
        //                case "C2008Page1":
        //                    switch (selElement.name)
        //                    {
        //                        case "ctl00$ContentPlaceHolder1$ddlMastautin":
        //                            selElement.value = dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$ddlNegara_Mastautin":
        //                            selElement.value = dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$ddlKetetapan":
        //                            strComparator = dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[2].ToString() == "0" ? selElement.value = "1" : selElement.value = "2";
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$ddlPenyimpanan":
        //                            strComparator = strRecKept == "True" ? selElement.value = "1" : selElement.value = "2";
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$ddlRKT_RKS":
        //                            if (dsData.Tables["P1_SELECT_RTK_RTS"].Rows.Count > 0)
        //                                strComparator = dsData.Tables["P1_SELECT_RTK_RTS"].Rows[0].ItemArray[0].ToString() == "1" ? selElement.value = "RKT" : selElement.value = "RKS";
        //                            else selElement.value = "3";
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$ddlSyer":
        //                            if (dsData.Tables["P1_SELECT_TAX_COMP"].Rows[0].ItemArray[0].ToString() == "0")
        //                                selElement.value = "2";
        //                            else if (dsData.Tables["P1_SELECT_TAX_COMP"].Rows[0].ItemArray[0].ToString() == "1")
        //                                selElement.value = "1";
        //                            else
        //                                selElement.value = "3";
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$ddlO1":
        //                                if (dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[3].ToString().Length > 0)
        //                                {
        //                                    string strKey = "";
        //                                    if (dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[3].ToString().Contains(","))
        //                                        strKey = dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[3].ToString().Substring(0, dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[3].ToString().IndexOf(","));
        //                                    else
        //                                        strKey = dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[3].ToString().Trim();
        //                                    switch (strKey)
        //                                    {
        //                                        case "1": selElement.value = "1"; break;
        //                                        case "2": selElement.value = "2"; break;
        //                                        case "3": selElement.value = "9"; break;
        //                                        case "4": selElement.value = "3"; break;
        //                                        case "15": selElement.value = "4"; break;
        //                                        case "6": selElement.value = "7"; break;
        //                                        case "7": selElement.value = "5"; break;
        //                                        case "8": selElement.value = "11"; break;
        //                                        case "9": selElement.value = "6"; break;
        //                                        case "10": selElement.value = "8"; break;
        //                                        case "11": selElement.value = "14"; break;
        //                                        case "12": selElement.value = "10"; break;
        //                                        case "13": selElement.value = "12"; break;
        //                                        case "14": selElement.value = "13"; break;
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    selElement.value = "0";
        //                                }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$ddlO2_Negeri":
        //                            selElement.value = SelectState(dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[4].ToString());
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$ddlO4_Negeri":
        //                            selElement.value = SelectState(dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[5].ToString());
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$ddlO5_Negeri":
        //                            selElement.value = SelectState(dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[6].ToString());
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$ddlO6":
        //                            if (dsData.Tables["P1_SELECT_BANK"].Rows.Count > 0)
        //                            {
        //                                selElement.value = dsData.Tables["P1_SELECT_BANK"].Rows[0].ItemArray[0].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$ddlO8":
        //                            if (dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() == "1")
        //                                selElement.value = "2";
        //                            else if (dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() == "2")
        //                                selElement.value = "3";
        //                            else if (dsData.Tables["P1_SELECT_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() == "3")
        //                                selElement.value = "1";
        //                            break;
        //                    }
        //                    break;

        //                case "C2008Page2":
        //                    switch (selElement.name)
        //                    {
        //                        case "ctl00$ContentPlaceHolder1$ddlO13_Kump1":
        //                            if (dsData.Tables["P2_INPUT_DIRECTORS"].Rows.Count > 0)
        //                                selElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[0].ItemArray[3].ToString();
        //                            else
        //                                selElement.value = "0";
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$ddlO13_Kump2":
        //                            if (dsData.Tables["P2_INPUT_DIRECTORS"].Rows.Count > 1)
        //                                selElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[1].ItemArray[3].ToString();
        //                            else
        //                                selElement.value = "0";
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$ddlO13_Kump3":
        //                            if (dsData.Tables["P2_INPUT_DIRECTORS"].Rows.Count > 2)
        //                                selElement.value = dsData.Tables["P2_INPUT_DIRECTORS"].Rows[2].ItemArray[3].ToString();
        //                            else
        //                                selElement.value = "0";
        //                            break;
        //                    }
        //                    break;
        //                case "C2008Page13":
        //                    switch (selElement.name)
        //                    {
        //                        case "ctl00$ContentPlaceHolder1$ddlK1":
        //                            if (dsData.Tables["P13_DISPOSAL"].Rows.Count > 0)
        //                            {
        //                                if (dsData.Tables["P13_DISPOSAL"].Rows[0].ItemArray[0].ToString() == "Yes")
        //                                    selElement.value = "1";
        //                                else
        //                                    selElement.value = "2";
        //                                FireSelElementEvent(selElement, "OnChange");
        //                            }
        //                            else
        //                            {
        //                                selElement.value = "0";
        //                                FireSelElementEvent(selElement, "OnChange");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$ddlK2":
        //                            if (dsData.Tables["P13_DISPOSAL"].Rows.Count > 0)
        //                            {
        //                                if (dsData.Tables["P13_DISPOSAL"].Rows[0].ItemArray[1].ToString() == "Yes")
        //                                    selElement.value = "1";
        //                                else
        //                                    selElement.value = "2";
        //                                FireSelElementEvent(selElement, "OnChange");
        //                            }
        //                            else
        //                            {
        //                                selElement.value = "0";
        //                                FireSelElementEvent(selElement, "OnChange");
        //                            }
        //                            break;
        //                    }
        //                    break;
        //                case "C2008Page16":
        //                    switch (selElement.name)
        //                    {
        //                        case "ctl00$ContentPlaceHolder1$ddlQ1":
        //                            if (dsData.Tables["P16_FOREIGN"].Rows.Count > 0)
        //                            {
        //                                if (dsData.Tables["P16_FOREIGN"].Rows[0].ItemArray[0].ToString() == "70 % - 100 %")
        //                                    selElement.value = "1";
        //                                else if (dsData.Tables["P16_FOREIGN"].Rows[0].ItemArray[0].ToString() == "51 % - 69 %")
        //                                    selElement.value = "2";
        //                                else if (dsData.Tables["P16_FOREIGN"].Rows[0].ItemArray[0].ToString() == "20 % - 50 %")
        //                                    selElement.value = "3";
        //                                else if (dsData.Tables["P16_FOREIGN"].Rows[0].ItemArray[0].ToString() == "<= 19 %")
        //                                    selElement.value = "4";
        //                                else if (dsData.Tables["P16_FOREIGN"].Rows[0].ItemArray[0].ToString() == "NIL")
        //                                    selElement.value = "5";
        //                            }
        //                            else
        //                                selElement.value = "0";
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$ddlQ2a":
        //                            if (dsData.Tables["P16_FOREIGN"].Rows.Count > 0)
        //                            {
        //                                strComparator = dsData.Tables["P16_FOREIGN"].Rows[0].ItemArray[1].ToString() == "N" ? selElement.value = "2" : selElement.value = "1";
        //                                FireSelElementEvent(selElement, "OnChange");
        //                            }
        //                            else
        //                            {
        //                                selElement.value = "0";
        //                                FireSelElementEvent(selElement, "OnChange");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$ddlQ2b":
        //                            if (dsData.Tables["P16_FOREIGN"].Rows.Count > 0)
        //                                strComparator = dsData.Tables["P16_FOREIGN"].Rows[0].ItemArray[2].ToString() == "N" ? selElement.value = "2" : selElement.value = "1";
        //                            else
        //                                selElement.value = "0";
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$ddlQ2c":
        //                            if (dsData.Tables["P16_FOREIGN"].Rows.Count > 0)
        //                                strComparator = dsData.Tables["P16_FOREIGN"].Rows[0].ItemArray[3].ToString() == "N" ? selElement.value = "2" : selElement.value = "1";
        //                            else
        //                                selElement.value = "0";
        //                            break;
        //                    }
        //                    break;
        //                case "C2008Page18":
        //                    switch (selElement.name)
        //                    {
        //                        case "ctl00$ContentPlaceHolder1$ddlR2_Negeri":
        //                            selElement.value = SelectState(dsData.Tables["P18_AUDITOR"].Rows[0].ItemArray[4].ToString());
        //                            break;
        //                    }
        //                    break;
        //                case "C2008Page19":
        //                    switch (selElement.name)
        //                    {
        //                        case "ctl00$ContentPlaceHolder1$ddlS2_Negeri":
        //                            selElement.value = SelectState(dsData.Tables["P19_FIRM"].Rows[0].ItemArray[5].ToString());
        //                            break;
        //                    }
        //                    break;
        //                case "C2008Page3":
        //                    switch (selElement.name)
        //                    {
        //                        case "ctl00$ContentPlaceHolder1$ddlNegara_1":
        //                            if (dsData.Tables["P3_SYER"].Rows.Count > 0)
        //                            {
        //                                selElement.value = dsData.Tables["P3_SYER"].Rows[0].ItemArray[3].ToString().ToUpper();
        //                                FireSelElementEvent(selElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                selElement.value = "";
        //                                FireSelElementEvent(selElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$ddlNegara_2":
        //                            if (dsData.Tables["P3_SYER"].Rows.Count > 1)
        //                            {
        //                                selElement.value = dsData.Tables["P3_SYER"].Rows[1].ItemArray[3].ToString().ToUpper();
        //                                FireSelElementEvent(selElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                selElement.value = "";
        //                                FireSelElementEvent(selElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$ddlNegara_3":
        //                            if (dsData.Tables["P3_SYER"].Rows.Count > 2)
        //                            {
        //                                selElement.value = dsData.Tables["P3_SYER"].Rows[2].ItemArray[3].ToString().ToUpper();
        //                                FireSelElementEvent(selElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                selElement.value = "";
        //                                FireSelElementEvent(selElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$ddlNegara_4":
        //                            if (dsData.Tables["P3_SYER"].Rows.Count > 3)
        //                            {
        //                                selElement.value = dsData.Tables["P3_SYER"].Rows[3].ItemArray[3].ToString().ToUpper();
        //                                FireSelElementEvent(selElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                selElement.value = "";
        //                                FireSelElementEvent(selElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder1$ddlNegara_5":
        //                            if (dsData.Tables["P3_SYER"].Rows.Count > 4)
        //                            {
        //                                selElement.value = dsData.Tables["P3_SYER"].Rows[4].ItemArray[3].ToString().ToUpper();
        //                                FireSelElementEvent(selElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                selElement.value = "";
        //                                FireSelElementEvent(selElement, "OnBlur");
        //                            }
        //                            break;
        //                    }
        //                    break;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private void ProcessFormR(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        //{
        //    try
        //    {
        //        EFilingDAL dal = new EFilingDAL(strTaxPayer, strYA, strAuditor);
        //        DataSet dsData = dal.GetFormData(strPageIndex);
        //        dal.CloseConn();
        //        string strComparator;

        //        foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
        //        {
        //            switch (strPageIndex)
        //            {
        //                case "R2008Page1":
        //                    switch (inpElement.name)
        //                    {
        //                        //ctl00$ContentPlaceHolder2$txtNama_Sykt
        //                        //ctl00$ContentPlaceHolder2$txtNo_Rujukan
        //                        //ctl00$ContentPlaceHolder2$TextBox12
        //                        //ctl00$ContentPlaceHolder2$TextBox12_MaskedEditExtender_ClientState
        //                        case "ctl00$ContentPlaceHolder2$txtTempoh":
        //                            inpElement.value = dsData.Tables["P1_TP_PROFILE"].Rows[0].ItemArray[0].ToString();
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;                                
        //                        //ctl00$ContentPlaceHolder2$txtNo_Daftar
        //                        //ctl00$ContentPlaceHolder2$txtDate
        //                        case "ctl00$ContentPlaceHolder2$txtTarikh_1":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[0].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_1":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[1].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Layak_1":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[2].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_1":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 0)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[0].ItemArray[3].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_1":

        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder2$txtTarikh_2":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[0].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_2":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[1].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Layak_2":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[2].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_2":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 1)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[1].ItemArray[3].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_2":

        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder2$txtTarikh_3":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[0].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_3":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[1].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Layak_3":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[2].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_3":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 2)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[2].ItemArray[3].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_3":

        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder2$txtTarikh_4":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[0].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_4":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[1].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Layak_4":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[2].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_4":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 3)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[3].ItemArray[3].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_4":

        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder2$txtTarikh_5":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[0].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_5":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[1].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Layak_5":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[2].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_5":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 4)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[4].ItemArray[3].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_5":

        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder2$txtTarikh_6":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[0].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_6":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[1].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Layak_6":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[2].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_6":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 5)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[5].ItemArray[3].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_6":

        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder2$txtTarikh_7":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[0].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_7":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[1].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Layak_7":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[2].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_7":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 6)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[6].ItemArray[3].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_7":

        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder2$txtTarikh_8":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[0].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_8":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[1].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Layak_8":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[2].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_8":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 7)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[7].ItemArray[3].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_8":

        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder2$txtTarikh_9":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[0].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_9":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[1].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Layak_9":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[2].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_9":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 8)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[8].ItemArray[3].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_9":

        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder2$txtTarikh_10":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[0].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_10":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[1].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Layak_10":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[2].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_10":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 9)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[9].ItemArray[3].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_10":

        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder2$txtTarikh_11":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[0].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_11":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[1].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Layak_11":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[2].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_11":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 10)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[10].ItemArray[3].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_11":

        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder2$txtTarikh_12":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[0].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtAmaun_Kasar_12":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[1].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Layak_12":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[2].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtCukai_Tdk_Layak_12":
        //                            if (dsData.Tables["P1_BORANG08B"].Rows.Count > 11)
        //                                inpElement.value = dsData.Tables["P1_BORANG08B"].Rows[11].ItemArray[3].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder2$txtAmaun_Bersih_12":

        //                        //    break;
        //                        //ctl00$ContentPlaceHolder2$txtJumlah_Amaun_Kasar
        //                        //ctl00$ContentPlaceHolder2$txtJumlah_Cukai_layak
        //                        //ctl00$ContentPlaceHolder2$txtJumlah_Cukai_Tdk_layak
        //                        //ctl00$ContentPlaceHolder2$txtJumlah_Amaun_Bersih
        //                        //ctl00$ContentPlaceHolder2$btnSubmit
        //                    }
        //                    break;
        //                case "R2008Page2":
        //                    switch(inpElement.name)
        //                    {
        //                        //ctl00$ContentPlaceHolder2$txtdate2
        //                        //ctl00$ContentPlaceHolder2$txtDate
        //                        case "ctl00$ContentPlaceHolder2$txtA1":
        //                            if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
        //                                inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[1].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtA1_Tarikh":
        //                            if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
        //                            {
        //                                if (dsData.Tables["P2_BORANG08"].Rows.Count > 0 && dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[0].ToString()=="2")
        //                                    inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[2].ToString();
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            else
        //                            {
        //                                inpElement.value = "";
        //                                FireInpElementEvent(inpElement, "OnBlur");
        //                            }
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtA2":
        //                            if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
        //                                inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[3].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtA3":
        //                            if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
        //                                inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[4].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtA4":
        //                            if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
        //                                inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[5].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtA4a":
        //                            if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
        //                                inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[6].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtA4b":
        //                            if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
        //                                inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[7].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder2$txtA4c":

        //                        //    break;
        //                        //case "ctl00$ContentPlaceHolder2$txtA5":

        //                        //    break;
        //                        //case "ctl00$ContentPlaceHolder2$txtA6":

        //                        //    break;
        //                        //case "ctl00$ContentPlaceHolder2$txtA7":

        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder2$txtA8a":
        //                            if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
        //                                inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[8].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtA8b":
        //                            if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
        //                                inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[9].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtA8c":
        //                            if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
        //                                inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[10].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtA8d":
        //                            if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
        //                                inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[11].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //case "ctl00$ContentPlaceHolder2$txtA8e":

        //                        //    break;
        //                        case "ctl00$ContentPlaceHolder2$txtA9a_TT":
        //                            if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
        //                                strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[12].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[12].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtA9a_KK":
        //                            if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
        //                                inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[13].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtA9b_TT":
        //                            if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
        //                                strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[14].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[14].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtA9b_KK":
        //                            if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
        //                                inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[15].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtA9c_TT":
        //                            if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
        //                                strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[16].ToString() == "-" ? inpElement.value = "" : inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[16].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        case "ctl00$ContentPlaceHolder2$txtA9c_KK":
        //                            if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
        //                                inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[17].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                        //ctl00$ContentPlaceHolder2$txtA9d
        //                        //ctl00$ContentPlaceHolder2$txtA11
        //                        //ctl00$ContentPlaceHolder2$txtA12
        //                        //ctl00$ContentPlaceHolder2$txtA13_Label
        //                        //ctl00$ContentPlaceHolder2$txtA13a
        //                        //ctl00$ContentPlaceHolder2$txtA14
        //                        //ctl00$ContentPlaceHolder2$txtA15
        //                        //ctl00$ContentPlaceHolder2$txtA16
        //                        //ctl00$ContentPlaceHolder2$txtA17
        //                        case "ctl00$ContentPlaceHolder2$txtA10":
        //                            if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
        //                                inpElement.value = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[18].ToString();
        //                            else
        //                                inpElement.value = "";
        //                            FireInpElementEvent(inpElement, "OnBlur");
        //                            break;
        //                    }
        //                    break;
        //            }
        //        }

        //        foreach (mshtml.HTMLSelectElement selElement in htmlDoc.getElementsByTagName("select"))
        //        {
        //            switch (strPageIndex)
        //            {
        //                case "R2008Page2":
        //                    switch (selElement.name)
        //                    {
        //                        case "ctl00$ContentPlaceHolder2$ddlA1":
        //                            if (dsData.Tables["P2_BORANG08"].Rows.Count > 0)
        //                                strComparator = dsData.Tables["P2_BORANG08"].Rows[0].ItemArray[0].ToString() == "1" ? selElement.value = "1" : selElement.value = "2";
        //                            else
        //                                selElement.value = "0";
        //                            FireSelElementEvent(selElement, "OnChange");
        //                            break;
        //                    }
        //                    break;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

//        private void ProcessFormB(mshtml.HTMLDocument htmlDoc, String strPageIndex)
//        {
//            try
//            {
//                EFilingDALB dalB = new EFilingDALB(strTaxPayer, strYA, strTaxAgent);
//                DataSet dsData = dalB.GetFormDataB(strPageIndex);
//                dalB.CloseConn();
//                int intCount = 0;
//                double dblProfitLoss = 0;
//                double dblOtherSourceIn = 0;
//                double dblTemp = 0;
//                //Boolean boolLocal = true;
//                //string strComparator;
//                string[] strAddress = new string[3];
//                Boolean boolNoRecord = false;
//                foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
//                {
//                    switch (strPageIndex)
//                    {
//#region "Input Page1"
//                         case "B2008Page1":

//                             switch (inpElement.name)
//                             {
//                                 case "ctl00$master$txtF00009": //No PassPort
//                                     inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
//                                     break;
//                                 case "ctl00$master$txtf00014": //Married Date, Divoice Date, Die Date
//                                     if (dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
//                                     {
//                                         inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[4].ToString(); //Married Date
//                                     }
//                                     else if ((dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3")|| (dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
//                                     {
//                                         inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[5].ToString(); //Divoice Date
//                                     }
//                                     break;
//                                 case "ctl00$master$txtF00019": //Correspondence Address1
//                                     //strAddress = TextSpliter(
//                                     //    dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[8].ToString().ToUpper() +
//                                     //    dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[9].ToString().ToUpper() +
//                                     //    dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[10].ToString().ToUpper(), 40);
//                                     inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[8].ToString().ToUpper();
//                                     break;
//                                 case "ctl00$master$txtF00020": //Correspondence Address2
//                                     inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[9].ToString().ToUpper();
//                                     break;
//                                 case "ctl00$master$txtF00021": //Correspondence Address3
//                                     inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[10].ToString().ToUpper();
//                                     break;
//                                 case "ctl00$master$txtF00022": //Poscode
//                                     inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[11].ToString();
//                                     break;
//                                 case "ctl00$master$txtF00023": //City
//                                     inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[12].ToString().ToUpper();
//                                     break;
//                                 //case "ctl00$master$txtSurat_Negara":
//                                 //    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[11].ToString();
//                                 //    break;
//                                 case "ctl00$master$txtF00031": //Premis Address1
//                                     //strAddress = TextSpliter(
//                                     //  dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[14].ToString().ToUpper() +
//                                     //  dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[15].ToString().ToUpper() +
//                                     //  dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[16].ToString().ToUpper(), 40);
//                                     inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[14].ToString().ToUpper();
//                                     break;
//                                 case "ctl00$master$txtF00032": //Premis Address2
//                                     inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[15].ToString().ToUpper();
//                                     break;
//                                 case "ctl00$master$txtF00033": //Premis Address3
//                                     inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[16].ToString().ToUpper();
//                                     break;
//                                 case "ctl00$master$txtF00034": //Poscode
//                                     inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[17].ToString();
//                                     break;
//                                 case "ctl00$master$txtF00035": //City
//                                     inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[18].ToString().ToUpper();    
//                                     break;
//                                 //case "ctl00$master$txtNiaga_Negara":
//                                 //    inpElement.value = strAddress[2];
//                                 //    break;
//                                 case "ctl00$master$txtF00041": //Tel No.
//                                     if (String.IsNullOrEmpty(dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[20].ToString() + dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[21].ToString()))
//                                     {
//                                         inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[22].ToString() + dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[23].ToString();
//                                     }
//                                     else //Mobile No.
//                                     {
//                                         inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[20].ToString() + dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[21].ToString();
//                                     }
//                                     break;
//                                 case "ctl00$master$txtF00040": //Employer's No.
//                                     inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[24].ToString();
//                                     break;
//                                 case "ctl00$master$txtF00043": //E-mail
//                                     inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[25].ToString();
//                                     break;
//                                 case "ctl00$master$txtF00044": //Name of Bank
//                                     inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[26].ToString();
//                                     break;
//                                 case "ctl00$master$txtF00045": //Bank Acc No.
//                                     inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[27].ToString();
//                                     break;

//                             }
//                             break;
//#endregion

//#region "Input Page2"
//                         case "B2008Page2":
//                            switch (inpElement.name)
//                            {
//                                case "ctl00$master$txtF00052": //HW Name
//                                    inpElement.value = dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[0].ToString(); 
//                                    break;
//                                case "ctl00$master$txtF00055":
//                                       string strTemp = ""; //HW Reference No.
//                                       if (!String.IsNullOrEmpty(dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[2].ToString()))
//                                       {
//                                           strTemp = strTemp + dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[2].ToString();
//                                       }
//                                       if (!String.IsNullOrEmpty(dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[3].ToString()))
//                                       {
//                                           strTemp = strTemp + dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[3].ToString();
//                                       }
//                                       if (!String.IsNullOrEmpty(dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
//                                       {
//                                           strTemp = strTemp + dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[4].ToString();
//                                       }
//                                       inpElement.value = strTemp;
//                                    break;
//                                //case "ctl00$master$ddlJPengenalan_isteri":
//                                //    break;
//                                case "ctl00$master$txtF00057": //ID No.
//                                    if (!String.IsNullOrEmpty(dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[5].ToString())||
//                                        !String.IsNullOrEmpty(dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[6].ToString())||
//                                        !String.IsNullOrEmpty(dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[7].ToString()))
//                                    {
//                                        inpElement.value = dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() 
//                                            + dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[6].ToString()
//                                            + dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[7].ToString();
//                                    }
//                                    else if(!String.IsNullOrEmpty(dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[9].ToString()))
//                                    {
//                                        inpElement.value = dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
//                                    }
//                                    else if (!String.IsNullOrEmpty(dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[10].ToString()))
//                                    {
//                                        inpElement.value = dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
//                                    }
//                                    else if (!String.IsNullOrEmpty(dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[11].ToString()))
//                                    {
//                                        inpElement.value = dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[11].ToString();
//                                    }
//                                    break;
//                            }
//                            break;
//                         #endregion

//#region "Input Page3"
//                        case "B2008Page3":
//                            switch (inpElement.name)
//                            {
//                                case "ctl00$master$txtF00061": //Business1 Code
//                                    if (dsData.Tables["P3_BUSINESS_CODE"].Rows.Count > 0)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_BUSINESS_CODE"].Rows[0].ItemArray[0].ToString();
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00062": //Business1 Amount
//                                    if (dsData.Tables["P3_BUSINESS_CODE"].Rows.Count > 0)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_INCOME_ADJUSTED"].Rows[0].ItemArray[0].ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00063": //Business2 Code
//                                    if (dsData.Tables["P3_BUSINESS_CODE"].Rows.Count > 1)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_BUSINESS_CODE"].Rows[1].ItemArray[0].ToString();
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00064"://Business2 Amount
//                                    if (dsData.Tables["P3_BUSINESS_CODE"].Rows.Count > 1)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_INCOME_ADJUSTED"].Rows[1].ItemArray[0].ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00065": //Business3 Code
//                                    if (dsData.Tables["P3_BUSINESS_CODE"].Rows.Count > 2)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_BUSINESS_CODE"].Rows[2].ItemArray[0].ToString();
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00066": //Business3 Amount
//                                    double dblTempValue = 0;
//                                    if (dsData.Tables["P3_BUSINESS_CODE"].Rows.Count > 2)
//                                    {
//                                        for (int i = 2; i < dsData.Tables["P3_BUSINESS_CODE"].Rows.Count; i++)
//                                        {
//                                            dblTempValue = dblTempValue + double.Parse(dsData.Tables["P3_INCOME_ADJUSTED"].Rows[i].ItemArray[0].ToString());
//                                        }
//                                        inpElement.value = dblTempValue.ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00067": //Partner1 Code
//                                    if (dsData.Tables["P3_PARTNERSHIP_CODE"].Rows.Count > 0) 
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PARTNERSHIP_CODE"].Rows[0].ItemArray[0].ToString();
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00068": //Partner1 Amount
//                                    if (dsData.Tables["P3_PARTNERSHIP_CODE"].Rows.Count > 0) 
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PARTNERSHIP_INCOME"].Rows[0].ItemArray[0].ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00069": //Partner2 Code
//                                    if (dsData.Tables["P3_PARTNERSHIP_CODE"].Rows.Count > 1) 
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PARTNERSHIP_CODE"].Rows[1].ItemArray[0].ToString();
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00070": //Partner2 Amount
//                                    if (dsData.Tables["P3_PARTNERSHIP_CODE"].Rows.Count > 1) 
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PARTNERSHIP_INCOME"].Rows[1].ItemArray[0].ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00071": //Partner3 Code
//                                    if (dsData.Tables["P3_PARTNERSHIP_CODE"].Rows.Count > 2)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PARTNERSHIP_CODE"].Rows[2].ItemArray[0].ToString();
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00072": //Partner3 Amount
//                                    double dblTempValue2 = 0; 
//                                    if (dsData.Tables["P3_PARTNERSHIP_CODE"].Rows.Count > 2) 
//                                    {
//                                        for (int i = 2; i < dsData.Tables["P3_PARTNERSHIP_CODE"].Rows.Count; i++)
//                                        {
//                                            dblTempValue2 = dblTempValue2 + double.Parse(dsData.Tables["P3_PARTNERSHIP_INCOME"].Rows[i].ItemArray[0].ToString());
//                                        }
//                                    }
//                                    inpElement.value = dblTempValue2.ToString();
//                                    FireInpElementEvent(inpElement, "OnBlur");
//                                    break;
//                                case "ctl00$master$txtF00074":
//                                    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
//                                    FireInpElementEvent(inpElement, "OnBlur");
//                                    break;
//                                //case "ctl00$master$txtF00073":
//                                //    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
//                                //    break;
//                                case "ctl00$master$txtF00076": //Employment
//                                    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString();
//                                    FireInpElementEvent(inpElement, "OnBlur");
//                                    break;
//                                case "ctl00$master$txtF00077":
//                                    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[4].ToString();
//                                    FireInpElementEvent(inpElement, "OnBlur");
//                                    break;
//                                case "ctl00$master$txtF00078": //Interest and discounts
//                                    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[5].ToString();
//                                    FireInpElementEvent(inpElement, "OnBlur");
//                                    break;
//                                case "ctl00$master$txtF00079": //Rent, royalty and payment
//                                    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[6].ToString();
//                                    FireInpElementEvent(inpElement, "OnBlur");
//                                    break;
//                                case "ctl00$master$txtF00080": //pencen, annuity and other periodical payments
//                                    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[7].ToString();
//                                    FireInpElementEvent(inpElement, "OnBlur");
//                                    break;
//                                case "ctl00$master$txtF00081": //Other gains and profit
//                                    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[8].ToString();
//                                    FireInpElementEvent(inpElement, "OnBlur");
//                                    break;
//                                case "ctl00$master$txtF00082": //additional pursuant on paragraph 43(1)(c)
//                                    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[9].ToString();
//                                    FireInpElementEvent(inpElement, "OnBlur");
//                                    break;
//                                case "ctl00$master$txtF00085": //current year business loss
//                                    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[11].ToString();
//                                    FireInpElementEvent(inpElement, "OnBlur");
//                                    break;
//                                case "ctl00$master$txtF00087": //Schedule 4 paragraph 44(1)(b)
//                                    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[12].ToString();
//                                    FireInpElementEvent(inpElement, "OnBlur");
//                                    break;
//                                case "ctl00$master$txtF00088": //Schedule 4A paragraph 44(1)(b)
//                                    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[13].ToString();
//                                    FireInpElementEvent(inpElement, "OnBlur");
//                                    break;
//                                case "ctl00$master$ImageButton3":
//                                    FireInpElementEvent(inpElement, "OnClick");
//                                    break;
//                                case "ctl00$master$txtF00090": //Goverment
//                                    foreach (DataRow row in dsData.Tables["P3_TAX_GIFTS"].Rows)
//                                    {
//                                        if (row.ItemArray[0].ToString() == "9")
//                                            inpElement.value = row.ItemArray[1].ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00393": //Organisation Approval
//                                    foreach (DataRow row in dsData.Tables["P3_TAX_GIFTS"].Rows)
//                                    {
//                                        if (row.ItemArray[0].ToString() == "1")
//                                            inpElement.value = row.ItemArray[1].ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00389": //Sport Activity
//                                    foreach (DataRow row in dsData.Tables["P3_TAX_GIFTS"].Rows)
//                                    {
//                                        if (row.ItemArray[0].ToString() == "7")
//                                            inpElement.value = row.ItemArray[1].ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00390": //Project Approval
//                                    foreach (DataRow row in dsData.Tables["P3_TAX_GIFTS"].Rows)
//                                    {
//                                        if (row.ItemArray[0].ToString() == "8")
//                                            inpElement.value = row.ItemArray[1].ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                //case "ctl00$master$txtF00394": //Artefact
//                                //    foreach (DataRow row in dsData.Tables["P3_TAX_GIFTS"].Rows)
//                                //    {
//                                //        if (row.ItemArray[0].ToString() == "2")
//                                //            inpElement.value = row.ItemArray[1].ToString();
//                                //        FireInpElementEvent(inpElement, "OnBlur");
//                                //    }
//                                //    break;
//                                case "ctl00$master$txtF00091": //Artefact
//                                    foreach (DataRow row in dsData.Tables["P3_TAX_GIFTS"].Rows)
//                                    {
//                                        if (row.ItemArray[0].ToString() == "2")
//                                            inpElement.value = row.ItemArray[1].ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00092":  //Provision of library facilities
//                                    foreach (DataRow row in dsData.Tables["P3_TAX_GIFTS"].Rows)
//                                    {
//                                        if (row.ItemArray[0].ToString() == "3")
//                                            inpElement.value = row.ItemArray[1].ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00093": //Disabled person
//                                    foreach (DataRow row in dsData.Tables["P3_TAX_GIFTS"].Rows)
//                                    {
//                                        if (row.ItemArray[0].ToString() == "4")
//                                            inpElement.value = row.ItemArray[1].ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00094": //Medical equipment
//                                    foreach (DataRow row in dsData.Tables["P3_TAX_GIFTS"].Rows)
//                                    {
//                                        if (row.ItemArray[0].ToString() == "5")
//                                            inpElement.value = row.ItemArray[1].ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00095": //Painting
//                                    foreach (DataRow row in dsData.Tables["P3_TAX_GIFTS"].Rows)
//                                    {
//                                        if (row.ItemArray[0].ToString() == "6")
//                                            inpElement.value = row.ItemArray[1].ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;

//                                //case "ctl00$master$txtF00096":
//                                //    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[18].ToString();
//                                //    break;
//                                case "ctl00$master$txtF00349": //Pioneer Income
//                                    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[18].ToString();
//                                    FireInpElementEvent(inpElement, "OnBlur");
//                                    break;
//                                //case "ctl00$master$txtF00098":
//                                //    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[20].ToString();
//                                //    break;
//                                case "ctl00$master$txtF00099": //HW Income Transfer
//                                    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[20].ToString();
//                                    FireInpElementEvent(inpElement, "OnBlur");
//                                    break;
//                                case "ctl00$master$txtF00165": //Instalment/ Schedular Tax Deduction if HW join assessment
//                                    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[22].ToString();
//                                    FireInpElementEvent(inpElement, "OnBlur");
//                                    break;

//                                case "ctl00$master$txtF00169": //Type of Income 1
//                                    if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 0)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[0].ItemArray[0].ToString();
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00170": //Payment Year 1
//                                    if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 0)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[0].ItemArray[1].ToString();
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00171": //Gross Amount 1
//                                    if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 0)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[0].ItemArray[2].ToString();
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00172": //Provision and Pension fund 1
//                                    if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 0)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[0].ItemArray[3].ToString();
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00173": //Type of Income 2
//                                    if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 1)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[1].ItemArray[0].ToString();
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00174": //Payment Year 2
//                                    if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 1)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[1].ItemArray[1].ToString();
//                                    }
//                                         break;
//                                case "ctl00$master$txtF00175": //Gross Amount 2
//                                    if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 1)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[1].ItemArray[2].ToString();
                                       
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00176": //Provision and Pension fund 2
//                                    if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 1)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[1].ItemArray[3].ToString();
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00177": //Type of Income 3
//                                    if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 2)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[2].ItemArray[0].ToString();
//                                    }
//                                    break;

//                                case "ctl00$master$txtF00178": //Payment Year 3
//                                    if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 2)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[2].ItemArray[1].ToString();
//                                    }
//                                    break;

//                                case "ctl00$master$txtF00179": //Gross Amount 3
//                                    if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 2)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[2].ItemArray[2].ToString();
//                                    }
//                                    break;

//                                case "ctl00$master$txtF00180": //Provision and Pension fund 3
//                                    if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 2)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[2].ItemArray[3].ToString();
//                                    }
//                                    break;

//                                case "ctl00$master$txtF00361": //Type of Income 4
//                                    if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 3)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[3].ItemArray[0].ToString();
//                                    }
//                                    break;

//                                case "ctl00$master$txtF00362": //Payment Year 4
//                                    if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 3)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[3].ItemArray[1].ToString();
//                                    }
//                                    break;

//                                case "ctl00$master$txtF00363": //Gross Amount 4
//                                    if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 3)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[3].ItemArray[2].ToString();
//                                    }
//                                    break;

//                                case "ctl00$master$txtF00364": //Provision and Pension fund 4
//                                    if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 3)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[3].ItemArray[3].ToString();
//                                    }
//                                    break;

//                                case "ctl00$master$txtF00365": //Type of Income 5
//                                    if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 4)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[4].ItemArray[0].ToString();
//                                    }
//                                    break;

//                                case "ctl00$master$txtF00366": //Payment Year 5
//                                    if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 4)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[4].ItemArray[1].ToString();
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00367": //Gross Amount 5
//                                    if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 4)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[4].ItemArray[2].ToString();
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00368": //Provision and Pension fund 5
//                                    if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 4)
//                                    {
//                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[4].ItemArray[3].ToString();
//                                    }
//                                    break;
//                            }
//                            break;
//#endregion

//#region "Input Page4"
//                        case "B2008Page4": //Pelepasan
//                                switch (inpElement.name)
//                                {
//                                    case "ctl00$master$txtF00104": //D1
//                                        foreach (DataRow row in dsData.Tables["P4_TAX_RELIEF"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "1")
//                                            inpElement.value = row.ItemArray[1].ToString();
//                                        }
//                                        break;
//                                    case "ctl00$master$txtF00105": //D2
//                                        foreach (DataRow row in dsData.Tables["P4_TAX_RELIEF"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "2")
//                                                inpElement.value = row.ItemArray[1].ToString();
//                                        }
//                                        break;
//                                    case "ctl00$master$txtF00106": //D3
//                                        foreach (DataRow row in dsData.Tables["P4_TAX_RELIEF"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "3")
//                                                inpElement.value = row.ItemArray[1].ToString();
//                                        }
//                                        break;
//                                    case "ctl00$master$txtF00107": //D4
//                                        foreach (DataRow row in dsData.Tables["P4_TAX_RELIEF"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "4")
//                                                inpElement.value = row.ItemArray[1].ToString();
//                                        }
//                                        break;
//                                    case "ctl00$master$txtF00108": //D5
//                                        foreach (DataRow row in dsData.Tables["P4_TAX_RELIEF"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "5")
//                                                inpElement.value = row.ItemArray[1].ToString();
//                                        }
//                                        break;
//                                    case "ctl00$master$txtF00109": //D6
//                                        foreach (DataRow row in dsData.Tables["P4_TAX_RELIEF"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "6")
//                                                inpElement.value = row.ItemArray[1].ToString();
//                                        }
//                                        break;
//                                    case "ctl00$master$txtF00110": //D7
//                                        foreach (DataRow row in dsData.Tables["P4_TAX_RELIEF"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "7")
//                                                inpElement.value = row.ItemArray[1].ToString();
//                                        }
//                                        break;
//                                    case "ctl00$master$txtF00112": //D8
//                                        foreach (DataRow row in dsData.Tables["P4_TAX_RELIEF"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "8")
//                                                inpElement.value = row.ItemArray[1].ToString();
//                                        }
//                                        break;
//                                    case "ctl00$master$txtF00391": //D8A
//                                        foreach (DataRow row in dsData.Tables["P4_TAX_RELIEF"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "21")
//                                                inpElement.value = row.ItemArray[1].ToString();
//                                        }
//                                        break;
//                                    case "ctl00$master$txtF00392": //D8B
//                                        foreach (DataRow row in dsData.Tables["P4_TAX_RELIEF"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "22")
//                                                inpElement.value = row.ItemArray[1].ToString();
//                                        }
//                                        break;
//                                    case "ctl00$master$txtF00395": //D8C
//                                        foreach (DataRow row in dsData.Tables["P4_TAX_RELIEF"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "23")
//                                                inpElement.value = row.ItemArray[1].ToString();
//                                        }
//                                        break;
//                                    case "ctl00$master$txtF00116": //D9
//                                        foreach (DataRow row in dsData.Tables["P4_TAX_RELIEF"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "10")
//                                                inpElement.value = row.ItemArray[1].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00118": //D10
//                                        double dblDisableHW = 0;
//                                        foreach (DataRow row in dsData.Tables["P4_TAX_RELIEF"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "10")
//                                            {
//                                                dblDisableHW = double.Parse(row.ItemArray[1].ToString());
//                                            }
//                                            else if (row.ItemArray[0].ToString() == "13")
//                                            {
//                                                if (dblDisableHW != 0)
//                                                {
//                                                    inpElement.value = row.ItemArray[1].ToString();
//                                                    FireInpElementEvent(inpElement, "OnBlur");
//                                                }
//                                            }
//                                        }
//                                        break;
//                                    case "ctl00$master$ImageButton4":
//                                        FireInpElementEvent(inpElement, "OnClick");
//                                        break;
//                                    case "ctl00$master$txtF00140": //KWSP
//                                        foreach (DataRow row in dsData.Tables["P4_TAX_RELIEF"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "17")
//                                                inpElement.value = row.ItemArray[1].ToString();
//                                        }
//                                        break;
//                                    case "ctl00$master$txtF00141": //Education and medical insurance.
//                                        foreach (DataRow row in dsData.Tables["P4_TAX_RELIEF"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "18")
//                                                inpElement.value = row.ItemArray[1].ToString();
//                                        }
//                                        break;
//                                    case "ctl00$master$txtF00396": //No. child eligible for deduction
//                                        intCount = 0;
//                                        foreach (DataRow row in dsData.Tables["P4_RELIEF_CHILD"].Rows)
//                                        { 
//                                            if (!String.IsNullOrEmpty(row.ItemArray[1].ToString()))
//                                            { intCount ++; }
//                                              if (!String.IsNullOrEmpty(row.ItemArray[2].ToString()))
//                                            { intCount ++; }   
                                           
//                                        }
//                                        foreach (DataRow row in dsData.Tables["P4_RELIEF_HWCHILD"].Rows)
//                                        {
//                                            if (!String.IsNullOrEmpty(row.ItemArray[1].ToString()))
//                                            { intCount++; }
//                                            if (!String.IsNullOrEmpty(row.ItemArray[2].ToString()))
//                                            { intCount++; }

//                                        }
//                                        inpElement.value = intCount.ToString();
//                                        break;
//                                    case "ctl00$master$txtF00397": //No. child claim by own self
//                                        intCount = 0;
//                                        foreach (DataRow row in dsData.Tables["P4_RELIEF_CHILD"].Rows)
//                                        {
//                                            if (!String.IsNullOrEmpty(row.ItemArray[1].ToString()))
//                                            { intCount++; }
//                                            if (!String.IsNullOrEmpty(row.ItemArray[2].ToString()))
//                                            { intCount++; }

//                                        }
//                                        inpElement.value = intCount.ToString();
//                                        break;
//                                    case "ctl00$master$txtF00398": //No. child claim by hw
//                                        intCount = 0;
//                                        foreach (DataRow row in dsData.Tables["P4_RELIEF_HWCHILD"].Rows)
//                                        {
//                                            if (!String.IsNullOrEmpty(row.ItemArray[1].ToString()))
//                                            { intCount++; }
//                                            if (!String.IsNullOrEmpty(row.ItemArray[2].ToString()))
//                                            { intCount++; }

//                                        }
//                                        inpElement.value = intCount.ToString();
//                                        break;
//                                    case "ctl00$master$txtF00120": //child under age 18 (100%)
//                                        intCount = 0;
//                                        foreach (DataRow row in dsData.Tables["P4_RELIEF_CHILD"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "14")
//                                            {
//                                                if (!String.IsNullOrEmpty(row.ItemArray[1].ToString()))
//                                                {
//                                                    if (double.Parse(row.ItemArray[1].ToString()) == 1000)
//                                                    { intCount++; }
//                                                }
//                                            }

//                                        }
//                                        inpElement.value = intCount.ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;

//                                    case "ctl00$master$txtF00122": //child under age 18 (50%)
//                                        intCount = 0;
//                                        foreach (DataRow row in dsData.Tables["P4_RELIEF_CHILD"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "14")
//                                            {
//                                                if (!String.IsNullOrEmpty(row.ItemArray[2].ToString()))
//                                                {
//                                                    if (double.Parse(row.ItemArray[2].ToString()) == 500)
//                                                    { intCount++; }
//                                                }

//                                            }
//                                        }
//                                        inpElement.value = intCount.ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;

//                                    case "ctl00$master$txtF00357": //child age 18 and above claim RM1000(100%)
//                                        intCount = 0;
//                                        foreach (DataRow row in dsData.Tables["P4_RELIEF_CHILD"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "15")
//                                            {
//                                                if (!String.IsNullOrEmpty(row.ItemArray[1].ToString()))
//                                                {
//                                                    if (double.Parse(row.ItemArray[1].ToString()) == 1000)
//                                                    { intCount++; }
//                                                }
//                                            }
//                                        }
//                                        inpElement.value = intCount.ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;

//                                    case "ctl00$master$txtF00359": //child age 8 and above claim RM4000(100%)
//                                        intCount = 0;
//                                        foreach (DataRow row in dsData.Tables["P4_RELIEF_CHILD"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "15")
//                                            {
//                                                if (!String.IsNullOrEmpty(row.ItemArray[1].ToString()))
//                                                {
//                                                    if (double.Parse(row.ItemArray[1].ToString()) == 4000)
//                                                    { intCount++; }
//                                                }
//                                            }
//                                        }
//                                        inpElement.value = intCount.ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;

//                                    case "ctl00$master$txtF00358": //child age 18 and above claim RM500(50%)
//                                        intCount = 0;
//                                        foreach (DataRow row in dsData.Tables["P4_RELIEF_CHILD"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "15")
//                                            {
//                                                if (!String.IsNullOrEmpty(row.ItemArray[2].ToString()))
//                                                {
//                                                    if (double.Parse(row.ItemArray[2].ToString()) == 500)
//                                                    { intCount++; }
//                                                }
//                                            }
//                                        }
//                                        inpElement.value = intCount.ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;

//                                    case "ctl00$master$txtF00360": //child age 18 and above claim RM2000(50%)
//                                        intCount = 0;
//                                        foreach (DataRow row in dsData.Tables["P4_RELIEF_CHILD"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "15")
//                                            {
//                                                if (!String.IsNullOrEmpty(row.ItemArray[2].ToString()))
//                                                {
//                                                    if (double.Parse(row.ItemArray[2].ToString()) == 2000)
//                                                    { intCount++; }
//                                                }
//                                            }
//                                        }
//                                        inpElement.value = intCount.ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00135":  //child disabled claim RM5000(100%)
//                                        intCount = 0;
//                                        foreach (DataRow row in dsData.Tables["P4_RELIEF_CHILD"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "16")
//                                            {
//                                                if (!String.IsNullOrEmpty(row.ItemArray[1].ToString()))
//                                                {
//                                                    if (double.Parse(row.ItemArray[1].ToString()) == 5000)
//                                                    { intCount++; }
//                                                }
//                                            }
//                                        }
//                                        inpElement.value = intCount.ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00369": //child disabled claim RM9000(100%)
//                                        intCount = 0;
//                                        foreach (DataRow row in dsData.Tables["P4_RELIEF_CHILD"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "16")
//                                            {
//                                                if (!String.IsNullOrEmpty(row.ItemArray[1].ToString()))
//                                                {
//                                                    if (double.Parse(row.ItemArray[1].ToString()) == 9000)
//                                                    { intCount++; }
//                                                }
//                                            }
//                                        }
//                                        inpElement.value = intCount.ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00137": //child disabled claim RM2500(50%)
//                                        intCount = 0;
//                                        foreach (DataRow row in dsData.Tables["P4_RELIEF_CHILD"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "16")
//                                            {
//                                                if (!String.IsNullOrEmpty(row.ItemArray[2].ToString()))
//                                                {
//                                                    if (double.Parse(row.ItemArray[2].ToString()) == 2500)
//                                                    { intCount++; }
//                                                }
//                                            }
//                                        }
//                                        inpElement.value = intCount.ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00370": //child disabled claim RM4500(50%)
//                                        intCount = 0;
//                                        foreach (DataRow row in dsData.Tables["P4_RELIEF_CHILD"].Rows)
//                                        {
//                                            if (row.ItemArray[0].ToString() == "16")
//                                            {
//                                                if (!String.IsNullOrEmpty(row.ItemArray[2].ToString()))
//                                                {
//                                                    if (double.Parse(row.ItemArray[2].ToString()) == 4500)
//                                                    { intCount++; }
//                                                }
//                                            }
//                                        }
//                                        inpElement.value = intCount.ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                            }
//                            break;
                            
//#endregion

//#region "Input Page5"
//                               case "B2008Page5":
//                                   //string[] strArray = new string[5];
//                                   //strArray.Initialize();
//                                   //foreach (DataRow row in dsData.Tables["P5_TAX_REBATE"].Rows)
//                                   //{
//                                   //    switch (row.ItemArray[0].ToString())
//                                   //    {
//                                   //        case "1":
//                                   //            strArray[0] = row.ItemArray[1].ToString();
//                                   //            break;
//                                   //        case "2":
//                                   //            strArray[1] = row.ItemArray[1].ToString();
//                                   //            break;
//                                   //        case "3":
//                                   //            strArray[2] = row.ItemArray[1].ToString();
//                                   //            break;
//                                   //        case "4":
//                                   //            strArray[3] = row.ItemArray[1].ToString();
//                                   //            break;
//                                   //        case "5":
//                                   //            strArray[4] = row.ItemArray[1].ToString();
//                                   //            break;
//                                   //    }

//                                   //}
//                                   switch (inpElement.name) //Rebate
//                                   {
//                                       case "ctl00$master$txtF00155": //Zakat atau fitrah
//                                           foreach (DataRow row in dsData.Tables["P5_TAX_REBATE"].Rows)
//                                           {
//                                               if (row.ItemArray[0].ToString() == "3")
//                                               {
//                                                   inpElement.value = row.ItemArray[1].ToString();
//                                                   break;
//                                               }
//                                               //else
//                                               //{
//                                               //    inpElement.value = "0";
//                                               //}
//                                           }
//                                           //inpElement.value = strArray[2];
//                                           FireInpElementEvent(inpElement, "OnBlur"); 
//                                           break;
//                                       case "ctl00$master$txtF00157": //Fi atau Levi
//                                           foreach (DataRow row in dsData.Tables["P5_TAX_REBATE"].Rows)
//                                           {
//                                               if (row.ItemArray[0].ToString() == "5")
//                                               {
//                                                   inpElement.value = row.ItemArray[1].ToString();
//                                                   break;
//                                               }
//                                               //else
//                                               //{
//                                               //    inpElement.value = "0";
//                                               //}
//                                           }
//                                           //inpElement.value = strArray[4];
//                                           FireInpElementEvent(inpElement, "OnBlur");
//                                           break;
//                                       case "ctl00$master$txtF00160": //Dividend
//                                           inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString();
//                                           FireInpElementEvent(inpElement, "OnBlur");
//                                           break;
//                                       case "ctl00$master$txtF00161": //Cukai section 110
//                                           inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
//                                           FireInpElementEvent(inpElement, "OnBlur");
//                                           break;
//                                       case "ctl00$master$txtF00346": //Pelepasan cukai section 132
//                                           inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
//                                           FireInpElementEvent(inpElement, "OnBlur");
//                                           break;
//                                       case "ctl00$master$txtF00347": //Pelepasan cukai section 133
//                                           inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString();
//                                           FireInpElementEvent(inpElement, "OnBlur");
//                                           break;
//                                   }
//                                   break;
//                        #endregion

//#region "Input Page6"
//                        case "B2008Page6": //Perniagaan
//                            switch (inpElement.name)
//                            {
//                                case "ctl00$master$txtF00190": //Balance of current year loss
//                                    inpElement.value = dsData.Tables["P6_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
//                                    FireInpElementEvent(inpElement, "OnBlur");
//                                    break;
//                                case "ctl00$master$txtF00191": //Balance from previous year losses
//                                    inpElement.value = dsData.Tables["P6_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
//                                    FireInpElementEvent(inpElement, "OnBlur");
//                                    break;
//                                case "ctl00$master$txtF00351": //Pioneer loss amount absorbed 
//                                    inpElement.value = dsData.Tables["P6_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString();
//                                    FireInpElementEvent(inpElement, "OnBlur");
//                                    break;
//                                case "ctl00$master$txtF00352": //Pioneer loss balance carried forward
//                                    inpElement.value = dsData.Tables["P6_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString();
//                                    FireInpElementEvent(inpElement, "OnBlur");
//                                    break;
//                                case "ctl00$master$txtF00193": //Business1 allowance absorbed
//                                    if (dsData.Tables["P6_INCOME_ADJUSTED"].Rows.Count > 0)
//                                    {
//                                        inpElement.value = dsData.Tables["P6_INCOME_ADJUSTED"].Rows[0].ItemArray[0].ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00194": //Business1 balance carried forward
//                                    if (dsData.Tables["P6_INCOME_ADJUSTED"].Rows.Count > 0)
//                                    {
//                                        inpElement.value = dsData.Tables["P6_INCOME_ADJUSTED"].Rows[0].ItemArray[1].ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00195": //Business2 allowance absorbed
//                                    if (dsData.Tables["P6_INCOME_ADJUSTED"].Rows.Count > 1)
//                                    {
//                                        inpElement.value = dsData.Tables["P6_INCOME_ADJUSTED"].Rows[1].ItemArray[0].ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00196": //Business2 balance carried forward
//                                    if (dsData.Tables["P6_INCOME_ADJUSTED"].Rows.Count > 1)
//                                    {
//                                        inpElement.value = dsData.Tables["P6_INCOME_ADJUSTED"].Rows[1].ItemArray[1].ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00197": //Business3 + 4 and above allowance absorbed
//                                    double dblTotalBusinessAA = 0;
//                                    if (dsData.Tables["P6_INCOME_ADJUSTED"].Rows.Count > 2)
//                                    {
//                                        for (int i = 2; i < dsData.Tables["P6_INCOME_ADJUSTED"].Rows.Count; i++)
//                                        {
//                                            dblTotalBusinessAA = dblTotalBusinessAA + double.Parse(dsData.Tables["P6_INCOME_ADJUSTED"].Rows[i].ItemArray[0].ToString());
//                                        }
//                                        inpElement.value = dblTotalBusinessAA.ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00198": //Business3 + 4 and above balance carried forward
//                                    double dblTotalBusinessCF = 0;
//                                    if (dsData.Tables["P6_INCOME_ADJUSTED"].Rows.Count > 2)
//                                    {
//                                        for (int i = 2; i < dsData.Tables["P6_INCOME_ADJUSTED"].Rows.Count; i++)
//                                        {
//                                            dblTotalBusinessCF = dblTotalBusinessCF + double.Parse(dsData.Tables["P6_INCOME_ADJUSTED"].Rows[i].ItemArray[1].ToString());

//                                        }
//                                        inpElement.value = dblTotalBusinessCF.ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00199": //Partnership1 allowance absorbed
//                                    if (dsData.Tables["P6_PARTNER_INCOME"].Rows.Count > 0)
//                                    {
//                                        inpElement.value = dsData.Tables["P6_PARTNER_INCOME"].Rows[0].ItemArray[0].ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00200": //Partnership1 balance carried forward
//                                    if (dsData.Tables["P6_PARTNER_INCOME"].Rows.Count > 0)
//                                    {
//                                        inpElement.value = dsData.Tables["P6_PARTNER_INCOME"].Rows[0].ItemArray[1].ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00201": //Partnership2 allowance absorbed
//                                    if (dsData.Tables["P6_PARTNER_INCOME"].Rows.Count > 1)
//                                    {
//                                        inpElement.value = dsData.Tables["P6_PARTNER_INCOME"].Rows[1].ItemArray[0].ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");               
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00202": //Partnership2 balance carried forward
//                                    if (dsData.Tables["P6_PARTNER_INCOME"].Rows.Count > 1)
//                                    {
//                                        inpElement.value = dsData.Tables["P6_PARTNER_INCOME"].Rows[1].ItemArray[1].ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00203": //Partnership3 + 4 balance carried forward
//                                    double dblTotalPartnerAA = 0;
//                                    if (dsData.Tables["P6_PARTNER_INCOME"].Rows.Count > 2)
//                                    {
//                                        for (int i = 2; i < dsData.Tables["P6_PARTNER_INCOME"].Rows.Count; i++)
//                                        {
//                                            dblTotalPartnerAA = dblTotalPartnerAA + double.Parse(dsData.Tables["P6_PARTNER_INCOME"].Rows[i].ItemArray[0].ToString());
//                                        }
//                                        inpElement.value = dblTotalPartnerAA.ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00204": //Partnership3 + 4 balance carried forward
//                                    double dblTotalPartnerCF = 0;
//                                    if (dsData.Tables["P6_PARTNER_INCOME"].Rows.Count > 2)
//                                    {
//                                        for (int i = 2; i < dsData.Tables["P6_PARTNER_INCOME"].Rows.Count; i++)
//                                        {
//                                            dblTotalPartnerCF =  dblTotalPartnerCF + double.Parse(dsData.Tables["P6_PARTNER_INCOME"].Rows[i].ItemArray[1].ToString());
//                                        }
//                                        inpElement.value = dblTotalPartnerCF.ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00205": //Sec 107A Total Gross Amount
//                                    foreach (DataRow row in dsData.Tables["P6_WITHOLDING_TAX"].Rows)
//                                    {
//                                        if (row.ItemArray[0].ToString() == "1")
//                                        {
//                                            inpElement.value = row.ItemArray[1].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00206": //Sec 107A Total Tax Witheld
//                                    foreach (DataRow row in dsData.Tables["P6_WITHOLDING_TAX"].Rows)
//                                    {
//                                        if (row.ItemArray[0].ToString() == "1")
//                                        {
//                                            inpElement.value = (double.Parse(row.ItemArray[2].ToString()) + 
//                                                double.Parse(row.ItemArray[3].ToString())).ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00207": //Sec 109 Total Gross Amount
//                                    foreach (DataRow row in dsData.Tables["P6_WITHOLDING_TAX"].Rows)
//                                    {
//                                        if (row.ItemArray[0].ToString() == "2")
//                                        {
//                                            inpElement.value = row.ItemArray[1].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00208": //Sec 109 Total Tax Witheld
//                                    foreach (DataRow row in dsData.Tables["P6_WITHOLDING_TAX"].Rows)
//                                    {
//                                        if (row.ItemArray[0].ToString() == "2")
//                                        {
//                                            inpElement.value = row.ItemArray[2].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00209": //Sec 109A Total Gross Amount
//                                    foreach (DataRow row in dsData.Tables["P6_WITHOLDING_TAX"].Rows)
//                                    {
//                                        if (row.ItemArray[0].ToString() == "3")
//                                        {
//                                            inpElement.value = row.ItemArray[1].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00210": //Sec 109A Total Tax Witheld
//                                    foreach (DataRow row in dsData.Tables["P6_WITHOLDING_TAX"].Rows)
//                                    {
//                                        if (row.ItemArray[0].ToString() == "3")
//                                        {
//                                            inpElement.value = row.ItemArray[2].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00309": //Sec 109B Total Gross Amount
//                                    foreach (DataRow row in dsData.Tables["P6_WITHOLDING_TAX"].Rows)
//                                    {
//                                        if (row.ItemArray[0].ToString() == "4")
//                                        {
//                                            inpElement.value = row.ItemArray[1].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                                case "ctl00$master$txtF00211": //Sec 109B Total Tax Witheld
//                                    foreach (DataRow row in dsData.Tables["P6_WITHOLDING_TAX"].Rows)
//                                    {
//                                        if (row.ItemArray[0].ToString() == "4")
//                                        {
//                                            inpElement.value = row.ItemArray[2].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                    }
//                                    break;
//                            }
//                            break;
//#endregion 

//#region "Input Page7"
//                        case "B2008Page7": //Khas
//                            {
//                                string[] strArray2 = new string[6];
//                                string[] strClaimCode = new string[2];
//                                strArray2.Initialize();
//                                strClaimCode.Initialize();
//                                foreach (DataRow row in dsData.Tables["P7_INCENTIVE_CLAIM"].Rows)
//                                {
//                                   switch (row.ItemArray[0].ToString())
//                                   {
//                                       case "1": 
//                                           strArray2[0] = row.ItemArray[2].ToString();
//                                           strClaimCode[0] = row.ItemArray[1].ToString();
//                                           break;
//                                       case "2": 
//                                           strArray2[1] = row.ItemArray[2].ToString();
//                                           strClaimCode[1] = row.ItemArray[1].ToString();
//                                           break;
//                                       case "3": 
//                                           strArray2[2] = row.ItemArray[2].ToString();
//                                           break;
//                                       case "4": 
//                                           strArray2[3] = row.ItemArray[2].ToString();
//                                           break;
//                                       case "5": 
//                                           strArray2[4] = row.ItemArray[2].ToString();
//                                           break;
//                                       case "6": 
//                                           strArray2[5] = row.ItemArray[2].ToString();
//                                           break;
//                                   }
//                                }
//                                switch (inpElement.name)
//                                {
//                                    case "ctl00$master$txtF00212": //Claim Code1
//                                        if (dsData.Tables["P7_ADJUSTED_FURTHER"].Rows.Count > 0)
//                                        {
//                                            inpElement.value = dsData.Tables["P7_ADJUSTED_FURTHER"].Rows[0].ItemArray[0].ToString();
//                                        }
//                                        break;
//                                    case "ctl00$master$txtF00213": //Amount1
//                                        if (dsData.Tables["P7_ADJUSTED_FURTHER"].Rows.Count > 0)
//                                        {
//                                            inpElement.value = dsData.Tables["P7_ADJUSTED_FURTHER"].Rows[0].ItemArray[1].ToString();
//                                            FireInpElementEvent(inpElement, "OnBlur");
//                                        }
//                                        break;
//                                    case "ctl00$master$txtF00214": //Claim Code2
//                                        if (dsData.Tables["P7_ADJUSTED_FURTHER"].Rows.Count > 1)
//                                        {
//                                            inpElement.value = dsData.Tables["P7_ADJUSTED_FURTHER"].Rows[1].ItemArray[0].ToString();
//                                        }
//                                        break;
//                                    case "ctl00$master$txtF00215": //Amount2
//                                        if (dsData.Tables["P7_ADJUSTED_FURTHER"].Rows.Count > 1)
//                                        {
//                                            inpElement.value = dsData.Tables["P7_ADJUSTED_FURTHER"].Rows[1].ItemArray[1].ToString();
//                                            FireInpElementEvent(inpElement, "OnBlur");
//                                        }
//                                        break;
//                                    case "ctl00$master$txtF00216": //Claim Code3
//                                        if (dsData.Tables["P7_ADJUSTED_FURTHER"].Rows.Count > 2)
//                                        {
//                                            inpElement.value = dsData.Tables["P7_ADJUSTED_FURTHER"].Rows[2].ItemArray[0].ToString();
//                                        }
//                                        break;
//                                    case "ctl00$master$txtF00217": //Amount3
//                                        if (dsData.Tables["P7_ADJUSTED_FURTHER"].Rows.Count > 2)
//                                        {
//                                            inpElement.value = dsData.Tables["P7_ADJUSTED_FURTHER"].Rows[2].ItemArray[1].ToString();
//                                            FireInpElementEvent(inpElement, "OnBlur");
//                                        }
//                                        break;
//                                    case "ctl00$master$txtF00218": //Claim Code4
//                                        if (dsData.Tables["P7_ADJUSTED_FURTHER"].Rows.Count > 3)
//                                        {
//                                            inpElement.value = dsData.Tables["P7_ADJUSTED_FURTHER"].Rows[3].ItemArray[0].ToString();
//                                        }
//                                        break;
//                                    case "ctl00$master$txtF00219": //Amount4
//                                        if (dsData.Tables["P7_ADJUSTED_FURTHER"].Rows.Count > 3)
//                                        {
//                                            inpElement.value = dsData.Tables["P7_ADJUSTED_FURTHER"].Rows[3].ItemArray[1].ToString();
//                                            FireInpElementEvent(inpElement, "OnBlur");
//                                        }
//                                        break;
//                                    //case "ctl00$master$txtF00220":
//                                    //    inpElement.value = strClaimCode[0];
//                                    //    FireInpElementEvent(inpElement, "OnBlur");
//                                    //    break;


//                                    // ****************Incentive Claim ********************* //
//                                    case "ctl00$master$txtF00221": //Schedule 7A Amount absorbed
//                                        inpElement.value = strClaimCode[0];
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00222": //Schedule 7A Balance carried forward
//                                        inpElement.value = strArray2[0];
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00223": //Export Allowance Amount absorbed
//                                        inpElement.value = strClaimCode[1];
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00224": //Export Allowance Balance carried forward
//                                        inpElement.value = strArray2[1];
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00225": //Schedule 4 Balance carried forward
//                                        inpElement.value = strArray2[2];
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00226": //Schedule 4A Balance carried forward
//                                        inpElement.value = strArray2[3];
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00353": //Pioneer Income
//                                        inpElement.value = strArray2[4];
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00382": //Approve Food and Production
//                                        inpElement.value = strArray2[5];
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                }
//                            }
//                            break;
//#endregion

//#region "Input Page8"
//                        case "B2008Page8":
//                            {
//                                switch (inpElement.name)
//                                {
//                                    case "ctl00$master$txtNama_Niaga": //M1
//                                        if (!string.IsNullOrEmpty(dsData.Tables["P8_PNL_BCCODE"].Rows[0].ItemArray[0].ToString()))
//                                        inpElement.value = dsData.Tables["P8_PNL_BCCODE"].Rows[0].ItemArray[0].ToString();
//                                        break;
//                                    case "ctl00$master$txtF00227": //M1A (Code)
//                                        if (!string.IsNullOrEmpty(dsData.Tables["P8_PNL_BCCODE"].Rows[0].ItemArray[1].ToString())) 
//                                        inpElement.value = dsData.Tables["P8_PNL_BCCODE"].Rows[0].ItemArray[1].ToString();
//                                        break;
//                                    case "ctl00$master$txtF00228":  //M2
//                                        inpElement.value = dsData.Tables["P8_PNL_INCOME"].Rows[0].ItemArray[1].ToString();
//                                        dblProfitLoss = dblProfitLoss + double.Parse(dsData.Tables["P8_PNL_INCOME"].Rows[0].ItemArray[1].ToString());
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00229": //M3
//                                        inpElement.value = dsData.Tables["P8_PNL_INCOME"].Rows[0].ItemArray[2].ToString();
//                                        dblProfitLoss = dblProfitLoss - double.Parse(dsData.Tables["P8_PNL_INCOME"].Rows[0].ItemArray[2].ToString());
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00230": //M4
//                                        inpElement.value = dsData.Tables["P8_PNL_INCOME"].Rows[0].ItemArray[3].ToString();
//                                        dblProfitLoss = dblProfitLoss - double.Parse(dsData.Tables["P8_PNL_INCOME"].Rows[0].ItemArray[3].ToString());
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00231"://M5
//                                        inpElement.value = dsData.Tables["P8_PNL_INCOME"].Rows[0].ItemArray[4].ToString();
//                                        dblProfitLoss = dblProfitLoss + double.Parse(dsData.Tables["P8_PNL_INCOME"].Rows[0].ItemArray[4].ToString());
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$ImageButton1":
//                                        FireInpElementEvent(inpElement, "OnClick");
//                                        break;
//                                    case "ctl00$master$txtF00235": //M8
//                                        double dblTotal3 = 0;
//                                        if (dsData.Tables["P8_INCOME_OTHERBUSINESS"].Rows.Count > 0)
//                                        {
//                                            if (!String.IsNullOrEmpty(dsData.Tables["P8_INCOME_OTHERBUSINESS"].Rows[0].ItemArray[0].ToString()))
//                                                dblTotal3 = double.Parse(dsData.Tables["P8_INCOME_OTHERBUSINESS"].Rows[0].ItemArray[0].ToString());
//                                        }
//                                        foreach (DataRow row in dsData.Tables["P8_OTHER_PNL"].Rows)
//                                        {
//                                            dblTotal3 = dblTotal3 + dalB.OtherSource_GrossProfitLoss(
//                                                long.Parse(dsData.Tables["P8_OTHER_PNL"].Rows[0].ItemArray[0].ToString()),
//                                                dsData.Tables["P8_PNL_BCCODE"].Rows[0].ItemArray[1].ToString());
//                                        }
//                                        inpElement.value = dblTotal3.ToString();
//                                        if (!String.IsNullOrEmpty(dsData.Tables["P8_INCOME_OTHERBUSINESS"].Rows[0].ItemArray[0].ToString()))
//                                            dblOtherSourceIn = dblTotal3 - double.Parse(dsData.Tables["P8_INCOME_OTHERBUSINESS"].Rows[0].ItemArray[0].ToString());
//                                        if (!String.IsNullOrEmpty(dsData.Tables["P8_INCOME_OTHERBUSINESS"].Rows[0].ItemArray[0].ToString()))
//                                            dblProfitLoss = dblProfitLoss + dblTotal3
//                                                - double.Parse(dsData.Tables["P8_INCOME_OTHERBUSINESS"].Rows[0].ItemArray[0].ToString());
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00236": //M9
//                                        inpElement.value = dsData.Tables["P8_PL_DIVIDEND"].Rows[0].ItemArray[0].ToString();
//                                        if (!String.IsNullOrEmpty(dsData.Tables["P8_PL_DIVIDEND"].Rows[0].ItemArray[0].ToString()))
//                                            dblProfitLoss = dblProfitLoss + double.Parse(dsData.Tables["P8_PL_DIVIDEND"].Rows[0].ItemArray[0].ToString());
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00237": //M10
//                                        inpElement.value = dsData.Tables["P8_PL_INTEREST"].Rows[0].ItemArray[0].ToString();
//                                        if (!String.IsNullOrEmpty(dsData.Tables["P8_PL_INTEREST"].Rows[0].ItemArray[0].ToString()))
//                                            dblProfitLoss = dblProfitLoss + double.Parse(dsData.Tables["P8_PL_INTEREST"].Rows[0].ItemArray[0].ToString());
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00238": //M11
//                                        inpElement.value = dsData.Tables["P8_PL_RENT_ROYALTY"].Rows[0].ItemArray[0].ToString();
//                                        if (!String.IsNullOrEmpty(dsData.Tables["P8_PL_RENT_ROYALTY"].Rows[0].ItemArray[0].ToString()))
//                                            dblProfitLoss = dblProfitLoss + double.Parse(dsData.Tables["P8_PL_RENT_ROYALTY"].Rows[0].ItemArray[0].ToString());
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00239": //M12
//                                        if (!String.IsNullOrEmpty(dsData.Tables["P8_INCOME_OTHER"].Rows[0].ItemArray[0].ToString()))
//                                        {
//                                            inpElement.value = (dsData.Tables["P8_INCOME_OTHER"].Rows[0].ItemArray[0].ToString());
//                                            dblTemp = (double.Parse(dsData.Tables["P8_INCOME_OTHER"].Rows[0].ItemArray[0].ToString()));
//                                        }
//                                        if (!String.IsNullOrEmpty(dsData.Tables["P8_INCOME_OTHER2"].Rows[0].ItemArray[0].ToString()))
//                                        {
//                                            inpElement.value = (dsData.Tables["P8_INCOME_OTHER2"].Rows[0].ItemArray[0].ToString());
//                                            dblTemp = (double.Parse(dsData.Tables["P8_INCOME_OTHER2"].Rows[0].ItemArray[0].ToString()));
//                                        }
//                                        if (!String.IsNullOrEmpty(dsData.Tables["P8_INCOME_OTHER"].Rows[0].ItemArray[0].ToString()) && !String.IsNullOrEmpty(dsData.Tables["P8_INCOME_OTHER2"].Rows[0].ItemArray[0].ToString()))
//                                        {
//                                            inpElement.value = (double.Parse(dsData.Tables["P8_INCOME_OTHER"].Rows[0].ItemArray[0].ToString()) +
//                                                double.Parse(dsData.Tables["P8_INCOME_OTHER2"].Rows[0].ItemArray[0].ToString())).ToString();
//                                            dblTemp = (double.Parse(dsData.Tables["P8_INCOME_OTHER"].Rows[0].ItemArray[0].ToString()) +
//                                                double.Parse(dsData.Tables["P8_INCOME_OTHER2"].Rows[0].ItemArray[0].ToString()));
//                                        }
//                                        if (!String.IsNullOrEmpty(dsData.Tables["P8_INCOME_OTHERBUSINESS"].Rows[0].ItemArray[0].ToString()))
//                                            dblProfitLoss = dblProfitLoss + (dblTemp +
//                                                    double.Parse(dsData.Tables["P8_INCOME_OTHERBUSINESS"].Rows[0].ItemArray[0].ToString()) -
//                                                    dblOtherSourceIn);
//                                        else
//                                            dblProfitLoss = dblProfitLoss + (dblTemp -
//                                                    dblOtherSourceIn);
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$ImageButton3":
//                                        FireInpElementEvent(inpElement, "OnClick");
//                                        break;
//                                    //case "ctl00$master$txtF00240":
//                                    //    inpElement.value = dsData.Tables["P8_INCOME_OTHER2"].Rows[0].ItemArray[0].ToString();
//                                    //    FireInpElementEvent(inpElement, "OnBlur");
//                                    //    break;

//                                    case "ctl00$master$txtF00241": //M14
//                                        inpElement.value = dsData.Tables["P8_EXPENSES_LOAN"].Rows[0].ItemArray[0].ToString();
//                                        if (!String.IsNullOrEmpty(dsData.Tables["P8_EXPENSES_LOAN"].Rows[0].ItemArray[0].ToString()))
//                                            dblProfitLoss = dblProfitLoss - double.Parse(dsData.Tables["P8_EXPENSES_LOAN"].Rows[0].ItemArray[0].ToString());
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00242": //M15
//                                        inpElement.value = dsData.Tables["P8_EXPENSES_SALARY"].Rows[0].ItemArray[0].ToString();
//                                        if (!String.IsNullOrEmpty(dsData.Tables["P8_EXPENSES_SALARY"].Rows[0].ItemArray[0].ToString()))
//                                            dblProfitLoss = dblProfitLoss - double.Parse(dsData.Tables["P8_EXPENSES_SALARY"].Rows[0].ItemArray[0].ToString());
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00243": //M16
//                                        inpElement.value = dsData.Tables["P8_EXPENSES_RENTAL"].Rows[0].ItemArray[0].ToString();
//                                        if (!String.IsNullOrEmpty(dsData.Tables["P8_EXPENSES_RENTAL"].Rows[0].ItemArray[0].ToString()))
//                                            dblProfitLoss = dblProfitLoss - double.Parse(dsData.Tables["P8_EXPENSES_RENTAL"].Rows[0].ItemArray[0].ToString());
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00244": //M17
//                                        inpElement.value = dsData.Tables["P8_EXPENSES_CONTRACT"].Rows[0].ItemArray[0].ToString();
//                                        if (!String.IsNullOrEmpty(dsData.Tables["P8_EXPENSES_CONTRACT"].Rows[0].ItemArray[0].ToString()))
//                                            dblProfitLoss = dblProfitLoss - double.Parse(dsData.Tables["P8_EXPENSES_CONTRACT"].Rows[0].ItemArray[0].ToString());
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00245": //M18
//                                        inpElement.value = dsData.Tables["P8_EXPENSES_COMMISSION"].Rows[0].ItemArray[0].ToString();
//                                        if (!String.IsNullOrEmpty(dsData.Tables["P8_EXPENSES_COMMISSION"].Rows[0].ItemArray[0].ToString()))
//                                            dblProfitLoss = dblProfitLoss - double.Parse(dsData.Tables["P8_EXPENSES_COMMISSION"].Rows[0].ItemArray[0].ToString());
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00246": //M19
//                                        inpElement.value = dsData.Tables["P8_EXPENSES_DEBTS"].Rows[0].ItemArray[0].ToString();
//                                        if (!String.IsNullOrEmpty(dsData.Tables["P8_EXPENSES_DEBTS"].Rows[0].ItemArray[0].ToString()))
//                                            dblProfitLoss = dblProfitLoss - double.Parse(dsData.Tables["P8_EXPENSES_DEBTS"].Rows[0].ItemArray[0].ToString());
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00247": //M20
//                                        inpElement.value = dsData.Tables["P8_EXPENSES_TRAVEL"].Rows[0].ItemArray[0].ToString();
//                                        if (!String.IsNullOrEmpty(dsData.Tables["P8_EXPENSES_TRAVEL"].Rows[0].ItemArray[0].ToString()))
//                                            dblProfitLoss = dblProfitLoss - double.Parse(dsData.Tables["P8_EXPENSES_TRAVEL"].Rows[0].ItemArray[0].ToString());
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00383": //M21
//                                        inpElement.value = dsData.Tables["P8_EXPENSES_REPAIR"].Rows[0].ItemArray[0].ToString();
//                                        if (!String.IsNullOrEmpty(dsData.Tables["P8_EXPENSES_REPAIR"].Rows[0].ItemArray[0].ToString()))
//                                            dblProfitLoss = dblProfitLoss - double.Parse(dsData.Tables["P8_EXPENSES_REPAIR"].Rows[0].ItemArray[0].ToString());
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00384": //M22
//                                        inpElement.value = dsData.Tables["P8_EXPENSES_PROMOTION"].Rows[0].ItemArray[0].ToString();
//                                        if (!String.IsNullOrEmpty(dsData.Tables["P8_EXPENSES_PROMOTION"].Rows[0].ItemArray[0].ToString()))
//                                            dblProfitLoss = dblProfitLoss - double.Parse(dsData.Tables["P8_EXPENSES_PROMOTION"].Rows[0].ItemArray[0].ToString());
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00248": //M23
//                                        double dblTotal = 0;
//                                            if (!String.IsNullOrEmpty(dsData.Tables["P8_EXPENSES_OTHER"].Rows[0].ItemArray[0].ToString()))
//                                                dblTotal = dblTotal + double.Parse(dsData.Tables["P8_EXPENSES_OTHER"].Rows[0].ItemArray[0].ToString());
//                                            if (!String.IsNullOrEmpty(dsData.Tables["P8_LOSS_NONALLOW"].Rows[0].ItemArray[0].ToString()))
//                                                dblTotal = dblTotal + double.Parse(dsData.Tables["P8_LOSS_NONALLOW"].Rows[0].ItemArray[0].ToString());
//                                            if (!String.IsNullOrEmpty(dsData.Tables["P8_EXPENSES_NONALLOW"].Rows[0].ItemArray[0].ToString()))
//                                                dblTotal = dblTotal + double.Parse(dsData.Tables["P8_EXPENSES_NONALLOW"].Rows[0].ItemArray[0].ToString());
//                                            if (!String.IsNullOrEmpty(dsData.Tables["P8_EXPENSES_PERSONAL"].Rows[0].ItemArray[0].ToString()))
//                                                dblTotal = dblTotal + double.Parse(dsData.Tables["P8_EXPENSES_PERSONAL"].Rows[0].ItemArray[0].ToString());
//                                        inpElement.value = dblTotal.ToString();
//                                        dblProfitLoss = dblProfitLoss - dblTotal;
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00251": //M25 ****** Redo
//                                        inpElement.value = dblProfitLoss.ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00252": //M26
//                                        double dblTotal2 = 0;
//                                            if (!String.IsNullOrEmpty(dsData.Tables["P8_NAEXP_EXPENSES"].Rows[0].ItemArray[0].ToString()))
//                                                dblTotal2 = dblTotal2 + double.Parse(dsData.Tables["P8_NAEXP_EXPENSES"].Rows[0].ItemArray[0].ToString());
//                                            if (!String.IsNullOrEmpty(dsData.Tables["P8_NAEXP_NONALLOW"].Rows[0].ItemArray[0].ToString()))
//                                                dblTotal2 = dblTotal2 + double.Parse(dsData.Tables["P8_NAEXP_NONALLOW"].Rows[0].ItemArray[0].ToString());
//                                            if (!String.IsNullOrEmpty(dsData.Tables["P8_NAEXP_PERSONAL"].Rows[0].ItemArray[0].ToString()))
//                                                dblTotal2 = dblTotal2 + double.Parse(dsData.Tables["P8_NAEXP_PERSONAL"].Rows[0].ItemArray[0].ToString());
//                                            if (!String.IsNullOrEmpty(dsData.Tables["P8_NAEXP_PRODUCTION"].Rows[0].ItemArray[0].ToString()))
//                                                dblTotal2 = dblTotal2 + double.Parse(dsData.Tables["P8_NAEXP_PRODUCTION"].Rows[0].ItemArray[0].ToString());
//                                        inpElement.value = dblTotal2.ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$ImageButton2": 
//                                        FireInpElementEvent(inpElement, "OnClick");
//                                        break;
//                                    case "ctl00$master$txtF00253": //M27
//                                        if (dsData.Tables["P8_BALANCE_SHEET"].Rows.Count > 0)
//                                        {
//                                            inpElement.value = dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[0].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00254": //M28
//                                        if (dsData.Tables["P8_BALANCE_SHEET"].Rows.Count > 0)
//                                        {
//                                            inpElement.value = dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[1].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00255": //M29
//                                        if (dsData.Tables["P8_BALANCE_SHEET"].Rows.Count > 0)
//                                        {
//                                            inpElement.value = dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[2].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00256": //M30
//                                        if (dsData.Tables["P8_BALANCE_SHEET"].Rows.Count > 0)
//                                        {
//                                            inpElement.value = dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[3].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    //case "ctl00$master$txtF00257":
//                                    //    inpElement.value = dsData.Tables["P8_NAEXP_EXPENSES"].Rows[0].ItemArray[0].ToString();
//                                    //    FireInpElementEvent(inpElement, "OnBlur");
//                                    //    break;
//                                    case "ctl00$master$txtF00258": //M32
//                                        if (dsData.Tables["P8_BALANCE_SHEET"].Rows.Count > 0)
//                                        {
//                                            inpElement.value = dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[4].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$ImageButton5":
//                                        FireInpElementEvent(inpElement, "OnClick");
//                                        break;
//                                    case "ctl00$master$txtF00259": //M33
//                                        if (dsData.Tables["P8_BALANCE_SHEET"].Rows.Count > 0)
//                                        {
//                                            inpElement.value = dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[5].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00260": //M34
//                                        if (dsData.Tables["P8_BALANCE_SHEET"].Rows.Count > 0)
//                                        {
//                                            inpElement.value = dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[6].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00261": //M35
//                                        if (dsData.Tables["P8_BALANCE_SHEET"].Rows.Count > 0)
//                                        {
//                                            inpElement.value = dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[7].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00262": //M36
//                                        if (dsData.Tables["P8_BALANCE_SHEET"].Rows.Count > 0)
//                                        {
//                                            inpElement.value = dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[8].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00263": //M37
//                                        if (dsData.Tables["P8_BALANCE_SHEET"].Rows.Count > 0)
//                                        {
//                                            inpElement.value = dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[9].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00264": //M38
//                                        if (dsData.Tables["P8_BALANCE_SHEET"].Rows.Count > 0)
//                                        {
//                                            inpElement.value = dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[10].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    //case "ctl00$master$txtF00265":
//                                    //    inpElement.value = dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[11].ToString();
//                                    //    FireInpElementEvent(inpElement, "OnBlur");
//                                    //    break;
//                                    //case "ctl00$master$txtF00266":
//                                    //    inpElement.value = dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[12].ToString();
//                                    //    FireInpElementEvent(inpElement, "OnBlur");
//                                    //    break;
//                                    case "ctl00$master$ImageButton6": 
//                                        FireInpElementEvent(inpElement, "OnClick");
//                                        break;
//                                    case "ctl00$master$txtF00267": //M41
//                                        if (dsData.Tables["P8_BALANCE_SHEET"].Rows.Count > 0)
//                                        {
//                                            inpElement.value = dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[11].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00268": //M42
//                                        if (dsData.Tables["P8_BALANCE_SHEET"].Rows.Count > 0)
//                                        {
//                                            inpElement.value = dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[12].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00269": //M43
//                                        double dblTotalLib = 0;
//                                        if (dsData.Tables["P8_BALANCE_SHEET"].Rows.Count > 0)
//                                        {
//                                            dblTotalLib = (double.Parse(dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[13].ToString()) +
//                                                double.Parse(dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[14].ToString()) +
//                                                double.Parse(dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[15].ToString()));
//                                        }
//                                            inpElement.value = dblTotalLib.ToString();
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    //case "ctl00$master$txtF00270":
//                                    //    inpElement.value = dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[14].ToString();
//                                    //    FireInpElementEvent(inpElement, "OnBlur");
//                                    //    break;
//                                    case "ctl00$master$ImageButton7":
//                                        FireInpElementEvent(inpElement, "OnClick");
//                                        break;
//                                    case "ctl00$master$txtF00271": //M45
//                                        if (dsData.Tables["P8_BALANCE_SHEET"].Rows.Count > 0)
//                                        {
//                                            inpElement.value = dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[16].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00272": //M46
//                                        if (dsData.Tables["P8_BALANCE_SHEET"].Rows.Count > 0)
//                                        {
//                                            inpElement.value = dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[17].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00274": //M47
//                                        if (dsData.Tables["P8_BALANCE_SHEET"].Rows.Count > 0)
//                                        {
//                                            inpElement.value = dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[18].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00275": //M48
//                                        if (dsData.Tables["P8_BALANCE_SHEET"].Rows.Count > 0)
//                                        {
//                                            inpElement.value = dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[19].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                    case "ctl00$master$txtF00276": //M49
//                                        if (dsData.Tables["P8_BALANCE_SHEET"].Rows.Count > 0)
//                                        {
//                                            inpElement.value = dsData.Tables["P8_BALANCE_SHEET"].Rows[0].ItemArray[20].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                }
//                            }
//                            break;

//#endregion

//#region "Input Page9"
//                        case "B2008Page9": //Tax Agent Information
//                            {
//                                switch (inpElement.name)
//                                {
//                                    case "ctl00$master$txtF00183": 
//                                        inpElement.value = dsData.Tables["P9_TAXADM_PROFILE"].Rows[0].ItemArray[0].ToString();
//                                        break;

//                                    case "ctl00$master$txtF00185": 
//                                        if (!String.IsNullOrEmpty(dsData.Tables["P9_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
//                                        {
//                                            inpElement.value = dsData.Tables["P9_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString() +
//                                                dsData.Tables["P9_TAXADM_PROFILE"].Rows[0].ItemArray[2].ToString() +
//                                                dsData.Tables["P9_TAXADM_PROFILE"].Rows[0].ItemArray[3].ToString();
//                                        }
//                                        else if (!String.IsNullOrEmpty(dsData.Tables["P9_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
//                                        {
//                                            inpElement.value = dsData.Tables["P9_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString();
//                                        }
//                                        else if (!String.IsNullOrEmpty(dsData.Tables["P9_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
//                                        {
//                                            inpElement.value = dsData.Tables["P9_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString();
//                                        }
//                                        else if (!String.IsNullOrEmpty(dsData.Tables["P9_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
//                                        {
//                                            inpElement.value = dsData.Tables["P9_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString();
//                                        }
//                                        break;

//                                    case "ctl00$master$txtF00290": //No. Telephone
//                                        if (!String.IsNullOrEmpty(dsData.Tables["P9_TAX_AGENT"].Rows[0].ItemArray[0].ToString()))
//                                        {
//                                            inpElement.value = dsData.Tables["P9_TAX_AGENT"].Rows[0].ItemArray[0].ToString();
//                                        }
//                                        else
//                                        {
//                                            inpElement.value = dsData.Tables["P9_TAX_AGENT"].Rows[0].ItemArray[1].ToString();
//                                        }
//                                        FireInpElementEvent(inpElement, "OnBlur");
//                                        break;
//                                }
//                            }
//                            break;
//#endregion

//                    }
//                }
//                if (boolNoRecord)
//                {
//                    MessageBox.Show("No record found for current document.", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//                foreach (mshtml.HTMLSelectElement selElement in htmlDoc.getElementsByTagName("select"))
//                {
//                    switch (strPageIndex)
//                    {
//#region "Select Page1"
//                        case "B2008Page1":
//                            switch (selElement.name)
//                            {
//                                case "ctl00$master$ddlF00011": //CITIZEN
//                                    selElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
//                                    break;
//                                case "ctl00$master$ddlF00012": //SEX
//                                    selElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[2].ToString();
//                                    break;
//                                case "ctl00$master$ddlF00013": //STATUS
//                                    selElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[3].ToString();
//                                    break;
//                                case "ctl00$master$ddlF00016": //TYPE OF ASSESSMENT
//                                    if (dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "1")
//                                    {
//                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[28].ToString()))
//                                        {
//                                            if (dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[28].ToString() == "1")
//                                            { selElement.value = "1";}
//                                            else
//                                            {selElement.value = "2";}
//                                        }
//                                    }
//                                    else if (dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "2")
//                                    {
//                                        selElement.value = "3";
//                                    }
//                                    else if (dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "3")
//                                    {
//                                        selElement.value = "4";
//                                    }
//                                    FireSelElementEvent(selElement, "OnChange");
//                                    break;
//                                case "ctl00$master$ddlF00018": //PUBLIC RULING
//                                    if (dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() == "1")
//                                    {
//                                        selElement.value = "1";
//                                    }
//                                    else
//                                    {
//                                        selElement.value = "2";
//                                    }
//                                    break;
//                                case "ctl00$master$ddlF00378": //RECORD KEPT
//                                    if (strRecKept == "True")
//                                    {
//                                        selElement.value = "1";
//                                    }
//                                    else
//                                    {
//                                        selElement.value = "2";
//                                    }
//                                    break;
//                                case "ctl00$master$ddlF00024": //STATE
//                                    selElement.value = SelectState(dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[13].ToString());
//                                    break;
//                                case "ctl00$master$ddlF00036": //STATE
//                                    selElement.value = SelectState(dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[19].ToString());
//                                    break;
//                            }
//                            break;
//#endregion
                        
//#region "Select Page2"
//                        case "B2008Page2":
//                            switch (selElement.name)
//                            {
//                                case "ctl00$master$ddlF00054": //Type of Tax Reference
//                                    selElement.value = dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[1].ToString().ToUpper();
//                                    break;
//                                case "ctl00$master$ddlJPengenalan_isteri": //Type of ID
//                                    if (!String.IsNullOrEmpty(dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[5].ToString())||
//                                        !String.IsNullOrEmpty(dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[6].ToString())||
//                                        !String.IsNullOrEmpty(dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[7].ToString()))
//                                    {
//                                        selElement.value = "NEWIC";
//                                    }
//                                    else if(!String.IsNullOrEmpty(dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[9].ToString()))
//                                    {
//                                        selElement.value = "POLICE";
//                                    }
//                                    else if (!String.IsNullOrEmpty(dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[10].ToString()))
//                                    {
//                                        selElement.value = "ARMY";
//                                    }
//                                    else if (!String.IsNullOrEmpty(dsData.Tables["P2_INPUT_TAX_PROFILE"].Rows[0].ItemArray[11].ToString()))
//                                    {
//                                        selElement.value = "PASSPORT";
//                                    }
//                                    break;
//                            }
//                            break;
//                        #endregion

//#region "Select Page3"
//                        case "B2008Page3":
//                            switch (selElement.name)
//                            {
//                                case "ctl00$master$ddlF00355":
//                                    selElement.value = dsData.Tables["P3_SELECT_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
//                                    FireSelElementEvent(selElement, "OnChange");
//                                    break;
//                            }
//                            break;
//#endregion

//#region "Select Page9"
//                        case "B2008Page9":
//                            switch (selElement.name)
//                            {
//                                case "ctl00$master$ddlJPengenalan_mati":
//                                    if (!String.IsNullOrEmpty(dsData.Tables["P9_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
//                                    {
//                                        selElement.value = "NEWIC";
//                                    }
//                                    else if (!String.IsNullOrEmpty(dsData.Tables["P9_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
//                                    {
//                                        selElement.value = "POLICE";
//                                    }
//                                    else if (!String.IsNullOrEmpty(dsData.Tables["P9_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
//                                    {
//                                        selElement.value = "ARMY";
//                                    }
//                                    else if (!String.IsNullOrEmpty(dsData.Tables["P9_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
//                                    {
//                                        selElement.value = "PASSPORT";
//                                    }
//                                    FireSelElementEvent(selElement, "OnChange");
//                                    break;
//                            }
//                            break;
//#endregion

//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.ToString());
//            }
            
//        }

        //private void ProcessFormBE(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        //{
        //    try
        //    {
        //        EFilingDALB dal = new EFilingDALB(strTaxPayer, strYA, strTaxAgent);
        //        DataSet dsData = new DataSet();
        //        dsData = dal.GetFormDataBE(strPageIndex);
        //        dal.CloseConn();
        //        //string strComparator;
        //        //string strTemp;
        //        double nTotal = 0;
        //        DataRow dr;

        //        foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
        //        {
        //            switch (strPageIndex)
        //            {
        //                case "BE2008Page1":
        //                    switch (inpElement.name)
        //                    {
        //                        //case "ctl00$master$txtF00009"://IC No
        //                        //    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
        //                        //    break;
        //                        case "ctl00$master$txtF00009"://Passport No
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
        //                            break;
        //                        case "ctl00$master$txtf00014"://Date of Marriage/Divorce/Demise
        //                            if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
        //                            {
        //                                inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString();
        //                            }
        //                            else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
        //                            {
        //                                inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00019"://Correspondence Add
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00020"://Correspondence Add
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00021"://Correspondence Add
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00022"://Correspondence Add
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[11].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00023"://Correspondence Add
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[12].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00041"://Tel
        //                            inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[14].ToString() + "-" + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[15].ToString());
        //                            break;
        //                        case "ctl00$master$txtF00040"://Employer No
        //                            inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[16].ToString() + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[17].ToString());
        //                            break;
        //                        case "ctl00$master$txtF00043"://email
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[18].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00044"://Bank Name
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[19].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00045"://Bank A/C No
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[20].ToString();
        //                            break;
        //                    }
        //                    break;
        //                case "BE2008Page2":
        //                    switch (inpElement.name)
        //                    {
        //                        case "ctl00$master$txtF00052"://Wife Name
        //                            inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00055"://Ref No
        //                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[4].ToString());
        //                            break;
        //                        case "ctl00$master$txtF00057"://IC No/ Police No/ Army No/ Passport No
        //                            if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
        //                            {
        //                                inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString());
        //                            }
        //                            else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
        //                            {
        //                                inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
        //                            }
        //                            else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
        //                            {
        //                                inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
        //                            }
        //                            else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
        //                            {
        //                                inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
        //                            }
        //                            break;
        //                    }
        //                    break;

        //                case "BE2008Page3":
        //                    switch (inpElement.name)
        //                    {
        //                        case "ctl00$master$txtF00076"://Employment
        //                            inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00077"://Dividend
        //                            inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00078"://Interest and Discount
        //                            inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString())));
        //                            break;
        //                        case "ctl00$master$txtF00079"://Rent, royalties and premiums
        //                            inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[5].ToString())));
        //                            break;
        //                        case "ctl00$master$txtF00080"://Pension, annuities and other periodical payments
        //                            inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[6].ToString()));
        //                            break;
        //                        case "ctl00$master$txtF00081"://Other gains or profits
        //                            inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[9].ToString())));
        //                            break;
        //                        case "ctl00$master$txtF00090"://Gift to Government, State Government or local authorities
        //                            dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("9");
        //                            inpElement.value = dr["TCG_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00393"://Gift to approved institutions or organization
        //                            dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("1");
        //                            inpElement.value = dr["TCG_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00389"://Gift to sports activity
        //                            dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("7");
        //                            inpElement.value = dr["TCG_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00390"://Gift to contribution for project of national interest
        //                            dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("8");
        //                            inpElement.value = dr["TCG_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00091"://Gift artefacts, manuscript or painting
        //                            dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("2");
        //                            inpElement.value = dr["TCG_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00092"://Gift of library
        //                            dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("3");
        //                            inpElement.value = dr["TCG_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00093"://Gift of public facilities of disabled persons
        //                            dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("4");
        //                            inpElement.value = dr["TCG_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00094"://Gift of medical equipment to any healthcare facility
        //                            dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("5");
        //                            inpElement.value = dr["TCG_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00095"://Gift of National Art Gallery
        //                            dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("6");
        //                            inpElement.value = dr["TCG_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00099"://Income transfer from husband/wife
        //                            inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[10].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00165"://Installment/ Schedular
        //                            inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[11].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[12].ToString()));
        //                            break;
        //                        //Preceding Years Income
        //                        case "ctl00$master$txtF00169"://Type of income
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[0].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00170"://Year for which paid
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[1].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00171"://Gross Amount
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[2].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00172"://Provident and pension fund contribution
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[3].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00173"://Type of income
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[0].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00174"://Year for which paid
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[1].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00175"://Gross Amount
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[2].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00176"://Provident and pension fund contribution
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[3].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00177"://Type of income
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[0].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00178"://Year for which paid
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[1].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00179"://Gross Amount
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[2].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00180"://Provident and pension fund contribution
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[3].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00361"://Type of income
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[0].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00362"://Year for which paid
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[1].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00363"://Gross Amount
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[2].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00364"://Provident and pension fund contribution
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[3].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00365"://Type of income
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[0].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00366"://Year for which paid
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[1].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00367"://Gross Amount
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[2].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00368"://Provident and pension fund contribution'
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[3].ToString();
        //                            }
        //                            break;
        //                    }
        //                    break;
        //                case "BE2008Page4":
        //                    switch (inpElement.name)
        //                    {
        //                        case "ctl00$master$txtF00104"://Individual
        //                            dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("1");
        //                            inpElement.value = dr["TCC_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00105"://Medical expenses for won parents
        //                            dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("2");
        //                            inpElement.value = dr["TCC_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00106"://Basic supporting equipment for disabled person
        //                            //dsData.Tables["P4_TAX_RELIEF"].DefaultView.RowFilter = "TCC_KEY = 3";
        //                            //inpElement.value = dsData.Tables["P4_TAX_RELIEF"].Select();
        //                            //dtOverAll.PrimaryKey = new DataColumn[] { dtOverAll.Columns["ITEMNMBR"] };
        //                            //dsData.Tables["P4_TAX_RELIEF"].PrimaryKey = new DataColumn[] { dsData.Tables["P4_TAX_RELIEF"].Columns["TCC_KEY"] };
        //                            dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("3");
        //                            inpElement.value = dr["TCC_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00107"://Disabled individual
        //                            dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("4");
        //                            inpElement.value = dr["TCC_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00108"://Education fees
        //                            dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("5");
        //                            inpElement.value = dr["TCC_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00109"://Medical expenses for self/ spouse/ child
        //                            dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("6");
        //                            inpElement.value = dr["TCC_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00110"://Complete medical examination for self/ spouse/ child
        //                            dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("7");
        //                            inpElement.value = dr["TCC_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00112"://Purchase books/ megazines
        //                            dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("8");
        //                            inpElement.value = dr["TCC_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00391"://Purchase personal computers
        //                            dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("21");
        //                            inpElement.value = dr["TCC_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00392"://Skim Simapanan Pendidikan Nasional
        //                            dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("22");
        //                            inpElement.value = dr["TCC_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00395"://Purchase sports equipment
        //                            dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("23");
        //                            inpElement.value = dr["TCC_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00116"://Husband/ wife/ payment of alimony
        //                            dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("10");
        //                            inpElement.value = dr["TCC_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00118"://Disabled husband/ wife
        //                            dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("13");
        //                            inpElement.value = dr["TCC_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00397"://No. child own self
        //                            inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD"].Rows.Count);
        //                            break;
        //                        case "ctl00$master$txtF00398"://No. child husband/ wife
        //                            inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_HW"].Rows.Count);
        //                            break;
        //                        case "ctl00$master$txtF00396"://No. children eligible for deduction
        //                            inpElement.value = Convert.ToString((dsData.Tables["P4_TAX_RELIEF_CHILD"].Rows.Count) + (dsData.Tables["P4_TAX_RELIEF_CHILD_HW"].Rows.Count));
        //                            break;
        //                        case "ctl00$master$txtF00120"://No. child under 18 - 1000
        //                            inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_1000"].Rows.Count);
        //                            nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_1000"].Rows.Count;
        //                            break;
        //                        case "ctl00$master$txtF00121"://Amount child under 18 - 1000
        //                            inpElement.value = Convert.ToString(nTotal * 1000);
        //                            nTotal = 0;
        //                            break;
        //                        case "ctl00$master$txtF00122"://No. child under 18 - 500
        //                            inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_500"].Rows.Count);
        //                            nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_500"].Rows.Count;
        //                            break;
        //                        case "ctl00$master$txtF00123"://Amount child under 18 - 500
        //                            inpElement.value = Convert.ToString(nTotal * 500);
        //                            nTotal = 0;
        //                            break;
        //                        case "ctl00$master$txtF00124"://Total amount child under 18
        //                            dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("14");
        //                            inpElement.value = dr["TCC_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00357"://No. child 18 and above - 1000
        //                            inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_1000"].Rows.Count);
        //                            nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_1000"].Rows.Count;
        //                            break;
        //                        case "ctl00$master$txtF00371"://Amount child 18 and above - 1000
        //                            inpElement.value = Convert.ToString(nTotal * 1000);
        //                            nTotal = 0;
        //                            break;
        //                        case "ctl00$master$txtF00358"://No. child 18 and above - 500
        //                            inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_500"].Rows.Count);
        //                            nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_500"].Rows.Count;
        //                            break;
        //                        case "ctl00$master$txtF00372"://Amount child 18 and above - 500
        //                            inpElement.value = Convert.ToString(nTotal * 500);
        //                            nTotal = 0;
        //                            break;
        //                        case "ctl00$master$txtF00359"://No. child 18 and above - 4000
        //                            inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_4000"].Rows.Count);
        //                            nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_4000"].Rows.Count;
        //                            break;
        //                        case "ctl00$master$txtF00373"://Amount child 18 and above - 4000
        //                            inpElement.value = Convert.ToString(nTotal * 4000);
        //                            nTotal = 0;
        //                            break;
        //                        case "ctl00$master$txtF00360"://No. child 18 and above - 2000
        //                            inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_2000"].Rows.Count);
        //                            nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_2000"].Rows.Count;
        //                            break;
        //                        case "ctl00$master$txtF00374"://Amount child 18 and above - 2000
        //                            inpElement.value = Convert.ToString(nTotal * 2000);
        //                            nTotal = 0;
        //                            break;
        //                        case "ctl00$master$txtF00133"://Total amount child 18 and above
        //                            dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("15");
        //                            inpElement.value = dr["TCC_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00135"://No. disabled child - 5000
        //                            inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_5000"].Rows.Count);
        //                            nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_5000"].Rows.Count;
        //                            break;
        //                        case "ctl00$master$txtF00136"://Amount disabled child - 5000
        //                            inpElement.value = Convert.ToString(nTotal * 5000);
        //                            nTotal = 0;
        //                            break;
        //                        case "ctl00$master$txtF00137"://No. disabled child - 2500
        //                            inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_2500"].Rows.Count);
        //                            nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_2500"].Rows.Count;
        //                            break;
        //                        case "ctl00$master$txtF00138"://Amount disabled child - 2500
        //                            inpElement.value = Convert.ToString(nTotal * 2500);
        //                            nTotal = 0;
        //                            break;
        //                        case "ctl00$master$txtF00369"://No. disabled child - 9000
        //                            inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_9000"].Rows.Count);
        //                            nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_9000"].Rows.Count;
        //                            break;
        //                        case "ctl00$master$txtF00375"://Amount disabled child - 9000
        //                            inpElement.value = Convert.ToString(nTotal * 9000);
        //                            nTotal = 0;
        //                            break;
        //                        case "ctl00$master$txtF00370"://No. disabled child - 4500
        //                            inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_4500"].Rows.Count);
        //                            nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_4500"].Rows.Count;
        //                            break;
        //                        case "ctl00$master$txtF00376"://Amount disabled child - 4500
        //                            inpElement.value = Convert.ToString(nTotal * 4500);
        //                            nTotal = 0;
        //                            break;
        //                        case "ctl00$master$txtF00139"://Total amount disabled child
        //                            dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("16");
        //                            inpElement.value = dr["TCC_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00140"://Life insurance and providend fund
        //                            dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("17");
        //                            inpElement.value = dr["TCC_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00141"://Education and medical insurance
        //                            dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("18");
        //                            inpElement.value = dr["TCC_AMOUNT"].ToString();
        //                            break;
        //                    }
        //                    FireInpElementEvent(inpElement, "OnBlur");
        //                    break;
        //                case "BE2008Page5":
        //                    switch (inpElement.name)
        //                    {
        //                        case "ctl00$master$txtF00155":
        //                            dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("3");
        //                            inpElement.value = dr["TCR_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00157":
        //                            dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("5");
        //                            inpElement.value = dr["TCR_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00160":
        //                            inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00161":
        //                            inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00346":
        //                            inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00347":
        //                            inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString();
        //                            break;
        //                    }
        //                    break;
        //                case "BE2008Page6":
        //                    switch (inpElement.name)
        //                    {
        //                        case "ctl00$master$txtF00183":
        //                            inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[0].ToString();
        //                            break;

        //                        case "ctl00$master$txtF00185":
        //                            if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
        //                            {
        //                                inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString() +
        //                                    dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[2].ToString() +
        //                                    dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[3].ToString();
        //                            }
        //                            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
        //                            {
        //                                inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString();
        //                            }
        //                            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
        //                            {
        //                                inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString();
        //                            }
        //                            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
        //                            {
        //                                inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00290":
        //                            inpElement.value = dsData.Tables["P6_TAXA_PROFILE"].Rows[0].ItemArray[0].ToString();
        //                            break;
        //                    }
        //                    break;
        //            }
        //        }
        //        foreach (mshtml.HTMLSelectElement selElement in htmlDoc.getElementsByTagName("select"))
        //        {
        //            switch (strPageIndex)
        //            {
        //                case "BE2008Page1":
        //                    switch (selElement.name)
        //                    {
        //                        case "ctl00$master$ddlF00011"://Citizan
        //                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
        //                            break;
        //                        case "ctl00$master$ddlF00012"://Sex
        //                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[2].ToString();
        //                            break;
        //                        case "ctl00$master$ddlF00013"://Status
        //                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString();
        //                            break;
        //                        case "ctl00$master$ddlF00016"://Type of Assessment
        //                            if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "1")
        //                            {
        //                                if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[21].ToString()))
        //                                {
        //                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[21].ToString() == "1")
        //                                    { selElement.value = "1"; }
        //                                    else
        //                                    { selElement.value = "2"; }
        //                                }
        //                            }
        //                            else if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "2")
        //                            {
        //                                selElement.value = "3";
        //                            }
        //                            else if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "3")
        //                            {
        //                                selElement.value = "4";
        //                            }
        //                            break;
        //                        case "ctl00$master$ddlF00018"://Public Rulings
        //                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[7].ToString();
        //                            break;
        //                        case "ctl00$master$ddlF00024"://Correspondence Add - State
        //                            selElement.value = SelectState(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[13].ToString());
        //                            break;
        //                    }
        //                    FireSelElementEvent(selElement, "OnChange");
        //                    break;
        //                case "BE2008Page2":
        //                    switch (selElement.name)
        //                    {
        //                        case "ctl00$master$ddlF00054"://Ref Prefix
        //                            selElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
        //                            break;
        //                        case "ctl00$master$ddlJPengenalan_isteri"://Identity Type
        //                            if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
        //                            {
        //                                selElement.value = "NEWIC";
        //                            }
        //                            else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
        //                            {
        //                                selElement.value = "POLICE";
        //                            }
        //                            else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
        //                            {
        //                                selElement.value = "ARMY";
        //                            }
        //                            else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
        //                            {
        //                                selElement.value = "PASSPORT";
        //                            }
        //                            break;
        //                    }
        //                    break;
        //                case "BE2008Page3":
        //                    switch (selElement.name)
        //                    {
        //                        case "ctl00$master$ddlF00355"://Type of income transfer from husband/wife
        //                            if (dsData.Tables["P3_TAX_PROFILE"].Rows[0].ItemArray[11].ToString() == "1")
        //                            {
        //                                selElement.value = "1";//Ada pendapatan perniagaan (With business income)
        //                            }
        //                            else if (dsData.Tables["P3_TAX_PROFILE"].Rows[0].ItemArray[11].ToString() == "2")
        //                            {
        //                                selElement.value = "2";//Tiada punca pendapatan perniagaan (Without business income)
        //                            }
        //                            break;
        //                    }
        //                    break;
        //                case "BE2008Page6":
        //                    switch (selElement.name)
        //                    {
        //                        case "ctl00$master$ddlJPengenalan_mati":
        //                            if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
        //                            {
        //                                selElement.value = "NEWIC";
        //                            }
        //                            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
        //                            {
        //                                selElement.value = "POLICE";
        //                            }
        //                            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
        //                            {
        //                                selElement.value = "ARMY";
        //                            }
        //                            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
        //                            {
        //                                selElement.value = "PASSPORT";
        //                            }
        //                            FireSelElementEvent(selElement, "OnChange");
        //                            break;
        //                    }
        //                    break;

        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private void ProcessFormM(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        //{
        //    try
        //    {
        //        EFilingDALB dal = new EFilingDALB(strTaxPayer, strYA, strTaxAgent);
        //        DataSet dsData = new DataSet();
        //        dsData = dal.GetFormDataM(strPageIndex);
        //        dal.CloseConn();
        //        double nTotal = 0, nTotal1 = 0, nTotal2 = 0;
        //        DataRow dr;

        //        foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
        //        {
        //            switch (strPageIndex)
        //            {
        //                case "M2008Page1":
        //                    switch (inpElement.name)
        //                    {
        //                        case "ctl00$master$txtF00009"://Passport No
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00305"://Expire Date of Current Passport
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00377"://Date of Birth
        //                            inpElement.value = dsData.Tables["P1_TAXP_PROFILE2"].Rows[0].ItemArray[0].ToString();
        //                            break;
        //                        case "ctl00$master$txtf00014"://Date of Marriage/Divorce/Demise
        //                            if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() == "2")
        //                            {
        //                                inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString();
        //                            }
        //                            else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() == "4"))
        //                            {
        //                                inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[7].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00019"://Correspondence Add
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00020"://Correspondence Add
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[11].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00021"://Correspondence Add
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[12].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00022"://Correspondence Add
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[13].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00023"://Correspondence Add
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[14].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00025"://Permanent Add
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[16].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00026"://Permanent Add
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[17].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00027"://Permanent Add
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[18].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00028"://Permanent Add
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[19].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00029"://Permanent Add
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[20].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00031"://Business Premise Add
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[22].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00032"://Business Premise Add
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[23].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00033"://Business Premise Add
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[24].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00034"://Business Premise Add
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[25].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00035"://Business Premise Add
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[26].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00041"://Tel
        //                            inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[28].ToString() + "-" + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[29].ToString());
        //                            break;
        //                        case "ctl00$master$txtF00043"://email
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[30].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00044"://Bank Name
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[31].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00045"://Bank A/C No
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[32].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00037"://Employer Name
        //                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[33].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00040"://Employer No
        //                            inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[34].ToString() + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[35].ToString());
        //                            break;
        //                    }
        //                    break;
        //                case "M2008Page2":
        //                    switch (inpElement.name)
        //                    {
        //                        case "ctl00$master$txtF00052"://Wife Name
        //                            inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00055"://Ref No
        //                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[4].ToString());
        //                            break;
        //                        case "ctl00$master$txtF00057"://IC No/ Police No/ Army No/ Passport No
        //                            if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
        //                            {
        //                                inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString());
        //                            }
        //                            else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
        //                            {
        //                                inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
        //                            }
        //                            else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
        //                            {
        //                                inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
        //                            }
        //                            else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
        //                            {
        //                                inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00060"://Current Passport No
        //                            inpElement.value = dsData.Tables["P1_TAXP_PROFILE2"].Rows[0].ItemArray[0].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00306"://Expire Date of Current Passport
        //                            inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[11].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00379"://Date of Birth
        //                            inpElement.value = dsData.Tables["P1_TAXP_PROFILE2"].Rows[0].ItemArray[1].ToString();
        //                            break;
        //                    }
        //                    break;
        //                case "M2008Page3":
        //                    switch (inpElement.name)
        //                    {
        //                        case "ctl00$master$txtF00061"://Business Code 1
        //                            if (dsData.Tables["P3_INCOME_ADJUSTED"].Rows.Count > 0)
        //                            {
        //                                dr = dsData.Tables["P3_BUSINESS_SOURCE"].Rows.Find(dsData.Tables["P3_INCOME_ADJUSTED"].Rows[0].ItemArray[0].ToString());
        //                                inpElement.value = dr["BC_CODE"].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00062"://Amount 1
        //                            if (dsData.Tables["P3_INCOME_ADJUSTED"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_INCOME_ADJUSTED"].Rows[0].ItemArray[1].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P3_INCOME_ADJUSTED"].Rows[0].ItemArray[1].ToString());
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00063"://Business Code 2
        //                            if (dsData.Tables["P3_INCOME_ADJUSTED"].Rows.Count > 1)
        //                            {
        //                                dr = dsData.Tables["P3_BUSINESS_SOURCE"].Rows.Find(dsData.Tables["P3_INCOME_ADJUSTED"].Rows[1].ItemArray[0].ToString());
        //                                inpElement.value = dr["BC_CODE"].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00064"://Amount 2
        //                            if (dsData.Tables["P3_INCOME_ADJUSTED"].Rows.Count > 1)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_INCOME_ADJUSTED"].Rows[1].ItemArray[1].ToString();
        //                                nTotal = nTotal + double.Parse(dsData.Tables["P3_INCOME_ADJUSTED"].Rows[1].ItemArray[1].ToString());
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00065"://Business Code 3
        //                            if (dsData.Tables["P3_INCOME_ADJUSTED"].Rows.Count > 2)
        //                            {
        //                                if (dsData.Tables["P3_INCOME_ADJUSTED"].Rows.Count == 3)
        //                                {
        //                                    dr = dsData.Tables["P3_BUSINESS_SOURCE"].Rows.Find(dsData.Tables["P3_INCOME_ADJUSTED"].Rows[2].ItemArray[0].ToString());
        //                                    inpElement.value = dr["BC_CODE"].ToString();
        //                                }
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00066"://Amount 3
        //                            if (dsData.Tables["P3_INCOME_ADJUSTED"].Rows.Count > 2)
        //                            {
        //                                for (int i = 0; i < dsData.Tables["P3_INCOME_ADJUSTED"].Rows.Count; i++)
        //                                {
        //                                    nTotal1 = nTotal1 + double.Parse(dsData.Tables["P3_INCOME_ADJUSTED"].Rows[i].ItemArray[1].ToString());
        //                                }
        //                                nTotal = nTotal1 - nTotal;
        //                                nTotal = nTotal + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString());
        //                                inpElement.value = Convert.ToString(nTotal);
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00067"://Tax Reference 1
        //                            if (dsData.Tables["P3_INCOME_PARTNERSHIP"].Rows.Count > 0)
        //                            {
        //                                dr = dsData.Tables["P3_TAXP_PARTNERSHIP"].Rows.Find(dsData.Tables["P3_INCOME_PARTNERSHIP"].Rows[0].ItemArray[0].ToString());
        //                                inpElement.value = (dr["PS_FILE_NO2"].ToString() + dr["PS_FILE_NO3"].ToString());
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00068"://Amount 1
        //                            nTotal = 0;
        //                            if (dsData.Tables["P3_INCOME_PARTNERSHIP"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_INCOME_PARTNERSHIP"].Rows[0].ItemArray[1].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P3_INCOME_PARTNERSHIP"].Rows[0].ItemArray[1].ToString());
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00069"://Tax Reference 2
        //                            if (dsData.Tables["P3_INCOME_PARTNERSHIP"].Rows.Count > 1)
        //                            {
        //                                dr = dsData.Tables["P3_TAXP_PARTNERSHIP"].Rows.Find(dsData.Tables["P3_INCOME_PARTNERSHIP"].Rows[1].ItemArray[0].ToString());
        //                                inpElement.value = (dr["PS_FILE_NO2"].ToString() + dr["PS_FILE_NO3"].ToString());
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00070"://Amount 2
        //                            if (dsData.Tables["P3_INCOME_PARTNERSHIP"].Rows.Count > 1)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_INCOME_PARTNERSHIP"].Rows[1].ItemArray[1].ToString();
        //                                nTotal = nTotal + double.Parse(dsData.Tables["P3_INCOME_PARTNERSHIP"].Rows[1].ItemArray[1].ToString());
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00071"://Tax Reference 3
        //                            if (dsData.Tables["P3_INCOME_PARTNERSHIP"].Rows.Count > 2)
        //                            {
        //                                if (dsData.Tables["P3_INCOME_PARTNERSHIP"].Rows.Count == 3)
        //                                {
        //                                    dr = dsData.Tables["P3_TAXP_PARTNERSHIP"].Rows.Find(dsData.Tables["P3_INCOME_PARTNERSHIP"].Rows[2].ItemArray[0].ToString());
        //                                    inpElement.value = (dr["PS_FILE_NO2"].ToString() + dr["PS_FILE_NO3"].ToString());
        //                                }
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00072"://Amount 3
        //                            nTotal1 = 0;
        //                            if (dsData.Tables["P3_INCOME_PARTNERSHIP"].Rows.Count > 2)
        //                            {
        //                                for (int i = 0; i < dsData.Tables["P3_INCOME_PARTNERSHIP"].Rows.Count; i++)
        //                                {
        //                                    nTotal1 = nTotal1 + double.Parse(dsData.Tables["P3_INCOME_PARTNERSHIP"].Rows[i].ItemArray[1].ToString());
        //                                }
        //                                nTotal = nTotal1 - nTotal;
        //                                inpElement.value = Convert.ToString(nTotal);
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00074"://Business losses b/f
        //                            inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00076"://Employment
        //                            inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00077"://Dividend
        //                            inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[4].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00078"://Interest and Discount
        //                            inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[6].ToString())));
        //                            break;
        //                        case "ctl00$master$txtF00079"://Rent, royalties and premiums
        //                            inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[8].ToString())));
        //                            break;
        //                        case "ctl00$master$txtF00080"://Pension, annuities and other periodical payments
        //                            inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[9].ToString()));
        //                            break;
        //                        case "ctl00$master$txtF00081"://Other gains or profits
        //                            inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[10].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[11].ToString()));
        //                            break;
        //                        case "ctl00$master$txtF00082"://Paragraph 43(1)(c)
        //                            inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[12].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00085"://Current Year business losses
        //                            inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[13].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00087"://Schedule 4 and paragraph 44(1)(b)
        //                            inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[18].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00090"://Gift to Government, State Government or local authorities
        //                            dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("9");
        //                            inpElement.value = dr["TCG_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00393"://Gift to approved institutions or organization
        //                            dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("1");
        //                            inpElement.value = dr["TCG_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00389"://Gift to sports activity
        //                            dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("7");
        //                            inpElement.value = dr["TCG_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00390"://Gift to contribution for project of national interest
        //                            dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("8");
        //                            inpElement.value = dr["TCG_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00091"://Gift artefacts, manuscript or painting
        //                            dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("2");
        //                            inpElement.value = dr["TCG_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00092"://Gift of library
        //                            dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("3");
        //                            inpElement.value = dr["TCG_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00093"://Gift of public facilities of disabled persons
        //                            dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("4");
        //                            inpElement.value = dr["TCG_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00094"://Gift of medical equipment to any healthcare facility
        //                            dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("5");
        //                            inpElement.value = dr["TCG_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00095"://Gift of National Art Gallery
        //                            dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("6");
        //                            inpElement.value = dr["TCG_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00349"://Taxable Pioneer Income
        //                            inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[14].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00336"://Interest
        //                            inpElement.value = dsData.Tables["P3_CHARGEABLE_INCOME"].Rows[0].ItemArray[0].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00337"://Royalties
        //                            inpElement.value = dsData.Tables["P3_CHARGEABLE_INCOME"].Rows[0].ItemArray[1].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00307"://Section 4A
        //                            inpElement.value = dsData.Tables["P3_CHARGEABLE_INCOME"].Rows[0].ItemArray[2].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00338"://Other Income
        //                            inpElement.value = dsData.Tables["P3_CHARGEABLE_INCOME"].Rows[0].ItemArray[3].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00099"://Income transfer from husband/wife
        //                            inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[15].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00165"://Installment/ Schedular
        //                            inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[16].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[17].ToString()));
        //                            break;
        //                        //Preceding Years Income
        //                        case "ctl00$master$txtF00169"://Type of income
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[0].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00170"://Year for which paid
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[1].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00171"://Gross Amount
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[2].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00172"://Provident and pension fund contribution
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[3].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00173"://Type of income
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[0].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00174"://Year for which paid
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[1].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00175"://Gross Amount
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[2].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00176"://Provident and pension fund contribution
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[3].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00177"://Type of income
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[0].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00178"://Year for which paid
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[1].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00179"://Gross Amount
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[2].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00180"://Provident and pension fund contribution
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[3].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00361"://Type of income
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[0].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00362"://Year for which paid
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[1].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00363"://Gross Amount
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[2].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00364"://Provident and pension fund contribution
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[3].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00365"://Type of income
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[0].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00366"://Year for which paid
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[1].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00367"://Gross Amount
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[2].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00368"://Provident and pension fund contribution'
        //                            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
        //                            {
        //                                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[3].ToString();
        //                            }
        //                            break;
        //                    }
        //                    FireInpElementEvent(inpElement, "OnBlur");
        //                    break;
        //                case "M2008Page4":
        //                    switch (inpElement.name)
        //                    {
        //                        case "ctl00$master$txtF00149"://Chargeable Income 0
        //                            inpElement.value = dsData.Tables["P4_CHARGEABLE_INCOME"].Rows[0].ItemArray[0].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00316"://Chargeable Income 1
        //                            inpElement.value = dsData.Tables["P4_CHARGEABLE_INCOME"].Rows[0].ItemArray[1].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00319"://Chargeable Income 2
        //                            inpElement.value = dsData.Tables["P4_CHARGEABLE_INCOME"].Rows[0].ItemArray[2].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00322"://Chargeable Income 3
        //                            inpElement.value = dsData.Tables["P4_CHARGEABLE_INCOME"].Rows[0].ItemArray[3].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00325"://Chargeable Income 4
        //                            inpElement.value = dsData.Tables["P4_CHARGEABLE_INCOME"].Rows[0].ItemArray[4].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00328"://Chargeable Income 5
        //                            inpElement.value = dsData.Tables["P4_CHARGEABLE_INCOME"].Rows[0].ItemArray[5].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00331"://Chargeable Income 6
        //                            inpElement.value = dsData.Tables["P4_CHARGEABLE_INCOME"].Rows[0].ItemArray[6].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00332"://Rate 1
        //                            inpElement.value = dsData.Tables["P4_CHARGEABLE_INCOME"].Rows[0].ItemArray[7].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00157"://Rebate - Levy
        //                            dr = dsData.Tables["P3_TAX_REBATE"].Rows.Find("5");
        //                            inpElement.value = dr["TCR_AMOUNT"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00160"://Sec 110 (Dividend)
        //                            inpElement.value = dsData.Tables["P4_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00161"://Sec 110 (Others)
        //                            inpElement.value = dsData.Tables["P4_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00308"://Sec 130
        //                            inpElement.value = dsData.Tables["P4_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00347"://Sec133
        //                            inpElement.value = dsData.Tables["P4_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString();
        //                            break;
        //                    }
        //                    FireInpElementEvent(inpElement, "OnBlur");
        //                    break;
        //                case "M2008Page5":
        //                    switch (inpElement.name)
        //                    {
        //                        case "ctl00$master$txtF00190"://Balance from current year
        //                            inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00191"://Balance from previous year
        //                            inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00351"://Pioneer Loss Amount Absorbed
        //                            inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00352"://Pioneer Loss c/f
        //                            inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00193"://Business 1 Absorbed
        //                            nTotal = 0;
        //                            if (dsData.Tables["P5_INCOME_ADJUSTED"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P5_INCOME_ADJUSTED"].Rows[0].ItemArray[0].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P5_INCOME_ADJUSTED"].Rows[0].ItemArray[0].ToString());
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00194"://Business 1 c/f
        //                            nTotal1 = 0;
        //                            if (dsData.Tables["P5_INCOME_ADJUSTED"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P5_INCOME_ADJUSTED"].Rows[0].ItemArray[1].ToString();
        //                                nTotal1 = double.Parse(dsData.Tables["P5_INCOME_ADJUSTED"].Rows[0].ItemArray[1].ToString());
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00195"://Business 2 Absorbed
        //                            if (dsData.Tables["P5_INCOME_ADJUSTED"].Rows.Count > 1)
        //                            {
        //                                inpElement.value = dsData.Tables["P5_INCOME_ADJUSTED"].Rows[1].ItemArray[0].ToString();
        //                                nTotal = nTotal + double.Parse(dsData.Tables["P5_INCOME_ADJUSTED"].Rows[1].ItemArray[0].ToString());
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00196"://Business 2 c/f
        //                            if (dsData.Tables["P5_INCOME_ADJUSTED"].Rows.Count > 1)
        //                            {
        //                                inpElement.value = dsData.Tables["P5_INCOME_ADJUSTED"].Rows[1].ItemArray[1].ToString();
        //                                nTotal1 = nTotal1 + double.Parse(dsData.Tables["P5_INCOME_ADJUSTED"].Rows[1].ItemArray[1].ToString());
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00197"://Business 3++ Absorbed
        //                            if (dsData.Tables["P5_INCOME_ADJUSTED"].Rows.Count > 2)
        //                            {
        //                                for (int i = 0; i < dsData.Tables["P5_INCOME_ADJUSTED"].Rows.Count; i++)
        //                                {
        //                                    nTotal2 = nTotal2 + double.Parse(dsData.Tables["P5_INCOME_ADJUSTED"].Rows[i].ItemArray[0].ToString());
        //                                }
        //                                nTotal = nTotal2 - nTotal;
        //                                inpElement.value = Convert.ToString(nTotal);
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00198"://Business 3++ c/f
        //                            nTotal2 = 0;
        //                            if (dsData.Tables["P5_INCOME_ADJUSTED"].Rows.Count > 2)
        //                            {
        //                                for (int i = 0; i < dsData.Tables["P5_INCOME_ADJUSTED"].Rows.Count; i++)
        //                                {
        //                                    nTotal2 = nTotal2 + double.Parse(dsData.Tables["P5_INCOME_ADJUSTED"].Rows[i].ItemArray[1].ToString());
        //                                }
        //                                nTotal1 = nTotal2 - nTotal1;
        //                                inpElement.value = Convert.ToString(nTotal1);
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00199"://Partnership 1 Absorbed
        //                            nTotal = 0;
        //                            if (dsData.Tables["P5_INCOME_PARTNERSHIP"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P5_INCOME_PARTNERSHIP"].Rows[0].ItemArray[0].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P5_INCOME_PARTNERSHIP"].Rows[0].ItemArray[0].ToString());
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00200"://Partnership 1 c/f
        //                            nTotal1 = 0;
        //                            if (dsData.Tables["P5_INCOME_PARTNERSHIP"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P5_INCOME_PARTNERSHIP"].Rows[0].ItemArray[1].ToString();
        //                                nTotal1 = double.Parse(dsData.Tables["P5_INCOME_PARTNERSHIP"].Rows[0].ItemArray[1].ToString());
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00201"://Partnership 2 Absorbed
        //                            if (dsData.Tables["P5_INCOME_PARTNERSHIP"].Rows.Count > 1)
        //                            {
        //                                inpElement.value = dsData.Tables["P5_INCOME_PARTNERSHIP"].Rows[1].ItemArray[0].ToString();
        //                                nTotal = nTotal + double.Parse(dsData.Tables["P5_INCOME_PARTNERSHIP"].Rows[1].ItemArray[0].ToString());
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00202"://Partnership 2 c/f
        //                            if (dsData.Tables["P5_INCOME_PARTNERSHIP"].Rows.Count > 1)
        //                            {
        //                                inpElement.value = dsData.Tables["P5_INCOME_PARTNERSHIP"].Rows[1].ItemArray[1].ToString();
        //                                nTotal1 = nTotal1 + double.Parse(dsData.Tables["P5_INCOME_PARTNERSHIP"].Rows[1].ItemArray[1].ToString());
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00203"://Partnership 3++ Absorbed
        //                            nTotal2 = 0;
        //                            if (dsData.Tables["P5_INCOME_PARTNERSHIP"].Rows.Count > 2)
        //                            {
        //                                for (int i = 0; i < dsData.Tables["P5_INCOME_PARTNERSHIP"].Rows.Count; i++)
        //                                {
        //                                    nTotal2 = nTotal2 + double.Parse(dsData.Tables["P5_INCOME_PARTNERSHIP"].Rows[i].ItemArray[0].ToString());
        //                                }
        //                                nTotal = nTotal2 - nTotal;
        //                                inpElement.value = Convert.ToString(nTotal);
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00204"://Partnership 3++ c/f
        //                            nTotal2 = 0;
        //                            if (dsData.Tables["P5_INCOME_PARTNERSHIP"].Rows.Count > 2)
        //                            {
        //                                for (int i = 0; i < dsData.Tables["P5_INCOME_PARTNERSHIP"].Rows.Count; i++)
        //                                {
        //                                    nTotal2 = nTotal2 + double.Parse(dsData.Tables["P5_INCOME_PARTNERSHIP"].Rows[i].ItemArray[1].ToString());
        //                                }
        //                                nTotal1 = nTotal2 - nTotal1;
        //                                inpElement.value = Convert.ToString(nTotal1);
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00205"://107A Gross
        //                            dr = dsData.Tables["P5_NON_RESIDENT"].Rows.Find("1");
        //                            inpElement.value = dr["NR_GROSS_TOTAL"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00206"://107A LHDNM
        //                            dr = dsData.Tables["P5_NON_RESIDENT"].Rows.Find("1");
        //                            inpElement.value = Convert.ToString(double.Parse(dr["NR_WITHHOLD"].ToString()) + double.Parse(dr["NR_WITHHOLD_107A"].ToString()));
        //                            break;
        //                        case "ctl00$master$txtF00207"://109 Gross
        //                            dr = dsData.Tables["P5_NON_RESIDENT"].Rows.Find("2");
        //                            inpElement.value = dr["NR_GROSS_TOTAL"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00208"://109 LHDNM
        //                            dr = dsData.Tables["P5_NON_RESIDENT"].Rows.Find("2");
        //                            inpElement.value = dr["NR_WITHHOLD"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00209"://109A Gross
        //                            dr = dsData.Tables["P5_NON_RESIDENT"].Rows.Find("3");
        //                            inpElement.value = dr["NR_GROSS_TOTAL"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00210"://109A LHDNM
        //                            dr = dsData.Tables["P5_NON_RESIDENT"].Rows.Find("3");
        //                            inpElement.value = dr["NR_WITHHOLD"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00309"://109B Gross
        //                            dr = dsData.Tables["P5_NON_RESIDENT"].Rows.Find("4");
        //                            inpElement.value = dr["NR_GROSS_TOTAL"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00211"://109B LHDNM
        //                            dr = dsData.Tables["P5_NON_RESIDENT"].Rows.Find("4");
        //                            inpElement.value = dr["NR_WITHHOLD"].ToString();
        //                            break;
        //                    }
        //                    FireInpElementEvent(inpElement, "OnBlur");
        //                    break;
        //                case "M2008Page6":
        //                    switch (inpElement.name)
        //                    {
        //                        case "ctl00$master$txtF00212": //Claim Code 1
        //                            if (dsData.Tables["P6_INCOME_ADJ_FURTHER"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P6_INCOME_ADJ_FURTHER"].Rows[0].ItemArray[0].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00213": //Amount 1
        //                            if (dsData.Tables["P6_INCOME_ADJ_FURTHER"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P6_INCOME_ADJ_FURTHER"].Rows[0].ItemArray[1].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00214": //Claim Code 2
        //                            if (dsData.Tables["P6_INCOME_ADJ_FURTHER"].Rows.Count > 1)
        //                            {
        //                                inpElement.value = dsData.Tables["P6_INCOME_ADJ_FURTHER"].Rows[1].ItemArray[0].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00215": //Amount 2
        //                            if (dsData.Tables["P6_INCOME_ADJ_FURTHER"].Rows.Count > 1)
        //                            {
        //                                inpElement.value = dsData.Tables["P6_INCOME_ADJ_FURTHER"].Rows[1].ItemArray[1].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00216": //Claim Code 3
        //                            if (dsData.Tables["P6_INCOME_ADJ_FURTHER"].Rows.Count > 2)
        //                            {
        //                                inpElement.value = dsData.Tables["P6_INCOME_ADJ_FURTHER"].Rows[2].ItemArray[0].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00217": //Amount 3
        //                            if (dsData.Tables["P6_INCOME_ADJ_FURTHER"].Rows.Count > 2)
        //                            {
        //                                inpElement.value = dsData.Tables["P6_INCOME_ADJ_FURTHER"].Rows[2].ItemArray[1].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00218": //Claim Code 4
        //                            if (dsData.Tables["P6_INCOME_ADJ_FURTHER"].Rows.Count > 3)
        //                            {
        //                                inpElement.value = dsData.Tables["P6_INCOME_ADJ_FURTHER"].Rows[3].ItemArray[0].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00219": //Amount 4
        //                            if (dsData.Tables["P6_INCOME_ADJ_FURTHER"].Rows.Count > 3)
        //                            {
        //                                inpElement.value = dsData.Tables["P6_INCOME_ADJ_FURTHER"].Rows[3].ItemArray[1].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00225": //Schedule 4 c/f
        //                            dr = dsData.Tables["P6_TAX_INCENTIVE_CLAIM"].Rows.Find("3");
        //                            inpElement.value = dr["TIC_CF"].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00353": //Pioneer Income Exempted
        //                            dr = dsData.Tables["P6_TAX_INCENTIVE_CLAIM"].Rows.Find("5");
        //                            inpElement.value = dr["TIC_CF"].ToString();
        //                            break;
        //                    }
        //                    FireInpElementEvent(inpElement, "OnBlur");
        //                    break;
        //                case "M2008Page7":
        //                    switch (inpElement.name)
        //                    {
        //                        //Profit and Loss
        //                        case "ctl00$master$txtNama_Niaga"://Nama Perniagaan
        //                            if (dsData.Tables["P7_MAIN_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_BUSINESS_SOURCE"].Rows[0].ItemArray[0].ToString();
        //                            }
        //                            else if (dsData.Tables["P7_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_BUSINESS_SOURCE"].Rows[0].ItemArray[0].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00227": //Business Code
        //                            if (dsData.Tables["P7_MAIN_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_BUSINESS_SOURCE"].Rows[0].ItemArray[1].ToString();
        //                            }
        //                            else if (dsData.Tables["P7_BUSINESS_SOURCE"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_BUSINESS_SOURCE"].Rows[0].ItemArray[1].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00228": //Sales
        //                            nTotal = 0;
        //                            if (dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString());
        //                            }
        //                            else if (dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString());
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00229": //Opening Stock
        //                            nTotal1 = 0;
        //                            if (dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[1].ToString();
        //                                nTotal1 = double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[1].ToString());
        //                            }
        //                            else if (dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[1].ToString();
        //                                nTotal1 = double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[1].ToString());
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00230": //Purchase and Cost of Production
        //                            if (dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[2].ToString();
        //                                nTotal1 = nTotal1 + double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[2].ToString());
        //                            }
        //                            else if (dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[2].ToString();
        //                                nTotal1 = nTotal1 + double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[2].ToString());
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00231": //Closing Stock
        //                            if (dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[3].ToString();
        //                                nTotal1 = nTotal1 - double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[3].ToString());
        //                                nTotal1 = nTotal - nTotal1;
        //                            }
        //                            else if (dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[3].ToString();
        //                                nTotal1 = nTotal1 - double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[3].ToString());
        //                                nTotal1 = nTotal - nTotal1;
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00235": //Other Business
        //                            double dblOtherBusIn = 0;
        //                            if (dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                if (dsData.Tables["P7_MAIN_INCOME_OTHERBUSINESS"].Rows.Count > 0)
        //                                {
        //                                    if (!String.IsNullOrEmpty(dsData.Tables["P7_MAIN_INCOME_OTHERBUSINESS"].Rows[0].ItemArray[0].ToString()))
        //                                        dblOtherBusIn = double.Parse(dsData.Tables["P7_MAIN_INCOME_OTHERBUSINESS"].Rows[0].ItemArray[0].ToString());
        //                                }
        //                                foreach (DataRow row in dsData.Tables["P7_MAIN_PNL"].Rows)
        //                                {
        //                                    dblOtherBusIn = dblOtherBusIn + dal.OtherSource_GrossProfitLoss(long.Parse(dsData.Tables["P7_MAIN_PNL"].Rows[0].ItemArray[0].ToString()),
        //                                                dsData.Tables["P7_MAIN_BUSINESS_SOURCE"].Rows[0].ItemArray[1].ToString());
        //                                    //inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT_GROSS"].Rows[0].ItemArray[0].ToString()));
        //                                }
        //                                inpElement.value = dblOtherBusIn.ToString();
        //                                nTotal1 = nTotal1 + dblOtherBusIn;
        //                                    //(double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT_GROSS"].Rows[0].ItemArray[0].ToString()));
        //                            }
        //                            else if (dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                if (dsData.Tables["P7_INCOME_OTHERBUSINESS"].Rows.Count > 0)
        //                                {
        //                                    if (!String.IsNullOrEmpty(dsData.Tables["P7_INCOME_OTHERBUSINESS"].Rows[0].ItemArray[0].ToString()))
        //                                        dblOtherBusIn = double.Parse(dsData.Tables["P7_INCOME_OTHERBUSINESS"].Rows[0].ItemArray[0].ToString());
        //                                }
        //                                foreach (DataRow row in dsData.Tables["P7_OTHER_PNL"].Rows)
        //                                {
        //                                    dblOtherBusIn = dblOtherBusIn + dal.OtherSource_GrossProfitLoss(long.Parse(dsData.Tables["P7_OTHER_PNL"].Rows[0].ItemArray[0].ToString()),
        //                                                dsData.Tables["P7_BUSINESS_SOURCE"].Rows[0].ItemArray[1].ToString());
        //                                    //inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT_GROSS"].Rows[0].ItemArray[0].ToString()));
        //                                }
        //                                inpElement.value = dblOtherBusIn.ToString();
        //                                nTotal1 = nTotal1 + dblOtherBusIn;
        //                                    //(double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT_GROSS"].Rows[0].ItemArray[0].ToString()));
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00236": //Dividend
        //                            if (dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[5].ToString();
        //                                nTotal1 = nTotal1 + double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[5].ToString());
        //                            }
        //                            else if (dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[5].ToString();
        //                                nTotal1 = nTotal1 + double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[5].ToString());
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00237": //Interest and Discount
        //                            if (dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[6].ToString();
        //                                nTotal1 = nTotal1 + double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[6].ToString());
        //                            }
        //                            else if (dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[6].ToString();
        //                                nTotal1 = nTotal1 + double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[6].ToString());
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00238": //Rent, Royalties and premiums
        //                            if (dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[8].ToString()));
        //                                nTotal1 = nTotal1 + (double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[8].ToString()));
        //                            }
        //                            else if (dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[8].ToString()));
        //                                nTotal1 = nTotal1 + (double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[8].ToString()));
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00239": //Other Income
        //                            if (dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[9].ToString()) + double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[10].ToString()));
        //                                nTotal1 = nTotal1 + (double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[9].ToString()) + double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[10].ToString()));
        //                            }
        //                            else if (dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[9].ToString()) + double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[10].ToString()));
        //                                nTotal1 = nTotal1 + (double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[9].ToString()) + double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[10].ToString()));
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00241": //Loan Interest
        //                            nTotal = 0;
        //                            if (dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[11].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[11].ToString());
        //                                nTotal1 = nTotal1 - nTotal;
        //                            }
        //                            else if (dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[11].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[11].ToString());
        //                                nTotal1 = nTotal1 - nTotal;
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00242": //Salaries and Wages
        //                            if (dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[12].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[12].ToString());
        //                                nTotal1 = nTotal1 - nTotal;
        //                            }
        //                            else if (dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[12].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[12].ToString());
        //                                nTotal1 = nTotal1 - nTotal;
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00243": //Rent and Lease
        //                            if (dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[13].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[13].ToString());
        //                                nTotal1 = nTotal1 - nTotal;
        //                            }
        //                            else if (dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[13].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[13].ToString());
        //                                nTotal1 = nTotal1 - nTotal;
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00244": //Contract and Subcontrace
        //                            if (dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[14].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[14].ToString());
        //                                nTotal1 = nTotal1 - nTotal;
        //                            }
        //                            else if (dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[14].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[14].ToString());
        //                                nTotal1 = nTotal1 - nTotal;
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00245": //Commissions
        //                            if (dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[15].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[15].ToString());
        //                                nTotal1 = nTotal1 - nTotal;
        //                            }
        //                            else if (dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[15].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[15].ToString());
        //                                nTotal1 = nTotal1 - nTotal;
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00246": //Bad Debts
        //                            if (dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[16].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[16].ToString());
        //                                nTotal1 = nTotal1 - nTotal;
        //                            }
        //                            else if (dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[16].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[16].ToString());
        //                                nTotal1 = nTotal1 - nTotal;
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00247": //Travelling and Transport
        //                            if (dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[17].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[17].ToString());
        //                                nTotal1 = nTotal1 - nTotal;
        //                            }
        //                            else if (dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[17].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[17].ToString());
        //                                nTotal1 = nTotal1 - nTotal;
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00383": //Repair and Maintenance
        //                            if (dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[18].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[18].ToString());
        //                                nTotal1 = nTotal1 - nTotal;
        //                            }
        //                            else if (dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[18].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[18].ToString());
        //                                nTotal1 = nTotal1 - nTotal;
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00384": //Promotion and Advertisement
        //                            if (dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[19].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[19].ToString());
        //                                nTotal1 = nTotal1 - nTotal;
        //                            }
        //                            else if (dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[19].ToString();
        //                                nTotal = double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[19].ToString());
        //                                nTotal1 = nTotal1 - nTotal;
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00248": //Other Expenses
        //                            double dblTotal = 0;

        //                            if (dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                if (!String.IsNullOrEmpty(dsData.Tables["P7_MAIN_EXPENSES_OTHER"].Rows[0].ItemArray[0].ToString()))
        //                                    dblTotal = dblTotal + double.Parse(dsData.Tables["P7_MAIN_EXPENSES_OTHER"].Rows[0].ItemArray[0].ToString());
        //                                if (!String.IsNullOrEmpty(dsData.Tables["P7_MAIN_LOSS_NONALLOW"].Rows[0].ItemArray[0].ToString()))
        //                                    dblTotal = dblTotal + double.Parse(dsData.Tables["P7_MAIN_LOSS_NONALLOW"].Rows[0].ItemArray[0].ToString());
        //                                if (!String.IsNullOrEmpty(dsData.Tables["P7_MAIN_EXPENSES_NONALLOW"].Rows[0].ItemArray[0].ToString()))
        //                                    dblTotal = dblTotal + double.Parse(dsData.Tables["P7_MAIN_EXPENSES_NONALLOW"].Rows[0].ItemArray[0].ToString());
        //                                if (!String.IsNullOrEmpty(dsData.Tables["P7_MAIN_EXPENSES_PERSONAL"].Rows[0].ItemArray[0].ToString()))
        //                                    dblTotal = dblTotal + double.Parse(dsData.Tables["P7_MAIN_EXPENSES_PERSONAL"].Rows[0].ItemArray[0].ToString());
        //                                inpElement.value = dblTotal.ToString();
        //                                //inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[20].ToString()) - nTotal);
        //                                nTotal1 = nTotal1 - dblTotal;//(double.Parse(dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[20].ToString()) - nTotal);
        //                            }
        //                            else if (dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                if (!String.IsNullOrEmpty(dsData.Tables["P7_EXPENSES_OTHER"].Rows[0].ItemArray[0].ToString()))
        //                                    dblTotal = dblTotal + double.Parse(dsData.Tables["P7_EXPENSES_OTHER"].Rows[0].ItemArray[0].ToString());
        //                                if (!String.IsNullOrEmpty(dsData.Tables["P7_LOSS_NONALLOW"].Rows[0].ItemArray[0].ToString()))
        //                                    dblTotal = dblTotal + double.Parse(dsData.Tables["P7_LOSS_NONALLOW"].Rows[0].ItemArray[0].ToString());
        //                                if (!String.IsNullOrEmpty(dsData.Tables["P7_EXPENSES_NONALLOW"].Rows[0].ItemArray[0].ToString()))
        //                                    dblTotal = dblTotal + double.Parse(dsData.Tables["P7_EXPENSES_NONALLOW"].Rows[0].ItemArray[0].ToString());
        //                                if (!String.IsNullOrEmpty(dsData.Tables["P7_EXPENSES_PERSONAL"].Rows[0].ItemArray[0].ToString()))
        //                                    dblTotal = dblTotal + double.Parse(dsData.Tables["P7_EXPENSES_PERSONAL"].Rows[0].ItemArray[0].ToString());
        //                                inpElement.value = dblTotal.ToString();
        //                                //inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[20].ToString()) - nTotal);
        //                                nTotal1 = nTotal1 - dblTotal;//(double.Parse(dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[20].ToString()) - nTotal);
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00251":
        //                            if (dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = Convert.ToString(nTotal1);
        //                            }
        //                            else if (dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = Convert.ToString(nTotal1);
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00252": //Non-allowable expenses
        //                            double dblNAExpenses = 0;
        //                            if (dsData.Tables["P7_MAIN_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                if (!String.IsNullOrEmpty(dsData.Tables["P7_MAIN_PL_EXPENSES"].Rows[0].ItemArray[0].ToString()))
        //                                {
        //                                    dblNAExpenses = dblNAExpenses + double.Parse(dsData.Tables["P7_MAIN_PL_EXPENSES"].Rows[0].ItemArray[0].ToString());
        //                                }
        //                                if (!String.IsNullOrEmpty(dsData.Tables["P7_MAIN_PL_EXP_NONALLOWEXPEND"].Rows[0].ItemArray[0].ToString()))
        //                                {
        //                                    dblNAExpenses = dblNAExpenses + double.Parse(dsData.Tables["P7_MAIN_PL_EXP_NONALLOWEXPEND"].Rows[0].ItemArray[0].ToString());
        //                                }
        //                                if(!String.IsNullOrEmpty(dsData.Tables["P7_MAIN_PL_EXP_PERSONAL"].Rows[0].ItemArray[0].ToString()))
        //                                {
        //                                    dblNAExpenses = dblNAExpenses + double.Parse(dsData.Tables["P7_MAIN_PL_EXP_PERSONAL"].Rows[0].ItemArray[0].ToString());
        //                                }
        //                                if(!String.IsNullOrEmpty(dsData.Tables["P7_MAIN_PL_PRODUCTION_COST"].Rows[0].ItemArray[0].ToString()))
        //                                {
        //                                    dblNAExpenses = dblNAExpenses + double.Parse(dsData.Tables["P7_MAIN_PL_PRODUCTION_COST"].Rows[0].ItemArray[0].ToString());
        //                                }
        //                                inpElement.value  = dblNAExpenses.ToString();
        //                            }
        //                            else if (dsData.Tables["P7_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
        //                            {
        //                                if (!String.IsNullOrEmpty(dsData.Tables["P7_PL_EXPENSES"].Rows[0].ItemArray[0].ToString()))
        //                                {
        //                                    dblNAExpenses = dblNAExpenses + double.Parse(dsData.Tables["P7_PL_EXPENSES"].Rows[0].ItemArray[0].ToString());
        //                                }
        //                                if (!String.IsNullOrEmpty(dsData.Tables["P7_PL_EXP_NONALLOWEXPEND"].Rows[0].ItemArray[0].ToString()))
        //                                {
        //                                    dblNAExpenses = dblNAExpenses + double.Parse(dsData.Tables["P7_PL_EXP_NONALLOWEXPEND"].Rows[0].ItemArray[0].ToString());
        //                                }
        //                                if (!String.IsNullOrEmpty(dsData.Tables["P7_PL_EXP_PERSONAL"].Rows[0].ItemArray[0].ToString()))
        //                                {
        //                                    dblNAExpenses = dblNAExpenses + double.Parse(dsData.Tables["P7_PL_EXP_PERSONAL"].Rows[0].ItemArray[0].ToString());
        //                                }
        //                                if (!String.IsNullOrEmpty(dsData.Tables["P7_PL_PRODUCTION_COST"].Rows[0].ItemArray[0].ToString()))
        //                                {
        //                                    dblNAExpenses = dblNAExpenses + double.Parse(dsData.Tables["P7_PL_PRODUCTION_COST"].Rows[0].ItemArray[0].ToString());
        //                                }
        //                                inpElement.value = dblNAExpenses.ToString();
        //                            }
        //                            break;
        //                        //Balance Sheet
        //                        case "ctl00$master$txtF00253"://Land and Building
        //                            if (dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows[0].ItemArray[0].ToString();
        //                            }
        //                            else if (dsData.Tables["P7_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_BALANCE_SHEET"].Rows[0].ItemArray[0].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00254"://Plant and Machinery
        //                            if (dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows[0].ItemArray[1].ToString();
        //                            }
        //                            else if (dsData.Tables["P7_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_BALANCE_SHEET"].Rows[0].ItemArray[1].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00255"://Motor Vehicle
        //                            if (dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows[0].ItemArray[2].ToString();
        //                            }
        //                            else if (dsData.Tables["P7_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_BALANCE_SHEET"].Rows[0].ItemArray[2].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00256"://Other Fixed Assets
        //                            if (dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows[0].ItemArray[3].ToString();
        //                            }
        //                            else if (dsData.Tables["P7_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_BALANCE_SHEET"].Rows[0].ItemArray[3].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00258"://Investments
        //                            if (dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows[0].ItemArray[4].ToString();
        //                            }
        //                            else if (dsData.Tables["P7_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_BALANCE_SHEET"].Rows[0].ItemArray[4].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00259"://Stock
        //                            if (dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows[0].ItemArray[5].ToString();
        //                            }
        //                            else if (dsData.Tables["P7_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_BALANCE_SHEET"].Rows[0].ItemArray[5].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00260"://Trade Dubtors
        //                            if (dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows[0].ItemArray[6].ToString();
        //                            }
        //                            else if (dsData.Tables["P7_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_BALANCE_SHEET"].Rows[0].ItemArray[6].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00261"://Sundry Debtors
        //                            if (dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows[0].ItemArray[7].ToString();
                                               
        //                            }
        //                            else if (dsData.Tables["P7_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_BALANCE_SHEET"].Rows[0].ItemArray[7].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00262"://Cash in hand
        //                            if (dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows[0].ItemArray[8].ToString();
        //                            }
        //                            else if (dsData.Tables["P7_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_BALANCE_SHEET"].Rows[0].ItemArray[8].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00263"://Cash at Bank
        //                            if (dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows[0].ItemArray[9].ToString();
        //                            }
        //                            else if (dsData.Tables["P7_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_BALANCE_SHEET"].Rows[0].ItemArray[9].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00264"://Other current assets
        //                            if (dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows[0].ItemArray[10].ToString();
        //                            }
        //                            else if (dsData.Tables["P7_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_BALANCE_SHEET"].Rows[0].ItemArray[10].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00267"://Loans
        //                            if (dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows[0].ItemArray[11].ToString();
        //                            }
        //                            else if (dsData.Tables["P7_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_BALANCE_SHEET"].Rows[0].ItemArray[11].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00268"://Trade creditors
        //                            if (dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows[0].ItemArray[12].ToString();
        //                            }
        //                            else if (dsData.Tables["P7_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_BALANCE_SHEET"].Rows[0].ItemArray[12].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00269"://Sundry creditors
        //                            if (dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = (double.Parse(dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows[0].ItemArray[13].ToString()) +
        //                                                double.Parse(dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows[0].ItemArray[20].ToString()) +
        //                                                double.Parse(dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows[0].ItemArray[21].ToString())).ToString();
        //                            }
        //                            else if (dsData.Tables["P7_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = (double.Parse(dsData.Tables["P7_BALANCE_SHEET"].Rows[0].ItemArray[13].ToString()) +
        //                                                  double.Parse(dsData.Tables["P7_BALANCE_SHEET"].Rows[0].ItemArray[20].ToString()) +
        //                                                  double.Parse(dsData.Tables["P7_BALANCE_SHEET"].Rows[0].ItemArray[21].ToString())).ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00271"://Capital Account
        //                            if (dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows[0].ItemArray[14].ToString();
        //                            }
        //                            else if (dsData.Tables["P7_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_BALANCE_SHEET"].Rows[0].ItemArray[14].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00272"://Current a/c b/f
        //                            if (dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows[0].ItemArray[15].ToString();
        //                            }
        //                            else if (dsData.Tables["P7_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_BALANCE_SHEET"].Rows[0].ItemArray[15].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00274"://Current Year Profit/ Loss
        //                            if (dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows[0].ItemArray[16].ToString();
        //                            }
        //                            else if (dsData.Tables["P7_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_BALANCE_SHEET"].Rows[0].ItemArray[16].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00275"://Net advanced/ drawng
        //                            if (dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows[0].ItemArray[17].ToString()) - double.Parse(dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows[0].ItemArray[18].ToString()));
        //                            }
        //                            else if (dsData.Tables["P7_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P7_BALANCE_SHEET"].Rows[0].ItemArray[17].ToString()) - double.Parse(dsData.Tables["P7_BALANCE_SHEET"].Rows[0].ItemArray[18].ToString()));
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00276"://Current account c/f
        //                            if (dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_MAIN_BALANCE_SHEET"].Rows[0].ItemArray[19].ToString();
        //                            }
        //                            else if (dsData.Tables["P7_BALANCE_SHEET"].Rows.Count > 0)
        //                            {
        //                                inpElement.value = dsData.Tables["P7_BALANCE_SHEET"].Rows[0].ItemArray[19].ToString();
        //                            }
        //                            break;
        //                    }
        //                    FireInpElementEvent(inpElement, "OnBlur");
        //                    break;
        //                case "M2008Page8":
        //                    switch (inpElement.name)
        //                    {
        //                        case "ctl00$master$txtF00183":
        //                            inpElement.value = dsData.Tables["P8_TAXADM_PROFILE"].Rows[0].ItemArray[0].ToString();
        //                            break;
        //                        case "ctl00$master$txtF00185":
        //                            if (!String.IsNullOrEmpty(dsData.Tables["P8_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
        //                            {
        //                                inpElement.value = dsData.Tables["P8_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString() +
        //                                    dsData.Tables["P8_TAXADM_PROFILE"].Rows[0].ItemArray[2].ToString() + 
        //                                    dsData.Tables["P8_TAXADM_PROFILE"].Rows[0].ItemArray[3].ToString();
        //                            }
        //                            else if (!String.IsNullOrEmpty(dsData.Tables["P8_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
        //                            {
        //                                inpElement.value = dsData.Tables["P8_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString();
        //                            }
        //                            else if (!String.IsNullOrEmpty(dsData.Tables["P8_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
        //                            {
        //                                inpElement.value = dsData.Tables["P8_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString();
        //                            }
        //                            else if (!String.IsNullOrEmpty(dsData.Tables["P8_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
        //                            {
        //                                inpElement.value = dsData.Tables["P8_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString();
        //                            }
        //                            break;
        //                        case "ctl00$master$txtF00290":
        //                            inpElement.value = dsData.Tables["P8_TAXA_PROFILE"].Rows[0].ItemArray[0].ToString();
        //                            break;
        //                    }
        //                    break;
        //            }
        //        }
        //        foreach (mshtml.HTMLSelectElement selElement in htmlDoc.getElementsByTagName("select"))
        //        {
        //            switch (strPageIndex)
        //            {
        //                case "M2008Page1":
        //                    switch (selElement.name)
        //                    {
        //                        case "ctl00$master$ddlF00010"://Citizan
        //                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[2].ToString();
        //                            break;
        //                        case "ctl00$master$ddlF00011"://Country of Residence
        //                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString();
        //                            break;
        //                        case "ctl00$master$ddlF00012"://Sex
        //                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString();
        //                            break;
        //                        case "ctl00$master$ddlF00013"://Status
        //                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString();
        //                            break;
        //                        case "ctl00$master$ddlF00016"://Type of Assessment
        //                            if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() == "1")
        //                            {
        //                                if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[36].ToString()))
        //                                {
        //                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[36].ToString() == "1")
        //                                    { selElement.value = "1"; }
        //                                    else
        //                                    { selElement.value = "2"; }
        //                                }
        //                            }
        //                            else if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() == "2")
        //                            {
        //                                selElement.value = "3";
        //                            }
        //                            else if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() == "3")
        //                            {
        //                                selElement.value = "4";
        //                            }
        //                            break;
        //                        case "ctl00$master$ddlF00018"://Public Rulings
        //                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
        //                            break;
        //                        case "ctl00$master$ddlF00378"://Record-keeping
        //                            selElement.value = strRecKept == "True" ? selElement.value = "1" : selElement.value = "2";
        //                            break;
        //                        case "ctl00$master$ddlF00024"://Correspondence Add - State
        //                            selElement.value = SelectState(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[15].ToString());
        //                            break;
        //                        case "ctl00$master$ddlF00030"://Permanent Add - State
        //                            selElement.value = SelectState(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[21].ToString());
        //                            break;
        //                        case "ctl00$master$ddlF00036"://Business Premise Add - State
        //                            selElement.value = SelectState(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[27].ToString());
        //                            break;
        //                    }
        //                    FireSelElementEvent(selElement, "OnChange");
        //                    break;
        //                case "M2008Page2":
        //                    switch (selElement.name)
        //                    {
        //                        case "ctl00$master$ddlF00054"://Ref Prefix
        //                            selElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
        //                            break;
        //                        case "ctl00$master$ddlJPengenalan_isteri"://Identity Type
        //                            if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
        //                            {
        //                                selElement.value = "NEWIC";
        //                            }
        //                            else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
        //                            {
        //                                selElement.value = "POLICE";
        //                            }
        //                            else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
        //                            {
        //                                selElement.value = "ARMY";
        //                            }
        //                            else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
        //                            {
        //                                selElement.value = "PASSPORT";
        //                            }
        //                            break;
        //                    }
        //                    break;
        //                case "M2008Page3":
        //                    switch (selElement.name)
        //                    {
        //                        case "ctl00$master$ddlF00380"://Claim Exemption
        //                            if (dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString() == "1")
        //                            {
        //                                selElement.value = "1";
        //                            }
        //                            else if (dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString() == "2")
        //                            {
        //                                selElement.value = "2";
        //                            }
        //                            FireSelElementEvent(selElement, "OnChange");
        //                            break;
        //                        case "ctl00$master$ddlF00011a"://Claim Exemption under 
        //                            selElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString();
        //                            break;
        //                        case "ctl00$master$ddlF00355"://Type of income transfer from husband/wife
        //                            if (dsData.Tables["P3_TAX_PROFILE"].Rows[0].ItemArray[11].ToString() == "1")
        //                            {
        //                                selElement.value = "1";//Ada pendapatan perniagaan (With business income)
        //                            }
        //                            else if (dsData.Tables["P3_TAX_PROFILE"].Rows[0].ItemArray[11].ToString() == "2")
        //                            {
        //                                selElement.value = "2";//Tiada punca pendapatan perniagaan (Without business income)
        //                            }
        //                            break;
        //                    }
        //                    break;
        //                case "M2008Page8":
        //                    switch (selElement.name)
        //                    {
        //                        case "ctl00$master$ddlJPengenalan_mati" :
        //                            if (!String.IsNullOrEmpty(dsData.Tables["P8_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
        //                            {
        //                                selElement.value = "NEWIC";
        //                            }
        //                            else if (!String.IsNullOrEmpty(dsData.Tables["P8_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
        //                            {
        //                                selElement.value = "POLICE";
        //                            }
        //                            else if (!String.IsNullOrEmpty(dsData.Tables["P8_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
        //                            {
        //                                selElement.value = "ARMY";
        //                            }
        //                            else if (!String.IsNullOrEmpty(dsData.Tables["P8_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
        //                            {
        //                                selElement.value = "PASSPORT";
        //                            }
        //                            FireSelElementEvent(selElement, "OnChange");
        //                            break;
        //                    }
        //                    break;
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        private void ProcessFormP(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            //FileStream file = new FileStream("path.txt", FileMode.CreateNew, FileAccess.Write);
            // StreamWriter sw = new StreamWriter(file);
            try
            {
                EFilingDALP dalP = new EFilingDALP(strTaxPayer, strYA, strTaxAgent);
                DataSet dsData = dalP.GetFormDataP(strPageIndex);
                dalP.CloseConn();
                int intcount = 0;
                Boolean boolLocal = true;
                string strComparator;
                Boolean boolNoRecord = false;

                foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
                {

                    // sw.WriteLine(inpElement.name);

                    switch (strPageIndex)
                    {
                        #region "Page1"
                        case "P2008Page1":
                            switch (inpElement.name)
                            {
                                case "ctl00$ContentPlaceHolder2$txtF00005":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[2].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00006":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00007":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[4].ToString();
                                    break;

                                case "ctl00$ContentPlaceHolder2$txtF00089":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[6].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00090":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[7].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00091":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00092":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00093":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                    break;

                                case "ctl00$ContentPlaceHolder2$btn_daftar": //Alamat berdaftar
                                //    if (intcount == 0)
                                //    {
                                //        if (SelectState(dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[11].ToString()) != "SILA PILIH NEGERI")
                                //        {
                                //            inpElement.@checked = true;
                                //            FireInpElementEvent(inpElement, "OnClick");
                                //            boolLocal = true;
                                //        }
                                //        intcount++;
                                //    }
                                //    else
                                //    {
                                //        if (SelectState(dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[11].ToString()) == "SILA PILIH NEGERI")
                                //        {
                                //            inpElement.@checked = true;
                                //            FireInpElementEvent(inpElement, "OnClick");
                                //            boolLocal = false;
                                //        }
                                //        intcount = 0;
                                //    }
                                    break;

                                case "ctl00$ContentPlaceHolder2$ddlF00094":
                                    if (!boolLocal)
                                        inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[11].ToString();
                                    break;


                                case "ctl00$ContentPlaceHolder2$txtF00095":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[12].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00096":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[13].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00097":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[14].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00098":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[15].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00099":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[16].ToString();
                                    break;

                                case "ctl00$ContentPlaceHolder2$btn_daftar1": // Alamat perniagaan utama
                                    //if (intcount == 0)
                                    //{
                                    //    if (SelectState(dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[17].ToString()) != "SILA PILIH NEGERI")
                                    //    {
                                    //        inpElement.@checked = true;
                                    //        FireInpElementEvent(inpElement, "OnClick");
                                    //        boolLocal = true;
                                    //    }
                                    //    intcount++;
                                    //}
                                    //else
                                    //{
                                    //    if (SelectState(dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[17].ToString()) == "SILA PILIH NEGERI")
                                    //    {
                                    //        inpElement.@checked = true;
                                    //        FireInpElementEvent(inpElement, "OnClick");
                                    //        boolLocal = false;
                                    //    }
                                    //    intcount = 0;
                                    //}
                                    break;
                                case "ctl00$ContentPlaceHolder2$ddlF00100":

                                    if (!boolLocal)
                                        inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[17].ToString();
                                    break;


                                case "ctl00$ContentPlaceHolder2$txtF00101":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[18].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00102":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[19].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00103":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[20].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00104":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[21].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00105":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[22].ToString();
                                    break;

                                case "ctl00$ContentPlaceHolder2$btn_daftar2": //Alamat surat-menyurat
                                    //if (intcount == 0)
                                    //{
                                    //    if (SelectState(dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[23].ToString()) != "SILA PILIH NEGERI")
                                    //    {
                                    //        inpElement.@checked = true;
                                    //        FireInpElementEvent(inpElement, "OnClick");
                                    //        boolLocal = true;
                                    //    }
                                    //    intcount++;
                                    //}
                                    //else
                                    //{
                                    //    if (SelectState(dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[23].ToString()) == "SILA PILIH NEGERI")
                                    //    {
                                    //        inpElement.@checked = true;
                                    //        FireInpElementEvent(inpElement, "OnClick");
                                    //        boolLocal = false;
                                    //    }
                                    //    intcount = 0;
                                    //}
                                    break;

                                case "ctl00$ContentPlaceHolder2$ddlF00106":

                                    if (!boolLocal)
                                        inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[23].ToString();
                                    break;

                                case "ctl00$ContentPlaceHolder2$txtF00107":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[24].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00108":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[25].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00109":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[26].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00110":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[27].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00111":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[28].ToString();
                                    break;

                                case "cctl00$ContentPlaceHolder2$btn_surat": //Alamat tempat akaun disimpan
                                    if (intcount == 0)
                                    {
                                        if (SelectState(dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[29].ToString()) != "SILA PILIH NEGERI")
                                        {
                                            inpElement.@checked = true;
                                            FireInpElementEvent(inpElement, "OnClick");
                                            boolLocal = true;
                                        }
                                        intcount++;
                                    }
                                    else
                                    {
                                        if (SelectState(dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[29].ToString()) == "SILA PILIH NEGERI")
                                        {
                                            inpElement.@checked = true;
                                            FireInpElementEvent(inpElement, "OnClick");
                                            boolLocal = false;
                                        }
                                        intcount = 0;
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder2$ddlF00112":
                                    if (!boolLocal)
                                        inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[29].ToString();
                                    break;


                                case "ctl00$ContentPlaceHolder2$txtF00113":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[30].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00114":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[31].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00116":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[32].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00117":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[33].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00118":
                                    inpElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[34].ToString();
                                    break;

                            }
                            break;
                        #endregion
                        #region "Page2"
                        case "P2008Page2":
                            if (dsData.Tables["P2_INPUTT_TAX_BUSINESS"].Rows.Count > 0)
                            {

                                if ((dsData.Tables["P2_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[0].ToString() == "Yes") &&
                                    (dsData.Tables["P2_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[1].ToString() == "0"))
                                {
                                    switch (inpElement.name)
                                    {
                                        case "ctl00$ContentPlaceHolder2$txtF00009": //A1
                                            inpElement.value = dsData.Tables["P2_SELECT_TAXP"].Rows[0].ItemArray[0].ToString();
                                            break;
                                        case "ctl00$ContentPlaceHolder2$txtF00012": //A2
                                            inpElement.value = dsData.Tables["P2_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[2].ToString();
                                            break;
                                        case "ctl00$ContentPlaceHolder2$txtF00015": //A3
                                            inpElement.value = dsData.Tables["P2_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[3].ToString();
                                            break;
                                        case "ctl00$ContentPlaceHolder2$txtF00017"://A4
                                            inpElement.value = dsData.Tables["P2_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[4].ToString();
                                            break;
                                        case "ctl00$ContentPlaceHolder2$txtF00019"://A5
                                            inpElement.value = dsData.Tables["P2_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[5].ToString();
                                            break;

                                        case "ctl00$ContentPlaceHolder2$txtF00021"://A6
                                            inpElement.value = dsData.Tables["P2_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[6].ToString();
                                            break;
                                        case "ctl00$ContentPlaceHolder2$txtF00023"://A7
                                            inpElement.value = dsData.Tables["P2_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[7].ToString();
                                            break;
                                    }
                                }
                                else
                                {
                                    switch (inpElement.name)
                                    {

                                        case "ctl00$ContentPlaceHolder2$txtF00010": //A1
                                            inpElement.value = dsData.Tables["P2_SELECT_TAXP"].Rows[0].ItemArray[0].ToString();
                                            break;
                                        case "ctl00$ContentPlaceHolder2$txtF00014": //A2
                                            inpElement.value = dsData.Tables["P2_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[2].ToString();
                                            break;
                                        case "ctl00$ContentPlaceHolder2$txtF00016": //A3
                                            inpElement.value = dsData.Tables["P2_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[3].ToString();
                                            break;
                                        case "ctl00$ContentPlaceHolder2$txtF00018"://A4
                                            inpElement.value = dsData.Tables["P2_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[4].ToString();
                                            break;
                                        case "ctl00$ContentPlaceHolder2$txtF00020"://A5
                                            inpElement.value = dsData.Tables["P2_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[5].ToString();
                                            break;

                                    }
                                }
                            }


                            if (dsData.Tables["P2_INPUTT_TAX_BUSINESS1"].Rows.Count > 0)
                            {

                                if ((dsData.Tables["P2_INPUTT_TAX_BUSINESS1"].Rows[0].ItemArray[7].ToString() == "0"))
                                {
                                    switch (inpElement.name)
                                    {
                                        case "ctl00$ContentPlaceHolder2$txtF00025": //A8
                                            inpElement.value = dsData.Tables["P2_SELECT_TAXP1"].Rows[0].ItemArray[0].ToString();
                                            break;

                                        case "ctl00$ContentPlaceHolder2$txtF00027": //A9
                                            inpElement.value = dsData.Tables["P2_INPUTT_TAX_BUSINESS1"].Rows[0].ItemArray[0].ToString();
                                            break;

                                        case "ctl00$ContentPlaceHolder2$txtF00030": //A10
                                            inpElement.value = dsData.Tables["P2_INPUTT_TAX_BUSINESS1"].Rows[0].ItemArray[1].ToString();
                                            break;

                                        case "ctl00$ContentPlaceHolder2$txtF00033": //A11
                                            inpElement.value = dsData.Tables["P2_INPUTT_TAX_BUSINESS1"].Rows[0].ItemArray[2].ToString();
                                            break;

                                        case "ctl00$ContentPlaceHolder2$txtF00035": //A12
                                            inpElement.value = dsData.Tables["P2_INPUTT_TAX_BUSINESS1"].Rows[0].ItemArray[3].ToString();
                                            break;

                                        case "ctl00$ContentPlaceHolder2$txtF00037": //A13
                                            inpElement.value = dsData.Tables["P2_INPUTT_TAX_BUSINESS1"].Rows[0].ItemArray[4].ToString();
                                            break;

                                        case "ctl00$ContentPlaceHolder2$txtF00039": //A14
                                            inpElement.value = dsData.Tables["P2_INPUTT_TAX_BUSINESS1"].Rows[0].ItemArray[5].ToString();
                                            break;


                                    }
                                }
                                else
                                {
                                    switch (inpElement.name)
                                    {

                                        case "ctl00$ContentPlaceHolder2$txtF00026": //A8
                                            inpElement.value = dsData.Tables["P2_SELECT_TAXP1"].Rows[0].ItemArray[0].ToString();
                                            break;

                                        case "ctl00$ContentPlaceHolder2$txtF00028": //A9
                                            inpElement.value = dsData.Tables["P2_INPUTT_TAX_BUSINESS1"].Rows[0].ItemArray[0].ToString();
                                            break;

                                        case "ctl00$ContentPlaceHolder2$txtF00032": //A10
                                            inpElement.value = dsData.Tables["P2_INPUTT_TAX_BUSINESS1"].Rows[0].ItemArray[1].ToString();
                                            break;

                                        case "ctl00$ContentPlaceHolder2$txtF00034": //A11
                                            inpElement.value = dsData.Tables["P2_INPUTT_TAX_BUSINESS1"].Rows[0].ItemArray[2].ToString();
                                            break;

                                        case "ctl00$ContentPlaceHolder2$txtF00036": //A12
                                            inpElement.value = dsData.Tables["P2_INPUTT_TAX_BUSINESS1"].Rows[0].ItemArray[3].ToString();
                                            break;



                                    }
                                }
                            }

                            break;
                        #endregion
                        #region "Page3"
                        case "P2008Page3":
                            //S3
                            if (dsData.Tables["P3_INPUTT_TAX_BUSINESS"].Rows.Count > 0)
                            {
                                if ((dsData.Tables["P3_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[7].ToString() == "0"))
                                {
                                    switch (inpElement.name)
                                    {
                                        case "ctl00$ContentPlaceHolder2$FormView1$A8_KongsiAddEmpty": //A8
                                            inpElement.value = dsData.Tables["P3_SELECT_TAXP"].Rows[0].ItemArray[0].ToString();
                                            break;
                                        case "ctl00$ContentPlaceHolder2$FormView1$A9_KongsiAddEmpty": //A9
                                            inpElement.value = dsData.Tables["P3_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[0].ToString();
                                            break;

                                        case "ctl00$ContentPlaceHolder2$FormView1$A10_KongsiAddEmpty": //A10
                                            inpElement.value = dsData.Tables["P3_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[1].ToString();
                                            break;

                                        case "ctl00$ContentPlaceHolder2$FormView1$A11_KongsiAddEmpty": //A11
                                            inpElement.value = dsData.Tables["P3_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[2].ToString();
                                            break;

                                        case "ctl00$ContentPlaceHolder2$FormView1$A12_KongsiAddEmpty": //A12
                                            inpElement.value = dsData.Tables["P3_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[3].ToString();
                                            break;

                                        case "ctl00$ContentPlaceHolder2$FormView1$A13_KongsiAddEmpty": //A13
                                            inpElement.value = dsData.Tables["P3_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[4].ToString();
                                            break;

                                        case "ctl00$ContentPlaceHolder2$FormView1$A14_KongsiAddEmpty": //A14
                                            inpElement.value = dsData.Tables["P3_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[5].ToString();
                                            break;

                                    }
                                }
                                // }
                                else
                                {
                                    if (dsData.Tables["P3_INPUTT_TAX_BUSINESS"].Rows.Count > 0)
                                    {
                                        switch (inpElement.name)
                                        {

                                            case "ctl00$ContentPlaceHolder2$FormView1$A8_PerintisAddEmpty": //A8
                                                inpElement.value = dsData.Tables["P3_SELECT_TAXP"].Rows[0].ItemArray[0].ToString();
                                                break;

                                            case "ctl00$ContentPlaceHolder2$FormView1$A9_PerintisAddEmpty": //A9
                                                inpElement.value = dsData.Tables["P3_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[0].ToString();
                                                break;

                                            case "ctl00$ContentPlaceHolder2$FormView1$A10_PerintisAddEmpty": //A10
                                                inpElement.value = dsData.Tables["P3_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[1].ToString();
                                                break;

                                            case "ctl00$ContentPlaceHolder2$FormView1$A11_PerintisAddEmpty": //A11
                                                inpElement.value = dsData.Tables["P3_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[2].ToString();
                                                break;

                                            case "ctl00$ContentPlaceHolder2$FormView1$A12_PerintisAddEmpty": //A12
                                                inpElement.value = dsData.Tables["P3_INPUTT_TAX_BUSINESS"].Rows[0].ItemArray[3].ToString();
                                                break;

                                        }
                                    }
                                }
                            }



                            //A8-A14
                            if (dsData.Tables["P3_INPUTT_TAX_BUSINESS1"].Rows.Count > 0)
                            {
                                if (dsData.Tables["P3_INPUTT_TAX_BUSINESS1"].Rows.Count != intIndex)
                                {
                                    if ((dsData.Tables["P3_INPUTT_TAX_BUSINESS1"].Rows[intIndex].ItemArray[7].ToString() == "0"))
                                    {
                                        switch (inpElement.name)
                                        {
                                            case "ctl00$ContentPlaceHolder2$FormView1$A8_KongsiAddGrid": //A8
                                                inpElement.value = dsData.Tables["P3_SELECT_TAXP1"].Rows[intIndex].ItemArray[0].ToString();
                                                break;


                                            case "ctl00$ContentPlaceHolder2$FormView1$A9_KongsiAddGrid": //A9
                                                inpElement.value = dsData.Tables["P3_INPUTT_TAX_BUSINESS1"].Rows[intIndex].ItemArray[0].ToString();
                                                break;

                                            case "ctl00$ContentPlaceHolder2$FormView1$A10_KongsiAddGrid": //A10
                                                inpElement.value = dsData.Tables["P3_INPUTT_TAX_BUSINESS1"].Rows[intIndex].ItemArray[1].ToString();
                                                break;

                                            case "ctl00$ContentPlaceHolder2$FormView1$A11_KongsiAddGrid": //A11
                                                inpElement.value = dsData.Tables["P3_INPUTT_TAX_BUSINESS1"].Rows[intIndex].ItemArray[2].ToString();
                                                break;

                                            case "ctl00$ContentPlaceHolder2$FormView1$A12_KongsiAddGrid": //A12
                                                inpElement.value = dsData.Tables["P3_INPUTT_TAX_BUSINESS1"].Rows[intIndex].ItemArray[3].ToString();
                                                break;

                                            case "ctl00$ContentPlaceHolder2$FormView1$A13_KongsiAddGrid": //A13
                                                inpElement.value = dsData.Tables["P3_INPUTT_TAX_BUSINESS1"].Rows[intIndex].ItemArray[4].ToString();
                                                break;

                                            case "ctl00$ContentPlaceHolder2$FormView1$A14_KongsiAddGrid": //A14
                                                inpElement.value = dsData.Tables["P3_INPUTT_TAX_BUSINESS1"].Rows[intIndex].ItemArray[5].ToString();
                                                break;

                                            case "ctl00$ContentPlaceHolder2$FormView1$btnAdd_Grid":
                                                inpElement.click();
                                                intIndex++;
                                                break;

                                        }
                                    }
                                    //}
                                    else
                                    {
                                        if (dsData.Tables["P3_INPUTT_TAX_BUSINESS1"].Rows.Count > 0)
                                        {
                                            switch (inpElement.name)
                                            {

                                                case "ctl00$ContentPlaceHolder2$FormView1$A8_PerintisAddGrid": //A8
                                                    inpElement.value = dsData.Tables["P3_SELECT_TAXP1"].Rows[intIndex].ItemArray[0].ToString();
                                                    break;

                                                case "ctl00$ContentPlaceHolder2$FormView1$A9_PerintisAddGrid": //A9
                                                    inpElement.value = dsData.Tables["P3_INPUTT_TAX_BUSINESS1"].Rows[intIndex].ItemArray[0].ToString();
                                                    break;

                                                case "ctl00$ContentPlaceHolder2$FormView1$A10_PerintisAddGrid": //A10
                                                    inpElement.value = dsData.Tables["P3_INPUTT_TAX_BUSINESS1"].Rows[intIndex].ItemArray[1].ToString();
                                                    break;

                                                case "ctl00$ContentPlaceHolder2$FormView1$A11_PerintisAddGrid": //A11
                                                    inpElement.value = dsData.Tables["P3_INPUTT_TAX_BUSINESS1"].Rows[intIndex].ItemArray[2].ToString();
                                                    break;

                                                case "ctl00$ContentPlaceHolder2$FormView1$A12_PerintisAddGrid": //A12
                                                    inpElement.value = dsData.Tables["P3_INPUTT_TAX_BUSINESS1"].Rows[intIndex].ItemArray[3].ToString();
                                                    break;

                                                case "ctl00$ContentPlaceHolder2$FormView1$btnAdd_Grid":
                                                    inpElement.click();
                                                    intIndex++;
                                                    break;

                                            }
                                        }
                                    }
                                }
                            }


                            break;


                        #endregion
                        #region "Page4"
                        case "P2008Page4":
                            if (dsData.Tables["P3_PARTNERSHIP_INCOME"].Rows.Count > 0)
                            {
                                switch (inpElement.name)
                                {
                                    case "ctl00$ContentPlaceHolder2$txtF00047"://C1
                                        inpElement.value = dsData.Tables["P3_PARTNERSHIP_INCOME"].Rows[0].ItemArray[0].ToString();
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00048": //C2
                                        inpElement.value = dsData.Tables["P3_PARTNERSHIP_INCOME"].Rows[0].ItemArray[1].ToString();
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00049": //C3
                                        inpElement.value = dsData.Tables["P3_PARTNERSHIP_INCOME"].Rows[0].ItemArray[2].ToString();
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00050"://C4
                                        inpElement.value = dsData.Tables["P3_PARTNERSHIP_INCOME"].Rows[0].ItemArray[3].ToString();
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00051"://C3_2
                                        inpElement.value = dsData.Tables["P3_PARTNERSHIP_INCOME"].Rows[0].ItemArray[4].ToString();
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00246": //C3_3
                                        inpElement.value = dsData.Tables["P3_PARTNERSHIP_INCOME"].Rows[0].ItemArray[5].ToString();
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00247": //C3_4
                                        inpElement.value = dsData.Tables["P3_PARTNERSHIP_INCOME"].Rows[0].ItemArray[6].ToString();
                                        break;

                                }

                            }


                            if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 0)
                            {
                                switch (inpElement.name)
                                {

                                    case "ctl00$ContentPlaceHolder2$txtF00367": //K1_1
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[0].ItemArray[0].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00368"://K1_2
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[0].ItemArray[1].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00369"://K1_3
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[0].ItemArray[2].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00370"://K1_4
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[0].ItemArray[3].ToString();
                                        break;

                                }
                            }

                            if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 1)
                            {
                                switch (inpElement.name)
                                {
                                    case "ctl00$ContentPlaceHolder2$txtF00371"://K2_1
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[1].ItemArray[0].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00372"://K2_2
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[1].ItemArray[1].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00373"://K2_3
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[1].ItemArray[2].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00374"://K2_4
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[1].ItemArray[3].ToString();
                                        break;
                                }
                            }

                            if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 2)
                            {
                                switch (inpElement.name)
                                {
                                    case "ctl00$ContentPlaceHolder2$txtF00371_1"://K3_1
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[2].ItemArray[0].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00372_1"://K3_2
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[2].ItemArray[1].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00373_1"://K3_3
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[2].ItemArray[2].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00374_1"://K3_4
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[2].ItemArray[3].ToString();
                                        break;
                                }
                            }
                            if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 3)
                            {
                                switch (inpElement.name)
                                {

                                    case "ctl00$ContentPlaceHolder2$txtF00371_2"://K4_1
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[3].ItemArray[0].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00372_2"://K4_2
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[3].ItemArray[1].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00373_2"://K4_3
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[3].ItemArray[2].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00374_2"://K4_4
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[3].ItemArray[3].ToString();
                                        break;
                                }
                            }

                            if (dsData.Tables["P3_PRECEDING_YEAR"].Rows.Count > 4)
                            {
                                switch (inpElement.name)
                                {
                                    case "ctl00$ContentPlaceHolder2$txtF00371_3"://K5_1
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[4].ItemArray[0].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00372_3"://K5_2
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[4].ItemArray[1].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00373_3"://K5_3
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[4].ItemArray[2].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00374_3"://K5_4
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR"].Rows[4].ItemArray[3].ToString();
                                        break;

                                }
                            }

                            if (dsData.Tables["P3_PARTNERSHIP_INCOME1"].Rows.Count > 0)
                            {
                                switch (inpElement.name)
                                {

                                    case "ctl00$ContentPlaceHolder2$txtF00041": //B1
                                        inpElement.value = dsData.Tables["P3_PARTNERSHIP_INCOME1"].Rows[0].ItemArray[0].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00042":
                                        inpElement.value = dsData.Tables["P3_PARTNERSHIP_INCOME1"].Rows[0].ItemArray[1].ToString();
                                        break;

                                }
                            }

                            break;

                        #endregion
                        #region "Page5"
                        case "P2008Page5":


                            if (dsData.Tables["P4_PARTNERSHIP_INCOME"].Rows.Count > 0)
                            {
                                switch (inpElement.name)
                                {

                                    case "ctl00$ContentPlaceHolder2$txtF00052": //D1
                                        inpElement.value = dsData.Tables["P4_PARTNERSHIP_INCOME"].Rows[0].ItemArray[0].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00054": //D3
                                        inpElement.value = dsData.Tables["P4_PARTNERSHIP_INCOME"].Rows[0].ItemArray[1].ToString();
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00055": //D4
                                        inpElement.value = dsData.Tables["P4_PARTNERSHIP_INCOME"].Rows[0].ItemArray[2].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00056": //D5
                                        inpElement.value = dsData.Tables["P4_PARTNERSHIP_INCOME"].Rows[0].ItemArray[3].ToString();
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00059": //D6
                                        inpElement.value = dsData.Tables["P4_PARTNERSHIP_INCOME"].Rows[0].ItemArray[4].ToString();
                                        break;

                                }
                                FireInpElementEvent(inpElement, "OnBlur");
                            }


                            if (dsData.Tables["P4_P_OTHER_CLAIMS"].Rows.Count > 0)
                            {
                                switch (inpElement.name)
                                {

                                    case "ctl00$ContentPlaceHolder2$txtF00060": //E1
                                        if (dsData.Tables["P4_P_OTHER_CLAIMS"].Rows.Count > 0)
                                        {
                                            inpElement.value = dsData.Tables["P4_P_OTHER_CLAIMS"].Rows[0].ItemArray[0].ToString();
                                        }
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00061": //E1
                                        if (dsData.Tables["P4_P_OTHER_CLAIMS"].Rows.Count > 0)
                                        {
                                            inpElement.value = dsData.Tables["P4_P_OTHER_CLAIMS"].Rows[0].ItemArray[1].ToString();
                                        }
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00062": //E2
                                        if (dsData.Tables["P4_P_OTHER_CLAIMS"].Rows.Count > 1)
                                        {
                                            inpElement.value = dsData.Tables["P4_P_OTHER_CLAIMS"].Rows[1].ItemArray[0].ToString();
                                        }
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00063": //E2
                                        if (dsData.Tables["P4_P_OTHER_CLAIMS"].Rows.Count > 1)
                                        {
                                            inpElement.value = dsData.Tables["P4_P_OTHER_CLAIMS"].Rows[1].ItemArray[1].ToString();
                                        }
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00064": //E3
                                        if (dsData.Tables["P4_P_OTHER_CLAIMS"].Rows.Count > 2)
                                        {
                                            inpElement.value = dsData.Tables["P4_P_OTHER_CLAIMS"].Rows[2].ItemArray[0].ToString();
                                        }
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00065": //E3
                                        if (dsData.Tables["P4_P_OTHER_CLAIMS"].Rows.Count > 2)
                                        {
                                            inpElement.value = dsData.Tables["P4_P_OTHER_CLAIMS"].Rows[2].ItemArray[1].ToString();
                                        }
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00066": //E4
                                        if (dsData.Tables["P4_P_OTHER_CLAIMS"].Rows.Count > 3)
                                        {
                                            inpElement.value = dsData.Tables["P4_P_OTHER_CLAIMS"].Rows[3].ItemArray[0].ToString();
                                        }
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00067": //E4
                                        inpElement.value = dsData.Tables["P4_P_OTHER_CLAIMS"].Rows[3].ItemArray[1].ToString();
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00068": //E5
                                        if (dsData.Tables["P4_P_OTHER_CLAIMS"].Rows.Count > 4)
                                        {
                                            inpElement.value = dsData.Tables["P4_P_OTHER_CLAIMS"].Rows[4].ItemArray[0].ToString();
                                        }
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00069": //E5
                                        if (dsData.Tables["P4_P_OTHER_CLAIMS"].Rows.Count > 4)
                                        {
                                            inpElement.value = dsData.Tables["P4_P_OTHER_CLAIMS"].Rows[4].ItemArray[1].ToString();
                                        }
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00070": //E6
                                        if (dsData.Tables["P4_P_OTHER_CLAIMS"].Rows.Count > 5)
                                        {
                                            inpElement.value = dsData.Tables["P4_P_OTHER_CLAIMS"].Rows[5].ItemArray[0].ToString();
                                        }
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00071": //E6
                                        if (dsData.Tables["P4_P_OTHER_CLAIMS"].Rows.Count > 5)
                                        {
                                            inpElement.value = dsData.Tables["P4_P_OTHER_CLAIMS"].Rows[5].ItemArray[1].ToString();
                                        }
                                        break;


                                    case "ctl00$ContentPlaceHolder2$txtF00072": //E7
                                        if (dsData.Tables["P4_P_OTHER_CLAIMS"].Rows.Count > 6)
                                        {
                                            inpElement.value = dsData.Tables["P4_P_OTHER_CLAIMS"].Rows[6].ItemArray[0].ToString();
                                        }
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00073": //E7
                                        if (dsData.Tables["P4_P_OTHER_CLAIMS"].Rows.Count > 6)
                                        {
                                            inpElement.value = dsData.Tables["P4_P_OTHER_CLAIMS"].Rows[6].ItemArray[1].ToString();
                                        }
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00074": //E8
                                        if (dsData.Tables["P4_P_OTHER_CLAIMS"].Rows.Count > 7)
                                        {
                                            inpElement.value = dsData.Tables["P4_P_OTHER_CLAIMS"].Rows[7].ItemArray[0].ToString();
                                        }
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00075": //E8
                                        if (dsData.Tables["P4_P_OTHER_CLAIMS"].Rows.Count > 7)
                                        {
                                            inpElement.value = dsData.Tables["P4_P_OTHER_CLAIMS"].Rows[7].ItemArray[1].ToString();
                                        }
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00076": //E9
                                        if (dsData.Tables["P4_P_OTHER_CLAIMS"].Rows.Count > 8)
                                        {
                                            inpElement.value = dsData.Tables["P4_P_OTHER_CLAIMS"].Rows[8].ItemArray[0].ToString();
                                        }
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00077": //E9
                                        if (dsData.Tables["P4_P_OTHER_CLAIMS"].Rows.Count > 8)
                                        {
                                            inpElement.value = dsData.Tables["P4_P_OTHER_CLAIMS"].Rows[8].ItemArray[1].ToString();
                                        }
                                        break;


                                    case "ctl00$ContentPlaceHolder2$txtF00078": //E10
                                        if (dsData.Tables["P4_P_OTHER_CLAIMS"].Rows.Count > 9)
                                        {
                                            inpElement.value = dsData.Tables["P4_P_OTHER_CLAIMS"].Rows[9].ItemArray[0].ToString();
                                        }
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00079": //E10
                                        if (dsData.Tables["P4_P_OTHER_CLAIMS"].Rows.Count > 9)
                                        {
                                            inpElement.value = dsData.Tables["P4_P_OTHER_CLAIMS"].Rows[9].ItemArray[1].ToString();
                                        }
                                        break;


                                }
                                FireInpElementEvent(inpElement, "OnBlur");

                            }


                            break;
                        #endregion
                        #region "Page6"
                        case "P2008Page6":
                            if (dsData.Tables["P5_PARTNERSHIP_INCOME"].Rows.Count > 0)
                            {
                                switch (inpElement.name)
                                {

                                    case "ctl00$ContentPlaceHolder2$txtF00081": //F1
                                        inpElement.value = dsData.Tables["P5_PARTNERSHIP_INCOME"].Rows[0].ItemArray[0].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00082": //F1_1
                                        inpElement.value = dsData.Tables["P5_PARTNERSHIP_INCOME"].Rows[0].ItemArray[1].ToString();
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00083": //F2
                                        inpElement.value = dsData.Tables["P5_PARTNERSHIP_INCOME"].Rows[0].ItemArray[2].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00084": //F2_1
                                        inpElement.value = dsData.Tables["P5_PARTNERSHIP_INCOME"].Rows[0].ItemArray[3].ToString();
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00085": //F3
                                        inpElement.value = dsData.Tables["P5_PARTNERSHIP_INCOME"].Rows[0].ItemArray[4].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00086": //F3_1
                                        inpElement.value = dsData.Tables["P5_PARTNERSHIP_INCOME"].Rows[0].ItemArray[5].ToString();
                                        break;


                                    case "ctl00$ContentPlaceHolder2$txtF00087": //F4
                                        inpElement.value = dsData.Tables["P5_PARTNERSHIP_INCOME"].Rows[0].ItemArray[6].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00088": //F4_1
                                        inpElement.value = dsData.Tables["P5_PARTNERSHIP_INCOME"].Rows[0].ItemArray[7].ToString();
                                        break;

                                }
                            }


                            if (dsData.Tables["P5_PARTNERSHIP_INCOME1"].Rows.Count > 0)
                            {
                                switch (inpElement.name)
                                {
                                    case "ctl00$ContentPlaceHolder2$ddlF00375": //M1
                                        inpElement.value = dsData.Tables["P5_PARTNERSHIP_INCOME1"].Rows[0].ItemArray[0].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00376": //M1_1
                                        inpElement.value = dsData.Tables["P5_PARTNERSHIP_INCOME1"].Rows[0].ItemArray[1].ToString();
                                        break;


                                    case "ctl00$ContentPlaceHolder2$txtF00377": //M2
                                        inpElement.value = dsData.Tables["P5_PARTNERSHIP_INCOME1"].Rows[0].ItemArray[2].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00379": //M2_1
                                        inpElement.value = dsData.Tables["P5_PARTNERSHIP_INCOME1"].Rows[0].ItemArray[3].ToString();
                                        break;
                                }
                            }

                            break;
                        #endregion
                        #region "Page7"
                        case "P2008Page7":


                            //if (dsData.Tables["P6_TAXP_PARTNERS"].Rows.Count > 0)
                            //{
                            //    switch (inpElement.name)
                            //    {
                            //        case"ctl00_ContentPlaceHolder2_GridView1_ctl02_Nama"://PART H a
                            //            inpElement.value = dsData.Tables["P6_TAXP_PARTNERS"].Rows[0].ItemArray[1].ToString();
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlEmpty_Negara"://PART H b
                            //            inpElement.value = dsData.Tables["P6_TAXP_PARTNERS"].Rows[0].ItemArray[2].ToString();
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_No_kp": //PART H c
                            //            inpElement.value = dsData.Tables["P6_TAXP_PARTNERS"].Rows[0].ItemArray[3].ToString();
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_No_rujukan": //PART H d
                            //            inpElement.value = dsData.Tables["P6_TAXP_PARTNERS"].Rows[0].ItemArray[4].ToString();
                            //            break;

                            //        case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlJ_Fail": //PART H d
                            //            inpElement.value = dsData.Tables["P6_TAXP_PARTNERS"].Rows[0].ItemArray[0].ToString();
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_tarikh_masuk": //PART H e
                            //            inpElement.value = dsData.Tables["P6_TAXP_PARTNERS"].Rows[0].ItemArray[5].ToString();
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_tarikh_keluar": //PART H e
                            //            inpElement.value = dsData.Tables["P6_TAXP_PARTNERS"].Rows[0].ItemArray[6].ToString();
                            //            break;

                            //        case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_bhgn_ahli": //PART H f
                            //            inpElement.value = dsData.Tables["P6_TAXP_PARTNERS"].Rows[0].ItemArray[7].ToString();
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_manfaat1": //PART H fiia
                            //            inpElement.value = dsData.Tables["P6_TAXP_PARTNERS"].Rows[0].ItemArray[8].ToString();
                            //            break;

                            //        case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_manfaat2": //PART H fiib
                            //            inpElement.value = dsData.Tables["P6_TAXP_PARTNERS"].Rows[0].ItemArray[9].ToString();
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_manfaat3": //PART H fiic
                            //            inpElement.value = dsData.Tables["P6_TAXP_PARTNERS"].Rows[0].ItemArray[10].ToString();
                            //            break;

                            //    }
                            //}



                            break;
                        #endregion
                        #region "Page8"
                        case "P2008Page8":
                            if (dsData.Tables["P7_TAXP_PSOURCE"].Rows.Count > 0)
                            {
                                switch (inpElement.name)
                                {
                                    case "ctl00$ContentPlaceHolder2$txtF00161": //J1
                                        inpElement.value = dsData.Tables["P7_TAXP_PSOURCE"].Rows[0].ItemArray[0].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00162": //J2
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS"].Rows[0].ItemArray[0].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00163": //J3
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS"].Rows[0].ItemArray[1].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00164": //J4
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS"].Rows[0].ItemArray[2].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00165": //J5
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS"].Rows[0].ItemArray[3].ToString();
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00169": //J8
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS"].Rows[0].ItemArray[5].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00170": //J9
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS"].Rows[0].ItemArray[6].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00171": //J10
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS"].Rows[0].ItemArray[7].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00172": //J11
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS"].Rows[0].ItemArray[8].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00173": //J12
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS"].Rows[0].ItemArray[9].ToString();
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00175": //J14
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS"].Rows[0].ItemArray[10].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00176": //J15
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS"].Rows[0].ItemArray[11].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00177": //J16
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS"].Rows[0].ItemArray[12].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00178": //J17
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS"].Rows[0].ItemArray[13].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00179": //J18
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS"].Rows[0].ItemArray[14].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00180": //J19
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS"].Rows[0].ItemArray[15].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00181": //J20
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS"].Rows[0].ItemArray[16].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00364": //J21
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS"].Rows[0].ItemArray[17].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00365": //J22
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS"].Rows[0].ItemArray[18].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00182": //J23
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS"].Rows[0].ItemArray[19].ToString();
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00185": //J25
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS"].Rows[0].ItemArray[20].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00186": //J26
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS"].Rows[0].ItemArray[21].ToString();
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00187": //J27
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS1"].Rows[0].ItemArray[0].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00188": //J28
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS1"].Rows[0].ItemArray[1].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00189": //J29
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS1"].Rows[0].ItemArray[2].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00190": //J30
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS1"].Rows[0].ItemArray[3].ToString();
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00192": //J32
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS1"].Rows[0].ItemArray[4].ToString();
                                        break;

                                    case "ctl00$ContentPlaceHolder2$txtF00193": //J33
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS1"].Rows[0].ItemArray[5].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00194": //J34
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS1"].Rows[0].ItemArray[6].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00195": //J35
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS1"].Rows[0].ItemArray[7].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00196": //J36
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS1"].Rows[0].ItemArray[8].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00197": //J37
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS1"].Rows[0].ItemArray[9].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00198": //J38
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS1"].Rows[0].ItemArray[10].ToString();
                                        break;


                                    case "ctl00$ContentPlaceHolder2$txtF00201": //J41
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS1"].Rows[0].ItemArray[11].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00202": //J42
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS1"].Rows[0].ItemArray[12].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00203": //J43
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P7_P_PROFIT_AND_LOSS1"].Rows[0].ItemArray[13].ToString()) + double.Parse(dsData.Tables["P7_P_PROFIT_AND_LOSS1"].Rows[0].ItemArray[14].ToString()) + double.Parse(dsData.Tables["P7_P_PROFIT_AND_LOSS1"].Rows[0].ItemArray[15].ToString()));
                                        break;


                                    case "ctl00$ContentPlaceHolder2$txtF00366": //J45
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS1"].Rows[0].ItemArray[16].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00205": //J46
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS1"].Rows[0].ItemArray[17].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00208": //J47
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS1"].Rows[0].ItemArray[18].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00209": //J48
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS1"].Rows[0].ItemArray[19].ToString();
                                        break;
                                    case "ctl00$ContentPlaceHolder2$txtF00210": //J49
                                        inpElement.value = dsData.Tables["P7_P_PROFIT_AND_LOSS1"].Rows[0].ItemArray[20].ToString();
                                        break;

                                }
                                FireInpElementEvent(inpElement, "OnBlur");
                            }
                            //else
                            //{
                            //    switch (inpElement.name)
                            //    {
                            //        case "ctl00$ContentPlaceHolder2$txtF00161": //J1
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00162": //J2
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00163": //J3
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00164": //J4
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00165": //J5
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00169": //J8
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00170": //J9
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00171": //J10
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00172": //J11
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00173": //J12
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00175": //J14
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00176": //J15
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00177": //J16
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00178": //J17
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00179": //J18
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00180": //J19
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00181": //J20
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00364": //J21
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00365": //J22
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00182": //J23
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00185": //J25
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00186": //J26
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00187": //J27
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00188": //J28
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00189": //J29
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00190": //J30
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00192": //J32
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00193": //J33
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00194": //J34
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00195": //J35
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00196": //J36
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00197": //J37
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00198": //J38
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00201": //J41
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00202": //J42
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00203": //J43
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00366": //J45
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00205": //J46
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00208": //J47
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00209": //J48
                            //            inpElement.value = "";
                            //            break;
                            //        case "ctl00$ContentPlaceHolder2$txtF00210": //J49
                            //            inpElement.value = "";
                            //            break;
                            //    }

                            break;
                        #endregion
                        #region "Page9"
                        case "P2008Page9":
                            string[] arrTaxAgent = new string[3];
                            arrTaxAgent[0] = dsData.Tables["P8_FIRM"].Rows[0].ItemArray[0].ToString();
                            arrTaxAgent[1] = dsData.Tables["P8_FIRM"].Rows[0].ItemArray[1].ToString();
                            arrTaxAgent[2] = dsData.Tables["P8_FIRM"].Rows[0].ItemArray[2].ToString();
                            arrTaxAgent = TextSpliterAddress(arrTaxAgent, 40);
                            switch (inpElement.name)
                            {
                                case "ctl00$ContentPlaceHolder2$txtF00215":
                                    if (arrTaxAgent[0] != null)
                                    {
                                        inpElement.value = arrTaxAgent[0].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00216":
                                    if (arrTaxAgent[1] != null)
                                    {
                                        inpElement.value = arrTaxAgent[1].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00217":
                                    if (arrTaxAgent[2] != null)
                                    {
                                        inpElement.value = arrTaxAgent[2].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00218": //Postcode
                                    inpElement.value = dsData.Tables["P8_FIRM"].Rows[0].ItemArray[3].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00219"://city
                                    inpElement.value = dsData.Tables["P8_FIRM"].Rows[0].ItemArray[4].ToString();
                                    break;
                                //5 state
                                case "ctl00$ContentPlaceHolder2$txtF00221"://tel no
                                    inpElement.value = dsData.Tables["P8_FIRM"].Rows[0].ItemArray[6].ToString(); ;
                                    break;

                                case "ctl00$ContentPlaceHolder2$txtF00222":
                                    inpElement.value = dsData.Tables["P8_FIRM"].Rows[0].ItemArray[7].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder2$txtF00223"://email
                                    inpElement.value = dsData.Tables["P8_FIRM"].Rows[0].ItemArray[8].ToString();
                                    break;

                                case "ctl00$ContentPlaceHolder2$txtF00226":
                                    inpElement.value = this.strPosition;
                                    break;
                                //ctl00$ContentPlaceHolder2$txtF00224
                                //ctl00$ContentPlaceHolder2$txtF00226 jawatan


                            }
                            break;
                        #endregion

                    }

                }

                if (boolNoRecord)
                {
                    MessageBox.Show("No record found for current document.", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // sw.WriteLine();
                foreach (mshtml.HTMLSelectElement selElement in htmlDoc.getElementsByTagName("select"))
                {

                    // sw.WriteLine(selElement.name);
                    switch (strPageIndex)
                    {
                        #region "Page1"
                        case "P2008Page1":
                            switch (selElement.name)
                            {


                                case "ctl00$ContentPlaceHolder2$ddlF00008"://Ketetapan umum dipatuhi
                                    strComparator = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() == "0" ? selElement.value = "1" : selElement.value = "2";
                                    break;
                                case "ctl00$ContentPlaceHolder2$ddlF00378": //penyimpanan rekod
                                    strComparator = strRecKept == "True" ? selElement.value = "1" : selElement.value = "2";
                                    break;

                                case "ctl00$ContentPlaceHolder2$ddlF00094":
                                    selElement.value = SelectState(dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[11].ToString());
                                    break;
                                case "ctl00$ContentPlaceHolder2$ddlF00100":
                                    selElement.value = SelectState(dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[17].ToString());
                                    break;
                                case "ctl00$ContentPlaceHolder2$ddlF00106":
                                    selElement.value = SelectState(dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[23].ToString());
                                    break;
                                case "ctl00$ContentPlaceHolder2$ddlF00112":
                                    selElement.value = SelectState(dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[29].ToString());
                                    break;
                            }
                            break;
                        #endregion
                        #region "Page6"
                        case "P2008Page6":
                            if (dsData.Tables["P5_PARTNERSHIP_INCOME1"].Rows.Count > 0)
                            {
                                switch (selElement.name)
                                {


                                    //case "ctl00$ContentPlaceHolder2$ddlF00008"://Ketetapan umum dipatuhi
                                    //    strComparator = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() == "0" ? selElement.value = "1" : selElement.value = "2";
                                    //    break;
                                    case "ctl00$ContentPlaceHolder2$ddlF00375": //M1
                                        // inpElement.value = dsData.Tables["P5_PARTNERSHIP_INCOME1"].Rows[0].ItemArray[0].ToString();
                                        // If ds.Tables(0).Rows(0).Item(5).ToString = "1" Then
                                        //    strLine = "2"
                                        //ElseIf ds.Tables(0).Rows(0).Item(5).ToString = "0" Then
                                        //    strLine = "1"
                                        //End If
                                        if (dsData.Tables["P5_PARTNERSHIP_INCOME1"].Rows[0].ItemArray[0].ToString() == "1")
                                        {
                                            selElement.value = "1";

                                        }
                                        else  //(dsData.Tables["P5_PARTNERSHIP_INCOME1"].Rows[0].ItemArray[0].ToString() == "1")
                                        {
                                            selElement.value = "2";
                                        }
                                        FireSelElementEvent(selElement, "OnChange");
                                        // MessageBox.Show("in");
                                        // strComparator = dsData.Tables["P5_PARTNERSHIP_INCOME1"].Rows[0].ItemArray[0].ToString() == "0" ? selElement.value = "1" : selElement.value = "2";
                                        // strComparator = selElement.value == "0" ? selElement.value = "1" : selElement.value = "2";
                                        break;

                                }
                            }
                            break;
                        #endregion
                        #region "Page9"
                        case "P2008Page9":
                            switch (selElement.name)
                            {

                                case "ctl00$ContentPlaceHolder2$ddlF00220"://negeri
                                    selElement.value = SelectState(dsData.Tables["P8_FIRM"].Rows[0].ItemArray[5].ToString());
                                    break;
                            }

                            break;
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //finally
            //{
            //    sw.Close();
            //}

        }

        private void FireSelElementEvent(mshtml.HTMLSelectElement  selElement, string strEvent)
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

        //NGOHCS 2009
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

        private void FillTaxFormtoolStripButton_Click(object sender, EventArgs e)
        {
            SHDocVw.ShellWindows swTemp = new SHDocVw.ShellWindows();
            Boolean boolTargetFound = false;
            Boolean boolTargetReady = false;
            string strDocName = "";
            if (SelectedTaxPayertoolStripLabel.Text != "")
            {
                EFilingProcessGeneral dalGeneral = new EFilingProcessGeneral();
                try
                {
                    foreach (SHDocVw.InternetExplorer ieTemp in swTemp)
                    {
                        switch (strFormType)
                        {
                            case "C":case "R":
                                EFilingDAL dal = new EFilingDAL();
                                strDocName = dal.GetDocName(ieTemp.LocationURL.ToString().ToLower(), strYA);
                                break;
                            case "B":case "BE":case "M":
                                EFilingDALB dalB = new EFilingDALB();
                                //strDocName = dalB.GetDocName(dalGeneral.RefreshForm(ieTemp).ToLower(), strYA, strFormType);
                                strDocName = dalB.GetDocName(ieTemp.LocationURL.ToString().ToLower(), strYA, strFormType);
                                //strDocName = dalB.GetDocName(ieTemp.LocationURL.ToString().ToLower(), strYA, strFormType);
                            //strDocName = dalB.GetDocName(dalGeneral.RefreshForm(ieTemp).ToLower(), strYA, strFormType);
                                //MessageBox.Show(ieTemp.LocationURL.ToString());
                            //strDocName = dalB.GetDocName(ieTemp.LocationURL.ToString().ToLower(), strYA, strFormType);
                                //if (strDocName.Length > 0)
                                //{
                                //    if (strDocName.Substring(0, strFormType.Trim().Length) == strFormType)
                                //    {
                                //        if (ieTemp.ReadyState.Equals(SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE))
                                //        {
                                //            if (typeof(mshtml.HTMLDocumentClass).IsAssignableFrom(ieTemp.Document.GetType()))
                                //            {
                                //                mshtml.HTMLDocument htmlDoc2 = ieTemp.Document as mshtml.HTMLDocument;
                                //                strDocName = dalB.GetDocName(dalGeneral.RefreshForm(htmlDoc2).ToLower(), strYA, strFormType);
                                //            }
                                //            //else
                                //            //{
                                //            //    strDocName = "";
                                //            //}
                                //        }
                                //    }
                                //}
                                break;
                            case "P":
                                EFilingDALP dalP = new EFilingDALP();
                                //dalGeneral.RefreshForm(htmlDoc);
                                strDocName = dalP.GetDocName(ieTemp.LocationURL.ToString().ToLower(), strYA);
                                break;
                            //PANYW CP204
                            case "CP204":
                                EFilingDALCP204 dalCP204 = new EFilingDALCP204();
                                //dalGeneral.RefreshForm(htmlDoc);
                                strDocName = dalCP204.GetDocName(ieTemp.LocationURL.ToString().ToLower(), strYA);
                                break;
                            //PANYW CP204 END
                            case "CP204A":
                                EFilingDALCP204A dalCP204A = new EFilingDALCP204A();
                                strDocName = dalCP204A.GetDocName(ieTemp.LocationURL.ToString().ToLower(), strYA);
                                break;
                        }
                        if (strDocName.Length > 0)
                        {
                            if (strDocName.Substring(0, strFormType.Trim().Length) == strFormType)
                            {
                                boolTargetFound = true;
                                if (ieTemp.ReadyState.Equals(SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE))
                                {
                                    boolTargetReady = true;
                                    if (typeof(mshtml.HTMLDocumentClass).IsAssignableFrom(ieTemp.Document.GetType()))
                                    {
                                            mshtml.HTMLDocument htmlDoc = ieTemp.Document as mshtml.HTMLDocument;
                                            switch (strFormType)
                                            {
                                                case "C":
                                                    EFilingProcessC dalProcessC =
                                                        new EFilingProcessC(strTaxPayer, strYA, strAuditor, strRecKept, strTaxAgent);
                                                    dalProcessC.ProcessForm(htmlDoc, strDocName);
                                                    break;
                                                case "R":
                                                    EFilingProcessR dalProcessR =
                                                        new EFilingProcessR(strTaxPayer, strYA, strAuditor, strRecKept, strTaxAgent);
                                                    dalProcessR.ProcessForm(htmlDoc, strDocName);
                                                    break;
                                                case "B":
                                                    EFilingProcessB dalProcessB =
                                                        new EFilingProcessB(strTaxPayer, strYA, strTaxAgent, strRecKept);
                                                    dalProcessB.ProcessForm(htmlDoc, strDocName);
                                                    break;
                                                    //ProcessFormB(htmlDoc, strDocName);
                                                case "BE":
                                                    EFilingProcessBE dalProcessBE =
                                                        new EFilingProcessBE(strTaxPayer, strYA, strTaxAgent);
                                                    dalProcessBE.ProcessForm(htmlDoc, strDocName);
                                                    break;
                                                case "M":
                                                    EFilingProcessM dalProcessM =
                                                          new EFilingProcessM(strTaxPayer, strYA, strTaxAgent, strRecKept);
                                                    dalProcessM.ProcessForm(htmlDoc, strDocName);
                                                    break;
                                                case "P":
                                                    EFilingProcessP dalProcessP =
                                                          new EFilingProcessP(strTaxPayer, strYA, strTaxAgent, strRecKept, strPosition);
                                                    dalProcessP.SetIndex(intIndex);
                                                    dalProcessP.ProcessForm(htmlDoc, strDocName);
                                                    this.intIndex = dalProcessP.GetIndex();
                                                    break;
                                                //PANYW CP204
                                                case "CP204":
                                                    EFilingProcessCP204 dalProcessCP204 =
                                                       new EFilingProcessCP204(strTaxPayer, strYA, strAuditor, strRecKept, strTaxAgent);
                                                    dalProcessCP204.ProcessForm(htmlDoc, strDocName);
                                                    break;
                                                //PANYW CP204
                                                case "CP204A":
                                                    EFilingProcessCP204A dalProcessCP204A =
                                                       new EFilingProcessCP204A(strTaxPayer, strYA, strAuditor, strRecKept, strTaxAgent, strCP204AVersion);
                                                    dalProcessCP204A.ProcessForm(htmlDoc, strDocName);
                                                    break;
                                            }
                                    }
                                }
                            }
                        }
                    }
                    if (boolTargetFound == false)
                        MessageBox.Show("No relevant document is found for E-Filling (Form " + strFormType + ")!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else if (boolTargetFound == true && boolTargetReady == false)
                        MessageBox.Show("Document is not ready, please try again!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                { MessageBox.Show(ex.ToString()); }
            }
            else
            {
                MessageBox.Show("Please select a tax payer!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void SettingstoolStripButton_Click(object sender, EventArgs e)
        {
            SettingstoolStripButton.ShowDropDown();
            //frmEFileURL frmURL = new frmEFileURL();
            //frmURL.Show();
        }

        private void eHasilURLtoolStripButton_Click(object sender, EventArgs e)
        {
            EFilingPublic dalURL = new EFilingPublic();
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = dalURL.GetURL("Q0000PageX"); //"https://elatihan.hasil.org.my/TaxAgent/LogMasuk.aspx";    
            process.Start();
        }

        private void HowToUseURLtoolStripButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = "http://www.yglworld.com/taxcomdownloads/taxcomuserguide.html";
            process.Start();
        }

        private void selectTaxPayerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEFileSelect frmSelect = new frmEFileSelect(this);
            frmSelect.Show();
        }

        private void selectRKTRKSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (strFormType == "C")
            {
                if (SelectedTaxPayertoolStripLabel.Text.Length > 0)
                {
                    frmRKTRKS frmRKTRKS = new frmRKTRKS(strTaxPayer, strYA);
                    frmRKTRKS.Show();
                }
                else
                {
                    MessageBox.Show("Please select a tax payer!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (String.IsNullOrEmpty(strFormType))
            {
                MessageBox.Show("Please select a tax payer!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("RKT/ RKS not available in Form " + strFormType + "!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void selectHK3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (strFormType == "B")
            {
                if (SelectedTaxPayertoolStripLabel.Text.Length > 0)
                {
                    frmHK3 frmHK3 = new frmHK3(strTaxPayer, strYA, "B", "SELF");
                    frmHK3.Show();
                }
                else
                {
                    MessageBox.Show("Please select a tax payer!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (strFormType == "BE")
            {
                if (SelectedTaxPayertoolStripLabel.Text.Length > 0)
                {
                    frmHK3 frmHK3 = new frmHK3(strTaxPayer, strYA, "BE", "SELF");
                    frmHK3.Show();
                }
                else
                {
                    MessageBox.Show("Please select a tax payer!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (strFormType == "M")
            {
                if (SelectedTaxPayertoolStripLabel.Text.Length > 0)
                {
                    frmHK3 frmHK3 = new frmHK3(strTaxPayer, strYA, "M", "SELF");
                    frmHK3.Show();
                }
                else
                {
                    MessageBox.Show("Please select a tax payer!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (String.IsNullOrEmpty(strFormType))
            {
                MessageBox.Show("Please select a tax payer!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("HK-3 is not available in Form " + strFormType + "!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tsbtnSelect_ButtonClick(object sender, EventArgs e)
        {
            tsbtnSelect.ShowDropDown ();
        }

        private void Control_OnLoad(object sender, EventArgs e)
        {
            EFilingPublic dsn = new EFilingPublic();

            eBorangCAndRURLToolStripMenuItem.Enabled = false;
            eBorangBURLToolStripMenuItem.Enabled = false;
            eBorangBEURLToolStripMenuItem.Enabled = false;
            eBorangMURLToolStripMenuItem.Enabled = false;
            eBorangPURLToolStripMenuItem.Enabled = false;
            selectRKTRKSToolStripMenuItem.Enabled = false;
            selectHK3ToolStripMenuItem.Enabled = false;
            selectMaklumatAhliKongsiToolStripMenuItem.Enabled = false;

            if (dsn.isExist("TAXOFFICE", DSNType.System_DSN))
            {
                dsn.VersionUpgradeTaxOffice();
            }
            if (dsn.isExist("TAXSYSTEM", DSNType.System_DSN))
            { 
                eBorangCAndRURLToolStripMenuItem.Enabled = true;
                selectRKTRKSToolStripMenuItem.Enabled = true;
            }
            if (dsn.isExist("TAXCOM_B", DSNType.System_DSN))
            {
                eBorangBURLToolStripMenuItem.Enabled = true;
                eBorangBEURLToolStripMenuItem.Enabled = true;
                eBorangMURLToolStripMenuItem.Enabled = true;
                selectHK3ToolStripMenuItem.Enabled = true;
            }
            if (dsn.isExist("TAXCOM_P", DSNType.System_DSN))
            {   
                eBorangPURLToolStripMenuItem.Enabled = true;
                selectMaklumatAhliKongsiToolStripMenuItem.Enabled = true;
            }  

        }

        private void efilingTaxAgentLoginURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTaxAgentLogIn frmTAURL = new frmTaxAgentLogIn();
            frmTAURL.Show();
        }

        private void eBorangCAndRURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EFilingDAL dal = new EFilingDAL();
            frmEFileURL frmURL = new frmEFileURL();
            dal.VersionUpgrade();
            frmURL.Show();
        }

        private void eBorangBURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EFilingDALB dalB = new EFilingDALB();
            frmEFileURL frmURL = new frmEFileURL("B");
            dalB.VersionUpgrade();
            frmURL.Show();
        }

        private void eBorangBEURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EFilingDALB dalBE = new EFilingDALB();
            frmEFileURL frmURL = new frmEFileURL("BE");
            dalBE.VersionUpgrade();
            frmURL.Show();
        }

        private void eBorangMURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EFilingDALB dalM = new EFilingDALB();
            frmEFileURL frmURL = new frmEFileURL("M");
            dalM.VersionUpgrade();
            frmURL.Show();
        }

        private void eBorangPURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EFilingDALP dalP = new EFilingDALP();
            frmEFileURL frmURL = new frmEFileURL("P");
            dalP.VersionUpgrade();
            frmURL.Show();
        }

        private void selectMaklumatAhliKongsiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (strFormType == "P")
            {
                if (SelectedTaxPayertoolStripLabel.Text.Length > 0)
                {
                    frmMaklumatAhliKongsi frmMAK = new frmMaklumatAhliKongsi(strTaxPayer, strYA, "P");
                    frmMAK.Show();
                }
                else
                {
                    MessageBox.Show("Please select a tax payer!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (String.IsNullOrEmpty(strFormType))
            {
                MessageBox.Show("Please select a tax payer!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Maklumat Ahli Kongsi is not available in Form " + strFormType + "!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //PANYW CP204
        private void eBorangCP204URLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EFilingDALCP204 dalCP204 = new EFilingDALCP204();
            frmEFileURL frmURL = new frmEFileURL("CP204");
            dalCP204.VersionUpgrade();
            frmURL.Show();
        }

        //PANYW CP204

        private void eBorangCP204AURLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EFilingDALCP204A dalCP204A = new EFilingDALCP204A();
            frmEFileURL frmURL = new frmEFileURL("CP204A");
            dalCP204A.VersionUpgrade();
            frmURL.Show();
        }

        private void selectHK3HWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (strFormType == "B")
            {
                if (SelectedTaxPayertoolStripLabel.Text.Length > 0)
                {
                    frmHK3 frmHK3HW = new frmHK3(strTaxPayer, strYA, "B", "SPOUSE");
                    frmHK3HW.Show();
                }
                else
                {
                    MessageBox.Show("Please select a tax payer!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (strFormType == "BE")
            {
                if (SelectedTaxPayertoolStripLabel.Text.Length > 0)
                {
                    frmHK3 frmHK3HW = new frmHK3(strTaxPayer, strYA, "BE", "SPOUSE");
                    frmHK3HW.Show();
                }
                else
                {
                    MessageBox.Show("Please select a tax payer!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (strFormType == "M")
            {
                if (SelectedTaxPayertoolStripLabel.Text.Length > 0)
                {
                    frmHK3 frmHK3HW = new frmHK3(strTaxPayer, strYA, "M", "SPOUSE");
                    frmHK3HW.Show();
                }
                else
                {
                    MessageBox.Show("Please select a tax payer!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else if (String.IsNullOrEmpty(strFormType))
            {
                MessageBox.Show("Please select a tax payer!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("HK-3 is not available in Form " + strFormType + "!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //NGOHCS CP204A9
    }
}

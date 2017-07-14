using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace IEToolBar
{
    class EFilingProcessMaklumatAhliKongsi
    {
        Boolean boolFilled = false;
        int intIndex;
        string[] strData;
        string strYA = "";
        string ErrorLog = "";
        public EFilingProcessMaklumatAhliKongsi()
        {
        }

        public EFilingProcessMaklumatAhliKongsi(string[] strData, string strYA)
        {
            this.strData = new string[17];
            this.strData[0] = strData[0].ToString();
            this.strData[1] = strData[1].ToString();
            this.strData[2] = strData[2].ToString();
            this.strData[3] = strData[3].ToString();
            this.strData[4] = strData[4].ToString();
            this.strData[5] = strData[5].ToString();
            this.strData[6] = strData[6].ToString();
            this.strData[7] = strData[7].ToString();
            this.strData[8] = strData[8].ToString();
            this.strData[9] = strData[9].ToString();
            this.strData[10] = strData[10].ToString();
            this.strData[11] = strData[11].ToString();
            this.strData[12] = strData[12].ToString();
            this.strData[13] = strData[13].ToString();
            this.strData[14] = strData[14].ToString();
            this.strData[15] = strData[15].ToString();
            this.strData[16] = strData[16].ToString();
            this.strYA = strYA;
        }

        private bool isPrePartner()
        {
            bool boolIsPre = false;
            if (this.strData[16].Trim() == strData[4].Trim())
            {
                boolIsPre = true;
            }
            return boolIsPre;
        }

        public void ProcessDocument(mshtml.HTMLDocument htmlDoc)
        {
            switch (this.strYA)
            {
                case "2008":
                    ProcessFormMaklumatAhliKongsi2008(htmlDoc);
                    break;
                case "2009":
                    ProcessFormMaklumatAhliKongsi2009(htmlDoc);
                    break;
                case "2010":
                    ProcessFormMaklumatAhliKongsi2010(htmlDoc);
                    break;
                //LeeCC 2011.2 27 FEB
                case "2011":
                    ProcessFormMaklumatAhliKongsi2011(htmlDoc);
                    break;
               //LeeCC end
               //LeeCC 2012 SU2 
                case "2012":
                    ProcessFormMaklumatAhliKongsi2012(htmlDoc);
                    break;
               //LeeCC 2012 SU2 

              //simkh 2014
                case "2013":
                    ProcessFormMaklumatAhliKongsi2013(htmlDoc);
                    break;
              //simkh end

                case "2014":
                    ProcessFormMaklumatAhliKongsi2014(htmlDoc);
                    break;
                case "2015":
                    ProcessFormMaklumatAhliKongsi2015(htmlDoc);
                    break;
                case "2016":
                    ProcessFormMaklumatAhliKongsi2016(htmlDoc);
                    break;
            }
        }

        private void ProcessFormMaklumatAhliKongsi2008(mshtml.HTMLDocument htmlDoc)
        {
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

        private void ProcessFormMaklumatAhliKongsi2009(mshtml.HTMLDocument htmlDoc)
        {

            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
            {
                switch (inpElement1.name)
                {
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_Nama":
                        inpElement1.value = strData[4].ToString().ToUpper();
                        break;
                }
            }

            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
            {
                switch (inpElement1.name)
                {
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_No_kp":
                        inpElement1.value = strData[5].Replace("-","");
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_No_rujukan":
                        inpElement1.value = strData[3];
                        break;
                    //case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlJ_Fail":
                    //    inpElement1.value = strData[2];
                    //    break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_tarikh_masuk":
                        inpElement1.value = strData[0];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_tarikh_keluar":
                        inpElement1.value = strData[1];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_bhgn_ahli":
                        inpElement1.value = strData[7];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmptyPend_Berkanun":
                        if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                        {
                            inpElement1.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                        }
                        else
                        {
                            inpElement1.value = "0";
                        }
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmptyRugi_Larasan":
                        if (double.Parse(strData[11]) < 0)
                        {
                            inpElement1.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                        }
                        else
                        {
                            inpElement1.value = "0";
                        }
                        break;
                }
            }
            foreach (mshtml.HTMLSelectElement selElement1 in htmlDoc.getElementsByTagName("select"))
            {
                switch (selElement1.name)
                {
                    //rmk
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlEmpty_Negara":
                        selElement1.value = strData[6];
                        boolFilled = true;
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$DropDownList1":
                        selElement1.value = strData[2];
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_manfaat1":
                        if (strData[8] == "1")
                        {
                            selElement1.value = strData[8];
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_manfaat2":
                        if (strData[9] == "1")
                        {
                            selElement1.value = "2";
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_manfaat3":
                        if (strData[10] == "1")
                        {
                            selElement1.value = "3";
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$Button1":
                        selElement1.click();
                        break;

                }
            }

            if (isPrePartner())
            {
                foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
                {
                    switch (inpElement1.name)
                    {
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNama":
                            inpElement1.value = strData[4].ToString().ToUpper();
                            boolFilled = true;
                            break;
                    }
                }

                foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
                {
                    switch (inpElement1.name)
                    {
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNo_Rujukan2":
                            inpElement1.value = strData[3];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNoPengenalan":
                            inpElement1.value = strData[5].Replace("-", "");
                            break;
                        //case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlJ_Fail":
                        //    inpElement1.value = strData[2];
                        //    break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtTkhMasuk":
                            inpElement1.value = strData[0];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtTkhKeluar":
                            inpElement1.value = strData[1];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtBhg_Ahli":
                            inpElement1.value = strData[7];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtPend_Berkanun":
                            if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                            {
                                inpElement1.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                            }
                            else
                            {
                                inpElement1.value = "0";
                            }
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtRugi_Larasan":
                            if (double.Parse(strData[11]) < 0)
                            {
                                inpElement1.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                            }
                            else
                            {
                                inpElement1.value = "0";
                            }
                            break;
                    }
                }
                foreach (mshtml.HTMLSelectElement selElement1 in htmlDoc.getElementsByTagName("select"))
                {
                    switch (selElement1.name)
                    {
                        //rmk
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNegara":
                            selElement1.value = strData[6];
                            boolFilled = true;
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$ddlJenis_Fail":
                            selElement1.value = strData[2];
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtManfaat1":
                            if (strData[8] == "1")
                            {
                                selElement1.value = strData[8];
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtManfaat2":
                            if (strData[9] == "1")
                            {
                                selElement1.value = "2";
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtManfaat3":
                            if (strData[10] == "1")
                            {
                                selElement1.value = "3";
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$Button1":
                            selElement1.click();
                            break;

                    }
                }

                if (boolFilled == true)
                {

                    intIndex = intIndex - 1;
                    foreach (mshtml.HTMLAnchorElement ancElement in htmlDoc.getElementsByTagName("a"))
                    {
                        if (ancElement.id != null)
                        {
                            if (ancElement.id.ToString() == "ctl00_ContentPlaceHolder2_GridView1_ctl02_btnSimpan")
                            {
                                ancElement.click();
                            }
                        }
                    }
                }
            }
            else
            {
                // ctl00$ContentPlaceHolder2$GridView1$ctl03$txtNama_Add
                for (intIndex = 3; intIndex < 20; intIndex++)
                {
                    if (boolFilled == true)
                    { break; }
                    else
                    {
                        string strPrefix = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$ddlJenis_Fail_Add";
                        string strRef = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNoRujukan2_Add";
                        //rmk
                        //string strName2 =
                        //"ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNama";

                        string strName = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNama_Add";
                        string strIC = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNoPengenalan_Add";
                        string strCountry = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNegara_Add";
                        string strDateIn = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtTkhMasuk_Add";
                        string strDateOut = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtTkhKeluar_Add";
                        string strShare = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtBhg_Ahli_Add";
                        string strB1 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat1_Add";
                        string strB2 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat2_Add";
                        string strB3 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat3_Add";
                        string strPendapatan = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtPend_Berkanun_Add";
                        string strPelarasan = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtRugi_Larasan_Add";

                        foreach (mshtml.HTMLInputElement inpElement2 in htmlDoc.getElementsByTagName("input"))
                        {

                            if (inpElement2.name.ToString() == strRef)
                            {
                                inpElement2.value = strData[3].ToString().ToUpper();
                                boolFilled = true;
                            }

                            else if (inpElement2.name.ToString() == strIC)
                            {
                                inpElement2.value = strData[5].Replace("-","") ;
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
                            else if (inpElement2.name.ToString() == strPendapatan)
                            {
                                if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                                {
                                    inpElement2.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                                }
                                else
                                {
                                    inpElement2.value = "0";
                                }
                                boolFilled = true;
                            }
                            else if (inpElement2.name.ToString() == strPelarasan)
                            {
                                if (double.Parse(strData[11]) < 0)
                                {
                                    inpElement2.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                                }
                                else
                                {
                                    inpElement2.value = "0";
                                }
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
                                if (strData[8] == "1")
                                {
                                    selElement.value = strData[8];
                                }
                                else
                                {
                                    selElement.value = "";
                                }
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
       }

        private void ProcessFormMaklumatAhliKongsi2010(mshtml.HTMLDocument htmlDoc)
        { //weihong

            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
            {
                switch (inpElement1.name)
                {
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_Nama":
                        inpElement1.value = strData[4].ToString().ToUpper();
                        break;
                }
            }

            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
            {
                switch (inpElement1.name)
                {
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_No_kp":
                        inpElement1.value = strData[5].Replace("-", "");
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_No_rujukan":
                        inpElement1.value = strData[3];
                        break;
                    //case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlJ_Fail":
                    //    inpElement1.value = strData[2];
                    //    break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_tarikh_masuk":
                        inpElement1.value = strData[0];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_tarikh_keluar":
                        inpElement1.value = strData[1];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_bhgn_ahli":
                        inpElement1.value = strData[7];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmptyPend_Berkanun":
                        if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                        {
                            inpElement1.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                        }
                        else
                        {
                            inpElement1.value = "0";
                        }
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmptyRugi_Larasan":
                        if (double.Parse(strData[11]) < 0)
                        {
                            inpElement1.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                        }
                        else
                        {
                            inpElement1.value = "0";
                        }
                        break;
                }
            }
            foreach (mshtml.HTMLSelectElement selElement1 in htmlDoc.getElementsByTagName("select"))
            {
                switch (selElement1.name)
                {
                    //rmk
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlEmpty_Negara":
                        selElement1.value = strData[6];
                        boolFilled = true;
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$DropDownList1":
                        selElement1.value = strData[2];
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_manfaat1":
                        if (strData[8] == "1")
                        {
                            selElement1.value = strData[8];
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_manfaat2":
                        if (strData[9] == "1")
                        {
                            selElement1.value = "2";
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_manfaat3":
                        if (strData[10] == "1")
                        {
                            selElement1.value = "3";
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$Button1":
                        selElement1.click();
                        break;

                }
            }

            if (isPrePartner())
            {
                foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
                {
                    switch (inpElement1.name)
                    {
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNama":
                            inpElement1.value = strData[4].ToString().ToUpper();
                            boolFilled = true;
                            break;
                    }
                }

                foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
                {
                    switch (inpElement1.name)
                    {
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNo_Rujukan2":
                            inpElement1.value = strData[3];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNoPengenalan":
                            inpElement1.value = strData[5].Replace("-", "");
                            break;
                        //case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlJ_Fail":
                        //    inpElement1.value = strData[2];
                        //    break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtTkhMasuk":
                            inpElement1.value = strData[0];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtTkhKeluar":
                            inpElement1.value = strData[1];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtBhg_Ahli":
                            inpElement1.value = strData[7];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtPend_Berkanun":
                            if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                            {
                                inpElement1.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                            }
                            else
                            {
                                inpElement1.value = "0";
                            }
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtRugi_Larasan":
                            if (double.Parse(strData[11]) < 0)
                            {
                                inpElement1.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                            }
                            else
                            {
                                inpElement1.value = "0";
                            }
                            break;
                    }
                }
                foreach (mshtml.HTMLSelectElement selElement1 in htmlDoc.getElementsByTagName("select"))
                {
                    switch (selElement1.name)
                    {
                        //rmk
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNegara":
                            selElement1.value = strData[6];
                            boolFilled = true;
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$ddlJenis_Fail":
                            selElement1.value = strData[2];
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtManfaat1":
                            if (strData[8] == "1")
                            {
                                selElement1.value = strData[8];
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtManfaat2":
                            if (strData[9] == "1")
                            {
                                selElement1.value = "2";
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtManfaat3":
                            if (strData[10] == "1")
                            {
                                selElement1.value = "3";
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$Button1":
                            selElement1.click();
                            break;

                    }
                }

                if (boolFilled == true)
                {

                    intIndex = intIndex - 1;
                    foreach (mshtml.HTMLAnchorElement ancElement in htmlDoc.getElementsByTagName("a"))
                    {
                        if (ancElement.id != null)
                        {
                            if (ancElement.id.ToString() == "ctl00_ContentPlaceHolder2_GridView1_ctl02_btnSimpan")
                            {
                                ancElement.click();
                            }
                        }
                    }
                }
            }
            else
            {
                // ctl00$ContentPlaceHolder2$GridView1$ctl03$txtNama_Add
                for (intIndex = 3; intIndex < 20; intIndex++)
                {
                    if (boolFilled == true)
                    { break; }
                    else
                    {
                        string strPrefix = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$ddlJenis_Fail_Add";
                        string strRef = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNoRujukan2_Add";
                        //rmk
                        //string strName2 =
                        //"ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNama";

                        string strName = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNama_Add";
                        string strIC = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNoPengenalan_Add";
                        string strCountry = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNegara_Add";
                        string strDateIn = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtTkhMasuk_Add";
                        string strDateOut = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtTkhKeluar_Add";
                        string strShare = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtBhg_Ahli_Add";
                        string strB1 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat1_Add";
                        string strB2 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat2_Add";
                        string strB3 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat3_Add";
                        string strPendapatan = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtPend_Berkanun_Add";
                        string strPelarasan = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtRugi_Larasan_Add";

                        foreach (mshtml.HTMLInputElement inpElement2 in htmlDoc.getElementsByTagName("input"))
                        {

                            if (inpElement2.name.ToString() == strRef)
                            {
                                inpElement2.value = strData[3].ToString().ToUpper();
                                boolFilled = true;
                            }

                            else if (inpElement2.name.ToString() == strIC)
                            {
                                inpElement2.value = strData[5].Replace("-", "");
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
                            else if (inpElement2.name.ToString() == strPendapatan)
                            {
                                if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                                {
                                    inpElement2.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                                }
                                else
                                {
                                    inpElement2.value = "0";
                                }
                                boolFilled = true;
                            }
                            else if (inpElement2.name.ToString() == strPelarasan)
                            {
                                if (double.Parse(strData[11]) < 0)
                                {
                                    inpElement2.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                                }
                                else
                                {
                                    inpElement2.value = "0";
                                }
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
                                if (strData[8] == "1")
                                {
                                    selElement.value = strData[8];
                                }
                                else
                                {
                                    selElement.value = "";
                                }
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
        }

        //LeeCC 27 FEB 2011.2
        private void ProcessFormMaklumatAhliKongsi2011(mshtml.HTMLDocument htmlDoc)
        { //weihong

            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
            {
                switch (inpElement1.name)
                {
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_Nama":
                        inpElement1.value = strData[4].ToString().ToUpper();
                        break;
                }
            }

            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
            {
                switch (inpElement1.name)
                {
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_No_kp":
                        inpElement1.value = strData[5].Replace("-", "");
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_No_rujukan":
                        inpElement1.value = strData[3];
                        break;
                    //case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlJ_Fail":
                    //    inpElement1.value = strData[2];
                    //    break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_tarikh_masuk":
                        inpElement1.value = strData[0];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_tarikh_keluar":
                        inpElement1.value = strData[1];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_bhgn_ahli":
                        inpElement1.value = strData[7];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmptyPend_Berkanun":
                        if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                        {
                            inpElement1.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                        }
                        else
                        {
                            inpElement1.value = "0";
                        }
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmptyRugi_Larasan":
                        if (double.Parse(strData[11]) < 0)
                        {
                            inpElement1.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                        }
                        else
                        {
                            inpElement1.value = "0";
                        }
                        break;
                }
            }
            foreach (mshtml.HTMLSelectElement selElement1 in htmlDoc.getElementsByTagName("select"))
            {
                switch (selElement1.name)
                {
                    //rmk
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlEmpty_Negara":
                        selElement1.value = strData[6];
                        boolFilled = true;
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$DropDownList1":
                        selElement1.value = strData[2];
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_manfaat1":
                        if (strData[8] == "1")
                        {
                            selElement1.value = strData[8];
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_manfaat2":
                        if (strData[9] == "1")
                        {
                            selElement1.value = "2";
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_manfaat3":
                        if (strData[10] == "1")
                        {
                            selElement1.value = "3";
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$Button1":
                        selElement1.click();
                        break;

                }
            }

            if (isPrePartner())
            {
                foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
                {
                    switch (inpElement1.name)
                    {
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNama":
                            inpElement1.value = strData[4].ToString().ToUpper();
                            boolFilled = true;
                            break;
                    }
                }

                foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
                {
                    switch (inpElement1.name)
                    {
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNo_Rujukan2":
                            inpElement1.value = strData[3];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNoPengenalan":
                            inpElement1.value = strData[5].Replace("-", "");
                            break;
                        //case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlJ_Fail":
                        //    inpElement1.value = strData[2];
                        //    break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtTkhMasuk":
                            inpElement1.value = strData[0];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtTkhKeluar":
                            inpElement1.value = strData[1];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtBhg_Ahli":
                            inpElement1.value = strData[7];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtPend_Berkanun":
                            if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                            {
                                inpElement1.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                            }
                            else
                            {
                                inpElement1.value = "0";
                            }
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtRugi_Larasan":
                            if (double.Parse(strData[11]) < 0)
                            {
                                inpElement1.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                            }
                            else
                            {
                                inpElement1.value = "0";
                            }
                            break;
                    }
                }
                foreach (mshtml.HTMLSelectElement selElement1 in htmlDoc.getElementsByTagName("select"))
                {
                    switch (selElement1.name)
                    {
                        //rmk
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNegara":
                            selElement1.value = strData[6];
                            boolFilled = true;
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$ddlJenis_Fail":
                            selElement1.value = strData[2];
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtManfaat1":
                            if (strData[8] == "1")
                            {
                                selElement1.value = strData[8];
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtManfaat2":
                            if (strData[9] == "1")
                            {
                                selElement1.value = "2";
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtManfaat3":
                            if (strData[10] == "1")
                            {
                                selElement1.value = "3";
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$Button1":
                            selElement1.click();
                            break;

                    }
                }

                if (boolFilled == true)
                {

                    intIndex = intIndex - 1;
                    foreach (mshtml.HTMLAnchorElement ancElement in htmlDoc.getElementsByTagName("a"))
                    {
                        if (ancElement.id != null)
                        {
                            if (ancElement.id.ToString() == "ctl00_ContentPlaceHolder2_GridView1_ctl02_btnSimpan")
                            {
                                ancElement.click();
                            }
                        }
                    }
                }
            }
            else
            {
                // ctl00$ContentPlaceHolder2$GridView1$ctl03$txtNama_Add
                for (intIndex = 3; intIndex < 20; intIndex++)
                {
                    if (boolFilled == true)
                    { break; }
                    else
                    {
                        string strPrefix = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$ddlJenis_Fail_Add";
                        string strRef = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNoRujukan2_Add";
                        //rmk
                        //string strName2 =
                        //"ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNama";

                        string strName = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNama_Add";
                        string strIC = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNoPengenalan_Add";
                        string strCountry = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNegara_Add";
                        string strDateIn = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtTkhMasuk_Add";
                        string strDateOut = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtTkhKeluar_Add";
                        string strShare = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtBhg_Ahli_Add";
                        string strB1 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat1_Add";
                        string strB2 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat2_Add";
                        string strB3 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat3_Add";
                        string strPendapatan = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtPend_Berkanun_Add";
                        string strPelarasan = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtRugi_Larasan_Add";

                        foreach (mshtml.HTMLInputElement inpElement2 in htmlDoc.getElementsByTagName("input"))
                        {

                            if (inpElement2.name.ToString() == strRef)
                            {
                                inpElement2.value = strData[3].ToString().ToUpper();
                                boolFilled = true;
                            }

                            else if (inpElement2.name.ToString() == strIC)
                            {
                                inpElement2.value = strData[5].Replace("-", "");
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
                            else if (inpElement2.name.ToString() == strPendapatan)
                            {
                                if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                                {
                                    inpElement2.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                                }
                                else
                                {
                                    inpElement2.value = "0";
                                }
                                boolFilled = true;
                            }
                            else if (inpElement2.name.ToString() == strPelarasan)
                            {
                                if (double.Parse(strData[11]) < 0)
                                {
                                    inpElement2.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                                }
                                else
                                {
                                    inpElement2.value = "0";
                                }
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
                                if (strData[8] == "1")
                                {
                                    selElement.value = strData[8];
                                }
                                else
                                {
                                    selElement.value = "";
                                }
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
        }

        private void ProcessFormMaklumatAhliKongsi2012(mshtml.HTMLDocument htmlDoc)
        { //weihong

            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
            {
                switch (inpElement1.name)
                {
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_Nama":
                        inpElement1.value = strData[4].ToString().ToUpper();
                        break;
                }
            }

            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
            {
                switch (inpElement1.name)
                {
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_No_kp":
                        inpElement1.value = strData[5].Replace("-", "");
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_No_rujukan":
                        inpElement1.value = strData[3];
                        break;
                    //case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlJ_Fail":
                    //    inpElement1.value = strData[2];
                    //    break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_tarikh_masuk":
                        inpElement1.value = strData[0];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_tarikh_keluar":
                        inpElement1.value = strData[1];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_bhgn_ahli":
                        inpElement1.value = strData[7];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmptyPend_Berkanun":
                        if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                        {
                            inpElement1.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                        }
                        else
                        {
                            inpElement1.value = "0";
                        }
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmptyRugi_Larasan":
                        if (double.Parse(strData[11]) < 0)
                        {
                            inpElement1.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                        }
                        else
                        {
                            inpElement1.value = "0";
                        }
                        break;
                }
            }
            foreach (mshtml.HTMLSelectElement selElement1 in htmlDoc.getElementsByTagName("select"))
            {
                switch (selElement1.name)
                {
                    //rmk
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlEmpty_Negara":
                        selElement1.value = strData[6];
                        boolFilled = true;
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$DropDownList1":
                        selElement1.value = strData[2];
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_manfaat1":
                        if (strData[8] == "1")
                        {
                            selElement1.value = strData[8];
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_manfaat2":
                        if (strData[9] == "1")
                        {
                            selElement1.value = "2";
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtEmpty_manfaat3":
                        if (strData[10] == "1")
                        {
                            selElement1.value = "3";
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$Button1":
                        selElement1.click();
                        break;

                }
            }

            if (isPrePartner())
            {
                foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
                {
                    switch (inpElement1.name)
                    {
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNama":
                            inpElement1.value = strData[4].ToString().ToUpper();
                            boolFilled = true;
                            break;
                    }
                }

                foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
                {
                    switch (inpElement1.name)
                    {
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNo_Rujukan2":
                            inpElement1.value = strData[3];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNoPengenalan":
                            inpElement1.value = strData[5].Replace("-", "");
                            break;
                        //case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlJ_Fail":
                        //    inpElement1.value = strData[2];
                        //    break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtTkhMasuk":
                            inpElement1.value = strData[0];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtTkhKeluar":
                            inpElement1.value = strData[1];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtBhg_Ahli":
                            inpElement1.value = strData[7];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtPend_Berkanun":
                            if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                            {
                                inpElement1.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                            }
                            else
                            {
                                inpElement1.value = "0";
                            }
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtRugi_Larasan":
                            if (double.Parse(strData[11]) < 0)
                            {
                                inpElement1.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                            }
                            else
                            {
                                inpElement1.value = "0";
                            }
                            break;
                    }
                }
                foreach (mshtml.HTMLSelectElement selElement1 in htmlDoc.getElementsByTagName("select"))
                {
                    switch (selElement1.name)
                    {
                        //rmk
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNegara":
                            selElement1.value = strData[6];
                            boolFilled = true;
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$ddlJenis_Fail":
                            selElement1.value = strData[2];
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtManfaat1":
                            if (strData[8] == "1")
                            {
                                selElement1.value = strData[8];
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtManfaat2":
                            if (strData[9] == "1")
                            {
                                selElement1.value = "2";
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtManfaat3":
                            if (strData[10] == "1")
                            {
                                selElement1.value = "3";
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$Button1":
                            selElement1.click();
                            break;

                    }
                }

                if (boolFilled == true)
                {

                    intIndex = intIndex - 1;
                    foreach (mshtml.HTMLAnchorElement ancElement in htmlDoc.getElementsByTagName("a"))
                    {
                        if (ancElement.id != null)
                        {
                            if (ancElement.id.ToString() == "ctl00_ContentPlaceHolder2_GridView1_ctl02_btnSimpan")
                            {
                                ancElement.click();
                            }
                        }
                    }
                }
            }
            else
            {
                // ctl00$ContentPlaceHolder2$GridView1$ctl03$txtNama_Add
                for (intIndex = 3; intIndex < 20; intIndex++)
                {
                    if (boolFilled == true)
                    { break; }
                    else
                    {
                        string strPrefix = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$ddlJenis_Fail_Add";
                        string strRef = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNoRujukan2_Add";
                        //rmk
                        //string strName2 =
                        //"ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNama";

                        string strName = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNama_Add";
                        string strIC = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNoPengenalan_Add";
                        string strCountry = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNegara_Add";
                        string strDateIn = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtTkhMasuk_Add";
                        string strDateOut = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtTkhKeluar_Add";
                        string strShare = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtBhg_Ahli_Add";
                        string strB1 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat1_Add";
                        string strB2 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat2_Add";
                        string strB3 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat3_Add";
                        string strPendapatan = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtPend_Berkanun_Add";
                        string strPelarasan = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtRugi_Larasan_Add";

                        foreach (mshtml.HTMLInputElement inpElement2 in htmlDoc.getElementsByTagName("input"))
                        {

                            if (inpElement2.name.ToString() == strRef)
                            {
                                inpElement2.value = strData[3].ToString().ToUpper();
                                boolFilled = true;
                            }

                            else if (inpElement2.name.ToString() == strIC)
                            {
                                inpElement2.value = strData[5].Replace("-", "");
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
                            else if (inpElement2.name.ToString() == strPendapatan)
                            {
                                if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                                {
                                    inpElement2.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                                }
                                else
                                {
                                    inpElement2.value = "0";
                                }
                                boolFilled = true;
                            }
                            else if (inpElement2.name.ToString() == strPelarasan)
                            {
                                if (double.Parse(strData[11]) < 0)
                                {
                                    inpElement2.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                                }
                                else
                                {
                                    inpElement2.value = "0";
                                }
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
                                if (strData[8] == "1")
                                {
                                    selElement.value = strData[8];
                                }
                                else
                                {
                                    selElement.value = "";
                                }
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
        }

        private void ProcessFormMaklumatAhliKongsi2013(mshtml.HTMLDocument htmlDoc)
        { //weihong

            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
            {
                switch (inpElement1.name)
                {
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtNama_Empty":
                        inpElement1.value = strData[4].ToString().ToUpper();
                        break;
                }
            }

            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
            {
                switch (inpElement1.name)
                {
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtNoPengenalan_Empty":
                        inpElement1.value = strData[5].Replace("-", "");
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtNoRujukan_Empty":
                        inpElement1.value = strData[3];
                        break;
                    //case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlJ_Fail":
                    //    inpElement1.value = strData[2];
                    //    break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtTkhMasuk_Empty":
                        inpElement1.value = strData[0];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtTkhKeluar_Empty":
                        inpElement1.value = strData[1];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtBhg_Ahli_Empty":
                        inpElement1.value = strData[7];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtPendBerkanun_Empty":
                        if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                        {
                            inpElement1.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                        }
                        else
                        {
                            inpElement1.value = "0";
                        }
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtRugiLarasan_Empty":
                        if (double.Parse(strData[11]) < 0)
                        {
                            inpElement1.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                        }
                        else
                        {
                            inpElement1.value = "0";
                        }
                        break;
                }
            }
            foreach (mshtml.HTMLSelectElement selElement1 in htmlDoc.getElementsByTagName("select"))
            {
                switch (selElement1.name)
                {
                    //rmk
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtNegara_Empty":
                        selElement1.value = strData[6];
                        boolFilled = true;
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlJenisFail_Empty":
                        selElement1.value = strData[2];
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtManfaat1_Empty":
                        if (strData[8] == "1")
                        {
                            selElement1.value = strData[8];
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtManfaat2_Empty":
                        if (strData[9] == "1")
                        {
                            selElement1.value = "2";
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtManfaat3_Empty":
                        if (strData[10] == "1")
                        {
                            selElement1.value = "3";
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$Button1":
                        selElement1.click();
                        break;

                }
            }

            if (isPrePartner())
            {
                foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
                {
                    switch (inpElement1.name)
                    {
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNama":
                            inpElement1.value = strData[4].ToString().ToUpper();
                            boolFilled = true;
                            break;
                    }
                }

                foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
                {
                    switch (inpElement1.name)
                    {
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNo_Rujukan2":
                            inpElement1.value = strData[3];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNoPengenalan":
                            inpElement1.value = strData[5].Replace("-", "");
                            break;
                        //case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlJ_Fail":
                        //    inpElement1.value = strData[2];
                        //    break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtTkhMasuk":
                            inpElement1.value = strData[0];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtTkhKeluar":
                            inpElement1.value = strData[1];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtBhg_Ahli":
                            inpElement1.value = strData[7];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtPend_Berkanun":
                            if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                            {
                                inpElement1.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                            }
                            else
                            {
                                inpElement1.value = "0";
                            }
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtRugi_Larasan":
                            if (double.Parse(strData[11]) < 0)
                            {
                                inpElement1.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                            }
                            else
                            {
                                inpElement1.value = "0";
                            }
                            break;
                    }
                }
                foreach (mshtml.HTMLSelectElement selElement1 in htmlDoc.getElementsByTagName("select"))
                {
                    switch (selElement1.name)
                    {
                        //rmk
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNegara":
                            selElement1.value = strData[6];
                            boolFilled = true;
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$ddlJenis_Fail":
                            selElement1.value = strData[2];
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtManfaat1":
                            if (strData[8] == "1")
                            {
                                selElement1.value = strData[8];
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtManfaat2":
                            if (strData[9] == "1")
                            {
                                selElement1.value = "2";
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtManfaat3":
                            if (strData[10] == "1")
                            {
                                selElement1.value = "3";
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$Button1":
                            selElement1.click();
                            break;

                    }
                }

                if (boolFilled == true)
                {

                    intIndex = intIndex - 1;
                    foreach (mshtml.HTMLAnchorElement ancElement in htmlDoc.getElementsByTagName("a"))
                    {
                        if (ancElement.id != null)
                        {
                            if (ancElement.id.ToString() == "ctl00_ContentPlaceHolder2_GridView1_ctl02_btnSimpan")
                            {
                                ancElement.click();
                            }
                        }
                    }
                }
            }
            else
            {
                // ctl00$ContentPlaceHolder2$GridView1$ctl03$txtNama_Add
                for (intIndex = 3; intIndex < 20; intIndex++)
                {
                    if (boolFilled == true)
                    { break; }
                    else
                    {
                        string strPrefix = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$ddlJenis_Fail_Add";
                        string strRef = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNoRujukan2_Add";
                        //rmk
                        //string strName2 =
                        //"ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNama";

                        string strName = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNama_Add";
                        string strIC = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNoPengenalan_Add";
                        string strCountry = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNegara_Add";
                        string strDateIn = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtTkhMasuk_Add";
                        string strDateOut = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtTkhKeluar_Add";
                        string strShare = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtBhg_Ahli_Add";
                        string strB1 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat1_Add";
                        string strB2 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat2_Add";
                        string strB3 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat3_Add";
                        string strPendapatan = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtPend_Berkanun_Add";
                        string strPelarasan = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtRugi_Larasan_Add";

                        foreach (mshtml.HTMLInputElement inpElement2 in htmlDoc.getElementsByTagName("input"))
                        {

                            if (inpElement2.name.ToString() == strRef)
                            {
                                inpElement2.value = strData[3].ToString().ToUpper();
                                boolFilled = true;
                            }

                            else if (inpElement2.name.ToString() == strIC)
                            {
                                inpElement2.value = strData[5].Replace("-", "");
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
                            else if (inpElement2.name.ToString() == strPendapatan)
                            {
                                if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                                {
                                    inpElement2.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                                }
                                else
                                {
                                    inpElement2.value = "0";
                                }
                                boolFilled = true;
                            }
                            else if (inpElement2.name.ToString() == strPelarasan)
                            {
                                if (double.Parse(strData[11]) < 0)
                                {
                                    inpElement2.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                                }
                                else
                                {
                                    inpElement2.value = "0";
                                }
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
                                if (strData[8] == "1")
                                {
                                    selElement.value = strData[8];
                                }
                                else
                                {
                                    selElement.value = "";
                                }
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
        }

        private void ProcessFormMaklumatAhliKongsi2014(mshtml.HTMLDocument htmlDoc)
        { //weihong

            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
            {
                switch (inpElement1.name)
                {
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl05$txtNama_Add":
                        inpElement1.value = strData[4].ToString().ToUpper();
                        break;
                }
            }

            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
            {
                switch (inpElement1.name)
                {
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl05$txtNoPengenalan_Add":
                        inpElement1.value = strData[5].Replace("-", "");
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl05$txtNoRujukan_Add":
                        inpElement1.value = strData[3];
                        break;
                    //case "ctl00$ContentPlaceHolder2$GridView1$ctl05$ddlJ_Fail":
                    //    inpElement1.value = strData[2];
                    //    break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl05$txtTkhMasuk_Add":
                        inpElement1.value = strData[0];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl05$txtTkhKeluar_Add":
                        inpElement1.value = strData[1];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl05$txtBhg_Ahli_Add":
                        inpElement1.value = strData[7];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl05$txtPendBerkanun_Add":
                        if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                        {
                            inpElement1.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                        }
                        else
                        {
                            inpElement1.value = "0";
                        }
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl05$txtRugiLarasan_Add":
                        if (double.Parse(strData[11]) < 0)
                        {
                            inpElement1.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                        }
                        else
                        {
                            inpElement1.value = "0";
                        }
                        break;
                }
            }
            foreach (mshtml.HTMLSelectElement selElement1 in htmlDoc.getElementsByTagName("select"))
            {
                switch (selElement1.name)
                {
                    //rmk
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl05$txtNegara_Add":
                        selElement1.value = strData[6];
                        boolFilled = true;
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl05$ddlJenisFail_Add":
                        selElement1.value = strData[2];
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl05$txtManfaat1_Add":
                        if (strData[8] == "1")
                        {
                            selElement1.value = strData[8];
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl05$txtManfaat2_Add":
                        if (strData[9] == "1")
                        {
                            selElement1.value = "2";
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl05$txtManfaat3_Add":
                        if (strData[10] == "1")
                        {
                            selElement1.value = "3";
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl05$Button1":
                        selElement1.click();
                        break;

                }
            }

            if (isPrePartner())
            {
                foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
                {
                    switch (inpElement1.name)
                    {
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNama":
                            inpElement1.value = strData[4].ToString().ToUpper();
                            boolFilled = true;
                            break;
                    }
                }

                foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
                {
                    switch (inpElement1.name)
                    {
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNo_Rujukan2":
                            inpElement1.value = strData[3];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNoPengenalan":
                            inpElement1.value = strData[5].Replace("-", "");
                            break;
                        //case "ctl00$ContentPlaceHolder2$GridView1$ctl05$ddlJ_Fail":
                        //    inpElement1.value = strData[2];
                        //    break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtTkhMasuk":
                            inpElement1.value = strData[0];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtTkhKeluar":
                            inpElement1.value = strData[1];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtBhg_Ahli":
                            inpElement1.value = strData[7];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtPend_Berkanun":
                            if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                            {
                                inpElement1.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                            }
                            else
                            {
                                inpElement1.value = "0";
                            }
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtRugi_Larasan":
                            if (double.Parse(strData[11]) < 0)
                            {
                                inpElement1.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                            }
                            else
                            {
                                inpElement1.value = "0";
                            }
                            break;
                    }
                }
                foreach (mshtml.HTMLSelectElement selElement1 in htmlDoc.getElementsByTagName("select"))
                {
                    switch (selElement1.name)
                    {
                        //rmk
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNegara":
                            selElement1.value = strData[6];
                            boolFilled = true;
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$ddlJenis_Fail":
                            selElement1.value = strData[2];
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtManfaat1":
                            if (strData[8] == "1")
                            {
                                selElement1.value = strData[8];
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtManfaat2":
                            if (strData[9] == "1")
                            {
                                selElement1.value = "2";
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$txtManfaat3":
                            if (strData[10] == "1")
                            {
                                selElement1.value = "3";
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl02$Button1":
                            selElement1.click();
                            break;

                    }
                }

                if (boolFilled == true)
                {

                    intIndex = intIndex - 1;
                    foreach (mshtml.HTMLAnchorElement ancElement in htmlDoc.getElementsByTagName("a"))
                    {
                        if (ancElement.id != null)
                        {
                            if (ancElement.id.ToString() == "ctl00_ContentPlaceHolder2_GridView1_ctl02_btnSimpan")
                            {
                                ancElement.click();
                            }
                        }
                    }
                }
            }
            else
            {
                // ctl00$ContentPlaceHolder2$GridView1$ctl03$txtNama_Add
                for (intIndex = 3; intIndex < 20; intIndex++)
                {
                    if (boolFilled == true)
                    { break; }
                    else
                    {
                        string strPrefix = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$ddlJenis_Fail_Add";
                        string strRef = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNoRujukan2_Add";
                        //rmk
                        //string strName2 =
                        //"ctl00$ContentPlaceHolder2$GridView1$ctl02$txtNama";

                        string strName = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNama_Add";
                        string strIC = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNoPengenalan_Add";
                        string strCountry = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNegara_Add";
                        string strDateIn = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtTkhMasuk_Add";
                        string strDateOut = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtTkhKeluar_Add";
                        string strShare = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtBhg_Ahli_Add";
                        string strB1 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat1_Add";
                        string strB2 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat2_Add";
                        string strB3 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat3_Add";
                        string strPendapatan = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtPend_Berkanun_Add";
                        string strPelarasan = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtRugi_Larasan_Add";

                        foreach (mshtml.HTMLInputElement inpElement2 in htmlDoc.getElementsByTagName("input"))
                        {

                            if (inpElement2.name.ToString() == strRef)
                            {
                                inpElement2.value = strData[3].ToString().ToUpper();
                                boolFilled = true;
                            }

                            else if (inpElement2.name.ToString() == strIC)
                            {
                                inpElement2.value = strData[5].Replace("-", "");
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
                            else if (inpElement2.name.ToString() == strPendapatan)
                            {
                                if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                                {
                                    inpElement2.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                                }
                                else
                                {
                                    inpElement2.value = "0";
                                }
                                boolFilled = true;
                            }
                            else if (inpElement2.name.ToString() == strPelarasan)
                            {
                                if (double.Parse(strData[11]) < 0)
                                {
                                    inpElement2.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                                }
                                else
                                {
                                    inpElement2.value = "0";
                                }
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
                                if (strData[8] == "1")
                                {
                                    selElement.value = strData[8];
                                }
                                else
                                {
                                    selElement.value = "";
                                }
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
        }
        private void ProcessFormMaklumatAhliKongsi2015(mshtml.HTMLDocument htmlDoc)
        { //weihong

            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
            {
                switch (inpElement1.name)
                {
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtNama_Empty":
                        inpElement1.value = strData[4].ToString().ToUpper();
                        break;
                }
            }

            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
            {
                switch (inpElement1.name)
                {
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtNoPengenalan_Empty":
                        inpElement1.value = strData[5].Replace("-", "");
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtNoRujukan_Empty":
                        inpElement1.value = strData[3];
                        break;
                    //case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlJ_Fail":
                    //    inpElement1.value = strData[2];
                    //    break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtTkhMasuk_Empty":
                        inpElement1.value = strData[0];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtTkhKeluar_Empty":
                        inpElement1.value = strData[1];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtBhg_Ahli_Empty":
                        inpElement1.value = strData[7];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtPendBerkanun_Empty":
                        if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                        {
                            inpElement1.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                        }
                        else
                        {
                            inpElement1.value = "0";
                        }
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtRugiLarasan_Empty":
                        if (double.Parse(strData[11]) < 0)
                        {
                            inpElement1.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                        }
                        else
                        {
                            inpElement1.value = "0";
                        }
                        break;
                }
            }
            foreach (mshtml.HTMLSelectElement selElement1 in htmlDoc.getElementsByTagName("select"))
            {
                switch (selElement1.name)
                {
                    //rmk
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtNegara_Empty":
                        selElement1.value = strData[6];
                        boolFilled = true;
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlJenisFail_Empty":
                        selElement1.value = strData[2];
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtManfaat1_Empty":
                        if (strData[8] == "1")
                        {
                            selElement1.value = strData[8];
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtManfaat2_Empty":
                        if (strData[9] == "1")
                        {
                            selElement1.value = "2";
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtManfaat3_Empty":
                        if (strData[10] == "1")
                        {
                            selElement1.value = "3";
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$Button1":
                        selElement1.click();
                        break;

                }
            }

            if (isPrePartner())
            {
                foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
                {
                    switch (inpElement1.name)
                    {
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtNama_Add":
                            inpElement1.value = strData[4].ToString().ToUpper();
                            boolFilled = true;
                            break;
                    }
                }

                foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
                {
                    switch (inpElement1.name)
                    {
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtNo_Rujukan2_Add":
                            inpElement1.value = strData[3];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtNoPengenalan_Add":
                            inpElement1.value = strData[5].Replace("-", "");
                            break;
                        //case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlJ_Fail":
                        //    inpElement1.value = strData[2];
                        //    break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtTkhMasuk_Add":
                            inpElement1.value = strData[0];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtTkhKeluar_Add":
                            inpElement1.value = strData[1];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtBhg_Ahli_Add":
                            inpElement1.value = strData[7];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtPend_Berkanun_Add":
                            if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                            {
                                inpElement1.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                            }
                            else
                            {
                                inpElement1.value = "0";
                            }
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtRugi_Larasan_Add":
                            if (double.Parse(strData[11]) < 0)
                            {
                                inpElement1.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                            }
                            else
                            {
                                inpElement1.value = "0";
                            }
                            break;
                    }
                }
                foreach (mshtml.HTMLSelectElement selElement1 in htmlDoc.getElementsByTagName("select"))
                {
                    switch (selElement1.name)
                    {
                        //rmk
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtNegara_Add":
                            selElement1.value = strData[6];
                            boolFilled = true;
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$ddlJenis_Fail_Add":
                            selElement1.value = strData[2];
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtManfaat1_Add":
                            if (strData[8] == "1")
                            {
                                selElement1.value = strData[8];
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtManfaat2_Add":
                            if (strData[9] == "1")
                            {
                                selElement1.value = "2";
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtManfaat3_Add":
                            if (strData[10] == "1")
                            {
                                selElement1.value = "3";
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$Button1_Add":
                            selElement1.click();
                            break;

                    }
                }

                if (boolFilled == true)
                {

                    intIndex = intIndex - 1;
                    foreach (mshtml.HTMLAnchorElement ancElement in htmlDoc.getElementsByTagName("a"))
                    {
                        if (ancElement.id != null)
                        {
                            if (ancElement.id.ToString() == "ctl00_ContentPlaceHolder2_GridView1_ctl03_btnSimpan_Add")
                            {
                                ancElement.click();
                            }
                        }
                    }
                }
            }
            else
            {
                // ctl00$ContentPlaceHolder2$GridView1$ctl03$txtNama_Empty
                for (intIndex = 3; intIndex < 20; intIndex++)
                {
                    if (boolFilled == true)
                    { break; }
                    else
                    {
                        string strPrefix = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$ddlJenis_Fail_Add";
                        string strRef = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNoRujukan2_Add";
                        //rmk
                        //string strName2 =
                        //"ctl00$ContentPlaceHolder2$GridView1$ctl03$txtNama";

                        string strName = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNama_Add";
                        string strIC = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNoPengenalan_Add";
                        string strCountry = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNegara_Add";
                        string strDateIn = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtTkhMasuk_Add";
                        string strDateOut = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtTkhKeluar_Add";
                        string strShare = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtBhg_Ahli_Add";
                        string strB1 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat1_Add";
                        string strB2 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat2_Add";
                        string strB3 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat3_Add";
                        string strPendapatan = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtPend_Berkanun_Add";
                        string strPelarasan = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtRugi_Larasan_Add";

                        foreach (mshtml.HTMLInputElement inpElement2 in htmlDoc.getElementsByTagName("input"))
                        {

                            if (inpElement2.name.ToString() == strRef)
                            {
                                inpElement2.value = strData[3].ToString().ToUpper();
                                boolFilled = true;
                            }

                            else if (inpElement2.name.ToString() == strIC)
                            {
                                inpElement2.value = strData[5].Replace("-", "");
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
                            else if (inpElement2.name.ToString() == strPendapatan)
                            {
                                if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                                {
                                    inpElement2.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                                }
                                else
                                {
                                    inpElement2.value = "0";
                                }
                                boolFilled = true;
                            }
                            else if (inpElement2.name.ToString() == strPelarasan)
                            {
                                if (double.Parse(strData[11]) < 0)
                                {
                                    inpElement2.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                                }
                                else
                                {
                                    inpElement2.value = "0";
                                }
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
                                if (strData[8] == "1")
                                {
                                    selElement.value = strData[8];
                                }
                                else
                                {
                                    selElement.value = "";
                                }
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
        }
        private void ProcessFormMaklumatAhliKongsi2016(mshtml.HTMLDocument htmlDoc)
        { //weihong
            
            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
            {
                switch (inpElement1.name)
                {
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtNama_Empty":
                        inpElement1.value = strData[4].ToString().ToUpper();
                        break;
                }
            }

            foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
            {
                switch (inpElement1.name)
                {
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtNoPengenalan_Empty":
                        inpElement1.value = strData[5].Replace("-", "");
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtNoRujukan_Empty":
                        inpElement1.value = strData[3];
                        break;
                    //case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlJ_Fail":
                    //    inpElement1.value = strData[2];
                    //    break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtTkhMasuk_Empty":
                        inpElement1.value = strData[0];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtTkhKeluar_Empty":
                        inpElement1.value = strData[1];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtBhg_Ahli_Empty":
                        inpElement1.value = strData[7];
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtPendBerkanun_Empty":
                        if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                        {
                            inpElement1.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                        }
                        else
                        {
                            inpElement1.value = "0";
                        }
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtRugiLarasan_Empty":
                        if (double.Parse(strData[11]) < 0)
                        {
                            inpElement1.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                        }
                        else
                        {
                            inpElement1.value = "0";
                        }
                        break;
                }
            }
            foreach (mshtml.HTMLSelectElement selElement1 in htmlDoc.getElementsByTagName("select"))
            {
                switch (selElement1.name)
                {
                    //rmk
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtNegara_Empty":
                        selElement1.value = strData[6];
                        boolFilled = true;
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlJenisFail_Empty":
                        selElement1.value = strData[2];
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtManfaat1_Empty":
                        if (strData[8] == "1")
                        {
                            selElement1.value = strData[8];
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;
                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtManfaat2_Empty":
                        if (strData[9] == "1")
                        {
                            selElement1.value = "2";
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$txtManfaat3_Empty":
                        if (strData[10] == "1")
                        {
                            selElement1.value = "3";
                        }
                        else
                        {
                            selElement1.value = "";
                        }
                        break;

                    case "ctl00$ContentPlaceHolder2$GridView1$ctl01$Button1":
                        selElement1.click();
                        break;

                }
            }
           // MessageBox.Show("XX" + isPrePartner().ToString());
            if (isPrePartner())
            {
               // MessageBox.Show("Y", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("textarea"))
                {
                    switch (inpElement1.name)
                    {
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtNama_Add": 
                            inpElement1.value = strData[4].ToString().ToUpper();
                            boolFilled = true;
                            break;
                    }
                }

                foreach (mshtml.HTMLInputElement inpElement1 in htmlDoc.getElementsByTagName("input"))
                {
                    switch (inpElement1.name)
                    {

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtNoRujukan2_Add":
                            inpElement1.value = strData[3];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtNoPengenalan_Add":
                            inpElement1.value = strData[5].Replace("-", "");
                            break;
                        //case "ctl00$ContentPlaceHolder2$GridView1$ctl01$ddlJ_Fail":
                        //    inpElement1.value = strData[2];
                        //    break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtTkhMasuk_Add":
                            inpElement1.value = strData[0];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtTkhKeluar_Add":
                            inpElement1.value = strData[1];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtBhg_Ahli_Add":
                            inpElement1.value = strData[7];
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtPend_Berkanun_Add":
                            if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                            {
                                inpElement1.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                            }
                            else
                            {
                                inpElement1.value = "0";
                            }
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtRugi_Larasan_Add":
                            if (double.Parse(strData[11]) < 0)
                            {
                                inpElement1.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                            }
                            else
                            {
                                inpElement1.value = "0";
                            }
                            break;
                    }
                }
                foreach (mshtml.HTMLSelectElement selElement1 in htmlDoc.getElementsByTagName("select"))
                {
                    switch (selElement1.name)
                    {
                        //rmk
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtNegara_Add":
                            selElement1.value = strData[6];
                            boolFilled = true;
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$ddlJenisFail_Add":
                            selElement1.value = strData[2];
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtManfaat1_Add":
                            if (strData[8] == "1")
                            {
                                selElement1.value = strData[8];
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;
                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtManfaat2_Add":
                            if (strData[9] == "1")
                            {
                                selElement1.value = "2";
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$txtManfaat3_Add":
                            if (strData[10] == "1")
                            {
                                selElement1.value = "3";
                            }
                            else
                            {
                                selElement1.value = "";
                            }
                            break;

                        case "ctl00$ContentPlaceHolder2$GridView1$ctl03$Button1":
                            selElement1.click();
                            break;

                    }
                }

                if (boolFilled == true)
                {

                    intIndex = intIndex - 1;
                    foreach (mshtml.HTMLAnchorElement ancElement in htmlDoc.getElementsByTagName("a"))
                    {
                        if (ancElement.id != null)
                        {
                            if (ancElement.id.ToString() == "ctl00_ContentPlaceHolder2_GridView1_ctl03_btnSimpanAdd")
                            {
                                ancElement.click();
                            }
                        }
                    }
                }
            }
            else
            {
               // MessageBox.Show("X", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
                // ctl00$ContentPlaceHolder2$GridView1$ctl03$txtNama_Empty
                for (intIndex = 3; intIndex < 20; intIndex++)
                {
                    if (boolFilled == true)
                    { break; } 
                    else
                    {
                        string strPrefix = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$ddlJenisFail_Add";
                        string strRef = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNoRujukan2_Add";
                        //rmk
                        //string strName2 =
                        //"ctl00$ContentPlaceHolder2$GridView1$ctl03$txtNama";
                        //ctl00$ContentPlaceHolder2$GridView1$ctl03$txtTkhMasuk_Add
                        string strName = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNama_Add";
                        string strIC = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNoPengenalan_Add";
                        string strCountry = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtNegara_Add";
                        string strDateIn = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtTkhMasuk_Add";
                        string strDateOut = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtTkhKeluar_Add";
                        string strShare = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtBhg_Ahli_Add";
                        string strB1 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat1_Add";
                        string strB2 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat2_Add";
                        string strB3 = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtManfaat3_Add";
                        string strPendapatan = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtPend_Berkanun_Add";
                        string strPelarasan = "ctl00$ContentPlaceHolder2$GridView1$ctl" + intIndex.ToString("0#") + "$txtRugi_Larasan_Add";

                        foreach (mshtml.HTMLInputElement inpElement2 in htmlDoc.getElementsByTagName("input"))
                        {

                            if (inpElement2.name.ToString() == strRef)
                            {
                                inpElement2.value = strData[3].ToString().ToUpper();
                                boolFilled = true;
                            }

                            else if (inpElement2.name.ToString() == strIC)
                            {
                                inpElement2.value = strData[5].Replace("-", "");
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
                            else if (inpElement2.name.ToString() == strPendapatan)
                            {
                                if ((double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])) > 0)
                                {
                                    inpElement2.value = (double.Parse(strData[11]) + double.Parse(strData[12]) - double.Parse(strData[13]) - double.Parse(strData[14]) - double.Parse(strData[15])).ToString();
                                }
                                else
                                {
                                    inpElement2.value = "0";
                                }
                                boolFilled = true;
                            }
                            else if (inpElement2.name.ToString() == strPelarasan)
                            {
                                if (double.Parse(strData[11]) < 0)
                                {
                                    inpElement2.value = (Math.Abs(double.Parse(strData[11]))).ToString();
                                }
                                else
                                {
                                    inpElement2.value = "0";
                                }
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
                                if (strData[8] == "1")
                                {
                                    selElement.value = strData[8];
                                }
                                else
                                {
                                    selElement.value = "";
                                }
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
        }
    }
}

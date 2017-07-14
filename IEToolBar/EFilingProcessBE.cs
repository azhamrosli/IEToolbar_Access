using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace IEToolBar
{
    class EFilingProcessBE
    {
        string strYA = "";
        string strTaxPayer = "";
        //string strRecKept = "";
        string strTaxAgent = "";
        string ErrorLog = "";
        public EFilingProcessBE()
        {
        }

        public EFilingProcessBE(string strTaxPayer, string strYA,  string strTaxAgent)
        {
            this.strYA = strYA;
            this.strTaxPayer = strTaxPayer;
            //this.strAuditor = strAuditor;
            this.strTaxAgent = strTaxAgent;
            //this.strRecKept = strRecKept;
    
        }

        public void ProcessForm(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            switch (strYA)
            {
                case "2008":
                    ProcessFormBE2008(htmlDoc, strPageIndex);
                    break;
                case "2009":
                    ProcessFormBE2009(htmlDoc, strPageIndex);
                    break;
                case "2010":
                    ProcessFormBE2010(htmlDoc, strPageIndex);
                    break;
                //LEESH FEB 2012
                case "2011":
                    ProcessFormBE2011(htmlDoc, strPageIndex);
                    break;
                //LEESH END
                //dannylee 15/02/2013
                case "2012":
                    ProcessFormBE2012(htmlDoc, strPageIndex);
                    break;
                //19 Feb 2013
                case "2013":
                    ProcessFormBE2013(htmlDoc, strPageIndex);
                    break;
                case "2014":
                    ProcessFormBE2014(htmlDoc, strPageIndex);
                    break;
                case "2015":
                    ProcessFormBE2015(htmlDoc, strPageIndex);
                    break;
                case "2016":
                    ProcessFormBE2016(htmlDoc, strPageIndex);
                    break;
                //case "2017":
                //    ProcessFormBE2017(htmlDoc, strPageIndex);
                //    break;

            }
        }

        private void ProcessFormBE2008(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            try
            {
                EFilingDALB dal = new EFilingDALB(strTaxPayer, strYA, strTaxAgent);
                DataSet dsData = new DataSet();
                dsData = dal.GetFormDataBE(strPageIndex);
                dal.CloseConn();
                //string strComparator;
                //string strTemp;
                double nTotal = 0;
                DataRow dr;

                foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
                {
                    switch (strPageIndex)
                    {
                        case "BE2008Page1":
                            switch (inpElement.name)
                            {
                                //case "ctl00$master$txtF00009"://IC No
                                //    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                //    break;
                                case "ctl00$master$txtF00009"://Passport No
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$master$txtf00014"://Date of Marriage/Divorce/Demise
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString();
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString();
                                    }
                                    break;
                                case "ctl00$master$txtF00019"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                    break;
                                case "ctl00$master$txtF00020"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                    break;
                                case "ctl00$master$txtF00021"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                    break;
                                case "ctl00$master$txtF00022"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[11].ToString();
                                    break;
                                case "ctl00$master$txtF00023"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[12].ToString();
                                    break;
                                case "ctl00$master$txtF00041"://Tel
                                    inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[14].ToString() + "-" + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[15].ToString());
                                    break;
                                case "ctl00$master$txtF00040"://Employer No
                                    inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[16].ToString() + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[17].ToString());
                                    break;
                                case "ctl00$master$txtF00043"://email
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[18].ToString();
                                    break;
                                case "ctl00$master$txtF00044"://Bank Name
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[19].ToString();
                                    break;
                                case "ctl00$master$txtF00045"://Bank A/C No
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[20].ToString();
                                    break;
                            }
                            break;
                        case "BE2008Page2":
                            switch (inpElement.name)
                            {
                                case "ctl00$master$txtF00052"://Wife Name
                                    inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$master$txtF00055"://Ref No
                                    inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[4].ToString());
                                    break;
                                case "ctl00$master$txtF00057"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString());
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                    }
                                    break;
                            }
                            break;

                        case "BE2008Page3":
                            switch (inpElement.name)
                            {
                                case "ctl00$master$txtF00076"://Employment
                                    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$master$txtF00077"://Dividend
                                    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$master$txtF00078"://Interest and Discount
                                    inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString())));
                                    break;
                                case "ctl00$master$txtF00079"://Rent, royalties and premiums
                                    inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[5].ToString())));
                                    break;
                                case "ctl00$master$txtF00080"://Pension, annuities and other periodical payments
                                    inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[6].ToString()));
                                    break;
                                case "ctl00$master$txtF00081"://Other gains or profits
                                    inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[9].ToString())));
                                    break;
                                case "ctl00$master$txtF00090"://Gift to Government, State Government or local authorities
                                    dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("9");
                                    inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00393"://Gift to approved institutions or organization
                                    dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("1");
                                    inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00389"://Gift to sports activity
                                    dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("7");
                                    inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00390"://Gift to contribution for project of national interest
                                    dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("8");
                                    inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00091"://Gift artefacts, manuscript or painting
                                    dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("2");
                                    inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00092"://Gift of library
                                    dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("3");
                                    inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00093"://Gift of public facilities of disabled persons
                                    dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("4");
                                    inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00094"://Gift of medical equipment to any healthcare facility
                                    dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("5");
                                    inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00095"://Gift of National Art Gallery
                                    dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("6");
                                    inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00099"://Income transfer from husband/wife
                                    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[10].ToString();
                                    break;
                                case "ctl00$master$txtF00165"://Installment/ Schedular
                                    inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[11].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[12].ToString()));
                                    break;
                                //Preceding Years Income
                                case "ctl00$master$txtF00169"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master$txtF00170"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master$txtF00171"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master$txtF00172"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[3].ToString();
                                    }
                                    break;
                                case "ctl00$master$txtF00173"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master$txtF00174"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master$txtF00175"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master$txtF00176"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[3].ToString();
                                    }
                                    break;
                                case "ctl00$master$txtF00177"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master$txtF00178"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master$txtF00179"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master$txtF00180"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[3].ToString();
                                    }
                                    break;
                                case "ctl00$master$txtF00361"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master$txtF00362"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master$txtF00363"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master$txtF00364"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[3].ToString();
                                    }
                                    break;
                                case "ctl00$master$txtF00365"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master$txtF00366"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master$txtF00367"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master$txtF00368"://Provident and pension fund contribution'
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[3].ToString();
                                    }
                                    break;
                            }
                            break;
                        case "BE2008Page4":
                            switch (inpElement.name)
                            {
                                case "ctl00$master$txtF00104"://Individual
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("1");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00105"://Medical expenses for won parents
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("2");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00106"://Basic supporting equipment for disabled person
                                    //dsData.Tables["P4_TAX_RELIEF"].DefaultView.RowFilter = "TCC_KEY = 3";
                                    //inpElement.value = dsData.Tables["P4_TAX_RELIEF"].Select();
                                    //dtOverAll.PrimaryKey = new DataColumn[] { dtOverAll.Columns["ITEMNMBR"] };
                                    //dsData.Tables["P4_TAX_RELIEF"].PrimaryKey = new DataColumn[] { dsData.Tables["P4_TAX_RELIEF"].Columns["TCC_KEY"] };
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("3");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00107"://Disabled individual
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("4");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00108"://Education fees
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("5");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00109"://Medical expenses for self/ spouse/ child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("6");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00110"://Complete medical examination for self/ spouse/ child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("7");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00112"://Purchase books/ megazines
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("8");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00391"://Purchase personal computers
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("21");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00392"://Skim Simapanan Pendidikan Nasional
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("22");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00395"://Purchase sports equipment
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("23");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00116"://Husband/ wife/ payment of alimony
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("10");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00118"://Disabled husband/ wife
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("13");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00397"://No. child own self
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD"].Rows.Count);
                                    break;
                                case "ctl00$master$txtF00398"://No. child husband/ wife
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_HW"].Rows.Count + (dsData.Tables["P4_TAX_RELIEF_CHILD_HW_OTHERS"].Rows.Count));
                                    break;
                                case "ctl00$master$txtF00396"://No. children eligible for deduction
                                    inpElement.value = Convert.ToString((dsData.Tables["P4_TAX_RELIEF_CHILD"].Rows.Count) + (dsData.Tables["P4_TAX_RELIEF_CHILD_HW"].Rows.Count) + (dsData.Tables["P4_TAX_RELIEF_CHILD_HW_OTHERS"].Rows.Count));
                                    break;
                                case "ctl00$master$txtF00120"://No. child under 18 - 1000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_1000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_1000"].Rows.Count;
                                    break;
                                case "ctl00$master$txtF00121"://Amount child under 18 - 1000
                                    inpElement.value = Convert.ToString(nTotal * 1000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master$txtF00122"://No. child under 18 - 500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_500"].Rows.Count;
                                    break;
                                case "ctl00$master$txtF00123"://Amount child under 18 - 500
                                    inpElement.value = Convert.ToString(nTotal * 500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master$txtF00124"://Total amount child under 18
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("14");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00357"://No. child 18 and above - 1000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_1000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_1000"].Rows.Count;
                                    break;
                                case "ctl00$master$txtF00371"://Amount child 18 and above - 1000
                                    inpElement.value = Convert.ToString(nTotal * 1000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master$txtF00358"://No. child 18 and above - 500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_500"].Rows.Count;
                                    break;
                                case "ctl00$master$txtF00372"://Amount child 18 and above - 500
                                    inpElement.value = Convert.ToString(nTotal * 500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master$txtF00359"://No. child 18 and above - 4000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_4000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_4000"].Rows.Count;
                                    break;
                                case "ctl00$master$txtF00373"://Amount child 18 and above - 4000
                                    inpElement.value = Convert.ToString(nTotal * 4000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master$txtF00360"://No. child 18 and above - 2000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_2000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_2000"].Rows.Count;
                                    break;
                                case "ctl00$master$txtF00374"://Amount child 18 and above - 2000
                                    inpElement.value = Convert.ToString(nTotal * 2000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master$txtF00133"://Total amount child 18 and above
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("15");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00135"://No. disabled child - 5000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_5000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_5000"].Rows.Count;
                                    break;
                                case "ctl00$master$txtF00136"://Amount disabled child - 5000
                                    inpElement.value = Convert.ToString(nTotal * 5000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master$txtF00137"://No. disabled child - 2500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_2500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_2500"].Rows.Count;
                                    break;
                                case "ctl00$master$txtF00138"://Amount disabled child - 2500
                                    inpElement.value = Convert.ToString(nTotal * 2500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master$txtF00369"://No. disabled child - 9000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_9000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_9000"].Rows.Count;
                                    break;
                                case "ctl00$master$txtF00375"://Amount disabled child - 9000
                                    inpElement.value = Convert.ToString(nTotal * 9000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master$txtF00370"://No. disabled child - 4500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_4500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_4500"].Rows.Count;
                                    break;
                                case "ctl00$master$txtF00376"://Amount disabled child - 4500
                                    inpElement.value = Convert.ToString(nTotal * 4500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master$txtF00139"://Total amount disabled child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("16");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00140"://Life insurance and providend fund
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("17");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00141"://Education and medical insurance
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("18");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                            }
                            FireInpElementEvent(inpElement, "OnBlur");
                            break;
                        case "BE2008Page5":
                            switch (inpElement.name)
                            {
                                case "ctl00$master$txtF00155":
                                    dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("3");
                                    inpElement.value = dr["TCR_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00157":
                                    dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("5");
                                    inpElement.value = dr["TCR_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master$txtF00160":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$master$txtF00161":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$master$txtF00346":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString();
                                    break;
                                case "ctl00$master$txtF00347":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString();
                                    break;
                            }
                            break;
                        case "BE2008Page6":
                            switch (inpElement.name)
                            {
                                case "ctl00$master$txtF00183":
                                    inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;

                                case "ctl00$master$txtF00185":
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[2].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString();
                                    }
                                    break;
                                case "ctl00$master$txtF00290":
                                    inpElement.value = dsData.Tables["P6_TAXA_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;
                            }
                            break;
                    }
                }
                foreach (mshtml.HTMLSelectElement selElement in htmlDoc.getElementsByTagName("select"))
                {
                    switch (strPageIndex)
                    {
                        case "BE2008Page1":
                            switch (selElement.name)
                            {
                                case "ctl00$master$ddlF00011"://Citizan
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$master$ddlF00012"://Sex
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[2].ToString();
                                    break;
                                case "ctl00$master$ddlF00013"://Status
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    break;
                                case "ctl00$master$ddlF00016"://Type of Assessment
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "1")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[21].ToString()))
                                        {
                                            if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[21].ToString() == "1")
                                            { selElement.value = "1"; }
                                            else
                                            { selElement.value = "2"; }
                                        }
                                    }
                                    else if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "2")
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "3")
                                    {
                                        selElement.value = "4";
                                    }
                                    break;
                                case "ctl00$master$ddlF00018"://Public Rulings
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[7].ToString();
                                    break;
                                case "ctl00$master$ddlF00024"://Correspondence Add - State
                                    selElement.value = SelectState(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[13].ToString());
                                    break;
                            }
                            FireSelElementEvent(selElement, "OnChange");
                            break;
                        case "BE2008Page2":
                            switch (selElement.name)
                            {
                                case "ctl00$master$ddlF00054"://Ref Prefix
                                    selElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$master$ddlJPengenalan_isteri"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                    {
                                        selElement.value = "NEWIC";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                    {
                                        selElement.value = "POLICE";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                    {
                                        selElement.value = "ARMY";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                    {
                                        selElement.value = "PASSPORT";
                                    }
                                    break;
                            }
                            break;
                        case "BE2008Page3":
                            switch (selElement.name)
                            {
                                case "ctl00$master$ddlF00355"://Type of income transfer from husband/wife
                                    if (dsData.Tables["P3_TAX_PROFILE"].Rows[0].ItemArray[11].ToString() == "1")
                                    {
                                        selElement.value = "1";//Ada pendapatan perniagaan (With business income)
                                    }
                                    else if (dsData.Tables["P3_TAX_PROFILE"].Rows[0].ItemArray[11].ToString() == "2")
                                    {
                                        selElement.value = "2";//Tiada punca pendapatan perniagaan (Without business income)
                                    }
                                    break;
                            }
                            break;
                        case "BE2008Page6":
                            switch (selElement.name)
                            {
                                case "ctl00$master$ddlJPengenalan_mati":
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        selElement.value = "NEWIC";
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        selElement.value = "POLICE";
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        selElement.value = "ARMY";
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        selElement.value = "PASSPORT";
                                    }
                                    FireSelElementEvent(selElement, "OnChange");
                                    break;
                            }
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ProcessFormBE2009(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            try
            {
                EFilingDALBE2009 dalBE = new EFilingDALBE2009(strTaxPayer, strYA, strTaxAgent);
                DataSet dsData = new DataSet();
                dsData = dalBE.GetFormDataBE2009(strPageIndex);
                dalBE.CloseConn();
                //string strComparator;
                //string strTemp;

                double nTotal = 0;
                DataRow dr;

                #region "INPUT"
                foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
                {
                    switch (strPageIndex)
                    {
                        #region "Page 1"
                        case "BE2009Page1":
                            switch (inpElement.name)
                            {
                                //case "ctl00$master$txtF00009"://IC No
                                //    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                //    break;
                                case "ctl00$master1$txtF00009"://Passport No
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$master1$txtf00014_Thn"://Date of Marriage/Divorce/Demise - Year
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().LastIndexOf('/') + 1, 4);
                                        }
                                        else
                                        {
                                            inpElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().LastIndexOf('/') + 1, 4);
                                        }
                                        else
                                        {
                                            inpElement.value = "";
                                        }
                                    }
                                    break;
                                case "ctl00$master1$txtF00019"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                    break;
                                case "ctl00$master1$txtF00020"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                    break;
                                case "ctl00$master1$txtF00021"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                    break;
                                case "ctl00$master1$txtF00022"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[11].ToString();
                                    break;
                                case "ctl00$master1$txtF00023"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[12].ToString();
                                    break;
                                case "ctl00$master1$txtF00041"://Tel
                                    inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[14].ToString() + "-" + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[15].ToString());
                                    break;
                                case "ctl00$master1$txtF00040"://Employer No
                                    inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[16].ToString() + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[17].ToString());
                                    break;
                                case "ctl00$master1$txtF00043"://email
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[18].ToString();
                                    break;
                                //case "ctl00$master$txtF00044"://Bank Name
                                //    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[19].ToString();
                                //    break;
                                case "ctl00$master1$txtF00045"://Bank A/C No
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[20].ToString();
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 2"
                        case "BE2009Page2":
                            switch (inpElement.name)
                            {
                                case "ctl00$master1$txtF00052"://Wife Name
                                    inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$master1$txtF00055"://Ref No
                                    inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[4].ToString());
                                    break;
                                case "ctl00$master1$txtF00057"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString());
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00052_1"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00055_1"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$master1$txtF00057_1"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$master1$txtF00052_2"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00055_2"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$master1$txtF00057_2"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$master1$txtF00052_3"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00055_3"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$master1$txtF00057_3"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$master1$btnTambah_Isteri":
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        FireInpElementEvent(inpElement, "OnClick");
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 3"
                        case "BE2009Page3":
                            switch (inpElement.name)
                            {
                                case "ctl00$master1$txtF00076"://Employment
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00077"://Dividend
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00078"://Interest and Discount
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString())));
                                    }
                                    break;
                                case "ctl00$master1$txtF00079"://Rent, royalties and premiums
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[5].ToString())));
                                    }
                                    break;
                                case "ctl00$master1$txtF00080"://Pension, annuities and other periodical payments
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[6].ToString()));
                                    }
                                    break;
                                case "ctl00$master1$txtF00081"://Other gains or profits
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[9].ToString())));
                                    }
                                    break;
                                case "ctl00$master1$txtF00090"://Gift to Government, State Government or local authorities
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("9");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00393"://Gift to approved institutions or organization
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("1");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00389"://Gift to sports activity
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("7");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00390"://Gift to contribution for project of national interest
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("8");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00091"://Gift artefacts, manuscript or painting
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("2");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00092"://Gift of library
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("3");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00093"://Gift of public facilities of disabled persons
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("4");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00094"://Gift of medical equipment to any healthcare facility
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("5");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00095"://Gift of National Art Gallery
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("6");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    break;

                                case "ctl00$master1$txtF00099"://Income transfer from husband/wife
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[10].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00165"://Installment/ Schedular
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[11].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[12].ToString()));
                                    }
                                    break;


                            }
                            break;
                        #endregion

                        #region "Page 4"
                        case "BE2009Page4":
                            switch (inpElement.name)
                            {
                                //Preceding Years Income
                                case "ctl00$master1$txtF00169"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00170"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00171"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00172"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[3].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00173"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00174"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00175"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00176"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[3].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00177"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00178"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00179"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00180"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[3].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00361"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00362"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00363"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00364"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[3].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00365"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00366"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00367"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00368"://Provident and pension fund contribution'
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[3].ToString();
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 5"
                        case "BE2009Page5":
                            switch (inpElement.name)
                            {
                                //case "ctl00$master$txtF00104"://Individual
                                //    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("1");
                                //    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                //    break;
                                case "ctl00$master1$txtF00105"://Medical expenses for won parents
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("2");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00106"://Basic supporting equipment for disabled person
                                    //dsData.Tables["P4_TAX_RELIEF"].DefaultView.RowFilter = "TCC_KEY = 3";
                                    //inpElement.value = dsData.Tables["P4_TAX_RELIEF"].Select();
                                    //dtOverAll.PrimaryKey = new DataColumn[] { dtOverAll.Columns["ITEMNMBR"] };
                                    //dsData.Tables["P4_TAX_RELIEF"].PrimaryKey = new DataColumn[] { dsData.Tables["P4_TAX_RELIEF"].Columns["TCC_KEY"] };
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("3");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00107"://Disabled individual
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("4");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00108"://Education fees
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("5");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00109"://Medical expenses for self/ spouse/ child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("6");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00110"://Complete medical examination for self/ spouse/ child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("7");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00112"://Purchase books/ megazines
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("8");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00391"://Purchase personal computers
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("21");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00392"://Skim Simapanan Pendidikan Nasional
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("22");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00395"://Purchase sports equipment
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("23");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00402"://Housing load interest
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("9");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00116"://Husband/ wife/ payment of alimony
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("10");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00118"://Disabled husband/ wife
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("13");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00397"://No. child own self
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD"].Rows.Count);
                                    break;
                                case "ctl00$master1$txtF00398"://No. child husband/ wife
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_HW"].Rows.Count + dsData.Tables["P4_TAX_RELIEF_CHILD_HW_OTHERS"].Rows.Count);
                                    break;
                                case "ctl00$master1$txtF00396"://No. children eligible for deduction
                                    inpElement.value = Convert.ToString((dsData.Tables["P4_TAX_RELIEF_CHILD"].Rows.Count) + (dsData.Tables["P4_TAX_RELIEF_CHILD_HW"].Rows.Count) + (dsData.Tables["P4_TAX_RELIEF_CHILD_HW_OTHERS"].Rows.Count));
                                    break;
                                case "ctl00$master1$txtF00120"://No. child under 18 - 1000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_1000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_1000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00121"://Amount child under 18 - 1000
                                    inpElement.value = Convert.ToString(nTotal * 1000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00122"://No. child under 18 - 500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_500"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00123"://Amount child under 18 - 500
                                    inpElement.value = Convert.ToString(nTotal * 500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00124"://Total amount child under 18
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("14");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00357"://No. child 18 and above - 1000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_1000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_1000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00371"://Amount child 18 and above - 1000
                                    inpElement.value = Convert.ToString(nTotal * 1000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00358"://No. child 18 and above - 500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_500"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00372"://Amount child 18 and above - 500
                                    inpElement.value = Convert.ToString(nTotal * 500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00359"://No. child 18 and above - 4000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_4000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_4000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00373"://Amount child 18 and above - 4000
                                    inpElement.value = Convert.ToString(nTotal * 4000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00360"://No. child 18 and above - 2000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_2000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_2000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00374"://Amount child 18 and above - 2000
                                    inpElement.value = Convert.ToString(nTotal * 2000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00133"://Total amount child 18 and above
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("15");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00135"://No. disabled child - 5000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_5000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_5000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00136"://Amount disabled child - 5000
                                    inpElement.value = Convert.ToString(nTotal * 5000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00137"://No. disabled child - 2500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_2500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_2500"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00138"://Amount disabled child - 2500
                                    inpElement.value = Convert.ToString(nTotal * 2500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00369"://No. disabled child - 9000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_9000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_9000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00375"://Amount disabled child - 9000
                                    inpElement.value = Convert.ToString(nTotal * 9000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00370"://No. disabled child - 4500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_4500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_4500"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00376"://Amount disabled child - 4500
                                    inpElement.value = Convert.ToString(nTotal * 4500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00139"://Total amount disabled child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("16");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00140"://Life insurance and providend fund
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("17");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00141"://Education and medical insurance
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("18");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                            }
                            FireInpElementEvent(inpElement, "OnBlur");
                            break;
                        #endregion

                        #region "Page 6"
                        case "BE2009Page6":
                            switch (inpElement.name)
                            {
                                case "ctl00$master1$txtF00155":
                                    dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("3");
                                    inpElement.value = dr["TCR_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00157":
                                    dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("5");
                                    inpElement.value = dr["TCR_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00160":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$master1$txtF00161":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$master1$txtF00346":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString();
                                    break;
                                case "ctl00$master1$txtF00347":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString();
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 7"
                        case "BE2009Page7":
                            switch (inpElement.name)
                            {
                                case "ctl00$master1$txtF00282":
                                    inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;

                                case "ctl00$master1$txtF00293":
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[2].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00290":
                                    inpElement.value = dsData.Tables["P6_TAXA_PROFILE"].Rows[0].ItemArray[0].ToString();
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
                        #region "Page 1"
                        case "BE2009Page1":
                            switch (selElement.name)
                            {
                                case "ctl00$master1$ddlF00011"://Citizan
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$master1$ddlF00012"://Sex
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[2].ToString();
                                    break;
                                case "ctl00$master1$ddlF00013"://Status
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    break;
                                case "ctl00$master1$ddlF00014_Hari":////Date of Marriage/Divorce/Demise - Hari
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(0, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(0, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00014_Bulan":////Date of Marriage/Divorce/Demise - Bulan
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().IndexOf('/') + 1, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().IndexOf('/') + 1, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00016"://Type of Assessment
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "1")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[21].ToString()))
                                        {
                                            if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[21].ToString() == "1")
                                            { selElement.value = "1"; }
                                            else
                                            { selElement.value = "2"; }
                                        }
                                    }
                                    else if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "2")
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "3")
                                    {
                                        selElement.value = "4";
                                    }
                                    break;
                                case "ctl00$master1$ddlF00018"://Public Rulings
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[7].ToString();
                                    break;
                                case "ctl00$master1$ddlF00024"://Correspondence Add - State
                                    selElement.value = SelectState(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[13].ToString());
                                    break;

                                case "ctl00$master1$ddlF00044"://Bank Name
                                    if (dsData.Tables["P1_SELECT_BANK"].Rows.Count > 0)
                                    {
                                        selElement.value = dsData.Tables["P1_SELECT_BANK"].Rows[0].ItemArray[0].ToString();
                                    }
                                    break;
                            }
                            FireSelElementEvent(selElement, "OnChange");
                            break;
                        #endregion

                        #region "Page 2"
                        case "BE2009Page2":
                            switch (selElement.name)
                            {
                                case "ctl00$master1$ddlF00054"://Ref Prefix
                                    selElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$master1$ddlJPengenalan_isteri"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                    {
                                        selElement.value = "1";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                    {
                                        selElement.value = "4";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                    {
                                        selElement.value = "2";
                                    }
                                    break;

                                case "ctl00$master1$ddlF00054_1"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$ddlJPengenalan_isteri_1"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00054_2"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$ddlJPengenalan_isteri_2"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00054_3"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$ddlJPengenalan_isteri_3"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 3"
                        case "BE2009Page3":
                            switch (selElement.name)
                            {
                                case "ctl00$master1$ddlF00355"://Type of income transfer from husband/wife
                                    bool boolHaveBusiness = false;
                                    for (int i = 0; i < dsData.Tables["P3_TAX_PROFILE_OTHER"].Rows.Count; i++)
                                    {
                                        if (dsData.Tables["P3_TAX_PROFILE_OTHER"].Rows[i].ItemArray[11].ToString() == "1")
                                        {
                                            boolHaveBusiness = true;
                                            break;
                                        }
                                    }
                                    if (dsData.Tables["P3_TAX_PROFILE"].Rows[0].ItemArray[11].ToString() == "1" || boolHaveBusiness == true)
                                    {
                                        selElement.value = "1";//Ada pendapatan perniagaan (With business income)
                                    }
                                    else //if (dsData.Tables["P3_TAX_PROFILE"].Rows[0].ItemArray[11].ToString() == "2")
                                    {
                                        selElement.value = "2";//Tiada punca pendapatan perniagaan (Without business income)
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 7"
                        //case "BE2009Page7":
                        //    switch (selElement.name)
                        //    {
                        //        case "ctl00$master$ddlJPengenalan_mati":
                        //            if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                        //            {
                        //                selElement.value = "NEWIC";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                        //            {
                        //                selElement.value = "POLICE";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                        //            {
                        //                selElement.value = "ARMY";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                        //            {
                        //                selElement.value = "PASSPORT";
                        //            }
                        //            FireSelElementEvent(selElement, "OnChange");
                        //            break;
                        //    }
                        //    break;
                        #endregion
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void ProcessFormBE2010(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            try
            {
                EFilingDALBE2010 dalBE = new EFilingDALBE2010(strTaxPayer, strYA, strTaxAgent);
                DataSet dsData = new DataSet();
                dsData = dalBE.GetFormDataBE2010(strPageIndex);
                dalBE.CloseConn();
                //string strComparator;
                //string strTemp;

                double nTotal = 0;
                DataRow dr;

                #region "INPUT"
                foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
                {
                    switch (strPageIndex)
                    {
                        #region "Page 1"
                        case "BE2010Page1":
                            switch (inpElement.name)
                            {
                                //case "ctl00$master$txtF00009"://IC No
                                //    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                //    break;
                                case "ctl00$master1$txtF00009"://Passport No
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$master1$txtf00014_Thn"://Date of Marriage/Divorce/Demise - Year
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().LastIndexOf('/') + 1, 4);
                                        }
                                        else
                                        {
                                            inpElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().LastIndexOf('/') + 1, 4);
                                        }
                                        else
                                        {
                                            inpElement.value = "";
                                        }
                                    }
                                    break;


                                case "ctl00$master1$txtF00019"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                    break;
                                case "ctl00$master1$txtF00020"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                    break;
                                case "ctl00$master1$txtF00021"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                    break;
                                case "ctl00$master1$txtF00022"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[11].ToString();
                                    break;
                                case "ctl00$master1$txtF00023"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[12].ToString();
                                    break;
                                case "ctl00$master1$txtF00041"://Tel
                                    inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[14].ToString() + "-" + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[15].ToString());
                                    break;
                                case "ctl00$master1$txtF00040"://Employer No
                                    inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[16].ToString() + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[17].ToString());
                                    break;
                                case "ctl00$master1$txtF00043"://email
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[18].ToString();
                                    break;
                                //case "ctl00$master$txtF00044"://Bank Name
                                //    inpElement.value = SelectBank(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[19].ToString());
                                //    break;
                                case "ctl00$master1$txtF00045"://Bank A/C No
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[20].ToString();
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 2"
                        case "BE2010Page2":
                            switch (inpElement.name)
                            {
                                case "ctl00$master1$txtF00052"://Wife Name
                                    inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$master1$txtF00055"://Ref No
                                    inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[4].ToString());
                                    break;
                                case "ctl00$master1$txtF00057"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString());
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00052_1"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00055_1"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$master1$txtF00057_1"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$master1$txtF00052_2"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00055_2"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$master1$txtF00057_2"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$master1$txtF00052_3"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00055_3"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$master1$txtF00057_3"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$master1$btnTambah_Isteri":
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        FireInpElementEvent(inpElement, "OnClick");
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 3"
                        case "BE2010Page3":
                            switch (inpElement.name)
                            {
                                case "ctl00$master1$txtF00076"://Employment
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00077"://Dividend
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00078"://Interest and Discount
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString())));
                                    }
                                    break;
                                case "ctl00$master1$txtF00079"://Rent, royalties and premiums
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[5].ToString())));
                                    }
                                    break;
                                case "ctl00$master1$txtF00080"://Pension, annuities and other periodical payments
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[6].ToString()));
                                    }
                                    break;
                                case "ctl00$master1$txtF00081"://Other gains or profits
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[9].ToString())));
                                    }
                                    break;
                                case "ctl00$master1$txtF00090"://Gift to Government, State Government or local authorities
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("9");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00393"://Gift to approved institutions or organization
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("1");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00389"://Gift to sports activity
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("7");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00390"://Gift to contribution for project of national interest
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("8");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00091"://Gift artefacts, manuscript or painting
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("2");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00092"://Gift of library
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("3");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00093"://Gift of public facilities of disabled persons
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("4");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00094"://Gift of medical equipment to any healthcare facility
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("5");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00095"://Gift of National Art Gallery
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("6");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00099"://Income transfer from husband/wife
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[10].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00165"://Installment/ Schedular
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[11].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[12].ToString()));
                                    }
                                    break;

                                case "ctl00$master1$txtF00417"://Gross income from employment (weihong) 
                                    //MessageBox.Show("L");
                                    if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[0].ToString()));
                                    }
                                    break;

                                case "ctl00$master1$txtF00418"://Total gross income from all sources (weihong)
                                    if (dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()));
                                        if (dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
                                        {
                                            inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()));
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                        }
                                        else
                                        {
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
                                        {
                                            inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()));
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                        }
                                        else
                                        {
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                            else
                                            {
                                                inpElement.value = "";
                                            }
                                        }
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 4"
                        case "BE2010Page4":
                            switch (inpElement.name)
                            {
                                //Preceding Years Income
                                case "ctl00$master1$txtF00169"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00170"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00171"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00172"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[3].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00173"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00174"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00175"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00176"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[3].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00177"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00178"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00179"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00180"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[3].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00361"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00362"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00363"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00364"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[3].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00365"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00366"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00367"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00368"://Provident and pension fund contribution'
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[3].ToString();
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 5"
                        case "BE2010Page5":
                            int intCount = 0;

                            switch (inpElement.name)
                            {
                                //case "ctl00$master$txtF00104"://Individual
                                //    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("1");
                                //    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                //    break;
                                case "ctl00$master1$txtF00105"://Medical expenses for won parents
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("2");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00106"://Basic supporting equipment for disabled person
                                    //dsData.Tables["P4_TAX_RELIEF"].DefaultView.RowFilter = "TCC_KEY = 3";
                                    //inpElement.value = dsData.Tables["P4_TAX_RELIEF"].Select();
                                    //dtOverAll.PrimaryKey = new DataColumn[] { dtOverAll.Columns["ITEMNMBR"] };
                                    //dsData.Tables["P4_TAX_RELIEF"].PrimaryKey = new DataColumn[] { dsData.Tables["P4_TAX_RELIEF"].Columns["TCC_KEY"] };
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("3");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00107"://Disabled individual
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("4");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00108"://Education fees
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("5");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00109"://Medical expenses for self/ spouse/ child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("6");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00110"://Complete medical examination for self/ spouse/ child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("7");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00112"://Purchase books/ megazines
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("8");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00391"://Purchase personal computers
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("21");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00392"://Skim Simapanan Pendidikan Nasional
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("22");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00395"://Purchase sports equipment
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("23");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00402"://Housing load interest
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("9");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00116"://Husband/ wife/ payment of alimony
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("10");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00118"://Disabled husband/ wife
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("13");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00397"://No. child own self
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD"].Rows.Count);
                                    break;
                                case "ctl00$master1$txtF00398"://No. child husband/ wife
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_HW"].Rows.Count + dsData.Tables["P4_TAX_RELIEF_CHILD_HW_OTHERS"].Rows.Count);
                                    break;
                                case "ctl00$master1$txtF00396"://No. children eligible for deduction
                                    inpElement.value = Convert.ToString((dsData.Tables["P4_TAX_RELIEF_CHILD"].Rows.Count) + (dsData.Tables["P4_TAX_RELIEF_CHILD_HW"].Rows.Count) + (dsData.Tables["P4_TAX_RELIEF_CHILD_HW_OTHERS"].Rows.Count));
                                    break;
                                case "ctl00$master1$txtF00120"://No. child under 18 - 1000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_1000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_1000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00121"://Amount child under 18 - 1000
                                    inpElement.value = Convert.ToString(nTotal * 1000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00122"://No. child under 18 - 500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_500"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00123"://Amount child under 18 - 500
                                    inpElement.value = Convert.ToString(nTotal * 500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00124"://Total amount child under 18
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("14");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00357"://No. child 18 and above - 1000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_1000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_1000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00371"://Amount child 18 and above - 1000
                                    inpElement.value = Convert.ToString(nTotal * 1000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00358"://No. child 18 and above - 500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_500"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00372"://Amount child 18 and above - 500
                                    inpElement.value = Convert.ToString(nTotal * 500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00359"://No. child 18 and above - 4000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_4000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_4000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00373"://Amount child 18 and above - 4000
                                    inpElement.value = Convert.ToString(nTotal * 4000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00360"://No. child 18 and above - 2000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_2000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_2000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00374"://Amount child 18 and above - 2000
                                    inpElement.value = Convert.ToString(nTotal * 2000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00133"://Total amount child 18 and above
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("15");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                    
                                case "ctl00$master1$txtF00135"://No. disabled child - 5000
                                    intCount = 0;
                                    foreach (DataRow row in dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_5000"].Rows)
                                    {
                                        if (row.ItemArray[0].ToString() == "16")
                                        {
                                            if (!String.IsNullOrEmpty(row.ItemArray[1].ToString()))
                                            {
                                                if (double.Parse(row.ItemArray[1].ToString()) == 6000)
                                                { intCount++; }
                                            }
                                        }

                                    }
                                    inpElement.value = intCount.ToString();
                                 //   inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_5000"].Rows.Count);
                                 //   nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_5000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00136"://Amount disabled child - 5000
                                    inpElement.value = Convert.ToString(nTotal * 5000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00137"://No. disabled child - 2500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_2500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_2500"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00138"://Amount disabled child - 2500
                                    inpElement.value = Convert.ToString(nTotal * 2500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00369"://No. disabled child - 9000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_9000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_9000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00375"://Amount disabled child - 9000
                                    inpElement.value = Convert.ToString(nTotal * 9000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00370"://No. disabled child - 4500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_4500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_4500"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00376"://Amount disabled child - 4500
                                    inpElement.value = Convert.ToString(nTotal * 4500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00139"://Total amount disabled child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("16");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00140"://Life insurance and providend fund
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("17");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00141"://Education and medical insurance
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("18");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;

                                case "ctl00$master1$txtF00411"://Internet Broadband weihong 
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("24");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;

                                case "ctl00$master1$txtF00412"://Differed Anuities weihong 
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("25");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                            }
                            FireInpElementEvent(inpElement, "OnBlur");
                            break;
                        #endregion

                        #region "Page 6"
                        case "BE2010Page6":
                            switch (inpElement.name)
                            {
                                case "ctl00$master1$txtF00155":
                                    dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("3");
                                    inpElement.value = dr["TCR_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00157":
                                    dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("5");
                                    inpElement.value = dr["TCR_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00160":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$master1$txtF00161":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$master1$txtF00346":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString();
                                    break;
                                case "ctl00$master1$txtF00347":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString();
                                    break;

                            }
                            break;
                        #endregion

                        #region "Page 7"
                        case "BE2010Page7":
                            switch (inpElement.name)
                            {
                                case "ctl00$master1$txtF00282":
                                    inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;

                                case "ctl00$master1$txtF00293":
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[2].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString();
                                    }
                                    break;

                                case "ctl00$master1$txtF00290":
                                    inpElement.value = dsData.Tables["P6_TAXA_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;

                                //weihong NAMA PENTADBIR HARTA PUSAKA 
                                case "ctl00$master1$txtF00183":
                                    inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;

                                //weihong NOMBOR JENIS PENGENALAN (NUMBER INDENTITY TYPE) 
                                case "ctl00$master1$txtF00185":
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[2].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString();
                                    }
                                    break;
                                //endweihong
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
                        #region "Page 1"
                        case "BE2010Page1":
                            switch (selElement.name)
                            {
                                case "ctl00$master1$ddlF00011"://Citizan
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$master1$ddlF00012"://Sex
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[2].ToString();
                                    break;
                                case "ctl00$master1$ddlF00013"://Status
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    break;
                                case "ctl00$master1$ddlF00014_Hari":////Date of Marriage/Divorce/Demise - Hari
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(0, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(0, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00014_Bulan":////Date of Marriage/Divorce/Demise - Bulan
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().IndexOf('/') + 1, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().IndexOf('/') + 1, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00016"://Type of Assessment
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "1")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[21].ToString()))
                                        {
                                            if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[21].ToString() == "1")
                                            { selElement.value = "1"; }
                                            else
                                            { selElement.value = "2"; }
                                        }
                                    }
                                    else if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "2")
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "3")
                                    {
                                        //weihong
                                        if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                        { selElement.value = "4"; }
                                        else
                                        { selElement.value = "5"; }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00018"://Public Rulings weihong
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() == "1")
                                    { selElement.value = "1"; }
                                    else
                                    { selElement.value = "2"; }
                                    break;
                                case "ctl00$master1$ddlF00024"://Correspondence Add - State
                                    selElement.value = SelectState(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[13].ToString());
                                    break;

                                case "ctl00$master1$ddlF00044"://Bank Name
                                    if (dsData.Tables["P1_SELECT_BANK"].Rows.Count > 0)
                                    {
                                        selElement.value = SelectBank(dsData.Tables["P1_SELECT_BANK"].Rows[0].ItemArray[0].ToString());
                                    }
                                    break;

                                case "ctl00$master1$ddlF00408"://Knowledge worker approval (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = "1";
                                    }
                                    else
                                    {
                                        selElement.value = "2";
                                    }
                                    FireSelElementEvent(selElement, "OnClick");
                                    break;

                                case "ctl00$master1$ddlF00409_hari"://Date Knowledge worker approval - HARI (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().Substring(0, 2);
                                    }
                                    else
                                    {
                                        selElement.value = "";
                                    }
                                    break;

                                case "ctl00$master1$ddlF00409_bln"://Date Knowledge worker approval - BULAN (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().Substring(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().IndexOf('/') + 1, 2);
                                    }
                                    else
                                    {
                                        selElement.value = "";
                                    }
                                    break;

                                case "ctl00$master1$ddlF00409_thn"://Date Knowledge worker approval - TAHUN (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().Substring(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().LastIndexOf('/') + 1, 4);
                                    }
                                    else
                                    {
                                        selElement.value = "";
                                    }
                                    break;

                                //case "ctl00$master1$ddlsurat_negara": //Negara Menyurat weihong
                                //    selElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[13].ToString();
                                //    break;
                            }
                            FireSelElementEvent(selElement, "OnChange");
                            break;
                        #endregion

                        #region "Page 2"
                        case "BE2010Page2":
                            switch (selElement.name)
                            {
                                case "ctl00$master1$ddlF00054"://Ref Prefix
                                    selElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$master1$ddlJPengenalan_isteri"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                    {
                                        selElement.value = "1";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                    {
                                        selElement.value = "4";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                    {
                                        selElement.value = "2";
                                    }
                                    break;

                                case "ctl00$master1$ddlF00054_1"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$ddlJPengenalan_isteri_1"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00054_2"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$ddlJPengenalan_isteri_2"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00054_3"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$ddlJPengenalan_isteri_3"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 3"
                        case "BE2010Page3":
                            switch (selElement.name)
                            {
                                case "ctl00$master1$ddlF00355"://Type of income transfer from husband/wife
                                    bool boolHaveBusiness = false;
                                    for (int i = 0; i < dsData.Tables["P3_TAX_PROFILE_OTHER"].Rows.Count; i++)
                                    {
                                        if (dsData.Tables["P3_TAX_PROFILE_OTHER"].Rows[i].ItemArray[11].ToString() == "1")
                                        {
                                            boolHaveBusiness = true;
                                            break;
                                        }
                                    }
                                    if (dsData.Tables["P3_TAX_PROFILE"].Rows[0].ItemArray[11].ToString() == "1" || boolHaveBusiness == true)
                                    {
                                        selElement.value = "1";//Ada pendapatan perniagaan (With business income)
                                    }
                                    else //if (dsData.Tables["P3_TAX_PROFILE"].Rows[0].ItemArray[11].ToString() == "2")
                                    {
                                        selElement.value = "2";//Tiada punca pendapatan perniagaan (Without business income)
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 7"
                        //case "BE2009Page7":
                        //    switch (selElement.name)
                        //    {
                        //        case "ctl00$master$ddlJPengenalan_mati":
                        //            if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                        //            {
                        //                selElement.value = "NEWIC";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                        //            {
                        //                selElement.value = "POLICE";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                        //            {
                        //                selElement.value = "ARMY";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                        //            {
                        //                selElement.value = "PASSPORT";
                        //            }
                        //            FireSelElementEvent(selElement, "OnChange");
                        //            break;
                        //    }
                        //    break;

                        //weihong JENIS PENGENALAN (INDENTITY TYPE)
                        case "BE200Page7":
                            switch (selElement.name)
                            {
                                case "ctl00$master$ddlJPengenalan_mati":
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        selElement.value = "1";
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        selElement.value = "4";
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        selElement.value = "2";
                                    }
                                    FireSelElementEvent(selElement, "OnChange");
                                    break;
                            }//endweihong
                            break;
                        #endregion
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void ProcessFormBE2011(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            //LEESH FEB 2012
            try
            {
                EFilingDALBE2011 dalBE = new EFilingDALBE2011(strTaxPayer, strYA, strTaxAgent);
                DataSet dsData = new DataSet();
                dsData = dalBE.GetFormDataBE2011(strPageIndex);
                dalBE.CloseConn();
                //string strComparator;
                //string strTemp;

                double nTotal = 0;
                DataRow dr;

                #region "INPUT"
                foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
                {
                    switch (strPageIndex)
                    {
                        #region "Page 1"
                        case "BE2011Page1":
                            switch (inpElement.name)
                            {
                                //case "ctl00$master$txtF00009"://IC No
                                //    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                //    break;
                                case "ctl00$master1$txtF00009"://Passport No
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$master1$txtf00014_Thn"://Date of Marriage/Divorce/Demise - Year
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().LastIndexOf('/') + 1, 4);
                                        }
                                        else
                                        {
                                            inpElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().LastIndexOf('/') + 1, 4);
                                        }
                                        else
                                        {
                                            inpElement.value = "";
                                        }
                                    }
                                    break;

                                // LEESH 14 FEB 2012
                                case "ctl00$master1$chkboxF00419": //Tax Agent Check State
                                    if (dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[1].ToString() == "1")
                                    {
                                        inpElement.value = "2";
                                        inpElement.@checked = true;
                                    }
                                    else
                                    {
                                        inpElement.value = "1";
                                        inpElement.@checked = false;
                                    }
                                    break;
                                // LEESH END


                                case "ctl00$master1$txtF00019"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                    break;
                                case "ctl00$master1$txtF00020"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                    break;
                                case "ctl00$master1$txtF00021"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                    break;
                                case "ctl00$master1$txtF00022"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[11].ToString();
                                    break;
                                case "ctl00$master1$txtF00023"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[12].ToString();
                                    break;
                                case "ctl00$master1$txtF00041"://Tel
                                    inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[14].ToString() + "-" + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[15].ToString());
                                    break;
                                case "ctl00$master1$txtF00040"://Employer No
                                    inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[16].ToString() + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[17].ToString());
                                    break;
                                case "ctl00$master1$txtF00043"://email
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[18].ToString();
                                    break;
                                //case "ctl00$master$txtF00044"://Bank Name
                                //    inpElement.value = SelectBank(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[19].ToString());
                                //    break;
                                case "ctl00$master1$txtF00045"://Bank A/C No
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[20].ToString();
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 2"
                        case "BE2011Page2":
                            switch (inpElement.name)
                            {
                                case "ctl00$master1$txtF00052"://Wife Name
                                    inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$master1$txtF00055"://Ref No
                                    inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[4].ToString());
                                    break;
                                case "ctl00$master1$txtF00057"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString());
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00052_1"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00055_1"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$master1$txtF00057_1"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$master1$txtF00052_2"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00055_2"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$master1$txtF00057_2"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$master1$txtF00052_3"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00055_3"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$master1$txtF00057_3"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$master1$btnTambah_Isteri":
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        FireInpElementEvent(inpElement, "OnClick");
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 3"
                        case "BE2011Page3":
                            switch (inpElement.name)
                            {
                                case "ctl00$master1$txtF00076"://Employment
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$master1$txtF00077"://Dividend
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$master1$txtF00078"://Interest and Discount
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString())));
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$master1$txtF00079"://Rent, royalties and premiums
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[5].ToString())));
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$master1$txtF00080"://Pension, annuities and other periodical payments
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[6].ToString()));
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$master1$txtF00081"://Other gains or profits
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[9].ToString())));
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$master1$txtF00090"://Gift to Government, State Government or local authorities
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("9");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$master1$txtF00393"://Gift to approved institutions or organization
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("1");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$master1$txtF00389"://Gift to sports activity
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("7");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$master1$txtF00390"://Gift to contribution for project of national interest
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("8");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$master1$txtF00091"://Gift artefacts, manuscript or painting
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("2");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$master1$txtF00092"://Gift of library
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("3");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$master1$txtF00093"://Gift of public facilities of disabled persons
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("4");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$master1$txtF00094"://Gift of medical equipment to any healthcare facility
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("5");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$master1$txtF00095"://Gift of National Art Gallery
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("6");
                                        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$master1$txtF00099a"://Income transfer from husband/wife
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[10].ToString();
                                    }
                                    break;
                                //LEESH 24 FEB 2012
                                case "ctl00$master1$txtF00099b":
                                    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[13].ToString();
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //LEESH END
                                case "ctl00$master1$txtF00165"://Installment/ Schedular
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[11].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[12].ToString()));
                                    }
                                    break;

                                case "ctl00$master1$txtF00417"://Gross income from employment (weihong) 
                                    //MessageBox.Show("L");
                                    if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[0].ToString()));
                                    }
                                    break;

                                case "ctl00$master1$txtF00418"://Total gross income from all sources (weihong)
                                    if (dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()));
                                        if (dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
                                        {
                                            inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()));
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                        }
                                        else
                                        {
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
                                        {
                                            inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()));
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                        }
                                        else
                                        {
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                            else
                                            {
                                                inpElement.value = "";
                                            }
                                        }
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 4"
                        case "BE2011Page4":
                            switch (inpElement.name)
                            {
                                //Preceding Years Income
                                case "ctl00$master1$txtF00169"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00170"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00171"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00172"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[3].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00173"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00174"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00175"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00176"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[3].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00177"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00178"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00179"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00180"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[3].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00361"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00362"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00363"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00364"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[3].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00365"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00366"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00367"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00368"://Provident and pension fund contribution'
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[3].ToString();
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 5"
                        case "BE2011Page5":
                            switch (inpElement.name)
                            {
                                //case "ctl00$master$txtF00104"://Individual
                                //    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("1");
                                //    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                //    break;
                                case "ctl00$master1$txtF00105"://Medical expenses for won parents
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("2");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00106"://Basic supporting equipment for disabled person
                                    //dsData.Tables["P4_TAX_RELIEF"].DefaultView.RowFilter = "TCC_KEY = 3";
                                    //inpElement.value = dsData.Tables["P4_TAX_RELIEF"].Select();
                                    //dtOverAll.PrimaryKey = new DataColumn[] { dtOverAll.Columns["ITEMNMBR"] };
                                    //dsData.Tables["P4_TAX_RELIEF"].PrimaryKey = new DataColumn[] { dsData.Tables["P4_TAX_RELIEF"].Columns["TCC_KEY"] };
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("3");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00107"://Disabled individual
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("4");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00108"://Education fees
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("5");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00109"://Medical expenses for self/ spouse/ child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("6");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00110"://Complete medical examination for self/ spouse/ child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("7");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00112"://Purchase books/ megazines
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("8");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00391"://Purchase personal computers
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("21");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00392"://Skim Simapanan Pendidikan Nasional
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("22");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00395"://Purchase sports equipment
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("23");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00404"://Housing load interest
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("9");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00116"://Husband/ wife/ payment of alimony
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("10");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00118"://Disabled husband/ wife
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("13");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00397"://No. child own self
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD"].Rows.Count);
                                    break;
                                case "ctl00$master1$txtF00398"://No. child husband/ wife
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_HW"].Rows.Count + dsData.Tables["P4_TAX_RELIEF_CHILD_HW_OTHERS"].Rows.Count);
                                    break;
                                case "ctl00$master1$txtF00396"://No. children eligible for deduction
                                    inpElement.value = Convert.ToString((dsData.Tables["P4_TAX_RELIEF_CHILD"].Rows.Count) + (dsData.Tables["P4_TAX_RELIEF_CHILD_HW"].Rows.Count) + (dsData.Tables["P4_TAX_RELIEF_CHILD_HW_OTHERS"].Rows.Count));
                                    break;
                                case "ctl00$master1$txtF00120"://No. child under 18 - 1000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_1000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_1000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00121"://Amount child under 18 - 1000
                                    inpElement.value = Convert.ToString(nTotal * 1000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00122"://No. child under 18 - 500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_500"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00123"://Amount child under 18 - 500
                                    inpElement.value = Convert.ToString(nTotal * 500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00124"://Total amount child under 18
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("14");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00357"://No. child 18 and above - 1000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_1000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_1000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00371"://Amount child 18 and above - 1000
                                    inpElement.value = Convert.ToString(nTotal * 1000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00358"://No. child 18 and above - 500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_500"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00372"://Amount child 18 and above - 500
                                    inpElement.value = Convert.ToString(nTotal * 500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00359"://No. child 18 and above - 4000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_4000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_4000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00373"://Amount child 18 and above - 4000
                                    inpElement.value = Convert.ToString(nTotal * 4000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00360"://No. child 18 and above - 2000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_2000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_2000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00374"://Amount child 18 and above - 2000
                                    inpElement.value = Convert.ToString(nTotal * 2000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00133"://Total amount child 18 and above
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("15");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00135"://No. disabled child - 5000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_5000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_5000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00136"://Amount disabled child - 5000
                                    inpElement.value = Convert.ToString(nTotal * 5000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00137"://No. disabled child - 2500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_2500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_2500"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00138"://Amount disabled child - 2500
                                    inpElement.value = Convert.ToString(nTotal * 2500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00369"://No. disabled child - 9000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_9000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_9000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00375"://Amount disabled child - 9000
                                    inpElement.value = Convert.ToString(nTotal * 9000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00370"://No. disabled child - 4500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_4500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_4500"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00376"://Amount disabled child - 4500
                                    inpElement.value = Convert.ToString(nTotal * 4500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00139"://Total amount disabled child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("16");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00140"://Life insurance and providend fund
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("17");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00141"://Education and medical insurance
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("18");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;

                                case "ctl00$master1$txtF00411"://Internet Broadband weihong 
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("24");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;

                                case "ctl00$master1$txtF00412"://Differed Anuities weihong 
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("25");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                            }
                            FireInpElementEvent(inpElement, "OnBlur");
                            break;
                        #endregion

                        #region "Page 6"
                        case "BE2011Page6":
                            switch (inpElement.name)
                            {
                                case "ctl00$master1$txtF00155":
                                    dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("3");
                                    inpElement.value = dr["TCR_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00157":
                                    dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("5");
                                    inpElement.value = dr["TCR_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00160":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$master1$txtF00161":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$master1$txtF00346":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString();
                                    break;
                                case "ctl00$master1$txtF00347":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString();
                                    break;

                            }
                            break;
                        #endregion

                        #region "Page 7"
                        case "BE2011Page7":
                            switch (inpElement.name)
                            {
                                //case "ctl00$master1$txtF00282":
                                //    inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[0].ToString();
                                //    break;

                                case "ctl00$master1$txtF00293":
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[2].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString();
                                    }
                                    break;

                                case "ctl00$master1$txtF00290":
                                    inpElement.value = dsData.Tables["P6_TAXA_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;

                                //weihong NAMA PENTADBIR HARTA PUSAKA 
                                case "ctl00$master1$txtF00183":
                                    inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;

                                //weihong NOMBOR JENIS PENGENALAN (NUMBER INDENTITY TYPE) 
                                case "ctl00$master1$txtF00185":
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[2].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString();
                                    }
                                    break;
                                //endweihong
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
                        #region "Page 1"
                        case "BE2011Page1":
                            switch (selElement.name)
                            {
                                case "ctl00$master1$ddlF00011"://Citizan
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$master1$ddlF00012"://Sex
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[2].ToString();
                                    break;
                                case "ctl00$master1$ddlF00013"://Status
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    break;
                                case "ctl00$master1$ddlF00014_Hari":////Date of Marriage/Divorce/Demise - Hari
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(0, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(0, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00014_Bulan":////Date of Marriage/Divorce/Demise - Bulan
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().IndexOf('/') + 1, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().IndexOf('/') + 1, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00016"://Type of Assessment
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "1")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[21].ToString()))
                                        {
                                            if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[21].ToString() == "1")
                                            { selElement.value = "1"; }
                                            else
                                            { selElement.value = "2"; }
                                        }
                                    }
                                    else if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "2")
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "3")
                                    {
                                        //weihong
                                        if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                        { selElement.value = "4"; }
                                        else
                                        { selElement.value = "5"; }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00018"://Public Rulings weihong
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() == "1")
                                    { selElement.value = "1"; }
                                    else
                                    { selElement.value = "2"; }
                                    break;
                                case "ctl00$master1$ddlF00024"://Correspondence Add - State
                                    selElement.value = SelectState(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[13].ToString());
                                    break;

                                case "ctl00$master1$ddlF00044"://Bank Name
                                    if (dsData.Tables["P1_SELECT_BANK"].Rows.Count > 0)
                                    {
                                        selElement.value = SelectBank(dsData.Tables["P1_SELECT_BANK"].Rows[0].ItemArray[0].ToString());
                                    }
                                    break;

                                case "ctl00$master1$ddlF00408"://Knowledge worker approval (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = "1";
                                    }
                                    else
                                    {
                                        selElement.value = "2";
                                    }
                                    FireSelElementEvent(selElement, "OnClick");
                                    break;

                                case "ctl00$master1$ddlF00409_hari"://Date Knowledge worker approval - HARI (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().Substring(0, 2);
                                    }
                                    else
                                    {
                                        selElement.value = "";
                                    }
                                    break;

                                case "ctl00$master1$ddlF00409_bln"://Date Knowledge worker approval - BULAN (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().Substring(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().IndexOf('/') + 1, 2);
                                    }
                                    else
                                    {
                                        selElement.value = "";
                                    }
                                    break;

                                case "ctl00$master1$ddlF00409_thn"://Date Knowledge worker approval - TAHUN (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().Substring(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().LastIndexOf('/') + 1, 4);
                                    }
                                    else
                                    {
                                        selElement.value = "";
                                    }
                                    break;

                                //case "ctl00$master1$ddlsurat_negara": //Negara Menyurat weihong
                                //    selElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[13].ToString();
                                //    break;
                            }
                            FireSelElementEvent(selElement, "OnChange");
                            break;
                        #endregion

                        #region "Page 2"
                        case "BE2011Page2":
                            switch (selElement.name)
                            {
                                case "ctl00$master1$ddlF00054"://Ref Prefix
                                    selElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$master1$ddlJPengenalan_isteri"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                    {
                                        selElement.value = "1";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                    {
                                        selElement.value = "4";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                    {
                                        selElement.value = "2";
                                    }
                                    break;

                                case "ctl00$master1$ddlF00054_1"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$ddlJPengenalan_isteri_1"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00054_2"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$ddlJPengenalan_isteri_2"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00054_3"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$ddlJPengenalan_isteri_3"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 3"
                        case "BE2011Page3":
                            switch (selElement.name)
                            {
                                case "ctl00$master1$ddlF00355"://Type of income transfer from husband/wife
                                    bool boolHaveBusiness = false;
                                    for (int i = 0; i < dsData.Tables["P3_TAX_PROFILE_OTHER"].Rows.Count; i++)
                                    {
                                        if (dsData.Tables["P3_TAX_PROFILE_OTHER"].Rows[i].ItemArray[11].ToString() == "1")
                                        {
                                            boolHaveBusiness = true;
                                            break;
                                        }
                                    }
                                    if (dsData.Tables["P3_TAX_PROFILE"].Rows[0].ItemArray[11].ToString() == "1" || boolHaveBusiness == true)
                                    {
                                        selElement.value = "1";//Ada pendapatan perniagaan (With business income)
                                    }
                                    else //if (dsData.Tables["P3_TAX_PROFILE"].Rows[0].ItemArray[11].ToString() == "2")
                                    {
                                        selElement.value = "2";//Tiada punca pendapatan perniagaan (Without business income)
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 7"
                        //case "BE2009Page7":
                        //    switch (selElement.name)
                        //    {
                        //        case "ctl00$master$ddlJPengenalan_mati":
                        //            if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                        //            {
                        //                selElement.value = "NEWIC";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                        //            {
                        //                selElement.value = "POLICE";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                        //            {
                        //                selElement.value = "ARMY";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                        //            {
                        //                selElement.value = "PASSPORT";
                        //            }
                        //            FireSelElementEvent(selElement, "OnChange");
                        //            break;
                        //    }
                        //    break;

                        //weihong JENIS PENGENALAN (INDENTITY TYPE)
                        case "BE2011Page7":
                            switch (selElement.name)
                            {
                                case "ctl00$master$ddlJPengenalan_mati":
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        selElement.value = "1";
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        selElement.value = "4";
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        selElement.value = "2";
                                    }
                                    FireSelElementEvent(selElement, "OnChange");
                                    break;
                            }//endweihong
                            break;
                        #endregion
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            //LEESH END
        }

        private void ProcessFormBE2012(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            //dannylee 15/02/2013
            try
            {
                EFilingDALBE2012 dalBE = new EFilingDALBE2012(strTaxPayer, strYA, strTaxAgent);
                DataSet dsData = new DataSet();
                dsData = dalBE.GetFormDataBE2012(strPageIndex);
                dalBE.CloseConn();
                //string strComparator;
                //string strTemp;

                double nTotal = 0;
                DataRow dr;

                #region "INPUT"
                foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
                {
                    switch (strPageIndex)
                    {
                        #region "Page 1"
                        case "BE2012Page1":
                            switch (inpElement.name)
                            {
                                //case "ctl00$master$txtF00009"://IC No
                                //    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                //    break;
                                case "ctl00$master1$txtF00009"://Passport No
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$master1$txtf00014_Thn"://Date of Marriage/Divorce/Demise - Year
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().LastIndexOf('/') + 1, 4);
                                        }
                                        else
                                        {
                                            inpElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().LastIndexOf('/') + 1, 4);
                                        }
                                        else
                                        {
                                            inpElement.value = "";
                                        }
                                    }
                                    break;

                                // LEESH 14 FEB 2012
                                case "ctl00$master1$chkboxF00419": //Tax Agent Check State
                                    if (dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[1].ToString() == "1")
                                    {
                                        inpElement.value = "2";
                                        inpElement.@checked = true;
                                    }
                                    else
                                    {
                                        inpElement.value = "1";
                                        inpElement.@checked = false;
                                    }
                                    break;
                                // LEESH END


                                case "ctl00$master1$txtF00019"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                    break;
                                case "ctl00$master1$txtF00020"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                    break;
                                case "ctl00$master1$txtF00021"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                    break;
                                case "ctl00$master1$txtF00022"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[11].ToString();
                                    break;
                                case "ctl00$master1$txtF00023"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[12].ToString();
                                    break;
                                case "ctl00$master1$txtF00041"://Tel
                                    inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[14].ToString() + "-" + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[15].ToString());
                                    break;
                                case "ctl00$master1$txtF00040"://Employer No
                                    inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[16].ToString() + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[17].ToString());
                                    break;
                                case "ctl00$master1$txtF00043"://email
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[18].ToString();
                                    break;
                                //case "ctl00$master$txtF00044"://Bank Name
                                //    inpElement.value = SelectBank(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[19].ToString());
                                //    break;
                                case "ctl00$master1$txtF00045"://Bank A/C No
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[20].ToString();
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 2"
                        case "BE2012Page2":
                            switch (inpElement.name)
                            {
                                case "ctl00$master1$txtF00052"://Wife Name
                                    inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$master1$txtF00055"://Ref No
                                    inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[4].ToString());
                                    break;
                                case "ctl00$master1$txtF00057"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString());
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00052_1"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00055_1"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$master1$txtF00057_1"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$master1$txtF00052_2"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00055_2"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$master1$txtF00057_2"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$master1$txtF00052_3"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00055_3"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$master1$txtF00057_3"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$master1$btnTambah_Isteri":
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        FireInpElementEvent(inpElement, "OnClick");
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 3"
                        case "BE2012Page3":
                            switch (inpElement.name)
                            {
                                case "ctl00$master1$txtF00076"://Employment
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$master1$txtF00077"://Dividend
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;

                                //case "ctl00$master1$txtF00078"://Interest and Discount
                                //    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                //    {
                                //        inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString())));
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;

                                //DANNYLEE 15 FEB 2013
                                case "ctl00$master1$txtF00078"://Interest, Discount, Royalty, Premium and etc..
                                    if (dsData.Tables["P3_INCOME_EXCLUDE_RENTAL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_INCOME_EXCLUDE_RENTAL"].Rows[0].ItemArray[0].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //END
                                //DANNYLEE 15 FEB 2013
                                case "ctl00$master1$txtF00079"://Rent
                                    if (dsData.Tables["P3_DIVIDEND_RENTAL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_DIVIDEND_RENTAL"].Rows[0].ItemArray[1].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //END
                                case "ctl00$master1$txtF00080"://Pension, annuities and other periodical payments
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[6].ToString()));
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$master1$txtF00081"://Other gains or profits
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[9].ToString())));
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$master1$txtF00090"://Gift to Government, State Government or local authorities
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("9");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$master1$txtF00393"://Gift to approved institutions or organization
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("1");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$master1$txtF00389"://Gift to sports activity
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("7");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$master1$txtF00390"://Gift to contribution for project of national interest
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("8");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$master1$txtF00091"://Gift artefacts, manuscript or painting
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("2");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$master1$txtF00092"://Gift of library
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("3");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$master1$txtF00093"://Gift of public facilities of disabled persons
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("4");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$master1$txtF00094"://Gift of medical equipment to any healthcare facility
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("5");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$master1$txtF00095"://Gift of National Art Gallery
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("6");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //dannylee 21/02/2013
                                case "ctl00$master1$txtjum_derma"://Approved Donations/Gifts/Contributions
                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_GIFTS"].Rows[0].ItemArray[0].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //end
                                case "ctl00$master1$txtF00099"://Income transfer from husband/wife
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[10].ToString();
                                    }
                                    break;
                                //LEESH 24 FEB 2012
                                case "ctl00$master1$txtF00099b":
                                    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[13].ToString();
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //LEESH END
                                case "ctl00$master1$txtF00165"://Installment/ Schedular
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[11].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[12].ToString()));
                                    }
                                    break;

                                case "ctl00$master1$txtF00417"://Gross income from employment (weihong) 
                                    //MessageBox.Show("L");
                                    if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[0].ToString()));
                                    }
                                    break;

                                case "ctl00$master1$txtF00418"://Total gross income from all sources (weihong)
                                    if (dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()));
                                        if (dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
                                        {
                                            inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()));
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                        }
                                        else
                                        {
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
                                        {
                                            inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()));
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                        }
                                        else
                                        {
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                            else
                                            {
                                                inpElement.value = "";
                                            }
                                        }
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 4"
                        case "BE2012Page4":
                            switch (inpElement.name)
                            {
                                //Preceding Years Income
                                case "ctl00$master1$txtF00169"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00170"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00171"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00172"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[3].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00173"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00174"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00175"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00176"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[3].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00177"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00178"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00179"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00180"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[3].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00361"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00362"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00363"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00364"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[3].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00365"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00366"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00367"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[2].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00368"://Provident and pension fund contribution'
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[3].ToString();
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 5"
                        case "BE2012Page5":
                            switch (inpElement.name)
                            {
                                //case "ctl00$master$txtF00104"://Individual
                                //    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("1");
                                //    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                //    break;
                                case "ctl00$master1$txtF00105"://Medical expenses for won parents
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("2");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00106"://Basic supporting equipment for disabled person
                                    //dsData.Tables["P4_TAX_RELIEF"].DefaultView.RowFilter = "TCC_KEY = 3";
                                    //inpElement.value = dsData.Tables["P4_TAX_RELIEF"].Select();
                                    //dtOverAll.PrimaryKey = new DataColumn[] { dtOverAll.Columns["ITEMNMBR"] };
                                    //dsData.Tables["P4_TAX_RELIEF"].PrimaryKey = new DataColumn[] { dsData.Tables["P4_TAX_RELIEF"].Columns["TCC_KEY"] };
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("3");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00107"://Disabled individual
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("4");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00108"://Education fees
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("5");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00109"://Medical expenses for self/ spouse/ child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("6");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00110"://Complete medical examination for self/ spouse/ child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("7");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00112"://Purchase books/ megazines
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("8");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00391"://Purchase personal computers
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("21");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00392"://Skim Simapanan Pendidikan Nasional
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("22");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00395"://Purchase sports equipment
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("23");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00404"://Housing load interest
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("9");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00116"://Husband/ wife/ payment of alimony
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("10");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00118"://Disabled husband/ wife
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("13");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00397"://No. child own self
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD"].Rows.Count);
                                    break;
                                case "ctl00$master1$txtF00398"://No. child husband/ wife
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_HW"].Rows.Count + dsData.Tables["P4_TAX_RELIEF_CHILD_HW_OTHERS"].Rows.Count);
                                    break;
                                case "ctl00$master1$txtF00396"://No. children eligible for deduction
                                    inpElement.value = Convert.ToString((dsData.Tables["P4_TAX_RELIEF_CHILD"].Rows.Count) + (dsData.Tables["P4_TAX_RELIEF_CHILD_HW"].Rows.Count) + (dsData.Tables["P4_TAX_RELIEF_CHILD_HW_OTHERS"].Rows.Count));
                                    break;
                                case "ctl00$master1$txtF00120"://No. child under 18 - 1000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_1000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_1000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00121"://Amount child under 18 - 1000
                                    inpElement.value = Convert.ToString(nTotal * 1000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00122"://No. child under 18 - 500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_500"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00123"://Amount child under 18 - 500
                                    inpElement.value = Convert.ToString(nTotal * 500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00124"://Total amount child under 18
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("14");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00357"://No. child 18 and above - 1000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_1000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_1000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00371"://Amount child 18 and above - 1000
                                    inpElement.value = Convert.ToString(nTotal * 1000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00358"://No. child 18 and above - 500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_500"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00372"://Amount child 18 and above - 500
                                    inpElement.value = Convert.ToString(nTotal * 500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00359"://No. child 18 and above - 4000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_4000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_4000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00373"://Amount child 18 and above - 4000
                                    inpElement.value = Convert.ToString(nTotal * 4000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00360"://No. child 18 and above - 2000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_2000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_2000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00374"://Amount child 18 and above - 2000
                                    inpElement.value = Convert.ToString(nTotal * 2000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00133"://Total amount child 18 and above
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("15");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00135"://No. disabled child - 5000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_5000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_5000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00136"://Amount disabled child - 5000
                                    inpElement.value = Convert.ToString(nTotal * 5000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00137"://No. disabled child - 2500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_2500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_2500"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00138"://Amount disabled child - 2500
                                    inpElement.value = Convert.ToString(nTotal * 2500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00369"://No. disabled child - 9000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_9000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_9000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00375"://Amount disabled child - 9000
                                    inpElement.value = Convert.ToString(nTotal * 9000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00370"://No. disabled child - 4500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_4500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_4500"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00376"://Amount disabled child - 4500
                                    inpElement.value = Convert.ToString(nTotal * 4500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00139"://Total amount disabled child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("16");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00140"://Life insurance and providend fund
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("17");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00141"://Education and medical insurance
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("18");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;

                                case "ctl00$master1$txtF00411"://Internet Broadband weihong 
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("24");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;

                                case "ctl00$master1$txtF00412"://Differed Anuities weihong 
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("25");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                            }
                            FireInpElementEvent(inpElement, "OnBlur");
                            break;
                        #endregion

                        #region "Page 6"
                        case "BE2012Page6":
                            switch (inpElement.name)
                            {
                                case "ctl00$master1$txtF00155":
                                    dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("3");
                                    inpElement.value = dr["TCR_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00157":
                                    dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("5");
                                    inpElement.value = dr["TCR_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00160":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$master1$txtF00161":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$master1$txtF00346":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString();
                                    break;
                                //case "ctl00$master1$txtF00347":
                                //    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString();
                                //    break;

                            }
                            break;
                        #endregion

                        #region "Page 7"
                        case "BE2012Page7":
                            switch (inpElement.name)
                            {
                                //case "ctl00$master1$txtF00282":
                                //    inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[0].ToString();
                                //    break;

                                case "ctl00$master1$txtF00293":
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[2].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString();
                                    }
                                    break;

                                case "ctl00$master1$txtF00290":
                                    inpElement.value = dsData.Tables["P6_TAXA_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;

                                //weihong NAMA PENTADBIR HARTA PUSAKA 
                                case "ctl00$master1$txtF00183":
                                    inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;

                                //weihong NOMBOR JENIS PENGENALAN (NUMBER INDENTITY TYPE) 
                                case "ctl00$master1$txtF00185":
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[2].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString();
                                    }
                                    break;
                                //endweihong
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
                        #region "Page 1"
                        case "BE2012Page1":
                            switch (selElement.name)
                            {
                                case "ctl00$master1$ddlF00011"://Citizan
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$master1$ddlF00012"://Sex
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[2].ToString();
                                    break;
                                case "ctl00$master1$ddlF00013"://Status
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    break;
                                case "ctl00$master1$ddlF00014_Hari":////Date of Marriage/Divorce/Demise - Hari
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(0, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(0, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00014_Bulan":////Date of Marriage/Divorce/Demise - Bulan
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().IndexOf('/') + 1, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().IndexOf('/') + 1, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00016"://Type of Assessment
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "1")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[21].ToString()))
                                        {
                                            if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[21].ToString() == "1")
                                            { selElement.value = "1"; }
                                            else
                                            { selElement.value = "2"; }
                                        }
                                    }
                                    else if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "2")
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "3")
                                    {
                                        //weihong
                                        if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                        { selElement.value = "4"; }
                                        else
                                        { selElement.value = "5"; }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00018"://Public Rulings weihong
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() == "1")
                                    { selElement.value = "1"; }
                                    else
                                    { selElement.value = "2"; }
                                    break;
                                case "ctl00$master1$ddlF00024"://Correspondence Add - State
                                    selElement.value = SelectState(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[13].ToString());
                                    break;

                                case "ctl00$master1$ddlF00044"://Bank Name
                                    if (dsData.Tables["P1_SELECT_BANK"].Rows.Count > 0)
                                    {
                                        selElement.value = SelectBank(dsData.Tables["P1_SELECT_BANK"].Rows[0].ItemArray[0].ToString());
                                    }
                                    break;

                                case "ctl00$master1$ddlF00408"://Knowledge worker approval (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = "1";
                                    }
                                    else
                                    {
                                        selElement.value = "2";
                                    }
                                    FireSelElementEvent(selElement, "OnClick");
                                    break;

                                case "ctl00$master1$ddlF00409_hari"://Date Knowledge worker approval - HARI (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().Substring(0, 2);
                                    }
                                    else
                                    {
                                        selElement.value = "";
                                    }
                                    break;

                                case "ctl00$master1$ddlF00409_bln"://Date Knowledge worker approval - BULAN (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().Substring(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().IndexOf('/') + 1, 2);
                                    }
                                    else
                                    {
                                        selElement.value = "";
                                    }
                                    break;

                                case "ctl00$master1$ddlF00409_thn"://Date Knowledge worker approval - TAHUN (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().Substring(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().LastIndexOf('/') + 1, 4);
                                    }
                                    else
                                    {
                                        selElement.value = "";
                                    }
                                    break;

                                //case "ctl00$master1$ddlsurat_negara": //Negara Menyurat weihong
                                //    selElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[13].ToString();
                                //    break;
                            }
                            FireSelElementEvent(selElement, "OnChange");
                            break;
                        #endregion

                        #region "Page 2"
                        case "BE2012Page2":
                            switch (selElement.name)
                            {
                                case "ctl00$master1$ddlF00054"://Ref Prefix
                                    selElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$master1$ddlJPengenalan_isteri"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                    {
                                        selElement.value = "1";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                    {
                                        selElement.value = "4";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                    {
                                        selElement.value = "2";
                                    }
                                    break;

                                case "ctl00$master1$ddlF00054_1"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$ddlJPengenalan_isteri_1"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00054_2"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$ddlJPengenalan_isteri_2"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00054_3"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$ddlJPengenalan_isteri_3"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 3"
                        case "BE2012Page3":
                            switch (selElement.name)
                            {
                                case "ctl00$master1$ddlF00355"://Type of income transfer from husband/wife
                                    bool boolHaveBusiness = false;
                                    for (int i = 0; i < dsData.Tables["P3_TAX_PROFILE_OTHER"].Rows.Count; i++)
                                    {
                                        if (dsData.Tables["P3_TAX_PROFILE_OTHER"].Rows[i].ItemArray[11].ToString() == "1")
                                        {
                                            boolHaveBusiness = true;
                                            break;
                                        }
                                    }
                                    if (dsData.Tables["P3_TAX_PROFILE"].Rows[0].ItemArray[11].ToString() == "1" || boolHaveBusiness == true)
                                    {
                                        selElement.value = "1";//Ada pendapatan perniagaan (With business income)
                                    }
                                    else //if (dsData.Tables["P3_TAX_PROFILE"].Rows[0].ItemArray[11].ToString() == "2")
                                    {
                                        selElement.value = "2";//Tiada punca pendapatan perniagaan (Without business income)
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 7"
                        //case "BE2009Page7":
                        //    switch (selElement.name)
                        //    {
                        //        case "ctl00$master$ddlJPengenalan_mati":
                        //            if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                        //            {
                        //                selElement.value = "NEWIC";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                        //            {
                        //                selElement.value = "POLICE";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                        //            {
                        //                selElement.value = "ARMY";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                        //            {
                        //                selElement.value = "PASSPORT";
                        //            }
                        //            FireSelElementEvent(selElement, "OnChange");
                        //            break;
                        //    }
                        //    break;

                        //weihong JENIS PENGENALAN (INDENTITY TYPE)
                        case "BE2012Page7":
                            switch (selElement.name)
                            {
                                case "ctl00$master1$ddlJPengenalan_mati":
                                    //selElement.removeAttribute("selected", 1);
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        selElement.value = "1";
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        selElement.value = "4"; ;
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        selElement.value = "2";
                                    }
                                    FireSelElementEvent(selElement, "OnChange");
                                    break;
                            }//endweihong
                            break;
                        #endregion
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            //dannylee end
        }

        private void ProcessFormBE2013(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            //dannylee 15/02/2013
            try
            {
                EFilingDALBE2013 dalBE = new EFilingDALBE2013(strTaxPayer, strYA, strTaxAgent);
                DataSet dsData = new DataSet();
                dsData = dalBE.GetFormDataBE2013(strPageIndex);
                dalBE.CloseConn();
                //string strComparator;
                //string strTemp;

                double nTotal = 0;
                DataRow dr;

                #region "INPUT"
                foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
                {
                    switch (strPageIndex)
                    {
                        #region "Page 1"
                        case "BE2013Page1":
                            switch (inpElement.name)
                            {
                                //case "ctl00$master$txtF00009"://IC No
                                //    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                //    break;
                                case "ctl00$master1$txtF00009"://Passport No
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$master1$txtf00014_Thn"://Date of Marriage/Divorce/Demise - Year
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().LastIndexOf('/') + 1, 4);
                                        }
                                        else
                                        {
                                            inpElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().LastIndexOf('/') + 1, 4);
                                        }
                                        else
                                        {
                                            inpElement.value = "";
                                        }
                                    }
                                    break;

                                // LEESH 14 FEB 2012
                                case "ctl00$master1$chkboxF00419": //Tax Agent Check State
                                    if (dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[1].ToString() == "1")
                                    {
                                        inpElement.value = "2";
                                        inpElement.@checked = true;
                                    }
                                    else
                                    {
                                        inpElement.value = "1";
                                        inpElement.@checked = false;
                                    }
                                    break;
                                // LEESH END


                                case "ctl00$master1$txtF00019"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                    break;
                                case "ctl00$master1$txtF00020"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                    break;
                                case "ctl00$master1$txtF00021"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                    break;
                                case "ctl00$master1$txtF00022"://Postcode
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[11].ToString();
                                    break;
                                case "ctl00$master1$txtF00023"://City
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[12].ToString();
                                    break;
                                case "ctl00$master1$txtF00041"://Tel
                                    inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[14].ToString() + "-" + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[15].ToString());
                                    break;
                                case "ctl00$master1$txtF00040"://Employer No
                                    inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[16].ToString() + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[17].ToString());
                                    break;
                                case "ctl00$master1$txtF00043"://email
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[18].ToString();
                                    break;
                                //case "ctl00$master$txtF00044"://Bank Name
                                //    inpElement.value = SelectBank(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[19].ToString());
                                //    break;
                                case "ctl00$master1$txtF00045"://Bank A/C No
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[20].ToString();
                                    break;

                                //simkh 2014
                                case "ctl00$master1$txtF00052"://Wife Name
                                    inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$master1$txtF00055"://Ref No
                                    inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[4].ToString());
                                    break;
                                case "ctl00$master1$txtF00057"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString());
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                    }
                                    break;
                                //simkh 2014 end
                            }
                            break;
                        #endregion

                        #region "Page 2"
                        case "BE2013Page2":
                            switch (inpElement.name)
                            {
                                //case "ctl00$master1$txtF00052"://Wife Name
                                //    inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                //    break;
                                //case "ctl00$master1$txtF00055"://Ref No
                                //    inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[4].ToString());
                                //    break;
                                //case "ctl00$master1$txtF00057"://IC No/ Police No/ Army No/ Passport No
                                //    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                //    {
                                //        inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString());
                                //    }
                                //    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                //    {
                                //        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                //    }
                                //    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                //    {
                                //        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                //    }
                                //    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                //    {
                                //        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                //    }
                                //    break;
                                case "ctl00$master1$txtF00052_1"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00055_1"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$master1$txtF00057_1"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$master1$txtF00052_2"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00055_2"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$master1$txtF00057_2"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$master1$txtF00052_3"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$master1$txtF00055_3"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$master1$txtF00057_3"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$master1$btnTambah_Isteri":
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        FireInpElementEvent(inpElement, "OnClick");
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 3"
                        case "BE2013Page3":
                            switch (inpElement.name)
                            {
                                case "ctl00$master1$txtF00076"://Employment
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$master1$txtF00077"://Dividend
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;

                                //case "ctl00$master1$txtF00078"://Interest and Discount
                                //    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                //    {
                                //        inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString())));
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;

                                //DANNYLEE 15 FEB 2013
                                case "ctl00$master1$txtF00078"://Interest, Discount, Royalty, Premium and etc..
                                    if (dsData.Tables["P3_INCOME_EXCLUDE_RENTAL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_INCOME_EXCLUDE_RENTAL"].Rows[0].ItemArray[0].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //END
                                //DANNYLEE 15 FEB 2013
                                case "ctl00$master1$txtF00079"://Rent
                                    if (dsData.Tables["P3_DIVIDEND_RENTAL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_DIVIDEND_RENTAL"].Rows[0].ItemArray[1].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //END
                                case "ctl00$master1$txtF00080"://Pension, annuities and other periodical payments
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[6].ToString()));
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$master1$txtF00081"://Other gains or profits
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[9].ToString())));
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$master1$txtF00090"://Gift to Government, State Government or local authorities
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("9");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$master1$txtF00393"://Gift to approved institutions or organization
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("1");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$master1$txtF00389"://Gift to sports activity
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("7");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$master1$txtF00390"://Gift to contribution for project of national interest
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("8");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$master1$txtF00091"://Gift artefacts, manuscript or painting
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("2");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$master1$txtF00092"://Gift of library
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("3");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$master1$txtF00093"://Gift of public facilities of disabled persons
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("4");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$master1$txtF00094"://Gift of medical equipment to any healthcare facility
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("5");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$master1$txtF00095"://Gift of National Art Gallery
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("6");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //dannylee 21/02/2013

                                //simkh 2014
                                case "ctl00$master1$txtF00096": //Gift and donation

                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_GIFTS"].Rows[0].ItemArray[0].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //simkh end

                                //case "ctl00$master1$txtjum_derma"://Approved Donations/Gifts/Contributions
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        inpElement.value = dsData.Tables["P3_TAX_GIFTS"].Rows[0].ItemArray[0].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                ////end
                                case "ctl00$master1$txtF00099"://Income transfer from husband/wife
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[10].ToString();
                                    }
                                    break;
                                //LEESH 24 FEB 2012
                                case "ctl00$master1$txtF00099b":
                                    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[13].ToString();
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //LEESH END
                                case "ctl00$master1$txtF00165"://Installment/ Schedular
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[11].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[12].ToString()));
                                    }
                                    break;

                                case "ctl00$master1$txtF00417"://Gross income from employment (weihong) 
                                    //MessageBox.Show("L");
                                    if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[0].ToString()));
                                    }
                                    break;

                                case "ctl00$master1$txtF00418"://Total gross income from all sources (weihong)
                                    if (dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()));
                                        if (dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
                                        {
                                            inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()));
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                        }
                                        else
                                        {
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
                                        {
                                            inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()));
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                        }
                                        else
                                        {
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                            else
                                            {
                                                inpElement.value = "";
                                            }
                                        }
                                    }
                                    break;

                                case "ctl00$master1$txtF00169"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[0].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$master1$txtF00170"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[1].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$master1$txtF00171"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[2].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$master1$txtF00172"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[3].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$master1$txtF00173"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[0].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$master1$txtF00174"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[1].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$master1$txtF00175"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[2].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$master1$txtF00176"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[3].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 4"
                        case "BE2013Page4":
                        //    switch (inpElement.name)
                        //    {
                        //        //Preceding Years Income
                        //        case "ctl00$master1$txtF00169"://Type of income
                        //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                        //            {
                        //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[0].ToString();
                        //            }
                        //            break;
                        //        case "ctl00$master1$txtF00170"://Year for which paid
                        //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                        //            {
                        //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[1].ToString();
                        //            }
                        //            break;
                        //        case "ctl00$master1$txtF00171"://Gross Amount
                        //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                        //            {
                        //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[2].ToString();
                        //            }
                        //            break;
                        //        case "ctl00$master1$txtF00172"://Provident and pension fund contribution
                        //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                        //            {
                        //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[3].ToString();
                        //            }
                        //            break;
                        //        case "ctl00$master1$txtF00173"://Type of income
                        //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                        //            {
                        //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[0].ToString();
                        //            }
                        //            break;
                        //        case "ctl00$master1$txtF00174"://Year for which paid
                        //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                        //            {
                        //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[1].ToString();
                        //            }
                        //            break;
                        //        case "ctl00$master1$txtF00175"://Gross Amount
                        //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                        //            {
                        //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[2].ToString();
                        //            }
                        //            break;
                        //        case "ctl00$master1$txtF00176"://Provident and pension fund contribution
                        //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                        //            {
                        //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[3].ToString();
                        //            }
                        //            break;
                        //        case "ctl00$master1$txtF00177"://Type of income
                        //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                        //            {
                        //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[0].ToString();
                        //            }
                        //            break;
                        //        case "ctl00$master1$txtF00178"://Year for which paid
                        //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                        //            {
                        //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[1].ToString();
                        //            }
                        //            break;
                        //        case "ctl00$master1$txtF00179"://Gross Amount
                        //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                        //            {
                        //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[2].ToString();
                        //            }
                        //            break;
                        //        case "ctl00$master1$txtF00180"://Provident and pension fund contribution
                        //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                        //            {
                        //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[3].ToString();
                        //            }
                        //            break;
                        //        case "ctl00$master1$txtF00361"://Type of income
                        //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                        //            {
                        //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[0].ToString();
                        //            }
                        //            break;
                        //        case "ctl00$master1$txtF00362"://Year for which paid
                        //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                        //            {
                        //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[1].ToString();
                        //            }
                        //            break;
                        //        case "ctl00$master1$txtF00363"://Gross Amount
                        //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                        //            {
                        //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[2].ToString();
                        //            }
                        //            break;
                        //        case "ctl00$master1$txtF00364"://Provident and pension fund contribution
                        //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                        //            {
                        //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[3].ToString();
                        //            }
                        //            break;
                        //        case "ctl00$master1$txtF00365"://Type of income
                        //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                        //            {
                        //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[0].ToString();
                        //            }
                        //            break;
                        //        case "ctl00$master1$txtF00366"://Year for which paid
                        //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                        //            {
                        //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[1].ToString();
                        //            }
                        //            break;
                        //        case "ctl00$master1$txtF00367"://Gross Amount
                        //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                        //            {
                        //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[2].ToString();
                        //            }
                        //            break;
                        //        case "ctl00$master1$txtF00368"://Provident and pension fund contribution'
                        //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                        //            {
                        //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[3].ToString();
                        //            }
                        //            break;
                        //    }
                        //    break;
                        #endregion

                        #region "Page 5"
                        case "BE2013Page5":
                            switch (inpElement.name)
                            {
                                case "ctl00$master$txtF00104"://Individual
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("1");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00105"://Medical expenses for won parents
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("2");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00106"://Basic supporting equipment for disabled person
                                    //dsData.Tables["P4_TAX_RELIEF"].DefaultView.RowFilter = "TCC_KEY = 3";
                                    //inpElement.value = dsData.Tables["P4_TAX_RELIEF"].Select();
                                    //dtOverAll.PrimaryKey = new DataColumn[] { dtOverAll.Columns["ITEMNMBR"] };
                                    //dsData.Tables["P4_TAX_RELIEF"].PrimaryKey = new DataColumn[] { dsData.Tables["P4_TAX_RELIEF"].Columns["TCC_KEY"] };
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("3");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00107"://Disabled individual
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("4");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00108"://Education fees
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("5");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00109"://Medical expenses for self/ spouse/ child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("6");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00110"://Complete medical examination for self/ spouse/ child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("7");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00112"://Purchase books/ megazines
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("8");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00391"://Purchase personal computers
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("21");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00392"://Skim Simapanan Pendidikan Nasional
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("22");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00395"://Purchase sports equipment
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("23");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00404"://Housing load interest
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("9");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00116"://Husband/ wife/ payment of alimony
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("10");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00118"://Disabled husband/ wife
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("13");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00397"://No. child own self
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD"].Rows.Count);
                                    break;
                                case "ctl00$master1$txtF00398"://No. child husband/ wife
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_HW"].Rows.Count + dsData.Tables["P4_TAX_RELIEF_CHILD_HW_OTHERS"].Rows.Count);
                                    break;
                                case "ctl00$master1$txtF00396"://No. children eligible for deduction
                                    inpElement.value = Convert.ToString((dsData.Tables["P4_TAX_RELIEF_CHILD"].Rows.Count) + (dsData.Tables["P4_TAX_RELIEF_CHILD_HW"].Rows.Count) + (dsData.Tables["P4_TAX_RELIEF_CHILD_HW_OTHERS"].Rows.Count));
                                    break;
                                case "ctl00$master1$txtF00120"://No. child under 18 - 1000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_1000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_1000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00121"://Amount child under 18 - 1000
                                    inpElement.value = Convert.ToString(nTotal * 1000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00122"://No. child under 18 - 500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_500"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00123"://Amount child under 18 - 500
                                    inpElement.value = Convert.ToString(nTotal * 500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00124"://Total amount child under 18
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("14");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00357"://No. child 18 and above - 1000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_1000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_1000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00371"://Amount child 18 and above - 1000
                                    inpElement.value = Convert.ToString(nTotal * 1000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00358"://No. child 18 and above - 500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_500"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00372"://Amount child 18 and above - 500
                                    inpElement.value = Convert.ToString(nTotal * 500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00359"://No. child 18 and above - 4000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_4000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_4000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00373"://Amount child 18 and above - 4000
                                    inpElement.value = Convert.ToString(nTotal * 6000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00360"://No. child 18 and above - 2000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_2000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_2000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00374"://Amount child 18 and above - 2000
                                    inpElement.value = Convert.ToString(nTotal * 3000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00133"://Total amount child 18 and above
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("15");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00135"://No. disabled child - 5000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_5000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_5000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00136"://Amount disabled child - 5000
                                    inpElement.value = Convert.ToString(nTotal * 5000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00137"://No. disabled child - 2500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_2500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_2500"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00138"://Amount disabled child - 2500
                                    inpElement.value = Convert.ToString(nTotal * 2500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00369"://No. disabled child - 9000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_9000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_9000"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00375"://Amount disabled child - 9000
                                    inpElement.value = Convert.ToString(nTotal * 11000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00370"://No. disabled child - 4500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_4500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_4500"].Rows.Count;
                                    break;
                                case "ctl00$master1$txtF00376"://Amount disabled child - 4500
                                    inpElement.value = Convert.ToString(nTotal * 5500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$master1$txtF00139"://Total amount disabled child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("16");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00140"://Life insurance and providend fund
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("17");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00141"://Education and medical insurance
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("18");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;

                                case "ctl00$master1$txtF00411"://Internet Broadband weihong 
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("24");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;

                                case "ctl00$master1$txtF00412"://Differed Anuities weihong 
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("25");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;

                                //simkh 2014
                                case "ctl00$master1$txtF00155":
                                    dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("3");
                                    inpElement.value = dr["TCR_AMOUNT"].ToString();
                                    break;
                                case "ctl00$master1$txtF00160":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$master1$txtF00161":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$master1$txtF00346":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString();
                                    break;
                                //simkh end


                            }
                            FireInpElementEvent(inpElement, "OnBlur");
                            break;
                        #endregion

                        #region "Page 6"
                        case "BE2013Page6":
                            switch (inpElement.name)
                            {
                                //case "ctl00$master1$txtF00155":
                                //    dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("3");
                                //    inpElement.value = dr["TCR_AMOUNT"].ToString();
                                //    break;
                                case "ctl00$master1$txtF00157":
                                    dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("5");
                                    inpElement.value = dr["TCR_AMOUNT"].ToString();
                                    break;
                                //case "ctl00$master1$txtF00160":
                                //    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
                                //    break;
                                //case "ctl00$master1$txtF00161":
                                //    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
                                //    break;
                                //case "ctl00$master1$txtF00346":
                                //    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString();
                                //    break;
                                //case "ctl00$master1$txtF00347":
                                //    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString();
                                //    break;

                            }
                            break;
                        #endregion

                        #region "Page 7"
                        case "BE2013Page7":
                            switch (inpElement.name)
                            {
                                //case "ctl00$master1$txtF00282":
                                //    inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[0].ToString();
                                //    break;

                                case "ctl00$master1$txtF00293":
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[2].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString();
                                    }
                                    break;

                                case "ctl00$master1$txtF00290":
                                    inpElement.value = dsData.Tables["P6_TAXA_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;

                                //weihong NAMA PENTADBIR HARTA PUSAKA 
                                case "ctl00$master1$txtF00183":
                                    inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;

                                //weihong NOMBOR JENIS PENGENALAN (NUMBER INDENTITY TYPE) 
                                case "ctl00$master1$txtF00185":
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[2].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString();
                                    }
                                    break;
                                //endweihong
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
                        #region "Page 1"
                        case "BE2013Page1":
                            switch (selElement.name)
                            {
                                case "ctl00$master1$ddlF00386"://Citizan
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$master1$ddlF00012"://Sex
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[2].ToString();
                                    break;
                                case "ctl00$master1$ddlF00013"://Status
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    break;
                                case "ctl00$master1$ddlF00014_Hari":////Date of Marriage/Divorce/Demise - Hari
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(0, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(0, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00014_Bulan":////Date of Marriage/Divorce/Demise - Bulan
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().IndexOf('/') + 1, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().IndexOf('/') + 1, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00016"://Type of Assessment
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "1")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[21].ToString()))
                                        {
                                            if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[21].ToString() == "1")
                                            { selElement.value = "1"; }
                                            else
                                            { selElement.value = "2"; }
                                        }
                                    }
                                    else if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "2")
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "3")
                                    {
                                        //weihong
                                        if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                        { selElement.value = "4"; }
                                        else
                                        { selElement.value = "5"; }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00018"://Public Rulings weihong
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() == "1")
                                    { selElement.value = "1"; }
                                    else
                                    { selElement.value = "2"; }
                                    break;
                                case "ctl00$master1$ddlF00024"://Correspondence Add - State
                                    selElement.value = SelectState(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[13].ToString());
                                    break;

                                case "ctl00$master1$ddlF00044"://Bank Name
                                    if (dsData.Tables["P1_SELECT_BANK"].Rows.Count > 0)
                                    {
                                        selElement.value = SelectBank(dsData.Tables["P1_SELECT_BANK"].Rows[0].ItemArray[0].ToString());
                                    }
                                    break;

                                case "ctl00$master1$ddlF00408"://Knowledge worker approval (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = "1";
                                    }
                                    else
                                    {
                                        selElement.value = "2";
                                    }
                                    FireSelElementEvent(selElement, "OnClick");
                                    break;

                                case "ctl00$master1$ddlF00409_hari"://Date Knowledge worker approval - HARI (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().Substring(0, 2);
                                    }
                                    else
                                    {
                                        selElement.value = "";
                                    }
                                    break;

                                case "ctl00$master1$ddlF00409_bln"://Date Knowledge worker approval - BULAN (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().Substring(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().IndexOf('/') + 1, 2);
                                    }
                                    else
                                    {
                                        selElement.value = "";
                                    }
                                    break;

                                case "ctl00$master1$ddlF00409_thn"://Date Knowledge worker approval - TAHUN (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().Substring(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().LastIndexOf('/') + 1, 4);
                                    }
                                    else
                                    {
                                        selElement.value = "";
                                    }
                                    break;

                                //case "ctl00$master1$ddlsurat_negara": //Negara Menyurat weihong
                                //    selElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[13].ToString();
                                //    break;

                                //simkh 2014
                                case "ctl00$master1$ddlJPengenalan_isteri"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                    {
                                        selElement.value = "1";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                    {
                                        selElement.value = "4";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                    {
                                        selElement.value = "2";
                                    }
                                    break;
                                //simkh end
                            }
                            FireSelElementEvent(selElement, "OnChange");
                            break;
                        #endregion

                        #region "Page 2"
                        case "BE2013Page2":
                            switch (selElement.name)
                            {
                                case "ctl00$master1$ddlF00054"://Ref Prefix
                                    selElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$master1$ddlJPengenalan_isteri"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                    {
                                        selElement.value = "1";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                    {
                                        selElement.value = "4";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                    {
                                        selElement.value = "2";
                                    }
                                    break;

                                case "ctl00$master1$ddlF00054_1"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$ddlJPengenalan_isteri_1"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00054_2"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$ddlJPengenalan_isteri_2"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                                case "ctl00$master1$ddlF00054_3"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$master1$ddlJPengenalan_isteri_3"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 3"
                        case "BE2013Page3":
                            switch (selElement.name)
                            {
                                case "ctl00$master1$ddlF00355"://Type of income transfer from husband/wife
                                    bool boolHaveBusiness = false;
                                    for (int i = 0; i < dsData.Tables["P3_TAX_PROFILE_OTHER"].Rows.Count; i++)
                                    {
                                        if (dsData.Tables["P3_TAX_PROFILE_OTHER"].Rows[i].ItemArray[11].ToString() == "1")
                                        {
                                            boolHaveBusiness = true;
                                            break;
                                        }
                                    }
                                    if (dsData.Tables["P3_TAX_PROFILE"].Rows[0].ItemArray[11].ToString() == "1" || boolHaveBusiness == true)
                                    {
                                        selElement.value = "1";//Ada pendapatan perniagaan (With business income)
                                    }
                                    else //if (dsData.Tables["P3_TAX_PROFILE"].Rows[0].ItemArray[11].ToString() == "2")
                                    {
                                        selElement.value = "2";//Tiada punca pendapatan perniagaan (Without business income)
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 7"
                        //case "BE2009Page7":
                        //    switch (selElement.name)
                        //    {
                        //        case "ctl00$master$ddlJPengenalan_mati":
                        //            if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                        //            {
                        //                selElement.value = "NEWIC";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                        //            {
                        //                selElement.value = "POLICE";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                        //            {
                        //                selElement.value = "ARMY";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                        //            {
                        //                selElement.value = "PASSPORT";
                        //            }
                        //            FireSelElementEvent(selElement, "OnChange");
                        //            break;
                        //    }
                        //    break;

                        //weihong JENIS PENGENALAN (INDENTITY TYPE)
                        case "BE2013Page7":
                            switch (selElement.name)
                            {
                                case "ctl00$master1$ddlJPengenalan_mati":
                                    //selElement.removeAttribute("selected", 1);
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        selElement.value = "1";
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        selElement.value = "4"; ;
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        selElement.value = "2";
                                    }
                                    FireSelElementEvent(selElement, "OnChange");
                                    break;
                            }//endweihong
                            break;
                        #endregion
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            //dannylee end
        }

        private void ProcessFormBE2014(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            //dannylee 15/02/2013
            try
            {
                EFilingDALBE2014 dalBE = new EFilingDALBE2014(strTaxPayer, strYA, strTaxAgent);
                DataSet dsData = new DataSet();
                dsData = dalBE.GetFormDataBE2014(strPageIndex);
                dalBE.CloseConn();
                //string strComparator;
                //string strTemp;

                double nTotal = 0;
                DataRow dr;

                #region "INPUT"
                foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
                {
                    switch (strPageIndex)
                    {
                        case "BE2014Page1":
                        case "BE2014Page2":
                        case "BE2014Page3":
                            switch (inpElement.name)
                            {
                                //case "ctl00$master$txtF00009"://IC No
                                //    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                //    break;
                                case "ctl00$ContentPlaceHolder1$txtF00009"://Passport No ctl00$ContentPlaceHolder1$txtF00009
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtf00014_Thn"://Date of Marriage/Divorce/Demise - Year
                                    inpElement.value = "2002";
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().LastIndexOf('/') + 1, 4);
                                            //inpElement.value = Right(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString(),4);
                                        }
                                        else
                                        {
                                            inpElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().LastIndexOf('/') + 1, 4);
                                        }
                                        else
                                        {
                                            inpElement.value = "";
                                        }
                                    }
                                    break;

                                // LEESH 14 FEB 2012
                                case "ctl00$ContentPlaceHolder1$chkboxF00419": //Tax Agent Check State
                                    if (dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[1].ToString() == "1")
                                    {
                                        inpElement.value = "2";
                                        inpElement.@checked = true;
                                    }
                                    else
                                    {
                                        inpElement.value = "1";
                                        inpElement.@checked = false;
                                    }
                                    break;
                                // LEESH END
                                //azham 15-mar-2016 ==================================
                                case "ctl00$ContentPlaceHolder1$txtF00377_Thn": //Tax Agent Check State
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[2].ToString()))
                                    {
                                        DateTime dtBirthDate = Convert.ToDateTime(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[2].ToString());
                                        inpElement.value = dtBirthDate.ToString("yyyy");
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                //azham 15-mar-2016 ==================================

                                case "ctl00$ContentPlaceHolder1$txtF00019"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00020"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00021"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00022"://Postcode
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[11].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00023"://City
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[12].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00041"://Tel
                                    inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[14].ToString() + "-" + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[15].ToString());
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00444"://mobile
                                    inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[22].ToString() + "-" + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[23].ToString());
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00040"://Employer No
                                    inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[16].ToString() + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[17].ToString());
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00043"://email
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[18].ToString();
                                    break;
                                //case "ctl00$master$txtF00044"://Bank Name
                                //    inpElement.value = SelectBank(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[19].ToString());
                                //    break;
                                case "ctl00$ContentPlaceHolder1$txtF00045"://Bank A/C No
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[20].ToString();
                                    break;

                                //simkh 2014
                                case "ctl00$ContentPlaceHolder1$txtF00052"://Wife Name
                                    inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00055"://Ref No
                                    inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[4].ToString());
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00057"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString());
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                    }
                                    break;
                                //simkh 2014 end

                                //case "ctl00$ContentPlaceHolder1$txtF00052"://Wife Name
                                //    inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00055"://Ref No
                                //    inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[4].ToString());
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00057"://IC No/ Police No/ Army No/ Passport No
                                //    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                //    {
                                //        inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString());
                                //    }
                                //    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                //    {
                                //        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                //    }
                                //    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                //    {
                                //        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                //    }
                                //    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                //    {
                                //        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                //    }
                                //    break;
                                case "ctl00$ContentPlaceHolder1$txtF00052_1"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00055_1"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00057_1"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00052_2"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00055_2"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00057_2"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00052_3"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00055_3"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00057_3"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$btnTambah_Isteri":
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        FireInpElementEvent(inpElement, "OnClick");
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$txtF00076"://Employment
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00077"://Dividend
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;

                                //case "ctl00$ContentPlaceHolder1$txtF00078"://Interest and Discount
                                //    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                //    {
                                //        inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString())));
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;

                                //DANNYLEE 15 FEB 2013
                                case "ctl00$ContentPlaceHolder1$txtF00078"://Interest, Discount, Royalty, Premium and etc..
                                    if (dsData.Tables["P3_INCOME_EXCLUDE_RENTAL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_INCOME_EXCLUDE_RENTAL"].Rows[0].ItemArray[0].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //END
                                //DANNYLEE 15 FEB 2013
                                case "ctl00$ContentPlaceHolder1$txtF00079"://Rent
                                    if (dsData.Tables["P3_DIVIDEND_RENTAL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_DIVIDEND_RENTAL"].Rows[0].ItemArray[1].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //END
                                case "ctl00$ContentPlaceHolder1$txtF00080"://Pension, annuities and other periodical payments
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[6].ToString()));
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00081"://Other gains or profits
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[9].ToString())));
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00090"://Gift to Government, State Government or local authorities
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("9");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00393"://Gift to approved institutions or organization
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("1");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00389"://Gift to sports activity
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("7");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00390"://Gift to contribution for project of national interest
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("8");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00091"://Gift artefacts, manuscript or painting
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("2");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00092"://Gift of library
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("3");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00093"://Gift of public facilities of disabled persons
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("4");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00094"://Gift of medical equipment to any healthcare facility
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("5");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00095"://Gift of National Art Gallery
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("6");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //dannylee 21/02/2013

                                //simkh 2014
                                case "ctl00$ContentPlaceHolder1$txtF00096": //Gift and donation

                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_GIFTS"].Rows[0].ItemArray[0].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //simkh end

                                //case "ctl00$ContentPlaceHolder1$txtjum_derma"://Approved Donations/Gifts/Contributions
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        inpElement.value = dsData.Tables["P3_TAX_GIFTS"].Rows[0].ItemArray[0].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                ////end
                                case "ctl00$ContentPlaceHolder1$txtF00099"://Income transfer from husband/wife
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[10].ToString();
                                    }
                                    break;
                                //LEESH 24 FEB 2012
                                case "ctl00$ContentPlaceHolder1$txtF00099b":
                                    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[13].ToString();
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //LEESH END
                                case "ctl00$ContentPlaceHolder1$txtF00165"://Installment/ Schedular
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[11].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[12].ToString()));
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$txtF00417"://Gross income from employment (weihong) 
                                    //MessageBox.Show("L");
                                    if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[0].ToString()));
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$txtF00418"://Total gross income from all sources (weihong)
                                    if (dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()));
                                        if (dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
                                        {
                                            inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()));
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                        }
                                        else
                                        {
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
                                        {
                                            inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()));
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                        }
                                        else
                                        {
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                            else
                                            {
                                                inpElement.value = "";
                                            }
                                        }
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$txtF00169"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[0].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00170"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[1].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00171"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[2].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00172"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[3].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00173"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[0].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00174"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[1].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00175"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[2].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00176"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[3].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;

                                //    switch (inpElement.name)
                                //    {
                                //        //Preceding Years Income
                                //        case "ctl00$ContentPlaceHolder1$txtF00169"://Type of income
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[0].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00170"://Year for which paid
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[1].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00171"://Gross Amount
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[2].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00172"://Provident and pension fund contribution
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[3].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00173"://Type of income
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[0].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00174"://Year for which paid
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[1].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00175"://Gross Amount
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[2].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00176"://Provident and pension fund contribution
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[3].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00177"://Type of income
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[0].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00178"://Year for which paid
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[1].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00179"://Gross Amount
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[2].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00180"://Provident and pension fund contribution
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[3].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00361"://Type of income
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[0].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00362"://Year for which paid
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[1].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00363"://Gross Amount
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[2].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00364"://Provident and pension fund contribution
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[3].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00365"://Type of income
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[0].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00366"://Year for which paid
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[1].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00367"://Gross Amount
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[2].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00368"://Provident and pension fund contribution'
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[3].ToString();
                                //            }
                                //            break;
                                //    }
                                //    break;

                                case "ctl00$master$txtF00104"://Individual
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("1");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00105"://Medical expenses for won parents
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("2");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00106"://Basic supporting equipment for disabled person
                                    //dsData.Tables["P4_TAX_RELIEF"].DefaultView.RowFilter = "TCC_KEY = 3";
                                    //inpElement.value = dsData.Tables["P4_TAX_RELIEF"].Select();
                                    //dtOverAll.PrimaryKey = new DataColumn[] { dtOverAll.Columns["ITEMNMBR"] };
                                    //dsData.Tables["P4_TAX_RELIEF"].PrimaryKey = new DataColumn[] { dsData.Tables["P4_TAX_RELIEF"].Columns["TCC_KEY"] };
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("3");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00107"://Disabled individual
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("4");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00108"://Education fees
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("5");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00109"://Medical expenses for self/ spouse/ child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("6");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00110"://Complete medical examination for self/ spouse/ child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("7");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00112"://Purchase books/ megazines
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("8");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00391"://Purchase personal computers
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("21");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00392"://Skim Simapanan Pendidikan Nasional
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("22");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00395"://Purchase sports equipment
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("23");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00404"://Housing load interest
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("9");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00116"://Husband/ wife/ payment of alimony
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("10");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00118"://Disabled husband/ wife
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("13");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00397"://No. child own self
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD"].Rows.Count);
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00398"://No. child husband/ wife
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_HW"].Rows.Count + dsData.Tables["P4_TAX_RELIEF_CHILD_HW_OTHERS"].Rows.Count);
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00396"://No. children eligible for deduction
                                    inpElement.value = Convert.ToString((dsData.Tables["P4_TAX_RELIEF_CHILD"].Rows.Count) + (dsData.Tables["P4_TAX_RELIEF_CHILD_HW"].Rows.Count) + (dsData.Tables["P4_TAX_RELIEF_CHILD_HW_OTHERS"].Rows.Count));
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00120"://No. child under 18 - 1000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_1000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_1000"].Rows.Count;
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00121"://Amount child under 18 - 1000
                                    inpElement.value = Convert.ToString(nTotal * 1000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00122"://No. child under 18 - 500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_500"].Rows.Count;
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00123"://Amount child under 18 - 500
                                    inpElement.value = Convert.ToString(nTotal * 500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00124"://Total amount child under 18
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("14");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00357"://No. child 18 and above - 1000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_1000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_1000"].Rows.Count;
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00371"://Amount child 18 and above - 1000
                                    inpElement.value = Convert.ToString(nTotal * 1000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00358"://No. child 18 and above - 500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_500"].Rows.Count;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00372"://Amount child 18 and above - 500
                                    inpElement.value = Convert.ToString(nTotal * 500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00359"://No. child 18 and above - 4000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_4000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_4000"].Rows.Count;
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00373"://Amount child 18 and above - 4000
                                    inpElement.value = Convert.ToString(nTotal * 6000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00360"://No. child 18 and above - 2000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_2000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_2000"].Rows.Count;
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00374"://Amount child 18 and above - 2000
                                    inpElement.value = Convert.ToString(nTotal * 3000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00133"://Total amount child 18 and above
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("15");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00135"://No. disabled child - 5000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_5000"].Rows.Count);
                                   
                                   // inpElement.value = intCount.ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00136"://Amount disabled child - 5000
                                    inpElement.value = Convert.ToString(nTotal * 5000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00137"://No. disabled child - 2500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_2500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_2500"].Rows.Count;
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00138"://Amount disabled child - 2500
                                    inpElement.value = Convert.ToString(nTotal * 2500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00369"://No. disabled child - 9000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_9000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_9000"].Rows.Count;
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00375"://Amount disabled child - 9000
                                    inpElement.value = Convert.ToString(nTotal * 11000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00370"://No. disabled child - 4500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_4500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_4500"].Rows.Count;
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00376"://Amount disabled child - 4500
                                    inpElement.value = Convert.ToString(nTotal * 5500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00139"://Total amount disabled child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("16");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00140"://Life insurance and providend fund
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("17");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00141"://Education and medical insurance
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("18");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;

                                case "ctl00$ContentPlaceHolder1$txtF00411"://Internet Broadband weihong 
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("24");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;

                                case "ctl00$ContentPlaceHolder1$txtF00412"://Differed Anuities weihong 
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("25");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;

                                //simkh 2014
                                case "ctl00$ContentPlaceHolder1$txtF00155":
                                    dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("3");
                                    inpElement.value = dr["TCR_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00160":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00161":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00346":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString();
                                    break;
                                //simkh end

                                //case "ctl00$ContentPlaceHolder1$txtF00155":
                                //    dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("3");
                                //    inpElement.value = dr["TCR_AMOUNT"].ToString();
                                //    break;
                                case "ctl00$ContentPlaceHolder1$txtF00157":
                                    dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("5");
                                    inpElement.value = dr["TCR_AMOUNT"].ToString();
                                    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00160":
                                //    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00161":
                                //    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00346":
                                //    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString();
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00347":
                                //    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString();
                                //    break;

                                //case "ctl00$ContentPlaceHolder1$txtF00282":
                                //    inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[0].ToString();
                                //    break;

                                case "ctl00$ContentPlaceHolder1$txtF00293":
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[2].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString();
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$txtF00290":
                                    inpElement.value = dsData.Tables["P6_TAXA_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;

                                //weihong NAMA PENTADBIR HARTA PUSAKA 
                                case "ctl00$ContentPlaceHolder1$txtF00183":
                                    inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;

                                //weihong NOMBOR JENIS PENGENALAN (NUMBER INDENTITY TYPE) 
                                case "ctl00$ContentPlaceHolder1$txtF00185":
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[2].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString();
                                    }
                                    break;
                                //endweihong
                            }
                            break;
                #endregion
                    }
                }

                #region "SELECT"
                foreach (mshtml.HTMLSelectElement selElement in htmlDoc.getElementsByTagName("select"))
                {
                    switch (strPageIndex)
                    {
                        #region "Page 1"
                        case "BE2014Page1":
                            switch (selElement.name)
                            {
                                case "ctl00$ContentPlaceHolder1$ddlF00011"://Citizan
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00012"://Sex
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[2].ToString();
                                    break;
                                //azham 14-mar-2016 =========================
                                case "ctl00$ContentPlaceHolder1$ddlF00377_Hari"://Date of Birth -Day
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[2].ToString()))
                                    {
                                        DateTime dtBirthDate = Convert.ToDateTime(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[2].ToString());
                                        selElement.value = dtBirthDate.ToString("dd");
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00377_Bulan"://Date of Birth -month
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[2].ToString()))
                                    {
                                        DateTime dtBirthDate = Convert.ToDateTime(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[2].ToString());
                                        selElement.value = dtBirthDate.ToString("MM");
                                    }
                                    break;
                                //azham 14-mar-2016 =========================
                                case "ctl00$ContentPlaceHolder1$ddlF00013"://Status
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00014_Hari":////Date of Marriage/Divorce/Demise - Hari
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(0, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(0, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00014_Bulan":////Date of Marriage/Divorce/Demise - Bulan
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().IndexOf('/') + 1, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().IndexOf('/') + 1, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00016"://Type of Assessment
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "1")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[21].ToString()))
                                        {
                                            if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[21].ToString() == "1")
                                            { selElement.value = "1"; }
                                            else
                                            { selElement.value = "2"; }
                                        }
                                    }
                                    else if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "2")
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "3")
                                    {
                                        //weihong
                                        if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                        { selElement.value = "4"; }
                                        else
                                        { selElement.value = "5"; }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00018"://Public Rulings weihong
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() == "1")
                                    { selElement.value = "1"; }
                                    else
                                    { selElement.value = "2"; }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00024"://Correspondence Add - State
                                    selElement.value = SelectState(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[13].ToString());
                                    break;

                                case "ctl00$ContentPlaceHolder1$ddlF00044"://Bank Name
                                    if (dsData.Tables["P1_SELECT_BANK"].Rows.Count > 0)
                                    {
                                        selElement.value = SelectBank(dsData.Tables["P1_SELECT_BANK"].Rows[0].ItemArray[0].ToString());
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$ddlF00408"://Knowledge worker approval (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = "1";
                                    }
                                    else
                                    {
                                        selElement.value = "2";
                                    }
                                    FireSelElementEvent(selElement, "OnClick");
                                    break;

                                case "ctl00$ContentPlaceHolder1$ddlF00409_hari"://Date Knowledge worker approval - HARI (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().Substring(0, 2);
                                    }
                                    else
                                    {
                                        selElement.value = "";
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$ddlF00409_bln"://Date Knowledge worker approval - BULAN (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().Substring(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().IndexOf('/') + 1, 2);
                                    }
                                    else
                                    {
                                        selElement.value = "";
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$ddlF00409_thn"://Date Knowledge worker approval - TAHUN (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().Substring(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().LastIndexOf('/') + 1, 4);
                                    }
                                    else
                                    {
                                        selElement.value = "";
                                    }
                                    break;

                                //case "ctl00$ContentPlaceHolder1$ddlsurat_negara": //Negara Menyurat weihong
                                //    selElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[13].ToString();
                                //    break;

                                //simkh 2014
                                case "ctl00$ContentPlaceHolder1$ddlJPengenalan_isteri"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                    {
                                        selElement.value = "1";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                    {
                                        selElement.value = "4";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                    {
                                        selElement.value = "2";
                                    }
                                    break;
                                //simkh end
                            }
                            FireSelElementEvent(selElement, "OnChange");
                            break;
                        #endregion

                        #region "Page 2"
                        case "BE2014Page2":
                            switch (selElement.name)
                            {
                                case "ctl00$ContentPlaceHolder1$ddlF00054"://Ref Prefix
                                    selElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlJPengenalan_isteri"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                    {
                                        selElement.value = "1";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                    {
                                        selElement.value = "4";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                    {
                                        selElement.value = "2";
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$ddlF00054_1"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlJPengenalan_isteri_1"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00054_2"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlJPengenalan_isteri_2"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00054_3"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlJPengenalan_isteri_3"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 3"
                        case "BE2014Page3":
                            switch (selElement.name)
                            {
                                case "ctl00$ContentPlaceHolder1$ddlF00355"://Type of income transfer from husband/wife
                                    bool boolHaveBusiness = false;
                                    for (int i = 0; i < dsData.Tables["P3_TAX_PROFILE_OTHER"].Rows.Count; i++)
                                    {
                                        if (dsData.Tables["P3_TAX_PROFILE_OTHER"].Rows[i].ItemArray[11].ToString() == "1")
                                        {
                                            boolHaveBusiness = true;
                                            break;
                                        }
                                    }
                                    if (dsData.Tables["P3_TAX_PROFILE"].Rows[0].ItemArray[11].ToString() == "1" || boolHaveBusiness == true)
                                    {
                                        selElement.value = "1";//Ada pendapatan perniagaan (With business income)
                                    }
                                    else //if (dsData.Tables["P3_TAX_PROFILE"].Rows[0].ItemArray[11].ToString() == "2")
                                    {
                                        selElement.value = "2";//Tiada punca pendapatan perniagaan (Without business income)
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 7"
                        //case "BE2009Page7":
                        //    switch (selElement.name)
                        //    {
                        //        case "ctl00$master$ddlJPengenalan_mati":
                        //            if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                        //            {
                        //                selElement.value = "NEWIC";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                        //            {
                        //                selElement.value = "POLICE";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                        //            {
                        //                selElement.value = "ARMY";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                        //            {
                        //                selElement.value = "PASSPORT";
                        //            }
                        //            FireSelElementEvent(selElement, "OnChange");
                        //            break;
                        //    }
                        //    break;

                        //weihong JENIS PENGENALAN (INDENTITY TYPE)
                        case "BE2014Page7":
                            switch (selElement.name)
                            {
                                case "ctl00$ContentPlaceHolder1$ddlJPengenalan_mati":
                                    //selElement.removeAttribute("selected", 1);
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        selElement.value = "1";
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        selElement.value = "4"; ;
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        selElement.value = "2";
                                    }
                                    FireSelElementEvent(selElement, "OnChange");
                                    break;
                            }//endweihong
                            break;
                        #endregion
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            //dannylee end
        }

        private void ProcessFormBE2015(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            //dannylee 15/02/2013
            String Errorlog = "";
            try
            {
               
                EFilingDALBE2015 dalBE = new EFilingDALBE2015(strTaxPayer, strYA, strTaxAgent);
                DataSet dsData = new DataSet();
                dsData = dalBE.GetFormDataBE2015(strPageIndex);
                dalBE.CloseConn();
                //string strComparator;
                //string strTemp;
                Errorlog = "DalBE";
                double nTotal = 0;
                DataRow dr;

                #region "INPUT"
                foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
                {
                    switch (strPageIndex)
                    {
                        
                        case "BE2015Page1":
                        case "BE2015Page2":
                        case "BE2015Page3":
                            switch (inpElement.name)
                            {
                                //case "ctl00$master$txtF00009"://IC No
                                //    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                //    break;
                                case "ctl00$ContentPlaceHolder1$txtF00009"://Passport No ctl00$ContentPlaceHolder1$txtF00009
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00014_Thn"://Date of Marriage/Divorce/Demise - Year
                                    inpElement.value = "2002";
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().LastIndexOf('/') + 1, 4);
                                            //inpElement.value = Right(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString(),4);
                                        }
                                        else
                                        {
                                            inpElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().LastIndexOf('/') + 1, 4);
                                        }
                                        else
                                        {
                                            inpElement.value = "";
                                        }
                                    }
                                    
                                    break;

                                // LEESH 14 FEB 2012
                                case "ctl00$ContentPlaceHolder1$chkboxF00419": //Tax Agent Check State
                                    if (dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[1].ToString() == "1")
                                    {
                                        inpElement.value = "2";
                                        inpElement.@checked = true;
                                    }
                                    else
                                    {
                                        inpElement.value = "1";
                                        inpElement.@checked = false;
                                    }
                                    
                                    break;
                                // LEESH END
                                //azham 15-mar-2016 ==================================
                                case "ctl00$ContentPlaceHolder1$txtF00377_Thn": //Tax Agent Check State
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[2].ToString()))
                                    {
                                        DateTime dtBirthDate = Convert.ToDateTime(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[2].ToString());
                                        inpElement.value = dtBirthDate.ToString("yyyy");
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                   
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00379_Thn": //Tax Agent Check State
                                    try
                                    {
                                        DateTime dtBirthDate = Convert.ToDateTime(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[3].ToString());
                                        inpElement.value = dtBirthDate.ToString("yyyy");
                                    }
                                    catch (Exception e)
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                //azham 15-mar-2016 ==================================
                                case "ctl00$ContentPlaceHolder1$txtF00019"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00020"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00021"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00022"://Postcode
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[11].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00023"://City
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[12].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00041"://Tel
                                    inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[14].ToString() + "-" + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[15].ToString());
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00444"://mobile
                                    inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[22].ToString() + "-" + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[23].ToString());
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00040"://Employer No
                                    inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[16].ToString() + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[17].ToString());
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00043"://email
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[18].ToString();
                                    break;
                                //case "ctl00$master$txtF00044"://Bank Name
                                //    inpElement.value = SelectBank(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[19].ToString());
                                //    break;
                                case "ctl00$ContentPlaceHolder1$txtF00045"://Bank A/C No
                                
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[20].ToString();
                               
                                    break;

                                //simkh 2014
                                case "ctl00$ContentPlaceHolder1$txtF00052"://Wife Name
                            //azham 05052016
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows.Count > 0 && dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[0] != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    }
                                    else { 
                                        inpElement.value = "";
                                    }

                         
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00055"://Ref No

                                    inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[4].ToString());

                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00057"://IC No/ Police No/ Army No/ Passport No
                                 
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString());
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                    }

                                    break;
                                //simkh 2014 end

                                //case "ctl00$ContentPlaceHolder1$txtF00052"://Wife Name
                                //    inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00055"://Ref No
                                //    inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[4].ToString());
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00057"://IC No/ Police No/ Army No/ Passport No
                                //    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                //    {
                                //        inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString());
                                //    }
                                //    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                //    {
                                //        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                //    }
                                //    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                //    {
                                //        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                //    }
                                //    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                //    {
                                //        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                //    }
                                //    break;
                                case "ctl00$ContentPlaceHolder1$txtF00052_1"://Wife Name

                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00055_1"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00057_1"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00052_2"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00055_2"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00057_2"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00052_3"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00055_3"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00057_3"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$btnTambah_Isteri":
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        FireInpElementEvent(inpElement, "OnClick");
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$txtF00076"://Employment
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00077"://Dividend
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;

                                //case "ctl00$ContentPlaceHolder1$txtF00078"://Interest and Discount
                                //    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                //    {
                                //        inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString())));
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;

                                //DANNYLEE 15 FEB 2013
                                case "ctl00$ContentPlaceHolder1$txtF00078"://Interest, Discount, Royalty, Premium and etc..
                                    if (dsData.Tables["P3_INCOME_EXCLUDE_RENTAL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_INCOME_EXCLUDE_RENTAL"].Rows[0].ItemArray[0].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //END
                                //DANNYLEE 15 FEB 2013
                                case "ctl00$ContentPlaceHolder1$txtF00079"://Rent
                                    if (dsData.Tables["P3_DIVIDEND_RENTAL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_DIVIDEND_RENTAL"].Rows[0].ItemArray[1].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //END
                                case "ctl00$ContentPlaceHolder1$txtF00080"://Pension, annuities and other periodical payments
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[6].ToString()));
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00081"://Other gains or profits
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[9].ToString())));
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00090"://Gift to Government, State Government or local authorities
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("9");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00393"://Gift to approved institutions or organization
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("1");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00389"://Gift to sports activity
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("7");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00390"://Gift to contribution for project of national interest
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("8");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00091"://Gift artefacts, manuscript or painting
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("2");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00092"://Gift of library
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("3");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00093"://Gift of public facilities of disabled persons
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("4");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00094"://Gift of medical equipment to any healthcare facility
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("5");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00095"://Gift of National Art Gallery
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("6");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //dannylee 21/02/2013

                                //simkh 2014
                                case "ctl00$ContentPlaceHolder1$txtF00096": //Gift and donation

                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_GIFTS"].Rows[0].ItemArray[0].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //simkh end

                                //case "ctl00$ContentPlaceHolder1$txtjum_derma"://Approved Donations/Gifts/Contributions
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        inpElement.value = dsData.Tables["P3_TAX_GIFTS"].Rows[0].ItemArray[0].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                ////end
                                case "ctl00$ContentPlaceHolder1$txtF00099"://Income transfer from husband/wife
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[10].ToString();
                                    }
                                    break;
                                //LEESH 24 FEB 2012
                                case "ctl00$ContentPlaceHolder1$txtF00099b":
                                    inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[13].ToString();
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //LEESH END
                                case "ctl00$ContentPlaceHolder1$txtF00165"://Installment/ Schedular
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[11].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[12].ToString()));
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$txtF00417"://Gross income from employment (weihong) 
                                    //MessageBox.Show("L");
                                    if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[0].ToString()));
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$txtF00418"://Total gross income from all sources (weihong)
                                    if (dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()));
                                        if (dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
                                        {
                                            inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()));
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                        }
                                        else
                                        {
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
                                        {
                                            inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()));
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                        }
                                        else
                                        {
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                            else
                                            {
                                                inpElement.value = "";
                                            }
                                        }
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$txtF00169"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[0].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00170"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[1].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00171"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[2].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00172"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[3].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00173"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[0].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00174"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[1].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00175"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[2].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00176"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[3].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;

                                //    switch (inpElement.name)
                                //    {
                                //        //Preceding Years Income
                                //        case "ctl00$ContentPlaceHolder1$txtF00169"://Type of income
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[0].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00170"://Year for which paid
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[1].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00171"://Gross Amount
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[2].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00172"://Provident and pension fund contribution
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[3].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00173"://Type of income
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[0].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00174"://Year for which paid
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[1].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00175"://Gross Amount
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[2].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00176"://Provident and pension fund contribution
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[3].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00177"://Type of income
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[0].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00178"://Year for which paid
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[1].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00179"://Gross Amount
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[2].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00180"://Provident and pension fund contribution
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[3].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00361"://Type of income
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[0].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00362"://Year for which paid
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[1].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00363"://Gross Amount
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[2].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00364"://Provident and pension fund contribution
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[3].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00365"://Type of income
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[0].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00366"://Year for which paid
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[1].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00367"://Gross Amount
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[2].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00368"://Provident and pension fund contribution'
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[3].ToString();
                                //            }
                                //            break;
                                //    }
                                //    break;

                                case "ctl00$master$txtF00104"://Individual
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("1");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00105"://Medical expenses for won parents
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("2");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00106"://Basic supporting equipment for disabled person
                                    //dsData.Tables["P4_TAX_RELIEF"].DefaultView.RowFilter = "TCC_KEY = 3";
                                    //inpElement.value = dsData.Tables["P4_TAX_RELIEF"].Select();
                                    //dtOverAll.PrimaryKey = new DataColumn[] { dtOverAll.Columns["ITEMNMBR"] };
                                    //dsData.Tables["P4_TAX_RELIEF"].PrimaryKey = new DataColumn[] { dsData.Tables["P4_TAX_RELIEF"].Columns["TCC_KEY"] };
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("3");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00107"://Disabled individual
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("4");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00108"://Education fees
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("5");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00109"://Medical expenses for self/ spouse/ child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("6");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00110"://Complete medical examination for self/ spouse/ child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("7");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00112"://Purchase books/ megazines
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("8");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00391"://Purchase personal computers
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("21");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00392"://Skim Simapanan Pendidikan Nasional
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("22");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00395"://Purchase sports equipment
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("23");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00404"://Housing load interest
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("9");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00116"://Husband/ wife/ payment of alimony
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("10");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00118"://Disabled husband/ wife
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("13");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00397"://No. child own self
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD"].Rows.Count);
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00398"://No. child husband/ wife
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_HW"].Rows.Count + dsData.Tables["P4_TAX_RELIEF_CHILD_HW_OTHERS"].Rows.Count);
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00396"://No. children eligible for deduction
                                    inpElement.value = Convert.ToString((dsData.Tables["P4_TAX_RELIEF_CHILD"].Rows.Count) + (dsData.Tables["P4_TAX_RELIEF_CHILD_HW"].Rows.Count) + (dsData.Tables["P4_TAX_RELIEF_CHILD_HW_OTHERS"].Rows.Count));
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00120"://No. child under 18 - 1000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_1000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_1000"].Rows.Count;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00121"://Amount child under 18 - 1000
                                    inpElement.value = Convert.ToString(nTotal * 1000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00122"://No. child under 18 - 500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_500"].Rows.Count;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00123"://Amount child under 18 - 500
                                    inpElement.value = Convert.ToString(nTotal * 500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00124"://Total amount child under 18
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("14");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00357"://No. child 18 and above - 1000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_1000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_1000"].Rows.Count;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00371"://Amount child 18 and above - 1000
                                    inpElement.value = Convert.ToString(nTotal * 1000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00358"://No. child 18 and above - 500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_500"].Rows.Count;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00372"://Amount child 18 and above - 500
                                    inpElement.value = Convert.ToString(nTotal * 500);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00359"://No. child 18 and above - 4000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_4000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_4000"].Rows.Count;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00373"://Amount child 18 and above - 4000
                                    inpElement.value = Convert.ToString(nTotal * 6000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00360"://No. child 18 and above - 2000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_2000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_2000"].Rows.Count;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00374"://Amount child 18 and above - 2000
                                    inpElement.value = Convert.ToString(nTotal * 3000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00133"://Total amount child 18 and above
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("15");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00135"://No. disabled child - 5000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_5000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_5000"].Rows.Count;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00136"://Amount disabled child - 5000
                                    inpElement.value = Convert.ToString(nTotal * 6000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00137"://No. disabled child - 2500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_2500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_2500"].Rows.Count;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00138"://Amount disabled child - 2500
                                    inpElement.value = Convert.ToString(nTotal * 3000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00369"://No. disabled child - 9000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_9000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_9000"].Rows.Count;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00375"://Amount disabled child - 9000
                                    inpElement.value = Convert.ToString(nTotal * 12000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00370"://No. disabled child - 4500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_4500"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_4500"].Rows.Count;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00376"://Amount disabled child - 4500
                                    inpElement.value = Convert.ToString(nTotal * 6000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00139"://Total amount disabled child
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("16");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00140"://Life insurance and providend fund
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("17");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00141"://Education and medical insurance
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("18");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;

                                case "ctl00$ContentPlaceHolder1$txtF00411"://Internet Broadband weihong 
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("24");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    break;

                                case "ctl00$ContentPlaceHolder1$txtF00412"://Differed Anuities weihong 
                                    dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("25");
                                    inpElement.value = dr["TCC_AMOUNT"].ToString();
  
                                    break;

                                //simkh 2014
                                case "ctl00$ContentPlaceHolder1$txtF00155":
                                    dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("3");
                                    inpElement.value = dr["TCR_AMOUNT"].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00160":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00161":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00346":
                                    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString();
                                    break;
                                //simkh end

                                //case "ctl00$ContentPlaceHolder1$txtF00155":
                                //    dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("3");
                                //    inpElement.value = dr["TCR_AMOUNT"].ToString();
                                //    break;
                                case "ctl00$ContentPlaceHolder1$txtF00157":
                                    dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("5");
                                    inpElement.value = dr["TCR_AMOUNT"].ToString();
                                    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00160":
                                //    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00161":
                                //    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00346":
                                //    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString();
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00347":
                                //    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString();
                                //    break;

                                //case "ctl00$ContentPlaceHolder1$txtF00282":
                                //    inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[0].ToString();
                                //    break;

                                case "ctl00$ContentPlaceHolder1$txtF00293":
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[2].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString();
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$txtF00290":
                                    inpElement.value = dsData.Tables["P6_TAXA_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;

                                //weihong NAMA PENTADBIR HARTA PUSAKA 
                                case "ctl00$ContentPlaceHolder1$txtF00183":
                                    inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;

                                //weihong NOMBOR JENIS PENGENALAN (NUMBER INDENTITY TYPE) 
                                case "ctl00$ContentPlaceHolder1$txtF00185":
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[2].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString();
                                    }
                                    break;
                                //endweihong
                            }
                            break;
                #endregion
                    }
                }

                #region "SELECT"
                foreach (mshtml.HTMLSelectElement selElement in htmlDoc.getElementsByTagName("select"))
                {
                    switch (strPageIndex)
                    {
                        #region "Page 1"
                        case "BE2015Page1":
                            switch (selElement.name)
                            {
                                case "ctl00$ContentPlaceHolder1$ddlF00011"://Citizan
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[1].ToString().ToUpper();
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00012"://Sex
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[2].ToString();
                                    break;
                                    //azham 14-mar-2016 =========================
                                case "ctl00$ContentPlaceHolder1$ddlF00377_Hari"://Date of Birth -Day
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[2].ToString()))
                                    {
                                        DateTime dtBirthDate = Convert.ToDateTime(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[2].ToString());
                                        selElement.value = dtBirthDate.ToString("dd");
                                    }        
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00377_Bulan"://Date of Birth -month
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[2].ToString()))
                                    {
                                        DateTime dtBirthDate = Convert.ToDateTime(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[2].ToString());
                                        selElement.value = dtBirthDate.ToString("MM");
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00379_Hari" : //wife
                                  try
                                    {
                                        
                                        DateTime dtBirthDatex = Convert.ToDateTime(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[3].ToString());
                                        selElement.value = dtBirthDatex.ToString("dd");
                                    }
                                    catch (Exception e)
                                    {
                                        
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00379_Bulan" : //wife
                                     try
                                    {
                                        DateTime dtBirthDatex = Convert.ToDateTime(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[3].ToString());
                                        selElement.value = dtBirthDatex.ToString("MM");
                                    }
                                    catch (Exception e)
                                    {

                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00181"://Date of Birth -month
                                    try
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["DISPOSAL"].Rows[0].ItemArray[1].ToString()))
                                        {
                                            if (dsData.Tables["DISPOSAL"].Rows[0].ItemArray[1].ToString().ToUpper() == "YES")
                                            {
                                                selElement.value = "1";
                                            }
                                            else
                                            {
                                                selElement.value = "2";
                                            }
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    catch (Exception e) {
                                        selElement.value = "2";
                                    }
                                    
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00182":
                                    try
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["DISPOSAL"].Rows[0].ItemArray[2].ToString()))
                                        {
                                            if (dsData.Tables["DISPOSAL"].Rows[0].ItemArray[2].ToString().ToUpper() == "YES")
                                            {
                                                selElement.value = "1";
                                            }
                                            else
                                            {
                                                selElement.value = "2";
                                            }
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    catch (Exception e) {
                                        selElement.value = "2";
                                    }
                                    
                                    break;
                                //azham 14-mar-2016 =========================
                                case "ctl00$ContentPlaceHolder1$ddlF00013"://Status
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00014_Hari":////Date of Marriage/Divorce/Demise - Hari
                                   
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(0, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(0, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00014_Bulan":////Date of Marriage/Divorce/Demise - Bulan
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(3,2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().IndexOf('/') + 1, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00016"://Type of Assessment
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "1")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[21].ToString()))
                                        {
                                            if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[21].ToString() == "1")
                                            { selElement.value = "1"; }
                                            else
                                            { selElement.value = "2"; }
                                        }
                                    }
                                    else if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "2")
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "3")
                                    {
                                        //weihong
                                        if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                        { selElement.value = "4"; }
                                        else
                                        { selElement.value = "5"; }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00018"://Public Rulings weihong
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() == "1")
                                    { selElement.value = "1"; }
                                    else
                                    { selElement.value = "2"; }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00024"://Correspondence Add - State
                                    selElement.value = SelectState(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[13].ToString());
                                    break;

                                case "ctl00$ContentPlaceHolder1$ddlF00044"://Bank Name
                                    if (dsData.Tables["P1_SELECT_BANK"].Rows.Count > 0)
                                    {
                                        selElement.value = SelectBank(dsData.Tables["P1_SELECT_BANK"].Rows[0].ItemArray[0].ToString());
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$ddlF00408"://Knowledge worker approval (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = "1";
                                    }
                                    else
                                    {
                                        selElement.value = "2";
                                    }
                                    FireSelElementEvent(selElement, "OnClick");
                                    break;

                                case "ctl00$ContentPlaceHolder1$ddlF00409_hari"://Date Knowledge worker approval - HARI (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().Substring(0, 2);
                                    }
                                    else
                                    {
                                        selElement.value = "";
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$ddlF00409_bln"://Date Knowledge worker approval - BULAN (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().Substring(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().IndexOf('/') + 1, 2);
                                    }
                                    else
                                    {
                                        selElement.value = "";
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$ddlF00409_thn"://Date Knowledge worker approval - TAHUN (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().Substring(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().LastIndexOf('/') + 1, 4);
                                    }
                                    else
                                    {
                                        selElement.value = "";
                                    }
                                    break;

                                //case "ctl00$ContentPlaceHolder1$ddlsurat_negara": //Negara Menyurat weihong
                                //    selElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[13].ToString();
                                //    break;

                                //simkh 2014
                                case "ctl00$ContentPlaceHolder1$ddlJPengenalan_isteri"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                    {
                                        selElement.value = "1";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                    {
                                        selElement.value = "4";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                    {
                                        selElement.value = "2";
                                    }
                                    break;
                                //simkh end
                            }
                            FireSelElementEvent(selElement, "OnChange");
                            break;
                        #endregion

                        #region "Page 2"
                        case "BE2015Page2":
                            switch (selElement.name)
                            {
                                case "ctl00$ContentPlaceHolder1$ddlF00054"://Ref Prefix
                                    selElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlJPengenalan_isteri"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                    {
                                        selElement.value = "1";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                    {
                                        selElement.value = "4";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                    {
                                        selElement.value = "2";
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$ddlF00054_1"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlJPengenalan_isteri_1"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00054_2"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlJPengenalan_isteri_2"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00054_3"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlJPengenalan_isteri_3"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 3"
                        case "BE2015Page3":
                            switch (selElement.name)
                            {
                                case "ctl00$ContentPlaceHolder1$ddlF00355"://Type of income transfer from husband/wife
                                    bool boolHaveBusiness = false;
                                    for (int i = 0; i < dsData.Tables["P3_TAX_PROFILE_OTHER"].Rows.Count; i++)
                                    {
                                        if (dsData.Tables["P3_TAX_PROFILE_OTHER"].Rows[i].ItemArray[11].ToString() == "1")
                                        {
                                            boolHaveBusiness = true;
                                            break;
                                        }
                                    }
                                    if (dsData.Tables["P3_TAX_PROFILE"].Rows[0].ItemArray[11].ToString() == "1" || boolHaveBusiness == true)
                                    {
                                        selElement.value = "1";//Ada pendapatan perniagaan (With business income)
                                    }
                                    else //if (dsData.Tables["P3_TAX_PROFILE"].Rows[0].ItemArray[11].ToString() == "2")
                                    {
                                        selElement.value = "2";//Tiada punca pendapatan perniagaan (Without business income)
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 7"
                        //case "BE2009Page7":
                        //    switch (selElement.name)
                        //    {
                        //        case "ctl00$master$ddlJPengenalan_mati":
                        //            if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                        //            {
                        //                selElement.value = "NEWIC";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                        //            {
                        //                selElement.value = "POLICE";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                        //            {
                        //                selElement.value = "ARMY";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                        //            {
                        //                selElement.value = "PASSPORT";
                        //            }
                        //            FireSelElementEvent(selElement, "OnChange");
                        //            break;
                        //    }
                        //    break;

                        //weihong JENIS PENGENALAN (INDENTITY TYPE)
                        case "BE2015Page7":
                            switch (selElement.name)
                            {
                                case "ctl00$ContentPlaceHolder1$ddlJPengenalan_mati":
                                    //selElement.removeAttribute("selected", 1);
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        selElement.value = "1";
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        selElement.value = "4"; ;
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        selElement.value = "2";
                                    }
                                    FireSelElementEvent(selElement, "OnChange");
                                    break;
                            }//endweihong
                            break;
                        #endregion
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
            //    System.Windows.Forms.MessageBox.Show("LOG : " + Errorlog);
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            //dannylee end
        }

        private void ProcessFormBE2016(mshtml.HTMLDocument htmlDoc, String strPageIndex)
        {
            //dannylee 15/02/2013
            try
            {
                EFilingDALBE2016 dalBE = new EFilingDALBE2016(strTaxPayer, strYA, strTaxAgent);
                DataSet dsData = new DataSet();
                dsData = dalBE.GetFormDataBE2016(strPageIndex);
                dalBE.CloseConn();
                //string strComparator;
                //string strTemp;

                double nTotal = 0;
                DataRow dr;

                #region "INPUT"
                foreach (mshtml.HTMLInputElement inpElement in htmlDoc.getElementsByTagName("input"))
                {
                    switch (strPageIndex)
                    {
                        case "BE2016Page1":
                        case "BE2016Page2":
                        case "BE2016Page3":
                            ErrorLog = inpElement.name;
                            switch (inpElement.name)
                            {
                                case "ctl00$master$txtF00009"://IC No
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00009"://Passport No ctl00$ContentPlaceHolder1$txtF00009
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00014_Thn"://Date of Marriage/Divorce/Demise - Year
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            DateTime dtBirthDate = Convert.ToDateTime(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString());
                                            inpElement.value = dtBirthDate.ToString("yyyy");
                                            //inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Length - 4);
                                        }
                                        else
                                        {
                                            inpElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            DateTime dtBirthDate = Convert.ToDateTime(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString());
                                            inpElement.value = dtBirthDate.ToString("yyyy");
                                           // inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Length - 4);
                                        }
                                        else
                                        {
                                            inpElement.value = "";
                                        }
                                    }
                                    break;

                                //// LEESH 14 FEB 2012
                                //case "ctl00$ContentPlaceHolder1$chkboxF00419": //Tax Agent Check State
                                //    if (dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[1].ToString() == "1")
                                //    {
                                //        inpElement.value = "2";
                                //        inpElement.@checked = true;
                                //    }
                                //    else
                                //    {
                                //        inpElement.value = "1";
                                //        inpElement.@checked = false;
                                //    }
                                //    break;
                                // LEESH END
                                case "ctl00$ContentPlaceHolder1$txtF00377_Thn": //D.O.B Year
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[2].ToString()))
                                    {
                                        DateTime dtBirthDate = Convert.ToDateTime(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[2].ToString());
                                        inpElement.value = dtBirthDate.ToString("yyyy");
                                     //   inpElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[2].ToString().Substring(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[2].ToString().Length - 4);
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00379_Thn":
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[3].ToString()))
                                    {
                                        DateTime dtBirthDate = Convert.ToDateTime(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[3].ToString());
                                        inpElement.value = dtBirthDate.ToString("yyyy");
                                       // inpElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[3].ToString().Substring(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[3].ToString().Length - 4);
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00019"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00020"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00021"://Correspondence Add
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00022"://Postcode
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[11].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00023"://City
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[12].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00041"://Tel
                                    inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[14].ToString() + "-" + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[15].ToString());
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00444"://mobile
                                    inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[22].ToString() + "-" + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[23].ToString());
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00040"://Employer No
                                    inpElement.value = (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[16].ToString() + dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[17].ToString());
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00043"://email
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[18].ToString();
                                    break;
                                //case "ctl00$master$txtF00044"://Bank Name
                                //    inpElement.value = SelectBank(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[19].ToString());
                                //    break;
                                case "ctl00$ContentPlaceHolder1$txtF00045"://Bank A/C No
                                    inpElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[20].ToString();
                                    break;

                                //simkh 2014
                                case "ctl00$ContentPlaceHolder1$txtF00052"://Wife Name
                                    inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00055"://Ref No
                                    inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[4].ToString());
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00057"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString());
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                    }
                                    break;
                                //azham 06-jan-2017
                                //================================================================
                                case "ctl00$ContentPlaceHolder1$txtNoPengenalanIbu": //No. Pengenalan / Pasport IBU
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[12].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[12].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtBilIbu": //Bil. Individu Yang Menuntut IBU
                                    foreach (DataRow row in dsData.Tables["P4_TAX_RELIEF"].Rows)
                                    {
                                        if (row.ItemArray[0].ToString() == "29")
                                            inpElement.value = row.ItemArray[1].ToString();
                                    }
                                     if (inpElement.value == "0") {
                                         inpElement.value = "";
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtNoPengenalanBapa": //No. Pengenalan / Pasport BAPA
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[13].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[13].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtBilBapa": //Bil. Individu Yang Menuntut BAPA
                                    foreach (DataRow row in dsData.Tables["P4_TAX_RELIEF"].Rows)
                                    {
                                        if (row.ItemArray[0].ToString() == "30")
                                            inpElement.value = row.ItemArray[1].ToString();
                                    }
                                    if (inpElement.value == "0")
                                    {
                                        inpElement.value = "";
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //azham 06-jan-2017
                                //================================================================
                                //simkh 2014 end

                                //case "ctl00$ContentPlaceHolder1$txtF00052"://Wife Name
                                //    inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[0].ToString();
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00055"://Ref No
                                //    inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[4].ToString());
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00057"://IC No/ Police No/ Army No/ Passport No
                                //    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                //    {
                                //        inpElement.value = (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString());
                                //    }
                                //    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                //    {
                                //        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString();
                                //    }
                                //    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                //    {
                                //        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString();
                                //    }
                                //    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                //    {
                                //        inpElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString();
                                //    }
                                //    break;
                                case "ctl00$ContentPlaceHolder1$txtF00052_1"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00055_1"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00057_1"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00052_2"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00055_2"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00057_2"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00052_3"://Wife Name
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[0].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00055_3"://Ref No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[2].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[3].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[4].ToString());
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00057_3"://IC No/ Police No/ Army No/ Passport No
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString() != "")
                                        {
                                            inpElement.value = (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString());
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString();
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString() != "")
                                        {
                                            inpElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString();
                                        }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$btnTambah_Isteri":
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        FireInpElementEvent(inpElement, "OnClick");
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$txtF00076"://Employment
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00077"://Dividend
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;

                                //case "ctl00$ContentPlaceHolder1$txtF00078"://Interest and Discount
                                //    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                //    {
                                //        inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString())));
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;

                                //DANNYLEE 15 FEB 2013
                                case "ctl00$ContentPlaceHolder1$txtF00078"://Interest, Discount, Royalty, Premium and etc..
                                    if (dsData.Tables["P3_INCOME_EXCLUDE_RENTAL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_INCOME_EXCLUDE_RENTAL"].Rows[0].ItemArray[0].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //END
                                //DANNYLEE 15 FEB 2013
                                case "ctl00$ContentPlaceHolder1$txtF00079"://Rent
                                    if (dsData.Tables["P3_DIVIDEND_RENTAL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_DIVIDEND_RENTAL"].Rows[0].ItemArray[1].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //END
                                case "ctl00$ContentPlaceHolder1$txtF00080"://Pension, annuities and other periodical payments
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[6].ToString()));
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00081"://Other gains or profits
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString((double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[9].ToString())));
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00090"://Gift to Government, State Government or local authorities
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("9");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00393"://Gift to approved institutions or organization
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("1");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00389"://Gift to sports activity
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("7");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00390"://Gift to contribution for project of national interest
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("8");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00091"://Gift artefacts, manuscript or painting
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("2");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00092"://Gift of library
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("3");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00093"://Gift of public facilities of disabled persons
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("4");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00094"://Gift of medical equipment to any healthcare facility
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("5");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00095"://Gift of National Art Gallery
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        dr = dsData.Tables["P3_TAX_GIFTS"].Rows.Find("6");
                                //        inpElement.value = dr["TCG_AMOUNT"].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                //dannylee 21/02/2013

                                //simkh 2014
                                case "ctl00$ContentPlaceHolder1$txtF00096": //Gift and donation

                                    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_GIFTS"].Rows[0].ItemArray[0].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    FireInpElementEvent(inpElement, "OnBlur");
                                    break;
                                //simkh end

                                //case "ctl00$ContentPlaceHolder1$txtjum_derma"://Approved Donations/Gifts/Contributions
                                //    if (dsData.Tables["P3_TAX_GIFTS"].Rows.Count > 0)
                                //    {
                                //        inpElement.value = dsData.Tables["P3_TAX_GIFTS"].Rows[0].ItemArray[0].ToString();
                                //    }
                                //    FireInpElementEvent(inpElement, "OnBlur");
                                //    break;
                                ////end
                                case "ctl00$ContentPlaceHolder1$txtF00099"://Income transfer from husband/wife
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[10].ToString();
                                        FireInpElementEvent(inpElement, "OnBlur");
                                    }
                                    break;
                                //LEESH 24 FEB 2012
                                case "ctl00$ContentPlaceHolder1$txtF00099b":
                                    if (dsData.Tables["P3_TAX_COMPUTATION"] != null && dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0) {
                                        inpElement.value = dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[13].ToString();
                                        FireInpElementEvent(inpElement, "OnBlur");
                                    }
                                    break;
                                //LEESH END
                                case "ctl00$ContentPlaceHolder1$txtF00165"://Installment/ Schedular
                                    if (dsData.Tables["P3_TAX_COMPUTATION"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[11].ToString()) + double.Parse(dsData.Tables["P3_TAX_COMPUTATION"].Rows[0].ItemArray[12].ToString()));
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$txtF00417"://Gross income from employment (weihong) 
                                    //MessageBox.Show("L");
                                    if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[0].ToString()));
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$txtF00418"://Total gross income from all sources (weihong)
                                    if (dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows.Count > 0)
                                    {
                                        inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()));
                                        if (dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
                                        {
                                            inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()));
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                        }
                                        else
                                        {
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[1].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[2].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[3].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[4].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[5].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[6].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[7].ToString()) + double.Parse(dsData.Tables["P3_INCOME_OTHERSOURCE"].Rows[0].ItemArray[8].ToString()) + double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows.Count > 0)
                                        {
                                            inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()));
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_PROFIT_LOSS_ACCOUNT"].Rows[0].ItemArray[0].ToString()) + double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                        }
                                        else
                                        {
                                            if (dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows.Count > 0)
                                            {
                                                inpElement.value = Convert.ToString(double.Parse(dsData.Tables["P3_INCOME_EMPLOYMENT"].Rows[0].ItemArray[1].ToString()));
                                            }
                                            else
                                            {
                                                inpElement.value = "";
                                            }
                                        }
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$txtF00169"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[0].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00170"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[1].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00171"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[2].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00172"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[3].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00173"://Type of income
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[0].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00174"://Year for which paid
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[1].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00175"://Gross Amount
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[2].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00176"://Provident and pension fund contribution
                                    if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                    {
                                        inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[3].ToString();
                                    }
                                    else
                                    {
                                        inpElement.value = "";
                                    }
                                    break;

                                //    switch (inpElement.name)
                                //    {
                                //        //Preceding Years Income
                                //        case "ctl00$ContentPlaceHolder1$txtF00169"://Type of income
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[0].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00170"://Year for which paid
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[1].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00171"://Gross Amount
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[2].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00172"://Provident and pension fund contribution
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 0)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[0].ItemArray[3].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00173"://Type of income
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[0].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00174"://Year for which paid
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[1].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00175"://Gross Amount
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[2].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00176"://Provident and pension fund contribution
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 1)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[1].ItemArray[3].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00177"://Type of income
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[0].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00178"://Year for which paid
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[1].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00179"://Gross Amount
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[2].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00180"://Provident and pension fund contribution
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 2)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[2].ItemArray[3].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00361"://Type of income
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[0].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00362"://Year for which paid
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[1].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00363"://Gross Amount
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[2].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00364"://Provident and pension fund contribution
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 3)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[3].ItemArray[3].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00365"://Type of income
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[0].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00366"://Year for which paid
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[1].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00367"://Gross Amount
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[2].ToString();
                                //            }
                                //            break;
                                //        case "ctl00$ContentPlaceHolder1$txtF00368"://Provident and pension fund contribution'
                                //            if (dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows.Count > 4)
                                //            {
                                //                inpElement.value = dsData.Tables["P3_PRECEDING_YEAR_DETAIL"].Rows[4].ItemArray[3].ToString();
                                //            }
                                //            break;
                                //    }
                                //    break;

                                case "ctl00$master$txtF00104"://Individual
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("1");
                                        inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    }
                                    
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00105"://Medical expenses for won parents
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("2");
                                        inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00106"://Basic supporting equipment for disabled person
                                    //dsData.Tables["P4_TAX_RELIEF"].DefaultView.RowFilter = "TCC_KEY = 3";
                                    //inpElement.value = dsData.Tables["P4_TAX_RELIEF"].Select();
                                    //dtOverAll.PrimaryKey = new DataColumn[] { dtOverAll.Columns["ITEMNMBR"] };
                                    //dsData.Tables["P4_TAX_RELIEF"].PrimaryKey = new DataColumn[] { dsData.Tables["P4_TAX_RELIEF"].Columns["TCC_KEY"] };
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0) {
                                        dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("3");
                                        inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    }
                                    
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00107"://Disabled individual
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0) {
                                        dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("4");
                                        inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    }  
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00108"://Education fees
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0) {
                                        dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("5");
                                        inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00109"://Medical expenses for self/ spouse/ child
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0) {
                                        dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("6");
                                        inpElement.value = dr["TCC_AMOUNT"].ToString();
                                        FireInpElementEvent(inpElement, "OnClick");
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00110"://Complete medical examination for self/ spouse/ child
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0) {
                                        dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("7");
                                        inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00112"://Purchase books/ megazines
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0) {
                                        dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("8");
                                        inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00391"://Purchase personal computers
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0) {
                                        dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("21");
                                        inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00392"://Skim Simapanan Pendidikan Nasional
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0) {
                                        dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("22");
                                        inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00395"://Purchase sports equipment
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0) {
                                        dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("23");
                                        inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00404"://Housing load interest
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0) {
                                        dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("9");
                                        inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00116"://Husband/ wife/ payment of alimony
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0) {
                                        dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("10");
                                        inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00118"://Disabled husband/ wife
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0) {
                                        dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("13");
                                        inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00397"://No. child own self
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD"].Rows.Count);
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00398"://No. child husband/ wife
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_HW"].Rows.Count + dsData.Tables["P4_TAX_RELIEF_CHILD_HW_OTHERS"].Rows.Count);
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00396"://No. children eligible for deduction
                                    inpElement.value = Convert.ToString((dsData.Tables["P4_TAX_RELIEF_CHILD"].Rows.Count) + (dsData.Tables["P4_TAX_RELIEF_CHILD_HW"].Rows.Count) + (dsData.Tables["P4_TAX_RELIEF_CHILD_HW_OTHERS"].Rows.Count));
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00120"://No. child under 18 - 1000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_2000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_2000"].Rows.Count;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00121"://Amount child under 18 - 1000
                                    inpElement.value = Convert.ToString(nTotal * 1000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00122"://No. child under 18 - 500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_1000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_UNDER18_1000"].Rows.Count;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00123"://Amount child under 18 - 500
                                    inpElement.value = Convert.ToString(nTotal * 1000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00124"://Total amount child under 18
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0) {
                                        dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("14");
                                        inpElement.value = dr["TCC_AMOUNT"].ToString();                 
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00357"://No. child 18 and above - 1000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_2000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_2000"].Rows.Count;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00371"://Amount child 18 and above - 1000
                                    inpElement.value = Convert.ToString(nTotal * 2000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00358"://No. child 18 and above - 500
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_1000_50"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_1000_50"].Rows.Count;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00372"://Amount child 18 and above - 500
                                    inpElement.value = Convert.ToString(nTotal * 1000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00359"://No. child 18 and above - 4000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_8000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_8000"].Rows.Count;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00373"://Amount child 18 and above - 4000
                                    inpElement.value = Convert.ToString(nTotal * 8000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00360"://No. child 18 and above - 2000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_8000_50"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_18ABOVE_8000_50"].Rows.Count;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00374"://Amount child 18 and above - 2000
                                    inpElement.value = Convert.ToString(nTotal * 4000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00133"://Total amount child 18 and above
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0) {
                                        dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("15");
                                        inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    }
                                    
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00135"://No. disabled child - 6000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_6000_100"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_6000_100"].Rows.Count;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00136"://Amount disabled child - 6000 claim 100%
                                    inpElement.value = Convert.ToString(nTotal * 6000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00137"://No. disabled child - 3000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_3000_50"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_3000_50"].Rows.Count;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00138"://Amount disabled child - 3000
                                    inpElement.value = Convert.ToString(nTotal * 3000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00369"://No. disabled child - 12000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_14000"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_14000"].Rows.Count;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00375"://Amount disabled child - 12000
                                    inpElement.value = Convert.ToString(nTotal * 14000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00370"://No. disabled child - 6000
                                    inpElement.value = Convert.ToString(dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_7000_50"].Rows.Count);
                                    nTotal = dsData.Tables["P4_TAX_RELIEF_CHILD_DISABLED_7000_50"].Rows.Count;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00376"://Amount disabled child - 6000
                                    inpElement.value = Convert.ToString(nTotal * 7000);
                                    nTotal = 0;
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00139"://Total amount disabled child
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0) {
                                        dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("16");
                                        inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    }
                                    
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00140"://Life insurance and providend fund
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0) {
                                        dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("17");
                                        inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    }
                                    
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00141"://Education and medical insurance
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0) {
                                        dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("18");
                                        inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtSocso"://Education and medical insurance
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0)
                                    {
                                        dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("28");
                                        if (dr != null)
                                        {
                                            inpElement.value = dr["TCC_AMOUNT"].ToString();
                                        }
                                        else
                                        {
                                            inpElement.value = "0";
                                        }
                                    }
                                    else {
                                        inpElement.value = "0";
                                    }
                                   
                                       break;

                                case "ctl00$ContentPlaceHolder1$txtF00411"://Internet Broadband weihong 
                                       if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0) {
                                           dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("24");
                                           inpElement.value = dr["TCC_AMOUNT"].ToString();   
                                       }
                                    
                                    break;

                                case "ctl00$ContentPlaceHolder1$txtF00412"://Differed Anuities weihong 
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0) {
                                        dr = dsData.Tables["P4_TAX_RELIEF"].Rows.Find("25");
                                        inpElement.value = dr["TCC_AMOUNT"].ToString();
                                    }
                                    
                                    break;

                                //simkh 2014
                                case "ctl00$ContentPlaceHolder1$txtF00155":
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0) {
                                        dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("3");
                                        inpElement.value = dr["TCR_AMOUNT"].ToString();
                                    }
                                    
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00160":
                                    if (dsData.Tables["P5_TAX_COMPUTATION"] != null && dsData.Tables["P5_TAX_COMPUTATION"].Rows.Count > 0) {
                                        inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
                                    }
                                    
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00161":
                                    if (dsData.Tables["P5_TAX_COMPUTATION"] != null && dsData.Tables["P5_TAX_COMPUTATION"].Rows.Count > 0) {
                                        inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
                                    }
                                    
                                    break;
                                case "ctl00$ContentPlaceHolder1$txtF00346":
                                    if (dsData.Tables["P5_TAX_COMPUTATION"] != null && dsData.Tables["P5_TAX_COMPUTATION"].Rows.Count > 0) {
                                        inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString();
                                    }
                                    
                                    break;
                                //simkh end

                                //case "ctl00$ContentPlaceHolder1$txtF00155":
                                //    dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("3");
                                //    inpElement.value = dr["TCR_AMOUNT"].ToString();
                                //    break;
                                case "ctl00$ContentPlaceHolder1$txtF00157":
                                    if (dsData.Tables["P4_TAX_RELIEF"] != null && dsData.Tables["TCC_AMOUNT"] != null && dsData.Tables["P4_TAX_RELIEF"].Rows.Count > 0) {
                                        dr = dsData.Tables["P5_TAX_REBATE"].Rows.Find("5");
                                        inpElement.value = dr["TCR_AMOUNT"].ToString();
                                    }
                                    
                                    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00160":
                                //    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[0].ToString();
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00161":
                                //    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[1].ToString();
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00346":
                                //    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[2].ToString();
                                //    break;
                                //case "ctl00$ContentPlaceHolder1$txtF00347":
                                //    inpElement.value = dsData.Tables["P5_TAX_COMPUTATION"].Rows[0].ItemArray[3].ToString();
                                //    break;

                                //case "ctl00$ContentPlaceHolder1$txtF00282":
                                //    inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[0].ToString();
                                //    break;

                                case "ctl00$ContentPlaceHolder1$txtF00293":
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[2].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString();
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$txtF00290":
                                    inpElement.value = dsData.Tables["P6_TAXA_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;

                                //weihong NAMA PENTADBIR HARTA PUSAKA 
                                case "ctl00$ContentPlaceHolder1$txtF00183":
                                    inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[0].ToString();
                                    break;

                                //weihong NOMBOR JENIS PENGENALAN (NUMBER INDENTITY TYPE) 
                                case "ctl00$ContentPlaceHolder1$txtF00185":
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[2].ToString() +
                                            dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString();
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        inpElement.value = dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString();
                                    }
                                    break;
                                //endweihong
                            }
                            break;
                #endregion
                    }
                }

                #region "SELECT"
                foreach (mshtml.HTMLSelectElement selElement in htmlDoc.getElementsByTagName("select"))
                {
                    switch (strPageIndex)
                    {
                        #region "Page 1"
                        case "BE2016Page1":
                            ErrorLog = selElement.name;
                            switch (selElement.name)
                            {
                                case "ctl00$ContentPlaceHolder1$ddlF00011"://Citizan
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00012"://Sex
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[2].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00377_Hari"://Date of Birth -Day
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[2].ToString()))
                                    {
                                        DateTime dtBirthDate = Convert.ToDateTime(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[2].ToString());
                                        selElement.value = dtBirthDate.ToString("dd");
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00377_Bulan"://Date of Birth -month
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[2].ToString()))
                                    {
                                        DateTime dtBirthDate = Convert.ToDateTime(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[2].ToString());
                                        selElement.value = dtBirthDate.ToString("MM");
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00379_Hari": //wife
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[3].ToString()))
                                    {
                                        DateTime dtBirthDate = Convert.ToDateTime(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[3].ToString());
                                        selElement.value = dtBirthDate.ToString("dd");
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00379_Bulan": //wife
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[3].ToString()))
                                    {
                                        DateTime dtBirthDate = Convert.ToDateTime(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[3].ToString());
                                        selElement.value = dtBirthDate.ToString("MM");
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00181"://Date of Birth -month
                                    try
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["DISPOSAL"].Rows[0].ItemArray[1].ToString()))
                                        {
                                            if (dsData.Tables["DISPOSAL"].Rows[0].ItemArray[1].ToString().ToUpper() == "YES")
                                            {
                                                selElement.value = "1";
                                            }
                                            else
                                            {
                                                selElement.value = "2";
                                            }
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        selElement.value = "2";
                                    }

                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00182":
                                    try
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["DISPOSAL"].Rows[0].ItemArray[2].ToString()))
                                        {
                                            if (dsData.Tables["DISPOSAL"].Rows[0].ItemArray[2].ToString().ToUpper() == "YES")
                                            {
                                                selElement.value = "1";
                                            }
                                            else
                                            {
                                                selElement.value = "2";
                                            }
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        selElement.value = "2";
                                    }

                                    break;
                                //azham 14-mar-2016 =========================
                                case "ctl00$ContentPlaceHolder1$ddlF00013"://Status
                                    selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00014_Hari":////Date of Marriage/Divorce/Demise - Hari

                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            DateTime dtBirthDate = Convert.ToDateTime(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString());
                                            selElement.value = dtBirthDate.ToString("dd");
                                            //selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(0, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            DateTime dtBirthDate = Convert.ToDateTime(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString());
                                            selElement.value = dtBirthDate.ToString("dd");
                                            //selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(0, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00014_Bulan":////Date of Marriage/Divorce/Demise - Bulan
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                        {
                                            DateTime dtBirthDate = Convert.ToDateTime(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString());
                                            selElement.value = dtBirthDate.ToString("MM");
                                            //selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[4].ToString().IndexOf('/') + 1, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    else if ((dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "3") || (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "4"))
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                        {
                                            DateTime dtBirthDate = Convert.ToDateTime(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString());
                                            selElement.value = dtBirthDate.ToString("MM");
                                           // selElement.value = dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().Substring(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[5].ToString().IndexOf('/') + 1, 2);
                                        }
                                        else
                                        {
                                            selElement.value = "";
                                        }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00016"://Type of Assessment
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "1")
                                    {
                                        if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[21].ToString()))
                                        {
                                            if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[21].ToString() == "1")
                                            { selElement.value = "1"; }
                                            else
                                            { selElement.value = "2"; }
                                        }
                                    }
                                    else if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "2")
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() == "3")
                                    {
                                        //weihong
                                        if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[3].ToString() == "2")
                                        { selElement.value = "4"; }
                                        else
                                        { selElement.value = "5"; }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00018"://Public Rulings weihong
                                    if (dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() == "1")
                                    { selElement.value = "1"; }
                                    else
                                    { selElement.value = "2"; }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00024"://Correspondence Add - State
                                    selElement.value = SelectState(dsData.Tables["P1_TAX_PROFILE"].Rows[0].ItemArray[13].ToString());
                                    break;

                                case "ctl00$ContentPlaceHolder1$ddlF00044"://Bank Name
                                    if (dsData.Tables["P1_SELECT_BANK"].Rows.Count > 0)
                                    {
                                        selElement.value = SelectBank(dsData.Tables["P1_SELECT_BANK"].Rows[0].ItemArray[0].ToString());
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$ddlF00408"://Knowledge worker approval (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = "1";
                                    }
                                    else
                                    {
                                        selElement.value = "2";
                                    }
                                    FireSelElementEvent(selElement, "OnClick");
                                    break;

                                case "ctl00$ContentPlaceHolder1$ddlF00409_hari"://Date Knowledge worker approval - HARI (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().Substring(0, 2);
                                    }
                                    else
                                    {
                                        selElement.value = "";
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$ddlF00409_bln"://Date Knowledge worker approval - BULAN (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().Substring(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().IndexOf('/') + 1, 2);
                                    }
                                    else
                                    {
                                        selElement.value = "";
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$ddlF00409_thn"://Date Knowledge worker approval - TAHUN (weihong)
                                    if (!String.IsNullOrEmpty(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString()))
                                    {
                                        selElement.value = dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().Substring(dsData.Tables["P1_TAX_PROFILE2"].Rows[0].ItemArray[0].ToString().LastIndexOf('/') + 1, 4);
                                    }
                                    else
                                    {
                                        selElement.value = "";
                                    }
                                    break;

                                //case "ctl00$ContentPlaceHolder1$ddlsurat_negara": //Negara Menyurat weihong
                                //    selElement.value = dsData.Tables["P1_INPUT_TAX_PROFILE"].Rows[0].ItemArray[13].ToString();
                                //    break;

                                //simkh 2014
                                case "ctl00$ContentPlaceHolder1$ddlJPengenalan_isteri"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                    {
                                        selElement.value = "1";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                    {
                                        selElement.value = "4";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                    {
                                        selElement.value = "2";
                                    }
                                    break;
                                //simkh end
                            }
                            FireSelElementEvent(selElement, "OnChange");
                            break;
                        #endregion

                        #region "Page 2"
                        case "BE2016Page2":
                            switch (selElement.name)
                            {
                                case "ctl00$ContentPlaceHolder1$ddlF00054"://Ref Prefix
                                    selElement.value = dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[1].ToString();
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlJPengenalan_isteri"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[7].ToString() != "")
                                    {
                                        selElement.value = "1";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[8].ToString() != "")
                                    {
                                        selElement.value = "4";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[9].ToString() != "")
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (dsData.Tables["P2_TAX_PROFILE"].Rows[0].ItemArray[10].ToString() != "")
                                    {
                                        selElement.value = "2";
                                    }
                                    break;

                                case "ctl00$ContentPlaceHolder1$ddlF00054_1"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlJPengenalan_isteri_1"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 0)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[0].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00054_2"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlJPengenalan_isteri_2"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 1)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[1].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlF00054_3"://Ref Prefix
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        selElement.value = dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[1].ToString();
                                    }
                                    break;
                                case "ctl00$ContentPlaceHolder1$ddlJPengenalan_isteri_3"://Identity Type
                                    if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows.Count > 2)
                                    {
                                        if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[5].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[6].ToString() + dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[7].ToString() != "")
                                        {
                                            selElement.value = "1";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[8].ToString() != "")
                                        {
                                            selElement.value = "4";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[9].ToString() != "")
                                        {
                                            selElement.value = "3";
                                        }
                                        else if (dsData.Tables["P2_TAX_PROFILE_HW_OTHERS"].Rows[2].ItemArray[10].ToString() != "")
                                        {
                                            selElement.value = "2";
                                        }
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 3"
                        case "BE2016Page3":
                            switch (selElement.name)
                            {
                                case "ctl00$ContentPlaceHolder1$ddlF00355"://Type of income transfer from husband/wife
                                    bool boolHaveBusiness = false;
                                    for (int i = 0; i < dsData.Tables["P3_TAX_PROFILE_OTHER"].Rows.Count; i++)
                                    {
                                        if (dsData.Tables["P3_TAX_PROFILE_OTHER"].Rows[i].ItemArray[11].ToString() == "1")
                                        {
                                            boolHaveBusiness = true;
                                            break;
                                        }
                                    }
                                    if (dsData.Tables["P3_TAX_PROFILE"].Rows[0].ItemArray[11].ToString() == "1" || boolHaveBusiness == true)
                                    {
                                        selElement.value = "1";//Ada pendapatan perniagaan (With business income)
                                    }
                                    else //if (dsData.Tables["P3_TAX_PROFILE"].Rows[0].ItemArray[11].ToString() == "2")
                                    {
                                        selElement.value = "2";//Tiada punca pendapatan perniagaan (Without business income)
                                    }
                                    break;
                            }
                            break;
                        #endregion

                        #region "Page 7"
                        //case "BE2009Page7":
                        //    switch (selElement.name)
                        //    {
                        //        case "ctl00$master$ddlJPengenalan_mati":
                        //            if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                        //            {
                        //                selElement.value = "NEWIC";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                        //            {
                        //                selElement.value = "POLICE";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                        //            {
                        //                selElement.value = "ARMY";
                        //            }
                        //            else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                        //            {
                        //                selElement.value = "PASSPORT";
                        //            }
                        //            FireSelElementEvent(selElement, "OnChange");
                        //            break;
                        //    }
                        //    break;

                        //weihong JENIS PENGENALAN (INDENTITY TYPE)
                        case "BE2016Page7":
                            switch (selElement.name)
                            {
                                case "ctl00$ContentPlaceHolder1$ddlJPengenalan_mati":
                                    //selElement.removeAttribute("selected", 1);
                                    if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[1].ToString()))
                                    {
                                        selElement.value = "1";
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[4].ToString()))
                                    {
                                        selElement.value = "4"; ;
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[5].ToString()))
                                    {
                                        selElement.value = "3";
                                    }
                                    else if (!String.IsNullOrEmpty(dsData.Tables["P6_TAXADM_PROFILE"].Rows[0].ItemArray[6].ToString()))
                                    {
                                        selElement.value = "2";
                                    }
                                    FireSelElementEvent(selElement, "OnChange");
                                    break;
                            }//endweihong
                            break;
                        #endregion
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ErrorLog + " || " + ex.Message);
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            //dannylee end
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

        private string SelectBank(string strData)
        {
            strData = strData.ToUpper();
            switch (strData)
            {
                //case "AGRO BANK": return "22";
                //case "ALLIANCE BANK MALAYSIA BERHAD": return "02";
                //case "AM BANK BERHAD": return "03";
                //case "BANK ISLAM MALAYSIA BERHAD": return "05";
                //case "BANK KERJASAMA RAKYAT MALAYSIA BHD": return "06";
                //case "BANK MUAMALAT MALAYSIA BERHAD": return "04";
                //case "BANK OF AMERICA MALAYSIA BERHAD": return "21";
                //case "BANK SIMPANAN NASIONAL": return "17";
                //case "CIMB BANK BERHAD": return "07";
                //case "CITIBANK BERHAD": return "13";
                //case "DEUTSCHE BANK (MALAYSIA) BERHAD": return "19";
                //case "EON BANK BERHAD": return "08";
                //case "HONG LEONG BANK": return "09";
                //case "HONGKONG & SHANGHAI BANK MALAYSIA BHD": return "15";
                //case "J.P. MORGAN CHASE BANK BHD": return "23";
                //case "KUWAIT FINANCE HOUSE MALAYSIA BHD": return "24";
                //case "MALAYAN BANKING BERHAD": return "10";
                //case "OCBC AL-AMIN BANK BHD":
                //case "OCBC BANK MALAYSIA BHD": return "14";
                //case "PUBLIC BANK BERHAD":
                //case "PUBLIC ISLAMIC BANK BERHAD": return "11";
                //case "RHB BANK BERHAD": return "12";
                //case "STANDARD CHARTERED BANK MALAYSIA BHD": return "16";
                //case "THE ROYAL BANK OF SCOTLAND": return "20";
                //case "UNITED OVERSEAS BANK (MALAYSIA) BERHAD": return "18";
                //default: return "";
                case "AFFIN BANK BERHAD": return "01";
                case "ALLIANCE BANK MALAYSIA BERHAD": return "02";
                case "AMBANK BERHAD": return "03";
                case "BANK MUAMALAT MALAYSIA BERHAD": return "04";
                case "BANK ISLAM MALAYSIA BERHAD": return "05";
                case "BANK KERJASAMA RAKYAT MALAYSIA BHD": return "06";
                case "CIMB BANK BERHAD": return "07";
                case "EON BANK BERHAD": return "08";
                case "HONG LEONG BANK": return "09";
                case "MALAYAN BANKING BERHAD": return "10";
                case "PUBLIC BANK BERHAD": return "11";
                case "RHB BANK BERHAD": return "12";
                case "CITIBANK BERHAD": return "13";
                case "OCBC BANK MALAYSIA BHD": return "14";
                case "HSBC BANK MALAYSIA BERHAD":
                case "HONGKONG BANK MALAYSIA BHD": return "15";
                case "STANDARD CHARTERED BANK MALAYSIA BHD": return "16";
                case "BANK SIMPANAN NASIONAL": return "17";
                case "UNITED OVERSEAS BANK (MALAYSIA) BERHAD": return "18";
                case "DEUTSCHE BANK (MALAYSIA) BERHAD": return "19";
                case "THE ROYAL BANK OF SCOTLAND BERHAD": return "20";
                case "BANK OF AMERICA MALAYSIA BERHAD": return "21";
                case "AGRO BANK": return "22";
                case "JP MORGAN CHASE BANK BHD": return "23";
                case "KUWAIT FINANCE HOUSE MALAYSIA BERHAD": return "24";
                case "BANK OF TOKYO-MITSUBISHI (M) BERHAD": return "25";
                case "SUMITOMO MITSUI BANKING CORPORATION": return "26";
                case "AL RAJHI BANKING & INVESTMENT CORPORATION": return "27";
                default: return "";
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

        public static string Right(string param, int length)
        {
            //start at the index based on the lenght of the sting minus
            //the specified lenght and assign it a variable
            string result = param.Substring(param.Length - length, length);
            //return the result of the operation
            return result;
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

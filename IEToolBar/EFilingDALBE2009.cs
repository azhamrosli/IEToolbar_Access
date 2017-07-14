using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;

namespace IEToolBar
{
    public class EFilingDALBE2009 : EFilingDALB
    {
        
        public EFilingDALBE2009()
        {
        }

        public EFilingDALBE2009(string strTaxPayer, string strYA, string strTaxAgent)// string strAuditor, string strTaxAgent)
        {
            this.strTaxPayer = strTaxPayer;
            this.strYA = strYA;
            //this.strAuditor = strAuditor;
            this.strTaxAgent = strTaxAgent;
        }

        public DataSet GetFormDataBE2009(string strPage)
        {
            string strQuery = "";
            OdbcCommand cmdOdbc = new OdbcCommand();
            OdbcDataAdapter daOdbc;
            DataTable dtTemp = new DataTable();
            DataSet dsData = new DataSet();

            try
            {
                if (connOdbc.State == ConnectionState.Closed)
                    connOdbc.Open();
                switch (strPage)
                {
                    case "BE2009Page1":
                        strQuery = "SELECT TP_PASSPORT_NO, TP_COUNTRY, TP_GENDER, TP_STATUS, FORMAT(TP_DATE_MARRIAGE,'dd/mm/yyyy'), " +
                        "FORMAT(TP_DATE_DIVORCE,'dd/mm/yyyy'), TP_TYPE_ASSESSMENT, TP_KUP, TP_CURR_ADD_LINE1, TP_CURR_ADD_LINE2, " +
                        "TP_CURR_ADD_LINE3, TP_CURR_POSTCODE, TP_CURR_CITY, TP_CURR_STATE, TP_TEL1, " +
                        "TP_TEL2, TP_EMPLOYER_NO2, TP_EMPLOYER_NO3, TP_EMAIL, TP_BANK, " +
                        "TP_BANK_ACC, TP_ASSESSMENTON " +
                        "FROM TAXP_PROFILE WHERE TP_5=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_TAX_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select b.bk_desc from taxp_profile t, bank b where tp_5=? and t.tp_bank=b.bk_name";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_SELECT_BANK");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                    case "BE2009Page2":
                        strQuery = "SELECT TP_HW_NAME, TP_HW_REF_NO_PREFIX, TP_HW_REF_NO1, TP_HW_REF_NO2, TP_HW_REF_NO3, " +
                        "TP_HW_IC_NEW1, TP_HW_IC_NEW2, TP_HW_IC_NEW3, TP_HW_POLICE_NO, TP_HW_ARMY_NO, " +
                        "TP_HW_PASSPORT_NO, TP_HW_TYPEOFINCOME " +
                        "FROM TAXP_PROFILE WHERE TP_5=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P2_TAX_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT TP_HW_NAME, TP_HW_REF_NO_PREFIX, TP_HW_REF_NO1, TP_HW_REF_NO2, TP_HW_REF_NO3, " +
                        "TP_HW_IC_NEW1, TP_HW_IC_NEW2, TP_HW_IC_NEW3, TP_HW_POLICE_NO, TP_HW_ARMY_NO, " +
                        "TP_HW_PASSPORT_NO, TP_HW_TYPEOFINCOME " +
                        "FROM TAXP_PROFILE_HW_OTHERS WHERE TP_REF_NO=? ORDER BY TP_HW_ORDER";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P2_TAX_PROFILE_HW_OTHERS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                    case "BE2009Page3":
                        strQuery = "select TC_EMPLOYMENT_INCOME, TC_DIVIDEND, TC_INTEREST, TC_DISCOUNT, TC_RENTAL_ROYALTY, " +
                        "TC_PREMIUM, TC_PENSION_AND_ETC, TC_OTHER_GAIN_PROFIT, TC_SEC4A, TC_ADDITION_43, " +
                        "TC_INCOME_TRANSFER_FROM_HW, TC_INSTALLMENT_PAYMENT_SELF, TC_INSTALLMENT_PAYMENT_HW " +
                        "FROM TAX_COMPUTATION WHERE TC_REF_NO=? AND TC_YA=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_TAX_COMPUTATION");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select TCG_KEY, TCG_AMOUNT " +
                        "FROM TAX_GIFTS WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?) ORDER BY TCG_KEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_TAX_GIFTS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        dsData.Tables["P3_TAX_GIFTS"].PrimaryKey = new DataColumn[] { dsData.Tables["P3_TAX_GIFTS"].Columns["TCG_KEY"] };
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT TP_HW_NAME, TP_HW_REF_NO_PREFIX, TP_HW_REF_NO1, TP_HW_REF_NO2, TP_HW_REF_NO3, " +
                        "TP_HW_IC_NEW1, TP_HW_IC_NEW2, TP_HW_IC_NEW3, TP_HW_POLICE_NO, TP_HW_ARMY_NO, " +
                        "TP_HW_PASSPORT_NO, TP_HW_TYPEOFINCOME " +
                        "FROM TAXP_PROFILE WHERE TP_5=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_TAX_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //NGOHCS B2010.2 
                        strQuery = "SELECT TP_HW_NAME, TP_HW_REF_NO_PREFIX, TP_HW_REF_NO1, TP_HW_REF_NO2, TP_HW_REF_NO3, " +
                        "TP_HW_IC_NEW1, TP_HW_IC_NEW2, TP_HW_IC_NEW3, TP_HW_POLICE_NO, TP_HW_ARMY_NO, " +
                        "TP_HW_PASSPORT_NO, TP_HW_TYPEOFINCOME " +
                        "FROM TAXP_PROFILE_HW_OTHERS WHERE TP_REF_NO=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_TAX_PROFILE_OTHER");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        //NGOHCS B2010.2 END
                        break;

                    case "BE2009Page4":
                        strQuery = "SELECT TOP 5 PY_INCOME_TYPE, PY_PAYMENT_YEAR, PY_AMOUNT, PY_EPF " +
                        "FROM PRECEDING_YEAR_DETAIL WHERE PY_KEY IN (SELECT PY_KEY FROM PRECEDING_YEAR WHERE PY_REF_NO=? and PY_YA=?) ORDER BY PY_DKEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_PRECEDING_YEAR_DETAIL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                    case "BE2009Page5":
                        strQuery = "select TCC_KEY, TCC_AMOUNT " +
                        "FROM TAX_RELIEF WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?) ORDER BY TCC_KEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_TAX_RELIEF");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        dsData.Tables["P4_TAX_RELIEF"].PrimaryKey = new DataColumn[] { dsData.Tables["P4_TAX_RELIEF"].Columns["TCC_KEY"] };
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select TCC_KEY, TCC_100, TCC_50 " +
                        "FROM TAX_RELIEF_CHILD WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?) ORDER BY TCC_KEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_TAX_RELIEF_CHILD");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select TCC_KEY, TCC_100, TCC_50 " +
                        "FROM TAX_RELIEF_CHILD WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO IN (SELECT TP_HW_REF_NO1 FROM TAXP_PROFILE WHERE TP_5=?) AND TC_YA=?) ORDER BY TCC_KEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_TAX_RELIEF_CHILD_HW");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select TCC_KEY, TCC_100, TCC_50 " +
                        "FROM TAX_RELIEF_CHILD WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO IN (SELECT TP_HW_REF_NO1 FROM TAXP_PROFILE_HW_OTHERS WHERE TP_REF_NO=?) AND TC_YA=?) ORDER BY TCC_KEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_TAX_RELIEF_CHILD_HW_OTHERS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select TCC_KEY, TCC_100, TCC_50 " +
                        "FROM TAX_RELIEF_CHILD WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?) AND TCC_KEY = 14 AND TCC_RELIEF = '1,000'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_TAX_RELIEF_CHILD_UNDER18_1000");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select TCC_KEY, TCC_100, TCC_50 " +
                        "FROM TAX_RELIEF_CHILD WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?) AND TCC_KEY = 14 AND TCC_RELIEF = '500'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_TAX_RELIEF_CHILD_UNDER18_500");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select TCC_KEY, TCC_100, TCC_50 " +
                        "FROM TAX_RELIEF_CHILD WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?) AND TCC_KEY = 15 AND TCC_RELIEF = '1,000'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_TAX_RELIEF_CHILD_18ABOVE_1000");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select TCC_KEY, TCC_100, TCC_50 " +
                        "FROM TAX_RELIEF_CHILD WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?) AND TCC_KEY = 15 AND TCC_RELIEF = '500'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_TAX_RELIEF_CHILD_18ABOVE_500");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select TCC_KEY, TCC_100, TCC_50 " +
                        "FROM TAX_RELIEF_CHILD WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?) AND TCC_KEY = 15 AND TCC_RELIEF = '4,000'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_TAX_RELIEF_CHILD_18ABOVE_4000");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select TCC_KEY, TCC_100, TCC_50 " +
                        "FROM TAX_RELIEF_CHILD WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?) AND TCC_KEY = 15 AND TCC_RELIEF = '2,000'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_TAX_RELIEF_CHILD_18ABOVE_2000");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select TCC_KEY, TCC_100, TCC_50 " +
                        "FROM TAX_RELIEF_CHILD WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?) AND TCC_KEY = 16 AND TCC_RELIEF = '5,000'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_TAX_RELIEF_CHILD_DISABLED_5000");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select TCC_KEY, TCC_100, TCC_50 " +
                        "FROM TAX_RELIEF_CHILD WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?) AND TCC_KEY = 16 AND TCC_RELIEF = '2,500'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_TAX_RELIEF_CHILD_DISABLED_2500");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select TCC_KEY, TCC_100, TCC_50 " +
                        "FROM TAX_RELIEF_CHILD WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?) AND TCC_KEY = 16 AND TCC_RELIEF = '9,000'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_TAX_RELIEF_CHILD_DISABLED_9000");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select TCC_KEY, TCC_100, TCC_50 " +
                        "FROM TAX_RELIEF_CHILD WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?) AND TCC_KEY = 16 AND TCC_RELIEF = '4,500'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_TAX_RELIEF_CHILD_DISABLED_4500");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;
                    case "BE2009Page6":
                        strQuery = "select TCR_KEY, TCR_AMOUNT " +
                        "FROM TAX_REBATE WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?) ORDER BY TCR_KEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P5_TAX_REBATE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        dsData.Tables["P5_TAX_REBATE"].PrimaryKey = new DataColumn[] { dsData.Tables["P5_TAX_REBATE"].Columns["TCR_KEY"] };
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select TC_SEC110_DIVIDEND, TC_SEC110_OTHERS, TC_1, TC_2 " +
                        "FROM TAX_COMPUTATION WHERE TC_REF_NO=? AND TC_YA=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P5_TAX_COMPUTATION");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                    case "BE2009Page7":
                        strQuery = "select TP_ADM_NAME, TP_ADM_IC_NEW1, TP_ADM_IC_NEW2, TP_ADM_IC_NEW3, TP_ADM_POLICE_NO, TP_ADM_ARMY_NO, TP_ADM_PASSPORT_NO " +
                        "FROM TAXP_PROFILE WHERE TP_5=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P6_TAXADM_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select TA_TEL_NO " +
                        "FROM TAXA_PROFILE WHERE TA_CO_NAME=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxagent", strTaxAgent));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P6_TAXA_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                    case "BE2009Page9":
                        strQuery = "select format(div_date,'dd MMM yyyy') as [Date of Payment], Iif(div_year_end is null,format(div_date,'dd MMM yyyy'),format(div_year_end,'dd MMM yyyy')) as [Year End], div_serialno as [Waran No], div_company as [Company Name], div_gross as [Gross Dividend], DIV_RATE as [Tax Rate], "
                        + "div_tax as [Tax Deducted], div_net as [Net Dividend], os_dv_interest as [Dividend Interest]"
                        + "from income_othersource inner join income_os_dividend on income_othersource.os_key = income_os_dividend.os_key "
                        + "where income_othersource.os_ref_no =? and income_othersource.os_ya =?";

                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P12_HK3_MASTER");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;
                }
            }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show(ex.ToString()); }
            return dsData;
        }
    }
}

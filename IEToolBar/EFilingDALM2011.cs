using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;

namespace IEToolBar
{
    public class EFilingDALM2011 : EFilingDALB
    {
        public EFilingDALM2011()
        {
        }

        public EFilingDALM2011(string strTaxPayer, string strYA, string strTaxAgent)
        {
            this.strTaxPayer = strTaxPayer;
            this.strYA = strYA;
            this.strTaxAgent = strTaxAgent;
        }

        public DataSet GetFormDataM2011(string strPage)
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
                    case "M2011Page1":
                        strQuery = "SELECT TP_PASSPORT_NO, FORMAT(TP_PASSWPORTDUEDATE,'dd/mm/yyyy'), TP_RESIDENCE, TP_COUNTRY, TP_GENDER, " +
                        "TP_STATUS, FORMAT(TP_DATE_MARRIAGE,'dd/mm/yyyy'), FORMAT(TP_DATE_DIVORCE,'dd/mm/yyyy'), TP_TYPE_ASSESSMENT, TP_KUP, " +
                        "TP_CURR_ADD_LINE1, TP_CURR_ADD_LINE2, TP_CURR_ADD_LINE3, TP_CURR_POSTCODE, TP_CURR_CITY, " +
                        "TP_CURR_STATE, TP_REG_ADD_LINE1, TP_REG_ADD_LINE2, TP_REG_ADD_LINE3, TP_REG_POSTCODE, " +
                        "TP_REG_CITY, TP_REG_STATE, TP_COM_ADD_LINE1, TP_COM_ADD_LINE2, TP_COM_ADD_LINE3, " +
                        "TP_COM_POSTCODE, TP_COM_CITY, TP_COM_STATE, TP_TEL1, TP_TEL2, " +
                        "TP_EMAIL, TP_BANK, TP_BANK_ACC, TP_EMPLOYERNAME, TP_EMPLOYER_NO2, " +
                        "TP_EMPLOYER_NO3, TP_ASSESSMENTON " +
                        "FROM TAXP_PROFILE WHERE TP_5=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_TAX_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //weihong FORMAT(TP_WORKER_APPROVEDATE)
                        strQuery = "SELECT FORMAT(TP_DOB,'dd/mm/yyyy'), FORMAT(TP_WORKER_APPROVEDATE,'dd/mm/yyyy'), TP_COM_ADD_STATUS " +
                        "FROM TAXP_PROFILE2 WHERE TP_REF_NO=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_TAXP_PROFILE2");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT TP_BWA FROM TAXP_PROFILE2 WHERE TP_REF_NO=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_TAX_PROFILE_OTHERS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum(tca_cbl) from tax_adjusted_loss where tc_key in (select tc_key from tax_computation where tc_ref_no =? and tc_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_ADJUSTED_LOSS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                    case "M2011Page2":
                        strQuery = "SELECT TP_HW_NAME, TP_HW_REF_NO_PREFIX, TP_HW_REF_NO1, TP_HW_REF_NO2, TP_HW_REF_NO3, " +
                        "TP_HW_IC_NEW1, TP_HW_IC_NEW2, TP_HW_IC_NEW3, TP_HW_POLICE_NO, TP_HW_ARMY_NO, " +
                        "TP_HW_PASSPORT_NO, FORMAT(TP_PASSWPORTDUEDATE2,'dd/mm/yyyy') " +
                        "FROM TAXP_PROFILE WHERE TP_5=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P2_TAX_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT TP_HW_LAST_PASSPORT_NO, FORMAT(TP_HW_DOB,'dd/mm/yyyy') " +
                        "FROM TAXP_PROFILE2 WHERE TP_REF_NO=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_TAXP_PROFILE2");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //lyeyc
                        strQuery = "SELECT TP_HW_NAME, TP_HW_REF_NO_PREFIX, TP_HW_REF_NO1, TP_HW_REF_NO2, TP_HW_REF_NO3, TP_HW_IC_NEW1, TP_HW_IC_NEW2, TP_HW_IC_NEW3, TP_HW_POLICE_NO, TP_HW_ARMY_NO, TP_HW_PASSPORT_NO, TP_HW_TYPEOFINCOME, FORMAT(TP_PASSWPORTDUEDATE2, 'dd/mm/yyyy'), FORMAT(TP_HW_DOB, 'dd/mm/yyyy') FROM TAXP_PROFILE_HW_OTHERS WHERE TP_REF_NO=? ORDER BY TP_HW_ORDER";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P2_TAX_PROFILE_HW_OTHERS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        //lyeyc (end)
                        break;

                    case "M2011Page3":
                        strQuery = "SELECT ADJ_BUSINESS, ADJSI_NET_STAT_INCOME " +
                        "FROM INCOME_ADJUSTED WHERE ADJ_REF_NO=? AND ADJ_YA=? ORDER BY ADJ_BUSINESS";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_INCOME_ADJUSTED");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //weihong
                        strQuery = "SELECT OS_RT_SEC4A_RENTAL, OS_OTHER_GAINS_TOTAL, OS_PENSION_AND_ETC, OS_SEC4A, OS_RY_GROSS_ROYALTY110, OS_RY_ROYALTY_INCOME, OS_INT_GROSS_RECEIVED, OS_INT_LOAN, OS_RT_GROSS_RENTAL, OS_DV_GROSS_DIVIDEND " +
                        "FROM INCOME_OTHERSOURCE WHERE OS_REF_NO=? AND OS_YA=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_INCOME_OTHERSOURCE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        //weihong

                        strQuery = "SELECT BC_CODE, BC_SOURCEKEY, BC_BUSINESSSOURCE " +
                        "FROM BUSINESS_SOURCE WHERE BC_KEY=? AND BC_YA=? ORDER BY BC_SOURCEKEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_BUSINESS_SOURCE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        dsData.Tables["P3_BUSINESS_SOURCE"].PrimaryKey = new DataColumn[] { dsData.Tables["P3_BUSINESS_SOURCE"].Columns["BC_BUSINESSSOURCE"] };
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT PS_SOURCE, PS_SCH_7A_STAT_INCOME " +
                        "FROM INCOME_PARTNERSHIP WHERE PN_REF_NO=? AND PN_YA=? ORDER BY PS_SOURCE";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_INCOME_PARTNERSHIP");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT PS_FILE_NO2, PS_FILE_NO3, PS_SOURCEKEY, PS_SOURCENO " +
                        "FROM TAXP_PARTNERSHIP WHERE PS_KEY=? AND PS_YA=? ORDER BY PS_SOURCEKEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_TAXP_PARTNERSHIP");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        dsData.Tables["P3_TAXP_PARTNERSHIP"].PrimaryKey = new DataColumn[] { dsData.Tables["P3_TAXP_PARTNERSHIP"].Columns["PS_SOURCENO"] };
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //weihong
                        strQuery = "SELECT TC_BUSINESSLOSS_BF, TC_EMPLOYMENT_INCOME, TC_EXEMPT_CLAIM, TC_EXEMPT_COUNTRY, TC_DIVIDEND, " +
                        "TC_INTEREST, TC_DISCOUNT, TC_RENTAL_ROYALTY, TC_PREMIUM, TC_PENSION_AND_ETC, " +
                        "TC_OTHER_GAIN_PROFIT, TC_SEC4A, TC_ADDITION_43, TC_BUSINESSLOSS_CY, TC_3, " +
                        "TC_INCOME_TRANSFER_FROM_HW, TC_INSTALLMENT_PAYMENT_SELF, TC_INSTALLMENT_PAYMENT_HW, TC_PROSPECTING, TC_EXEMPT_AMOUNT, TC_HK3_TRANSFER_FROM_HW, TC_EXHK3_TRANSFER_FROM_HW " +
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

                        strQuery = "SELECT INTEREST, ROYALTIES, SECTION4A, OTHERINCOME " +
                        "FROM CHARGEABLE_INCOME WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_CHARGEABLE_INCOME");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT TCG_KEY, TCG_AMOUNT " +
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

                        //strQuery = "SELECT TOP 5 PY_INCOME_TYPE, PY_PAYMENT_YEAR, PY_AMOUNT, PY_EPF " +
                        //"FROM PRECEDING_YEAR_DETAIL WHERE PY_KEY IN (SELECT PY_KEY FROM PRECEDING_YEAR WHERE PY_REF_NO=? and PY_YA=?) ORDER BY PY_DKEY";
                        //cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        //daOdbc = new OdbcDataAdapter(cmdOdbc);
                        //dtTemp = new DataTable("P3_PRECEDING_YEAR_DETAIL");
                        //daOdbc.Fill(dtTemp);
                        //dsData.Tables.Add(dtTemp);
                        //daOdbc.Dispose();
                        //cmdOdbc.Dispose();

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

                        //weihong Gross income from employment case "M2010Page3":
                        strQuery = "select EI_SCHEDULE1, EI_GROSS from INCOME_EMPLOYMENT where EI_REF_NO=? and EI_YA=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_INCOME_EMPLOYMENT");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        //weihong

                        //weihong Total gross income from all source 
                        strQuery = "select PL_SALES from PROFIT_LOSS_ACCOUNT where PL_REF_NO=? and PL_YA=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_PROFIT_LOSS_ACCOUNT");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        //weihong

                        break;



                    case "M2011Page4":
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

                    case "M2011Page5":
                        strQuery = "SELECT CHARGEABLE0, CHARGEABLE1, CHARGEABLE2, CHARGEABLE3, CHARGEABLE4, " +
                        "CHARGEABLE5, CHARGEABLE6, RATE1 " +
                        "FROM CHARGEABLE_INCOME WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_CHARGEABLE_INCOME");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT TCR_KEY, TCR_AMOUNT " +
                        "FROM TAX_REBATE WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?) ORDER BY TCR_KEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_TAX_REBATE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        dsData.Tables["P3_TAX_REBATE"].PrimaryKey = new DataColumn[] { dsData.Tables["P3_TAX_REBATE"].Columns["TCR_KEY"] };
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT TC_SEC110_DIVIDEND, TC_SEC110_OTHERS, TC_SEC130, TC_2 " +
                        "FROM TAX_COMPUTATION WHERE TC_REF_NO=? AND TC_YA=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_TAX_COMPUTATION");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                    case "M2011Page6":
                        strQuery = "SELECT TC_AL_CY_UNASORBED_LOSS, TC_AL_BAL_UNASORBED_LOSS, TC_PIONEER, TC_PIONEER_CF " +
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

                        strQuery = "SELECT ADCA_UTIL, ADCA_BAL_CF" +
                        " FROM INCOME_ADJUSTED WHERE ADJ_REF_NO=? AND ADJ_YA=? ORDER BY ADJ_BUSINESS";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P5_INCOME_ADJUSTED");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT PSCA_UTIL, PSCA_BAL_CF" +
                        " FROM INCOME_PARTNERSHIP WHERE PN_REF_NO=? AND PN_YA=? ORDER BY PS_SOURCE";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P5_INCOME_PARTNERSHIP");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT NR_SECTION, NR_GROSS_TOTAL, NR_WITHHOLD, NR_WITHHOLD_107A " +
                        "FROM NON_RESIDENT WHERE NR_REF_NO=? AND NR_YA=? ORDER BY NR_SECTION";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P5_NON_RESIDENT");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        dsData.Tables["P5_NON_RESIDENT"].PrimaryKey = new DataColumn[] { dsData.Tables["P5_NON_RESIDENT"].Columns["NR_SECTION"] };
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum(tca_cbl) from tax_adjusted_loss where tc_key in (select tc_key from tax_computation where tc_ref_no =? and tc_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P5_ADJUSTED_LOSS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                    case "M2011Page7":
                        strQuery = "SELECT ADJD_CLAIM_CODE, ADJD_AMOUNT " +
                        "FROM INCOME_ADJ_FURTHER WHERE ADJ_KEY IN (SELECT ADJ_KEY FROM INCOME_ADJUSTED WHERE ADJ_REF_NO=? and ADJ_YA=?) ORDER BY ADJD_NO";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P6_INCOME_ADJ_FURTHER");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT TIC_KEY, TIC_CF " +
                        "FROM TAX_INCENTIVE_CLAIM WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO=? and TC_YA=?) ORDER BY TIC_KEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P6_TAX_INCENTIVE_CLAIM");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        dsData.Tables["P6_TAX_INCENTIVE_CLAIM"].PrimaryKey = new DataColumn[] { dsData.Tables["P6_TAX_INCENTIVE_CLAIM"].Columns["TIC_KEY"] };
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                    case "M2011Page8":
                        strQuery = "SELECT PL_SALES, PL_OP_STK, PL_PURCHASES_PRO_COST, PL_CLS_STK, PL_OTH_BSIN, " +
                        "PL_1, PL_4, PL_2, PL_3, PL_5, " +
                        "PL_NT_INCOME, PL_EXP_LOANINTEREST, PL_EXP_SALARY, PL_EXP_RENTAL,PL_EXP_CONTRACT, " +
                        "PL_EXP_COMMISSION, PL_BAD_DEBTS, PL_TRAVEL, PL_REP_MAINT, PL_PRO_ADV, " +
                        "PL_TOT_EXP, PL_DISALLOWED_EXP " +
                        "FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO =? AND PL_YA =? AND PL_MAINCOMPANY = '1' ORDER BY PL_KEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_PROFIT_LOSS_ACCOUNT");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT PL_SALES, PL_OP_STK, PL_PURCHASES_PRO_COST, PL_CLS_STK, PL_OTH_BSIN, " +
                        "PL_1, PL_4, PL_2, PL_3, PL_5, " +
                        "PL_NT_INCOME, PL_EXP_LOANINTEREST, PL_EXP_SALARY, PL_EXP_RENTAL,PL_EXP_CONTRACT, " +
                        "PL_EXP_COMMISSION, PL_BAD_DEBTS, PL_TRAVEL, PL_REP_MAINT, PL_PRO_ADV, " +
                        "PL_TOT_EXP, PL_DISALLOWED_EXP " +
                        "FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO =? AND PL_YA =? ORDER BY PL_KEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_PROFIT_LOSS_ACCOUNT");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        // csNgoh BEfiling SU7
                        strQuery = "SELECT SUM([EXA_AMOUNT]) FROM [PL_EXPENSES] WHERE [EXA_KEY] IN " +
                        "(SELECT PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1' ORDER BY PL_KEY) " +
                        "AND (EXA_PLTYPE BETWEEN 18 AND 20 OR EXA_PLTYPE = 46)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_EXPENSES_OTHER");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT SUM([EXA_AMOUNT]) FROM [PL_EXPENSES] WHERE [EXA_KEY] IN " +
                        "(SELECT TOP 1 PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? ORDER BY PL_KEY) " +
                        "AND (EXA_PLTYPE BETWEEN 18 AND 20 OR EXA_PLTYPE = 46)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_EXPENSES_OTHER");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT SUM([EXA_AMOUNT]) FROM [PL_EXP_NONALLOWLOSS] WHERE [EXA_KEY] IN " +
                        "(SELECT PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1' ORDER BY PL_KEY)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_LOSS_NONALLOW");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT SUM([EXA_AMOUNT]) FROM [PL_EXP_NONALLOWLOSS] WHERE [EXA_KEY] IN " +
                        "(SELECT TOP 1 PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? ORDER BY PL_KEY)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_LOSS_NONALLOW");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT SUM([EXA_AMOUNT]) FROM [PL_EXP_NONALLOWEXPEND] WHERE [EXA_KEY] IN " +
                        "(SELECT PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1' ORDER BY PL_KEY)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_EXPENSES_NONALLOW");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT SUM([EXA_AMOUNT]) FROM [PL_EXP_NONALLOWEXPEND] WHERE [EXA_KEY] IN " +
                        "(SELECT TOP 1 PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? ORDER BY PL_KEY)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_EXPENSES_NONALLOW");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT SUM([EXA_AMOUNT]) FROM [PL_EXP_PERSONAL] WHERE [EXA_KEY] IN " +
                        "(SELECT PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1' ORDER BY PL_KEY)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_EXPENSES_PERSONAL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT SUM([EXA_AMOUNT]) FROM [PL_EXP_PERSONAL] WHERE [EXA_KEY] IN " +
                        "(SELECT TOP 1 PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? ORDER BY PL_KEY)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_EXPENSES_PERSONAL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT BC_BUS_ENTITY, BC_CODE, BC_COMPANY " +
                        "FROM BUSINESS_SOURCE WHERE BC_KEY =? AND BC_YA =? AND BC_BUSINESSSOURCE IN " +
                        "(SELECT PL_MAIN_BUSINESS FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1' ORDER BY PL_KEY) ";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_BUSINESS_SOURCE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT BC_BUS_ENTITY, BC_CODE, BC_COMPANY " +
                        "FROM BUSINESS_SOURCE WHERE BC_KEY =? AND BC_YA =? AND BC_BUSINESSSOURCE IN " +
                        "(SELECT TOP 1 PL_MAIN_BUSINESS FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? ORDER BY PL_KEY) ";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_BUSINESS_SOURCE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();


                        // csNgoh BEFiling2008
                        strQuery = "select pl_key from profit_loss_account where pl_ref_no = ? and pl_ya = ? and pl_key not in " +
                        "(SELECT PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? " +
                        "AND PL_MAINCOMPANY = '1' ORDER BY PL_KEY)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_PNL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();


                        strQuery = "select pl_key from profit_loss_account where pl_ref_no = ? and pl_ya = ? and pl_key not in " +
                        "(SELECT TOP 1 PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? " +
                        "AND PL_YA=? ORDER BY PL_KEY)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_OTHER_PNL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();


                        strQuery = "select sum(cdbl(exa_amount)) from pl_income_otherbusiness where exa_key = " +
                        "(SELECT PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? " +
                        "AND PL_MAINCOMPANY = '1' ORDER BY PL_KEY)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_INCOME_OTHERBUSINESS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();


                        strQuery = "select sum(cdbl(exa_amount)) from pl_income_otherbusiness where exa_key = " +
                        "(SELECT TOP 1 PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? " +
                        "AND PL_YA=? ORDER BY PL_KEY)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_INCOME_OTHERBUSINESS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        // end csNgoh BEFiling2008


                        strQuery = "SELECT (SUM(PL_SALES) - (SUM(PL_OP_STK) + SUM(PL_PURCHASES_PRO_COST) - SUM(PL_CLS_STK))) " +
                        "FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO =? AND PL_YA =? AND PL_KEY NOT IN " +
                        "(SELECT PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1' ORDER BY PL_KEY)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_PROFIT_LOSS_ACCOUNT_GROSS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT (SUM(PL_SALES) - (SUM(PL_OP_STK) + SUM(PL_PURCHASES_PRO_COST) - SUM(PL_CLS_STK))) " +
                        "FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO =? AND PL_YA =? AND PL_KEY NOT IN " +
                        "(SELECT TOP 1 PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? ORDER BY PL_KEY)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_PROFIT_LOSS_ACCOUNT_GROSS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT BS_LAND, BS_MACHINERY, BS_TRANSPORT, BS_OTH_FA, BS_INVESTMENT, " +
                        "BS_STOCK, BS_TRADE_DEBTORS, BS_OTH_DEBTORS, BS_CASH, BS_BANK, " +
                        "BS_OTH_CA, BS_LOAN, BS_TRADE_CR, BS_OTHER_CR, BS_CAPITALACCOUNT, " +
                        "BS_BROUGHT_FORWARD, BS_CY_PROFITLOSS, BS_CAP_CONTRIBUTION, BS_DRAWING, BS_CARRIED_FORWARD, " +
                        "BS_OTH_LIAB, BS_LT_LIAB " +
                        "FROM BALANCE_SHEET WHERE BS_REF_NO =? AND BS_YA =? AND BS_SOURCENO IN " +
                        "(SELECT PL_MAIN_BUSINESS FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1' ORDER BY PL_KEY) ORDER BY BS_SOURCENO";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_BALANCE_SHEET");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT BS_LAND, BS_MACHINERY, BS_TRANSPORT, BS_OTH_FA, BS_INVESTMENT, " +
                        "BS_STOCK, BS_TRADE_DEBTORS, BS_OTH_DEBTORS, BS_CASH, BS_BANK, " +
                        "BS_OTH_CA, BS_LOAN, BS_TRADE_CR, BS_OTHER_CR, BS_CAPITALACCOUNT, " +
                        "BS_BROUGHT_FORWARD, BS_CY_PROFITLOSS, BS_CAP_CONTRIBUTION, BS_DRAWING, BS_CARRIED_FORWARD, " +
                        "BS_OTH_LIAB, BS_LT_LIAB " +
                        "FROM BALANCE_SHEET WHERE BS_REF_NO =? AND BS_YA =? AND BS_SOURCENO IN " +
                        "(SELECT PL_MAIN_BUSINESS FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? ORDER BY PL_KEY) ORDER BY BS_SOURCENO";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_BALANCE_SHEET");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT SUM(EXA_AMOUNT) " +
                        "FROM PL_EXPENSES WHERE EXA_KEY IN " +
                        "(SELECT PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1' ORDER BY PL_KEY) AND [EXA_DEDUCTIBLE]='No'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_PL_EXPENSES");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT SUM(EXA_AMOUNT) " +
                        "FROM PL_EXPENSES WHERE EXA_KEY IN " +
                        "(SELECT TOP 1 PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? ORDER BY PL_KEY) AND [EXA_DEDUCTIBLE]='No'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_PL_EXPENSES");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT SUM(EXA_AMOUNT) " +
                        "FROM PL_EXP_NONALLOWEXPEND WHERE EXA_KEY IN " +
                        "(SELECT PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1' ORDER BY PL_KEY) AND [EXA_DEDUCTIBLE]='No'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_PL_EXP_NONALLOWEXPEND");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT SUM(EXA_AMOUNT) " +
                        "FROM PL_EXP_NONALLOWEXPEND WHERE EXA_KEY IN " +
                        "(SELECT TOP 1 PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? ORDER BY PL_KEY) AND [EXA_DEDUCTIBLE]='No'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_PL_EXP_NONALLOWEXPEND");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT SUM(EXA_AMOUNT) " +
                        "FROM PL_EXP_PERSONAL WHERE EXA_KEY IN " +
                        "(SELECT PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1' ORDER BY PL_KEY) AND [EXA_DEDUCTIBLE]='No'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_PL_EXP_PERSONAL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT SUM(EXA_AMOUNT) " +
                        "FROM PL_EXP_PERSONAL WHERE EXA_KEY IN " +
                        "(SELECT TOP 1 PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? ORDER BY PL_KEY) AND [EXA_DEDUCTIBLE]='No'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_PL_EXP_PERSONAL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT SUM(EXA_AMOUNT) " +
                        "FROM PL_PRODUCTION_COST WHERE EXA_KEY IN " +
                        "(SELECT PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? AND PL_MAINCOMPANY = '1' ORDER BY PL_KEY) AND [EXA_DEDUCTIBLE]='No' and (EXA_PLTYPE = 43 or EXA_PLTYPE = 45)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_MAIN_PL_PRODUCTION_COST");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT SUM(EXA_AMOUNT) " +
                        "FROM PL_PRODUCTION_COST WHERE EXA_KEY IN " +
                        "(SELECT TOP 1 PL_KEY FROM PROFIT_LOSS_ACCOUNT WHERE PL_REF_NO=? AND PL_YA=? ORDER BY PL_KEY) AND [EXA_DEDUCTIBLE]='No' and (EXA_PLTYPE = 43 or EXA_PLTYPE = 45)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_PL_PRODUCTION_COST");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                    case "M2011Page9":
                        strQuery = "select TA_TEL_NO " +
                        "FROM TAXA_PROFILE WHERE TA_CO_NAME=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxagent", strTaxAgent));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_TAXA_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "SELECT TP_ADM_NAME, TP_ADM_IC_NEW1, TP_ADM_IC_NEW2, TP_ADM_IC_NEW3, TP_ADM_POLICE_NO, TP_ADM_ARMY_NO, TP_ADM_PASSPORT_NO " +
                        "FROM TAXP_PROFILE WHERE TP_5=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_TAXADM_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                    case "M2011Page11":
                        strQuery = "select format(div_date,'dd MMM yyyy') as [Date of Payment], Iif(div_year_end is null,format(div_date,'dd MMM yyyy'),format(div_year_end,'dd MMM yyyy')) as [Year End], div_serialno as [Waran No], div_company as [Company Name], div_gross as [Gross Dividend], DIV_RATE as [Tax Rate], "
                        + "div_tax as [Tax Deducted], div_net as [Net Dividend], os_dv_interest as [Dividend Interest]"
                        + "from income_othersource inner join income_os_dividend on income_othersource.os_key = income_os_dividend.os_key "
                        + "where income_othersource.os_ref_no =? and income_othersource.os_ya =?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P11_HK3_MASTER");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                    case "M2011Page12":

                        strQuery = "select format(div_date,'dd MMM yyyy') as [Date of Payment], Iif(div_year_end is null,format(div_date,'dd MMM yyyy'),format(div_year_end,'dd MMM yyyy')) as [Year End], div_serialno as [Waran No], div_company as [Company Name], div_gross as [Gross Dividend], DIV_RATE as [Tax Rate], "
                        + "div_tax as [Tax Deducted], div_net as [Net Dividend], os_dv_interest as [Dividend Interest] "
                        + "from income_othersource inner join income_os_dividend on income_othersource.os_key = income_os_dividend.os_key "
                        + "where income_othersource.os_ref_no = ? and income_othersource.os_ya =?";

                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P12_HK3_MASTER");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select format(div_date,'dd MMM yyyy') as [Date of Payment], Iif(div_year_end is null,format(div_date,'dd MMM yyyy'),format(div_year_end,'dd MMM yyyy')) as [Year End], div_serialno as [Waran No], div_company as [Company Name], div_gross as [Gross Dividend], DIV_RATE as [Tax Rate], "
                        + "div_tax as [Tax Deducted], div_net as [Net Dividend], os_dv_interest as [Dividend Interest] "
                        + "from income_othersource inner join income_os_dividend on income_othersource.os_key = income_os_dividend.os_key "
                        + "where income_othersource.os_ref_no in (select tp_hw_ref_no1 from taxp_profile_hw_others where tp_ref_no = ? and income_othersource.os_ya =?) "
                        + "UNION select format(div_date,'dd MMM yyyy') as [Date of Payment], Iif(div_year_end is null,format(div_date,'dd MMM yyyy'),format(div_year_end,'dd MMM yyyy')) as [Year End], div_serialno as [Waran No], div_company as [Company Name], div_gross as [Gross Dividend], DIV_RATE as [Tax Rate], "
                        + "div_tax as [Tax Deducted], div_net as [Net Dividend], os_dv_interest as [Dividend Interest] "
                        + "from income_othersource inner join income_os_dividend on income_othersource.os_key = income_os_dividend.os_key "
                        + "where income_othersource.os_ref_no = (select tp_hw_ref_no1 from taxp_profile where (tp_ref_no1+tp_ref_no2+tp_ref_no3) = ?) and income_othersource.os_ya =?";

                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer2", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya2", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P12_HK3HW_MASTER");
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
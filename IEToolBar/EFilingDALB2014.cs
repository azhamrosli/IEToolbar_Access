using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;

namespace IEToolBar
{
    public class EFilingDALB2014 : EFilingDALB
    {

        public EFilingDALB2014()
        {
        }


        public EFilingDALB2014(string strTaxPayer, string strYA, string strTaxAgent)
        {
            //LEESH FEB 2012
            this.strTaxPayer = strTaxPayer;
            this.strYA = strYA;
            this.strTaxAgent = strTaxAgent;
            //LEESH END
        }

        public DataSet GetFormDataB2014(string strPage)
        {
            //LEESH FEB 2012
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

                    case "B2014Page1": case "B2014Page2": case "B2014Page3":
                        strQuery = "select tp_passport_no, tp_country, tp_gender, tp_status, iif(tp_date_marriage is null,'',format(tp_date_marriage,'dd/mm/yyyy')),"
                                + " iif(tp_date_divorce is null,'',format(tp_date_divorce,'dd/mm/yyyy')), tp_type_assessment, tp_kup,"
                                + " tp_curr_add_line1, tp_curr_add_line2, tp_curr_add_line3,"
                                + " tp_curr_postcode, tp_curr_city, tp_curr_state,"
                                + " tp_com_add_line1, tp_com_add_line2, tp_com_add_line3,"
                                + " tp_com_postcode, tp_com_city, tp_com_state,"
                                + " tp_tel1, tp_tel2, tp_mobile1, tp_mobile2,"
                                + " (tp_employer_no2 + tp_employer_no3),"
                                + " tp_email, tp_bank, tp_bank_acc, tp_assessmenton"
                                + " from taxp_profile where (tp_ref_no1 + tp_ref_no2 + tp_ref_no3)=?";

                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_INPUT_TAX_PROFILE");
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

                        strQuery = "SELECT TP_BWA FROM TAXP_PROFILE2 WHERE TP_REF_NO=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_INPUT_TAX_PROFILE_OTHERS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum(tca_cbl) from tax_adjusted_loss where tc_key in (select tc_key from tax_computation where tc_ref_no =? and tc_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_INPUT_ADJUSTED_LOSS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //weihong 
                        strQuery = "select FORMAT(TP_WORKER_APPROVEDATE,'dd/mm/yyyy'), TP_COM_ADD_STATUS,FORMAT(TP_DOB,'dd/MMM/yyyy'),FORMAT(TP_HW_DOB,'dd/MMM/yyyy') from TAXP_PROFILE2 where TP_REF_NO=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_TAX_PROFILE2");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select tp_hw_name, tp_hw_ref_no_prefix, tp_hw_ref_no1 , tp_hw_ref_no2 , tp_hw_ref_no3, tp_hw_ic_new1, tp_hw_ic_new2, tp_hw_ic_new3, tp_hw_ic_old,tp_hw_police_no, tp_hw_army_no, tp_hw_passport_no from taxp_profile where (tp_ref_no1 + tp_ref_no2 + tp_ref_no3)=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P2_INPUT_TAX_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //strQuery = "select tp_hw_name, tp_hw_ref_no_prefix, tp_hw_ref_no1 , tp_hw_ref_no2 , tp_hw_ref_no3, tp_hw_ic_new1, tp_hw_ic_new2, tp_hw_ic_new3, tp_hw_ic_old,tp_hw_police_no, tp_hw_army_no, tp_hw_passport_no from taxp_profile where (tp_ref_no1 + tp_ref_no2 + tp_ref_no3)=?";
                        //cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        ////cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        //daOdbc = new OdbcDataAdapter(cmdOdbc);
                        //dtTemp = new DataTable("P2_INPUT_TAX_PROFILE");
                        //daOdbc.Fill(dtTemp);
                        //dsData.Tables.Add(dtTemp);
                        //daOdbc.Dispose();
                        //cmdOdbc.Dispose();

                        strQuery = "SELECT TP_HW_NAME, TP_HW_REF_NO_PREFIX, TP_HW_REF_NO1, TP_HW_REF_NO2, TP_HW_REF_NO3, TP_HW_IC_NEW1, TP_HW_IC_NEW2, TP_HW_IC_NEW3, TP_HW_POLICE_NO, TP_HW_ARMY_NO, TP_HW_PASSPORT_NO, TP_HW_TYPEOFINCOME FROM TAXP_PROFILE_HW_OTHERS WHERE TP_REF_NO=? ORDER BY TP_HW_ORDER";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P2_TAX_PROFILE_HW_OTHERS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select b.bc_code from business_source b where b.bc_key = ? and b.bc_ya = ? and b.bc_businesssource in (select  a.adj_business from income_adjusted a where a.adj_ref_no=? and a.adj_ya=? order by adj_business)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_BUSINESS_CODE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select os_rt_sec4A_rental from income_othersource where os_ref_no = ? and os_ya = ?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_SECTION_4A");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select a.adjsi_net_stat_income from income_adjusted a where a.adj_ref_no=? and a.adj_ya=? order by adj_business";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_INCOME_ADJUSTED");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select (ps_file_no2 + ps_file_no3) from taxp_partnership where ps_key= ? and ps_ya=? and ps_sourceno in (select ps_source from income_partnership where pn_ref_no= ? and pn_ya= ? order by ps_source)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_PARTNERSHIP_CODE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select ps_sch_7a_stat_income from income_partnership where pn_ref_no= ? and pn_ya= ? order by ps_source";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_PARTNERSHIP_INCOME");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //LEESH 24 FEB 2012
                        strQuery = "select tc_statutory_income, tc_businessloss_bf, tc_aggregate_bus_income, tc_employment_income, tc_dividend, (cdbl(tc_interest) + cdbl(tc_discount)), (cdbl(tc_rental_royalty)+cdbl(tc_premium)), tc_pension_and_etc,(cdbl(tc_other_gain_profit) + cdbl(tc_sec4a)), tc_addition_43, tc_aggregate_other_src, tc_businessloss_cy, (cdbl(tc_prospecting) + cdbl(tc_qualifying_ag_exp)), tc_qualifying_ag_exp, tc_key, tc_prospecting,tc_qualifying_ag_exp, tc_4, tc_3, tc_total_income_2, tc_income_transfer_from_hw, tc_total_income_3, (cdbl(tc_installment_payment_self) + cdbl(tc_installment_payment_hw)),tc_exhk3_transfer_from_hw from tax_computation where tc_ref_no =? and tc_ya =?";
                        //LEESH END
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_TAX_COMPUTATION");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //LEESH 2014
                        strQuery = "select os_rt_rental_bf from income_othersource where os_ref_no =? and os_ya =?";
                        //LEESH END
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_RENTAL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //simkh 2014
                        strQuery = "SELECT ((cdbl(TAX_COMPUTATION.TC_INTEREST)+cdbl(TAX_COMPUTATION.TC_DISCOUNT)+" +
                        "cdbl(TAX_COMPUTATION.TC_RENTAL_ROYALTY)+cdbl(TAX_COMPUTATION.TC_PREMIUM)+" +
                        "cdbl(TAX_COMPUTATION.TC_PENSION_AND_ETC)+cdbl(TAX_COMPUTATION.TC_OTHER_GAIN_PROFIT)+" +
                        "cdbl(TAX_COMPUTATION.TC_SEC4A))- CDBL(INCOME_OTHERSOURCE.OS_RT_RENTAL_BF )) " +
                        "FROM TAX_COMPUTATION INNER JOIN INCOME_OTHERSOURCE " +
                        "ON TAX_COMPUTATION.TC_REF_NO=INCOME_OTHERSOURCE.OS_REF_NO " +
                        "AND TAX_COMPUTATION.TC_YA = INCOME_OTHERSOURCE.OS_YA " +
                        "WHERE TAX_COMPUTATION.TC_REF_NO=? AND TAX_COMPUTATION.TC_YA=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_INCOME_EXCLUDE_RENTAL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        //simkh end

                        strQuery = "select tp_hw_typeofincome from taxp_profile where (tp_ref_no1 + tp_ref_no2 + tp_ref_no3) = ?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_SELECT_TAX_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //NGOHCS B2010.2 
                        strQuery = "select tp_hw_typeofincome from taxp_profile_hw_others where tp_ref_no=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_SELECT_TAX_PROFILE_OTHER");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        //NGOHCS B2010.2 END

                        strQuery = "select tcg_key, tcg_amount from tax_gifts where tc_key = (select tc_key from tax_computation where tc_ref_no = ? and tc_ya = ?) order by tcg_key";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_TAX_GIFTS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //weihong Gross income from employment 
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

                        strQuery = "select OS_OTHER_GAINS_TOTAL, OS_PENSION_AND_ETC, OS_SEC4A, OS_RY_GROSS_ROYALTY110, OS_RY_ROYALTY_INCOME, OS_INT_GROSS_RECEIVED, OS_INT_LOAN, OS_RT_GROSS_RENTAL, OS_DV_GROSS_DIVIDEND from INCOME_OTHERSOURCE where OS_REF_NO=? and OS_YA=?";
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

                        //simkh 2014
                        strQuery = "select py_income_type, py_payment_year, py_amount, py_epf from preceding_year_detail where py_key in (select py_key from preceding_year where py_ref_no= ? and py_ya= ?)order by py_dkey";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_PRECEDING_YEAR");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        //simkh end

                    //strQuery = "select py_income_type, py_payment_year, py_amount, py_epf from preceding_year_detail where py_key in (select py_key from preceding_year where py_ref_no= ? and py_ya= ?)order by py_dkey";
                    //cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    //cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                    //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                    //daOdbc = new OdbcDataAdapter(cmdOdbc);
                    //dtTemp = new DataTable("P3_PRECEDING_YEAR");
                    //daOdbc.Fill(dtTemp);
                    //dsData.Tables.Add(dtTemp);
                    //daOdbc.Dispose();
                    //cmdOdbc.Dispose();
                    //break;

                        strQuery = "select tcc_key, tcc_amount from tax_relief where tc_key in (select tc_key from tax_computation where tc_ref_no = ? and tc_ya = ?) order by tcc_key";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_TAX_RELIEF");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select tcc_key, tcc_100, tcc_50 from tax_relief_child where tc_key in (select tc_key from tax_computation where tc_ref_no = ? and tc_ya = ?) order by tcc_key";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_RELIEF_CHILD");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select tcc_key, tcc_100, tcc_50 from tax_relief_child where tc_key in (select tc_key from tax_computation where tc_ref_no in (select (Iif(tp_hw_ref_no1 is Null,'',tp_hw_ref_no1)+Iif(tp_hw_ref_no2 is Null,'',tp_hw_ref_no2)+Iif(tp_hw_ref_no3 is Null,'',tp_hw_ref_no3)) from taxp_profile where (tp_ref_no1 + tp_ref_no2 + tp_ref_no3)= ?) and tc_ya =?) order by tcc_key";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_RELIEF_HWCHILD");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select TCC_KEY, TCC_100, TCC_50 FROM TAX_RELIEF_CHILD WHERE TC_KEY IN (SELECT TC_KEY FROM TAX_COMPUTATION WHERE TC_REF_NO IN (SELECT TP_HW_REF_NO1 FROM TAXP_PROFILE_HW_OTHERS WHERE TP_REF_NO=?) AND TC_YA=?) ORDER BY TCC_KEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_RELIEF_HWCHILD_OTHERS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //simkh 2014
                        strQuery = "select tc_sec110_others, (cdbl(tc_1) + cdbl(tc_2)), tc_sec110_dividend from tax_computation where tc_ref_no= ? and tc_ya= ?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P5_TAX_COMPUTATION");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();


                        strQuery = "select tcr_key, tcr_amount from tax_rebate where tc_key=(select tc_key from tax_computation where tc_ref_no = ? and tc_ya = ?) order by tcr_key";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P5_TAX_REBATE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                    //simkh end

                    //strQuery = "select tcr_key, tcr_amount from tax_rebate where tc_key=(select tc_key from tax_computation where tc_ref_no = ? and tc_ya = ?) order by tcr_key";
                    //cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    //cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                    //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                    //daOdbc = new OdbcDataAdapter(cmdOdbc);
                    //dtTemp = new DataTable("P5_TAX_REBATE");
                    //daOdbc.Fill(dtTemp);
                    //dsData.Tables.Add(dtTemp);
                    //daOdbc.Dispose();
                    //cmdOdbc.Dispose();
                    //break;

                        strQuery = "select tc_al_cy_unasorbed_loss, tc_al_bal_unasorbed_loss, tc_pioneer, tc_pioneer_cf from tax_computation where tc_ref_no= ? and tc_ya= ?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P6_TAX_COMPUTATION");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select adca_util ,adca_bal_cf from income_adjusted where adj_ref_no= ? and adj_ya = ? order by adj_business";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P6_INCOME_ADJUSTED");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select psca_util ,psca_bal_cf from income_partnership where pn_ref_no= ? and pn_ya = ? order by ps_source";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P6_PARTNER_INCOME");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select nr_section, nr_gross_total, nr_withhold, nr_withhold_107A from non_resident where nr_ref_no= ? and nr_ya = ? order by nr_section";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P6_WITHOLDING_TAX");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum(tca_cbl) from tax_adjusted_loss where tc_key in (select tc_key from tax_computation where tc_ref_no =? and tc_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P6_INPUT_ADJUSTED_LOSS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select adjd_claim_code, adjd_amount from income_adj_further where adj_key in (select adj_key from income_adjusted where adj_ref_no= ? and adj_ya = ?) order by adjd_id, adjd_claim_code";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_ADJUSTED_FURTHER");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select tic_key, tic_claim, tic_cf from tax_incentive_claim where tc_key in (select tc_key from tax_computation where tc_ref_no= ? and tc_ya = ?) order by tic_key";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_INCENTIVE_CLAIM");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        
                        strQuery = "select pl_key, pl_main_business from profit_loss_account where pl_ref_no = ? and pl_ya = ? and pl_maincompany = '1' order by pl_key";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        OdbcDataReader drMainBus = cmdOdbc.ExecuteReader();
                        string strPNLKey = "";
                        string strPLMAINBUS = "";
                        if (drMainBus.HasRows)
                        {
                            if (drMainBus.Read())
                            {
                                strPNLKey = drMainBus.GetString(0);
                                strPLMAINBUS = drMainBus.GetString(1);
                            }
                        }
                        drMainBus.Dispose();
                        cmdOdbc.Dispose();

                        if (strPNLKey == "")
                        {
                            strQuery = "select pl_key, pl_main_business from profit_loss_account where pl_ref_no = ? and pl_ya = ? order by pl_key";
                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                            OdbcDataReader drOthBus = cmdOdbc.ExecuteReader();
                            if (drOthBus.HasRows)
                            {
                                if (drOthBus.Read())
                                {
                                    strPNLKey = drOthBus.GetString(0);
                                    strPLMAINBUS = drOthBus.GetString(1);
                                }
                            }
                            drOthBus.Dispose();
                            cmdOdbc.Dispose();

                            strQuery = "select pl_key, pl_sales, pl_op_stk, pl_purchases_pro_cost, pl_cls_stk from profit_loss_account where pl_ref_no = ? and pl_ya = ? order by pl_key";
                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                            daOdbc = new OdbcDataAdapter(cmdOdbc);
                            dtTemp = new DataTable("P8_PNL_INCOME");
                            daOdbc.Fill(dtTemp);
                            dsData.Tables.Add(dtTemp);
                            daOdbc.Dispose();
                            cmdOdbc.Dispose();

                            strQuery = "select bc_bus_entity, bc_code, bc_company from business_source where bc_key = ? and bc_ya = ?  and bc_businesssource = ?";
                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@source", strPLMAINBUS));
                            //cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                            daOdbc = new OdbcDataAdapter(cmdOdbc);
                            dtTemp = new DataTable("P8_PNL_BCCODE");
                            daOdbc.Fill(dtTemp);
                            dsData.Tables.Add(dtTemp);
                            daOdbc.Dispose();
                            cmdOdbc.Dispose();

                        }
                        else
                        {
                            strQuery = "select pl_key, pl_sales, pl_op_stk, pl_purchases_pro_cost, pl_cls_stk from profit_loss_account where pl_ref_no = ? and pl_ya = ? and pl_maincompany = '1' order by pl_key";
                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                            daOdbc = new OdbcDataAdapter(cmdOdbc);
                            dtTemp = new DataTable("P8_PNL_INCOME");
                            daOdbc.Fill(dtTemp);
                            dsData.Tables.Add(dtTemp);
                            daOdbc.Dispose();
                            cmdOdbc.Dispose();

                            strQuery = "select bc_bus_entity, bc_code, bc_company from business_source where bc_key = ? and bc_ya = ?  and bc_businesssource = (select pl_main_business from profit_loss_account where pl_ref_no = ? and pl_ya = ? and pl_maincompany = '1' order by pl_key)";
                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                            daOdbc = new OdbcDataAdapter(cmdOdbc);
                            dtTemp = new DataTable("P8_PNL_BCCODE");
                            daOdbc.Fill(dtTemp);
                            dsData.Tables.Add(dtTemp);
                            daOdbc.Dispose();
                            cmdOdbc.Dispose();
                        }

                        if (strPNLKey == "")
                        {
                            strPNLKey = "0";
                        }

                        strQuery = "select sum(exa_amount) from pl_income_nonbusiness where exa_key = ? and exa_pltype = 47";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_PL_DIVIDEND");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum(exa_amount) from pl_income_nonbusiness where exa_key = ? and exa_pltype = 50";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_PL_INTEREST");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum(exa_amount) from pl_income_nonbusiness where exa_key = ? and exa_pltype between 48 and 49";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_PL_RENT_ROYALTY");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum(exa_amount) from pl_income_nonbusiness where exa_key = ? and exa_pltype = 51";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_INCOME_OTHER");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum(cdbl(exa_amount)) from pl_income_otherbusiness where exa_key = ?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_INCOME_OTHERBUSINESS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select pl_key from profit_loss_account where pl_ref_no = ? and pl_ya = ? and pl_key <> ?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_OTHER_PNL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum(exa_amount) from pl_income_nontaxable where exa_key = ?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_INCOME_OTHER2");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum(exa_amount) from pl_expenses where exa_key = ? and exa_pltype = 11";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_EXPENSES_LOAN");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum([exa_amount]) from [pl_expenses] where [exa_key] = ? and exa_pltype = 12";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_EXPENSES_SALARY");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum([exa_amount]) from [pl_expenses] where [exa_key] = ? and exa_pltype = 13";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_EXPENSES_RENTAL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum([exa_amount]) from [pl_expenses] where [exa_key] = ? and exa_pltype = 14";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_EXPENSES_CONTRACT");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum([exa_amount]) from [pl_expenses] where [exa_key] = ? and exa_pltype = 15";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_EXPENSES_COMMISSION");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum([exa_amount]) from [pl_expenses] where [exa_key] = ? and exa_pltype = 16";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_EXPENSES_DEBTS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum([exa_amount]) from [pl_expenses] where [exa_key] = ? and exa_pltype = 17";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_EXPENSES_TRAVEL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum([exa_amount]) from [pl_expenses] where [exa_key] = ? and exa_pltype = 52";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_EXPENSES_REPAIR");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum([exa_amount]) from [pl_expenses] where [exa_key] = ? and exa_pltype = 53";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_EXPENSES_PROMOTION");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum([exa_amount]) from [pl_expenses] where [exa_key] = ? and (exa_pltype between 18 and 20 or exa_pltype = 46)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_EXPENSES_OTHER");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum([exa_amount]) from [pl_exp_nonallowloss] where [exa_key] = ?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_LOSS_NONALLOW");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum([exa_amount]) from [pl_exp_nonallowexpend] where [exa_key] = ?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_EXPENSES_NONALLOW");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum([exa_amount]) from [pl_exp_personal] where [exa_key] = ?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_EXPENSES_PERSONAL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum([exa_amount]) from [pl_expenses] where [exa_key] = ? and [exa_deductible]='no'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_NAEXP_EXPENSES");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum([exa_amount]) from [pl_exp_nonallowexpend] where [exa_key] = ? and [exa_deductible]='no'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_NAEXP_NONALLOW");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum([exa_amount]) from [pl_exp_personal] where [exa_key] = ? and [exa_deductible]='no'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_NAEXP_PERSONAL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum([exa_amount]) from [pl_production_cost] where [exa_key] = ? and [exa_deductible]='no' and (exa_pltype = 43 or exa_pltype = 45)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PNLKey", strPNLKey));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_NAEXP_PRODUCTION");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select bs_land, bs_machinery, bs_transport, bs_oth_fa, bs_investment, bs_stock, bs_trade_debtors, bs_oth_debtors, bs_cash,bs_bank, bs_oth_ca, bs_loan, bs_trade_cr, bs_other_cr, bs_oth_liab, bs_lt_liab, bs_capitalaccount, bs_brought_forward, bs_cy_profitloss, (cdbl(bs_cap_contribution) - cdbl(bs_drawing)), bs_carried_forward from balance_sheet where bs_ref_no = ? and bs_ya = ? and bs_sourceno = ? order by bs_sourceno";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@mainbusiness", strPLMAINBUS));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_BALANCE_SHEET");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select tp_adm_name, tp_adm_ic_new1, tp_adm_ic_new2, tp_adm_ic_new3, tp_adm_police_no, tp_adm_army_no, tp_adm_passport_no from taxp_profile where (tp_ref_no1 + tp_ref_no2 + tp_ref_no3)=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P9_TAXADM_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select iif(ta_tel_no is null,'', ta_tel_no) , iif(ta_mobile is null,'', ta_mobile) from taxa_profile where ta_co_name=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ta_co_name", strTaxAgent));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P9_TAX_AGENT");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //Business Loss CF
                        strQuery = "select sum(tca_balance_cf) as loss_cf from tax_adjusted_loss where tc_key=(select tc_key from tax_computation where tc_ref_no=? and tc_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("BS_LOSS_CF");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                        ////Pioneer Loss CF
                        //strQuery = "select tc_pioneer_cf from tax_computation where tc_ref_no=? and tc_ya=?)";
                        //cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        //daOdbc = new OdbcDataAdapter(cmdOdbc);
                        //dtTemp = new DataTable("PIONEER_LOSS_CF");
                        //daOdbc.Fill(dtTemp);
                        //dsData.Tables.Add(dtTemp);
                        //daOdbc.Dispose();
                        //cmdOdbc.Dispose();
                        //break;

                        ////Business Capital Allowance CF
                        //strQuery = "select adca_bal_cf from income_adjusted where adj_ref_no=? and adj_ya=?";
                        //cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        //daOdbc = new OdbcDataAdapter(cmdOdbc);
                        //dtTemp = new DataTable("CA_CF");
                        //daOdbc.Fill(dtTemp);
                        //dsData.Tables.Add(dtTemp);
                        //daOdbc.Dispose();
                        //cmdOdbc.Dispose();
                        //break;

                        ////Partnership Capital Allowance CF
                        //strQuery = "select psca_bal_cf from income_partnership where pn_ref_no=? and pn_ya=?";
                        //cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        //daOdbc = new OdbcDataAdapter(cmdOdbc);
                        //dtTemp = new DataTable("PNCA_CF");
                        //daOdbc.Fill(dtTemp);
                        //dsData.Tables.Add(dtTemp);
                        //daOdbc.Dispose();
                        //cmdOdbc.Dispose();
                        //break;

                    case "B2014Page4":

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
            //LEESH END
        }
    }
}


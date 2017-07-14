using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;

namespace IEToolBar
{
    public class EFilingDALC2011 : EFilingDAL
    {
        public EFilingDALC2011()
        {
        }

        public EFilingDALC2011(string strTaxPayer, string strYA, string strAuditor, string strTaxAgent)
        {
            this.strTaxPayer = strTaxPayer;
            this.strYA = strYA;
            this.strAuditor = strAuditor;
            this.strTaxAgent = strTaxAgent;
        }

        public DataSet GetFormDataC2011(string strPage)
        {
            string strQuery = "";
            OdbcCommand cmdOdbc = new OdbcCommand();
            OdbcDataAdapter daOdbc;
            DataTable dtTemp = new DataTable();
            DataSet dsData = new DataSet();
            try
            {
                if (connOdbc.State == ConnectionState.Closed)
                {
                    connOdbc.Open();
                }
                switch (strPage)
                {
                    case "C2011Page1":
                        strQuery = "select t.tp_com_name,t.tp_ref_no, t.tp_employer_no,t.tp_roc_no,format(t.tp_acc_period_fr,'dd/mm/yyyy'),format(t.tp_acc_period_to,'dd/mm/yyyy'),t.tp_reg_add_line1,t.tp_reg_add_line2,t.tp_reg_add_line3,t.tp_reg_postcode,t.tp_reg_city,t.tp_tel_no,t.tp_curr_add_line1,t.tp_curr_add_line2,t.tp_curr_add_line3,t.tp_curr_postcode,t.tp_curr_city,t.tp_com_add_line1,t.tp_com_add_line2,t.tp_com_add_line3,t.tp_com_postcode,t.tp_com_city,t.tp_bank_acc,t.tp_alt_add_line1,t.tp_alt_add_line2,t.tp_alt_add_line3,t.tp_alt_postcode,t.tp_alt_city,t.tp_blog " + 
                                   "from taxp_profile t " + 
                                   "where tp_ref_no=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_INPUT_TAX_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select t.tp_residence, t.tp_country, t.tp_public_order, t.tp_co_status, t.tp_reg_state, t.tp_curr_state, t.tp_com_state, b.bk_code, t.tp_record_kept, t.tp_alt_state from taxp_profile t, bank b where tp_ref_no=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_SELECT_TAX_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();



                        strQuery = "select b.bk_code from taxp_profile t, bank b where tp_ref_no=? and t.tp_bank=b.bk_name";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_SELECT_BANK");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select bc_type from borang_c_master where bc_ref_no=? and bc_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_SELECT_RTK_RTS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select d.* from borang_c_details d, borang_c_master m where m.bc_key=d.bc_key and m.bc_ref_no=? and m.bc_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_SELECT_RTK_RTS_DETAILS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();


                        // SME - HoGie
                        strQuery = "SELECT SME FROM BALANCE_SHEET WHERE BS_REF_NO =? AND BS_YA=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_SELECT_SME_STATUS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //


                        strQuery = "select pl_s60f from profit_loss_account where pl_ref_no=? and pl_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        OdbcDataReader drS60F = cmdOdbc.ExecuteReader();
                        string strTemp = "";
                        if (drS60F.HasRows)
                        {
                            while (drS60F.Read())
                            { strTemp = drS60F.GetString(0); }
                        }
                        drS60F.Dispose();
                        cmdOdbc.Dispose();

                        if (strTemp == "N")
                        {
                            //NGOHCS C2009.1 (SU12)
                            strQuery = "select tc_cb_check, tc_nb_chkcb from tax_computation where tc_ref_no=? and tc_ya=? order by tc_business";
                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer.ToString()));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                            //cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer2", strTaxPayer.ToString()));
                            //cmdOdbc.Parameters.Add(new OdbcParameter("@ya2", strYA));
                            daOdbc = new OdbcDataAdapter(cmdOdbc);
                            dtTemp = new DataTable("P1_SELECT_TAX_COMP");
                            daOdbc.Fill(dtTemp);
                            dsData.Tables.Add(dtTemp);
                            daOdbc.Dispose();
                            cmdOdbc.Dispose();
                        }
                        else
                        {
                            strQuery = "select ih_check, '2' from investment_holding where ih_ref_no=? and ih_ya=?";
                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer.ToString()));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                            //cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer2", strTaxPayer.ToString()));
                            //cmdOdbc.Parameters.Add(new OdbcParameter("@ya2", strYA));
                            daOdbc = new OdbcDataAdapter(cmdOdbc);
                            dtTemp = new DataTable("P1_SELECT_TAX_COMP");
                            daOdbc.Fill(dtTemp);
                            dsData.Tables.Add(dtTemp);
                            daOdbc.Dispose();
                            cmdOdbc.Dispose();
                        }
                        break;
                    case "C2011Page2":
                        strQuery = "select dir_name, dir_ic, dir_tel_no, dir_reftype, dir_refnum+dir_refnum2+dir_refnum3, dir_equity, dir_salary, dir_allow from directors_profile where dir_ref_no=? and dir_ya=? order by dir_order asc";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P2_INPUT_DIRECTORS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;
                    case "C2011Page3":
                        strQuery = "SELECT s.SH_IC, s.SH_NAME, iif(cdbl(b.bs_capital) > 0,(s.sh_share*s.sh_par_value/b.bs_capital)*100,0), s.SH_COUNTRY, s.SH_CHECK, s.SH_SHAREP FROM shareholders_profile AS s, balance_sheet AS b WHERE s.SH_REF_NO=b.bs_ref_no AND s.SH_YA=b.BS_YA AND s.SH_REF_NO=? AND S.SH_YA=? order by s.sh_order";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_SYER");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;
                    case "C2011Page4":
                        strQuery = "select bc_code from business_source where bc_key=? and bc_ya=? and bc_sourceno in (select pl_mainbuz from profit_loss_account where pl_ref_no=? and pl_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer2", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya2", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_BUSINESS_CODE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //main business income
                        strQuery = "select sum(plfs_amount) from plfst_sales where plfs_key in (select pl_key from profit_loss_account where pl_ref_no=? and pl_ya=?) and plfs_sourceno in (select pl_mainbuz from profit_loss_account where pl_ref_no=? and pl_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer2", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya2", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_PLFST_SALES");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum(plfos_amount) from plfst_openstock where plfos_key in (select pl_key from profit_loss_account where pl_ref_no=? and pl_ya=?) and plfos_sourceno in (select pl_mainbuz from profit_loss_account where pl_ref_no=? and pl_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer2", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya2", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_PLFST_OPENSTOCK");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum(plfpur_amount) from plfst_purchase where plfpur_key in (select pl_key from profit_loss_account where pl_ref_no=? and pl_ya=?) and plfpur_sourceno in (select pl_mainbuz from profit_loss_account where pl_ref_no=? and pl_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer2", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya2", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_PLFST_PURCHASE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum(exdep_amount) from expenses_depreciation where exdep_key in (select pl_key from profit_loss_account where pl_ref_no=? and pl_ya=?) and exdep_sourceno in (select pl_mainbuz from profit_loss_account where pl_ref_no=? and pl_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer2", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya2", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_EXP_DEPRECIATE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum(exa_amount) from expenses_allow where exa_key in (select pl_key from profit_loss_account where pl_ref_no=? and pl_ya=?) and exa_sourceno in (select pl_mainbuz from profit_loss_account where pl_ref_no=? and pl_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer2", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya2", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_EXP_ALLOW");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum(exna_amount) from expenses_nonallow where exna_key in (select pl_key from profit_loss_account where pl_ref_no=? and pl_ya=?) and exna_sourceno in (select pl_mainbuz from profit_loss_account where pl_ref_no=? and pl_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer2", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya2", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_EXP_NONALLOW");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum(plfcs_amount) from plfst_closestock where plfcs_key in (select pl_key from profit_loss_account where pl_ref_no=? and pl_ya=?) and plfcs_sourceno in (select pl_mainbuz from profit_loss_account where pl_ref_no=? and pl_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer2", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya2", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_PLFST_CLOSESTOCK");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //other source income 
                        strQuery = "select sum(plfs_amount) from plfst_sales where plfs_key in (select pl_key from profit_loss_account where pl_ref_no=? and pl_ya=?) and plfs_sourceno not in (select pl_mainbuz from profit_loss_account where pl_ref_no=? and pl_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer2", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya2", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_PLFST_SALES2");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum(plfos_amount) from plfst_openstock where plfos_key in (select pl_key from profit_loss_account where pl_ref_no=? and pl_ya=?) and plfos_sourceno not in (select pl_mainbuz from profit_loss_account where pl_ref_no=? and pl_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer2", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya2", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_PLFST_OPENSTOCK2");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum(plfpur_amount) from plfst_purchase where plfpur_key in (select pl_key from profit_loss_account where pl_ref_no=? and pl_ya=?) and plfpur_sourceno not in (select pl_mainbuz from profit_loss_account where pl_ref_no=? and pl_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer2", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya2", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_PLFST_PURCHASE2");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum(exdep_amount) from expenses_depreciation where exdep_key in (select pl_key from profit_loss_account where pl_ref_no=? and pl_ya=?) and exdep_sourceno not in (select pl_mainbuz from profit_loss_account where pl_ref_no=? and pl_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer2", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya2", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_EXP_DEPRECIATE2");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum(exa_amount) from expenses_allow where exa_key in (select pl_key from profit_loss_account where pl_ref_no=? and pl_ya=?) and exa_sourceno not in (select pl_mainbuz from profit_loss_account where pl_ref_no=? and pl_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer2", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya2", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_EXP_ALLOW2");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum(exna_amount) from expenses_nonallow where exna_key in (select pl_key from profit_loss_account where pl_ref_no=? and pl_ya=?) and exna_sourceno not in (select pl_mainbuz from profit_loss_account where pl_ref_no=? and pl_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer2", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya2", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_EXP_NONALLOW2");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select sum(plfcs_amount) from plfst_closestock where plfcs_key in (select pl_key from profit_loss_account where pl_ref_no=? and pl_ya=?) and plfcs_sourceno not in (select pl_mainbuz from profit_loss_account where pl_ref_no=? and pl_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer2", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya2", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_PLFST_CLOSESTOCK2");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select ed_amount from exempt_dividend where ed_key in (select pl_key from profit_loss_account where pl_ref_no=? and pl_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_EXEMPT_DIVIDEND");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //strQuery = "select pl_oth_bsin_nonsource, pl_oth_in, pl_nontax_in, pl_exp_int, pl_exp_intrestrict, pl_lawyer_cost, pl_tech_fee, pl_contract_exp, pl_exp_salary, pl_empl_stock, pl_royalty, pl_exp_rent, pl_exp_maintenance, pl_rnd, pl_advert, pl_travel, pl_other_exp, pl_net_profit_loss, pl_disallowed_exp from profit_loss_account where pl_ref_no =? and pl_ya=?";
                        strQuery = "select pl_oth_bsin_nonsource, pl_oth_in, pl_nontax_in, pl_exp_int, pl_exp_intrestrict, pl_lawyer_cost, pl_tech_fee, pl_contract_exp, pl_exp_salary, pl_empl_stock, pl_royalty, pl_exp_rent, pl_exp_maintenance, pl_rnd, pl_advert, pl_travel, pl_other_exp, pl_net_profit_loss, pl_disallowed_exp,pl_oth_bsin_realgt,pl_other_exp_unrealoss,pl_other_exp_realoss, pl_other_exrlossforeignt from profit_loss_account where pl_ref_no =? and pl_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_PROFIT_LOSS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        
                        strQuery = "select bs_transport, bs_machinery, bs_land, bs_oth_fa, bs_curyearfa, bs_investment, bs_trade_debtors, bs_oth_debtors, bs_stock, bs_loan_director, bs_cash, bs_oth_ca, bs_loan, bs_trade_cr, bs_other_cr, bs_loan_fr_dir, bs_oth_liab, bs_lt_liab, bs_capital, bs_pnl_appr_acc, bs_reserve_acc from balance_sheet where bs_ref_no=? and bs_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_BUSINESS_SOURCE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //YONG HO GIE - Non-taxable profits 
                        strQuery = "SELECT PL_OTH_BSIN_REALGT, PL_NONTAX_IN_REALG, PL_OTH_BSIN_UNREALGT, PL_NONTAX_IN_UNREALG " +
                                    "From profit_loss_account " + 
                                    "Where pl_ref_no =? and pl_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_NON_TAXALBE_PROFITS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        //YONG HO GIE - Non-taxable profits - END


                        break;
                    case "C2011Page5":
                        //NGOHCS C2009.1 (SU12)
                        strQuery = "select pl_s60f, pl_key from profit_loss_account where pl_ref_no=? and pl_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        OdbcDataReader drS60F2 = cmdOdbc.ExecuteReader();
                        string strTemp2 = "";
                        string strTempPLKey = "";
                        if (drS60F2.HasRows)
                        {
                            while (drS60F2.Read())
                            { strTemp2 = drS60F2.GetString(0);
                            strTempPLKey = drS60F2.GetString(1);}
                        }
                        drS60F2.Dispose();
                        cmdOdbc.Dispose();

                        if (strTemp2 == "Y")
                        {
                            strQuery = "select bc_code from business_source where bc_key=? and bc_ya=? and bc_sourceno in (select pl_mainbuz from profit_loss_account where pl_ref_no=? and pl_ya=?)";
                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer2", strTaxPayer));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya2", strYA));
                            daOdbc = new OdbcDataAdapter(cmdOdbc);
                            dtTemp = new DataTable("P5_INVEST_BC_CODE");
                            daOdbc.Fill(dtTemp);
                            dsData.Tables.Add(dtTemp);
                            daOdbc.Dispose();
                            cmdOdbc.Dispose();

                            // modify by csNgoh C20008.6 (SU6)
                            //strQuery = "select ih_interest_net, ih_rental_net, ih_exp_allowed, ih_appr_donation, ih_zakat, ih_stat_dividend, ih_pioneer_charge, ih_foreign_charge from investment_holding where ih_ref_no=? and ih_ya=?";
                            strQuery = "select ih_interest_net, ih_rental_net, ih_exp_allowed, ih_appr_donation, ih_zakat, ih_stat_dividend, ih_pioneer_charge, ih_foreign_charge, ih_royalty, ih_other_income, ih_addition, ih_other_expenses from investment_holding where ih_ref_no=? and ih_ya=?";
                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                            daOdbc = new OdbcDataAdapter(cmdOdbc);
                            dtTemp = new DataTable("P5_INVEST");
                            daOdbc.Fill(dtTemp);
                            dsData.Tables.Add(dtTemp);
                            daOdbc.Dispose();
                            cmdOdbc.Dispose();
                        }
                        else
                        {
                            strQuery = "select bc_code from business_source where bc_key=? and bc_ya=? order by bc_sourceno asc";
                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                            daOdbc = new OdbcDataAdapter(cmdOdbc);
                            dtTemp = new DataTable("P5_TC_BC_CODE");
                            daOdbc.Fill(dtTemp);
                            dsData.Tables.Add(dtTemp);
                            daOdbc.Dispose();
                            cmdOdbc.Dispose();

                            strQuery = "select tc_si_net_stat_in, tc_business from tax_computation where tc_ref_no=? and tc_ya=? order by tc_business asc";
                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                            daOdbc = new OdbcDataAdapter(cmdOdbc);
                            dtTemp = new DataTable("P5_TC_BC_AMOUNT");
                            daOdbc.Fill(dtTemp);
                            dsData.Tables.Add(dtTemp);
                            daOdbc.Dispose();
                            cmdOdbc.Dispose();

                            strQuery = "select tc_si_bs_loss_bf, tc_nb_int_net, tc_nb_rent_net, tc_ai_royalty, tc_nb_sundry, tc_nb_addition, tc_tp_curr_loss, tc_tp_prospecting, tc_tp_preop_bs, tc_tp_exp_allowed, tc_tp_aprv_donation, tc_tp_zakat, tc_stat_dividend, tc_tp_pioneer_charge, tc_tp_foreign_charge, tc_nb_royalty, tc_sundry_exp from tax_computation where tc_ref_no=? and tc_ya=? order by tc_business";
                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                            daOdbc = new OdbcDataAdapter(cmdOdbc);
                            dtTemp = new DataTable("P5_TC");
                            daOdbc.Fill(dtTemp);
                            dsData.Tables.Add(dtTemp);
                            daOdbc.Dispose();
                            cmdOdbc.Dispose();

                            // YONG HOGIE - PARTNERSHIP INCOME
                            strQuery = "SELECT T.PS_FILE_NO2, T.PS_FILE_NO3, IP.PN_TOTAL_STAT_INCOME " +
                                        "FROM  TAXP_PARTNERSHIP T , INCOME_PARTNERSHIP IP, TAX_COMPUTATION_PARTNER TAX " +
                                        "WHERE PS_KEY = ? " +
                                        "AND PS_YA = ? " +
                                        "AND T.PS_KEY = TAX.TCP_REF_NO " +
                                        "AND TAX.TCP_KEY = IP.TCP_KEY " +
                                        "AND IP.PN_SOURCENO = T.PS_SOURCEKEY " +
                                        "ORDER BY IP.PN_KEY";




                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                            daOdbc = new OdbcDataAdapter(cmdOdbc);
                            dtTemp = new DataTable("P5_PARTNERSHIP_INCOME");
                            daOdbc.Fill(dtTemp);
                            dsData.Tables.Add(dtTemp);
                            daOdbc.Dispose();
                            cmdOdbc.Dispose();

                            // YONG HOGIE - PARTNERSHIP INCOME - END
                        }

                        strQuery = "select exoad_detail, exoad_type, exoad_amount, exoad_exoadkey from other_exapprdonation where exoad_key=? and exoad_sourceno in (select bc_sourceno from business_source where bc_key=? and bc_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@plkey", strTempPLKey));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P5_DONATION");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();


                        strQuery = "select exoadd_type, exoadd_amount, exoadd_exoadkey from other_exapprdonation_detail where exoadd_key=? and exoadd_sourceno in (select bc_sourceno from business_source where bc_key=? and bc_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@plkey", strTempPLKey));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P5_DONATION_DETAIL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;



                    case "C2011Page6":
                        strQuery = "select it_1, it_2, it_3, it_4, it_5, it_6, it_6a, it_7, it_7a, it_7b, it_8, it_9, it_10,it_11, it_12, it_13, it_14, it_15, it_16, it_18, it_19, it_20, it_21, it_23, it_24, it_25, it_527, it_528, it_529, it_530 from income_transfer where it_ref_no=? and it_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P6_INCOME_TRANSFER"); 
                        daOdbc.Fill(dtTemp);
                        //Set ordinary of the field NGOHCS EFILING 2009
                        string[] strArray = {"501", "502", "503", "504", "505", "506", "507", "508", "509", "510", "511", "512", "513", "514", "515", "516", "517", "518", "519", "520", "521", "522", "523", "524", "525", "526", "527", "528", "529", "530"};
                        int i = strArray.Length - 1;
                        if (dtTemp.Rows.Count > 0)
                        {
                            dtTemp.Rows.Add(strArray);
                            while (0 <= i)
                            {
                                if (double.Parse(dtTemp.Rows[0].ItemArray[i].ToString())== 0)
                                {
                                    dtTemp.Columns.RemoveAt(i);
                                }
                                i--;
                            }
                        }
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                    case "C2011Page7":
                        strQuery = "select py_income from preceding_year where py_ref_no=? and py_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_PRECEDING_YEAR");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select dp_disposal, dp_declare from disposal where dp_ref_no=? and dp_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_DISPOSAL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                    case "C2011Page8":
                        strQuery = "select tc_cb_ca_util, tc_cb_ca_abal_cf from tax_computation where tc_ref_no=? and tc_ya=? order by tc_business asc";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_TC_CA");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //NGOHCS CA2008 
                        strQuery = "select ca_rate_aa, ca_qualifying_cost, ca_rate_ia, ca_remain_qc from ca where ca_ref_no=? and ca_ya=? and ca_mode = 'ADD' and ca_key not in (select distinct ca_key from ca_disposal where ca_disp_ya=?)";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbcCA);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@dispya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_CA_ADD");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select c.ca_rate_aa, c.ca_qualifying_cost, c.ca_rate_ia, sum(d.ca_disp_qc) from ca c inner join ca_disposal d on c.ca_key = d.ca_key where c.ca_ref_no = ? and c.ca_ya = ? and c.ca_mode = 'ADD' and d.ca_disp_ya =? group by c.ca_key, c.ca_qualifying_cost, c.ca_rate_aa, c.ca_rate_ia";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbcCA);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@dispya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_CA_ADDRQC");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        ////Lee Choo Chiang SU3.4
                        //OdbcDataReader drOdbc = new OdbcDataReader();
                        //strQuery = "SELECT TC_BUSINESS FROM TAX_COMPUTATION WHERE TC_REF_NO = "

                        //Yong Ho Gie - Total  - accelerated capital allowance 
                        strQuery = "Select TC_CB_CA_UTIL, TC_CB_CA_CURR, TC_CB_CA_ACA, TC_CB_CA_BAL_BF " + 
                                   "FROM TAX_COMPUTATION " +
                                   "WHERE TC_REF_NO = ? AND TC_YA = ?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_TC_Total_CA");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        //Yong Ho Gie - Total  - accelerated capital allowance - end
                        

                        //strQuery = "select count(ca_key), sum(ca_disp_qc) from ca_disposal where ca_key in (select ca_key from ca where ca_ref_no=? and ca_ya=? and ca_mode='ADD') and ca_disp_ya=? group by ca_key";
                        //cmdOdbc = new OdbcCommand(strQuery, connOdbcCA);
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@dispya", strYA));
                        //daOdbc = new OdbcDataAdapter(cmdOdbc);
                        //dtTemp = new DataTable("P8_CA_DISPQC");
                        //daOdbc.Fill(dtTemp);
                        //dsData.Tables.Add(dtTemp);
                        //daOdbc.Dispose();
                        //cmdOdbc.Dispose();
                        //NGOHCS CA2008 END

                        strQuery = "select sum(tc_cb_ca_disallow) from tax_computation where tc_ref_no=? and tc_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_CA_DISALLOW");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();


                        //Yong Ho Gie - Perkongsian 

                        strQuery = "SELECT PN_SOURCENO , PN_CA_BA , PN_CF " +
                                    "FROM INCOME_PARTNERSHIP IP , TAX_COMPUTATION_PARTNER TCP " +
                                    "WHERE TCP.TCP_KEY = IP.TCP_KEY AND TCP_REF_NO = ? AND TCP_YA = ? " +
                                    "ORDER BY  PN_SOURCENO";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_TC_PARTNER_CA");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;
                        //Yong Ho Gie - Perkongsian End

                    case "C2011Page9":
                        strQuery = "select tc_cb_ls_d_bl, tc_cb_ls_bals_cf, tc_cb_ls_samount, tc_cb_ls_blncf, tc_nb_carrybckloss, tc_nb_amtnotcarrybck, tc_nb_chkcb from tax_computation where tc_ref_no=? and tc_ya=? order by tc_business";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P9_TC");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select lc_pioneer_amt, lc_pioneer_bf, lc_service_amt, lc_service_bf, lc_hq_amt, lc_hq_bf, lc_ship_amt, lc_ship_bf from loss_claim where lc_ref_no=? and lc_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P9_LOSS_CLAIM");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;
                    case "C2011Page10":
                        strQuery = "select ic_invest_amt, ic_invest_bf, ic_indust_amt, ic_indust_bf, ic_infra_amt, ic_infra_bf, ic_sect7a_amt, ic_sect7a_bf, ic_sect7b_amt, ic_sect7b_bf, ic_export_amt, ic_export_bf, ic_agri_amt, ic_agri_bf, ic_intco_amt, ic_intco_bf, ic_service_amt, ic_service_bf, ic_special_amt, ic_special_bf, ic_bio_amt, ic_bio_cf, ic_sch4, ic_sch4b from incentive_claim where ic_ref_no=? and ic_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P10_INCENTIVE_CLAIM");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;
                    case "C2011Page11":
                        strQuery = "select oe_claimcode, oe_amount from other_expenditure where oe_ref_no=? and oe_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P11_OTHER_EXPENDITURE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;
                    case "C2011Page12":
                        strQuery = "select ea_credit, ea_exempt from exempt_account where ea_ref_no=? and ea_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P12_EXEMPT_ACC");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;
                    //case "C2009Page13":
                    //    strQuery = "select dp_disposal, dp_declare from disposal where dp_ref_no=? and dp_ya=?";
                    //    cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    //    cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                    //    cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                    //    daOdbc = new OdbcDataAdapter(cmdOdbc);
                    //    dtTemp = new DataTable("P13_DISPOSAL");
                    //    daOdbc.Fill(dtTemp);
                    //    dsData.Tables.Add(dtTemp);
                    //    daOdbc.Dispose();
                    //    cmdOdbc.Dispose();
                    //    break;
                    case "C2011Page13":
                        strQuery = "select wt_107a_gross, wt_107a_tax, wt_109_gross, wt_109_tax, wt_109a_gross, wt_109a_tax,wt_109b_gross, wt_109b_tax,wt_109e_gross, wt_109e_tax, wt_109f_gross, wt_109f_tax from withhold_tax where wt_ref_no=? and wt_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P14_WITHHOLD");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                    case "C2011Page14":
                        strQuery = "select rc_1, rc_2, rc_3, rc_4, rc_5, rc_6, rc_7, rc_8, rc_9, rc_10, rc_11, rc_12 from related_company where rc_ref_no=? and rc_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P15_RELATED");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;
                    case "C2011Page15":
                        strQuery = "select fe_type, fe_aer, fe_cwer, fe_mcer, fe_apa, fe_capa, fe_mcapa, fe_aernot, fe_apanot from foreignequity where fe_ref_no=? and fe_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P16_FOREIGN");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;
                    case "C2011Page16":
                        strQuery = "select pl_s60f from profit_loss_account where pl_ref_no=? and pl_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        OdbcDataReader drS60F3 = cmdOdbc.ExecuteReader();
                        string strTemp3 = "";
                        if (drS60F3.HasRows)
                        {
                            while (drS60F3.Read())
                            { strTemp3 = drS60F3.GetString(0); }
                        }
                        drS60F3.Dispose();
                        cmdOdbc.Dispose();

                        if (strTemp3 == "N")
                        {
                            strQuery = "Select TC_TP_APP_CHARGEABLE1, TC_TP_APP_CHARGEABLE2, TC_TP_APP_CHARGEABLE3, TC_TP_APP_CHARGEABLE4, TC_TP_APP_CHARGEABLE4A, TC_TP_APP_CHARGEABLE5, TC_TP_APP_CHARGEABLE6, TC_TP_RATE6, TC_TP_SEC6B_REBATE, TC_TP_SEC110B, TC_TP_SEC110, TC_TP_SEC110_OTHERS, TC_TP_SEC132, TC_TP_SEC133, TC_TP_INSTALL FROM TAX_COMPUTATION WHERE TC_REF_NO=? AND TC_YA=? ORDER BY TC_BUSINESS";
                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer.ToString()));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                            daOdbc = new OdbcDataAdapter(cmdOdbc);
                            dtTemp = new DataTable("P17_TABLE");
                            daOdbc.Fill(dtTemp);
                            dsData.Tables.Add(dtTemp);
                            daOdbc.Dispose();
                            cmdOdbc.Dispose();
                        }
                        else
                        {
                            strQuery = "SELECT IH_APP_CHARGE_IN1, IH_APP_CHARGE_IN2, IH_APP_CHARGE_IN3, IH_APP_CHARGE_IN4, IH_APP_CHARGE_IN4A, IH_APP_CHARGE_IN5, IH_APP_CHARGE_IN6, IH_RATE6, IH_SEC6B_REBATE, IH_ITP_SETOFF_110B, IH_ITP_SETOFF, IH_ITP_SETOFF_OTH, IH_SEC132, IH_SEC133, IH_INSTALLMENTS FROM INVESTMENT_HOLDING WHERE IH_REF_NO=? AND IH_YA=?";
                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                            daOdbc = new OdbcDataAdapter(cmdOdbc);
                            dtTemp = new DataTable("P17_TABLE");
                            daOdbc.Fill(dtTemp);
                            dsData.Tables.Add(dtTemp);
                            daOdbc.Dispose();
                            cmdOdbc.Dispose();
                        }
                        break;
                    case "C2011Page17":
                        strQuery = "select ad_co_name, ad_add, ad_add_postcode, ad_add_city, ad_add_state, ad_tel_no from auditor_profile where ad_co_name=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@auditor", strAuditor.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P18_AUDITOR");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;
                    case "C2011Page18":
                        strQuery = "select ta_add_line1, ta_add_line2, ta_add_line3, ta_add_postcode, ta_add_city, ta_add_state, ta_tel_no, ta_roc_no, ta_email from taxa_profile where ta_co_name=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxagent", strTaxAgent.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P19_FIRM");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;
                    case "C2011Page19":
                        strQuery = "select bc_ref_no as [Reference No], bc_co_name as [Company Name], format(bc_basis_period_fr,'dd MMM yyyy') as [Period From], format(bc_basis_period_to,'dd MMM yyyy') as [Period To], bc_type_amount as [Amount] from borang_c_details where bc_key in (select bc_key from borang_c_master where bc_ref_no=? and bc_ya=?) order by bc_priority asc";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P20_RKT_RKS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select bc_type from borang_c_master where bc_ref_no=? and bc_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P20_RKT_RKS_MASTER");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select tp_acc_period_fr, tp_acc_period_to from taxp_profile where tp_ref_no=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P20_RKT_RKS_ACCPERIOD");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                    case "R2011Page1":
                        strQuery = "select format(tp_acc_period_to,'dd/mm/yyyy'), format(tp_acc_period_fr,'dd/mm/yyyy') from taxp_profile where tp_ref_no=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_TP_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select format(br08_bb_date,'dd/mm/yyyy'), br08_bb_gross, br08_bb_tax, br08_bb_taxnotentl from borangr2008b where br08_key in (select br08_key from borangr2008 where br08_ref_no=? and br08_ya=?) order by br08_bb_key";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_BORANG08B");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;
                    case "R2011Page2":
                        strQuery = "select br08_baki108a1, br08_ba_bakibh, format(br08_ba_tarikh,'dd/mm/yyyy'), br08_ba_kreditsebelum, br08_ba_cukai110, br08_ba_cukaidikenakan, br08_ba_pelepasan132, br08_ba_pelepasan133, br08_ba_bayarbaliksebelum, br08_ba_pindaan, br08_ba_kurangan110, br08_ba_cukaidiremit, br08_ba_kurangantt1, br08_ba_kurangan1, br08_ba_kurangantt2, br08_ba_kurangan2, br08_ba_kurangantt3, br08_ba_kurangan3, br08_ba_cukaitt2000, br09_bakidiabaikan from borangr2008 where br08_ref_no=? and br08_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P2_BORANG08");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString()); 
            }
            return dsData;
        }

    }
}

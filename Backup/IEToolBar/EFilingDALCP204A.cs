using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;

namespace IEToolBar
{
    class EFilingDALCP204A : EFilingDAL
    {
        string strCP204AVersion = "";

        public EFilingDALCP204A()
        {
        }

        public EFilingDALCP204A(string strTaxPayer, string strYA, string strAuditor, string strTaxAgent, string strCP204AVersion)
        {
            this.strTaxPayer = strTaxPayer;
            this.strYA = strYA;
            this.strAuditor = strAuditor;
            this.strTaxAgent = strTaxAgent;
            this.strCP204AVersion = strCP204AVersion;
        }

        public DataSet GetFormDataCP204A(string strPage)
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
                //switch (strPage)
                //{
                //   case "CP2042009Page1":
                strQuery = "select bcp_correspond_add1, bcp_correspond_add2, bcp_correspond_add3, bcp_correspond_post, bcp_correspond_city, bcp_correspond_state, bcp_curr_corr_add1, bcp_curr_corr_add2, bcp_curr_corr_add3, bcp_curr_corr_post, bcp_curr_corr_city, bcp_curr_corr_state, bcp_estimated_tax, format(bcp_newco_date,'dd/mm/yyyy'), bcp_indicate, format(bcp_acc_period_fr,'dd/mm/yyyy'), format(bcp_acc_period_to,'dd/mm/yyyy'), format(bcp_basis_period_fr,'dd/mm/yyyy'), format(bcp_basis_period_to,'dd/mm/yyyy'), format(bcp_newco_bas_fr,'dd/mm/yyyy'), format(bcp_newco_bas_to,'dd/mm/yyyy'), format(bcp_newco_bas_sub_fr,'dd/mm/yyyy'), format(bcp_newco_bas_sub_to,'dd/mm/yyyy'), format(bcp_sme_period_fr,'yyyy'), format(bcp_sme_period_to,'yyyy'), bcp_chkm, bcp_to_month, bcp_rev_estimated_tax from borang_cp204 where bcp_ref_no=? and bcp_ya=? and bcp_version=? and bcp_form='CP204A'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@version", strCP204AVersion));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_BORANG_CP204A");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select ta_add_line1, ta_add_line2, ta_add_line3, ta_add_postcode, ta_add_city, ta_add_state, ta_tel_no, ta_roc_no, ta_email from taxa_profile where ta_co_name=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxagent", strTaxAgent.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_FIRM");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        
                //        break;
                    
                //}
            }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show(ex.ToString()); }
            return dsData;
        }

    }
}

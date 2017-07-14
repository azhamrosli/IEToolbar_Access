using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using System.Data;

namespace IEToolBar
{
    public class EFilingDAL
    {

        public OdbcConnection connOdbc = new OdbcConnection("Dsn=TAXSYSTEM;Uid=;Pwd=;");
        public OdbcConnection connOdbcCA = new OdbcConnection("Dsn=TAXCOM_CA_C;Uid=;Pwd=;");
        public OdbcCommand cmdOdbc;
        public string strTaxPayer;
        public string strYA;
        public string strAuditor;
        public string strTaxAgent;

        public EFilingDAL(string strTaxPayer, string strYA, string strAuditor, string strTaxAgent)
        {   
            this.strTaxPayer = strTaxPayer;
            this.strYA = strYA;
            this.strAuditor = strAuditor;
            this.strTaxAgent = strTaxAgent;
        }

        public EFilingDAL()
        {   }

        public void CloseConn()
        {
            if (this.connOdbc.State == ConnectionState.Open )   connOdbc.Close();
        }

        public void VersionUpgrade()
        {
            try
            {
                connOdbc.Open();
                DataTable dt = connOdbc.GetSchema("tables");
                if (dt.Select("table_name='EFILING_URL'").Length<=0)
                {
                    string strQuery = "create table EFILING_URL (EF_URL memo not null, EF_PAGE_INDEX varchar(30) not null, EF_YA varchar(5) not null, EF_TYPE varchar(10) not null)";
                    cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    int intRA = cmdOdbc.ExecuteNonQuery();
                    connOdbc.Close();
                    string[] strCURL = new string[20];
                    strCURL[0] = "https://spsd.hasil.gov.my/ec/mak_syarikat.aspx";
                    strCURL[1] = "https://spsd.hasil.gov.my/ec/mak_pengarah.aspx";
                    strCURL[2] = "https://spsd.hasil.gov.my/ec/mak_syer.aspx";
                    strCURL[3] = "https://spsd.hasil.gov.my/ec/mak_wang.aspx";
                    strCURL[4] = "https://spsd.hasil.gov.my/ec/pen_kanun.aspx";
                    strCURL[5] = "https://spsd.hasil.gov.my/ec/pen_pindah.aspx";
                    strCURL[6] = "https://spsd.hasil.gov.my/ec/pen_tahun.aspx";
                    strCURL[7] = "https://spsd.hasil.gov.my/ec/tun_elaun.aspx";
                    strCURL[8] = "https://spsd.hasil.gov.my/ec/tun_kerugian.aspx";
                    strCURL[9] = "https://spsd.hasil.gov.my/ec/tun_insentif.aspx";
                    strCURL[10] = "https://spsd.hasil.gov.my/ec/per_khas.aspx";
                    strCURL[11] = "https://spsd.hasil.gov.my/ec/lain_akaun.aspx";
                    strCURL[12] = "https://spsd.hasil.gov.my/ec/lain_syer.aspx";
                    strCURL[13] = "https://spsd.hasil.gov.my/ec/lain_cukai.aspx";
                    strCURL[14] = "https://spsd.hasil.gov.my/ec/lain_transaksi.aspx";
                    strCURL[15] = "https://spsd.hasil.gov.my/ec/lain_makl.aspx";
                    strCURL[16] = "https://spsd.hasil.gov.my/ec/cukai_dibayar.aspx";
                    strCURL[17] = "https://spsd.hasil.gov.my/ec/juruaudit.aspx";
                    strCURL[18] = "https://spsd.hasil.gov.my/ec/firma.aspx";
                    strCURL[19] = "https://spsd.hasil.gov.my/ec/rkt_rks.aspx";
                    if (InsertURLData(strCURL,"2008","C")<=0)
                        System.Windows.Forms.MessageBox.Show("Data insertion for TAXcom E-Filing has been failed!");

                    string[] strRURL = new string[2];
                    strRURL[0] = "https://spsd.hasil.gov.my/er/dividensyrkt.aspx";
                    strRURL[1] = "https://spsd.hasil.gov.my/er/penyata.aspx";
                    if (InsertURLData(strRURL, "2008", "R") <= 0)
                        System.Windows.Forms.MessageBox.Show("Data insertion for TAXcom E-Filing has been failed!");
                }

                //csNgoh C2008.6(SU6)
                DataTable dt2 = new DataTable();
                //EFilingDAL dalURL = new EFilingDAL();
                if (dt.Select("table_name='EFILING_URL'").Length > 0)
                {
                    connOdbc.Close();
                    if (String.IsNullOrEmpty(GetURL("Q0000PageX")))
                    {
                        string[] strQURL = new string[4];
                        strQURL[0] = "https://spsd.hasil.gov.my/Taef/LogMasuk.aspx";
                        strQURL[1] = "0000";
                        strQURL[2] = "Q0000PageX";
                        strQURL[3] = "QLINK";
                        if (Execute(strQURL, "ADD") <= 0)
                            System.Windows.Forms.MessageBox.Show("Data insertion for TAXcom E-Filing has been failed!");
                    }

                    string[] strCURL = new string[20];
                    string[] strRURL = new string[2];
                    string[] strUURL = new string[2];

                    strCURL[0] = "https://ef.hasil.gov.my/ec/mak_syarikat.aspx";
                    strCURL[1] = "https://ef.hasil.gov.my/ec/mak_pengarah.aspx";
                    strCURL[2] = "https://ef.hasil.gov.my/ec/mak_syer.aspx";
                    strCURL[3] = "https://ef.hasil.gov.my/ec/mak_wang.aspx";
                    strCURL[4] = "https://ef.hasil.gov.my/ec/pen_kanun.aspx";
                    strCURL[5] = "https://ef.hasil.gov.my/ec/pen_pindah.aspx";
                    strCURL[6] = "https://ef.hasil.gov.my/ec/pen_tahun.aspx";
                    strCURL[7] = "https://ef.hasil.gov.my/ec/tun_elaun.aspx";
                    strCURL[8] = "https://ef.hasil.gov.my/ec/tun_kerugian.aspx";
                    strCURL[9] = "https://ef.hasil.gov.my/ec/tun_insentif.aspx";
                    strCURL[10] = "https://ef.hasil.gov.my/ec/per_khas.aspx";
                    strCURL[11] = "https://ef.hasil.gov.my/ec/lain_akaun.aspx";
                    strCURL[12] = "https://ef.hasil.gov.my/ec/lain_syer.aspx";
                    strCURL[13] = "https://ef.hasil.gov.my/ec/lain_cukai.aspx";
                    strCURL[14] = "https://ef.hasil.gov.my/ec/lain_transaksi.aspx";
                    strCURL[15] = "https://ef.hasil.gov.my/ec/lain_makl.aspx";
                    strCURL[16] = "https://ef.hasil.gov.my/ec/cukai_dibayar.aspx";
                    strCURL[17] = "https://ef.hasil.gov.my/ec/juruaudit.aspx";
                    strCURL[18] = "https://ef.hasil.gov.my/ec/firma.aspx";
                    strCURL[19] = "https://ef.hasil.gov.my/ec/rkt_rks.aspx";
                    strRURL[0] = "https://ef.hasil.gov.my/er/dividensyrkt.aspx";
                    strRURL[1] = "https://ef.hasil.gov.my/er/penyata.aspx";

                    //dt2 = LoadAllURL();
                    for (int i = 0; i < strCURL.Length; i++)
                    {
                        strUURL[0] = strCURL[i];
                        strUURL[1] = "C2008Page" + (i + 1);
                        if (!GetURL(strUURL[1]).Contains(".gov."))
                        {
                            if (Execute(strUURL, "UPD") <= 0)
                            {
                                System.Windows.Forms.MessageBox.Show("Form C Data update for TAXcom E-Filing has been failed!");
                                break;
                            }
                        }
                    }
                    for (int i = 0; i < strRURL.Length; i++)
                    {
                        strUURL[0] = strRURL[i];
                        strUURL[1] = "R2008Page" + (i + 1);
                        if (!GetURL(strUURL[1]).Contains(".gov."))
                        {
                            if (Execute(strUURL, "UPD") <= 0)
                            {
                                System.Windows.Forms.MessageBox.Show("Form R Data update for TAXcom E-Filing has been failed!");
                                break;
                            }
                        }
                    }
                    
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("System upgrade for TAXcom E-Filing has been failed!");
            }
            finally
            {
                connOdbc.Close();
            }

        }

        public int InsertURLData(string[] arrData, string strYA, string strType)
        {
            DataTable dtData = new DataTable();
            dtData.Columns.Add("ef_url");
            dtData.Columns.Add("ef_page_index");
            dtData.Columns.Add("ef_ya");
            dtData.Columns.Add("ef_type");
            DataRow dr;
            for (int i = 0; i < arrData.Length; i++)
            {
                dr = dtData.NewRow();
                dr["ef_url"] = arrData[i];
                dr["ef_page_index"] = strType + strYA + "Page" + (i + 1);
                dr["ef_ya"] = strYA;
                dr["ef_type"] = strType;
                dtData.Rows.Add(dr);
            }
            
            try
            {
                string strQuery="insert into efiling_url(ef_url, ef_page_index, ef_ya, ef_type) values(?,?,?,?)";
                connOdbc.Open();
                OdbcDataAdapter odbcAdapter = new OdbcDataAdapter();
                odbcAdapter.InsertCommand = new OdbcCommand(strQuery, connOdbc);
                odbcAdapter.InsertCommand.Parameters.Add(new OdbcParameter("@ef_url", OdbcType.VarChar, 0, "ef_url"));
                odbcAdapter.InsertCommand.Parameters.Add(new OdbcParameter("@ef_page_index", OdbcType.VarChar, 0, "ef_page_index"));
                odbcAdapter.InsertCommand.Parameters.Add(new OdbcParameter("@ef_ya", OdbcType.VarChar, 0, "ef_ya"));
                odbcAdapter.InsertCommand.Parameters.Add(new OdbcParameter("@ef_type", OdbcType.VarChar, 0, "ef_type"));
                return odbcAdapter.Update(dtData);
            }
            catch
            {
                return -1;
            }
            finally
            {
                connOdbc.Close();
            }

         }

        public DataTable LoadAllURL(string strYA)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("select (select count(*) from efiling_url efurl where efurl.ef_url<=efurl2.ef_url and ef_ya = ?) as [No], ef_url as [URL], ef_page_index as [Page Index], ef_ya as [YA], ef_type as [Type] from efiling_url efurl2 where ef_page_index <> 'Q0000PageX' and ef_ya = ? order by ef_url asc, ef_ya desc, ef_page_index asc", connOdbc);
                OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
                daOdbc.SelectCommand.Parameters.Add(new OdbcParameter("@ef_ya", strYA));
                daOdbc.SelectCommand.Parameters.Add(new OdbcParameter("@ef_ya2", strYA));
                daOdbc.Fill(dtData);
                daOdbc.Dispose();
                cmdOdbc.Dispose();
            }
            catch 
            { 
                throw; 
            }
            finally
            { connOdbc.Close(); }
            return dtData;
        }

        public DataTable LoadAllURL(string[] strArray,string strYA)
        {
            DataTable dtData = new DataTable();
            try
            {
                if (strArray[0] == "C")
                {
                    connOdbc.Open();
                    cmdOdbc = new OdbcCommand("select (select count(*) from efiling_url efurl where efurl.ef_url<=efurl2.ef_url and efurl.ef_type in(?,?) and ef_ya = ?) as [No], ef_url as [URL], ef_page_index as [Page Index], ef_ya as [YA], ef_type as [Type] from efiling_url efurl2 where ef_type in(?,?) and ef_ya = ? order by ef_url asc, ef_ya desc, ef_page_index asc", connOdbc);
                    OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
                    daOdbc.SelectCommand.Parameters.Add(new OdbcParameter("@ef_type1", strArray[0]));
                    daOdbc.SelectCommand.Parameters.Add(new OdbcParameter("@ef_type2", strArray[1]));
                    daOdbc.SelectCommand.Parameters.Add(new OdbcParameter("@ef_ya", strYA));
                    daOdbc.SelectCommand.Parameters.Add(new OdbcParameter("@ef_type3", strArray[0]));
                    daOdbc.SelectCommand.Parameters.Add(new OdbcParameter("@ef_type4", strArray[1]));
                    daOdbc.SelectCommand.Parameters.Add(new OdbcParameter("@ef_ya2", strYA));
                    daOdbc.Fill(dtData);
                    daOdbc.Dispose();
                    cmdOdbc.Dispose();
                }
                //PANYW CP204
                else if (strArray[0] == "CP204")
                {
                    connOdbc.Open();
                    cmdOdbc = new OdbcCommand("select (select count(*) from efiling_url efurl where efurl.ef_url<=efurl2.ef_url and efurl.ef_type = ? and ef_ya = ?) as [No], ef_url as [URL], ef_page_index as [Page Index], ef_ya as [YA], ef_type as [Type] from efiling_url efurl2 where ef_type = ? and ef_ya = ? order by ef_url asc, ef_ya desc, ef_page_index asc", connOdbc);
                    OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
                    daOdbc.SelectCommand.Parameters.Add(new OdbcParameter("@ef_type", strArray[0]));
                    daOdbc.SelectCommand.Parameters.Add(new OdbcParameter("@ef_ya", strYA));
                    daOdbc.SelectCommand.Parameters.Add(new OdbcParameter("@ef_type2", strArray[0]));
                    daOdbc.SelectCommand.Parameters.Add(new OdbcParameter("@ef_ya2", strYA));
                    daOdbc.Fill(dtData);
                    daOdbc.Dispose();
                    cmdOdbc.Dispose();
                }
                //PANYW CP204 END
                else if (strArray[0] == "CP204A")
                {
                    connOdbc.Open();
                    cmdOdbc = new OdbcCommand("select (select count(*) from efiling_url efurl where efurl.ef_url<=efurl2.ef_url and efurl.ef_type = ? and ef_ya = ?) as [No], ef_url as [URL], ef_page_index as [Page Index], ef_ya as [YA], ef_type as [Type] from efiling_url efurl2 where ef_type = ? and ef_ya = ? order by ef_url asc, ef_ya desc, ef_page_index asc", connOdbc);
                    OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
                    daOdbc.SelectCommand.Parameters.Add(new OdbcParameter("@ef_type", strArray[0]));
                    daOdbc.SelectCommand.Parameters.Add(new OdbcParameter("@ef_ya", strYA));
                    daOdbc.SelectCommand.Parameters.Add(new OdbcParameter("@ef_type2", strArray[0]));
                    daOdbc.SelectCommand.Parameters.Add(new OdbcParameter("@ef_ya2", strYA));
                    daOdbc.Fill(dtData);
                    daOdbc.Dispose();
                    cmdOdbc.Dispose();
                }
            }
            catch
            {
                throw;
            }
            finally
            { connOdbc.Close(); }
            return dtData;
        }

        public Boolean VerifyURL(string strURL, string strYA, string strType)
        {
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("select ef_url from efiling_url where ef_url=? and ef_ya=? and ef_type=?", connOdbc);
                cmdOdbc.Parameters.Add(new OdbcParameter("@url", strURL));
                cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                cmdOdbc.Parameters.Add(new OdbcParameter("@type", strType));
                OdbcDataReader drData = cmdOdbc.ExecuteReader();
                if (drData.HasRows) return true;
                drData.Dispose();
                cmdOdbc.Dispose();
            }
            catch 
            { return false; }
            finally
            { connOdbc.Close(); }
            return false;
        }

        public Boolean VerifyYA(string strYA)
        {
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("select ya from year_assessment where ya=?", connOdbc);
                cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                OdbcDataReader drData = cmdOdbc.ExecuteReader();
                if (drData.HasRows) return true;
                drData.Dispose();
                cmdOdbc.Dispose();
            }
            catch 
            { return false; }
            finally
            { connOdbc.Close(); }
            return false;
        }
        //PANYW CP204
        public DataTable GetCP204TaxPayer(string strYA, string strSearchText)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("select bcp_ref_no as [Reference No], bcp_co_name as [Company Name], bcp_co_regno as [Company Registration No], bcp_ya as [Year of Accessment], bcp_estimated_tax as [Estimated Tax Payable], bcp_form as [Form Type] from borang_cp204 where bcp_form ='CP204' and bcp_ya = ? and bcp_ref_no like ? order by bcp_ref_no", connOdbc);
                cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                cmdOdbc.Parameters.Add(new OdbcParameter("@Text", strSearchText + '%'));
                OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
                daOdbc.Fill(dtData);
                daOdbc.Dispose();
                cmdOdbc.Dispose();
            }
            catch
            { throw; }
            finally
            { connOdbc.Close(); }
            return dtData;
        }

        public DataTable GetCP204TaxPayerName(string strYA, string strSearchText)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("select bcp_ref_no as [Reference No], bcp_co_name as [Company Name], bcp_co_regno as [Company Registration No], bcp_ya as [Year of Accessment], bcp_estimated_tax as [Estimated Tax Payable], bcp_form as [Form Type] from borang_cp204 where bcp_form='CP204' and bcp_ya = ? and bcp_co_name like ? order by bcp_ref_no", connOdbc);
                cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                cmdOdbc.Parameters.Add(new OdbcParameter("@Text", strSearchText + '%'));
                OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
                daOdbc.Fill(dtData);
                daOdbc.Dispose();
                cmdOdbc.Dispose();
            }
            catch
            { throw; }
            finally
            { connOdbc.Close(); }
            return dtData;
        }

        public DataTable GetCP204TaxPayerAll(string strYA, string strSearchText)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("select bcp_ref_no as [Reference No], bcp_co_name as [Company Name], bcp_co_regno as [Company Registration No], bcp_ya as [Year of Accessment], bcp_estimated_tax as [Estimated Tax Payable], bcp_form as [Form Type] from borang_cp204 where bcp_form = 'CP204' and bcp_ya = ? order by bcp_ref_no", connOdbc);
                cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
                daOdbc.Fill(dtData);
                daOdbc.Dispose();
                cmdOdbc.Dispose();
            }
            catch
            { throw; }
            finally
            { connOdbc.Close(); }
            return dtData;
        }
        //PANYW CP204 END

        //NGOHCS CP204A
        public DataTable GetCP204ATaxPayer(string strYA, string strSearchText)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("select bcp_ref_no as [Reference No], bcp_co_name as [Company Name], bcp_co_regno as [Company Registration No], bcp_ya as [Year of Accessment], bcp_rev_estimated_tax as [Estimated Tax Payable], bcp_version as [Version], bcp_form as [Form Type] from borang_cp204 where bcp_form ='CP204A' and bcp_ya = ? and bcp_ref_no like ? order by bcp_ref_no", connOdbc);
                cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                cmdOdbc.Parameters.Add(new OdbcParameter("@Text", strSearchText + '%'));
                OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
                daOdbc.Fill(dtData);
                daOdbc.Dispose();
                cmdOdbc.Dispose();
            }
            catch
            { throw; }
            finally
            { connOdbc.Close(); }
            return dtData;
        }

        public DataTable GetCP204ATaxPayerName(string strYA, string strSearchText)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("select bcp_ref_no as [Reference No], bcp_co_name as [Company Name], bcp_co_regno as [Company Registration No], bcp_ya as [Year of Accessment], bcp_rev_estimated_tax as [Estimated Tax Payable], bcp_version as [Version], bcp_form as [Form Type] from borang_cp204 where bcp_form='CP204A' and bcp_ya = ? and bcp_co_name like ? order by bcp_ref_no", connOdbc);
                cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                cmdOdbc.Parameters.Add(new OdbcParameter("@Text", strSearchText + '%'));
                OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
                daOdbc.Fill(dtData);
                daOdbc.Dispose();
                cmdOdbc.Dispose();
            }
            catch
            { throw; }
            finally
            { connOdbc.Close(); }
            return dtData;
        }

        public DataTable GetCP204ATaxPayerAll(string strYA, string strSearchText)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("select bcp_ref_no as [Reference No], bcp_co_name as [Company Name], bcp_co_regno as [Company Registration No], bcp_ya as [Year of Accessment], bcp_rev_estimated_tax as [Estimated Tax Payable], bcp_version as [Version], bcp_form as [Form Type] from borang_cp204 where bcp_form = 'CP204A' and bcp_ya = ? order by bcp_ref_no", connOdbc);
                cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
                daOdbc.Fill(dtData);
                daOdbc.Dispose();
                cmdOdbc.Dispose();
            }
            catch
            { throw; }
            finally
            { connOdbc.Close(); }
            return dtData;
        }
        //NGOHCS CP204A END

        public DataTable GetTaxPayer(string strYA, string strSearchText)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("select p.tp_ref_no as [Reference No], p.tp_com_name as [Company Name], p.tp_roc_no as [Company Registration No], p.tp_employer_no as [Employer No], p.tp_tax_file_no as [File No], Iif(p.tp_residence='1','Yes', Iif(p.tp_residence='2','No','Unknown')) as [Residence], c.ct_desc as [Country of Residence], p.tp_acc_period_fr as [Accounting Period Start], p.tp_acc_period_to as [Accounting Period End], Iif(p.tp_efiling='1','Yes', Iif(p.tp_efiling='2','No','Unknown')) as [Electronic Filling], Iif(p.tp_public_order='1','Yes',Iif(p.tp_public_order='2','No','Unknown')) as [Public Ruling Compliance], p.tp_email as [Email] from taxp_profile p, country c where p.tp_ref_no in (select pl_ref_no from profit_loss_account where pl_ya=?) and c.ct_code=p.tp_country and p.tp_ref_no like ? Union select p.tp_ref_no as [Reference No], p.tp_com_name as [Company Name], p.tp_roc_no as [Company Registration No], p.tp_employer_no as [Employer No], p.tp_tax_file_no as [File No], Iif(p.tp_residence='1','Yes', Iif(p.tp_residence='2','No','Unknown')) as [Residence], p.tp_country as [Country of Residence], p.tp_acc_period_fr as [Accounting Period Start], p.tp_acc_period_to as [Accounting Period End], Iif(p.tp_efiling='1','Yes', Iif(p.tp_efiling='2','No','Unknown')) as [Electronic Filling], Iif(p.tp_public_order='1','Yes',Iif(p.tp_public_order='2','No','Unknown')) as [Public Ruling Compliance], p.tp_email as [Email] from taxp_profile p where p.tp_ref_no in (select pl_ref_no from profit_loss_account where pl_ya=?) and p.tp_country='' and p.tp_ref_no like ? ", connOdbc);
                cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                cmdOdbc.Parameters.Add(new OdbcParameter("@Text", strSearchText + '%'));
                cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                cmdOdbc.Parameters.Add(new OdbcParameter("@Text", strSearchText + '%'));
                OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
                daOdbc.Fill(dtData);
                daOdbc.Dispose();
                cmdOdbc.Dispose();
            }
            catch
            { throw; }
            finally
            { connOdbc.Close(); }
            return dtData;
        }

        public DataTable GetTaxPayerName(string strYA, string strSearchText)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("select p.tp_ref_no as [Reference No], p.tp_com_name as [Company Name], p.tp_roc_no as [Company Registration No], p.tp_employer_no as [Employer No], p.tp_tax_file_no as [File No], Iif(p.tp_residence='1','Yes', Iif(p.tp_residence='2','No','Unknown')) as [Residence], c.ct_desc as [Country of Residence], p.tp_acc_period_fr as [Accounting Period Start], p.tp_acc_period_to as [Accounting Period End], Iif(p.tp_efiling='1','Yes', Iif(p.tp_efiling='2','No','Unknown')) as [Electronic Filling], Iif(p.tp_public_order='1','Yes',Iif(p.tp_public_order='2','No','Unknown')) as [Public Ruling Compliance], p.tp_email as [Email] from taxp_profile p, country c where p.tp_ref_no in (select pl_ref_no from profit_loss_account where pl_ya=?) and c.ct_code=p.tp_country and p.tp_com_name like ? order by p.tp_ref_no asc Union select p.tp_ref_no as [Reference No], p.tp_com_name as [Company Name], p.tp_roc_no as [Company Registration No], p.tp_employer_no as [Employer No], p.tp_tax_file_no as [File No], Iif(p.tp_residence='1','Yes', Iif(p.tp_residence='2','No','Unknown')) as [Residence], p.tp_country as [Country of Residence], p.tp_acc_period_fr as [Accounting Period Start], p.tp_acc_period_to as [Accounting Period End], Iif(p.tp_efiling='1','Yes', Iif(p.tp_efiling='2','No','Unknown')) as [Electronic Filling], Iif(p.tp_public_order='1','Yes',Iif(p.tp_public_order='2','No','Unknown')) as [Public Ruling Compliance], p.tp_email as [Email] from taxp_profile p where p.tp_ref_no in (select pl_ref_no from profit_loss_account where pl_ya=?) and p.tp_country='' and p.tp_com_name like ?", connOdbc);
                cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                cmdOdbc.Parameters.Add(new OdbcParameter("@Text", strSearchText + '%'));
                cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                cmdOdbc.Parameters.Add(new OdbcParameter("@Text", strSearchText + '%'));
                OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
                daOdbc.Fill(dtData);
                daOdbc.Dispose();
                cmdOdbc.Dispose();
            }
            catch
            { throw; }
            finally
            { connOdbc.Close(); }
            return dtData;
        }

        public DataTable GetTaxPayerAll(string strYA, string strSearchText)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("select p.tp_ref_no as [Reference No], p.tp_com_name as [Company Name], p.tp_roc_no as [Company Registration No], p.tp_employer_no as [Employer No], p.tp_tax_file_no as [File No], Iif(p.tp_residence='1','Yes', Iif(p.tp_residence='2','No','Unknown')) as [Residence], c.ct_desc as [Country of Residence], p.tp_acc_period_fr as [Accounting Period Start], p.tp_acc_period_to as [Accounting Period End], Iif(p.tp_efiling='1','Yes', Iif(p.tp_efiling='2','No','Unknown')) as [Electronic Filling], Iif(p.tp_public_order='1','Yes',Iif(p.tp_public_order='2','No','Unknown')) as [Public Ruling Compliance], p.tp_email as [Email] from taxp_profile p, country c where p.tp_ref_no in (select pl_ref_no from profit_loss_account where pl_ya=?) and c.ct_code=p.tp_country Union select p.tp_ref_no as [Reference No], p.tp_com_name as [Company Name], p.tp_roc_no as [Company Registration No], p.tp_employer_no as [Employer No], p.tp_tax_file_no as [File No], Iif(p.tp_residence='1','Yes', Iif(p.tp_residence='2','No','Unknown')) as [Residence], p.tp_country as [Country of Residence], p.tp_acc_period_fr as [Accounting Period Start], p.tp_acc_period_to as [Accounting Period End], Iif(p.tp_efiling='1','Yes', Iif(p.tp_efiling='2','No','Unknown')) as [Electronic Filling], Iif(p.tp_public_order='1','Yes',Iif(p.tp_public_order='2','No','Unknown')) as [Public Ruling Compliance], p.tp_email as [Email] from taxp_profile p where p.tp_ref_no in (select pl_ref_no from profit_loss_account where pl_ya=?) and p.tp_country =''", connOdbc);
                cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
                daOdbc.Fill(dtData);
                daOdbc.Dispose();
                cmdOdbc.Dispose();
            }
            catch
            { throw; }
            finally
            { connOdbc.Close(); }
            return dtData;
        }

        public DataTable GetAuditor()
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("select ad_co_name from auditor_profile", connOdbc);
                OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
                daOdbc.Fill(dtData);
                daOdbc.Dispose();
                cmdOdbc.Dispose();
            }
            catch
            { throw; }
            finally
            { connOdbc.Close(); }
            return dtData;
        }

        public DataTable GetTaxAgent()
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("select ta_co_name from taxa_profile order by ta_default desc", connOdbc);
                OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
                daOdbc.Fill(dtData);
                daOdbc.Dispose();
                cmdOdbc.Dispose();
            }
            catch
            { throw; }
            finally
            { connOdbc.Close(); }
            return dtData;
        }

        public DataTable GetYA()
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("select ya from year_assessment order by ya desc", connOdbc);
                OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
                daOdbc.Fill(dtData);
                daOdbc.Dispose();
                cmdOdbc.Dispose();
            }
            catch
            { throw; }
            finally
            { connOdbc.Close(); }
            return dtData;
        }

        public string GetRecCount(string strYA, string strType)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("select count(*) from efiling_url where ef_ya=? and ef_type=?", connOdbc);
                cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                cmdOdbc.Parameters.Add(new OdbcParameter("@type", strType));
                OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
                daOdbc.Fill(dtData);
                daOdbc.Dispose();
                cmdOdbc.Dispose();
            }
            catch
            { throw; }
            finally
            { connOdbc.Close(); }
            return dtData.Rows[0].ItemArray[0].ToString();
        }

        public int Execute(string[] strData, string strOprCode)
        {
            connOdbc.Open();
            switch (strOprCode)
            {
                case "ADD":
                    cmdOdbc = new OdbcCommand("insert into efiling_url(ef_url, ef_ya, ef_page_index, ef_type) values(?,?,?,?)", connOdbc);
                    cmdOdbc.Parameters.Add(new OdbcParameter("@url", strData[0]));
                    cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strData[1]));
                    cmdOdbc.Parameters.Add(new OdbcParameter("@page", strData[2]));
                    cmdOdbc.Parameters.Add(new OdbcParameter("@type", strData[3]));
                    break;
                case "UPD":
                    cmdOdbc = new OdbcCommand("update efiling_url set ef_url=? where ef_page_index=?", connOdbc);
                    cmdOdbc.Parameters.Add(new OdbcParameter("@url", strData[0]));
                    cmdOdbc.Parameters.Add(new OdbcParameter("@index", strData[1]));
                    break;
                case "DEL":
                    cmdOdbc = new OdbcCommand("delete from efiling_url where ef_page_index=?", connOdbc);
                    cmdOdbc.Parameters.Add(new OdbcParameter("@index", strData[0]));
                    break;
                case "DELALL":
                    cmdOdbc = new OdbcCommand("delete * from efiling_url where ef_ya=? and ef_type=?", connOdbc);
                    cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strData[0]));
                    cmdOdbc.Parameters.Add(new OdbcParameter("@type", strData[1]));
                    break;
                case "DELALLR":
                    cmdOdbc = new OdbcCommand("delete * from efiling_url where ef_ya=? and ef_type='R'", connOdbc);
                    cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strData[0]));
                    break;
            }
            int intRE = 0;
            try
            { intRE = cmdOdbc.ExecuteNonQuery(); }
            catch
            { throw; }
            finally
            { connOdbc.Close(); }
            return intRE;
        }

        public string GetDocName(string strURL, string strYA)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("select ef_page_index from efiling_url where ef_url like ? and ef_ya=?", connOdbc);
                OdbcParameter prmURL = new OdbcParameter("@url", OdbcType.NVarChar, 2048);
                prmURL.Value = "%" + strURL + "%";
                cmdOdbc.Parameters.Add(prmURL);
                cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
                daOdbc.Fill(dtData);
                daOdbc.Dispose();
                cmdOdbc.Dispose();
            }
            catch
            { throw; }
            finally
            { connOdbc.Close(); }
            if (dtData.Rows.Count > 0)  return dtData.Rows[0].ItemArray[0].ToString();
            else    return "";
        }
        // csNgoh C2008.6 (SU6) 
        public string GetURL(string strPageIndex)
        {

            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("select ef_url from efiling_url where ef_page_index = ?", connOdbc);
                //OdbcParameter prmURL = new OdbcParameter("@index", OdbcType.NVarChar, 2048);
                //prmURL.Value = "%" + strURL + "%";
                //cmdOdbc.Parameters.Add(prmURL);
                cmdOdbc.Parameters.Add(new OdbcParameter("@index", strPageIndex));
                OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
                daOdbc.Fill(dtData);
                daOdbc.Dispose();
                cmdOdbc.Dispose();
            }
            catch
            { throw; }
            finally
            { connOdbc.Close();}
            if (dtData.Rows.Count > 0) return dtData.Rows[0].ItemArray[0].ToString();
            else return "";
        }

        public DataSet GetFormData(string strPage) 
        {
            string strQuery="";
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
                    case "C2008Page1":
                        strQuery = "select t.tp_com_name, t.tp_ref_no, t.tp_employer_no, t.tp_roc_no,  format(t.tp_acc_period_fr,'dd/mm/yyyy'), format(t.tp_acc_period_to,'dd/mm/yyyy'), t.tp_reg_add_line1, t.tp_reg_add_line2, t.tp_reg_add_line3, t.tp_reg_postcode, t.tp_reg_city, t.tp_tel_no, t.tp_curr_add_line1, t.tp_curr_add_line2, t.tp_curr_add_line3, t.tp_curr_postcode, t.tp_curr_city, t.tp_com_add_line1, t.tp_com_add_line2, t.tp_com_add_line3, t.tp_com_postcode, t.tp_com_city, t.tp_bank_acc, t.tp_alt_add_line1, t.tp_alt_add_line2, t.tp_alt_add_line3, t.tp_alt_postcode, t.tp_alt_city from taxp_profile t where tp_ref_no=?";
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

                        strQuery = "select pl_s60f from profit_loss_account where pl_ref_no=? and pl_ya=?";                       
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA ));
                        OdbcDataReader drS60F = cmdOdbc.ExecuteReader();
                        string strTemp="";
                        if (drS60F.HasRows )
                        {
                            while (drS60F.Read())
                            { strTemp = drS60F.GetString(0); }
                        }
                        drS60F.Dispose();
                        cmdOdbc.Dispose();

                        if (strTemp == "N")
                        {
                            strQuery = "select tc_cb_check from tax_computation where tc_ref_no=? and tc_ya=?";
                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer.ToString()));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer2", strTaxPayer.ToString()));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya2", strYA));
                            daOdbc = new OdbcDataAdapter(cmdOdbc);
                            dtTemp = new DataTable("P1_SELECT_TAX_COMP");
                            daOdbc.Fill(dtTemp);
                            dsData.Tables.Add(dtTemp);
                            daOdbc.Dispose();
                            cmdOdbc.Dispose();
                        }
                        else
                        {
                            strQuery = "select ih_check from investment_holding where ih_ref_no=? and ih_ya=?";
                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer.ToString()));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer2", strTaxPayer.ToString()));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya2", strYA));
                            daOdbc = new OdbcDataAdapter(cmdOdbc);
                            dtTemp = new DataTable("P1_SELECT_TAX_COMP");
                            daOdbc.Fill(dtTemp);
                            dsData.Tables.Add(dtTemp);
                            daOdbc.Dispose();
                            cmdOdbc.Dispose();
                        }
                        break;
                    case "C2008Page2":
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
                    case "C2008Page3":
                        strQuery = "SELECT s.SH_IC, s.SH_NAME, (s.sh_share*s.sh_par_value/b.bs_capital)*100, s.SH_COUNTRY, s.SH_CHECK, s.SH_SHAREP FROM shareholders_profile AS s, balance_sheet AS b WHERE s.SH_REF_NO=b.bs_ref_no AND s.SH_YA=b.BS_YA AND s.SH_REF_NO=? AND S.SH_YA=? order by s.sh_order";
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
                    case "C2008Page4":
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

                        strQuery = "select pl_oth_bsin_nonsource, pl_oth_in, pl_nontax_in, pl_exp_int, pl_exp_intrestrict, pl_lawyer_cost, pl_tech_fee, pl_contract_exp, pl_exp_salary, pl_empl_stock, pl_royalty, pl_exp_rent, pl_exp_maintenance, pl_rnd, pl_advert, pl_travel, pl_other_exp, pl_net_profit_loss, pl_disallowed_exp from profit_loss_account where pl_ref_no =? and pl_ya=?";
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

                        strQuery = "select pl_oth_bsin_realgt from profit_loss_account where pl_ref_no = ? and pl_ya = ?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_FOREIGN_EXCHANGE_GAINT_TRADE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();  //hogie - added on 5th August 2011 
                        break;
                    case "C2008Page5":
                        strQuery = "select pl_s60f from profit_loss_account where pl_ref_no=? and pl_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        OdbcDataReader drS60F2 = cmdOdbc.ExecuteReader();
                        string strTemp2 = "";
                        if (drS60F2.HasRows)
                        {
                            while (drS60F2.Read())
                            { strTemp2 = drS60F2.GetString(0); }
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
                            strQuery = "select ih_interest_net, ih_rental_net, ih_exp_allowed, ih_appr_donation, ih_zakat, ih_stat_dividend, ih_pioneer_charge, ih_foreign_charge, ih_royalty, ih_other_income, ih_addition from investment_holding where ih_ref_no=? and ih_ya=?";
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

                            strQuery = "select tc_si_bs_loss_bf, tc_nb_int_net, tc_nb_rent_net, tc_ai_royalty, tc_nb_sundry, tc_nb_addition, tc_tp_curr_loss, tc_tp_prospecting, tc_tp_preop_bs, tc_tp_exp_allowed, tc_tp_aprv_donation, tc_tp_zakat, tc_stat_dividend, tc_tp_pioneer_charge, tc_tp_foreign_charge from tax_computation where tc_ref_no=? and tc_ya=? order by tc_business";
                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                            daOdbc = new OdbcDataAdapter(cmdOdbc);
                            dtTemp = new DataTable("P5_TC");
                            daOdbc.Fill(dtTemp);
                            dsData.Tables.Add(dtTemp);
                            daOdbc.Dispose();
                            cmdOdbc.Dispose();
                        }
                        break;
                    case "C2008Page6":
                        strQuery = "select it_1, it_2, it_3, it_4, it_5, it_6, it_6a, it_7, it_7a, it_7b, it_8, it_9, it_10,it_11, it_12, it_13, it_14, it_15, it_16, it_18, it_19, it_20, it_21, it_23, it_24, it_25 from income_transfer where it_ref_no=? and it_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P6_INCOME_TRANSFER");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;
                    case "C2008Page7":
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
                        break;
                    case "C2008Page8":
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
                        //strQuery = "select ca_add_rate, ca_add_qc, ca_add_ia_rate, ca_add_curr_amt from ca_addition where ca_add_ref_no=? and ca_add_ya=?";
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

                        //strQuery = "select ca_add_rate, ca_add_qc, ca_add_ia_rate, ca_add_curr_amt from ca_addition where ca_add_ref_no=? and ca_add_ya=?";
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
                        //NGOHCS CA2008

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
                        break;
                    case "C2008Page9":
                        strQuery = "select  tc_cb_ls_d_bl, tc_cb_ls_bals_cf, tc_cb_ls_samount, tc_cb_ls_blncf from tax_computation where tc_ref_no=? and tc_ya=? order by tc_business";
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
                    case "C2008Page10":
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
                    case "C2008Page11":
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
                    case "C2008Page12":
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
                    case "C2008Page13":
                        strQuery = "select dp_disposal, dp_declare from disposal where dp_ref_no=? and dp_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P13_DISPOSAL");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;
                    case "C2008Page14":
                        strQuery = "select wt_107a_gross, wt_107a_tax, wt_109_gross, wt_109_tax, wt_109a_gross, wt_109a_tax,wt_109b_gross, wt_109b_tax,wt_109e_gross, wt_109e_tax from withhold_tax where wt_ref_no=? and wt_ya=?";
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

                    case "C2008Page15":
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
                    case "C2008Page16":
                        strQuery = "select fe_type, fe_aer, fe_cwer, fe_mcer from foreignequity where fe_ref_no=? and fe_ya=?";
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
                    case "C2008Page17":
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
                    case "C2008Page18":
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
                    case "C2008Page19":
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
                    case "C2008Page20":
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

                    case "R2008Page1":
                        strQuery = "select format(tp_acc_period_to,'dd/mm/yyyy') from taxp_profile where tp_ref_no=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_TP_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        strQuery = "select format(br08_bb_date,'dd/mm/yyyy'), br08_bb_gross, br08_bb_tax, br08_bb_taxnotentl from borangr2008b where br08_key in (select br08_key from borangr2008 where br08_ref_no=? and br08_ya=?)";
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
                    case "R2008Page2":
                        strQuery = "select br08_baki108a1, br08_ba_bakibh, format(br08_ba_tarikh,'dd/mm/yyyy'), br08_ba_kreditsebelum, br08_ba_cukai110, br08_ba_cukaidikenakan, br08_ba_pelepasan132, br08_ba_pelepasan133, br08_ba_bayarbaliksebelum, br08_ba_pindaan, br08_ba_kurangan110, br08_ba_cukaidiremit, br08_ba_kurangantt1, br08_ba_kurangan1, br08_ba_kurangantt2, br08_ba_kurangan2, br08_ba_kurangantt3, br08_ba_kurangan3, br08_ba_cukaitt2000 from borangr2008 where br08_ref_no=? and br08_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P2_BORANG08");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //NGOHCS C2009.1 (SU12)
                        strQuery = "select pl_s60f from profit_loss_account where pl_ref_no=? and pl_ya=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        OdbcDataReader drS60F5 = cmdOdbc.ExecuteReader();
                        string strTemp5 = "";
                        if (drS60F5.HasRows)
                        {
                            while (drS60F5.Read())
                            { strTemp5 = drS60F5.GetString(0); }
                        }
                        drS60F5.Dispose();
                        cmdOdbc.Dispose();

                        if (strTemp5 == "N")
                        {
                            strQuery = "select tc_tp_rate4a_chargeable, tc_tp_28_chargeable, tc_tp_sec132, tc_tp_sec133 from tax_computation where tc_ref_no=? and tc_ya=? order by tc_business";
                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer.ToString()));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                            daOdbc = new OdbcDataAdapter(cmdOdbc);
                            dtTemp = new DataTable("P2_BORANG08_SEC4A");
                            daOdbc.Fill(dtTemp);
                            dsData.Tables.Add(dtTemp);
                            daOdbc.Dispose();
                            cmdOdbc.Dispose();
                        }
                        else
                        {
                            strQuery = "select ih_itp_charge_in4a, ih_itp_charge_in5, ih_sec132, ih_sec133 from investment_holding where ih_ref_no=? and ih_ya=?";
                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer.ToString()));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                            daOdbc = new OdbcDataAdapter(cmdOdbc);
                            dtTemp = new DataTable("P2_BORANG08_SEC4A");
                            daOdbc.Fill(dtTemp);
                            dsData.Tables.Add(dtTemp);
                            daOdbc.Dispose();
                            cmdOdbc.Dispose();
                        }
                        break;
                }
            }
            catch(Exception ex)
            { System.Windows.Forms.MessageBox.Show(ex.ToString()); }
            return dsData;
        }
   
    }
}

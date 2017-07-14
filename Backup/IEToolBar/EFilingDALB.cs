using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using System.Data;

namespace IEToolBar
{
    public class EFilingDALB
    {

        protected OdbcConnection  connOdbc = new OdbcConnection("Dsn=TAXCOM_B;Uid=;Pwd=;");
        protected OdbcCommand cmdOdbc;
        protected string strTaxPayer;
        protected string strYA;
        protected string strTaxAgent;
        //private string strAuditor;

        public EFilingDALB(string strTaxPayer, string strYA, string strTaxAgent)
        {   
            this.strTaxPayer = strTaxPayer;
            this.strYA = strYA;
            this.strTaxAgent = strTaxAgent;
        }

        public EFilingDALB()
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
                    string[] strBURL = new string[12];
                    strBURL[0] = "https://spsd.hasil.gov.my/eBE2009/Mak_ind.aspx";
                    strBURL[1] = "https://spsd.hasil.gov.my/eBE2009/mak_pasangan.aspx";
                    strBURL[2] = "https://spsd.hasil.gov.my/eBE2009/pendapatan.aspx";
                    strBURL[3] = "https://spsd.hasil.gov.my/eBE2009/Pelepasan.aspx";
                    strBURL[4] = "https://spsd.hasil.gov.my/eBE2009/rebat.aspx";
                    strBURL[5] = "https://spsd.hasil.gov.my/eBE2009/perniagaan.aspx";
                    strBURL[6] = "https://spsd.hasil.gov.my/eBE2009/khas.aspx";
                    strBURL[7] = "https://spsd.hasil.gov.my/eBE2009/kewangan.aspx";
                    strBURL[8] = "https://spsd.hasil.gov.my/eBE2009/mak_pentadbir.aspx";
                    strBURL[9] = "https://spsd.hasil.gov.my/eBE2009/rumusan.aspx";
                    strBURL[10] = "https://spsd.hasil.gov.my/eBE2009/akuan.aspx";
                    strBURL[11] = "https://spsd.hasil.gov.my/eBE2009/HK3.aspx";
                    if (InsertURLData(strBURL, "2008", "B") <= 0)
                        System.Windows.Forms.MessageBox.Show("Data insertion for TAXcom E-Filing has been failed!");

                    string[] strBEURL = new string[9];
                    strBEURL[0] = "https://spsd.hasil.gov.my/eBE2009/Mak_ind.aspx";
                    strBEURL[1] = "https://spsd.hasil.gov.my/eBE2009/mak_pasangan.aspx";
                    strBEURL[2] = "https://spsd.hasil.gov.my/eBE2009/pendapatan.aspx";
                    strBEURL[3] = "https://spsd.hasil.gov.my/eBE2009/pelepasan.aspx";
                    strBEURL[4] = "https://spsd.hasil.gov.my/eBE2009/rebat.aspx";
                    strBEURL[5] = "https://spsd.hasil.gov.my/eBE2009/mak_pentadbir.aspx";
                    strBEURL[6] = "https://spsd.hasil.gov.my/eBE2009/rumusan.aspx";
                    strBEURL[7] = "https://spsd.hasil.gov.my/eBE2009/akuan.aspx";
                    strBEURL[8] = "https://spsd.hasil.gov.my/eBE2009/HK3.aspx";
                    if (InsertURLData(strBEURL,"2008","BE")<=0)
                        System.Windows.Forms.MessageBox.Show("Data insertion for TAXcom E-Filing has been failed!");

                    string[] strMURL = new string[11];
                    strMURL[0] = "https://spsd.hasil.gov.my/eM2009/Mak_ind.aspx";
                    strMURL[1] = "https://spsd.hasil.gov.my/eM2009/mak_pasangan.aspx";
                    strMURL[2] = "https://spsd.hasil.gov.my/eM2009/Income.aspx";
                    strMURL[3] = "https://spsd.hasil.gov.my/eM2009/taxpayable.aspx";
                    strMURL[4] = "https://spsd.hasil.gov.my/eM2009/perniagaan.aspx";
                    strMURL[5] = "https://spsd.hasil.gov.my/eM2009/khas.aspx";
                    strMURL[6] = "https://spsd.hasil.gov.my/eM2009/financial.aspx";
                    strMURL[7] = "https://spsd.hasil.gov.my/eM2009/mak_pentadbir.aspx";
                    strMURL[8] = "https://spsd.hasil.gov.my/eM2009/rumusan.aspx";
                    strMURL[9] = "https://spsd.hasil.gov.my/eM2009/akuan.aspx";
                    strMURL[10] = "https://spsd.hasil.gov.my/eM2009/HK3.aspx";
                    if (InsertURLData(strMURL, "2008", "M") <= 0)
                        System.Windows.Forms.MessageBox.Show("Data insertion for TAXcom E-Filing has been failed!");
                }
                DataTable dt2 = new DataTable();
                if (dt.Select("table_name='EFILING_URL'").Length > 0)
                {
                    connOdbc.Close();
                    string[] strBURL = new string[12];
                    string[] strBEURL = new string[9];
                    string[] strMURL = new string[11];
                    string[] strUURL = new string[2];
                    strBURL[0] = "https://ef.hasil.gov.my/eBE2009/Mak_ind.aspx";
                    strBURL[1] = "https://ef.hasil.gov.my/eBE2009/mak_pasangan.aspx";
                    strBURL[2] = "https://ef.hasil.gov.my/eBE2009/pendapatan.aspx";
                    strBURL[3] = "https://ef.hasil.gov.my/eBE2009/Pelepasan.aspx";
                    strBURL[4] = "https://ef.hasil.gov.my/eBE2009/rebat.aspx";
                    strBURL[5] = "https://ef.hasil.gov.my/eBE2009/perniagaan.aspx";
                    strBURL[6] = "https://ef.hasil.gov.my/eBE2009/khas.aspx";
                    strBURL[7] = "https://ef.hasil.gov.my/eBE2009/kewangan.aspx";
                    strBURL[8] = "https://ef.hasil.gov.my/eBE2009/mak_pentadbir.aspx";
                    strBURL[9] = "https://ef.hasil.gov.my/eBE2009/rumusan.aspx";
                    strBURL[10] = "https://ef.hasil.gov.my/eBE2009/akuan.aspx";
                    strBURL[11] = "https://ef.hasil.gov.my/eBE2009/HK3.aspx";
                    strBEURL[0] = "https://ef.hasil.gov.my/eBE2009/Mak_ind.aspx";
                    strBEURL[1] = "https://ef.hasil.gov.my/eBE2009/mak_pasangan.aspx";
                    strBEURL[2] = "https://ef.hasil.gov.my/eBE2009/pendapatan.aspx";
                    strBEURL[3] = "https://ef.hasil.gov.my/eBE2009/pelepasan.aspx";
                    strBEURL[4] = "https://ef.hasil.gov.my/eBE2009/rebat.aspx";
                    strBEURL[5] = "https://ef.hasil.gov.my/eBE2009/mak_pentadbir.aspx";
                    strBEURL[6] = "https://ef.hasil.gov.my/eBE2009/rumusan.aspx";
                    strBEURL[7] = "https://ef.hasil.gov.my/eBE2009/akuan.aspx";
                    strBEURL[8] = "https://ef.hasil.gov.my/eBE2009/HK3.aspx";
                    strMURL[0] = "https://ef.hasil.gov.my/eM2009/Mak_ind.aspx";
                    strMURL[1] = "https://ef.hasil.gov.my/eM2009/mak_pasangan.aspx";
                    strMURL[2] = "https://ef.hasil.gov.my/eM2009/Income.aspx";
                    strMURL[3] = "https://ef.hasil.gov.my/eM2009/taxpayable.aspx";
                    strMURL[4] = "https://ef.hasil.gov.my/eM2009/perniagaan.aspx";
                    strMURL[5] = "https://ef.hasil.gov.my/eM2009/khas.aspx";
                    strMURL[6] = "https://ef.hasil.gov.my/eM2009/financial.aspx";
                    strMURL[7] = "https://ef.hasil.gov.my/eM2009/mak_pentadbir.aspx";
                    strMURL[8] = "https://ef.hasil.gov.my/eM2009/rumusan.aspx";
                    strMURL[9] = "https://ef.hasil.gov.my/eM2009/akuan.aspx";
                    strMURL[10] = "https://ef.hasil.gov.my/eM2009/HK3.aspx";

                    for (int i = 0; i < strBURL.Length; i++)
                    {
                        strUURL[0] = strBURL[i];
                        strUURL[1] = "B2008Page" + (i + 1);
                        if (!GetURL(strUURL[1]).Contains("ef."))
                        {
                            if (Execute(strUURL, "UPD") <= 0)
                            {
                                System.Windows.Forms.MessageBox.Show("Form B Data update for TAXcom E-Filing has been failed!");
                                break;
                            }
                        }
                    }
                    for (int i = 0; i < strBEURL.Length; i++)
                    {
                        strUURL[0] = strBEURL[i];
                        strUURL[1] = "BE2008Page" + (i + 1);
                        if (!GetURL(strUURL[1]).Contains("ef."))
                        {
                            if (Execute(strUURL, "UPD") <= 0)
                            {
                                System.Windows.Forms.MessageBox.Show("Form BE Data update for TAXcom E-Filing has been failed!");
                                break;
                            }
                        }
                    }
                    for (int i = 0; i < strMURL.Length; i++)
                    {
                        strUURL[0] = strMURL[i];
                        strUURL[1] = "M2008Page" + (i + 1);
                        if (!GetURL(strUURL[1]).Contains("ef."))
                        {
                            if (Execute(strUURL, "UPD") <= 0)
                            {
                                System.Windows.Forms.MessageBox.Show("Form M Data update for TAXcom E-Filing has been failed!");
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

        public string GetURL(string strPageIndex)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("select ef_url from efiling_url where ef_page_index = ?", connOdbc);
                cmdOdbc.Parameters.Add(new OdbcParameter("@index", strPageIndex));
                OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
                daOdbc.Fill(dtData);
                daOdbc.Dispose();
                cmdOdbc.Dispose();
            }
            catch
            { throw; }
            finally
            { connOdbc.Close(); }
            if (dtData.Rows.Count > 0) return dtData.Rows[0].ItemArray[0].ToString();
            else return "";
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

        public DataTable LoadAllURL(string strType , string strYA)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("select (select count(*) from efiling_url efurl where efurl.ef_url<=efurl2.ef_url and efurl.ef_type = ? and ef_ya = ?) as [No], ef_url as [URL], ef_page_index as [Page Index], ef_ya as [YA], ef_type as [Type] from efiling_url efurl2 where ef_type = ? and ef_ya = ? order by ef_url asc, ef_ya desc, ef_page_index asc", connOdbc);
                OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
                daOdbc.SelectCommand.Parameters.Add(new OdbcParameter("@ef_type",strType));
                daOdbc.SelectCommand.Parameters.Add(new OdbcParameter("@ef_ya", strYA));
                daOdbc.SelectCommand.Parameters.Add(new OdbcParameter("@ef_type2",strType));
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

        //NGOHCS 2009
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
        //NGOHCS 2009 END 

        public DataTable GetTaxPayerB(string strSearchText)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
//                cmdOdbc = new OdbcCommand("select (p.tp_ref_no1 + p.tp_ref_no2 + p.tp_ref_no3) as [Reference No], p.tp_name as [Name],  (p.tp_ic_new_1 + p.tp_ic_new_2 + p.tp_ic_new_3) as [IC No], p.tp_file_no as [Company Registration No], c.ct_desc as [Country of Residence], p.tp_email as [Email] from taxp_profile p, country c where (p.tp_ref_no1 + p.tp_ref_no2 + p.tp_ref_no3) in (select tc_ref_no from tax_computation where tc_ya=?) and c.ct_code=p.tp_country and p.tp_nonresident = 'No' order by  (p.tp_ref_no1 + p.tp_ref_no2 + p.tp_ref_no3) asc", connOdbc);
                cmdOdbc = new OdbcCommand("SELECT (TP_REF_NO1 + TP_REF_NO2 + TP_REF_NO3) as [Reference No], TP_NAME AS [Name], (TP_IC_NEW_1 + TP_IC_NEW_2 + TP_IC_NEW_3) AS [IC No], TP_FILE_NO AS [File No] FROM TAXP_PROFILE WHERE TP_5 LIKE ? AND TP_NONRESIDENT='No' ORDER BY TP_5", connOdbc);
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

        public DataTable GetTaxPayerBName(string strSearchText)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("SELECT (TP_REF_NO1 + TP_REF_NO2 + TP_REF_NO3) as [Reference No], TP_NAME AS [Name], (TP_IC_NEW_1 + TP_IC_NEW_2 + TP_IC_NEW_3) AS [IC No], TP_FILE_NO AS [File No] FROM TAXP_PROFILE WHERE TP_NAME LIKE ? AND TP_NONRESIDENT='No' ORDER BY TP_5", connOdbc);
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

        public DataTable GetTaxPayerBAll(string strSearchText)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("SELECT (TP_REF_NO1 + TP_REF_NO2 + TP_REF_NO3) as [Reference No], TP_NAME AS [Name], (TP_IC_NEW_1 + TP_IC_NEW_2 + TP_IC_NEW_3) AS [IC No], TP_FILE_NO AS [File No] FROM TAXP_PROFILE WHERE TP_NONRESIDENT='No' ORDER BY TP_5", connOdbc);
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

        public DataTable GetTaxPayerM(string strSearchText)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("SELECT (TP_REF_NO1 + TP_REF_NO2 + TP_REF_NO3) as [Reference No], TP_NAME AS [Name], (TP_IC_NEW_1 + TP_IC_NEW_2 + TP_IC_NEW_3) AS [IC No], TP_FILE_NO AS [File No] FROM TAXP_PROFILE WHERE TP_5 LIKE ? AND TP_NONRESIDENT='Yes' ORDER BY TP_5", connOdbc);
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

        public DataTable GetTaxPayerMName(string strSearchText)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("SELECT (TP_REF_NO1 + TP_REF_NO2 + TP_REF_NO3) as [Reference No], TP_NAME AS [Name], (TP_IC_NEW_1 + TP_IC_NEW_2 + TP_IC_NEW_3) AS [IC No], TP_FILE_NO AS [File No] FROM TAXP_PROFILE WHERE TP_NAME LIKE ? AND TP_NONRESIDENT='Yes' ORDER BY TP_5", connOdbc);
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

        public DataTable GetTaxPayerMAll(string strSearchText)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("SELECT (TP_REF_NO1 + TP_REF_NO2 + TP_REF_NO3) as [Reference No], TP_NAME AS [Name], (TP_IC_NEW_1 + TP_IC_NEW_2 + TP_IC_NEW_3) AS [IC No], TP_FILE_NO AS [File No] FROM TAXP_PROFILE WHERE TP_NONRESIDENT='Yes' ORDER BY TP_5", connOdbc);
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

        public string GetDocName(string strURL, string strYA , string strFormType)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("select ef_page_index from efiling_url where ef_url like ? and ef_ya=? and ef_type=?", connOdbc);
                OdbcParameter prmURL = new OdbcParameter("@url", OdbcType.NVarChar, 2048);
                prmURL.Value = "%" + strURL + "%";
                cmdOdbc.Parameters.Add(prmURL);
                cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                cmdOdbc.Parameters.Add(new OdbcParameter("@formtype", strFormType));
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
            else return "";
        }

        public DataSet GetFormDataB(string strPage)
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

                    case "B2008Page1":
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
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_INPUT_TAX_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                    case "B2008Page2":
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
                        break;

                    case "B2008Page3":
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

                        strQuery = "select tc_statutory_income, tc_businessloss_bf, tc_aggregate_bus_income, tc_employment_income, tc_dividend, (cdbl(tc_interest) + cdbl(tc_discount)), (cdbl(tc_rental_royalty)+cdbl(tc_premium)), tc_pension_and_etc,(cdbl(tc_other_gain_profit) + cdbl(tc_sec4a)), tc_addition_43, tc_aggregate_other_src, tc_businessloss_cy, tc_prospecting, tc_qualifying_ag_exp, tc_key, tc_prospecting,tc_qualifying_ag_exp, tc_4, tc_3, tc_total_income_2, tc_income_transfer_from_hw, tc_total_income_3, (cdbl(tc_installment_payment_self) + cdbl(tc_installment_payment_hw)) from tax_computation where tc_ref_no =? and tc_ya =?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_TAX_COMPUTATION");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

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
                        break;


                    case "B2008Page4":
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
                        break;


                    case "B2008Page5":
                        strQuery = "select tc_sec110_others, tc_1, tc_2, tc_sec110_dividend from tax_computation where tc_ref_no= ? and tc_ya= ?";
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
                        break;
                        
                    case "B2008Page6":
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
                        break;

                    case "B2008Page7":
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
                        break;

                    case "B2008Page8":
                        strQuery = "select pl_key, pl_main_business from profit_loss_account where pl_ref_no = ? and pl_ya = ? and pl_maincompany = '1' order by pl_key";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        OdbcDataReader drMainBus = cmdOdbc.ExecuteReader();
                        string strPNLKey = "";
                        string strPLMAINBUS = "";
                        if (drMainBus.HasRows)
                        {
                            while (drMainBus.Read())
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
                                while (drOthBus.Read())
                                { 
                                  strPNLKey = drOthBus.GetString(0);
                                  strPLMAINBUS = drMainBus.GetString(1);
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

                            strQuery = "select bc_bus_entity, bc_code, bc_company from business_source where bc_key = ? and bc_ya = ?  and bc_businesssource = (select pl_main_business from profit_loss_account where pl_ref_no = ? and pl_ya = ? order by pl_key)";
                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer1", strTaxPayer));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
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
                        break;

                    case "B2008Page9":

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
                        break;

                    case "B2008Page12":
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

                    //Insert Code Here...
                }
            }
            catch(Exception ex)
            { System.Windows.Forms.MessageBox.Show(ex.ToString()); }
            return dsData;
        }

        public DataSet GetFormDataBE(string strPage)
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
                    case "BE2008Page1":
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
                        break;
                    case "BE2008Page2":
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
                        break;
                    case "BE2008Page3":
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
                        break;
                    case "BE2008Page4":
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
                    case "BE2008Page5":
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

                    case "BE2008Page6":
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

                }
            }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show(ex.ToString()); }
            return dsData;
        }

        public DataSet GetFormDataM(string strPage)
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
                    case "M2008Page1":
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

                        strQuery = "SELECT FORMAT(TP_DOB,'dd/mm/yyyy') " +
                        "FROM TAXP_PROFILE2 WHERE TP_REF_NO=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_TAXP_PROFILE2");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;
                    case "M2008Page2":
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
                        break;
                    case "M2008Page3":
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

                        strQuery = "SELECT OS_RT_SEC4A_RENTAL " +
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

                        strQuery = "SELECT TC_BUSINESSLOSS_BF, TC_EMPLOYMENT_INCOME, TC_EXEMPT_CLAIM, TC_EXEMPT_COUNTRY, TC_DIVIDEND, " +
                        "TC_INTEREST, TC_DISCOUNT, TC_RENTAL_ROYALTY, TC_PREMIUM, TC_PENSION_AND_ETC, " +
                        "TC_OTHER_GAIN_PROFIT, TC_SEC4A, TC_ADDITION_43, TC_BUSINESSLOSS_CY, TC_3, " +
                        "TC_INCOME_TRANSFER_FROM_HW, TC_INSTALLMENT_PAYMENT_SELF, TC_INSTALLMENT_PAYMENT_HW, TC_PROSPECTING " +
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
                        break;
                    case "M2008Page4":
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
                    case "M2008Page5":
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
                        break;
                    case "M2008Page6":
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
                    case "M2008Page7":
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

                        strQuery = "SELECT BC_BUS_ENTITY, BC_CODE " +
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

                        strQuery = "SELECT BC_BUS_ENTITY, BC_CODE " +
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
                    case "M2008Page8":
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

                    case "M2008Page11":
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
                }
            }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show(ex.ToString()); }
            return dsData;
        }

#region "PNL Business Rules"
        public Double OtherSource_GrossProfitLoss(long cPNL_Key, string PNLCompany)
        {
            int i = 0;
            string strQuery = "";
            string[] arrSource = new string[0];
            double[,] arrPNL;
            double osTotal = 0.0;
            OdbcDataReader drOthBus = null;

            i = 0;
            osTotal = 0;
            connOdbc.Open();

            strQuery = "SELECT [BC_BUSINESSSOURCE] FROM [BUSINESS_SOURCE] WHERE [BC_KEY] = ? AND [BC_YA] = ? AND [BC_COMPANY] <> ?";
            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
            cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
            cmdOdbc.Parameters.Add(new OdbcParameter("@pnlcompany", PNLCompany));
            drOthBus = cmdOdbc.ExecuteReader();
            if (drOthBus.HasRows)
            {
                while (drOthBus.Read())
                {
                    i = i + 1;
                    Array.Resize(ref arrSource, i);
                    arrSource[i-1] = drOthBus.GetString(0);
                }
            }
            drOthBus.Dispose(); 
            cmdOdbc.Dispose();

            if (i != 0)
            {
                arrPNL = new double[i,6];
                for (int J = 0; J <= arrPNL.GetUpperBound(0); J++)
                {
                    arrPNL[J,0] = 0; //Sales
                    arrPNL[J,1] = 0; //Opening Stock
                    arrPNL[J,2] = 0; //Purchase
                    arrPNL[J,3] = 0; //Cost of Production
                    arrPNL[J,4] = 0; //Closing Stock
                    arrPNL[J,5] = 0; //Gross Profit and Loss

                    //*** Sales
                    strQuery = "SELECT sum([PL_AMOUNT]) FROM [PL_SALES] WHERE [PL_KEY] = " + cPNL_Key + " AND [PL_SOURCENO] = '" + arrSource[J] + "'";
                    cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    //cmdOdbc.Parameters.Add(new OdbcParameter("@pnlkey", cPNL_Key));
                    //cmdOdbc.Parameters.Add(new OdbcParameter("@plsource", arrSource[J]));
                    drOthBus = cmdOdbc.ExecuteReader();
                    if (drOthBus.HasRows)
                    {
                        if (drOthBus.Read())
                        {
                            if (!drOthBus.IsDBNull(0))
                            {
                               //if (!String.IsNullOrEmpty(drOthBus.GetString(0).ToString())) 
                                    arrPNL[J, 0] = double.Parse(drOthBus.GetDouble(0).ToString());
                            }
                        }
                    }
                    drOthBus.Dispose();
                    cmdOdbc.Dispose();

                    //*** Opening Stock
                    strQuery = "SELECT sum([PL_AMOUNT]) FROM [PL_OPENSTOCK] WHERE [PL_KEY] = " + cPNL_Key + " AND [PL_SOURCENO] = '" + arrSource[J] + "'";
                    cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    //cmdOdbc.Parameters.Add(new OdbcParameter("@pnlkey", cPNL_Key));
                    //cmdOdbc.Parameters.Add(new OdbcParameter("@plsource", arrSource[J]));
                    drOthBus = cmdOdbc.ExecuteReader();
                    if (drOthBus.HasRows)
                    {
                        if (drOthBus.Read())
                        {
                            if (!drOthBus.IsDBNull(0))
                            {
                                //if (!String.IsNullOrEmpty(drOthBus.GetString(0).ToString())) 
                                arrPNL[J, 1] = double.Parse(drOthBus.GetDouble(0).ToString());
                            }
                        }
                    }
                    drOthBus.Dispose();
                    cmdOdbc.Dispose();

                    //*** Purchase
                    strQuery = "SELECT sum([PL_AMOUNT]) FROM [PL_PURCHASE] WHERE [PL_KEY] = " + cPNL_Key + " AND [PL_SOURCENO] = '" + arrSource[J] + "'";
                    cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    //cmdOdbc.Parameters.Add(new OdbcParameter("@pnlkey", cPNL_Key));
                    //cmdOdbc.Parameters.Add(new OdbcParameter("@plsource", arrSource[J]));
                    drOthBus = cmdOdbc.ExecuteReader();
                    if (drOthBus.HasRows)
                    {
                        if (drOthBus.Read())
                        {
                            if (!drOthBus.IsDBNull(0))
                            {
                                //if (!String.IsNullOrEmpty(drOthBus.GetString(0).ToString())) 
                                arrPNL[J, 2] = double.Parse(drOthBus.GetDouble(0).ToString());

                            }
                        }
                    }
                    drOthBus.Dispose();
                    cmdOdbc.Dispose();

                    //*** Cost of Production
                    strQuery = "SELECT sum([EXA_AMOUNT]) FROM [PL_PRODUCTION_COST] WHERE [EXA_KEY] = " + cPNL_Key + " AND [EXA_SOURCENO] = '" + arrSource[J] + "'";
                    cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    //cmdOdbc.Parameters.Add(new OdbcParameter("@pnlkey", cPNL_Key));
                    //cmdOdbc.Parameters.Add(new OdbcParameter("@plsource", arrSource[J]));
                    drOthBus = cmdOdbc.ExecuteReader();
                    if (drOthBus.HasRows)
                    {
                        if (drOthBus.Read())
                        {
                            if (!drOthBus.IsDBNull(0))
                            {
                                //if (!String.IsNullOrEmpty(drOthBus.GetString(0).ToString())) 
                                arrPNL[J, 3] = double.Parse(drOthBus.GetDouble(0).ToString());
                            }
                        }
                    }
                    drOthBus.Dispose();
                    cmdOdbc.Dispose();

                    //*** Closing Stock
                    strQuery = "SELECT sum([PL_AMOUNT]) FROM [PL_CLOSESTOCK] WHERE [PL_KEY] = " + cPNL_Key + " AND [PL_SOURCENO] = '" + arrSource[J] + "'";
                    cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    //cmdOdbc.Parameters.Add(new OdbcParameter("@pnlkey", cPNL_Key));
                    //cmdOdbc.Parameters.Add(new OdbcParameter("@plsource", arrSource[J]));
                    drOthBus = cmdOdbc.ExecuteReader();
                    if (drOthBus.HasRows)
                    {
                        if (drOthBus.Read())
                        {
                            if (!drOthBus.IsDBNull(0))
                            {
                               //if (!String.IsNullOrEmpty(drOthBus.GetString(0))) 
                                arrPNL[J, 4] = double.Parse(drOthBus.GetDouble(0).ToString());
                            }
                        }
                    }
                    drOthBus.Dispose();
                    cmdOdbc.Dispose();

                    //Cost of sales (Opening Stock + Purchase + Cost of Production - Closing Stock)
                    //Gross Profit and Loss (Sales - Cost of Sales)
                    arrPNL[J,5] = arrPNL[J,0] - (arrPNL[J,1] + arrPNL[J,2] + arrPNL[J,3] - arrPNL[J,4]);
                    if (arrPNL[J,5] > 0)
                    {
                        osTotal = osTotal + arrPNL[J,5];
                    }
                }
            }
            if (this.connOdbc.State == ConnectionState.Open){ connOdbc.Close(); }
            return osTotal;

           }

        public double OtherSource_Sales(string strPLKey)
        {
            string strQuery = "";
            OdbcDataReader drOthBus = null;
            double SalesAmount = 0.0;

            connOdbc.Open();

            strQuery = "SELECT [PL_AMOUNT] FROM [PL_SALES] WHERE [PL_KEY] = ?";
            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
            cmdOdbc.Parameters.Add(new OdbcParameter("@pnlkey", strPLKey));

            drOthBus = cmdOdbc.ExecuteReader();
            if (drOthBus.HasRows)
            {
                while (drOthBus.Read())
                {
                    SalesAmount = double.Parse(drOthBus.GetString(0));
                }
            }
            drOthBus.Dispose();
            cmdOdbc.Dispose();

            if (this.connOdbc.State == ConnectionState.Open) { connOdbc.Close(); }
            return SalesAmount;
        }

#endregion
    }
}

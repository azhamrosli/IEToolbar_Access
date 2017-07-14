using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using System.Data;

namespace IEToolBar
{
    public class EFilingDALP
    {

        protected OdbcConnection connOdbc = new OdbcConnection("Dsn=TAXCOM_P;Uid=;Pwd=;");
        protected OdbcConnection connOdbcB = new OdbcConnection("Dsn=TAXCOM_B;Uid=;Pwd=;");
        protected OdbcCommand cmdOdbc;
        protected string strTaxPayer;
        protected string strYA;
        protected string strTaxAgent;
        //private string strAuditor;

        public EFilingDALP(string strTaxPayer, string strYA, string strTaxAgent)
        {   
            this.strTaxPayer = strTaxPayer;
            this.strYA = strYA;
            this.strTaxAgent = strTaxAgent;
        }

        public EFilingDALP()
        {   }

        public void CloseConn()
        {
            if (this.connOdbc.State == ConnectionState.Open )   connOdbc.Close();
            if (this.connOdbcB.State == ConnectionState.Open) connOdbcB.Close();
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
                    string[] strPURL = new string[10];
                    strPURL[0] = "https://spsd.hasil.gov.my/eP2009/Mak_asas.aspx";
                    strPURL[1] = "https://spsd.hasil.gov.my/eP2009/Pendapatan.aspx";
                    strPURL[2] = "https://spsd.hasil.gov.my/eP2009/Pendapatan2.aspx";
                    strPURL[3] = "https://spsd.hasil.gov.my/eP2009/pendapatan_lain.aspx";
                    strPURL[4] = "https://spsd.hasil.gov.my/eP2009/perbelanjaan.aspx";
                    strPURL[5] = "https://spsd.hasil.gov.my/eP2009/mak_cukai.aspx";
                    strPURL[6] = "https://spsd.hasil.gov.my/eP2009/mak_ahli_kongsi.aspx";
                    strPURL[7] = "https://spsd.hasil.gov.my/eP2009/mak_wang.aspx";
                    strPURL[8] = "https://spsd.hasil.gov.my/eP2009/mak_firma.aspx";
                    strPURL[9] = "https://spsd.hasil.gov.my/eP2009/akuan.aspx";
                   
                    if (InsertURLData(strPURL,"2008","P")<=0)
                        System.Windows.Forms.MessageBox.Show("Data insertion for TAXcom E-Filing has been failed!");
                 }
                 DataTable dt2 = new DataTable();
                 if (dt.Select("table_name='EFILING_URL'").Length > 0)
                 {
                     connOdbc.Close();
                     string[] strPURL = new string[10];
                     string[] strUURL = new string[2];
                     strPURL[0] = "https://ef.hasil.gov.my/eP2009/Mak_asas.aspx";
                     strPURL[1] = "https://ef.hasil.gov.my/eP2009/Pendapatan.aspx";
                     strPURL[2] = "https://ef.hasil.gov.my/eP2009/Pendapatan2.aspx";
                     strPURL[3] = "https://ef.hasil.gov.my/eP2009/pendapatan_lain.aspx";
                     strPURL[4] = "https://ef.hasil.gov.my/eP2009/perbelanjaan.aspx";
                     strPURL[5] = "https://ef.hasil.gov.my/eP2009/mak_cukai.aspx";
                     strPURL[6] = "https://ef.hasil.gov.my/eP2009/mak_ahli_kongsi.aspx";
                     strPURL[7] = "https://ef.hasil.gov.my/eP2009/mak_wang.aspx";
                     strPURL[8] = "https://ef.hasil.gov.my/eP2009/mak_firma.aspx";
                     strPURL[9] = "https://ef.hasil.gov.my/eP2009/akuan.aspx";

                     for (int i = 0; i < strPURL.Length; i++)
                     {
                         strUURL[0] = strPURL[i];
                         strUURL[1] = "P2008Page" + (i + 1);
                         if (!GetURL(strUURL[1]).Contains("ef."))
                         {
                             if (Execute(strUURL, "UPD") <= 0)
                             {
                                 System.Windows.Forms.MessageBox.Show("Form P Data update for TAXcom E-Filing has been failed!");
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
                cmdOdbc = new OdbcCommand("select ta_co_name from taxa_profile order by ta_default desc", connOdbcB);
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

        public DataTable GetTaxPayer(string strSearchText)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("SELECT p.pt_ref_no as [Reference No], p.pt_name as [Name], p.pt_register_no as [Registration No] from taxp_profile p WHERE pt_ref_no LIKE ? ORDER BY pt_ref_no", connOdbc);
                cmdOdbc.Parameters.Add(new OdbcParameter("@Text", strSearchText + '%'));
                //cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
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

        public DataTable GetTaxPayerName(string strSearchText)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("SELECT p.pt_ref_no as [Reference No], p.pt_name as [Name], p.pt_register_no as [Registration No] from taxp_profile p WHERE pt_name LIKE ? ORDER BY pt_ref_no", connOdbc);
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

        public DataTable GetTaxPayerAll(string strSearchText)
        {
            DataTable dtData = new DataTable();
            try
            {
                connOdbc.Open();
                cmdOdbc = new OdbcCommand("SELECT p.pt_ref_no as [Reference No], p.pt_name as [Name], p.pt_register_no as [Registration No] from taxp_profile p ORDER BY pt_ref_no", connOdbc);
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

        //public DataTable GetAuditor()
        //{
        //    DataTable dtData = new DataTable();
        //    try
        //    {
        //        connOdbc.Open();
        //        cmdOdbc = new OdbcCommand("select ad_co_name from auditor_profile", connOdbc);
        //        OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
        //        daOdbc.Fill(dtData);
        //        daOdbc.Dispose();
        //        cmdOdbc.Dispose();
        //    }
        //    catch
        //    { throw; }
        //    finally
        //    { connOdbc.Close(); }
        //    return dtData;
        //}

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
        //public string GetURL(string strPageIndex)
        //{
        //    DataTable dtData = new DataTable();
        //    try
        //    {
        //        connOdbc.Open();
        //        cmdOdbc = new OdbcCommand("select ef_url from efiling_url where ef_page_index = ?", connOdbc);
        //        //OdbcParameter prmURL = new OdbcParameter("@index", OdbcType.NVarChar, 2048);
        //        //prmURL.Value = "%" + strURL + "%";
        //        //cmdOdbc.Parameters.Add(prmURL);
        //        cmdOdbc.Parameters.Add(new OdbcParameter("@index", strPageIndex));
        //        OdbcDataAdapter daOdbc = new OdbcDataAdapter(cmdOdbc);
        //        daOdbc.Fill(dtData);
        //        daOdbc.Dispose();
        //        cmdOdbc.Dispose();
        //    }
        //    catch
        //    { throw; }
        //    finally
        //    { connOdbc.Close();}
        //    if (dtData.Rows.Count > 0) return dtData.Rows[0].ItemArray[0].ToString();
        //    else return "";
        //}

        //public DataSet GetFormDataP(string strPage)
        //{
        //    string strQuery="";
        //    OdbcCommand cmdOdbc = new OdbcCommand();
        //    OdbcDataAdapter daOdbc;
        //    DataTable dtTemp = new DataTable();
        //    DataSet dsData = new DataSet();

        //    try
        //    {
        //        if (connOdbc.State == ConnectionState.Closed)
        //            connOdbc.Open();
        //        switch (strPage)
        //        {
        //            //Insert Code Here...
        //        }
        //    }
        //    catch(Exception ex)
        //    { System.Windows.Forms.MessageBox.Show(ex.ToString()); }
        //    return dsData;
        //}

        public DataSet GetFormDataP(string strPage)
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
                    #region "Page1"
                    case "P2008Page1":
                        //strQuery= "SELECT PT_NAME, PT_REF_NO, " &
                        strQuery = "SELECT PT_NAME, PT_REF_NO, " +
                        "PT_REGISTER_NO, PT_NO_PARTNERS, PT_APPORTIONMENT, PT_COMPLIANCE, " +
                        "PT_REG_ADDRESS1 , PT_REG_ADDRESS2 ,PT_REG_ADDRESS3,PT_REG_POSTCODE,PT_REG_CITY,PT_REG_STATE," +
                        "PT_BUS_ADDRESS1 , PT_BUS_ADDRESS2 , PT_BUS_ADDRESS3 ,PT_BUS_POSTCODE,PT_BUS_CITY,PT_BUS_STATE," +
                        "PT_COR_ADDRESS1 , PT_COR_ADDRESS2 , PT_COR_ADDRESS3 ,PT_COR_POSTCODE, PT_COR_CITY,PT_COR_STATE," +
                        "PT_ACC_ADDRESS1 ,PT_ACC_ADDRESS2, PT_ACC_ADDRESS3,PT_ACC_POSTCODE, PT_ACC_CITY,PT_ACC_STATE," +
                        "PT_EMPLOYER_NO2,PT_PRE_PARTNER,PT_TEL1 + PT_TEL2,PT_MOBILE1 + PT_MOBILE2,PT_EMAIL " +
                        "FROM TAXP_PROFILE where PT_REF_NO=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer.ToString()));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P1_INPUT_TAX_PROFILE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                    #endregion
                    #region "Page2"
                    case "P2008Page2": //Pendapatan Perniagaan

                        strQuery = "SELECT [P_KEY] FROM [P_BALANCE_SHEET] WHERE [P_REF_NO]=? AND P_YA=? ";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        OdbcDataReader drP = cmdOdbc.ExecuteReader();
                        string strTemp = "";
                        if (drP.HasRows)
                        {
                            while (drP.Read())
                            { strTemp = drP.GetString(0); }
                        }
                        //drP.Dispose;
                        //cmdOdbc.Dispose();

                        strQuery = "SELECT PI_TYPE,PI_PIONEER_INCOME,PI_INCOME_LOSS,PI_P_BEBEFIT,PI_BAL_CHARGE,PI_BAL_ALLOWANCE,PI_7A_ALLOWANCE,PI_EXP_ALLOWANCE " +
                            "FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and [PI_SOURCENO]=1";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        // cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@KEY", strTemp));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P2_INPUTT_TAX_BUSINESS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();


                        strQuery = "SELECT PS_CODE FROM [TAXP_PSOURCE] WHERE  [PS_REF_NO]=? and PS_YA=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P2_SELECT_TAXP");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();





                        strQuery = "SELECT Top 1 PI_REF_NO,PI_INCOME_LOSS,PI_BAL_CHARGE,PI_BAL_ALLOWANCE,PI_7A_ALLOWANCE,PI_EXP_ALLOWANCE,PI_SOURCENO,PI_PIONEER_INCOME FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and [PI_SOURCENO]>1 and [PI_TYPE]<>'Yes'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@KEY", strTemp));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P2_INPUTT_TAX_BUSINESS1");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();




                        strQuery = "SELECT Top 1 PI_REF_NO,PI_INCOME_LOSS,PI_BAL_CHARGE,PI_BAL_ALLOWANCE,PI_7A_ALLOWANCE,PI_EXP_ALLOWANCE,PI_SOURCENO,PI_PIONEER_INCOME FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and [PI_SOURCENO]>1 and [PI_TYPE]<>'Yes'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@KEY", strTemp));
                        OdbcDataReader dr = cmdOdbc.ExecuteReader();
                        string strTemp1 = "";
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            { strTemp1 = dr.GetString(6); }
                        }

                        cmdOdbc.Dispose();

                        if (strTemp1 != "")
                        {
                        strQuery = "SELECT PS_CODE FROM [TAXP_PSOURCE] WHERE  [PS_REF_NO]=? and PS_YA=? and PS_SOURCENO=? ";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@Source", strTemp1));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P2_SELECT_TAXP1");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        }
                        break;

                    #endregion
                    #region "Page3"
                    case "P2008Page3": //Pendapatan Perniagaan
                        strQuery = "SELECT [P_KEY] FROM [P_BALANCE_SHEET] WHERE [P_REF_NO]=?  AND P_YA=? ";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        OdbcDataReader drP3 = cmdOdbc.ExecuteReader();
                        string strTempP3 = "";
                        if (drP3.HasRows)
                        {
                            while (drP3.Read())
                            { strTempP3 = drP3.GetString(0); }
                        }



                        ////empty A8-A14
                        strQuery = "SELECT PI_REF_NO,PI_INCOME_LOSS,PI_BAL_CHARGE,PI_BAL_ALLOWANCE,PI_7A_ALLOWANCE,PI_EXP_ALLOWANCE,PI_SOURCENO,PI_PIONEER_INCOME " +
                                 "FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and [PI_SOURCENO]=3 and [PI_TYPE]<>'Yes'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@KEY", strTempP3));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_INPUTT_TAX_BUSINESS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //empty
                        strQuery = "SELECT PS_CODE FROM [TAXP_PSOURCE] WHERE  [PS_REF_NO]=? and PS_YA=? and PS_SOURCENO=3 ";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_SELECT_TAXP");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();


                        ////>S3 A8-A14
                        strQuery = "SELECT PI_REF_NO,PI_INCOME_LOSS,PI_BAL_CHARGE,PI_BAL_ALLOWANCE,PI_7A_ALLOWANCE,PI_EXP_ALLOWANCE,PI_SOURCENO,PI_PIONEER_INCOME " +
                                 "FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and [PI_SOURCENO]>3 and [PI_TYPE]<>'Yes'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@KEY", strTempP3));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_INPUTT_TAX_BUSINESS1");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //>S3
                        strQuery = "SELECT PS_CODE FROM [TAXP_PSOURCE] WHERE  [PS_REF_NO]=? and PS_YA=? and PS_SOURCENO>3 ";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_SELECT_TAXP1");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();




                        break;
                    #endregion
                    #region "Page4"
                    case "P2008Page4":
                        strQuery = "SELECT P_DIVISIBLE_INT_DIS,P_DIVISIBLE_RENT_ROY_PRE,P_DIVISIBLE_NOTLISTED,P_DIVISIBLE_ADD_43,P_TAXDED_110," +
                         " P_TAXDED_132,P_TAXDED_133,P_DIVISIBLE_ADD_43 FROM [PARTNERSHIP_INCOME]  WHERE P_REF_NO=? AND P_YA=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_PARTNERSHIP_INCOME");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();



                        strQuery = "SELECT [P_KEY] FROM [P_BALANCE_SHEET] WHERE [P_REF_NO]=?  AND P_YA=? ";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        OdbcDataReader dr1 = cmdOdbc.ExecuteReader();
                        string strTemp2 = "";
                        if (dr1.HasRows)
                        {
                            while (dr1.Read())
                            { strTemp2 = dr1.GetString(0); }
                        }
                        //drP.Dispose;
                        cmdOdbc.Dispose();


                        strQuery = ("SELECT Top 5 PY_INCOME_TYPE,PY_PAYMENT_YEAR,PY_AMOUNT,PY_EPF FROM [PRECEDING_YEAR] WHERE [P_KEY] = ? order by [PY_DKEY]");
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        //cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PKey", strTemp2));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_PRECEDING_YEAR");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();



                        strQuery = "SELECT P_DIV_MALDIV,P_TAX_MALDIV FROM [PARTNERSHIP_INCOME]  WHERE P_REF_NO=? AND P_YA=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_PARTNERSHIP_INCOME1");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;
                    #endregion
                    #region "Page5"
                    case "P2008Page5":

                        strQuery = "SELECT P_DIVS_EXP_1,P_DIVS_EXP_3,P_DIVS_EXP_4,P_DIVS_EXP_5,P_DIVS_EXP_8 FROM [PARTNERSHIP_INCOME]  WHERE P_REF_NO=? AND P_YA=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_PARTNERSHIP_INCOME");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();



                        strQuery = "SELECT [P_KEY] FROM [P_BALANCE_SHEET] WHERE [P_REF_NO]=?  AND P_YA=? ";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        OdbcDataReader dr4 = cmdOdbc.ExecuteReader();
                        string strTemp3 = "";
                        if (dr4.HasRows)
                        {
                            while (dr4.Read())
                            { strTemp3 = dr4.GetString(0); }
                        }
                        //drP.Dispose;
                        cmdOdbc.Dispose();


                        strQuery = ("SELECT Top 10 PC_CL_CODE,PC_AMOUNT FROM [P_OTHER_CLAIMS] WHERE [P_KEY] = ? order by [PC_KEY]");
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@Key", strTemp3));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P4_P_OTHER_CLAIMS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                    #endregion
                    #region "Page6"
                    case "P2008Page6":

                        strQuery = "SELECT P_WITHTAX_107A_GROSS,P_WITHTAX_107A_TAX," +
                        " P_WITHTAX_109_GROSS, P_WITHTAX_109_TAX," +
                        " P_WITHTAX_109A_GROSS,P_WITHTAX_109A_TAX," +
                        " P_WITHTAX_109B_GROSS,P_WITHTAX_109B_TAX FROM [PARTNERSHIP_INCOME]  WHERE P_REF_NO=? AND P_YA=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P5_PARTNERSHIP_INCOME");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();


                        strQuery = "SELECT [P_KEY] FROM [P_BALANCE_SHEET] WHERE [P_REF_NO]=?  AND P_YA=? ";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        OdbcDataReader dr6 = cmdOdbc.ExecuteReader();
                        string strTemp4 = "";
                        if (dr6.HasRows)
                        {
                            while (dr6.Read())
                            { strTemp4 = dr6.GetString(0); }
                        }
                        else
                        {
                            strTemp4 = "0";
                        }
                        // dr4.Dispose;
                        cmdOdbc.Dispose();

                        strQuery = "SELECT P_CP30_ASAL,format(P_CP30_ASAL_DATE,'dd/mm/yyyy'), P_CP30_PINDAAN, format(P_CP30_PINDAAN_DATE,'dd/mm/yyyy') FROM [PARTNERSHIP_INCOME]  where [P_KEY]=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PKey", strTemp4));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P5_PARTNERSHIP_INCOME1");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                    #endregion
                    #region "Page7"
                    case "P2008Page7":

                        strQuery = "SELECT [PT_KEY] FROM [TAXP_PROFILE] WHERE [PT_REF_NO]=? ";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        OdbcDataReader dr5 = cmdOdbc.ExecuteReader();
                        string strTemp5 = "";
                        if (dr5.HasRows)
                        {
                            while (dr5.Read())
                            { strTemp5 = dr5.GetString(0); }
                        }
                        cmdOdbc.Dispose();

                        strQuery = "select PN_PREFIX As [PREFIX],PN_REF_NO AS [REFERENCE_NO]," +
                            "PN_NAME AS [NAME],PN_IDENTITY AS [IDENTITY],PN_COUNTRY AS [COUNTRY]," +
                            "PN_DATE_APPOINTNENT AS [DATE_APPOINTMENT]," +
                            "PN_DATE_CESSATION AS [DATE_CESSATION],PN_SHARE AS [SHARE], " +
                            "PN_BENEFIT_1 AS [BENEFIT_1],PN_BENEFIT_2 AS [BENEFIT_2],PN_BENEFIT_3 AS [BENEFIT_3] from TAXP_PARTNERS WHERE [PT_KEY] = ?  order by PN_KEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PartnerKey", strTemp5));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P6_TAXP_PARTNERS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();


                        break;
                    #endregion
                    #region "Page8"
                    case "P2008Page8":

                        strQuery = "SELECT [PS_CODE] FROM [TAXP_PSOURCE] where PS_REF_NO=? and PS_YA=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_TAXP_PSOURCE");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();


                        strQuery = "SELECT PPL_SALES,PPL_OP_STK,PPL_PURCHASES_COST,PPL_CLS_STK, PPL_COGS," +
                            "PPL_OTH_BSIN,PPL_OTH_IN_DIVIDEND,PPL_OTH_IN_INTEREST,PPL_OTH_IN_RENTAL_ROYALTY,PPL_OTH_IN_OTHER," +
                            "PPL_EXP_LOANINTEREST,PPL_EXP_SALARY,PPL_EXP_RENTAL,PPL_EXP_CONTRACT,PPL_EXP_COMMISSION," +
                            "PPL_BAD_DEBTS,PPL_TRAVEL,PPL_EXP_REPAIR_MAINT,PPL_EXP_PRO_ADV,PPL_OTHER_EXP, " +
                            "PPL_NET_PROFIT,PPL_DISALLOWED_EXP FROM [P_PROFIT_AND_LOSS] where P_REF_NO=? and P_YA=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_P_PROFIT_AND_LOSS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();


                        strQuery = "SELECT BS_LAND,BS_MACHINERY,BS_TRANSPORT,BS_OTH_FA," +
                                   "BS_INVESTMENT, BS_STOCK,BS_TRADE_DEBTORS,BS_OTH_DEBTORS,BS_CASH,BS_BANK,BS_OTH_CA," +
                                   "BS_LOAN, BS_TRADE_CR,BS_OTHER_CR,BS_OTH_LIAB,BS_LT_LIAB, " +
                                   "BS_CAPITALACCOUNT,BS_BROUGHT_FORWARD,BS_CY_PROFITLOSS,BS_DRAWING, BS_CARRIED_FORWARD " +
                                   "FROM [P_BALANCE_SHEET] where P_REF_NO=? and P_YA=?  order by BS_SOURCENO";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P7_P_PROFIT_AND_LOSS1");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                    #endregion
                    #region "Page9"
                    case "P2008Page9":
                        if (connOdbcB.State == ConnectionState.Closed)
                            connOdbcB.Open();
                        strQuery = "select ta_add_line1, ta_add_line2, ta_add_line3, ta_add_postcode, ta_add_city, ta_add_state, ta_tel_no, TA_MOBILE, ta_email from taxa_profile where ta_co_name=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbcB);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxagent", strTaxAgent));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P8_FIRM");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;
                    #endregion

                }
            }
            catch (Exception ex)
            { System.Windows.Forms.MessageBox.Show(ex.ToString()); }
            return dsData;
        }
    }
}

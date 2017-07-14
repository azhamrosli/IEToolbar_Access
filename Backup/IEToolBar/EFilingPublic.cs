using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Data;
using System.Text;
using Microsoft.Win32;

namespace IEToolBar
{
        public enum DSNType
        {
            User_DSN,
            System_DSN,
            File_DSN,
        }

        public class EFilingPublic
        {

            #region "Public Method"
            /// <summary>
            /// Upgrade the TaxOffice database.
            /// </summary>
            public void VersionUpgradeTaxOffice()
            {
                OdbcConnection  connOdbc = new OdbcConnection("Dsn=TAXOFFICE;Uid=;Pwd=;");
                OdbcCommand cmdOdbc;
                connOdbc.Open();
                DataTable dt = connOdbc.GetSchema("tables");
                if (dt.Select("table_name='EFILING_URL'").Length <= 0)
                {
                    string strQuery = "create table EFILING_URL (EF_URL memo not null, EF_PAGE_INDEX varchar(30) not null, EF_YA varchar(5) not null, EF_TYPE varchar(10) not null)";
                    cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    int intRA = cmdOdbc.ExecuteNonQuery();
                    connOdbc.Close();

                    string[] strURL = new string[4];
                    strURL[0] = "https://e.hasil.gov.my";
                    strURL[1] = "Q0000PageX";
                    strURL[2] = "0000";
                    strURL[3] = "QLINK";
                    if (InsertURLData(strURL) <= 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Data insertion for TAXcom E-Filing has been failed!");
                    }
                    cmdOdbc.Dispose();
                }
                connOdbc.Close();
            }

            /// <summary>
            /// Insert the url to the Efiling_URL Table
            /// </summary>
            /// <param name="arrData">The url data which is needed to insert into the database table.</param>
            /// <returns>Number of affected rows. Return -1 if error occurs</returns>
            private int InsertURLData(string[] arrData)
            {
                OdbcConnection connOdbc = new OdbcConnection("Dsn=TAXOFFICE;Uid=;Pwd=;");
                connOdbc.Open();
                DataTable dtData = new DataTable();
                dtData.Columns.Add("ef_url");
                dtData.Columns.Add("ef_page_index");
                dtData.Columns.Add("ef_ya");
                dtData.Columns.Add("ef_type");

                DataRow dr;
                dr = dtData.NewRow();
                dr["ef_url"] = arrData[0];
                dr["ef_page_index"] = arrData[1];
                dr["ef_ya"] = arrData[2];
                dr["ef_type"] = arrData[3];
                dtData.Rows.Add(dr);
                
                try
                {
                    string strQuery="insert into efiling_url(ef_url, ef_page_index, ef_ya, ef_type) values(?,?,?,?)";
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

            /// <summary>
            /// Get the url from database table efiling_url by the specific page index
            /// </summary>
            /// <param name="strPageIndex">The page index of the url.</param>
            /// <returns>The selected url.</returns>
            public string GetURL(string strPageIndex)
            {
                DataTable dtData = new DataTable();
                OdbcConnection connOdbc = new OdbcConnection("Dsn=TAXOFFICE;Uid=;Pwd=;");
                connOdbc.Open();
                try
                {
                    OdbcCommand cmdOdbc;
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

            /// <summary>
            /// Execute Insert/ Update/ Delete query according to the execution mode.
            /// </summary>
            /// <param name="strData">Data require by the query</param>
            /// <param name="strOprCode">Execution mode</param>
            /// <returns>Number of affected rows</returns>
            public int Execute(string[] strData, string strOprCode)
            {
                OdbcConnection connOdbc = new OdbcConnection("Dsn=TAXOFFICE;Uid=;Pwd=;");
                OdbcCommand cmdOdbc = null;
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
                    }
                int intRE = 0;
                try
                {intRE = cmdOdbc.ExecuteNonQuery();}
                catch
                { throw; }
                finally
                { connOdbc.Close(); }
                return intRE;
            }

            /// <summary>
            /// Determines whether the specific DSN is exist in ODBC Data Sources.
            /// </summary>
            /// <param name="strDSN"> Name of the DSN.</param>
            /// <param name="enuType">The specific type of the DSN.</param>
            /// <returns>True if the specific DSN is exist.</returns>
            /// 
            public Boolean isExist(String strDSN, DSNType enuType)
            {
                RegistryKey rk = null;
                Boolean isExist = false;
                try
                {
                    rk = SetDSNType(enuType);
                    {
                        if (isRegExist(rk.Name + "\\SOFTWARE\\ODBC\\ODBC.INI\\ODBC Data Sources\\",
                            strDSN))
                            isExist = true;

                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
                return isExist;
            }

            #endregion

            #region "Private Method"

            /// <summary>
            /// Determines whether the valueName is exist in the specific Registry Key.
            /// </summary>
            /// <param name="strRegKey">The specific Registry Key.</param>
            /// <param name="strValueName">The valueName of the specific Registry Key.</param>
            /// <returns>Return true if the specific Registry Key and its valueName is exist.</returns>
            private Boolean isRegExist(String strRegKey, String strValueName)
            {

                Boolean isRegExist = false;
                try
                {
                    if (!(Registry.GetValue(strRegKey, strValueName, "").Equals(null)||
                        Registry.GetValue(strRegKey, strValueName, "").Equals("")))
                    {
                        isRegExist = true;
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }

                return isRegExist;
            }

            /// <summary>
            /// Determines whether the specific Registry Key is exist.
            /// </summary>
            /// <param name="strRegKey">The specific Registry Key.</param>
            /// <returns>Return true if the specific Registry Key is exist.</returns>
            private Boolean isRegExist(String strRegKey)
            {

                Boolean isRegExist = false;
                try
                {
                    if (!(Registry.GetValue(strRegKey, "", "").Equals(null)))
                    {
                        isRegExist = true;
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
                return isRegExist;
            }

            /// <summary>
            /// Sets the specific location to the Registry Key according to the type of DSN.
            /// </summary>
            /// <param name="enuType">The type of the DSN.</param>
            /// <returns>Return the modified Registry Key.</returns>
            private RegistryKey 
                SetDSNType(DSNType enuType)
            {

                RegistryKey rk = null;
                try
                {
                    switch (enuType)
                    {
                        case DSNType.System_DSN:
                            rk = Registry.LocalMachine;
                            break;
                        case DSNType.User_DSN:
                            rk = Registry.CurrentUser;
                            break;

                        default: rk = Registry.CurrentUser;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
                return rk;
            }

            #endregion

        }
}

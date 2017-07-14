using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;

namespace IEToolBar
{
    public class EFilingDALP2010: EFilingDALP
    {
        public EFilingDALP2010()
        {
        }

        public EFilingDALP2010(string strTaxPayer, string strYA, string strTaxAgent)
        {   
            this.strTaxPayer = strTaxPayer;
            this.strYA = strYA;
            this.strTaxAgent = strTaxAgent;
        }

        public DataSet GetFormDataP2010(string strPage)
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
                    case "P2010Page1":
                        //strQuery= "SELECT PT_NAME, PT_REF_NO, " &
                        strQuery = "SELECT PT_NAME, PT_REF_NO, " +
                        "PT_REGISTER_NO, PT_NO_PARTNERS, PT_APPORTIONMENT, PT_COMPLIANCE, " +
                        "PT_REG_ADDRESS1 , PT_REG_ADDRESS2 ,PT_REG_ADDRESS3,PT_REG_POSTCODE,PT_REG_CITY,PT_REG_STATE," +
                        "PT_BUS_ADDRESS1 , PT_BUS_ADDRESS2 , PT_BUS_ADDRESS3 ,PT_BUS_POSTCODE,PT_BUS_CITY,PT_BUS_STATE," +
                        "PT_COR_ADDRESS1 , PT_COR_ADDRESS2 , PT_COR_ADDRESS3 ,PT_COR_POSTCODE, PT_COR_CITY,PT_COR_STATE," +
                        "PT_ACC_ADDRESS1 ,PT_ACC_ADDRESS2, PT_ACC_ADDRESS3,PT_ACC_POSTCODE, PT_ACC_CITY,PT_ACC_STATE," +
                        "PT_EMPLOYER_NO2,PT_PRE_PARTNER,PT_TEL1 + PT_TEL2,PT_MOBILE1 + PT_MOBILE2,PT_EMAIL, PT_BWA " +
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
                    case "P2010Page2": //Pendapatan Perniagaan

                        strQuery = "SELECT [P_KEY] FROM [P_BALANCE_SHEET] WHERE [P_REF_NO]=? AND [P_YA]=? ";
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
                            "FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and [PI_TYPE]='Yes'";
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


                        strQuery = "SELECT PS_CODE FROM [TAXP_PSOURCE] WHERE [PS_REF_NO]=? and [PS_YA]=? ORDER BY [PS_SOURCENO]";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P2_SELECT_TAXP");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();


                        strQuery = "SELECT Top 1 PI_REF_NO,PI_INCOME_LOSS,PI_BAL_CHARGE,PI_BAL_ALLOWANCE,PI_7A_ALLOWANCE,PI_EXP_ALLOWANCE,PI_SOURCENO,PI_PIONEER_INCOME FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and [PI_REF_NO]=? and [PI_TYPE]<>'Yes'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@KEY", strTemp));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P2_INPUTT_TAX_BUSINESS1");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();


                        strQuery = "SELECT Top 1 PI_REF_NO,PI_INCOME_LOSS,PI_BAL_CHARGE,PI_BAL_ALLOWANCE,PI_7A_ALLOWANCE,PI_EXP_ALLOWANCE,PI_SOURCENO,PI_PIONEER_INCOME FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and [PI_REF_NO]<>? and [PI_TYPE]<>'Yes'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@KEY", strTemp));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P2_INPUTT_TAX_BUSINESS2");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();


                        strQuery = "SELECT Top 1 PI_REF_NO,PI_INCOME_LOSS,PI_BAL_CHARGE,PI_BAL_ALLOWANCE,PI_7A_ALLOWANCE,PI_EXP_ALLOWANCE,PI_SOURCENO,PI_PIONEER_INCOME FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and [PI_REF_NO]=? and [PI_TYPE]<>'Yes'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@KEY", strTemp));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        OdbcDataReader dr = cmdOdbc.ExecuteReader();
                        string strTemp10 = "";
                        string strTemp11 = "";
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            { 
                                strTemp10 = dr.GetString(6);
                                strTemp11 = dr.GetString(0); 
                            }
                        }

                        cmdOdbc.Dispose();

                        if (strTemp10 != "")
                        {
                            strQuery = "SELECT PS_CODE FROM [TAXP_PSOURCE] WHERE  [PS_REF_NO]=? and PS_YA=? and PS_SOURCENO=? ";
                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@Source", strTemp10));
                            daOdbc = new OdbcDataAdapter(cmdOdbc);
                            dtTemp = new DataTable("P2_SELECT_TAXP1");
                            daOdbc.Fill(dtTemp);
                            dsData.Tables.Add(dtTemp);
                            daOdbc.Dispose();
                            cmdOdbc.Dispose();
                        }

                        strQuery = "SELECT Top 1 PI_REF_NO,PI_INCOME_LOSS,PI_BAL_CHARGE,PI_BAL_ALLOWANCE,PI_7A_ALLOWANCE,PI_EXP_ALLOWANCE,PI_SOURCENO,PI_PIONEER_INCOME FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and [PI_REF_NO]<>? and [PI_TYPE]<>'Yes'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@KEY", strTemp));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                        OdbcDataReader dr2 = cmdOdbc.ExecuteReader();
                        string strTemp12 = "";
                        string strTemp13 = "";
                        if (dr2.HasRows)
                        {
                            while (dr2.Read())
                            { 
                              strTemp12 = dr2.GetString(6);
                              strTemp13 = dr2.GetString(0); 
                            }
                        }

                        cmdOdbc.Dispose();

                        if (strTemp12 != "")
                        {
                            strQuery = "SELECT PS_CODE FROM [TAXP_PSOURCE] WHERE  [PS_REF_NO]=? and PS_YA=? and PS_SOURCENO=? ";
                            cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                            cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTemp13));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                            cmdOdbc.Parameters.Add(new OdbcParameter("@Source", strTemp12));
                            daOdbc = new OdbcDataAdapter(cmdOdbc);
                            dtTemp = new DataTable("P2_SELECT_TAXP2");
                            daOdbc.Fill(dtTemp);
                            dsData.Tables.Add(dtTemp);
                            daOdbc.Dispose();
                            cmdOdbc.Dispose();
                        }
                        break;
                        #endregion
                    #region "Page3"
                    case "P2010Page3": //Pendapatan Perniagaan
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
                                 "FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and [PI_SOURCENO]>=3 and [PI_TYPE]<>'Yes'";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@KEY", strTempP3));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P3_INPUTT_TAX_BUSINESS1");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();

                        //>S3
                        strQuery = "SELECT PS_CODE FROM [TAXP_PSOURCE] WHERE  [PS_REF_NO]=? and PS_YA=? and PS_SOURCENO>=3 ";
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
                    #region "Comment it for next project"
                    //#region "Page2"
                    //case "P2009Page2": //Pendapatan Perniagaan


                    //    strQuery = "SELECT [P_KEY] FROM [P_BALANCE_SHEET] WHERE [P_REF_NO]=? AND P_YA=?";
                    //    cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    //    cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                    //    cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                    //    OdbcDataReader drP = cmdOdbc.ExecuteReader();
                    //    string strTemp = "";
                    //    if (drP.HasRows)
                    //    {
                    //        while (drP.Read())
                    //        { strTemp = drP.GetString(0);}

                    //    }
                    //    //drP.Dispose;
                    //    //cmdOdbc.Dispose();

                    //    strQuery = "SELECT Top 1 PI_REF_NO,PI_INCOME_LOSS, PI_P_BEBEFIT, PI_BAL_CHARGE,PI_BAL_ALLOWANCE,PI_7A_ALLOWANCE,PI_EXP_ALLOWANCE,PI_SOURCENO,PI_PIONEER_INCOME FROM [P_BUSINESS_INCOME] WHERE [P_KEY]=? and [PI_TYPE]='Yes'";
                    //    cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    //    //cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                    //    // cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                    //    cmdOdbc.Parameters.Add(new OdbcParameter("@KEY", strTemp));
                    //    daOdbc = new OdbcDataAdapter(cmdOdbc);
                    //    dtTemp = new DataTable("P2_INPUTT_TAX_BUSINESS");
                    //    daOdbc.Fill(dtTemp);
                    //    dsData.Tables.Add(dtTemp);
                    //    daOdbc.Dispose();
                    //    cmdOdbc.Dispose();

                    //    strQuery = "SELECT TOP 1 PI_SOURCENO FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and [PI_REF_NO] = (SELECT PI_REF_NO FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and [PI_TYPE]='Yes')";
                    //    cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    //    cmdOdbc.Parameters.Add(new OdbcParameter("@KEY", strTemp));
                    //    cmdOdbc.Parameters.Add(new OdbcParameter("@KEY1", strTemp));
                    //    daOdbc = new OdbcDataAdapter(cmdOdbc);
                    //    OdbcDataReader dr = cmdOdbc.ExecuteReader();
                    //    string strTemp6 = "";
                    //    if (dr.HasRows)
                    //    {
                    //        while (dr.Read())
                    //        { strTemp6 = dr.GetString(0); }
                    //    }
                    //    dr.Close();
                    //    cmdOdbc.Dispose();

                    //    if (strTemp6 != "")
                    //    {
                    //        strQuery = "SELECT PS_CODE FROM [TAXP_PSOURCE] WHERE [PS_REF_NO]=? and [PS_YA]=? AND [PS_SOURCENO]=?";
                    //        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    //        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                    //        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                    //        cmdOdbc.Parameters.Add(new OdbcParameter("@Source", strTemp6));
                    //        daOdbc = new OdbcDataAdapter(cmdOdbc);
                    //        dtTemp = new DataTable("P2_SELECT_TAXP");
                    //        daOdbc.Fill(dtTemp);
                    //        dsData.Tables.Add(dtTemp);
                    //        daOdbc.Dispose();
                    //        cmdOdbc.Dispose();
                    //    }

                    //    strQuery = "SELECT TOP 1 PI_REF_NO,PI_INCOME_LOSS,PI_BAL_CHARGE,PI_BAL_ALLOWANCE,PI_7A_ALLOWANCE,PI_EXP_ALLOWANCE,PI_SOURCENO,PI_PIONEER_INCOME FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and PI_REF_NO not in (SELECT PI_REF_NO FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and [PI_TYPE]='Yes') ORDER BY [PI_REF_NO], [PI_SOURCENO]";
                    //    cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    //    cmdOdbc.Parameters.Add(new OdbcParameter("@KEY", strTemp));
                    //    cmdOdbc.Parameters.Add(new OdbcParameter("@KEY1", strTemp));
                    //    daOdbc = new OdbcDataAdapter(cmdOdbc);
                    //    dtTemp = new DataTable("P2_INPUTT_TAX_BUSINESS1");
                    //    daOdbc.Fill(dtTemp);
                    //    dsData.Tables.Add(dtTemp);
                    //    daOdbc.Dispose();
                    //    cmdOdbc.Dispose();

                    //    strQuery = "SELECT Top 1 PI_SOURCENO, PI_REF_NO FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and PI_REF_NO not in (SELECT PI_REF_NO FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and [PI_TYPE]='Yes') ORDER BY [PI_REF_NO], [PI_SOURCENO]";
                    //    cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    //    cmdOdbc.Parameters.Add(new OdbcParameter("@KEY", strTemp));
                    //    cmdOdbc.Parameters.Add(new OdbcParameter("@KEY1", strTemp));
                    //    OdbcDataReader dr2 = cmdOdbc.ExecuteReader();
                    //    string strTemp1 = "";
                    //    string strTemp7 = "";
                    //    if (dr2.HasRows)
                    //    {
                    //        while (dr2.Read())
                    //        { 
                    //            strTemp1 = dr2.GetString(0);
                    //            strTemp7 = dr2.GetString(1);
                    //        }
                    //    }
                    //    dr2.Close();
                    //    cmdOdbc.Dispose();

                    //    if (strTemp1 != "" && strTemp7 != "")
                    //    {
                    //        strQuery = "SELECT PS_CODE FROM [TAXP_PSOURCE] WHERE [PS_REF_NO]=? and PS_YA=? and PS_SOURCENO=? ";
                    //        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    //        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTemp7));
                    //        cmdOdbc.Parameters.Add(new OdbcParameter("@ya1", strYA));
                    //        cmdOdbc.Parameters.Add(new OdbcParameter("@Source", strTemp1));
                    //        daOdbc = new OdbcDataAdapter(cmdOdbc);
                    //        dtTemp = new DataTable("P2_SELECT_TAXP1");
                    //        daOdbc.Fill(dtTemp);
                    //        dsData.Tables.Add(dtTemp);
                    //        daOdbc.Dispose();
                    //        cmdOdbc.Dispose();
                    //    }
                    //    break;

                    //#endregion
                    //#region "Page3"
                    //case "P2009Page3": //Pendapatan Perniagaan
                    //    strQuery = "SELECT [P_KEY] FROM [P_BALANCE_SHEET] WHERE [P_REF_NO]=? AND P_YA=?";
                    //    cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    //    cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                    //    cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                    //    OdbcDataReader drP3 = cmdOdbc.ExecuteReader();
                    //    string strTempP3 = "";
                    //    if (drP3.HasRows)
                    //    {
                    //        while (drP3.Read())
                    //        { strTempP3 = drP3.GetString(0); }
                    //    }


                    //    ////empty A8-A14
                    //    strQuery = "SELECT PI_REF_NO,PI_INCOME_LOSS, PI_P_BEBEFIT, PI_BAL_CHARGE,PI_BAL_ALLOWANCE,PI_7A_ALLOWANCE,PI_EXP_ALLOWANCE,PI_SOURCENO,PI_PIONEER_INCOME FROM [P_BUSINESS_INCOME] WHERE [P_KEY]=? and [PI_REF_NO]=" +
                    //        "(SELECT [PI_REF_NO] FROM [P_BUSINESS_INCOME] WHERE [P_KEY]=? and [PI_TYPE]='Yes') and [PI_TYPE]='' ORDER BY [PI_REF_NO], [PI_SOURCENO]";
                    //    cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    //    cmdOdbc.Parameters.Add(new OdbcParameter("@KEY", strTempP3));
                    //    cmdOdbc.Parameters.Add(new OdbcParameter("@KEY1", strTempP3));
                    //    daOdbc = new OdbcDataAdapter(cmdOdbc);
                    //    dtTemp = new DataTable("P3_INPUTT_TAX_BUSINESS");
                    //    daOdbc.Fill(dtTemp);
                    //    dsData.Tables.Add(dtTemp);
                    //    daOdbc.Dispose();
                    //    cmdOdbc.Dispose();


                    //    strQuery = "SELECT PI_SOURCENO FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and PI_REF_NO not in (SELECT PI_REF_NO FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and [PI_TYPE]='Yes') ORDER BY [PI_REF_NO], [PI_SOURCENO]";
                    //    cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    //    cmdOdbc.Parameters.Add(new OdbcParameter("@KEY", strTempP3));
                    //    cmdOdbc.Parameters.Add(new OdbcParameter("@KEY1", strTempP3));
                    //    OdbcDataReader dr3 = cmdOdbc.ExecuteReader();
                    //    string strTemp8 = "";

                    //    if (dr3.HasRows)
                    //    {
                    //        while (dr3.Read())
                    //        {
                    //            strTemp8 = dr3.GetString(0);
                    //        }
                    //    }
                    //    dr3.Close();
                    //    cmdOdbc.Dispose();


                    //    //empty
                    //    if (strTemp8 != "")
                    //    {
                    //        strQuery = "SELECT PS_CODE FROM [TAXP_PSOURCE] WHERE [PS_REF_NO]=? and PS_YA=? and [PS_SOURCENO]=?";
                    //        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    //        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                    //        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                    //        cmdOdbc.Parameters.Add(new OdbcParameter("@sourceno", strTemp8));
                    //        daOdbc = new OdbcDataAdapter(cmdOdbc);
                    //        dtTemp = new DataTable("P3_SELECT_TAXP");
                    //        daOdbc.Fill(dtTemp);
                    //        dsData.Tables.Add(dtTemp);
                    //        daOdbc.Dispose();
                    //        cmdOdbc.Dispose();
                    //    }


                    //    ////>S3 A8-A14
                    //    strQuery = "SELECT PI_REF_NO,PI_INCOME_LOSS,PI_BAL_CHARGE,PI_BAL_ALLOWANCE,PI_7A_ALLOWANCE,PI_EXP_ALLOWANCE,PI_SOURCENO,PI_PIONEER_INCOME " +
                    //             "FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and [PI_REF_NO] not in (SELECT [PI_REF_NO] FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and [PI_TYPE]='Yes') " +
                    //             "ORDER BY [PI_REF_NO], [PI_SOURCENO]";
                    //    cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    //    cmdOdbc.Parameters.Add(new OdbcParameter("@KEY", strTempP3));
                    //    cmdOdbc.Parameters.Add(new OdbcParameter("@KEY1", strTempP3));
                    //    daOdbc = new OdbcDataAdapter(cmdOdbc);
                    //    dtTemp = new DataTable("P3_INPUTT_TAX_BUSINESS1");
                    //    daOdbc.Fill(dtTemp);
                    //    dsData.Tables.Add(dtTemp);
                    //    daOdbc.Dispose();
                    //    cmdOdbc.Dispose();


                    //    strQuery = "SELECT PI_SOURCENO, PI_REF_NO FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and PI_REF_NO not in (SELECT PI_REF_NO FROM [P_BUSINESS_INCOME] WHERE [P_KEY] = ? and [PI_TYPE]='Yes') ORDER BY [PI_REF_NO], [PI_SOURCENO]";
                    //    cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    //    cmdOdbc.Parameters.Add(new OdbcParameter("@KEY", strTempP3));
                    //    cmdOdbc.Parameters.Add(new OdbcParameter("@KEY1", strTempP3));
                    //    OdbcDataReader dr4 = cmdOdbc.ExecuteReader();
                    //    string strTemp9 = "";
                    //    string strTemp10 = "";
                    //    if (dr4.HasRows)
                    //    {
                    //        while (dr4.Read())
                    //        {
                    //            strTemp9 = dr4.GetString(0);
                    //            strTemp10 = dr4.GetString(1);
                    //        }
                    //    }
                    //    dr4.Close();
                    //    cmdOdbc.Dispose();

                    //    //>S3
                    //    if (strTemp9 != "" && strTemp10 != "")
                    //    {
                    //        strQuery = "SELECT PS_CODE FROM [TAXP_PSOURCE] WHERE [PS_REF_NO]=? and PS_YA=? and PS_SOURCENO=?";
                    //        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                    //        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTemp10));
                    //        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                    //        cmdOdbc.Parameters.Add(new OdbcParameter("@source", strTemp9));
                    //        daOdbc = new OdbcDataAdapter(cmdOdbc);
                    //        dtTemp = new DataTable("P3_SELECT_TAXP1");
                    //        daOdbc.Fill(dtTemp);
                    //        dsData.Tables.Add(dtTemp);
                    //        daOdbc.Dispose();
                    //        cmdOdbc.Dispose();
                    //    }
                    //    break;
                    //#endregion
                    #endregion
                    #region "Page4"
                    case "P2010Page4":
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


                        strQuery = ("SELECT Top 10 PY_INCOME_TYPE,PY_PAYMENT_YEAR,PY_AMOUNT,PY_EPF FROM [PRECEDING_YEAR] WHERE [P_KEY] = ? order by [PY_DKEY]");
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
                    case "P2010Page5":

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
                        OdbcDataReader dr8 = cmdOdbc.ExecuteReader();
                        string strTemp3 = "";
                        if (dr8.HasRows)
                        {
                            while (dr8.Read())
                            { strTemp3 = dr8.GetString(0); }
                        }
                        dr8.Close();
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
                    case "P2010Page6":

                        strQuery = "SELECT P_WITHTAX_107A_GROSS,P_WITHTAX_107A_TAX," +
                        " P_WITHTAX_109_GROSS, P_WITHTAX_109_TAX," +
                        " P_WITHTAX_109A_GROSS,P_WITHTAX_109A_TAX," +
                        " P_WITHTAX_109B_GROSS,P_WITHTAX_109B_TAX," +
                        " P_WITHTAX_109F_GROSS,P_WITHTAX_109F_TAX" +
                        " FROM [PARTNERSHIP_INCOME]  WHERE P_REF_NO=? AND P_YA=?";
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
                    case "P2010Page7":

                        strQuery = "SELECT [PT_KEY] FROM [TAXP_PROFILE] WHERE [PT_REF_NO]=? ";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        OdbcDataReader dr5 = cmdOdbc.ExecuteReader();
                        string strTemp5 = "0";
                        if (dr5.HasRows)
                        {
                            while (dr5.Read())
                            { strTemp5 = dr5.GetString(0); }
                        }
                        cmdOdbc.Dispose();
                        dr5.Close();

                        strQuery = "SELECT [P_KEY] FROM [PARTNERSHIP_INCOME] WHERE [P_REF_NO]=? AND [P_YA]=?";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                        OdbcDataReader dr9 = cmdOdbc.ExecuteReader();
                        string strTemp9 = "0";
                        if (dr9.HasRows)
                        {
                            while (dr9.Read())
                            { strTemp9 = dr9.GetString(0); }
                        }
                        cmdOdbc.Dispose();
                        dr9.Close();

                        strQuery = "select PN_PREFIX As [PREFIX],PN_REF_NO AS [REFERENCE_NO]," +
                            "PN_NAME AS [NAME],PN_IDENTITY AS [IDENTITY],PN_COUNTRY AS [COUNTRY]," +
                            "PN_DATE_APPOINTNENT AS [DATE_APPOINTMENT]," +
                            "PN_DATE_CESSATION AS [DATE_CESSATION],PN_SHARE AS [SHARE], " +
                            "PN_BENEFIT_1 AS [BENEFIT_1],PN_BENEFIT_2 AS [BENEFIT_2],PN_BENEFIT_3 AS [BENEFIT_3]," +
                            "CP_B_ADJ_INCOMELOSS AS [ADJUSTED_AMOUNT], CP_B_BAL_CHARGE AS [BALANCING_CHARGE]," +
                            "CP_B_BAL_ALLOWANCE AS [BALANCING_ALLOWANCE], CP_B_7A_ALLOWANCE AS [SCHEDULE_7A]," +
                            "CP_B_EXP_ALLOWANCE AS [EXPORT_ALLOWANCE] " +
                            "from CP30 a INNER JOIN TAXP_PARTNERS b on a.CP_REF_NO = b.PN_REF_NO " +
                            "WHERE [PT_KEY] = ? AND [P_KEY] = ? order by PN_KEY";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@PartnerKey", strTemp5));
                        cmdOdbc.Parameters.Add(new OdbcParameter("@Key", strTemp9));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P6_TAXP_PARTNERS");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();


                        strQuery = "SELECT [PT_PRE_PARTNER] FROM [TAXP_PROFILE] WHERE [PT_REF_NO]=? ";
                        cmdOdbc = new OdbcCommand(strQuery, connOdbc);
                        cmdOdbc.Parameters.Add(new OdbcParameter("@taxpayer", strTaxPayer));
                        daOdbc = new OdbcDataAdapter(cmdOdbc);
                        dtTemp = new DataTable("P6_TAXP_PREPARTNER");
                        daOdbc.Fill(dtTemp);
                        dsData.Tables.Add(dtTemp);
                        daOdbc.Dispose();
                        cmdOdbc.Dispose();
                        break;

                    #endregion
                    #region "Page8"
                    case "P2010Page8":

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
                    case "P2010Page9":
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

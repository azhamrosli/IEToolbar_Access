using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Odbc;

namespace IEToolBar
{
    class EFilingVersionUpgrade
    {
        OdbcConnection connOdbc = new OdbcConnection();
        OdbcConnection connOdbcP = new OdbcConnection();
        OdbcCommand cmdOdbc= new OdbcCommand();
        string strYA = "";
        string strFormType = "";

        #region "Ctors"
        public EFilingVersionUpgrade()
        {

        }

        public EFilingVersionUpgrade(string strFormType, string strYA)
        {
            this.strFormType = strFormType;
            this.strYA = strYA;
            switch (strFormType)
            {
                case "C": case "R":case"CP204":case"CP204A":
                    this.connOdbc = new OdbcConnection("Dsn=TAXSYSTEM;Uid=;Pwd=;");
                    break;
                case "B": case "BE": case "M":
                    this.connOdbc = new OdbcConnection("Dsn=TAXCOM_B;Uid=;Pwd=;");
                    break;
                case "P":
                    this.connOdbcP  = new OdbcConnection("Dsn=TAXCOM_P;Uid=;Pwd=;");
                    this.connOdbc = new OdbcConnection("Dsn=TAXCOM_B;Uid=;Pwd=;");
                    break;
            }
            
        }
        #endregion

        #region "Define new url here"
        private String[] GetEFilingURL(string strType)
        {
            String[] strURL = null;
            String[] strCURL = new String[19];
            String[] strRURL = new String[2];
            //PANYW CP204
            String[] strCP204URL = new String[1];
            //PANYW CP204 END
            //NGOHCS CP204A
            String[] strCP204AURL = new String[1];
            //NGOHCS CP204A END


            //String[] strRURL = new String[2];
            //DataTable dt = new DataTable("EFILING_URL");
            switch (strYA)
            {
                case "2008":
                    
                    break;
                case "2009":
                    String[] strBEURL = new String[9];
                    String[] strBURL = new String[12];
                    String[] strMURL = new String[11];
                    String[] strPURL = new String[10];
                    if (strType == "C")
                    {
                        strCURL[0] = "https://ef.hasil.gov.my/ec2009/mak_syarikat.aspx";
                        strCURL[1] = "https://ef.hasil.gov.my/ec2009/mak_pengarah.aspx";
                        strCURL[2] = "https://ef.hasil.gov.my/ec2009/mak_syer.aspx";
                        strCURL[3] = "https://ef.hasil.gov.my/ec2009/mak_wang.aspx";
                        strCURL[4] = "https://ef.hasil.gov.my/ec2009/pen_kanun.aspx";
                        strCURL[5] = "https://ef.hasil.gov.my/ec2009/pen_pindah.aspx";
                        strCURL[6] = "https://ef.hasil.gov.my/ec2009/pen_tahun.aspx";
                        strCURL[7] = "https://ef.hasil.gov.my/ec2009/tun_elaun.aspx";
                        strCURL[8] = "https://ef.hasil.gov.my/ec2009/tun_kerugian.aspx";
                        strCURL[9] = "https://ef.hasil.gov.my/ec2009/tun_insentif.aspx";
                        strCURL[10] = "https://ef.hasil.gov.my/ec2009/per_khas.aspx";
                        strCURL[11] = "https://ef.hasil.gov.my/ec2009/lain_akaun.aspx";
                        strCURL[12] = "https://ef.hasil.gov.my/ec2009/lain_cukai.aspx";
                        strCURL[13] = "https://ef.hasil.gov.my/ec2009/lain_transaksi.aspx";
                        strCURL[14] = "https://ef.hasil.gov.my/ec2009/lain_makl.aspx";
                        strCURL[15] = "https://ef.hasil.gov.my/ec2009/cukai_dibayar.aspx";
                        strCURL[16] = "https://ef.hasil.gov.my/ec2009/juruaudit.aspx";
                        strCURL[17] = "https://ef.hasil.gov.my/ec2009/firma.aspx";
                        strCURL[18] = "https://ef.hasil.gov.my/ec2009/rkt_rks.aspx";
                        strURL = strCURL;
                    }

                    if (strType == "R")
                    {
                        strRURL[0] = "https://ef.hasil.gov.my/er2009/dividensyrkt.aspx";
                        strRURL[1] = "https://ef.hasil.gov.my/er2009/penyata.aspx";
                        strURL = strRURL;
                    }

                    if (strType == "B")
                    {
                        strBURL[0] = "https://ef.hasil.gov.my/eBE2010/Mak_ind.aspx";
                        strBURL[1] = "https://ef.hasil.gov.my/eBE2010/mak_pasangan.aspx";
                        strBURL[2] = "https://ef.hasil.gov.my/eBE2010/pendapatan.aspx";
                        strBURL[3] = "https://ef.hasil.gov.my/eBE2010/pend_belakang.aspx";
                        strBURL[4] = "https://ef.hasil.gov.my/eBE2010/pelepasan.aspx";
                        strBURL[5] = "https://ef.hasil.gov.my/eBE2010/rebat.aspx";
                        strBURL[6] = "https://ef.hasil.gov.my/eBE2010/perniagaan.aspx";
                        strBURL[7] = "https://ef.hasil.gov.my/eBE2010/khas.aspx";
                        strBURL[8] = "https://ef.hasil.gov.my/eBE2010/kewangan.aspx";
                        strBURL[9] = "https://ef.hasil.gov.my/eBE2010/mak_pentadbir.aspx";
                        strBURL[10] = "https://ef.hasil.gov.my/eBE2010/rumusan.aspx";
                        strBURL[11] = "https://ef.hasil.gov.my/eBE2010/HK3.aspx";
                        strURL = strBURL;
                    }

                    if (strType == "BE")
                    {
                        strBEURL[0] = "https://ef.hasil.gov.my/eBE2010/Mak_ind.aspx";
                        strBEURL[1] = "https://ef.hasil.gov.my/eBE2010/mak_pasangan.aspx";
                        strBEURL[2] = "https://ef.hasil.gov.my/eBE2010/pendapatan.aspx";
                        strBEURL[3] = "https://ef.hasil.gov.my/eBE2010/pend_belakang.aspx";
                        strBEURL[4] = "https://ef.hasil.gov.my/eBE2010/pelepasan.aspx";
                        strBEURL[5] = "https://ef.hasil.gov.my/eBE2010/rebat.aspx";
                        strBEURL[6] = "https://ef.hasil.gov.my/eBE2010/mak_pentadbir.aspx";
                        strBEURL[7] = "https://ef.hasil.gov.my/eBE2010/rumusan.aspx";
                        strBEURL[8] = "https://ef.hasil.gov.my/eBE2010/HK3.aspx";
                        strURL = strBEURL;
                    }

                    if (strType == "M")
                    {
                        strMURL[0] = "https://ef.hasil.gov.my/eM2010/Mak_ind.aspx";
                        strMURL[1] = "https://ef.hasil.gov.my/eM2010/mak_pasangan.aspx";
                        strMURL[2] = "https://ef.hasil.gov.my/eM2010/pendapatan.aspx";
                        strMURL[3] = "https://ef.hasil.gov.my/eM2010/pend_belakang.aspx";
                        strMURL[4] = "https://ef.hasil.gov.my/eM2010/rebat.aspx";
                        strMURL[5] = "https://ef.hasil.gov.my/eM2010/perniagaan.aspx";
                        strMURL[6] = "https://ef.hasil.gov.my/eM2010/khas.aspx";
                        strMURL[7] = "https://ef.hasil.gov.my/eM2010/kewangan.aspx";
                        strMURL[8] = "https://ef.hasil.gov.my/eM2010/mak_pentadbir.aspx";
                        strMURL[9] = "https://ef.hasil.gov.my/eM2010/rumusan.aspx";
                        strMURL[10] = "https://ef.hasil.gov.my/eM2010/HK3.aspx";
                        strURL = strMURL;
                    }

                    if (strType == "P")
                    {
                        strPURL[0] = "https://ef.hasil.gov.my/eP2010/Mak_asas.aspx";
                        strPURL[1] = "https://ef.hasil.gov.my/eP2010/Pendapatan.aspx";
                        strPURL[2] = "https://ef.hasil.gov.my/eP2010/Pendapatan2.aspx";
                        strPURL[3] = "https://ef.hasil.gov.my/eP2010/pendapatan_lain.aspx";
                        strPURL[4] = "https://ef.hasil.gov.my/eP2010/perbelanjaan.aspx";
                        strPURL[5] = "https://ef.hasil.gov.my/eP2010/mak_cukai.aspx";
                        strPURL[6] = "https://ef.hasil.gov.my/eP2010/mak_ahli_kongsi.aspx";
                        strPURL[7] = "https://ef.hasil.gov.my/eP2010/mak_wang.aspx";
                        strPURL[8] = "https://ef.hasil.gov.my/eP2010/mak_firma.aspx";
                        strPURL[9] = "https://ef.hasil.gov.my/eP2010/akuan.aspx";
                        strURL = strPURL;
                    }
                    //PANYW CP204
                    if (strType == "CP204")
                    {
                        strCP204URL[0] = "https://ef.hasil.gov.my/cp204/cp204.aspx";
                        strURL = strCP204URL;
                    }
                    //PANYW CP204 END
                    break;
                case "2010":
                    //weihong
                    String[] strBEURL10 = new String[9];
                    String[] strBURL10 = new String[12];
                    String[] strMURL10 = new String[11];
                    String[] strPURL10 = new String[10];
                    //weihong

                    if (strType == "CP204")
                    {
                        strCP204URL[0] = "https://ef.hasil.gov.my/cp204/cp204.aspx";
                        strURL = strCP204URL;
                    }
                    //===NgKL C2010.1===
                    if (strType == "C")
                    {
                        strCURL[0] = "https://ef.hasil.gov.my/ec2010/mak_syarikat.aspx";
                        strCURL[1] = "https://ef.hasil.gov.my/ec2010/mak_pengarah.aspx";
                        strCURL[2] = "https://ef.hasil.gov.my/ec2010/mak_syer.aspx";
                        strCURL[3] = "https://ef.hasil.gov.my/ec2010/mak_wang.aspx";
                        strCURL[4] = "https://ef.hasil.gov.my/ec2010/pen_kanun.aspx";
                        strCURL[5] = "https://ef.hasil.gov.my/ec2010/pen_pindah.aspx";
                        strCURL[6] = "https://ef.hasil.gov.my/ec2010/pen_tahun.aspx";
                        strCURL[7] = "https://ef.hasil.gov.my/ec2010/tun_elaun.aspx";
                        strCURL[8] = "https://ef.hasil.gov.my/ec2010/tun_kerugian.aspx";
                        strCURL[9] = "https://ef.hasil.gov.my/ec2010/tun_insentif.aspx";
                        strCURL[10] = "https://ef.hasil.gov.my/ec2010/per_khas.aspx";
                        strCURL[11] = "https://ef.hasil.gov.my/ec2010/lain_akaun.aspx";
                        strCURL[12] = "https://ef.hasil.gov.my/ec2010/lain_cukai.aspx";
                        strCURL[13] = "https://ef.hasil.gov.my/ec2010/lain_transaksi.aspx";
                        strCURL[14] = "https://ef.hasil.gov.my/ec2010/lain_makl.aspx";
                        strCURL[15] = "https://ef.hasil.gov.my/ec2010/cukai_dibayar.aspx";
                        strCURL[16] = "https://ef.hasil.gov.my/ec2010/juruaudit.aspx";
                        strCURL[17] = "https://ef.hasil.gov.my/ec2010/firma.aspx";
                        strCURL[18] = "https://ef.hasil.gov.my/ec2010/rkt_rks.aspx";
                        strURL = strCURL;
                    }

                    if (strType == "R")
                    {
                        strRURL[0] = "https://ef.hasil.gov.my/er2010/dividensyrkt.aspx";
                        strRURL[1] = "https://ef.hasil.gov.my/er2010/penyata.aspx";
                        strURL = strRURL;
                    }
                    //===Ngkl C2010.1 End ===

                    //weihong
                    if (strType == "B")
                    {
                        strBURL10[0] = "https://ef.hasil.gov.my/ebe2011/mak_ind.aspx";
                        strBURL10[1] = "https://ef.hasil.gov.my/ebe2011/mak_pasangan.aspx";
                        strBURL10[2] = "https://ef.hasil.gov.my/ebe2011/pendapatan.aspx";
                        strBURL10[3] = "https://ef.hasil.gov.my/ebe2011/pend_belakang.aspx";
                        strBURL10[4] = "https://ef.hasil.gov.my/ebe2011/pelepasan.aspx";
                        strBURL10[5] = "https://ef.hasil.gov.my/ebe2011/rebat.aspx";
                        strBURL10[6] = "https://ef.hasil.gov.my/ebe2011/perniagaan.aspx";
                        strBURL10[7] = "https://ef.hasil.gov.my/ebe2011/khas.aspx";
                        strBURL10[8] = "https://ef.hasil.gov.my/ebe2011/kewangan.aspx";
                        strBURL10[9] = "https://ef.hasil.gov.my/ebe2011/mak_pentadbir.aspx";
                        strBURL10[10] = "https://ef.hasil.gov.my/ebe2011/rumusan.aspx";
                        strBURL10[11] = "https://ef.hasil.gov.my/ebe2011/HK3.aspx";
                        strURL = strBURL10;
                    }

                    //weihong
                    if (strType == "BE")
                    {
                        strBEURL10[0] = "https://ef.hasil.gov.my/ebe2011/mak_ind.aspx";
                        strBEURL10[1] = "https://ef.hasil.gov.my/ebe2011/mak_pasangan.aspx";
                        strBEURL10[2] = "https://ef.hasil.gov.my/ebe2011/pendapatan.aspx";
                        strBEURL10[3] = "https://ef.hasil.gov.my/ebe2011/pend_belakang.aspx";
                        strBEURL10[4] = "https://ef.hasil.gov.my/ebe2011/pelepasan.aspx";
                        strBEURL10[5] = "https://ef.hasil.gov.my/ebe2011/rebat.aspx";
                        strBEURL10[6] = "https://ef.hasil.gov.my/ebe2011/mak_pentadbir.aspx";
                        strBEURL10[7] = "https://ef.hasil.gov.my/ebe2011/rumusan.aspx";
                        strBEURL10[8] = "https://ef.hasil.gov.my/ebe2011/HK3.aspx";
                        strURL = strBEURL10;
                    }

                    //weihong
                    if (strType == "M")
                    {
                        //https://elatihan.hasil.gov.my/eM2011/Mak_ind.aspx
                        strMURL10[0] = "https://ef.hasil.gov.my/eM2011/Mak_ind.aspx";
                        strMURL10[1] = "https://ef.hasil.gov.my/eM2011/mak_pasangan.aspx";
                        strMURL10[2] = "https://ef.hasil.gov.my/eM2011/pendapatan.aspx";
                        strMURL10[3] = "https://ef.hasil.gov.my/eM2011/pend_belakang.aspx";
                        strMURL10[4] = "https://ef.hasil.gov.my/eM2011/rebat.aspx";
                        strMURL10[5] = "https://ef.hasil.gov.my/eM2011/perniagaan.aspx";
                        strMURL10[6] = "https://ef.hasil.gov.my/eM2011/khas.aspx";
                        strMURL10[7] = "https://ef.hasil.gov.my/eM2011/kewangan.aspx";
                        strMURL10[8] = "https://ef.hasil.gov.my/eM2011/mak_pentadbir.aspx";
                        strMURL10[9] = "https://ef.hasil.gov.my/eM2011/rumusan.aspx";
                        strMURL10[10] = "https://ef.hasil.gov.my/eM2011/HK3.aspx";
                        strURL = strMURL10;
                    }

                    if (strType == "P")
                    {
                        strPURL10[0] = "https://ef.hasil.gov.my/eP2011/Mak_asas.aspx";
                        strPURL10[1] = "https://ef.hasil.gov.my/eP2011/Pendapatan.aspx";
                        strPURL10[2] = "https://ef.hasil.gov.my/eP2011/Pendapatan2.aspx";
                        strPURL10[3] = "https://ef.hasil.gov.my/eP2011/pendapatan_lain.aspx";
                        strPURL10[4] = "https://ef.hasil.gov.my/eP2011/perbelanjaan.aspx";
                        strPURL10[5] = "https://ef.hasil.gov.my/eP2011/mak_cukai.aspx";
                        strPURL10[6] = "https://ef.hasil.gov.my/eP2011/mak_ahli_kongsi.aspx";
                        strPURL10[7] = "https://ef.hasil.gov.my/eP2011/mak_wang.aspx";
                        strPURL10[8] = "https://ef.hasil.gov.my/eP2011/mak_firma.aspx";
                        strPURL10[9] = "https://ef.hasil.gov.my/eP2011/akuan.aspx";
                        strURL = strPURL10;
                    }

                    break;
                case "2011":

                    String[] strBEURL11 = new String[9];
                    String[] strBURL11 = new String[12];
                    String[] strMURL11 = new String[11];
                    String[] strPURL11 = new String[10];

                    if (strType == "CP204")
                    {
                        strCP204URL[0] = "https://ef.hasil.gov.my/cp204/cp204.aspx";
                        strURL = strCP204URL;
                    }

                    if (strType == "C")
                    {
                        strCURL[0] = "https://ef.hasil.gov.my/ec2011/mak_syarikat.aspx";
                        strCURL[1] = "https://ef.hasil.gov.my/ec2011/mak_pengarah.aspx";
                        strCURL[2] = "https://ef.hasil.gov.my/ec2011/mak_syer.aspx";
                        strCURL[3] = "https://ef.hasil.gov.my/ec2011/mak_wang.aspx";
                        strCURL[4] = "https://ef.hasil.gov.my/ec2011/pen_kanun.aspx";
                        strCURL[5] = "https://ef.hasil.gov.my/ec2011/pen_pindah.aspx";
                        strCURL[6] = "https://ef.hasil.gov.my/ec2011/pen_tahun.aspx";
                        strCURL[7] = "https://ef.hasil.gov.my/ec2011/tun_elaun.aspx";
                        strCURL[8] = "https://ef.hasil.gov.my/ec2011/tun_kerugian.aspx";
                        strCURL[9] = "https://ef.hasil.gov.my/ec2011/tun_insentif.aspx";
                        strCURL[10] = "https://ef.hasil.gov.my/ec2011/per_khas.aspx";
                        strCURL[11] = "https://ef.hasil.gov.my/ec2011/lain_akaun.aspx";
                        strCURL[12] = "https://ef.hasil.gov.my/ec2011/lain_cukai.aspx";
                        strCURL[13] = "https://ef.hasil.gov.my/ec2011/lain_transaksi.aspx";
                        strCURL[14] = "https://ef.hasil.gov.my/ec2011/lain_makl.aspx";
                        strCURL[15] = "https://ef.hasil.gov.my/ec2011/cukai_dibayar.aspx";
                        strCURL[16] = "https://ef.hasil.gov.my/ec2011/juruaudit.aspx";
                        strCURL[17] = "https://ef.hasil.gov.my/ec2011/firma.aspx";
                        strCURL[18] = "https://ef.hasil.gov.my/ec2011/rkt_rks.aspx";
                        strURL = strCURL;
                    }

                    if (strType == "R")
                    {
                        strRURL[0] = "https://ef.hasil.gov.my/eR2011/Dividen.aspx";
                        strRURL[1] = "https://ef.hasil.gov.my/er2011/penyata.aspx";
                        strURL = strRURL;
                    }

                    //ngohcs
                    if (strType == "CP204A")
                    {
                        strCP204AURL[0] = "https://ef.hasil.gov.my/cp204a/formcp204a.aspx";
                        strURL = strCP204AURL;
                    }
                    //ngohcs end

                    //danny
                    if (strType == "B")
                    {
                        strBURL11[0] = "https://ef.hasil.gov.my/ebe2012/mak_ind.aspx";
                        strBURL11[1] = "https://ef.hasil.gov.my/ebe2012/mak_pasangan.aspx";
                        strBURL11[2] = "https://ef.hasil.gov.my/ebe2012/pendapatan.aspx";
                        strBURL11[3] = "https://ef.hasil.gov.my/ebe2012/pend_belakang.aspx";
                        strBURL11[4] = "https://ef.hasil.gov.my/ebe2012/pelepasan.aspx";
                        strBURL11[5] = "https://ef.hasil.gov.my/ebe2012/rebat.aspx";
                        strBURL11[6] = "https://ef.hasil.gov.my/ebe2012/perniagaan.aspx";
                        strBURL11[7] = "https://ef.hasil.gov.my/ebe2012/khas.aspx";
                        strBURL11[8] = "https://ef.hasil.gov.my/ebe2012/kewangan.aspx";
                        strBURL11[9] = "https://ef.hasil.gov.my/ebe2012/mak_pentadbir.aspx";
                        strBURL11[10] = "https://ef.hasil.gov.my/ebe2012/rumusan.aspx";
                        strBURL11[11] = "https://ef.hasil.gov.my/ebe2012/HK3.aspx";
                        strURL = strBURL11;
                    }

                    //danny
                    if (strType == "BE")
                    {
                        strBEURL11[0] = "https://ef.hasil.gov.my/ebe2012/mak_ind.aspx";
                        strBEURL11[1] = "https://ef.hasil.gov.my/ebe2012/mak_pasangan.aspx";
                        strBEURL11[2] = "https://ef.hasil.gov.my/ebe2012/pendapatan.aspx";
                        strBEURL11[3] = "https://ef.hasil.gov.my/ebe2012/pend_belakang.aspx";
                        strBEURL11[4] = "https://ef.hasil.gov.my/ebe2012/pelepasan.aspx";
                        strBEURL11[5] = "https://ef.hasil.gov.my/ebe2012/rebat.aspx";
                        strBEURL11[6] = "https://ef.hasil.gov.my/ebe2012/mak_pentadbir.aspx";
                        strBEURL11[7] = "https://ef.hasil.gov.my/ebe2012/rumusan.aspx";
                        strBEURL11[8] = "https://ef.hasil.gov.my/ebe2012/HK3.aspx";
                        strURL = strBEURL11;
                    }

                    //danny
                    if (strType == "M")
                    {
                        //https://elatihan.hasil.gov.my/eM2012/Mak_ind.aspx
                        strMURL11[0] = "https://ef.hasil.gov.my/eM2012/Mak_ind.aspx";
                        strMURL11[1] = "https://ef.hasil.gov.my/eM2012/mak_pasangan.aspx";
                        strMURL11[2] = "https://ef.hasil.gov.my/eM2012/pendapatan.aspx";
                        strMURL11[3] = "https://ef.hasil.gov.my/eM2012/pend_belakang.aspx";
                        strMURL11[4] = "https://ef.hasil.gov.my/eM2012/rebat.aspx";
                        strMURL11[5] = "https://ef.hasil.gov.my/eM2012/perniagaan.aspx";
                        strMURL11[6] = "https://ef.hasil.gov.my/eM2012/khas.aspx";
                        strMURL11[7] = "https://ef.hasil.gov.my/eM2012/kewangan.aspx";
                        strMURL11[8] = "https://ef.hasil.gov.my/eM2012/mak_pentadbir.aspx";
                        strMURL11[9] = "https://ef.hasil.gov.my/eM2012/rumusan.aspx";
                        strMURL11[10] = "https://ef.hasil.gov.my/eM2012/HK3.aspx";
                        strURL = strMURL11;
                    }


                    if (strType == "P")
                    {
                        strPURL11[0] = "https://ef.hasil.gov.my/eP2012/Mak_asas.aspx";
                        strPURL11[1] = "https://ef.hasil.gov.my/eP2012/Pendapatan.aspx";
                        strPURL11[2] = "https://ef.hasil.gov.my/eP2012/Pendapatan2.aspx";
                        strPURL11[3] = "https://ef.hasil.gov.my/eP2012/pendapatan_lain.aspx";
                        strPURL11[4] = "https://ef.hasil.gov.my/eP2012/perbelanjaan.aspx";
                        strPURL11[5] = "https://ef.hasil.gov.my/eP2012/mak_cukai.aspx";
                        strPURL11[6] = "https://ef.hasil.gov.my/eP2012/mak_ahli_kongsi.aspx";
                        strPURL11[7] = "https://ef.hasil.gov.my/eP2012/mak_wang.aspx";
                        strPURL11[8] = "https://ef.hasil.gov.my/eP2012/mak_firma.aspx";
                        strPURL11[9] = "https://ef.hasil.gov.my/eP2012/akuan.aspx";
                        strURL = strPURL11;
                    }


                    break;

                case "2012":


                    String[] strBEURL12 = new String[9];
                    String[] strBURL12 = new String[12];
                    String[] strMURL12 = new String[11];
                    String[] strPURL12 = new String[10];

                    //dannylee 21/06/2011
                    if (strType == "C")
                    {
                        strCURL[0] = "https://ef.hasil.gov.my/ec2012PP/mak_sykt.aspx";
                        strCURL[1] = "https://ef.hasil.gov.my/ec2012PP/mak_pengarah.aspx";
                        strCURL[2] = "https://ef.hasil.gov.my/ec2012PP/mak_syer.aspx";
                        strCURL[3] = "https://ef.hasil.gov.my/ec2012PP/mak_wang.aspx";
                        strCURL[4] = "https://ef.hasil.gov.my/ec2012PP/pen_kanun.aspx";
                        strCURL[5] = "https://ef.hasil.gov.my/ec2012PP/pen_pindah.aspx";
                        strCURL[6] = "https://ef.hasil.gov.my/ec2012PP/pen_tahun.aspx";
                        strCURL[7] = "https://ef.hasil.gov.my/ec2012PP/tun_elaun.aspx";
                        strCURL[8] = "https://ef.hasil.gov.my/ec2012PP/tun_kerugian.aspx";
                        strCURL[9] = "https://ef.hasil.gov.my/ec2012PP/tun_insentif.aspx";
                        strCURL[10] = "https://ef.hasil.gov.my/ec2012PP/per_khas.aspx";
                        strCURL[11] = "https://ef.hasil.gov.my/ec2012PP/lain_akaun.aspx";
                        strCURL[12] = "https://ef.hasil.gov.my/ec2012PP/lain_cukai.aspx";
                        strCURL[13] = "https://ef.hasil.gov.my/ec2012PP/lain_transaksi.aspx";
                        strCURL[14] = "https://ef.hasil.gov.my/ec2012PP/lain_makl.aspx";
                        strCURL[15] = "https://ef.hasil.gov.my/ec2012PP/cukai_dibayar.aspx";
                        strCURL[16] = "https://ef.hasil.gov.my/ec2012PP/juruaudit.aspx";
                        strCURL[17] = "https://ef.hasil.gov.my/ec2012PP/firma.aspx";
                        strCURL[18] = "https://ef.hasil.gov.my/ec2012PP/rkt_rks.aspx";
                        strURL = strCURL;
                    }

                    if (strType == "R")
                    {
                        strRURL[0] = "https://ef.hasil.gov.my/eR2012PP/Dividen.aspx";
                        strRURL[1] = "https://ef.hasil.gov.my/er2012PP/penyata.aspx";
                        strURL = strRURL;
                    }

                    //dannylee end

                    //simkh 2012 su2
                    if (strType == "M")
                    {
                        //https://elatihan.hasil.gov.my/eM2013/Mak_ind.aspx
                        strMURL12[0] = "https://ef.hasil.gov.my/eM2013PP/Mak_ind.aspx";
                        strMURL12[1] = "https://ef.hasil.gov.my/eM2013PP/mak_pasangan.aspx";
                        strMURL12[2] = "https://ef.hasil.gov.my/eM2013PP/pendapatan.aspx";
                        strMURL12[3] = "https://ef.hasil.gov.my/eM2013PP/pend_belakang.aspx";
                        strMURL12[4] = "https://ef.hasil.gov.my/eM2013PP/rebat.aspx";
                        strMURL12[5] = "https://ef.hasil.gov.my/eM2013PP/perniagaan.aspx";
                        strMURL12[6] = "https://ef.hasil.gov.my/eM2013PP/khas.aspx";
                        strMURL12[7] = "https://ef.hasil.gov.my/eM2013PP/kewangan.aspx";
                        strMURL12[8] = "https://ef.hasil.gov.my/eM2013PP/mak_pentadbir.aspx";
                        strMURL12[9] = "https://ef.hasil.gov.my/eM2013PP/rumusan.aspx";
                        strMURL12[10] = "https://ef.hasil.gov.my/eM2013PP/HK3.aspx";
                        strURL = strMURL12;
                    }
                    //simkh end

                    //weihong
                    if (strType == "CP204")
                    {
                        strCP204URL[0] = "https://ef.hasil.gov.my/cp204PP/cp204.aspx";
                        strURL = strCP204URL;
                    }
                    //endweihong
                    //ngohcs
                    if (strType == "CP204A")
                    {
                        strCP204URL[0] = "https://ef.hasil.gov.my/cp204aPP/formcp204a.aspx";
                        strURL = strCP204URL;
                    }
                    //ngohcs end

                    //dannylee 15/02/2013
                    if (strType == "BE")
                    {
                        strBEURL12[0] = "https://ef.hasil.gov.my/ebe2013PP/mak_ind.aspx";
                        strBEURL12[1] = "https://ef.hasil.gov.my/ebe2013PP/mak_pasangan.aspx";
                        strBEURL12[2] = "https://ef.hasil.gov.my/ebe2013PP/pendapatan.aspx";
                        strBEURL12[3] = "https://ef.hasil.gov.my/ebe2013PP/pend_belakang.aspx";
                        strBEURL12[4] = "https://ef.hasil.gov.my/ebe2013PP/pelepasan.aspx";
                        strBEURL12[5] = "https://ef.hasil.gov.my/ebe2013PP/rebat.aspx";
                        strBEURL12[6] = "https://ef.hasil.gov.my/ebe2013PP/mak_pentadbir.aspx";
                        strBEURL12[7] = "https://ef.hasil.gov.my/ebe2013PP/rumusan.aspx";
                        strBEURL12[8] = "https://ef.hasil.gov.my/ebe2013PP/HK3.aspx";
                        strURL = strBEURL12;
                    }
                    //dannylee end

                    if (strType == "P")
                    {
                        strPURL12[0] = "https://ef.hasil.gov.my/eP2013PP/Mak_asas.aspx";
                        strPURL12[1] = "https://ef.hasil.gov.my/eP2013PP/Pendapatan.aspx";
                        strPURL12[2] = "https://ef.hasil.gov.my/eP2013PP/Pendapatan2.aspx";
                        strPURL12[3] = "https://ef.hasil.gov.my/eP2013PP/pendapatan_lain.aspx";
                        strPURL12[4] = "https://ef.hasil.gov.my/eP2013PP/perbelanjaan.aspx";
                        strPURL12[5] = "https://ef.hasil.gov.my/eP2013PP/mak_cukai.aspx";
                        strPURL12[6] = "https://ef.hasil.gov.my/eP2013PP/mak_ahli_kongsi.aspx";
                        strPURL12[7] = "https://ef.hasil.gov.my/eP2013PP/mak_wang.aspx";
                        strPURL12[8] = "https://ef.hasil.gov.my/eP2013PP/mak_firma.aspx";
                        strPURL12[9] = "https://ef.hasil.gov.my/eP2013PP/akuan.aspx";
                        strURL = strPURL12;
                    }

                    if (strType == "B")
                    {
                        strBURL12[0] = "https://ef.hasil.gov.my/ebe2013PP/mak_ind.aspx";
                        strBURL12[1] = "https://ef.hasil.gov.my/ebe2013PP/mak_pasangan.aspx";
                        strBURL12[2] = "https://ef.hasil.gov.my/ebe2013PP/pendapatan.aspx";
                        strBURL12[3] = "https://ef.hasil.gov.my/ebe2013PP/pend_belakang.aspx";
                        strBURL12[4] = "https://ef.hasil.gov.my/ebe2013PP/pelepasan.aspx";
                        strBURL12[5] = "https://ef.hasil.gov.my/ebe2013PP/rebat.aspx";
                        strBURL12[6] = "https://ef.hasil.gov.my/ebe2013PP/perniagaan.aspx";
                        strBURL12[7] = "https://ef.hasil.gov.my/ebe2013PP/khas.aspx";
                        strBURL12[8] = "https://ef.hasil.gov.my/ebe2013PP/kewangan.aspx";
                        strBURL12[9] = "https://ef.hasil.gov.my/ebe2013PP/mak_pentadbir.aspx";
                        strBURL12[10] = "https://ef.hasil.gov.my/ebe2013PP/rumusan.aspx";
                        strBURL12[11] = "https://ef.hasil.gov.my/ebe2013PP/HK3.aspx";
                        strURL = strBURL12;
                    }
                    break;

                 case "2013":

                     String[] strCURL13 = new String[15];
                     String[] strMURL13 = new String[11];
                     String[] strBEURL13 = new String[9];
                     String[] strPURL13 = new String[10];
                     String[] strBURL13 = new String[12];

                     //dannylee 04/07/2011
                     if (strType == "C")
                     {
                         strCURL13[0] = "https://ef.hasil.gov.my/ec2013PP/mak_sykt.aspx";
                         strCURL13[1] = "https://ef.hasil.gov.my/ec2013PP/mak_pengarah.aspx";
                         strCURL13[2] = "https://ef.hasil.gov.my/ec2013PP/mak_syer.aspx";
                         strCURL13[3] = "https://ef.hasil.gov.my/ec2013PP/pen_kanun.aspx";
                         strCURL13[4] = "https://ef.hasil.gov.my/ec2013PP/per_khas.aspx";
                         strCURL13[5] = "https://ef.hasil.gov.my/ec2013PP/tun_elaun.aspx";
                         strCURL13[6] = "https://ef.hasil.gov.my/ec2013PP/tun_insentif.aspx";
                         strCURL13[7] = "https://ef.hasil.gov.my/ec2013PP/pen_pindah.aspx";
                         strCURL13[8] = "https://ef.hasil.gov.my/ec2013PP/mak_wang.aspx";
                         strCURL13[9] = "https://ef.hasil.gov.my/ec2013PP/lain_cukai.aspx";
                         strCURL13[10] = "https://ef.hasil.gov.my/ec2013PP/lain_transaksi.aspx";
                         strCURL13[11] = "https://ef.hasil.gov.my/ec2013PP/lain_makl.aspx";
                         strCURL13[12] = "https://ef.hasil.gov.my/ec2013PP/cukai_dibayar.aspx";
                         strCURL13[13] = "https://ef.hasil.gov.my/ec2013PP/juruaudit.aspx";
                         strCURL13[14] = "https://ef.hasil.gov.my/ec2013PP/rkt_rks.aspx";
                         strURL = strCURL13;
                     }

                     if (strType == "R")
                     {
                         strRURL[0] = "https://ef.hasil.gov.my/er2013PP/dividen.aspx";
                         strRURL[1] = "https://ef.hasil.gov.my/er2013PP/penyata.aspx";
                         strURL = strRURL;
                     }

                     //dannylee end

                     if (strType == "M")
                     {                       
                         strMURL13[0] = "https://ef.hasil.gov.my/eM2014PP/Mak_ind.aspx";
                         strMURL13[1] = "https://ef.hasil.gov.my/eM2014PP/mak_pasangan.aspx";
                         strMURL13[2] = "https://ef.hasil.gov.my/eM2014PP/pendapatan.aspx";
                         strMURL13[3] = "https://ef.hasil.gov.my/eM2014PP/pend_belakang.aspx";
                         strMURL13[4] = "https://ef.hasil.gov.my/eM2014PP/rebat.aspx";
                         strMURL13[5] = "https://ef.hasil.gov.my/eM2014PP/perniagaan.aspx";
                         strMURL13[6] = "https://ef.hasil.gov.my/eM2014PP/khas.aspx";
                         strMURL13[7] = "https://ef.hasil.gov.my/eM2014PP/kewangan.aspx";
                         strMURL13[8] = "https://ef.hasil.gov.my/eM2014PP/mak_pentadbir.aspx";
                         strMURL13[9] = "https://ef.hasil.gov.my/eM2014PP/rumusan.aspx";
                         strMURL13[10] = "https://ef.hasil.gov.my/eM2014PP/HK3.aspx";
                         strURL = strMURL13;
                     }

                    if (strType == "CP204")
                    {
                        strCP204URL[0] = "https://ef.hasil.gov.my/cp204PP/cp204.aspx";
                        strURL = strCP204URL;
                    }

                    if (strType == "CP204A")
                    {
                        strCP204URL[0] = "https://ef.hasil.gov.my/cp204aPP/formcp204a.aspx";
                        strURL = strCP204URL;
                    }

                    if (strType == "BE")
                    {
                        strBEURL13[0] = "https://ef.hasil.gov.my/ebe2014PP/mak_ind.aspx";
                        strBEURL13[1] = "https://ef.hasil.gov.my/ebe2014PP/mak_pasangan.aspx";
                        strBEURL13[2] = "https://ef.hasil.gov.my/ebe2014PP/pendapatan.aspx";
                        strBEURL13[3] = "https://ef.hasil.gov.my/ebe2014PP/pend_belakang.aspx";
                        strBEURL13[4] = "https://ef.hasil.gov.my/ebe2014PP/pelepasan.aspx";
                        strBEURL13[5] = "https://ef.hasil.gov.my/ebe2014PP/rebat.aspx";
                        strBEURL13[6] = "https://ef.hasil.gov.my/ebe2014PP/mak_pentadbir.aspx";
                        strBEURL13[7] = "https://ef.hasil.gov.my/ebe2014PP/rumusan.aspx";
                        strBEURL13[8] = "https://ef.hasil.gov.my/ebe2014PP/HK3.aspx";
                        strURL = strBEURL13;
                    }
                    //dannylee end

                    if (strType == "P")
                    {
                        strPURL13[0] = "https://ef.hasil.gov.my/eP2014PP/Mak_asas.aspx";
                        strPURL13[1] = "https://ef.hasil.gov.my/eP2014PP/Pendapatan.aspx";
                        strPURL13[2] = "https://ef.hasil.gov.my/eP2014PP/Pendapatan2.aspx";
                        strPURL13[3] = "https://ef.hasil.gov.my/eP2014PP/pendapatan_lain.aspx";
                        strPURL13[4] = "https://ef.hasil.gov.my/eP2014PP/perbelanjaan.aspx";
                        strPURL13[5] = "https://ef.hasil.gov.my/eP2014PP/mak_cukai.aspx";
                        strPURL13[6] = "https://ef.hasil.gov.my/eP2014PP/mak_ahli_kongsi.aspx";
                        strPURL13[7] = "https://ef.hasil.gov.my/eP2014PP/mak_wang.aspx";
                        strPURL13[8] = "https://ef.hasil.gov.my/eP2014PP/mak_firma.aspx";
                        strPURL13[9] = "https://ef.hasil.gov.my/eP2014PP/akuan.aspx";
                        strURL = strPURL13;
                    }

                    if (strType == "B")
                    {
                        strBURL13[0] = "https://ef.hasil.gov.my/eBe2014PP/mak_ind.aspx";
                        strBURL13[1] = "https://ef.hasil.gov.my/eBe2014PP/pendapatan.aspx";
                        strBURL13[2] = "https://ef.hasil.gov.my/eBe2014PP/pelepasan.aspx";
                        strBURL13[3] = "https://ef.hasil.gov.my/eBe2014PP/kewangan.aspx";
                        strBURL13[4] = "https://ef.hasil.gov.my/eBe2014PP/mak_pentadbir.aspx";
                        strBURL13[5] = "https://ef.hasil.gov.my/eBe2014PP/rumusan.aspx";

                        //strBURL13[0] = "https://ef.hasil.gov.my/ebe2014PP/mak_ind.aspx";
                        //strBURL13[1] = "https://ef.hasil.gov.my/ebe2014PP/mak_pasangan.aspx";
                        //strBURL13[2] = "https://ef.hasil.gov.my/ebe2014PP/pendapatan.aspx";
                        //strBURL13[3] = "https://ef.hasil.gov.my/ebe2014PP/pend_belakang.aspx";
                        //strBURL13[4] = "https://ef.hasil.gov.my/ebe2014PP/pelepasan.aspx";
                        //strBURL13[5] = "https://ef.hasil.gov.my/ebe2014PP/rebat.aspx";
                        //strBURL13[6] = "https://ef.hasil.gov.my/ebe2014PP/perniagaan.aspx";
                        //strBURL13[7] = "https://ef.hasil.gov.my/ebe2014PP/khas.aspx";
                        //strBURL13[8] = "https://ef.hasil.gov.my/ebe2014PP/kewangan.aspx";
                        //strBURL13[9] = "https://ef.hasil.gov.my/ebe2014PP/mak_pentadbir.aspx";
                        //strBURL13[10] = "https://ef.hasil.gov.my/ebe2014PP/rumusan.aspx";
                        //strBURL13[11] = "https://ef.hasil.gov.my/ebe2014PP/HK3.aspx";
                        strURL = strBURL13;
                    }
                    //ngohcs
                    //if (strType == "CP204A")
                    //{
                    //    strCP204URL[0] = "https://ef.hasil.gov.my/cp204a/formcp204a.aspx";
                    //    strURL = strCP204URL;
                    //}

                    //ngohcs end
                    break;
                case "2014":

                    String[] strCURL14 = new String[15];
                    String[] strBURL14 = new String[4];
                    String[] strBEURL14 = new String[4];
                    String[] strMURL14 = new String[11];
                    String[] strPURL14 = new String[10];
                    

                    //simkh Mar2014
                    if (strType == "C")
                    {
                        strCURL14[0] = "https://ef.hasil.gov.my/ec2014PP/mak_sykt.aspx";
                        strCURL14[1] = "https://ef.hasil.gov.my/ec2014PP/mak_pengarah.aspx";
                        strCURL14[2] = "https://ef.hasil.gov.my/ec2014PP/mak_syer.aspx";
                        strCURL14[3] = "https://ef.hasil.gov.my/ec2014PP/pen_kanun.aspx";
                        strCURL14[4] = "https://ef.hasil.gov.my/ec2014PP/per_khas.aspx";
                        strCURL14[5] = "https://ef.hasil.gov.my/ec2014PP/tun_elaun.aspx";
                        strCURL14[6] = "https://ef.hasil.gov.my/ec2014PP/tun_insentif.aspx";
                        strCURL14[7] = "https://ef.hasil.gov.my/ec2014PP/pen_pindah.aspx";
                        strCURL14[8] = "https://ef.hasil.gov.my/ec2014PP/mak_wang.aspx";
                        strCURL14[9] = "https://ef.hasil.gov.my/ec2014PP/lain_cukai.aspx";
                        strCURL14[10] = "https://ef.hasil.gov.my/ec2014PP/lain_transaksi.aspx";
                        strCURL14[11] = "https://ef.hasil.gov.my/ec2014PP/lain_makl.aspx";
                        strCURL14[12] = "https://ef.hasil.gov.my/ec2014PP/juruaudit.aspx";
                        strCURL14[13] = "https://ef.hasil.gov.my/ec2014PP/cukai_dibayar.aspx";
                        strCURL14[14] = "https://ef.hasil.gov.my/ec2014PP/rkt_rks.aspx";
                        strURL = strCURL14;
                    }

                    if (strType == "R")
                    {
                        //https://ef.hasil.gov.my/eR2014PP/Dividen.aspx
                        strRURL[0] = "https://ef.hasil.gov.my/er2014PP/dividen.aspx";
                        strRURL[1] = "https://ef.hasil.gov.my/er2014PP/penyata.aspx";
                        strURL = strRURL;
                    }

                    if (strType == "B")
                    {
                        strBURL14[0] = "https://ef.hasil.gov.my/eBe2015PP/Ind.aspx";
                        strBURL14[1] = "https://ef.hasil.gov.my/eBe2015PP/Ind.aspx?tab=PD";
                        strBURL14[2] = "https://ef.hasil.gov.my/eBe2015PP/Ind.aspx?tab=PL";
                        strBURL14[3] = "https://ef.hasil.gov.my/eBe2015PP/HK3.aspx";
                        strURL = strBURL14;
                    }

                    if (strType == "BE")
                    {
                        //https://ef.hasil.gov.my/eBe2015PP/Ind.aspx
                        strBEURL14[0] = "https://ef.hasil.gov.my/eBe2015PP/Ind.aspx";
                        strBEURL14[1] = "https://ef.hasil.gov.my/eBe2015PP/Ind.aspx?tab=PD";
                        strBEURL14[2] = "https://ef.hasil.gov.my/eBe2015PP/Ind.aspx?tab=PL";
                        strBEURL14[3] = "https://ef.hasil.gov.my/eBe2015PP/HK3.aspx";
                        strURL = strBEURL14;
                    }
                    //dannylee end

                    if (strType == "M")
                    {
                        //https://ef.hasil.gov.my/eM2015PP/Mak_ind.aspx
                        strMURL14[0] = "https://ef.hasil.gov.my/eM2015PP/mak_ind.aspx";
                        strMURL14[1] = "https://ef.hasil.gov.my/eM2015PP/mak_pasangan.aspx";
                        strMURL14[2] = "https://ef.hasil.gov.my/eM2015PP/pendapatan.aspx";
                        strMURL14[3] = "https://ef.hasil.gov.my/eM2015PP/pend_belakang.aspx";
                        strMURL14[4] = "https://ef.hasil.gov.my/eM2015PP/rebat.aspx";
                        strMURL14[5] = "https://ef.hasil.gov.my/eM2015PP/perniagaan.aspx";
                        strMURL14[6] = "https://ef.hasil.gov.my/eM2015PP/khas.aspx";
                        strMURL14[7] = "https://ef.hasil.gov.my/eM2015PP/kewangan.aspx";
                        strMURL14[8] = "https://ef.hasil.gov.my/eM2015PP/mak_pentadbir.aspx";
                        strMURL14[9] = "https://ef.hasil.gov.my/eM2015PP/rumusan.aspx";
                        strMURL14[10] = "https://ef.hasil.gov.my/eM2015PP/HK3.aspx";
                        strURL = strMURL14;
                    }

                    if (strType == "P")
                    {
                        strPURL14[0] = "https://ef.hasil.gov.my/eP2015PP/Mak_asas.aspx";
                        strPURL14[1] = "https://ef.hasil.gov.my/eP2015PP/Pendapatan.aspx";
                        // strPURL15[2] = "https://ef.hasil.gov.my/eP2015PP/Pendapatan2.aspx";
                        strPURL14[2] = "https://ef.hasil.gov.my/eP2015PP/pendapatan_lain.aspx";
                        strPURL14[3] = "https://ef.hasil.gov.my/eP2015PP/perbelanjaan.aspx";
                        strPURL14[4] = "https://ef.hasil.gov.my/eP2015PP/mak_cukai.aspx";
                        strPURL14[5] = "https://ef.hasil.gov.my/eP2015PP/mak_ahli_kongsi.aspx";
                        strPURL14[6] = "https://ef.hasil.gov.my/eP2015PP/mak_wang.aspx";
                        strPURL14[7] = "https://ef.hasil.gov.my/eP2015PP/mak_firma.aspx";
                        strPURL14[8] = "https://ef.hasil.gov.my/eP2015PP/akuan.aspx";
                        strURL = strPURL14;
                    }
                    //if (strType == "P")
                    //{
                    //    strPURL14[0] = "https://ef.hasil.gov.my/eP2015PP/Mak_asas.aspx";
                    //    strPURL14[1] = "https://ef.hasil.gov.my/eP2015PP/Pendapatan.aspx";
                    //    strPURL14[2] = "https://ef.hasil.gov.my/eP2015PP/Pendapatan2.aspx";
                    //    strPURL14[3] = "https://ef.hasil.gov.my/eP2015PP/pendapatan_lain.aspx";
                    //    strPURL14[4] = "https://ef.hasil.gov.my/eP2015PP/perbelanjaan.aspx";
                    //    strPURL14[5] = "https://ef.hasil.gov.my/eP2015PP/mak_cukai.aspx";
                    //    strPURL14[6] = "https://ef.hasil.gov.my/eP2015PP/mak_ahli_kongsi.aspx";
                    //    strPURL14[7] = "https://ef.hasil.gov.my/eP2015PP/mak_wang.aspx";
                    //    strPURL14[8] = "https://ef.hasil.gov.my/eP2015PP/mak_firma.aspx";
                    //    strPURL14[9] = "https://ef.hasil.gov.my/eP2015PP/akuan.aspx";
                    //    strURL = strPURL14;
                    //}

                    //LeeCC 2012 SU2 CP204 2014 URL
                    if (strType == "CP204")
                    {
                        //
                        strCP204URL[0] = "https://ef.hasil.gov.my/cp204PP/cp204.aspx";
                        strURL = strCP204URL;
                    }

                    if (strType == "CP204A")
                    {
                        strCP204URL[0] = "https://ef.hasil.gov.my/cp204aPP/formcp204a.aspx";
                        strURL = strCP204URL;
                    }

                    break;



                case "2015":
                    String[] strCURL15 = new String[15];
                    String[] strBURL15 = new String[4];
                    String[] strBEURL15 = new String[4];
                    String[] strMURL15 = new String[11];
                    String[] strPURL15 = new String[9];


                    //simkh Mar2014
                    if (strType == "C")
                    {
                        strCURL15[0] = "https://ef.hasil.gov.my/ec2015PP/mak_sykt.aspx";
                        strCURL15[1] = "https://ef.hasil.gov.my/ec2015PP/mak_pengarah.aspx";
                        strCURL15[2] = "https://ef.hasil.gov.my/ec2015PP/mak_syer.aspx";
                        strCURL15[3] = "https://ef.hasil.gov.my/ec2015PP/pen_kanun.aspx";
                        strCURL15[4] = "https://ef.hasil.gov.my/ec2015PP/per_khas.aspx";
                        strCURL15[5] = "https://ef.hasil.gov.my/ec2015PP/tun_elaun.aspx";
                        strCURL15[6] = "https://ef.hasil.gov.my/ec2015PP/tun_insentif.aspx";
                        strCURL15[7] = "https://ef.hasil.gov.my/ec2015PP/pen_pindah.aspx";
                        strCURL15[8] = "https://ef.hasil.gov.my/ec2015PP/mak_wang.aspx";
                        strCURL15[9] = "https://ef.hasil.gov.my/ec2015PP/lain_cukai.aspx";
                        strCURL15[10] = "https://ef.hasil.gov.my/ec2015PP/lain_transaksi.aspx";
                        strCURL15[11] = "https://ef.hasil.gov.my/ec2015PP/lain_makl.aspx";
                        strCURL15[12] = "https://ef.hasil.gov.my/ec2015PP/juruaudit.aspx";
                        strCURL15[13] = "https://ef.hasil.gov.my/ec2015PP/cukai_dibayar.aspx";
                        strCURL15[14] = "https://ef.hasil.gov.my/ec2015PP/rkt_rks.aspx";
                        strURL = strCURL15;
                    }

                    if (strType == "R")
                    {
                        //https://ef.hasil.gov.my/eR2014PP/Dividen.aspx
                        strRURL[0] = "https://ef.hasil.gov.my/er2015/dividen.aspx";
                        strRURL[1] = "https://ef.hasil.gov.my/er2015/penyata.aspx";
                        strURL = strRURL;
                    }
                    //simkh april 2014
                    if (strType == "CP204")
                    {
                        strCP204URL[0] = "https://ef.hasil.gov.my/cp204/cp204.aspx";
                        strURL = strCP204URL;
                    }

                    if (strType == "CP204A")
                    {
                        strCP204URL[0] = "https://ef.hasil.gov.my/cp204a/formcp204a.aspx";
                        strURL = strCP204URL;
                    }

                    if (strType == "B")
                    {
                        strBURL15[0] = "https://ef.hasil.gov.my/eBe2016/Ind.aspx";
                        strBURL15[1] = "https://ef.hasil.gov.my/eBe2016/Ind.aspx?tab=PD";
                        strBURL15[2] = "https://ef.hasil.gov.my/eBe2016/Ind.aspx?tab=PL";
                        strBURL15[3] = "https://ef.hasil.gov.my/eBe2016/HK6.aspx?pg=HK6";
                        strURL = strBURL15;
                    }

                    if (strType == "BE")
                    {
                        //https://ef.hasil.gov.my/eBe2016PP/Ind.aspx
                        strBEURL15[0] = "https://ef.hasil.gov.my/eBe2016/Ind.aspx";
                        strBEURL15[1] = "https://ef.hasil.gov.my/eBe2016/Ind.aspx?tab=PD";
                        strBEURL15[2] = "https://ef.hasil.gov.my/eBe2016/Ind.aspx?tab=PL";
                        strBEURL15[3] = "https://ef.hasil.gov.my/eBe2016/HK6.aspx?pg=HK6";
                        strURL = strBEURL15;
                    }

                    if (strType == "P")
                    {
                        strPURL15[0] = "https://ef.hasil.gov.my/eP2016/Mak_asas.aspx";
                        strPURL15[1] = "https://ef.hasil.gov.my/eP2016/Pendapatan.aspx";
                       // strPURL15[2] = "https://ef.hasil.gov.my/eP2016/Pendapatan2.aspx";
                        strPURL15[2] = "https://ef.hasil.gov.my/eP2016/pendapatan_lain.aspx";
                        strPURL15[3] = "https://ef.hasil.gov.my/eP2016/perbelanjaan.aspx";
                        strPURL15[4] = "https://ef.hasil.gov.my/eP2016/mak_cukai.aspx";
                        strPURL15[5] = "https://ef.hasil.gov.my/eP2016/mak_ahli_kongsi.aspx";
                        strPURL15[6] = "https://ef.hasil.gov.my/eP2016/mak_wang.aspx";
                        strPURL15[7] = "https://ef.hasil.gov.my/eP2016/mak_firma.aspx";
                        strPURL15[8] = "https://ef.hasil.gov.my/eP2016/akuan.aspx";
                        strURL = strPURL15;
                    }

                    if (strType == "M")
                    {
                        //https://ef.hasil.gov.my/eM2016/Mak_ind.aspx
                        strMURL15[0] = "https://ef.hasil.gov.my/eM2016/mak_ind.aspx";
                        strMURL15[1] = "https://ef.hasil.gov.my/eM2016/mak_pasangan.aspx";
                        strMURL15[2] = "https://ef.hasil.gov.my/eM2016/pendapatan.aspx";
                        strMURL15[3] = "https://ef.hasil.gov.my/eM2016/pend_belakang.aspx";
                        strMURL15[4] = "https://ef.hasil.gov.my/eM2016/rebat.aspx";
                        strMURL15[5] = "https://ef.hasil.gov.my/eM2016/perniagaan.aspx";
                        strMURL15[6] = "https://ef.hasil.gov.my/eM2016/khas.aspx";
                        strMURL15[7] = "https://ef.hasil.gov.my/eM2016/kewangan.aspx";
                        strMURL15[8] = "https://ef.hasil.gov.my/eM2016/mak_pentadbir.aspx";
                        strMURL15[9] = "https://ef.hasil.gov.my/eM2016/rumusan.aspx";
                        strMURL15[10] = "https://ef.hasil.gov.my/eM2016/HK6.aspx?pg=HK6";
                        strURL = strMURL15;
                    }

                    break;
                    //end simkh

                 

                case "2016":
                  String[] strCURL16 = new String[15];
                    String[] strBURL16 = new String[4];
                    String[] strBEURL16 = new String[4];
                    String[] strMURL16 = new String[11];
                    String[] strPURL16 = new String[9];

                    if (strType == "C")
                    {
                        strCURL16[0] = "https://ef.hasil.gov.my/ec2016/mak_sykt.aspx";
                        strCURL16[1] = "https://ef.hasil.gov.my/ec2016/mak_pengarah.aspx";
                        strCURL16[2] = "https://ef.hasil.gov.my/ec2016/mak_syer.aspx";
                        strCURL16[3] = "https://ef.hasil.gov.my/ec2016/pen_kanun.aspx";
                        strCURL16[4] = "https://ef.hasil.gov.my/ec2016/per_khas.aspx";
                        strCURL16[5] = "https://ef.hasil.gov.my/ec2016/tun_elaun.aspx";
                        strCURL16[6] = "https://ef.hasil.gov.my/ec2016/tun_insentif.aspx";
                        strCURL16[7] = "https://ef.hasil.gov.my/ec2016/pen_pindah.aspx";
                        strCURL16[8] = "https://ef.hasil.gov.my/ec2016/mak_wang.aspx";
                        strCURL16[9] = "https://ef.hasil.gov.my/ec2016/lain_cukai.aspx";
                        strCURL16[10] = "https://ef.hasil.gov.my/ec2016/lain_transaksi.aspx";
                        strCURL16[11] = "https://ef.hasil.gov.my/ec2016/lain_makl.aspx";
                        strCURL16[12] = "https://ef.hasil.gov.my/ec2016/juruaudit.aspx";
                        strCURL16[13] = "https://ef.hasil.gov.my/ec2016/cukai_dibayar.aspx";
                        strCURL16[14] = "https://ef.hasil.gov.my/ec2016/rkt_rks.aspx";
                        strURL = strCURL16;
                    }

                    if (strType == "R")
                    {
                        //https://ef.hasil.gov.my/eR2014PP/Dividen.aspx
                        strRURL[0] = "https://ef.hasil.gov.my/er2016PP/dividen.aspx";
                        strRURL[1] = "https://ef.hasil.gov.my/er2016PP/penyata.aspx";
                        strURL = strRURL;
                    }

                    if (strType == "B")
                    {
                        strBURL16[0] = "https://ef.hasil.gov.my/eBe2017/Ind.aspx";
                        strBURL16[1] = "https://ef.hasil.gov.my/eBe2017/Ind.aspx?tab=PD";
                        strBURL16[2] = "https://ef.hasil.gov.my/eBe2017/Ind.aspx?tab=PL";
                        strBURL16[3] = "https://ef.hasil.gov.my/eBe2017/HK6.aspx?pg=HK6";
                        strURL = strBURL16;
                    }

                    if (strType == "BE")
                    {
                        //https://ef.hasil.gov.my/eBe2016PP/Ind.aspx
                        strBEURL16[0] = "https://ef.hasil.gov.my/eBe2017/Ind.aspx";
                        strBEURL16[1] = "https://ef.hasil.gov.my/eBe2017/Ind.aspx?tab=PD";
                        strBEURL16[2] = "https://ef.hasil.gov.my/eBe2017/Ind.aspx?tab=PL";
                        strBEURL16[3] = "https://ef.hasil.gov.my/eBe2017/HK6.aspx?pg=HK6";
                        strURL = strBEURL16;
                    }

                    if (strType == "P")
                    {
                        strPURL16[0] = "https://ef.hasil.gov.my/eP2017/Mak_asas.aspx";
                        strPURL16[1] = "https://ef.hasil.gov.my/eP2017/Pendapatan.aspx";
                        // strPURL15[2] = "https://ef.hasil.gov.my/eP2017/Pendapatan2.aspx";
                        strPURL16[2] = "https://ef.hasil.gov.my/eP2017/pendapatan_lain.aspx";
                        strPURL16[3] = "https://ef.hasil.gov.my/eP2017/perbelanjaan.aspx";
                        strPURL16[4] = "https://ef.hasil.gov.my/eP2017/mak_cukai.aspx";
                        strPURL16[5] = "https://ef.hasil.gov.my/eP2017/mak_ahli_kongsi.aspx";
                        strPURL16[6] = "https://ef.hasil.gov.my/eP2017/mak_wang.aspx";
                        strPURL16[7] = "https://ef.hasil.gov.my/eP2017/mak_firma.aspx";
                        strPURL16[8] = "https://ef.hasil.gov.my/eP2017/akuan.aspx";
                        strURL = strPURL16;
                    }

                    if (strType == "M")
                    {
                        //https://ef.hasil.gov.my/eM2016/Mak_ind.aspx
                        //strMURL16[0] = "https://ef.hasil.gov.my/eM2017/Ind.aspx";
                        //strMURL16[1] = "https://ef.hasil.gov.my/eM2017/mak_pasangan.aspx";
                        //strMURL16[2] = "https://ef.hasil.gov.my/eM2017/pendapatan.aspx";
                        //strMURL16[3] = "https://ef.hasil.gov.my/eM2017/pend_belakang.aspx";
                        //strMURL16[4] = "https://ef.hasil.gov.my/eM2017/rebat.aspx";
                        //strMURL16[5] = "https://ef.hasil.gov.my/eM2017/perniagaan.aspx";
                        //strMURL16[6] = "https://ef.hasil.gov.my/eM2017/khas.aspx";
                        //strMURL16[7] = "https://ef.hasil.gov.my/eM2017/kewangan.aspx";
                        //strMURL16[8] = "https://ef.hasil.gov.my/eM2017/mak_pentadbir.aspx";
                        //strMURL16[9] = "https://ef.hasil.gov.my/eM2017/rumusan.aspx";
                        //strMURL16[10] = "https://ef.hasil.gov.my/eM2017/HK6.aspx?pg=HK6";

                        strMURL16[0] = "https://ef.hasil.gov.my/eM2017/Ind.aspx";
                        strMURL16[1] = "https://ef.hasil.gov.my/eM2017/Ind.aspx?tab=PD";
                        strMURL16[2] = "https://ef.hasil.gov.my/eM2017/Ind.aspx?tab=PL";
                        strMURL16[3] = "https://ef.hasil.gov.my/eM2017/HK6.aspx?pg=HK6";
                        strURL = strMURL16;
                    }

                    //DannyLee Feb 2015
                    if (strType == "CP204")
                    {
                        strCP204URL[0] = "https://ef.hasil.gov.my/cp204PP/cp204.aspx";
                        strURL = strCP204URL;
                    }

                    if (strType == "CP204A")
                    {
                        strCP204URL[0] = "https://ef.hasil.gov.my/cp204aPP/formcp204a.aspx";
                        strURL = strCP204URL;
                    }
                    break;
                //end DannyLee

                case "2017":
                    String[] strCURL17 = new String[15];


                    if (strType == "C")
                    {
                        strCURL17[0] = "https://ef.hasil.gov.my/ec2017/mak_sykt.aspx";
                        strCURL17[1] = "https://ef.hasil.gov.my/ec2017/mak_pengarah.aspx";
                        strCURL17[2] = "https://ef.hasil.gov.my/ec2017/mak_syer.aspx";
                        strCURL17[3] = "https://ef.hasil.gov.my/ec2017/pen_kanun.aspx";
                        strCURL17[4] = "https://ef.hasil.gov.my/ec2017/per_khas.aspx";
                        strCURL17[5] = "https://ef.hasil.gov.my/ec2017/tun_elaun.aspx";
                        strCURL17[6] = "https://ef.hasil.gov.my/ec2017/tun_insentif.aspx";
                        strCURL17[7] = "https://ef.hasil.gov.my/ec2017/pen_pindah.aspx";
                        strCURL17[8] = "https://ef.hasil.gov.my/ec2017/mak_wang.aspx";
                        strCURL17[9] = "https://ef.hasil.gov.my/ec2017/lain_cukai.aspx";
                        strCURL17[10] = "https://ef.hasil.gov.my/ec2017/lain_transaksi.aspx";
                        strCURL17[11] = "https://ef.hasil.gov.my/ec2017/lain_makl.aspx";
                        strCURL17[12] = "https://ef.hasil.gov.my/ec2017/juruaudit.aspx";
                        strCURL17[13] = "https://ef.hasil.gov.my/ec2017/cukai_dibayar.aspx";
                        strCURL17[14] = "https://ef.hasil.gov.my/ec2017/rkt_rks.aspx";
                        strURL = strCURL17;
                    }

                    //if (strType == "R")
                    //{
                    //    //https://ef.hasil.gov.my/eR2014PP/Dividen.aspx
                    //    strRURL[0] = "https://ef.hasil.gov.my/er2016PP/dividen.aspx";
                    //    strRURL[1] = "https://ef.hasil.gov.my/er2016PP/penyata.aspx";
                    //    strURL = strRURL;
                    //}

                    //DannyLee Feb 2015
                    if (strType == "CP204")
                    {
                        strCP204URL[0] = "https://ef.hasil.gov.my/CP204PP/Anggaran.aspx";
                        strURL = strCP204URL;
                    }

                    if (strType == "CP204A")
                    {
                        strCP204URL[0] = "https://ef.hasil.gov.my/cp204aPP/formcp204a.aspx";
                        strURL = strCP204URL;
                    }
                    break;
                //end DannyLee
            }
            return strURL;
        }
        #endregion

        public Boolean VerifyEFilingVersion(string strYA)
        {
            try
            {
                OdbcConnection connOdbc = new OdbcConnection();
                switch (this.strFormType)
                {
                    case "C": case "R": case "CP204": case "CP204A":
                    case "B":case "BE": case "M":
                        connOdbc = this.connOdbc;
                        break;
                    case "P":
                        connOdbc = this.connOdbcP;
                        break;
                    case "CP30":
                        connOdbc = this.connOdbc;
                        break;
                    default :
                        connOdbc = null;
                        break;
                }

                if (connOdbc != null)
                {
                    connOdbc.Open();
                    cmdOdbc = new OdbcCommand("select distinct ef_ya from efiling_url where ef_ya =? and ef_type = ?", connOdbc);
                    cmdOdbc.Parameters.Add(new OdbcParameter("@ya", strYA));
                    cmdOdbc.Parameters.Add(new OdbcParameter("@formtype", strFormType));
                    OdbcDataReader drData = cmdOdbc.ExecuteReader();
                    if (drData.HasRows) return true;
                    drData.Dispose();
                    cmdOdbc.Dispose();
                }
            }
            catch
            { return false; }
            finally
            { connOdbc.Close(); }
            return false;
        }

        public void VersionUpgrade()
        {
            DataTable dt = null;
            try
            {
                EFilingDAL dal = new EFilingDAL();
                EFilingDALB dalB = new EFilingDALB();
                EFilingDALP dalP = new EFilingDALP();
                String[] strCURL;
                String[] strRURL;
                String[] strURL;
                //PANYW CP204
                String[] strCP204;
                //PANYW CP204 END
                //NGOHCS CP204
                String[] strCP204A;
                //NGOHCS CP204 END

                if (!VerifyEFilingVersion(strYA))
                {
                    connOdbc.Open();
                    if (!(connOdbc == null))
                    {
                       dt = connOdbc.GetSchema("tables");
                    }
                    if (!(dt == null))
                    {
                        if (dt.Select("table_name='EFILING_URL'").Length > 0)
                        {
                            if (strFormType == "C" || strFormType == "R" )
                            {
                                strCURL = GetEFilingURL("C");
                                if (!(strCURL == null))
                                {
                                    if (dal.InsertURLData(strCURL, strYA, "C") <= 0)
                                        System.Windows.Forms.MessageBox.Show("Data insertion for TAXcom E-Filing has been failed!");
                                }
                                strRURL = GetEFilingURL("R");
                                if (!(strRURL == null))
                                {
                                    if (dal.InsertURLData(strRURL, strYA, "R") <= 0)
                                        System.Windows.Forms.MessageBox.Show("Data insertion for TAXcom E-Filing has been failed!");
                                }
                            }
                            else if (strFormType == "CP204")
                            {
                                //PANYW CP204
                                strCP204 = GetEFilingURL("CP204");
                                if (!(strCP204 == null))
                                {
                                    if (dal.InsertURLData(strCP204, strYA, "CP204") <= 0)
                                        System.Windows.Forms.MessageBox.Show("Data insertion for TAXcom E-Filing has been failed!");
                                }
                                //PANYW CP204 END
                            }
                            else if (strFormType == "CP204A")
                            {
                                //NGOHCS CP204A
                                strCP204A = GetEFilingURL("CP204A");
                                if (!(strCP204A == null))
                                {
                                    if (dal.InsertURLData(strCP204A, strYA, "CP204A") <= 0)
                                        System.Windows.Forms.MessageBox.Show("Data insertion for TAXcom E-Filing has been failed!");
                                }
                                //NGOHCS CP204A END
                            }
                            else if(strFormType == "B" || strFormType == "BE" || strFormType == "M")
                            {
                                strURL = GetEFilingURL(strFormType);
                                if (!(strURL == null))
                                {
                                    if (dalB.InsertURLData(strURL, strYA, strFormType) <= 0)
                                        System.Windows.Forms.MessageBox.Show("Data insertion for TAXcom E-Filing has been failed!");
                                }
                            }
                            else if (strFormType == "P")
                            {
                                strURL = GetEFilingURL(strFormType);
                                if (!(strURL == null))
                                {
                                    if (dalP.InsertURLData(strURL, strYA, strFormType) <= 0)
                                        System.Windows.Forms.MessageBox.Show("Data insertion for TAXcom E-Filing has been failed!");
                                }
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

    }
}

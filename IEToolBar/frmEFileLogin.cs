using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IEToolBar
{
    public partial class frmTaxAgentLogIn : Form
    {
        public frmTaxAgentLogIn()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtURL.Text.Trim().Length > 0)
            {
                EFilingPublic dalSave = new EFilingPublic();
                int intStatus = 0;
                string[] strData = new string[2];
                strData[0] = this.txtURL.Text.Trim().ToLower(); ;
                strData[1] = "Q0000PageX";

                intStatus = dalSave.Execute(strData, "UPD");
                if (intStatus > 0)
                {
                    MessageBox.Show("URL updated!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Updates of URL failed!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Please complete the url!", "TAXcom E-Filing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTaxAgentLogIn_Load(object sender, EventArgs e)
        {
            EFilingPublic dalLoad = new EFilingPublic();
            string strURL = "";
            strURL = dalLoad.GetURL("Q0000PageX");
            this.txtURL.Text = strURL;
        }

    }
}
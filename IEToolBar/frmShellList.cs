using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IEToolBar
{
    public partial class frmShellList : Form
    {

        public frmShellList(SHDocVw.ShellWindows swTemp, string strDocName)
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            int count = 0;
            dt.Columns.Add("No");
            dt.Columns.Add("strDocName");
            dt.Columns.Add("url");
            dt.Columns.Add("Name");
            dt.Columns.Add("FullName");
            foreach (SHDocVw.InternetExplorer ieTemp in swTemp)
            {

                count += 1;
                dt.Rows.Add(count,strDocName, ieTemp.LocationURL.ToString().ToLower(),ieTemp.LocationName,ieTemp.FullName );
       
            }
            dataGridView1.DataSource = dt;

        }

        private void frmShellList_Load(object sender, EventArgs e)
        {

        }

    }
}
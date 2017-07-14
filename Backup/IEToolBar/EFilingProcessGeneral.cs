using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace IEToolBar
{
    class EFilingProcessGeneral
    {
        mshtml.HTMLDocument htmlDoc;
        public EFilingProcessGeneral()
        {
        }

        public string RefreshForm(SHDocVw.InternetExplorer ieTemp)
        {
            string href = "";
            if (ieTemp.ReadyState.Equals(SHDocVw.tagREADYSTATE.READYSTATE_COMPLETE))
            {
                if (typeof(mshtml.HTMLDocumentClass).IsAssignableFrom(ieTemp.Document.GetType()))
                {
                    htmlDoc = ieTemp.Document as mshtml.HTMLDocument;
                }
            }

            if (htmlDoc != null)
            {
                foreach (mshtml.HTMLFormElement frmElement in htmlDoc.getElementsByTagName("form"))
                {
                    if (frmElement.action.Length > 0)
                    {
                        href = htmlDoc.url.Substring(0, (htmlDoc.url.LastIndexOf("\\") + 1)) + frmElement.action;//+ ".aspx"
                        //if (frmElement.action.ToLower() == System.Drawing.Color.LightYellow.Name.ToLower())
                        //{
                        //    if (arcElement.href != null)
                        //    {
                        //        href = arcElement.href;
                        //    }
                        //}
                    }
                }
                //foreach (mshtml.HTMLAnchorElement arcElement in htmlDoc.getElementsByTagName("a"))
                //{
                //    if (arcElement.style.backgroundColor != null)
                //    {
                //        if (arcElement.style.backgroundColor.ToString().ToLower() == System.Drawing.Color.LightYellow.Name.ToLower())
                //        {
                //            //arcElement.click();
                //            if (arcElement.href != null)
                //            {
                //                href = arcElement.href;
                //            }
                //        }
                //    }
                //}
            }
            return href;
        }

        //public string RefreshForm(mshtml.HTMLDocument htmlDoc)
        //{
        //    string href = "";
        //    foreach (mshtml.HTMLAnchorElement arcElement in htmlDoc.getElementsByTagName("a"))
        //    {
        //        if (arcElement.style.backgroundColor != null)
        //        {
        //            if (arcElement.style.backgroundColor.ToString().ToLower() == System.Drawing.Color.LightYellow.Name.ToLower())
        //            {
        //                //arcElement.click();
        //                if (arcElement.href != null)
        //                {
        //                    href = arcElement.href;
        //                }
        //            }
        //        }
        //    }
        //    return href;
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WatiN.Core;

namespace Peerfx.Testing
{
    
    public class watin
    {
        [STAThread]


        public void TryScrape()
        {

            using (var browser = new FireFox("http://www.tradepfx.com/login.aspx"))
            {
                browser.TextField(Find.ByName("ctl00$Main$txtemail")).TypeText("lorne@lornestar.com");
                browser.Button(Find.ByName("ctl00$Main$btnLogin")).Click();

                string strtemp = browser.ToString();
                //Assert.IsTrue(browser.ContainsText("WatiN"));
            }
        }
    }
}
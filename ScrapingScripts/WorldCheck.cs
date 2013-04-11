using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WatiN.Core;

namespace Peerfx.ScrapingScripts
{
    public class WorldCheck
    {
        [STAThread]

        public string PassportCheck()
        {
            string strreturn = "";
            using (var browser = new IE("https://www.world-check.com/portal/mod_perl/Login/"))
            {
                if (Find.ByName("username"))
                {
                    browser.TextField(Find.ByName("username")).TypeText("nzrbrt0002");
                    browser.TextField(Find.ByName("password")).TypeText("Go8ahE5s");
                    browser.Image(Find.ByName("submitted")).Click();
                }
                                
                browser.GoTo("https://www.world-check.com/portal/mod_perl/PassportCheck");

                browser.TextField(Find.ByName("givenName")).TypeText("Jim");
                browser.TextField(Find.ByName("lastName")).TypeText("Smith");
                browser.RadioButton(Find.ByName("sexg") && Find.ByValue("M")).Click();
                browser.Span(Find.ById("issuingState-CAN")).Click();
                browser.TextField(Find.ByName("dateOfBirthDay")).TypeText("29");
                browser.TextField(Find.ByName("dateOfBirthMonth")).TypeText("05");
                browser.TextField(Find.ByName("dateOfBirthYear")).TypeText("1978");
                browser.TextField(Find.ByName("passportNumber")).TypeText("WL745488");
                browser.TextField(Find.ByName("expireDateDay")).TypeText("10");
                browser.TextField(Find.ByName("expireDateMonth")).TypeText("07");
                browser.TextField(Find.ByName("expireDateYear")).TypeText("2014");
                browser.Button(Find.ByValue("VERIFY")).Click();

                var element = browser.Element(Find.ByClass("tablelinespacer"));                
                var firsttd = element.NextSibling.NextSibling;
                strreturn = firsttd.Text.Replace("Lower Line:","");
                //Assert.IsTrue(browser.ContainsText("WatiN"));
            }
            return strreturn;
        }
    }
}
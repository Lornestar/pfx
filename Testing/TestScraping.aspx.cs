using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Collections.Specialized;
using System.Text;
using WatiN.Core;
using System.Threading;

namespace Peerfx.Testing
{
    public partial class TestScraping : System.Web.UI.Page
    {
        
        string URL = "https://www.cloudflare.com/login";
        protected void Page_Load(object sender, EventArgs e)
        {
            //SendRequest();
            watin wa = new watin();
            
            
            var t = new Thread(new ThreadStart(wa.TryScrape));
            t.SetApartmentState(ApartmentState.STA);            
            t.Start();
            
            // Run synchronously by waiting for t to finish.
            t.Join();
            t.Abort();
        }

        

        private void SendRequest()
        {
            try
            {
                WebClient webClient = new WebClient();

                // Create a new NameValueCollection instance to hold some custom parameters to be posted to the URL.
                NameValueCollection vars = new NameValueCollection();

                // Add necessary parameter/value pairs to the name/value container.
                vars.Add("login_email", "lorne@lornestar.com");
                vars.Add("login_pass", "x339211x");
                vars.Add("send_to", "");
                vars.Add("act", "login");

                // Upload the NameValueCollection.
                byte[] responseArray = webClient.UploadValues(URL, "POST", vars);
                //string response = Encoding.ASCII.GetString( responseArray);
                // Save the response.
                string fileName = "webRequest.html";
                string filePath = "c:/";
                System.IO.File.WriteAllBytes(System.IO.Path.Combine(filePath, fileName), responseArray);

            }
            catch (Exception ee)
            {
                // Log error (omitted for brevity)
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace Peerfx.User_Controls
{
    public partial class ViewUploadedPics : System.Web.UI.UserControl
    {
        Site sitetemp = new Site();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void LoadPics(string virtualfolder)
        {
            string folder =  HttpContext.Current.Server.MapPath(virtualfolder);
            DataTable dttemp = sitetemp.GetImagesinDirectory(folder, virtualfolder);
            RadListView1.DataSource = dttemp;
            RadListView1.DataBind();
        }

    }
}
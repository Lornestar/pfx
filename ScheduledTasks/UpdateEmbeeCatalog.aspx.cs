using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Peerfx.ScheduledTasks
{
    public partial class UpdateEmbeeCatalog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Peerfx.External_APIs.Embee embee = new External_APIs.Embee();
            embee.UpdateCatalog();
        }
    }
}
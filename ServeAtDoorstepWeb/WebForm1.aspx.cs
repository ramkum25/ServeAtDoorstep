using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServeAtDoorstepWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
             ClientScript.RegisterStartupScript(this.GetType(), "initMap", string.Format("initMap();"), true);
            //ClientScript.RegisterStartupScript(this.GetType(), "addMarker" + i, string.Format("addMarker({0}: {1}: {2});", dataTable.Rows[i]["latitude"].ToString(), dataTable.Rows[i]["longitude"].ToString(), FinalAddress.ToString()), true);

        }
    }
}
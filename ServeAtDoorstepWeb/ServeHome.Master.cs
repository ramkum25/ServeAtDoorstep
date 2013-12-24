using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServeAtDoorstepWeb
{
    public partial class ServeHome : System.Web.UI.MasterPage
    {
        public string isShowHideControl = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["LoginType"] != null)
            {
                Session.Add("LoginType", Request.Cookies["LoginType"].Value.ToString());
            }
            if (Request.Cookies["LoginId"] != null)
            {
                Session.Add("LoginId", Request.Cookies["LoginId"].Value.ToString());
            }

            if (Session["LoginId"] != null && (Session["LoginType"] != null && Session["LoginType"].ToString() == "3"))
            {
                isShowHideControl = "3"; // Admin
            }
            else if (Session["LoginId"] != null && (Session["LoginType"] != null && Session["LoginType"].ToString() == "2"))
            {
                isShowHideControl = "2"; // Vendor
            }
            else if (Session["LoginId"] != null && (Session["LoginType"] != null && Session["LoginType"].ToString() == "1"))
            {
                isShowHideControl = "1"; // Customer
            }
            else if (Session["LoginId"] == null)
            {
                isShowHideControl = "0";
            }
            else
            {
                //isShowHideControl = "0";
            }

        }
    }
}
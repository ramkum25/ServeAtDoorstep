using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServeAtDoorstepWeb
{
    public partial class ServeMaster : System.Web.UI.MasterPage
    {
        public string isShowHideControl = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            isShowHideControl = "0";
            lblWelcomeMsg.Visible = false;
            lblDashboard.Visible = false;

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
                lblWelcomeMsg.Visible = true;
                lblDashboard.Visible = true;
                isShowHideControl = "3"; // Admin
            }
            else if (Session["LoginId"] != null && (Session["LoginType"] != null && Session["LoginType"].ToString() == "2"))
            {
                lblWelcomeMsg.Visible = true;
                lblDashboard.Visible = true;
                isShowHideControl = "2"; // Vendor
            }
            else if (Session["LoginId"] != null && (Session["LoginType"] != null && Session["LoginType"].ToString() == "1"))
            {
                lblWelcomeMsg.Visible = true;
                lblDashboard.Visible = true;
                isShowHideControl = "1"; // Customer
            }
        }

        protected void lblDashboard_Click(object sender, EventArgs e)
        {
            if (Session["LoginType"].ToString() == "1")
                Response.Redirect("MyCustomerDash.aspx");
            else if (Session["LoginType"].ToString() == "2")
                Response.Redirect("MyVendorDash.aspx");
            else if (Session["LoginType"].ToString() == "3")
                Response.Redirect("MyAdminDash.aspx");
        }
    }
}
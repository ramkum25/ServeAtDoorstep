using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServeAtDoorstepServiceApp;

namespace ServeAtDoorstepWeb
{
    public partial class ServeMaster : System.Web.UI.MasterPage
    {
        public string isShowHideControl = string.Empty;
        public string strLoginId = string.Empty;
        public string strLoginType = string.Empty;
        public string strLoginName = string.Empty;
        public ServeAtDoorstepService objService = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            isShowHideControl = "0";
            lblWelcomeMsg.Visible = false;
            lblDashboard.Visible = false;
            btnPostButton.Visible = false;

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
                btnPostButton.Visible = false;
                isShowHideControl = "3"; // Admin
            }
            else if (Session["LoginId"] != null && (Session["LoginType"] != null && Session["LoginType"].ToString() == "2"))
            {
                lblWelcomeMsg.Visible = true;
                lblDashboard.Visible = true;
                btnPostButton.Visible = false;
                isShowHideControl = "2"; // Vendor
            }
            else if (Session["LoginId"] != null && (Session["LoginType"] != null && Session["LoginType"].ToString() == "1"))
            {
                lblWelcomeMsg.Visible = true;
                lblDashboard.Visible = true;
                btnPostButton.Visible = true;
                isShowHideControl = "1"; // Customer
            }

            if (Session["LoginId"] != null)
                strLoginId = Session["LoginId"].ToString();
            if (Session["LoginType"] != null)
                strLoginType = Session["LoginType"].ToString();
        
            if(strLoginType == "1")
            {
                objService = new ServeAtDoorstepService();
                DataTable dt = objService.GetCustomerById(Convert.ToInt32(strLoginId));
                if (dt.Rows.Count > 0)
                {
                    strLoginName = dt.Rows[0]["LoginName"].ToString();
                }

                lblWelcomeMsg.Text = "Welcome " + strLoginName;
            }
            else if (strLoginType == "2")
            {
                objService = new ServeAtDoorstepService();
                DataTable dt = objService.GetVendorById(Convert.ToInt32(strLoginId));
                if (dt.Rows.Count > 0)
                {
                    strLoginName = dt.Rows[0]["LoginName"].ToString();
                }

                lblWelcomeMsg.Text = "Welcome " + strLoginName;
            }
            else if (strLoginType == "3")
            {
                lblWelcomeMsg.Text = "Welcome Admin";

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

        protected void btnPostButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("PostQuote.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServeAtDoorstepData;
using ServeAtDoorstepServiceApp;
using System.Web.Services;
using System.Web.Script.Services;

namespace ServeAtDoorstepWeb
{
    public partial class MyVendorDash : System.Web.UI.Page
    {
        ServeAtDoorstepService objService = null;
        string sLoginType = "", sLoginId = "";
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
            if (Session["LoginType"] != null)
            {
                sLoginType = Session["LoginType"].ToString();
            }
            if (Session["LoginId"] != null)
            {
                sLoginId = Session["LoginId"].ToString();
            }

            if (!IsPostBack)
            {
                LoadVendorCount();
            }
        }

        void LoadVendorCount()
        {
            DataTable dtCusCount = null;
            objService = new ServeAtDoorstepService();
            if (sLoginType == "2")
                dtCusCount = objService.GetVendorCountById(Convert.ToInt32(sLoginId));

            if (dtCusCount != null)
            {
                if (dtCusCount.Rows.Count > 0)
                {
                    lnkLiveQuiryCnt.Text = "(" + dtCusCount.Rows[0]["LiveInqCount"].ToString() + ")";
                    lnkQuiryRespondCnt.Text = "(" + dtCusCount.Rows[0]["RespondMsgCount"].ToString() + ")";
                }
            }
        }
        protected void lnkLiveQuiry_Click(object sender, EventArgs e)
        {
            Response.Redirect("InboxVendor.aspx");
        }

        protected void lnkQuiryRespond_Click(object sender, EventArgs e)
        {
            Response.Redirect("InboxVendor.aspx?stab=respond");

        }
    }
}
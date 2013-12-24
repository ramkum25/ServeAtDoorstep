using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServeAtDoorstepCommon;
using ServeAtDoorstepServiceApp;
using ServeAtDoorstepData;

namespace ServeAtDoorstepWeb
{
    public partial class Activation : System.Web.UI.Page
    {
        public string strType = "", strId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ServeAtDoorstepServiceApp.ServeAtDoorstepService objService = new ServeAtDoorstepService();

            if (Request.QueryString["type"] != null)
            {
                strType = Request.QueryString["type"].ToString();
            }
            if (Request.QueryString["id"] != null)
            {
                strId = Request.QueryString["id"].ToString();
            }
            strId = strId.Replace(" ", "+");
            int intId = Convert.ToInt32(UtilityClass.Decrypt(strId));

            if (strType == "cus")
            {
               bool boolAct = objService.ActivateCustomer(intId);
            }
            else if (strType == "ven")
            {
                bool boolAct = objService.ActivateVendor(intId);
            }
        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            if (strType == "cus")
                Response.Redirect("LoginCustomer.aspx");
            else if (strType == "ven")
                Response.Redirect("LoginVendor.aspx");

        }
    }
}
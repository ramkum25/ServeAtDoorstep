using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServeAtDoorstepServiceApp;
using ServeAtDoorstepData;

namespace ServeAtDoorstepWeb
{
    public partial class index : System.Web.UI.Page
    {
        string sType = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int intErr = 0;
            LoginDetails objLogDetails = new LoginDetails();
            objLogDetails.UserName = txtUsername.Value.ToString();
            objLogDetails.UserPassword = txtUserpassword.Value.ToString();

            if (Request.Form["rdoLogType"] != null)
                sType = Request.Form["rdoLogType"].ToString();
            else if (Request.Form["rdoLogType"] == null && txtUsername.Value.ToString().ToLower() == "admin")
                sType = "3";
            else
                sType = "0";
            try
            {
                if (Request.Form["rdoLogType"] == null && txtUsername.Value.ToString().ToLower() != "admin")
                {
                    intErr = 1;
                    divErrMsg.InnerText = "Please Select Login type.";
                    divErrMsg.Visible = true;
                }
                else
                {
                    int intLogId = 0;
                    ServeAtDoorstepService objService = new ServeAtDoorstepService();
                    if (sType == "1")
                        intLogId = objService.LoginCustomer(objLogDetails);
                    if (sType == "2")
                        intLogId = objService.LoginVendor(objLogDetails);
                    if (sType == "3")
                        intLogId = objService.LoginCustomer(objLogDetails);

                    if (string.IsNullOrEmpty(intLogId.ToString().Trim()))
                    {
                        intErr = 1;
                        divErrMsg.InnerText = "Invalid Loginname and Password! Please try again.";
                        divErrMsg.Visible = true;
                    }
                    else
                    {
                        Session.Abandon();
                        Session.RemoveAll();

                        Session.Add("LoginId", intLogId.ToString());
                        Session.Add("LoginType", sType);

                        if (chkAgree.Checked == true)
                        {
                            HttpCookie cLoginId = new HttpCookie("LoginId", intLogId.ToString().Trim());
                            HttpCookie cLoginType = new HttpCookie("LoginType", sType);
                            cLoginId.Expires = DateTime.Now.AddDays(5);
                            cLoginType.Expires = DateTime.Now.AddDays(5);

                            Response.Cookies.Add(cLoginId);
                            Response.Cookies.Add(cLoginType);

                            HttpCookie cLoginName = new HttpCookie("LoginName", txtUsername.Value.ToString().Trim());
                            HttpCookie cPassword = new HttpCookie("Password", txtUserpassword.Value.ToString().Trim());
                            cLoginName.Expires = DateTime.Now.AddDays(5);
                            cPassword.Expires = DateTime.Now.AddDays(5);

                            Response.Cookies.Add(cLoginName);
                            Response.Cookies.Add(cPassword);
                        }
                    }
                }
            }
            catch (System.Threading.ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                divErrMsg.InnerText = ex.Message.ToString();
                intErr = 1;
            }

            if (intErr == 0 && Session["LoginType"].ToString() == "1")
                Response.Redirect("MyCustomerDash.aspx");
            else if (intErr == 0 && Session["LoginType"].ToString() == "2")
                Response.Redirect("MyVendorDash.aspx");
            else if (intErr == 0 && Session["LoginType"].ToString() == "3")
                Response.Redirect("MyAdminDash.aspx");
        }

        protected void btnVendor_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterVendor.aspx");
        }

        protected void btnCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterCustomer.aspx");
        }
    }
}
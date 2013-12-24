using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls;
using ServeAtDoorstepServiceApp;
using ServeAtDoorstepData;

namespace ServeAtDoorstepWeb
{
    public partial class LoginVendor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int intErr = 0;
            LoginDetails objLogDetails = new LoginDetails();
            objLogDetails.UserName = txtUsername.Value.ToString();
            objLogDetails.UserPassword = txtUserpassword.Value.ToString();

            try
            {
                ServeAtDoorstepService objService = new ServeAtDoorstepService();
                int intVenId = objService.LoginVendor(objLogDetails);

                if (string.IsNullOrEmpty(intVenId.ToString().Trim()))
                {
                    intErr = 1;
                    divErrMsg.InnerText = "Invalid Loginname and Password! Please try again.";
                    divErrMsg.Visible = true;
                }
                else
                {
                    Session.Abandon();
                    Session.RemoveAll();

                    if (Session["LoginId"] == null)
                        Session.Add("LoginId", intVenId.ToString());
                    else
                        Session.Add("LoginId", intVenId.ToString());

                    if (Session["LoginType"] == null)
                        Session.Add("LoginType", "2");
                    Session.Add("IsLoginUser", "true");

                    // Use this line when you want to save a cookie
                    Response.Cookies["TIS"].Value = intVenId.ToString() + ";" + "true";

                    // How long will cookie exist on client hard disk
                    Response.Cookies["TIS"].Expires = DateTime.Now.AddDays(10);

                    HttpCookie cLoginId = new HttpCookie("LoginId", intVenId.ToString().Trim());
                    HttpCookie cLoginType = new HttpCookie("LoginType", "2");
                    cLoginId.Expires = DateTime.Now.AddDays(5);
                    cLoginType.Expires = DateTime.Now.AddDays(5);
                    Response.Cookies.Add(cLoginId);
                    Response.Cookies.Add(cLoginType);

                    if (chkAgree.Checked == true)
                    {
                        //Response.Cookies.Clear();
                        HttpCookie cLoginName = new HttpCookie("LoginName", txtUsername.Value.ToString().Trim());
                        HttpCookie cPassword = new HttpCookie("Password", txtUserpassword.Value.ToString().Trim());
                        cLoginName.Expires = DateTime.Now.AddDays(5);
                        cPassword.Expires = DateTime.Now.AddDays(5);

                        Response.Cookies.Add(cLoginName);
                        Response.Cookies.Add(cPassword);
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

            if (intErr == 0)
                Response.Redirect("MyVendorHome.aspx");
        
        }
    }
}
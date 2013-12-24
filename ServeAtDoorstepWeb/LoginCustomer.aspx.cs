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
    public partial class LoginCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            int intErr=0;
            LoginDetails objLogDetails = new LoginDetails();
            objLogDetails.UserName = txtUsername.Value.ToString();
            objLogDetails.UserPassword = txtUserpassword.Value.ToString();

            try
            {
                ServeAtDoorstepService objService = new ServeAtDoorstepService();
                int intCusId = objService.LoginCustomer(objLogDetails);

                if (string.IsNullOrEmpty(intCusId.ToString().Trim()))
                {
                    intErr = 1;
                    divErrMsg.InnerText = "Invalid Loginname and Password! Please try again.";
                    divErrMsg.Visible = true;
                }
                else
                {
                    Session.Abandon();
                    Session.RemoveAll();

                    Session.Add("LoginId", intCusId.ToString());
                    Session.Add("LoginType", "1");

                    if (chkAgree.Checked == true)
                    {
                        HttpCookie cLoginId = new HttpCookie("LoginId", intCusId.ToString().Trim());
                        HttpCookie cLoginType = new HttpCookie("LoginType", "1");
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
            catch (System.Threading.ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                divErrMsg.InnerText = ex.Message.ToString();
                intErr = 1;
            }

            if (intErr == 0)
                Response.Redirect("MyCustomerHome.aspx");
        }
    }
}
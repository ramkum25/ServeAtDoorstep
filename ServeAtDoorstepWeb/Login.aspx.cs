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
    public partial class Login : System.Web.UI.Page
    {
        string sType = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void btnVendor_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterVendor.aspx");
        }

        protected void btnCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterCustomer.aspx");
        }

        protected void btnVenLogin_Click(object sender, EventArgs e)
        {
            int intErr = 0;
            LoginDetails objLogDetails = new LoginDetails();
            objLogDetails.UserName = txtVUsername.Value.ToString();
            objLogDetails.UserPassword = txtVUserpassword.Value.ToString();

            //if (Request.Form["rdoLogType"] != null)
            //    sType = Request.Form["rdoLogType"].ToString();
            //else 
            if (txtVUsername.Value.ToString().ToLower() == "admin")
                sType = "3";
            else
                sType = "2";
            try
            {
                //if (Request.Form["rdoLogType"] == null && txtCUsername.Value.ToString().ToLower() != "admin")
                //{
                //    intErr = 1;
                //    divCusErrMsg.InnerText = "Please Select Login type.";
                //    divCusErrMsg.Visible = true;
                //}
                //else
                {
                    int intLogId = 0;
                    ServeAtDoorstepService objService = new ServeAtDoorstepService();
                    if (sType == "1")
                        intLogId = objService.LoginCustomer(objLogDetails);
                    if (sType == "2")
                        intLogId = objService.LoginVendor(objLogDetails);
                    if (sType == "3")
                        intLogId = objService.LoginAdmin(objLogDetails);

                    if (string.IsNullOrEmpty(intLogId.ToString().Trim()))
                    {
                        intErr = 1;
                        divVenErrMsg.InnerText = "Invalid Loginname and Password! Please try again.";
                        divVenErrMsg.Visible = true;
                    }
                    else
                    {
                        Session.Abandon();
                        Session.RemoveAll();

                        Session.Add("LoginId", intLogId.ToString());
                        Session.Add("LoginType", sType);

                        if (chkVenAgree.Checked == true)
                        {
                            HttpCookie cLoginId = new HttpCookie("LoginId", intLogId.ToString().Trim());
                            HttpCookie cLoginType = new HttpCookie("LoginType", sType);
                            cLoginId.Expires = DateTime.Now.AddDays(5);
                            cLoginType.Expires = DateTime.Now.AddDays(5);

                            Response.Cookies.Add(cLoginId);
                            Response.Cookies.Add(cLoginType);

                            HttpCookie cLoginName = new HttpCookie("LoginName", txtVUsername.Value.ToString().Trim());
                            HttpCookie cPassword = new HttpCookie("Password", txtVUserpassword.Value.ToString().Trim());
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
                divVenErrMsg.InnerText = ex.Message.ToString();
                intErr = 1;
            }

            if (intErr == 0 && Session["LoginType"].ToString() == "1")
                Response.Redirect("MyCustomerDash.aspx");
            else if (intErr == 0 && Session["LoginType"].ToString() == "2")
                Response.Redirect("MyVendorDash.aspx");
            else if (intErr == 0 && Session["LoginType"].ToString() == "3")
                Response.Redirect("MyAdminDash.aspx");

        }

        protected void btnCusLogin_Click(object sender, EventArgs e)
        {
            int intErr = 0;
            LoginDetails objLogDetails = new LoginDetails();
            objLogDetails.UserName = txtCUsername.Value.ToString();
            objLogDetails.UserPassword = txtCUserpassword.Value.ToString();

            //if (Request.Form["rdoLogType"] != null)
            //    sType = Request.Form["rdoLogType"].ToString();
            //else 
            if (txtCUsername.Value.ToString().ToLower() == "admin")
                sType = "3";
            else
                sType = "1";
            try
            {
                //if (Request.Form["rdoLogType"] == null && txtCUsername.Value.ToString().ToLower() != "admin")
                //{
                //    intErr = 1;
                //    divCusErrMsg.InnerText = "Please Select Login type.";
                //    divCusErrMsg.Visible = true;
                //}
                //else
                {
                    int intLogId = 0;
                    ServeAtDoorstepService objService = new ServeAtDoorstepService();
                    if (sType == "1")
                        intLogId = objService.LoginCustomer(objLogDetails);
                    if (sType == "2")
                        intLogId = objService.LoginVendor(objLogDetails);
                    if (sType == "3")
                        intLogId = objService.LoginAdmin(objLogDetails);

                    if (string.IsNullOrEmpty(intLogId.ToString().Trim()))
                    {
                        intErr = 1;
                        divCusErrMsg.InnerText = "Invalid Loginname and Password! Please try again.";
                        divCusErrMsg.Visible = true;
                    }
                    else
                    {
                        Session.Abandon();
                        Session.RemoveAll();

                        Session.Add("LoginId", intLogId.ToString());
                        Session.Add("LoginType", sType);
                        HttpCookie cLoginId = new HttpCookie("LoginId", intLogId.ToString().Trim());
                        HttpCookie cLoginType = new HttpCookie("LoginType", sType);
                        cLoginId.Expires = DateTime.Now.AddDays(5);
                        cLoginType.Expires = DateTime.Now.AddDays(5);

                        Response.Cookies.Add(cLoginId);
                        Response.Cookies.Add(cLoginType);

                        if (chkCusAgree.Checked == true)
                        {
                            HttpCookie cLoginName = new HttpCookie("LoginName", txtCUsername.Value.ToString().Trim());
                            HttpCookie cPassword = new HttpCookie("Password", txtCUserpassword.Value.ToString().Trim());
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
                divCusErrMsg.InnerText = ex.Message.ToString();
                intErr = 1;
            }

            if (intErr == 0 && Session["LoginType"].ToString() == "1")
                Response.Redirect("MyCustomerDash.aspx");
            else if (intErr == 0 && Session["LoginType"].ToString() == "2")
                Response.Redirect("MyVendorDash.aspx");
            else if (intErr == 0 && Session["LoginType"].ToString() == "3")
                Response.Redirect("MyAdminDash.aspx");

        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServeAtDoorstepServiceApp;
using ServeAtDoorstepCommon;


namespace ServeAtDoorstepWeb
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        string sType = "";
        ServeAtDoorstepService objService = null;

        public int intCustomerAvail = 0, intMailAvail = 0, intVaidError = 0;
        public string strErrorMessage = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["type"]!=null)
            {
                sType = Request.QueryString["type"].ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            intVaidError = 0;
            if (!IsEmailValid(txtEmail.Text.ToString()))
            {
                intVaidError++;
                strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;E mail address is not valid.<br />";
            }
            MailCheck();
            if (intMailAvail == 0)
            {
                intVaidError++;
                strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;E mail address does not exists.<br />";
            }

            if (intVaidError == 0)
            {
                try
                {
                    string serverPath = ConfigurationManager.AppSettings["ApplicationPath"].ToString() + "/Login.aspx";
                    DataTable dtCV = null; 
                    ServeAtDoorstepService obj = new ServeAtDoorstepService();
                    if (sType == "cus")
                        dtCV = obj.ForgotPasswordCus(txtEmail.Text.Trim());
                    else if (sType == "ven")
                        dtCV = obj.ForgotPasswordVen(txtEmail.Text.Trim());
                    string sLoginName = "";
                    string sLoginPassword = "";
                    if (dtCV.Rows.Count>0)
                    {
                        sLoginName = dtCV.Rows[0][""].ToString();
                        sLoginPassword = dtCV.Rows[0][""].ToString();
                    }

                    ServeAtDoorstepData.SendMailDetails objMail = new ServeAtDoorstepData.SendMailDetails();
                    objMail.MailID = txtEmail.Text.Trim();
                    objMail.MailSubject = "Serve At Doorstep Password request";
                    objMail.MailContent = "<html><body><form id='form1' runat='server'><div>" +
                    "Dear " + sLoginName + ",<br /><br />As you request, your username and password is given below:<br><br>" +
                    "<b>UserName : " + sLoginName + "<br>Password : " + sLoginPassword + "</b>" +
                    "<br /><br />Now you can login with Serve At Doorstep<br />" +
                    "<a href='" + serverPath + "' runat='server' >" + serverPath + "</a>" +
                    "<br /><br />All the best,<br />Serve At Doorstep.</div></form></body></html>";

                    obj.DoSendMail(objMail);

                    divMessage.InnerHtml = "Password sent to your " + txtEmail.Text + ".<br/><img src='image/Mail Reply.png' height='25px' width='25px' />&nbsp;Goto your inbox";
                    txtEmail.Text = "";
                }
                catch (SqlException sqlEx)
                {
                    divErrorMessage.InnerHtml = "<img src='image/warning.png' height='25px' width='25px' />&nbsp;" + sqlEx.Message.ToString();
                }
                catch (Exception ex)
                {
                    divErrorMessage.InnerHtml = "<img src='image/warning.png' height='25px' width='25px' />&nbsp;" + ex.Message.ToString();
                }
            }
            else
            {
                divErrorMessage.InnerHtml = strErrorMessage;
            }
        }

        public bool IsEmailValid(string Email)
        {
            string strRegex = "^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}" + "\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\" + ".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(Email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void MailCheck()
        {
            objService = new ServeAtDoorstepService();
            DataTable dt = null;
            if (sType == "cus")
                dt = objService.AvailableCusMail(txtEmail.Text.ToString().Trim());
            else if (sType == "ven")
                dt = objService.AvailableVenMail(txtEmail.Text.ToString().Trim());
            if (dt.Rows.Count == 0)
            {
                intMailAvail = 0;
            }
            else
            {
                intMailAvail = 1;
            }
        }

    }
}
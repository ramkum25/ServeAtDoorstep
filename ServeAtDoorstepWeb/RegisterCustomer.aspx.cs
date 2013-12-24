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
    public partial class RegisterUser : System.Web.UI.Page
    {
        ServeAtDoorstepService objService = null;

        public int intCustomerAvail = 0, intMailAvail = 0, intVaidError = 0;
        public string strErrorMessage = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadCountry();
                LoadState();
                LoadCity();
            }
        }

        #region .. LOAD COMBO BOX ..

        void LoadCountry()
        {
            ddlCountry.Items.Clear();
            objService = new ServeAtDoorstepService();
            DataTable dt1 = objService.SelectAllCountry();
            ListItem listItem = new ListItem();
            listItem.Text = "<Select Country>";
            listItem.Value = "0";
            ddlCountry.Items.Add(listItem);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                listItem = new ListItem();
                listItem.Text = dt1.Rows[i]["CountryName"].ToString();
                listItem.Value = dt1.Rows[i]["CountryId"].ToString();
                ddlCountry.Items.Add(listItem);
            }
        }

        void LoadCity()
        {
            ddlCity.Items.Clear();
            objService = new ServeAtDoorstepService();
            DataTable dt1 = objService.SelectAllCity();
            ListItem listItem = new ListItem();
            listItem.Text = "<Select City>";
            listItem.Value = "0";
            ddlCity.Items.Add(listItem);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                listItem = new ListItem();
                listItem.Text = dt1.Rows[i]["CityName"].ToString();
                listItem.Value = dt1.Rows[i]["CityId"].ToString();
                ddlCity.Items.Add(listItem);
            }
        }

        void LoadState()
        {
            ddlState.Items.Clear();
            objService = new ServeAtDoorstepService();
            DataTable dt1 = objService.SelectAllState();
            ListItem listItem = new ListItem();
            listItem.Text = "<Select State>";
            listItem.Value = "0";
            ddlState.Items.Add(listItem);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                listItem = new ListItem();
                listItem.Text = dt1.Rows[i]["StateName"].ToString();
                listItem.Value = dt1.Rows[i]["StateId"].ToString();
                ddlState.Items.Add(listItem);
            }
        }

        #endregion

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            strErrorMessage = "";
            intVaidError = 0;
            CheckValidation();

            if (fileProfile.HasFile)
            {
                if (fileProfile.PostedFile.ContentLength > 1048576)
                {
                    strErrorMessage += "Image size exceeds maximum limit 1 MB.<br />";
                    intVaidError++;
                }
            }
            if (intVaidError == 0)
            {
                string path = string.Empty;
                string strImgFinalPath = "";
                string finalPath = string.Empty;
                string filePath = string.Empty;
                string sFilename = "";
                if (fileProfile.PostedFile != null)
                {
                    HttpPostedFile myFile = fileProfile.PostedFile;
                    int nFileLen = myFile.ContentLength;
                    if (nFileLen != 0)
                    {
                        DirectoryInfo dirInfo = null;
                        string fileSavePath = "/Data/SDCUS/Images/";
                        path = Server.MapPath("~" + fileSavePath);
                        if (!Directory.Exists(path))
                        {
                            dirInfo = Directory.CreateDirectory(path);
                        }
                        sFilename = System.IO.Path.GetFileName(myFile.FileName);
                        path = path + "/" + sFilename;
                        fileProfile.PostedFile.SaveAs(path);

                        finalPath = Path.Combine(fileSavePath, sFilename);
                    }
                }
                strImgFinalPath = finalPath;        
                ServeAtDoorstepData.CustomerDetails objCusDetails = new ServeAtDoorstepData.CustomerDetails();
                objCusDetails.Address = txtAddress.Value.ToString();
                objCusDetails.CityId = Convert.ToInt32(ddlCity.Value.ToString());
                objCusDetails.CountryId = Convert.ToInt32(ddlCountry.Value.ToString());
                objCusDetails.CustomerID = 0;
                objCusDetails.Email = txtEmail.Value.ToString();
                objCusDetails.FirstName = txtFirstname.Value.ToString();
                objCusDetails.LastName = txtLastname.Value.ToString();
                objCusDetails.Gender = Request.Form["rdoGender"].ToString();// rdoGender.Value.ToString();
                objCusDetails.LoginName = txtUsername.Value.ToString();
                objCusDetails.LoginPassword = txtPassword.Value.ToString();
                objCusDetails.Mobile = txtMobile.Value.ToString();
                objCusDetails.StateId = Convert.ToInt32(ddlState.Value.ToString());
                objCusDetails.StreetName = txtStreet.Value.ToString();
                objCusDetails.ZipCode = txtZipcode.Value.ToString();
                objCusDetails.ImagePath = strImgFinalPath;

                objService = new ServeAtDoorstepService();
                int intCusId = objService.AddCustomerRegister(objCusDetails);

                ServeAtDoorstepData.CusBankDetails objBankdet = new ServeAtDoorstepData.CusBankDetails();
                objBankdet.BankId = 0;
                objBankdet.CustomerId = intCusId;
                objBankdet.BankName = txtBankname.Value.ToString();
                objBankdet.CardHolderName = txtCardholdername.Value.ToString();
                objBankdet.CreditCardNumber = txtCredCardnumber.Value.ToString();
                objBankdet.CVCNumber = txtCVC.Value.ToString();

                int intCusBankId = objService.AddCustomerBankdet(objBankdet);

                SendMailtoUser(intCusId);

                Response.Redirect("Success.aspx?type=cus");
            }
            else
            {
                divErrorMessage.InnerHtml = strErrorMessage;

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginCustomer.aspx");
        }

        void CheckValidation()
        {
            if (txtUsername.Value.ToString() == "")
            {
                intVaidError++;
                strErrorMessage = "Login Name should not be empty.<br />";
            }
            CustomerCheck();
            if (intCustomerAvail==1)
            {
                intVaidError++;
                strErrorMessage += "Login Name already exists.<br />";
            } 
            if (txtPassword.Value.ToString() == "")
            {
                intVaidError++;
                strErrorMessage = "Login Password should not be empty.<br />";
            }
            if (txtPassword.Value.ToString() != txtConPassword.Value.ToString())
            {
                intVaidError++;
                strErrorMessage = "Confirm password should be match with password.<br />";
            }
            
            if (!IsEmailValid(txtEmail.Value.ToString()))
            {
                intVaidError++;
                strErrorMessage += "E mail address is not valid.<br />";
            }
            MailCheck();
            if (intMailAvail==1)
            {
                intVaidError++;
                strErrorMessage += "E mail address already exists.<br />";
            }
            if (chkAgree.Checked == false)
            {
                intVaidError++;
                strErrorMessage += "Please agree terms and conditions.<br />";
            }
        }

        void SendMailtoUser(int CustomerId)
        {
            try
            {
                string mUname = ConfigurationManager.AppSettings["mailUsername"].ToString();
                string mPwd = ConfigurationManager.AppSettings["mailPassword"].ToString();
                string mFrom = "";
                string mTo = txtEmail.Value.ToString().Trim();
                string mCC = "";

                string mSubject = "Serve At Doorstep Activation mail";
                string serverPath = ConfigurationManager.AppSettings["ApplicationPath"].ToString() + "/Activation.aspx?type=cus&id=" + UtilityClass.Encrypt(CustomerId.ToString()).ToString();
                string mMsg = "<html><body><form id='form1' runat='server'><div>" +
                "Dear " + txtUsername.Value.ToString() + ",<br /><br />Thank you for registering at the Serve At Doorstep." +
                "Before we can activate your account one last step must be taken to complete your registration." +
                "<br /><br />Please note - you must complete this last step to become a registered member. You will only need to visit this URL once to activate your account." +
                "<br /><br />To complete your registration, please visit this URL:<br />" +
                "<a href='" + serverPath + "' runat='server' >" + serverPath + "</a>" +
                "<br /><br /><br /><br />All the best,<br />ServAtDoorstep.</div></form></body></html>";

                UtilityClass.SendMail(mUname, mPwd, mFrom, mTo, mCC, mSubject, mMsg, true);
            }
            catch (SystemException ex)
            {
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

        #region .. CHECK LOGINNAME & EMAIL ..

        void CustomerCheck()
        {
            objService = new ServeAtDoorstepService();
            DataTable dt = objService.AvailableCustomer(txtUsername.Value.ToString().Trim());
            if (dt.Rows.Count == 0 && txtUsername.Value.ToString().Trim() != "")
            {
                intCustomerAvail = 0;
                //checkUser.Visible = true;
                //imgAvailable.Visible = true;
                //imgNotAvailable.Visible = false;
            }
            else
            {
                intCustomerAvail = 1;
                //imgAvailable.Visible = false;
                //imgNotAvailable.Visible = true;
            }
        }

        void MailCheck()
        {
            objService = new ServeAtDoorstepService();
            DataTable dt = objService.AvailableCusMail(txtEmail.Value.ToString().Trim());
            if (dt.Rows.Count == 0)
            {
                intMailAvail = 0;
            }
            else
            {
                intMailAvail = 1;
            }
        }

        #endregion

    }
}
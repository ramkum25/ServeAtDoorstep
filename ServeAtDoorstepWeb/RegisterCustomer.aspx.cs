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
        public string _usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
        public string _caZipRegEx = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$";

        protected void Page_Load(object sender, EventArgs e)
        {
            ddlState.SelectedIndexChanged += new EventHandler(ddlState_SelectedIndexChanged);
            ddlCity.Attributes.Add("onChange", "return codeAddress();");

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

            ddlCountry.SelectedIndex = 244;
            ddlCountry.Disabled = true;
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

            
            if (intVaidError == 0)
            {
                string path = string.Empty;
                string strImgFinalPath = "";
                string finalPath = string.Empty;
                string filePath = string.Empty;
                string sFilename = "";
                        
                ServeAtDoorstepData.CustomerDetails objCusDetails = new ServeAtDoorstepData.CustomerDetails();
                objCusDetails.Address = txtAddress.Value.ToString();
                objCusDetails.CityId = Convert.ToInt32(ddlCity.SelectedItem.Value.ToString());
                objCusDetails.CountryId = Convert.ToInt32(ddlCountry.Value.ToString());
                objCusDetails.CustomerID = 0;
                objCusDetails.Email = txtEmail.Value.ToString();
                objCusDetails.FirstName = txtFirstname.Value.ToString();
                objCusDetails.LastName = txtLastname.Value.ToString();
                objCusDetails.Gender = Request.Form["rdoGender"].ToString();// rdoGender.Value.ToString();
                objCusDetails.LoginName = txtUsername.Value.ToString();
                objCusDetails.LoginPassword = txtPassword.Value.ToString();
                objCusDetails.Mobile = txtMobile.Value.ToString();
                objCusDetails.StateId = Convert.ToInt32(ddlState.SelectedItem.Value.ToString());
                objCusDetails.StreetName = txtStreet.Value.ToString();
                objCusDetails.ZipCode = txtZipcode.Value.ToString();
                objCusDetails.ImagePath = "";

                objService = new ServeAtDoorstepService();
                int intCusId = objService.AddCustomerRegister(objCusDetails);

                if (fileProfile.PostedFile != null)
                {
                    HttpPostedFile myFile = fileProfile.PostedFile;
                    int nFileLen = myFile.ContentLength;
                    if (nFileLen != 0)
                    {
                        DirectoryInfo dirInfo = null;
                        string fileSavePath = "/Data/SDCUS_"+intCusId.ToString()+"/Images/";
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

                ServeAtDoorstepData.CustomerDetails cusDet = new ServeAtDoorstepData.CustomerDetails();
                cusDet.CustomerID = intCusId;
                cusDet.ImagePath = strImgFinalPath;
                objService.UpdateCustomerImage(cusDet);

                ServeAtDoorstepData.CusBankDetails objBankdet = new ServeAtDoorstepData.CusBankDetails();
                objBankdet.BankId = 0;
                objBankdet.CustomerId = intCusId;
                objBankdet.BankName = txtBankname.Value.ToString();
                objBankdet.CardHolderName = txtCardholdername.Value.ToString();
                objBankdet.CreditCardNumber = txtCredCardnumber.Value.ToString();
                objBankdet.CVCNumber = txtCVC.Value.ToString();

                int intCusBankId = objService.AddCustomerBankdet(objBankdet);

                SendMailtoUser(intCusId);

                lblEmailId.Text = txtEmail.Value.ToString();
                this.ModalPopupSuccess.Show();
                //Response.Redirect("Success.aspx?type=cus");
            }
            else
            {
                divErrorMessage.InnerHtml = strErrorMessage;

            }
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            this.ModalPopupSuccess.Hide();
            Response.Redirect("index.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        void CheckValidation()
        {
            if (txtUsername.Value.ToString() == "")
            {
                intVaidError++;
                strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Login Name should not be empty.<br />";
            }
            CustomerCheck();
            if (intCustomerAvail==1)
            {
                intVaidError++;
                strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Login Name already exists.<br />";
            } 
            if (txtPassword.Value.ToString() == "")
            {
                intVaidError++;
                strErrorMessage = "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Login Password should not be empty.<br />";
            }
            if (txtPassword.Value.ToString() != txtConPassword.Value.ToString())
            {
                intVaidError++;
                strErrorMessage = "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Confirm password should be match with password.<br />";
            }
            if (Request.Form["rdoGender"] == null)
            {
                intVaidError++;
                strErrorMessage = "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Please select gender.<br />";
            }
            if (ddlState.SelectedIndex == 0)
            {
                intVaidError++;
                strErrorMessage = "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Please select state.<br />";
            }
            if (ddlCity.SelectedIndex == 0)
            {
                intVaidError++;
                strErrorMessage = "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Please select city.<br />";
            }
            if (txtZipcode.Value.ToString() == "")
            {
                intVaidError++;
                strErrorMessage = "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Zip code should not be empty.<br />";
            }
            if (txtZipcode.Value.ToString() != "" && !IsUsorCanadianZipCode(txtZipcode.Value.ToString()))
            {
                intVaidError++;
                strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Zip code is not valid.<br />";
            }
            if (!IsEmailValid(txtEmail.Value.ToString()))
            {
                intVaidError++;
                strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;E mail address is not valid.<br />";
            }
            MailCheck();
            if (intMailAvail==1)
            {
                intVaidError++;
                strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;E mail address already exists.<br />";
            }
            if (chkAgree.Checked == false)
            {
                intVaidError++;
                strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Please agree terms and conditions.<br />";
            }
            if (!fileProfile.HasFile)
            {
                strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Please Select profile picture.<br />";
                intVaidError++;
            } 
            if (fileProfile.HasFile)
            {
                if (fileProfile.PostedFile.ContentLength > (50 * 1024))
                {
                    strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Image size exceeds maximum limit 50 KB.<br />";
                    intVaidError++;
                }
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

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            objService = new ServeAtDoorstepService();
            DataTable dtCy = objService.SelectCityByStateId(Convert.ToInt32(ddlState.SelectedIndex.ToString()));
            ddlCity.Items.Clear();
            ListItem listItem = new ListItem();
            listItem.Text = "<Select City>";
            listItem.Value = "0";
            ddlCity.Items.Add(listItem);
            for (int i = 0; i < dtCy.Rows.Count; i++)
            {
                listItem = new ListItem();
                listItem.Text = dtCy.Rows[i]["CityName"].ToString();
                listItem.Value = dtCy.Rows[i]["CityId"].ToString();
                ddlCity.Items.Add(listItem);
            }
        }

        private bool IsUsorCanadianZipCode(string zipCode)
        {
            bool validZipCode = true;
            if ((!Regex.Match(zipCode, _usZipRegEx).Success) && (!Regex.Match(zipCode, _caZipRegEx).Success))
            {
                validZipCode = false;
            }
            return validZipCode;
        }

    }
}
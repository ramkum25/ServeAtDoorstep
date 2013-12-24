using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServeAtDoorstepServiceApp;
using ServeAtDoorstepCommon;

namespace ServeAtDoorstepWeb
{
    public partial class RegisterVendor : System.Web.UI.Page
    {
        ServeAtDoorstepService objService = null;

        public int intVendorAvail = 0, intMailAvail = 0, intVaidError = 0;
        public string strErrorMessage = "";
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategory();
                LoadMembership();
                LoadCountry();
                LoadState();
                LoadCity();
            }
        }

        #region .. LOAD COMBO BOX ..

        void LoadCategory()
        {
            chkCateList.Items.Clear();
            objService = new ServeAtDoorstepService();
            DataTable dt1 = objService.SelectAllCategory();
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                ListItem chkCat = new ListItem();
                chkCat.Text = dt1.Rows[i]["CategoryName"].ToString();
                chkCat.Value = dt1.Rows[i]["CategoryID"].ToString();
                chkCateList.Items.Add(chkCat);

            }
        }

        void LoadMembership()
        {
            ddlMembership.Items.Clear();
            objService = new ServeAtDoorstepService();
            DataTable dt1 = objService.SelectAllMembership();
            ListItem listItem = new ListItem();
            listItem.Text = "<Select Membership>";
            listItem.Value = "0";
            ddlMembership.Items.Add(listItem);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                listItem = new ListItem();
                listItem.Text = dt1.Rows[i]["MemberShipName"].ToString();
                listItem.Value = dt1.Rows[i]["MemberShipID"].ToString();
                ddlMembership.Items.Add(listItem);
            }
        }

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

            if (intVaidError == 0)
            {
                ServeAtDoorstepData.VendorDetails objVenDetails = new ServeAtDoorstepData.VendorDetails();
                objVenDetails.LoginName = txtLoginname.Value.ToString();
                objVenDetails.LoginPassword = txtPassword.Value.ToString();
                objVenDetails.VendorID = 0;
                objVenDetails.VendorName = txtVendorName.Value.ToString();
                objVenDetails.VendorAddress = txtAddress.Value.ToString();
                objVenDetails.VendorStreet = txtStreet.Value.ToString();
                objVenDetails.VendorCityId = Convert.ToInt32(ddlCity.Value.ToString());
                objVenDetails.VendorStateId = Convert.ToInt32(ddlState.Value.ToString());
                objVenDetails.VendorCountryId = Convert.ToInt32(ddlCountry.Value.ToString());
                objVenDetails.VendorEmail = txtEmail.Value.ToString();
                objVenDetails.VendorZipcode = txtZipcode.Value.ToString();
                objVenDetails.VendorMobile = txtMobileNo.Value.ToString();
                objVenDetails.VendorBusinessPhone = txtBusinessNo.Value.ToString();
                objVenDetails.CompanyName = txtCompanyName.Value.ToString();
                objVenDetails.OwnerName = txtOwnerName.Value.ToString();
                objVenDetails.ContactName = txtContactName.Value.ToString();
                objVenDetails.ContactNumber = txtContactNo.Value.ToString();
                objVenDetails.CategoryId = 0;// Convert.ToInt32(ddlCategory.Value.ToString());
                objVenDetails.CoverageArea = txtCoverageArea.Value.ToString();
                objVenDetails.WebsiteUrl = txtWebsiteUrl.Value.ToString();
                objVenDetails.GeoCode = "0";//.Value.ToString();
                objVenDetails.MemberShipId = Convert.ToInt32(ddlMembership.Value.ToString());
                objVenDetails.CreditCardNumber = txtCredCardNo.Value.ToString();
                objVenDetails.CreditCardType = txtCredCardType.Value.ToString();
                objVenDetails.CreditCardExpired = txtExpiredDate.Value.ToString();
                objVenDetails.CVCNumber = txtCVC.Value.ToString();

                objService = new ServeAtDoorstepService();
                int intCusId = objService.AddVendorRegister(objVenDetails);

                SendMailtoUser(intCusId);

                Response.Redirect("Success.aspx?type=ven");
            }
            else
            {
                divErrorMessage.InnerHtml = strErrorMessage;

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginVendor.aspx");
        }

        void CheckValidation()
        {
            if (txtLoginname.Value.ToString() == "")
            {
                intVaidError++;
                strErrorMessage = "Login Name should not be empty.<br />";
            }
            VendorCheck();
            if (intVendorAvail == 1)
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
            if (intMailAvail == 1)
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

        void SendMailtoUser(int VendorId)
        {
            try
            {
                string mUname = ConfigurationManager.AppSettings["mailUsername"].ToString();
                string mPwd = ConfigurationManager.AppSettings["mailPassword"].ToString();
                string mFrom = "";
                string mTo = txtEmail.Value.ToString().Trim();
                string mCC = "";

                string mSubject = "Serve At Doorstep Activation mail";
                string serverPath = ConfigurationManager.AppSettings["ApplicationPath"].ToString() + "/Activation.aspx?type=ven&id=" + UtilityClass.Encrypt(VendorId.ToString()).ToString();
                string mMsg = "<html><body><form id='form1' runat='server'><div>" +
                "Dear " + txtLoginname.Value.ToString() + ",<br /><br />Thank you for registering at the Serve At Doorstep." +
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

        void VendorCheck()
        {
            objService = new ServeAtDoorstepService();
            DataTable dt = objService.AvailableVendor(txtLoginname.Value.ToString().Trim());
            if (dt.Rows.Count == 0 && txtLoginname.Value.ToString().Trim() != "")
            {
                intVendorAvail = 0;
                //checkUser.Visible = true;
                //imgAvailable.Visible = true;
                //imgNotAvailable.Visible = false;
            }
            else
            {
                intVendorAvail = 1;
                //imgAvailable.Visible = false;
                //imgNotAvailable.Visible = true;
            }
        }

        void MailCheck()
        {
            objService = new ServeAtDoorstepService();
            DataTable dt = objService.AvailableVenMail(txtEmail.Value.ToString().Trim());
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
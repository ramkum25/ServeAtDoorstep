using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using ServeAtDoorstepServiceApp;
using ServeAtDoorstepData;

namespace ServeAtDoorstepWeb
{
    public partial class EditCustomerProfile : System.Web.UI.Page
    {
        ServeAtDoorstepService objService = null;

        public int intCustomerAvail = 0, intMailAvail = 0, intVaidError = 0;
        public string strErrorMessage = "";
        string sLoginType = "", sLoginId = "";
        public static string sCustomerId = "", sBankId = "", sLoginname = "", sPassword = "", sImagePath="";
        public string _usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
        public string _caZipRegEx = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginType"] != null)
            {
                sLoginType = Session["LoginType"].ToString();
            }
            if (Session["LoginId"] != null)
            {
                sLoginId = Session["LoginId"].ToString();
                sCustomerId = sLoginId;
            }

            ddlState.SelectedIndexChanged += new EventHandler(ddlState_SelectedIndexChanged);
            ddlCity.Attributes.Add("onChange", "return codeAddress();");

            if (!IsPostBack)
            {
                LoadCountry();
                LoadState();
                //lLoadCity();
                LoadProfile();
            }
        }

        void LoadProfile()
        {
            objService = new ServeAtDoorstepService();
            DataTable dtCus = objService.GetCustomerById(Convert.ToInt32(sLoginId));
            if (dtCus.Rows.Count > 0)
            {
                spnCusImage.InnerHtml = "<a class='example-image-link' href='" + dtCus.Rows[0]["ImagePath"].ToString() + "' data-lightbox='example-1'" +
                                    "title='Or press the right arrow on your keyboard.'>" +
                                    "<img class='example-image' src='" + dtCus.Rows[0]["ImagePath"].ToString() + "' alt='Plants: image 2 0f 4 thumb' width='150' height='150' /></a>";

                txtFirstName.Value = dtCus.Rows[0]["FirstName"].ToString();// +" " + dtCus.Rows[0]["LastName"].ToString();
                txtLastName.Value = dtCus.Rows[0]["LastName"].ToString();
                lblLoginName.Text = dtCus.Rows[0]["LoginName"].ToString();
                sLoginname = dtCus.Rows[0]["LoginName"].ToString();
                sPassword = dtCus.Rows[0]["LoginPassword"].ToString();
                sImagePath = dtCus.Rows[0]["ImagePath"].ToString();
                lblEmail.Text = dtCus.Rows[0]["Email"].ToString();
                txtEmail.Value = dtCus.Rows[0]["Email"].ToString();
                txtMobile.Value = dtCus.Rows[0]["Mobile"].ToString();
                rdoGender.SelectedValue = dtCus.Rows[0]["Gender"].ToString();
                for (int i = 0; i < ddlCountry.Items.Count; i++)
                {
                    if (ddlCountry.Items[i].Text == dtCus.Rows[0]["CountryName"].ToString())
                        ddlCountry.SelectedIndex = i;
                }
                for (int i = 0; i < ddlState.Items.Count; i++)
                {
                    if (ddlState.Items[i].Text == dtCus.Rows[0]["StateName"].ToString())
                        ddlState.SelectedIndex = i;
                }
                string sState = dtCus.Rows[0]["StateName"].ToString();
                string sStateId = dtCus.Rows[0]["StateId"].ToString();
                DataTable dtCy = objService.SelectCityByStateId(Convert.ToInt32(sStateId));
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
                for (int i = 0; i < ddlCity.Items.Count; i++)
                {
                    if (ddlCity.Items[i].Text == dtCus.Rows[0]["CityName"].ToString())
                        ddlCity.SelectedIndex = i;
                }
                txtAddress.Value = dtCus.Rows[0]["Address"].ToString();
                txtStreetname.Value = dtCus.Rows[0]["StreetName"].ToString();
                txtZipcode.Value = dtCus.Rows[0]["ZipCode"].ToString();
                sBankId = dtCus.Rows[0]["BankId"].ToString();

                hdnAddress.Value = dtCus.Rows[0]["CityName"].ToString().Trim() + ", " + dtCus.Rows[0]["StateName"].ToString() + ", US";
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            strErrorMessage = "";
            intVaidError = 0;
            CheckValidation();
            if (intVaidError == 0)
            {
                ServeAtDoorstepData.CustomerDetails objCusDetails = new ServeAtDoorstepData.CustomerDetails();
                objCusDetails.Address = txtAddress.Value.ToString();
                objCusDetails.CityId = Convert.ToInt32(ddlCity.SelectedItem.Value.ToString());
                objCusDetails.CountryId = Convert.ToInt32(ddlCountry.Value.ToString());
                objCusDetails.CustomerID = Convert.ToInt32(sCustomerId);
                objCusDetails.Email = txtEmail.Value.ToString().Trim();
                objCusDetails.FirstName = txtFirstName.Value.ToString();
                objCusDetails.LastName = txtLastName.Value.ToString();
                objCusDetails.Gender = rdoGender.SelectedValue.ToString();
                objCusDetails.LoginName = sLoginname;
                objCusDetails.LoginPassword = sPassword;
                objCusDetails.Mobile = txtMobile.Value.ToString();
                objCusDetails.StateId = Convert.ToInt32(ddlState.SelectedItem.Value.ToString());
                objCusDetails.StreetName = txtStreetname.Value.ToString();
                objCusDetails.ZipCode = txtZipcode.Value.ToString();
                objCusDetails.ImagePath = sImagePath;

                objService = new ServeAtDoorstepService();
                int intCusId = objService.AddCustomerRegister(objCusDetails);

                Response.Redirect("MyCustomerProfile.aspx");
            }
            else
            {
                divErrorMessage.InnerHtml = strErrorMessage;

            }
        
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            LoadProfile();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyCustomerProfile.aspx");
        }

        void CheckValidation()
        {
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
            if (!IsUsorCanadianZipCode(txtZipcode.Value.ToString()))
            {
                intVaidError++;
                strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Zip code is not valid.<br />";
            }
            if (!IsEmailValid(txtEmail.Value.ToString()))
            {
                intVaidError++;
                strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;E mail address is not valid.<br />";
            }

            if (lblEmail.Text.Trim() != txtEmail.Value.Trim())
            {
                MailCheck();
                if (intMailAvail == 1)
                {
                    intVaidError++;
                    strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;E mail address already exists.<br />";
                }
            }
        }

        void ClearFields()
        {
            txtAddress.Value = "";
            txtFirstName.Value = "";
            txtLastName.Value = "";
            txtMobile.Value = "";
            txtStreetname.Value = "";
            txtZipcode.Value = "";
            ddlCity.SelectedIndex = 0;
            ddlCountry.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;
            rdoGender.SelectedValue = "0";
        }

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

    }
}
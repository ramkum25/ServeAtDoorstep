using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using ServeAtDoorstepServiceApp;
using ServeAtDoorstepData;
using ServeAtDoorstepCommon;

namespace ServeAtDoorstepWeb
{
    public partial class RegisterVendor : System.Web.UI.Page
    {
        ServeAtDoorstepService objService = null;

        public int intVendorAvail = 0, intMailAvail = 0, intVaidError = 0;
        public string strErrorMessage = "";
        public string _usZipRegEx = @"^\d{5}(?:[-\s]\d{4})?$";
        public string _caZipRegEx = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$";

        protected void Page_Load(object sender, EventArgs e)
        {
            ddlState.SelectedIndexChanged += new EventHandler(ddlState_SelectedIndexChanged);
            ddlCity.Attributes.Add("onChange", "return codeAddress();");

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
                chkCat.Text = "  "+dt1.Rows[i]["CategoryName"].ToString();
                chkCat.Value = dt1.Rows[i]["CategoryID"].ToString();
                chkCateList.Items.Add(chkCat);

            }
        }

        void ListStateByCountry()
        {
            int iCntId = Convert.ToInt32(ddlCountry.SelectedIndex.ToString());

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
                ServeAtDoorstepData.VendorDetails objVenDetails = new ServeAtDoorstepData.VendorDetails();
                objVenDetails.LoginName = txtLoginname.Value.ToString();
                objVenDetails.LoginPassword = txtPassword.Value.ToString();
                objVenDetails.VendorID = 0;
                objVenDetails.VendorName = txtVendorName.Value.ToString();
                objVenDetails.VendorAddress = txtAddress.Value.ToString();
                objVenDetails.VendorStreet = txtStreet.Value.ToString();
                objVenDetails.VendorCityId = Convert.ToInt32(ddlCity.SelectedItem.Value.ToString());
                objVenDetails.VendorStateId = Convert.ToInt32(ddlState.SelectedItem.Value.ToString());
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
                int intVendId = objService.AddVendorRegister(objVenDetails);

                for(int intCnt=0;intCnt<chkCateList.Items.Count;intCnt++)
                {
                    if (chkCateList.Items[intCnt].Selected == true)
                    {
                        int iCatID = Convert.ToInt32(chkCateList.Items[intCnt].Value.ToString());

                        objService = new ServeAtDoorstepService();
                        DataTable dtServ = objService.SelectServiceByCatID(iCatID);

                        //if (dtServ.Rows.Count > 0)
                        {
                            //for (int intSer = 0; intSer < dtServ.Rows.Count; intSer++)
                            {
                                VendorServiceDetails objVSData = new VendorServiceDetails();
                                objVSData.VendorServiceId = 0;
                                objVSData.VendorId = intVendId;
                                objVSData.CategoryId = iCatID;
                                objVSData.ServiceId = 0;// Convert.ToInt32(dtServ.Rows[0]["ServiceID"].ToString());
                                objVSData.Status = "1";

                                int i = objService.AddVendorService(objVSData);

                            }
                        }
                    }
                }



                #region .. VENDOR COVERAGE AREA ..

                //var requestUri = "https://www.zipwise.com/webservices/radius.php?key=yj7b6stzbr3lmmoo&zip=" + txtZipcode.Value.Trim() + "&radius=5&format=xml";
                //var requestUri = "https://zipcodedistanceapi.redline13.com/rest/VGO5Fus2poaNqECnpYc77kfZARW0TjgP04UFymHYLSMcxoAWnM3u6itHaqH4KXTK/radius.xml/" + txtZipcode.Value.Trim() + "/15/mile";
                var requestUri = "https://zipcodedistanceapi.redline13.com/rest/dtMOhbP1itLs2K2WQNccHRkUoEGJfDds7Zgoa6ptAbWCWYzMMLYuDjo1Y4LdIYGP/radius.xml/" + txtZipcode.Value.Trim() + "/15/mile";

                var webRequest = (HttpWebRequest)WebRequest.Create(requestUri);

                webRequest.Method = "GET";

                webRequest.ContentType = "application/xml";

                HttpWebResponse response;

                string responseContent = "";

                try
                {

                    response = (HttpWebResponse)webRequest.GetResponse();

                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(response.GetResponseStream());

                    //Create namespace manager
                    int intAreaCount = 0;
                    string[] sCity = new string[500];
                    string[] state = new string[500];
                    string[] sZip = new string[500];
                    string[] sDis = new string[500];

                    XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
                    nsmgr.AddNamespace("rest", "http://schemas.microsoft.com/search/local/ws/rest/v1");
                    string s = xmlDoc.InnerXml.Contains("error").ToString();
                    if (xmlDoc.InnerXml.Contains("error").ToString() == "False")
                    {
                        XmlNodeList locationElements = xmlDoc.SelectNodes("results/result", nsmgr);
                        int i = 0;
                        foreach (XmlNode location in locationElements)
                        {
                            sZip[i] = location.SelectSingleNode("zip", nsmgr).InnerText;
                            //sCity[i] = location.SelectSingleNode("city", nsmgr).InnerText;
                            //state[i] = location.SelectSingleNode("state", nsmgr).InnerText;
                            //sDis[i] = location.SelectSingleNode("distance", nsmgr).InnerText;

                            i++;
                            intAreaCount++;
                        }
                    }
                    webRequest.Abort();

                    for (int iACnt = 0; iACnt < intAreaCount; iACnt++)
                    {
                        ServeAtDoorstepData.VendorAreaDetails objVendorArea = new VendorAreaDetails();
                        objVendorArea.VendorAreaID = 0;
                        objVendorArea.VendorId = intVendId;
                        objVendorArea.VAZipcode = sZip[iACnt];
                        objVendorArea.VACityName = "";// sCity[iACnt];
                        objVendorArea.VAState = "";//state[iACnt];
                        objVendorArea.VADistance = "";//sDis[iACnt];

                        int j = objService.AddVendorArea(objVendorArea);

                    }
                }
                catch (WebException webex)
                {
                    //lblResult.Text = "INVALID ZIPCODE";

                }


                #endregion


                SendMailtoUser(intVendId);

                lblEmailId.Text = txtEmail.Value.ToString();
                this.ModalPopupSuccess.Show();
                //Response.Redirect("Success.aspx?type=ven");
            }
            else
            {
                divErrorMessage.InnerHtml = strErrorMessage;

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        void CheckValidation()
        {
            strErrorMessage = "";

            if (txtLoginname.Value.ToString() == "")
            {
                intVaidError++;
                strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Login Name should not be empty.<br />";
            }
            VendorCheck();
            if (intVendorAvail == 1)
            {
                intVaidError++;
                strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Vendor Login Name already exists.<br />";
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
            int iChkCount = 0;
            for (int intCnt = 0; intCnt < chkCateList.Items.Count; intCnt++)
            {
                if (chkCateList.Items[intCnt].Selected == true)
                {
                    iChkCount++;
                }
            }
            if (iChkCount == 0)
            {
                intVaidError++;
                strErrorMessage = "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Please Select Category.<br />";
            } 
            
            if (!IsEmailValid(txtEmail.Value.ToString()))
            {
                intVaidError++;
                strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;E mail address is not valid.<br />";
            }
            MailCheck();
            if (intMailAvail == 1)
            {
                intVaidError++;
                strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;E mail address already exists.<br />";
            }

            if (txtVendorName.Value.ToString() == "")
            {
                intVaidError++;
                strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Vendor Name should not be empty.<br />";
            } 
            if (ddlState.SelectedIndex == 0)
            {
                intVaidError++;
                strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Please select Vendor state.<br />";
            
            }
            if (ddlCity.SelectedIndex == 0)
            {
                intVaidError++;
                strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Please select Vendor city.<br />";
            
            }
            if(!IsUsorCanadianZipCode(txtZipcode.Value.ToString()))
            {
                intVaidError++;
                strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Zip Code is not valid.<br />";
            }
            if (chkAgree.Checked == false)
            {
                intVaidError++;
                strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Please agree terms and conditions.<br />";
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            lblEmailId.Text = txtEmail.Value.ToString();
            this.ModalPopupSuccess.Show();
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            this.ModalPopupSuccess.Hide();
            Response.Redirect("index.aspx");
        }


//        <script type="text/javascript">
//    function validZip(zip)
//{
//if (zip.match(^\d{5}(-\d{4})?$)|(^[ABCEGHJKLMNPRSTVXY]{1}\d{1}[A-Z]{1} *\d{1}[A-Z]{1}\d{1}$)) {
//return true;
//}
//alert('*** Please enter a valid zip code.');
//return false;
//}
//    </script>


//<input name="ZIP" type="text" id="ZIP" size="6" maxlength="10" onChange="validZip('zip')"/>
    }
}
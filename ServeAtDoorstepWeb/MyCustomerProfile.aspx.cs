using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using ServeAtDoorstepServiceApp;
using ServeAtDoorstepData;

namespace ServeAtDoorstepWeb
{
    public partial class MyCustomerProfile : System.Web.UI.Page
    {
        ServeAtDoorstepService objService = null;
        string sLoginType = "", sLoginId = "";
        public static string sCustomerId = "", sBankId = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginType"] != null)
            {
                sLoginType=Session["LoginType"].ToString();
            }
            if (Session["LoginId"] != null)
            {
                sLoginId=Session["LoginId"].ToString();
            }

            if (!IsPostBack)
            {
                LoadProfile();

                //Page.ClientScript.RegisterClientScriptBlock(typeof(ScriptManager), "CallMyMethod", sScript, true);
                //ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "HelpScript", "codeAddress();", true);
            }
        }

        void LoadProfile()
        {
            objService = new ServeAtDoorstepService();
            DataTable dtCus = objService.GetCustomerById(Convert.ToInt32(sLoginId));
            sCustomerId = sLoginId;
            if (dtCus.Rows.Count > 0)
            {
                spnCusImage.InnerHtml = "<a class='example-image-link' href='" + dtCus.Rows[0]["ImagePath"].ToString() + "' data-lightbox='example-1'" +
                                    "title='Or press the right arrow on your keyboard.'>" +
                                    "<img class='example-image' src='" + dtCus.Rows[0]["ImagePath"].ToString() + "' alt='Plants: image 2 0f 4 thumb' width='150' height='150' /></a>";

                lblCusName.Text = dtCus.Rows[0]["FirstName"].ToString() + " " + dtCus.Rows[0]["LastName"].ToString();
                lblCusLogName.Text = dtCus.Rows[0]["LoginName"].ToString();
                lblCusLogPwd.Text = dtCus.Rows[0]["LoginPassword"].ToString();
                lblCusEmail.Text = dtCus.Rows[0]["Email"].ToString();
                lblCusMobile.Text = dtCus.Rows[0]["Mobile"].ToString();
                string sGender = dtCus.Rows[0]["Gender"].ToString();
                if (sGender == "0")
                    lblCusGender.Text = "Rather not say";
                else if (sGender == "1")
                    lblCusGender.Text = "Male";
                else if (sGender == "2")
                    lblCusGender.Text = "Female";
                lblCusState.Text = dtCus.Rows[0]["StateName"].ToString();
                lblCusCity.Text = dtCus.Rows[0]["CityName"].ToString();
                lblCusCountry.Text = dtCus.Rows[0]["CountryName"].ToString();
                lblCusAddr.Text = dtCus.Rows[0]["Address"].ToString();
                lblCusStreet.Text = dtCus.Rows[0]["StreetName"].ToString();
                lblCusZip.Text = dtCus.Rows[0]["ZipCode"].ToString();
                sBankId = dtCus.Rows[0]["BankId"].ToString();
                lblBankName.Text = dtCus.Rows[0]["BankName"].ToString();
                lblCardNo.Text = dtCus.Rows[0]["CreditCardNumber"].ToString();
                lblHolderName.Text = dtCus.Rows[0]["CardHolderName"].ToString();
                lblCVC.Text = dtCus.Rows[0]["CVCNumber"].ToString();

                hdnAddress.Value = dtCus.Rows[0]["CityName"].ToString().Trim() + ", " + dtCus.Rows[0]["StateName"].ToString() + ", US";
            }
        }

        protected void lbtnChangePic_Click(object sender, EventArgs e)
        {
            divErrorPic.InnerHtml = "";
            this.modalpopPicture.Show();
        }

        protected void imgClose_Click(object sender, ImageClickEventArgs e)
        {
            this.modalpopPicture.Hide();
        }

        protected void imgCloseBank_Click(object sender, ImageClickEventArgs e)
        {
            this.modalpopBank.Hide();
        }

        protected void lnkEditBank_Click(object sender, EventArgs e)
        {
            divErrorBank.InnerHtml = "";
            this.modalpopBank.Show();
        }

        protected void lnkEditPassword_Click(object sender, EventArgs e)
        {
            pnlpopupPwd.Height = 200;
            divErrorPwd.InnerHtml = "";
            this.modalpopPassword.Show();
        }

        protected void lnkEditProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditCustomerProfile.aspx?sid= ");
        }

        protected void btnSavePic_Click(object sender, EventArgs e)
        {
            string path = string.Empty;
            string finalPath = string.Empty;
            string filePath = string.Empty;
            string sFilename = "";
            string strErrorMessage = "";
            int intVaidError = 0;

            if (FileUpload1.PostedFile != null)
            {
                if (FileUpload1.PostedFile.ContentLength > (50 * 1024))
                {
                    strErrorMessage += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Image size exceeds maximum limit 50 KB.<br />";
                    intVaidError++;
                }
            }

            if (intVaidError == 0)
            {
                if (FileUpload1.PostedFile != null)
                {
                    HttpPostedFile myFile = FileUpload1.PostedFile;
                    int nFileLen = myFile.ContentLength;
                    if (nFileLen != 0)
                    {
                        DirectoryInfo dirInfo = null;
                        string fileSavePath = "/Data/SDCUS_" + sLoginId.ToString() + "/Images/";
                        path = Server.MapPath("~" + fileSavePath);
                        if (!Directory.Exists(path))
                        {
                            dirInfo = Directory.CreateDirectory(path);
                        }
                        sFilename = System.IO.Path.GetFileName(myFile.FileName);
                        path = path + "/" + sFilename;
                        FileUpload1.PostedFile.SaveAs(path);

                        finalPath = Path.Combine(fileSavePath, sFilename);
                    }
                }

                ServeAtDoorstepData.CustomerDetails cusDet = new ServeAtDoorstepData.CustomerDetails();
                cusDet.CustomerID = Convert.ToInt32(sLoginId);
                cusDet.ImagePath = finalPath;

                objService = new ServeAtDoorstepService();
                objService.UpdateCustomerImage(cusDet);

                this.modalpopPicture.Hide();
                LoadProfile();
            }
            else
            {
                divErrorPic.InnerHtml = strErrorMessage;
                this.modalpopPicture.Show();
            }
        }

        protected void imgClosePwd_Click(object sender, ImageClickEventArgs e)
        {
            this.modalpopPassword.Hide();

        }

        protected void btnSaveBank_Click(object sender, EventArgs e)
        {
            int intErrorBank = 0;
            string strErrorBank = "";

            if (intErrorBank == 0)
            {
                ServeAtDoorstepData.CusBankDetails objBankdet = new ServeAtDoorstepData.CusBankDetails();
                objBankdet.BankId = Convert.ToInt32(sBankId);
                objBankdet.CustomerId = Convert.ToInt32(sCustomerId);
                objBankdet.BankName = txtBankname.Value.ToString();
                objBankdet.CardHolderName = txtCardholdername.Value.ToString();
                objBankdet.CreditCardNumber = txtCredCardnumber.Value.ToString();
                objBankdet.CVCNumber = txtCVC.Value.ToString();

                objService = new ServeAtDoorstepService();
                int i = objService.AddCustomerBankdet(objBankdet);

                this.modalpopBank.Hide();
                LoadProfile();
            }
            else
            {
                this.modalpopBank.Show();
                divErrorBank.InnerHtml = strErrorBank;
            }
        }

        protected void btnSavePwd_Click(object sender, EventArgs e)
        {
            int intErrorPwd = 0;
            string strErrorPwd = "";
            if (txtNewPwd.Value.Trim()=="")
            {
                strErrorPwd += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Enter New Password.<br />";
                intErrorPwd++;
            }
            if (txtNewPwd.Value.Trim()!="" && txtNewPwd.Value.Length < 6)
            {
                strErrorPwd += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Password Length is minimum 6 characters.<br />";
                intErrorPwd++;
            }
            if (txtConPwd.Value.Trim() == "")
            {
                strErrorPwd += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Enter Confirm Password.<br />";
                intErrorPwd++;
            }
            if (txtNewPwd.Value.Trim() != txtConPwd.Value.Trim())
            {
                strErrorPwd += "<img src='image/warning.png' height='25px' width='25px' />&nbsp;&nbsp;Confirm Password is not match with password.<br />";
                intErrorPwd++;
            }

            if (intErrorPwd == 0)
            {
                ServeAtDoorstepData.CustomerDetails objCusdet = new ServeAtDoorstepData.CustomerDetails();
                objCusdet.LoginPassword = txtNewPwd.Value.Trim();
                objCusdet.CustomerID = Convert.ToInt32(sCustomerId);

                objService = new ServeAtDoorstepService();
                objService.UpdateCustomerPassword(objCusdet);

                this.modalpopPassword.Hide();
                LoadProfile();
            }
            else
            {
                this.modalpopPassword.Show();
                divErrorPwd.InnerHtml = strErrorPwd;
                pnlpopupPwd.Height = 260;
            }
        }

    }
}
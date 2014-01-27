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
    public partial class MyVendorProfile : System.Web.UI.Page
    {
        ServeAtDoorstepService objService = null;
        string sLoginType = "", sLoginId = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginType"] != null)
            {
                sLoginType = Session["LoginType"].ToString();
            }
            if (Session["LoginId"] != null)
            {
                sLoginId = Session["LoginId"].ToString();
            }

            if (!IsPostBack)
            {
                LoadProfile();
            }
        }

        void LoadProfile()
        {
            string sMemberId = "";
            string sCreatedOn = "";
            objService = new ServeAtDoorstepService();
            DataTable dtVen = objService.GetVendorById(Convert.ToInt32(sLoginId));

            if (dtVen.Rows.Count > 0)
            {
                sMemberId = dtVen.Rows[0]["MemberShipId"].ToString();
                sCreatedOn = dtVen.Rows[0]["CreatedOn"].ToString();
                divVendorInfo.InnerHtml = "<a class='example-image-link' href='image/Vendor.jpg' data-lightbox='example-1'" +
                                    "title='Vendor'>" +
                                    "<img class='example-image' src='image/Vendor.jpg' alt='Vendor' width='150' height='150' /></a>";
                string sAddress = dtVen.Rows[0]["VendorStreet"].ToString() + " " + dtVen.Rows[0]["VendorAddress"].ToString() + " " + dtVen.Rows[0]["CityName"].ToString() + " " + dtVen.Rows[0]["StateName"].ToString() + " " + dtVen.Rows[0]["VendorZipcode"].ToString();
                divAddressInfo.InnerHtml = "<span style='font-size: x-large; font-weight: 800; color: #003300; font-family: verdana, Geneva, Tahoma, sans-serif'>" + dtVen.Rows[0]["VendorName"].ToString() + "</span>" +
                                    "&nbsp;(" + dtVen.Rows[0]["LoginName"].ToString() + ")<br/>" +
                                    "<br/>&nbsp;&nbsp;<img src='image/address.jpg' width='25' height='25' />&nbsp;" + sAddress.ToUpper() + "<br/>" +
                                    "<br/>&nbsp;&nbsp;<img src='image/Mail.png' width='25' height='25' />&nbsp;" + dtVen.Rows[0]["VendorEmail"].ToString() + "<br/>" +
                                    "<br/>&nbsp;&nbsp;<img src='image/mobile.png' width='25' height='25' />&nbsp;" + dtVen.Rows[0]["VendorMobile"].ToString() + "<br/>";
                divBusinessInfo.InnerHtml = "<table style='width: 100%;'><tr><td style='text-align:center;'><span style='font-family: tahoma; font-size: 20px; font-style: normal;font-weight: 800; text-transform: uppercase;color: #FFFF99; text-decoration: navy dotted line-through;'>" + dtVen.Rows[0]["CompanyName"].ToString() + "</span></td></tr></table>" +
                                    "&nbsp;<span style='font-family: tahoma; font-size: 16px; font-style: normal; color: #FFFF99;'>Owner as " + dtVen.Rows[0]["OwnerName"].ToString() + "</span><br/>" +
                                    "<br/><span style='font-family: calibri; font-size: large; font-weight: bolder; color: #006666'>Contact Details :</span><br>"+
                                    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style='color: #006600; font-family: Geneva; font-size: 15px; font-weight: 500; text-transform: uppercase;'>" + dtVen.Rows[0]["ContactName"].ToString() + "</span><br/>" +
                                    "&nbsp;&nbsp;<img src='image/mobile.png' width='25' height='25' />&nbsp;&nbsp;<span style='color: #006600; font-family: Geneva; font-size: 15px; font-weight: 500; text-transform: uppercase;'>" + dtVen.Rows[0]["ContactNumber"].ToString() + "</span><br/>" +
                                    "<br/><span style='font-family: calibri; font-size: large; font-weight: bolder; color: #006666'>URL :</span>" +
                                    "&nbsp;<span style='color: #0066FF; font-family: Geneva; font-size: 15px;'>" + dtVen.Rows[0]["WebsiteUrl"].ToString() + "</span><br/>";
                                
                //lblCusName.Text = dtVen.Rows[0]["VendorName"].ToString() + " " + dtCus.Rows[0]["LastName"].ToString();

                lblCardNo.Text = dtVen.Rows[0]["CreditCardNumber"].ToString().Trim();
                lblCardType.Text = dtVen.Rows[0]["CreditCardType"].ToString().Trim();

                hdnAddress.Value = dtVen.Rows[0]["CityName"].ToString().Trim() + ", " + dtVen.Rows[0]["StateName"].ToString() + ", US";
            }

            string sMemName = "", sMemType = "", sMemAmt = "", sMemDays = "";
            DataTable dtMember = objService.GetMembershipById(Convert.ToInt32(sMemberId));
            if (dtMember.Rows.Count > 0)
            {
                sMemName = dtMember.Rows[0]["MemberShipName"].ToString().Trim();
                sMemType = dtMember.Rows[0]["MemberShipType"].ToString().Trim();
                sMemAmt = dtMember.Rows[0]["MemberShipAmount"].ToString().Trim();
                sMemDays = dtMember.Rows[0]["MemberShipDays"].ToString().Trim();
            }

            string sRemainDay = "";// sCreatedOn - sMemDays;
            string sCurrentDay = "";// sCreatedOn - sMemDays;
            DateTime dtCreate = Convert.ToDateTime(sCreatedOn);
            DateTime dtToday = System.DateTime.Today;
            TimeSpan dtResult = dtToday - dtCreate;

            int intDaysRemain = Convert.ToInt32(sMemDays) - Convert.ToInt32(dtResult.TotalDays);
            if (intDaysRemain>0)
                lblDaysRemain.Text = intDaysRemain.ToString() + " Days";
            else
                lblDaysRemain.Text = "Renew Membership";

            lblMemName.Text = sMemName;
            string sDivCate = "<br/>";
            DataTable dtCategory = objService.GetCategoryByVendorId(Convert.ToInt32(sLoginId));
            if (dtCategory.Rows.Count > 0)
            {
                for (int i = 0; i < dtCategory.Rows.Count; i++)
                {
                    sDivCate += "&nbsp;&nbsp;<span style='color: #006600; font-family: Geneva; font-size: 15px; font-weight: 500; text-transform: uppercase;'>" + dtCategory.Rows[i]["CategoryName"].ToString().Trim() + "</span><br/>";
                }
            }

            spnCategory.InnerHtml = sDivCate;
        }

        protected void lnkEditProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditVendorProfile.aspx");
        }

    }
}
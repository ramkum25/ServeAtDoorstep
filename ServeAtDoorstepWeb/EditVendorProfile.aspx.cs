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
    public partial class EditVendorProfile : System.Web.UI.Page
    {
        ServeAtDoorstepService objService = null;

        public int intVendorAvail = 0, intMailAvail = 0, intVaidError = 0;
        public string strErrorMessage = "";
        string sLoginType = "", sLoginId = "";
        public static string sVendorId = "", sMemberId = "", sLoginname = "", sPassword = "", sImagePath = "";
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
                sVendorId = sLoginId;
            }

            //ddlState.SelectedIndexChanged += new EventHandler(ddlState_SelectedIndexChanged);
            //ddlCity.Attributes.Add("onChange", "return codeAddress();");

            if (!IsPostBack)
            {
                //LoadCountry();
                //LoadState();
                //LoadProfile();
            }
        }

        void LoadProfile()
        {
            objService = new ServeAtDoorstepService();
            DataTable dtVen = objService.GetCustomerById(Convert.ToInt32(sLoginId));
            if (dtVen.Rows.Count > 0)
            {
                spnCusImage.InnerHtml = "<a class='example-image-link' href='image/Vendor.jpg' data-lightbox='example-1'" +
                                    "title='Vendor'>" +
                                    "<img class='example-image' src='image/Vendor.jpg' alt='Vendor' width='150' height='150' /></a>";

                lblLoginName.Text = dtVen.Rows[0]["LoginName"].ToString();
                lblEmail.Text = dtVen.Rows[0]["VendorEmail"].ToString();
                txtVendorName.Value = dtVen.Rows[0]["VendorName"].ToString();

        //        txtFirstName.Value = dtCus.Rows[0]["FirstName"].ToString();// +" " + dtCus.Rows[0]["LastName"].ToString();
        //        txtLastName.Value = dtCus.Rows[0]["LastName"].ToString();
        //        sLoginname = dtCus.Rows[0]["LoginName"].ToString();
        //        sPassword = dtCus.Rows[0]["LoginPassword"].ToString();
        //        sImagePath = dtCus.Rows[0]["ImagePath"].ToString();
        //        txtEmail.Value = dtCus.Rows[0]["Email"].ToString();
        //        txtMobile.Value = dtCus.Rows[0]["Mobile"].ToString();
        //        rdoGender.SelectedValue = dtCus.Rows[0]["Gender"].ToString();
        //        for (int i = 0; i < ddlCountry.Items.Count; i++)
        //        {
        //            if (ddlCountry.Items[i].Text == dtCus.Rows[0]["CountryName"].ToString())
        //                ddlCountry.SelectedIndex = i;
        //        }
        //        for (int i = 0; i < ddlState.Items.Count; i++)
        //        {
        //            if (ddlState.Items[i].Text == dtCus.Rows[0]["StateName"].ToString())
        //                ddlState.SelectedIndex = i;
        //        }
        //        string sState = dtCus.Rows[0]["StateName"].ToString();
        //        string sStateId = dtCus.Rows[0]["StateId"].ToString();
        //        DataTable dtCy = objService.SelectCityByStateId(Convert.ToInt32(sStateId));
        //        ddlCity.Items.Clear();
        //        ListItem listItem = new ListItem();
        //        listItem.Text = "<Select City>";
        //        listItem.Value = "0";
        //        ddlCity.Items.Add(listItem);
        //        for (int i = 0; i < dtCy.Rows.Count; i++)
        //        {
        //            listItem = new ListItem();
        //            listItem.Text = dtCy.Rows[i]["CityName"].ToString();
        //            listItem.Value = dtCy.Rows[i]["CityId"].ToString();
        //            ddlCity.Items.Add(listItem);
        //        }
        //        for (int i = 0; i < ddlCity.Items.Count; i++)
        //        {
        //            if (ddlCity.Items[i].Text == dtCus.Rows[0]["CityName"].ToString())
        //                ddlCity.SelectedIndex = i;
        //        }
        //        txtAddress.Value = dtCus.Rows[0]["Address"].ToString();
        //        txtStreetname.Value = dtCus.Rows[0]["StreetName"].ToString();
        //        txtZipcode.Value = dtCus.Rows[0]["ZipCode"].ToString();
        //        sBankId = dtCus.Rows[0]["BankId"].ToString();

        //        hdnAddress.Value = dtCus.Rows[0]["CityName"].ToString().Trim() + ", " + dtCus.Rows[0]["StateName"].ToString() + ", US";
            }
        }

        //#region .. LOAD COMBO BOX ..

        //void LoadCountry()
        //{
        //    ddlCountry.Items.Clear();
        //    objService = new ServeAtDoorstepService();
        //    DataTable dt1 = objService.SelectAllCountry();
        //    ListItem listItem = new ListItem();
        //    listItem.Text = "<Select Country>";
        //    listItem.Value = "0";
        //    ddlCountry.Items.Add(listItem);
        //    for (int i = 0; i < dt1.Rows.Count; i++)
        //    {
        //        listItem = new ListItem();
        //        listItem.Text = dt1.Rows[i]["CountryName"].ToString();
        //        listItem.Value = dt1.Rows[i]["CountryId"].ToString();
        //        ddlCountry.Items.Add(listItem);
        //    }

        //    ddlCountry.SelectedIndex = 244;
        //    ddlCountry.Disabled = true;
        //}

        //void LoadCity()
        //{
        //    ddlCity.Items.Clear();
        //    objService = new ServeAtDoorstepService();
        //    DataTable dt1 = objService.SelectAllCity();
        //    ListItem listItem = new ListItem();
        //    listItem.Text = "<Select City>";
        //    listItem.Value = "0";
        //    ddlCity.Items.Add(listItem);
        //    for (int i = 0; i < dt1.Rows.Count; i++)
        //    {
        //        listItem = new ListItem();
        //        listItem.Text = dt1.Rows[i]["CityName"].ToString();
        //        listItem.Value = dt1.Rows[i]["CityId"].ToString();
        //        ddlCity.Items.Add(listItem);
        //    }
        //}

        //void LoadState()
        //{
        //    ddlState.Items.Clear();
        //    objService = new ServeAtDoorstepService();
        //    DataTable dt1 = objService.SelectAllState();
        //    ListItem listItem = new ListItem();
        //    listItem.Text = "<Select State>";
        //    listItem.Value = "0";
        //    ddlState.Items.Add(listItem);
        //    for (int i = 0; i < dt1.Rows.Count; i++)
        //    {
        //        listItem = new ListItem();
        //        listItem.Text = dt1.Rows[i]["StateName"].ToString();
        //        listItem.Value = dt1.Rows[i]["StateId"].ToString();
        //        ddlState.Items.Add(listItem);
        //    }
        //}

        //#endregion

    }
}
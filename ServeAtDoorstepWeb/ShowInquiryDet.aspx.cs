using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServeAtDoorstepServiceApp;
using ServeAtDoorstepCommon;

namespace ServeAtDoorstepWeb
{
    public partial class ShowInquiryDet : System.Web.UI.Page
    {
        string sQuiryID = "";
        string sAction = "";
        string strCustomerName = "";
        string[] strImagePath = new string[5];
        string strVideoPath = "";
        string strCreatedOn = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["sQID"] != null)
            {
                sQuiryID = Request.QueryString["sQID"].ToString();
            }
            if (Request.QueryString["sACT"] != null)
            {
                sAction = Request.QueryString["sACT"].ToString();
            }

            
            LoadInquiry(Convert.ToInt32(sQuiryID));
        }

        void LoadInquiry(int intQuiryID)
        {
            string strCusImagePath = "";

            ServeAtDoorstepService objService = new ServeAtDoorstepService();
            DataTable dtQuiry = objService.GetInquiryById(intQuiryID);
            if (dtQuiry.Rows.Count > 0)
            {
                lblTitle.Text = dtQuiry.Rows[0]["InquiryTitle"].ToString();
                lblDesc.Text = dtQuiry.Rows[0]["Description"].ToString();
                lblCatgory.Text = dtQuiry.Rows[0]["CategoryName"].ToString();
                strImagePath = dtQuiry.Rows[0]["ImagePath"].ToString().Split(':');
                strCusImagePath = dtQuiry.Rows[0]["CustomerImagePath"].ToString();
                strVideoPath = dtQuiry.Rows[0]["VideoPath"].ToString();
                lblAddress.Text = dtQuiry.Rows[0]["Address"].ToString() + " " + dtQuiry.Rows[0]["StreetName"].ToString();
                lblCustomerName.Text = dtQuiry.Rows[0]["CustomerName"].ToString();
                lblCity.Text = dtQuiry.Rows[0]["CustomerCity"].ToString();
                lblState.Text = dtQuiry.Rows[0]["CustomerState"].ToString() + " " + dtQuiry.Rows[0]["ZipCode"].ToString();
                strCreatedOn = dtQuiry.Rows[0]["CreatedOn"].ToString();
            }

            spnCusImage.InnerHtml = "<a class='example-image-link' href='" + strCusImagePath + "' data-lightbox='example-1'" +
                                    "title='Or press the right arrow on your keyboard.'>" +
                                    "<img class='example-image' src='" + strCusImagePath + "' alt='Plants: image 2 0f 4 thumb' width='150' height='150' /></a>";
            

            lblPostedOn.Text = strCreatedOn;
            string strDivQImg = "";
            string strJSImg = "<div id='sliderFrame'><div id='slider'>";

            for (int i = 0; i < strImagePath.Length; i++)
            {
                strDivQImg += "<a class='example-image-link' href='"+strImagePath[i]+"' data-lightbox='example-set'"+
                                    "title='Or press the right arrow on your keyboard.'>"+
                                    "<img class='example-image' src='"+strImagePath[i]+"' alt='Plants: image 2 0f 4 thumb' width='100' height='100' /></a>";
                strJSImg += "<img src='" + strImagePath[i] + "' />";
            }
            strJSImg += "</DIV></DIV>";
            //spnImgSlide.InnerHtml = strJSImg;
            divQuiryImag.InnerHtml = strDivQImg;
            spnVideo.InnerHtml = BindUrl(strVideoPath);

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (sAction == "cus")
            {
                Response.Redirect("InboxCustomer.aspx");
            }
            else if (sAction == "ven")
            {
                Response.Redirect("InboxVendor.aspx");
            }
        }

        protected string BindUrl(string filename)
        {
            string htmlSText = "";
            string imageUrl = string.Empty;
            string videoUrl = string.Empty;
            UtilityClass.GetYouTubeURL(filename, out imageUrl, out videoUrl);

            htmlSText = "<object type='video/x-ms-wmv' data='{0}' width='420' height='340'>" +
            "<param name='movie' value='{0}' />" +
            "<param name='wmode' value='transparent' />" +
            "<embed src='{0}' type='video/x-ms-wmv' wmode='transparent' allowscriptaccess='always' allowfullscreen='true' width='480'" +
            "height='385'></embed>" +
            "</object>";
            string sTestHtml = string.Format(htmlSText, filename);

            return sTestHtml;
        }

        //to show modal popup at page startup 
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Panel1.Visible = false;

        }
    }
}
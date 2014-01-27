using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServeAtDoorstepData;
using ServeAtDoorstepServiceApp;
using System.Web.Services;
using System.Web.Script.Services;
using System.Collections.Generic;
using AjaxControlToolkit;

namespace ServeAtDoorstepWeb
{
    public partial class InboxCustomer : System.Web.UI.Page
    {
        ServeAtDoorstepService objService = null;
        DataTable dt = null;
        DataTable dtQuote = null;
        string sLoginType = "", sLoginId = "", sTab = "";
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
            if (Request.QueryString["stab"] != null)
            {
                sTab = Request.QueryString["stab"].ToString();
                if (sTab == "respond")
                {
                    tabMessage.ActiveTabIndex = 1;
                }
                if (sTab == "norespond")
                {
                    tabMessage.ActiveTabIndex = 2;
                }
            }
            if (!IsPostBack)
            {
                LoadCustomerMessage();
                LoadCustomerQuiry();
            }
        
        }


        #region .. INQUIRY LIST ..

        void LoadCustomerQuiry()
        {
            objService = new ServeAtDoorstepService();
            if (sLoginType == "1")
                dtQuote = objService.SelectInquiryByCustomerId(Convert.ToInt32(sLoginId));

            if (dtQuote.Rows.Count > 0)
            {
            }
            else
            {
            }
            gvQuiry.DataSource = dtQuote.DefaultView;
            gvQuiry.DataBind();
        }

        protected void gvQuiry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvQuiry_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image img = e.Row.FindControl("imgCus") as Image;
                img.ImageUrl = dtQuote.Rows[e.Row.RowIndex]["CusImagePath"].ToString();

                string sInqID = gvQuiry.DataKeys[e.Row.RowIndex].Value.ToString();
                ImageButton lnbtnQuiryView = e.Row.FindControl("lnbtnQuiryView") as ImageButton;
                lnbtnQuiryView.Click += new ImageClickEventHandler(lnbtnQuiryView_Click);
            }
        }

        protected void lnbtnQuiryView_Click(object sender, EventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            string sID = gvQuiry.DataKeys[gvrow.RowIndex].Value.ToString();

            Response.Redirect("ShowInquiryDet.aspx?sACT=cus&sQID=" + sID);
        }


        #endregion

        #region .. RESPOND MESSAGE LIST ..

        void LoadCustomerMessage()
        {
            objService = new ServeAtDoorstepService();
            if (sLoginType == "1")
                dt = objService.SelectMessageByCustomerId(Convert.ToInt32(sLoginId));

            if (dt.Rows.Count > 0)
            {
            }
            else
            {
            }
            gvCustomerMessage.DataSource = dt;
            gvCustomerMessage.DataBind();
        }

        protected void gvCustomerMessage_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvCustomerMessage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnk = e.Row.FindControl("lnbtnNewMsgView") as LinkButton;
                lnk.Click += new EventHandler(lnbtnNewMsgView_Click);

                //Image img = e.Row.FindControl("imgCus") as Image;
                //img.ImageUrl = dt.Rows[e.Row.RowIndex]["ImagePath"].ToString();
            }
        }

        protected void imgCloseReply_Click(object sender, ImageClickEventArgs e)
        {
            this.ModalPopupReply.Hide();
        }

        protected void btnMsgReply_Click(object sender, EventArgs e)
        {
            VendorMessageDetails objVenMsgDet = new VendorMessageDetails();
            objVenMsgDet.VendorMessageId = 0;
            objVenMsgDet.VendorId = Convert.ToInt32(hdnVendorId.Value.ToString());
            objVenMsgDet.SendCustomerId = Convert.ToInt32(hdnCustomerId.Value.ToString());
            objVenMsgDet.QuiryId = Convert.ToInt32(hdnQuoteId.Value.ToString());
            objVenMsgDet.CategoryId = Convert.ToInt32(hdnCategoryId.Value.ToString());
            objVenMsgDet.MessageTitle =  txtReplySubject.Text.Trim();
            objVenMsgDet.Description = txtMsgReply.Text.Trim();
            objVenMsgDet.Status = "1";

            objService = new ServeAtDoorstepService();
            int i = objService.AddVendorMessage(objVenMsgDet);

            this.ModalPopupReply.Hide();

        }

        protected void btnCancelReply_Click(object sender, EventArgs e)
        {
            this.ModalPopupReply.Hide();
        }

        protected void lnbtnNewMsgView_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            string sID = gvCustomerMessage.DataKeys[gvrow.RowIndex].Value.ToString();


            ServeAtDoorstepService objService = new ServeAtDoorstepService();
            DataTable dtMsg = objService.SelectCusMessageById(Convert.ToInt32(sID));

            if (dtMsg.Rows.Count > 0)
            {
                hdnCategoryId.Value = dtMsg.Rows[0]["CategoryId"].ToString();
                hdnCustomerId.Value = dtMsg.Rows[0]["CustomerId"].ToString();
                hdnQuoteId.Value = dtMsg.Rows[0]["QuiryId"].ToString();
                hdnVendorId.Value = dtMsg.Rows[0]["VendorID"].ToString();
                txtReplySubject.Text = "Re: " + dtMsg.Rows[0]["MessageTitle"].ToString();
                lblSubject.Text = dtMsg.Rows[0]["MessageTitle"].ToString();
                lblDescription.Text = dtMsg.Rows[0]["Description"].ToString();
                lblCreatedOn.Text = dtMsg.Rows[0]["CreatedOn"].ToString();
                lblVendor.Text = dtMsg.Rows[0]["VendorName"].ToString();
                lblCategory.Text = dtMsg.Rows[0]["CategoryName"].ToString();

            }

            this.ModalPopupReply.Show();
        }

        #endregion

        
    }
}
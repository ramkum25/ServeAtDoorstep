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
    public partial class InboxVendor : System.Web.UI.Page
    {
        ServeAtDoorstepService objService = null;
        DataTable dt = null;
        DataTable dtQuiry = null;
        DataTable dtRespond = null;
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
                LoadVendorMessage();
                LoadVendorQuiry();
                LoadVendorRespondMsg();
            }

        }

        void LoadVendorMessage()
        {
            objService = new ServeAtDoorstepService();
            if (sLoginType == "2")
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

        void LoadVendorQuiry()
        {
            objService = new ServeAtDoorstepService();
            if (sLoginType == "2")
                dtQuiry = objService.SelectInquiryByVendorId(Convert.ToInt32(sLoginId));

            if (dtQuiry.Rows.Count > 0)
            {
            }
            else
            {
            }
            gvQuiry.DataSource = dtQuiry.DefaultView;
            gvQuiry.DataBind();
        }

        void LoadVendorRespondMsg()
        {
            objService = new ServeAtDoorstepService();
            if (sLoginType == "2")
                dtRespond = objService.SelectResMsgByVenId(Convert.ToInt32(sLoginId));

            if (dtRespond.Rows.Count > 0)
            {
            }
            else
            {
            }
            gvRespondMsg.DataSource = dtRespond.DefaultView;
            gvRespondMsg.DataBind();
        }


        protected void gvCustomerMessage_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvCustomerMessage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnk = e.Row.FindControl("lnbtnView") as LinkButton;
                //lnk.Click += new EventHandler(lnbtnView_Click);

                //Image img = e.Row.FindControl("imgCus") as Image;
                //img.ImageUrl = dt.Rows[e.Row.RowIndex]["ImagePath"].ToString();
            }
        }

        protected void gvQuiry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvQuiry_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image img = e.Row.FindControl("imgCus") as Image;
                img.ImageUrl = dtQuiry.Rows[e.Row.RowIndex]["CusImagePath"].ToString();
            
                string sInqID = gvQuiry.DataKeys[e.Row.RowIndex].Value.ToString();
                ImageButton btnQuiryView = e.Row.FindControl("btnQuiryView") as ImageButton;
                btnQuiryView.Click += new ImageClickEventHandler(btnQuiryView_Click);

                ImageButton btnQuiryReply = e.Row.FindControl("btnQuiryReply") as ImageButton;
                btnQuiryReply.Click += new ImageClickEventHandler(btnQuiryReply_Click);
            }
        }

        protected void gvRespondMsg_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
        }

        protected void gvRespondMsg_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Image img = e.Row.FindControl("imgCus") as Image;
                img.ImageUrl = dtRespond.Rows[e.Row.RowIndex]["CusImagePath"].ToString();

                string sInqID = gvQuiry.DataKeys[e.Row.RowIndex].Value.ToString();

                LinkButton lnbtnResMsgView = e.Row.FindControl("lnbtnResMsgView") as LinkButton;
            }
        }

       
        protected void btnQuiryView_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            string sID = gvQuiry.DataKeys[gvrow.RowIndex].Value.ToString();

            Response.Redirect("ShowInquiryDet.aspx?sACT=ven&sQID=" + sID);
        }

        protected void btnQuiryReply_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            string sID = gvQuiry.DataKeys[gvrow.RowIndex].Value.ToString();

            ServeAtDoorstepService objService = new ServeAtDoorstepService();
            DataTable dtQ = objService.GetInquiryById(Convert.ToInt32(sID));

            if (dtQ.Rows.Count > 0)
            {
                hdnCategoryId.Value = dtQ.Rows[0]["CategoryId"].ToString();
                hdnCustomerId.Value = dtQ.Rows[0]["CustomerId"].ToString();
                hdnQuoteId.Value = dtQ.Rows[0]["InquiryID"].ToString();
                //hdnVendorId.Value = dtQ.Rows[0]["VendorID"].ToString();
                lblMsgTitle.Text = dtQ.Rows[0]["InquiryTitle"].ToString();
                lblMsgDesc.Text = dtQ.Rows[0]["Description"].ToString();
                lblMsgDate.Text = dtQ.Rows[0]["CreatedOn"].ToString();
                lblVendorName.Text = dtQ.Rows[0]["CustomerName"].ToString();
                lblCategory.Text = dtQ.Rows[0]["CategoryName"].ToString();

                spnInquiryDet.InnerHtml = @"<div style='float: left; display: block; width: 100%;height:150px;padding-left:25px;'>
                            <table>
                                <tr>
                                    <td>
                                        <div>
                                            <img src='" + dtQ.Rows[0]["CustomerImagePath"].ToString() + "' width='100' height='100' />" +
                                        "</div>" +
                                    "</td>" +
                                    "<td>" +
                                        "<div style='margin-left: 25px;font-family:Calibri;font-size:16px;height:25px;'>" + dtQ.Rows[0]["InquiryTitle"].ToString() + "</div>" +
                                        "<div style='margin-left: 25px;font-family:Calibri;font-size:14px;height:25px;'>By " + dtQ.Rows[0]["CustomerName"].ToString() + "</div>" +
                                        "<div style='margin-left: 25px;font-family:Calibri;font-size:12px;height:25px;'>Category - " + dtQ.Rows[0]["CategoryName"].ToString() + "</div>" +
                                        "<div style='margin-left: 25px;font-family:Calibri;font-size:13px;height:25px;'>" + dtQ.Rows[0]["Description"].ToString() + "</div>" +
                                    "</td>" +
                                "</tr>" +
                            "</table>" +
                        "</div>";
            }
            
            //this.ModalPopupViewMessage.Show();
            txtInquirySubject.Text = "Re: " + dtQ.Rows[0]["InquiryTitle"].ToString();
            this.modpopInquiryReply.Show();
        }

        protected void btnInquiryReply_Click(object sender, EventArgs e)
        {
            ServeAtDoorstepData.CustomerMessageDetails objMsg = new CustomerMessageDetails();
            objMsg.CustomerMessageId = 0;
            objMsg.QuiryId = Convert.ToInt32(hdnQuoteId.Value.ToString());
            objMsg.SendVendorId = Convert.ToInt32(sLoginId);
            objMsg.RecCustomerId = Convert.ToInt32(hdnCustomerId.Value.ToString());
            objMsg.CategoryId = Convert.ToInt32(hdnCategoryId.Value.ToString());
            objMsg.MessageTitle = txtInquirySubject.Text.Trim(); ;
            objMsg.Description = txtInquiryReply.Text.Trim();
            objMsg.Status = "";

            objService = new ServeAtDoorstepService();
            int i = objService.AddCustomerMessage(objMsg);

            txtInquirySubject.Text = "";
            txtInquiryReply.Text = "";

            this.ModalPopupViewMessage.Hide();
        }
      
        protected void btnReply_Click(object sender, EventArgs e)
        {
            ServeAtDoorstepData.CustomerMessageDetails objMsg = new CustomerMessageDetails();
            objMsg.CustomerMessageId = 0;
            objMsg.QuiryId = Convert.ToInt32(hdnQuoteId.Value.ToString());
            objMsg.SendVendorId = Convert.ToInt32(sLoginId);
            objMsg.RecCustomerId = Convert.ToInt32(hdnCustomerId.Value.ToString());
            objMsg.CategoryId = Convert.ToInt32(hdnCategoryId.Value.ToString());
            objMsg.MessageTitle = "Re: " + lblMsgTitle.Text.Trim(); ;
            objMsg.Description = txtReply.Text.Trim();
            objMsg.Status = "";

            objService = new ServeAtDoorstepService();
            int i = objService.AddCustomerMessage(objMsg);

            txtReply.Text = "";

            this.ModalPopupViewMessage.Hide();
        }

        protected void imgCloseMsg_Click(object sender, ImageClickEventArgs e)
        {
            this.ModalPopupViewMessage.Hide();
        }

        protected void lnbtnNewMsgView_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            string sID = gvCustomerMessage.DataKeys[gvrow.RowIndex].Value.ToString();

            ServeAtDoorstepService objService = new ServeAtDoorstepService();
            DataTable dtQ = objService.SelectCusMessageById(Convert.ToInt32(sID));

            if (dtQ.Rows.Count > 0)
            {
                hdnCategoryId.Value = dtQ.Rows[0]["CategoryId"].ToString();
                hdnCustomerId.Value = dtQ.Rows[0]["CustomerId"].ToString();
                hdnQuoteId.Value = dtQ.Rows[0]["QuiryId"].ToString();
                hdnVendorId.Value = dtQ.Rows[0]["VendorID"].ToString();
                lblMsgTitle.Text = dtQ.Rows[0]["MessageTitle"].ToString();
                lblMsgDesc.Text = dtQ.Rows[0]["Description"].ToString();
                lblMsgDate.Text = dtQ.Rows[0]["CreatedOn"].ToString();
                lblVendorName.Text = dtQ.Rows[0]["CustomerName"].ToString();
                lblCategory.Text = dtQ.Rows[0]["CategoryName"].ToString();
            }

            this.ModalPopupViewMessage.Show();
        }

        protected void lnbtnResMsgView_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            string sID = gvRespondMsg.DataKeys[gvrow.RowIndex].Value.ToString();

            ServeAtDoorstepService objService = new ServeAtDoorstepService();
            DataTable dtQ = objService.SelectVenMessageById(Convert.ToInt32(sID));

            if (dtQ.Rows.Count > 0)
            {
                hdnCategoryId.Value = dtQ.Rows[0]["CategoryId"].ToString();
                hdnCustomerId.Value = dtQ.Rows[0]["CustomerId"].ToString();
                hdnQuoteId.Value = dtQ.Rows[0]["QuiryId"].ToString();
                hdnVendorId.Value = dtQ.Rows[0]["VendorID"].ToString();
                lblMsgTitle.Text = dtQ.Rows[0]["MessageTitle"].ToString();
                lblMsgDesc.Text = dtQ.Rows[0]["Description"].ToString();
                lblMsgDate.Text = dtQ.Rows[0]["CreatedOn"].ToString();
                lblVendorName.Text = dtQ.Rows[0]["CustomerName"].ToString();
                lblCategory.Text = dtQ.Rows[0]["CategoryName"].ToString();
            }

            this.ModalPopupViewMessage.Show();
        
        }

    }
}
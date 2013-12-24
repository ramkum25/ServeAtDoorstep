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

namespace ServeAtDoorstepWeb
{
    public partial class MyMessage : System.Web.UI.Page
    {
        ServeAtDoorstepService objService = null;
        DataTable dt = null;
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
                LoadVendorMessage();
            }
        }

        void LoadVendorMessage()
        {
            objService = new ServeAtDoorstepService();
            if (sLoginType == "2")
                dt = objService.SelectMessageByVendorId(Convert.ToInt32(sLoginId));

            if (dt.Rows.Count > 0)
            {
            }
            else
            {
            }
            gvVendorMessage.DataSource = dt;
            gvVendorMessage.DataBind();
        }

        protected void gvVendorMessage_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void lnbtnView_Click(object sender, EventArgs e)
        {

            LinkButton btnEdit = (LinkButton)sender;
            GridViewRow Grow = (GridViewRow)btnEdit.NamingContainer;
            //VendorMessageId

            HiddenField firstCellText = (HiddenField)Grow.Cells[0].FindControl("hdnMessageId");
            string s = firstCellText.Value.ToString();
            pupMessage.ShowPopupWindow();
            //string S = gvVendorMessage.DataKeys[].Value.ToString();

            string sMId = gvVendorMessage.SelectedIndex.ToString();
        }
    
        protected void MycloseWindow(object sender, EventArgs e)
        {

        }

        protected void btnReply_Click(object sender, EventArgs e)
        {
            pupMessage.HidePopupWindow();
        }

        protected void gvVendorMessage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    LinkButton lnk = e.Row.FindControl("lnbtnView") as LinkButton;
            //    lnk.Click += new EventHandler(lnbtnView_Click);
            //}
        }

        protected void gvVendorMessage_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VIEW")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                string S= gvVendorMessage.DataKeys[index].Value.ToString();

                ServeAtDoorstepService objService = new ServeAtDoorstepService();
                DataTable dtMsg = objService.SelectVenMessageById(Convert.ToInt32(S));

                if (dtMsg.Rows.Count > 0)
                {
                    for (int i = 0; i < dtMsg.Rows.Count; i++)
                    {
                        lblMsgTitle.Text = dtMsg.Rows[i]["MessageTitle"].ToString();
                        lblMsgDesc.Text = dtMsg.Rows[i]["Description"].ToString();
                        lblMsgDate.Text = dtMsg.Rows[i]["CreatedOn"].ToString();
                        lblCustomerName.Text = dtMsg.Rows[i]["CustomerName"].ToString();
                        lblCategory.Text = dtMsg.Rows[i]["CategoryName"].ToString();
                    }
                }

                pupMessage.ShowPopupWindow();
            }
        }

        protected void gvVendorMessage_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var lnbtnView = (LinkButton)e.Row.FindControl("lnbtnView");
                lnbtnView.CommandArgument = e.Row.RowIndex.ToString();
            }
        }
    }
}
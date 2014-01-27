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
    public partial class WebForm1 : System.Web.UI.Page
    {
        ServeAtDoorstepService objService = null;
        DataTable dt = null;
        DataTable dtQuote = null;
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
                LoadCustomerQuiry();
            }
        
        }

        void LoadCustomerQuiry()
        {
            objService = new ServeAtDoorstepService();
                dtQuote = objService.SelectInquiryByCustomerId(1);

            if (dtQuote.Rows.Count > 0)
            {
            }
            else
            {
            }
            gvQuiry.DataSource = dtQuote.DefaultView;
            gvQuiry.DataBind();
        }

        //protected void lnbtnView_Click(object sender, EventArgs e)
        //{

        //    LinkButton btnEdit = (LinkButton)sender;
        //    GridViewRow Grow = (GridViewRow)btnEdit.NamingContainer;
        //    //VendorMessageId

        //    HiddenField firstCellText = (HiddenField)Grow.Cells[0].FindControl("hdnMessageId");
        //    string s = firstCellText.Value.ToString();
        //    //pupMessage.ShowPopupWindow();
        //    //string S = gvCustomerMessage.DataKeys[].Value.ToString();

        //    string sMId = gvCustomerMessage.SelectedIndex.ToString();
        //}
        
        protected void gvQuiry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
        }

        protected void gvQuiry_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string sInqID = gvQuiry.DataKeys[e.Row.RowIndex].Value.ToString();
                LinkButton lnbtnQuiryView = e.Row.FindControl("lnbtnQuiryView") as LinkButton;
                if (lnbtnQuiryView != null)
                {
                    lnbtnQuiryView.Attributes.Add("onclick", "javascript:return OpenCenterWindow('" + sInqID + "','View')");
                }
            }
        }

    }
}
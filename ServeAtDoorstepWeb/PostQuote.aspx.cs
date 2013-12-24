using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using ServeAtDoorstepData;
using ServeAtDoorstepServiceApp;

namespace ServeAtDoorstepWeb
{
    public partial class PostQuote : System.Web.UI.Page
    {
        ServeAtDoorstepService objService = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategory();
            }
        }
        void LoadCategory()
        {
            ddlCategory.Items.Clear();
            objService = new ServeAtDoorstepService();
            DataTable dt1 = objService.SelectAllCategory();
            ListItem listItem = new ListItem();
            listItem.Text = "<Select Category>";
            listItem.Value = "0";
            ddlCategory.Items.Add(listItem);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                listItem = new ListItem();
                listItem.Text = dt1.Rows[i]["CategoryName"].ToString();
                listItem.Value = dt1.Rows[i]["CategoryID"].ToString();
                ddlCategory.Items.Add(listItem);
            }
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            QuoteDetails objQuote = new QuoteDetails();
            objQuote.QuoteID = 0;
            objQuote.QuoteTitle = txtQuoteTitle.Value.ToString();
            objQuote.Description = txtQuoteDesc.Value.ToString();
            objQuote.Keywords = txtQuoteKey.Value.ToString();
            objQuote.CategoryId = Convert.ToInt32(ddlCategory.Value.ToString());
            objQuote.CustomerId = Convert.ToInt32(Session["LoginId"].ToString());
            objQuote.CityId = 0;

            objService = new ServeAtDoorstepService();
            int intQuoId = objService.AddQuoteDetails(objQuote);

            DataTable dt = objService.SelectVendorByCategory(objQuote.CategoryId);
            if (dt.Rows.Count > 0)
            {
                for (int intVen = 0; intVen < dt.Rows.Count; intVen++)
                {
                    string sVenEmail = dt.Rows[intVen]["VendorEmail"].ToString();

                    VendorMessageDetails objVenMsgDet = new VendorMessageDetails();
                    objVenMsgDet.VendorMessageId = 0;
                    objVenMsgDet.VendorId = Convert.ToInt32(dt.Rows[intVen]["VendorID"].ToString());
                    objVenMsgDet.SendCustomerId = objQuote.CustomerId;
                    objVenMsgDet.QuoteId = intQuoId;
                    objVenMsgDet.CategoryId = Convert.ToInt32(objQuote.CategoryId);
                    objVenMsgDet.MessageTitle = txtQuoteTitle.Value.ToString();
                    objVenMsgDet.Description = txtQuoteDesc.Value.ToString();
                    objVenMsgDet.Status = "";

                    int intVenMsg = objService.AddVendorMessage(objVenMsgDet);
                }
            }
        }
    }
}
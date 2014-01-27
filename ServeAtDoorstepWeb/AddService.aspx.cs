using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using ServeAtDoorstepData;
using ServeAtDoorstepServiceApp;

namespace ServeAtDoorstepWeb
{
    public partial class AddService : System.Web.UI.Page
    {
        ServeAtDoorstepService objService = null;
        public string strServiceID = "", strAction = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["sID"] != null)
            {
                strServiceID = Request.QueryString["sID"].ToString();
            }
            if (Request.QueryString["sAct"] != null)
            {
                strAction = Request.QueryString["sAct"].ToString();
            }
            l1.Text = strServiceID + strAction;

            if (!IsPostBack)
            {
                LoadCategory();
                if (strAction == "Edit")
                {
                    LoadEditService(Convert.ToInt32( strServiceID));
                }
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

        void LoadEditService(int intServiceID)
        {
            objService = new ServeAtDoorstepService();
            DataTable dt = objService.GetServiceById(intServiceID);
            if(dt.Rows.Count>0)
            {
                txtServiceName.Text = dt.Rows[0]["ServiceName"].ToString();
                txtServiceDesc.Text = dt.Rows[0]["ServiceDescription"].ToString();
                txtServiceKey.Text = dt.Rows[0]["ServiceKeyword"].ToString();
                txtServiceType.Text = dt.Rows[0]["ServiceType"].ToString();
                txtPriceRanFrom.Text = dt.Rows[0]["PriceRangeFrom"].ToString();
                txtPriceRanTo.Text = dt.Rows[0]["PriceRangeTo"].ToString();
                txtNoPair.Text = dt.Rows[0]["NoOfPair"].ToString();
                txtBrandName.Text = dt.Rows[0]["BrandName"].ToString();
                txtBrandType.Text = dt.Rows[0]["BrandType"].ToString();
                ddlCategory.SelectedValue = dt.Rows[0]["CategoryId"].ToString();
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int intErrorCnt = 0;
            string strErrMsg = "";

            if (txtServiceName.Text.Trim() == "")
            {
                intErrorCnt++;
                strErrMsg = "Service Name should not be empty.<br />";
            }
            if (ddlCategory.SelectedIndex==0)
            {
                intErrorCnt++;
                strErrMsg += "Please Select Category.<br />";
            }

            if (txtNoPair.Text.Trim() == "")
            {
                txtNoPair.Text = "0";
            }
            if (intErrorCnt == 0)
            {
                ServeAtDoorstepData.ServiceDetails objData = new ServiceDetails();
                objData.ServiceID = Convert.ToInt32(strServiceID);
                objData.ServiceName = txtServiceName.Text.Trim();
                objData.ServiceDescription = txtServiceDesc.Text.Trim();
                objData.ServiceKeyword = txtServiceKey.Text.Trim();
                objData.ServiceType = txtServiceType.Text.Trim();
                objData.PriceRangeFrom = txtPriceRanFrom.Text.Trim();
                objData.PriceRangeTo = txtPriceRanTo.Text.Trim();
                objData.NoOfPair = Convert.ToInt32(txtNoPair.Text.Trim());
                objData.BrandName = txtBrandName.Text.Trim();
                objData.BrandType = txtBrandType.Text.Trim();
                objData.CategoryId = Convert.ToInt32(ddlCategory.SelectedItem.Value.ToString());

                objService = new ServeAtDoorstepService();
                int i = objService.AddService(objData);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "name", "parent.parent.GB_hide();", true);

                //StringBuilder sb = new StringBuilder();
                //sb.Append("window.opener.RefreshPage();");
                //sb.Append("window.close();");

                //ClientScript.RegisterClientScriptBlock(this.GetType(), "CloseWindowScript",
                //    sb.ToString(), true);

                Response.Write("<script>window.opener.location.reload();</script>");
            }
            else
            {
                divErrorMsg.InnerHtml = strErrMsg;
            }

        }

    }
}
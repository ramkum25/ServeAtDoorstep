using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ServeAtDoorstepData;
using ServeAtDoorstepServiceApp;

namespace ServeAtDoorstepWeb
{
    public partial class Service : System.Web.UI.Page
    {
        ServeAtDoorstepService objService = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindServiceGrid();
                LoadCategory();
                ClearData();

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
        public void BindServiceGrid()
        {
            objService = new ServeAtDoorstepService();
            DataTable dtServ = objService.SelectAllService();

            if (dtServ.Rows.Count > 0)
            {
                //decimal dPageSize = (dt.Rows.Count / 4M);
                //GridView1.PagerSettings.PageButtonCount = Convert.ToInt32(Math.Floor(dPageSize));
                //GridView1.PageSize = Convert.ToInt32(Math.Ceiling(dPageSize));
            }
            gvService.DataSource = dtServ;
            gvService.DataBind();
        }

        protected void gvService_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvService_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //ImageButton lnkEditImg = e.Row.FindControl("imgbtnEdit") as ImageButton;
                //lnkEditImg.Click += new ImageClickEventHandler(lnkEditImg_Click);

                ImageButton lnkDelImg = e.Row.FindControl("imgbtnDelete") as ImageButton;
                //lnkDelImg.Click += new ImageClickEventHandler(lnkDelImg_Click);
                string strname = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ServiceName"));

                lnkDelImg.Attributes.Add("onclick", "javascript:return ConfirmationBox('" + strname + "')");

                //getting username from particular row
                string sServID = gvService.DataKeys[e.Row.RowIndex].Value.ToString();


            }
        }

        protected void lnkDelImg_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            string sID = gvService.DataKeys[gvrow.RowIndex].Value.ToString();
            ServeAtDoorstepService objService = new ServeAtDoorstepService();
            objService.DeleteServiceById(Convert.ToInt32(sID));

            BindServiceGrid();
        }

        protected void lnkEditImg_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            string sID = gvService.DataKeys[gvrow.RowIndex].Value.ToString();

            ServeAtDoorstepService objService = new ServeAtDoorstepService();
            DataTable dt = objService.GetServiceById(Convert.ToInt32(sID));
            if (dt.Rows.Count > 0)
            {
                hdnServiceId.Value = dt.Rows[0]["ServiceID"].ToString();
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

            this.ModalPopupViewMessage.Show();
        }

        protected void gvService_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvService_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvService.EditIndex = e.NewEditIndex;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.ModalPopupViewMessage.Hide();
            ClearData();
        }

        void ClearData()
        {
            divErrorMsg.InnerHtml = "";
            hdnServiceId.Value = "0";
            txtServiceName.Text = "";
            txtServiceDesc.Text = "";
            txtServiceKey.Text = "";
            txtServiceType.Text = "";
            txtPriceRanFrom.Text = "";
            txtPriceRanTo.Text = "";
            txtNoPair.Text = "";
            txtBrandName.Text = "";
            txtBrandType.Text = "";
            ddlCategory.SelectedIndex = 0;
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
            if (ddlCategory.SelectedIndex == 0)
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
                objData.ServiceID = Convert.ToInt32(hdnServiceId.Value.ToString());
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

                this.ModalPopupViewMessage.Hide();
                BindServiceGrid();
                ClearData();

            }
            else
            {
                divErrorMsg.InnerHtml = strErrMsg;
                this.ModalPopupViewMessage.Show();

            }

        }

        protected void lnkAddService_Click(object sender, EventArgs e)
        {
            ClearData();
            this.ModalPopupViewMessage.Show();
        }

        protected void imgClose_Click(object sender, ImageClickEventArgs e)
        {
            ClearData();
            this.ModalPopupViewMessage.Hide();
        }

    }
}
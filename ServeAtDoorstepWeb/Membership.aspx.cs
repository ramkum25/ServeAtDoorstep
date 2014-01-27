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
    public partial class Membership : System.Web.UI.Page
    {
        ServeAtDoorstepService objService = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMemberGrid();
                ClearData();
            }
        }

        public void BindMemberGrid()
        {
            objService = new ServeAtDoorstepService();
            DataTable dtMem = objService.SelectAllMembership();

            if (dtMem.Rows.Count > 0)
            {
                //decimal dPageSize = (dt.Rows.Count / 4M);
                //GridView1.PagerSettings.PageButtonCount = Convert.ToInt32(Math.Floor(dPageSize));
                //GridView1.PageSize = Convert.ToInt32(Math.Ceiling(dPageSize));
            }
            gvMember.DataSource = dtMem;
            gvMember.DataBind();
        }

        protected void gvMember_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvMember_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //ImageButton lnkEditImg = e.Row.FindControl("imgbtnEdit") as ImageButton;
                //lnkEditImg.Click += new ImageClickEventHandler(lnkEditImg_Click);

                ImageButton lnkDelImg = e.Row.FindControl("imgbtnDelete") as ImageButton;
                lnkDelImg.Click += new ImageClickEventHandler(lnkDelImg_Click);
                string strname = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "MemberShipName"));

                lnkDelImg.Attributes.Add("onclick", "javascript:return ConfirmationBox('" + strname + "')");

                //getting username from particular row
                string sServID = gvMember.DataKeys[e.Row.RowIndex].Value.ToString();


            }
        }

        protected void lnkDelImg_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            string sID = gvMember.DataKeys[gvrow.RowIndex].Value.ToString();
            ServeAtDoorstepService objService = new ServeAtDoorstepService();
            objService.DelMembershipById(Convert.ToInt32(sID));

            BindMemberGrid();
        }

        protected void lnkEditImg_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btndetails = sender as ImageButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            string sID = gvMember.DataKeys[gvrow.RowIndex].Value.ToString();

            ServeAtDoorstepService objService = new ServeAtDoorstepService();
            DataTable dt = objService.GetMembershipById(Convert.ToInt32(sID));
            if (dt.Rows.Count > 0)
            {
                hdnMemberId.Value = dt.Rows[0]["MemberShipID"].ToString();
                txtMemberName.Text = dt.Rows[0]["MemberShipName"].ToString();
                txtMemberType.Text = dt.Rows[0]["MemberShipType"].ToString();
                txtAmount.Text = dt.Rows[0]["MemberShipAmount"].ToString();
                txtDays.Text = dt.Rows[0]["MemberShipDays"].ToString();
            }

            this.ModalPopupViewMessage.Show();
        }

        protected void gvMember_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvMember_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMember.EditIndex = e.NewEditIndex;

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.ModalPopupViewMessage.Hide();
            ClearData();
        }

        void ClearData()
        {
            hdnMemberId.Value = "0";
            txtMemberName.Text = "";
            txtMemberType.Text = "";
            txtAmount.Text = "";
            txtDays.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int intErrorCnt = 0;
            string strErrMsg = "";

            if (txtMemberName.Text.Trim() == "")
            {
                intErrorCnt++;
                strErrMsg = "Membership Name should not be empty.<br />";
            }
            if (intErrorCnt == 0)
            {
                ServeAtDoorstepData.MembershipDetails objData = new MembershipDetails();
                objData.MemberShipID = Convert.ToInt32(hdnMemberId.Value.ToString());
                objData.MemberShipName = txtMemberName.Text.Trim();
                objData.MemberShipType = txtMemberType.Text.Trim();
                objData.MemberShipAmount = Convert.ToDecimal(txtAmount.Text.Trim());
                objData.MemberShipDays = Convert.ToInt32(txtDays.Text.Trim());

                objService = new ServeAtDoorstepService();
                int i = objService.AddMembership(objData);

                this.ModalPopupViewMessage.Hide();
                BindMemberGrid();
                ClearData();

            }
            else
            {
                divErrorMsg.InnerHtml = strErrMsg;
                this.ModalPopupViewMessage.Show();

            }

        }

        protected void lnkAddMember_Click(object sender, EventArgs e)
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
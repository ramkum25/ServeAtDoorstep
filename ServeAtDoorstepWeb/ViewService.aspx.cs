using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorldDomination.Net;
using System.Net;
using System.IO;
using Hammock;
using Hammock.Web;
using System.Web.Script.Serialization;
using ServeAtDoorstepData;
using ServeAtDoorstepServiceApp;

namespace ServeAtDoorstepWeb
{
    public partial class ViewService : System.Web.UI.Page
    {
        ServeAtDoorstepService objService = null;

        string strcurrentLocation = string.Empty;

        int intCatID = 0;
        int intServiceID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["sID"] != null)
            {
                intServiceID = Convert.ToInt32(Request.QueryString["sID"].ToString());
            }
            if (!IsPostBack)
            {
                LoadCategoryDiv();
                LoadService();
                BindVendorGrid();

                LoadVendorDiv();
            }
            string IPAdd = string.Empty;
            IPAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];


            if (string.IsNullOrEmpty(IPAdd))
            {
                IPAdd = Request.ServerVariables["REMOTE_ADDR"];
                //lblIPBehindProxy.Text = IPAdd;
            }

            string JSON = GetLocation(IPAdd);
            if (!string.IsNullOrWhiteSpace(JSON))
            {
                JavaScriptSerializer Serializer = new JavaScriptSerializer();
                dynamic dynamicResult = Serializer.Deserialize<dynamic>(JSON);

                //Response.Write(dynamicResult["countryName"].ToString());
                //Response.Write(dynamicResult["countryCode"].ToString());
                //Response.Write(dynamicResult["city"].ToString());
                //Response.Write(dynamicResult["region"].ToString());
                //Response.Write(dynamicResult["latitude"].ToString());
                //Response.Write(dynamicResult["longitude"].ToString());

                currentLocation.InnerText = string.Format(" / Country: {0}/{1}, City: {2}/{3} ",
                    dynamicResult["countryName"].ToString(), dynamicResult["countryCode"].ToString(), dynamicResult["city"].ToString(),
                    dynamicResult["region"].ToString());
                strcurrentLocation = string.Format(" / Country: {0}/{1}, City: {2}/{3} ",
                    dynamicResult["countryName"].ToString(), dynamicResult["countryCode"].ToString(), dynamicResult["city"].ToString(),
                    dynamicResult["region"].ToString());
                if (Session["Location"] == null)
                    Session.Add("Location", dynamicResult["city"].ToString());

            }
            else
            {
                string userHostIpAddress = IPAdd; // "117.197.193.243";
                IPAddress ipAddress;
                //Response.Write("<script>alert('"+userHostIpAddress+"')</Script>");
                if (userHostIpAddress == "::1")
                {
                    userHostIpAddress = "117.197.193.243";
                }
                if (IPAddress.TryParse(userHostIpAddress, out ipAddress))
                {

                    string country = ipAddress.Country(); // return value: UNITED STATES
                    string iso3166TwoLetterCode = ipAddress.Iso3166TwoLetterCode(); // return value: US
                    currentLocation.InnerText = string.Format("Country: {0} / Location: {1} ", country, iso3166TwoLetterCode);
                    strcurrentLocation = string.Format("Country: {0} / Location: {1} ", country, iso3166TwoLetterCode);

                    if (Session["Location"] == null)
                        Session.Add("Location", iso3166TwoLetterCode);
                    //Session.Add("Location", "wyoming");

                }
            }
        }

        private string GetLocation(string ipAd)
        {
            try
            {
                string ipadd = string.Format("http://smart-ip.net/geoip-json/{0}", ipAd);
                var client = new RestClient
                {
                    Authority = ipadd,
                    Method = WebMethod.Get
                };
                var request = new RestRequest();

                var res = client.Request(request);
                if (res.StatusCode != HttpStatusCode.OK) return null;

                return res.Content;
            }
            catch
            {
                return null;
            }

        }

        public void LoadCategoryDiv()
        {
            objService = new ServeAtDoorstepService();
            DataTable dt1 = objService.SelectAllCategory();

            string sCatInnerHtml = "";
            if (strcurrentLocation == "") strcurrentLocation = "Current Location";
            sCatInnerHtml = @"<br/>
                    <strong>
                        <label id='currentLocation' runat='server'>" + strcurrentLocation + "</label></strong>" +
                    "<small style='color: #C03;'>&nbsp;&nbsp;&nbsp;[Change]</small>" +
                    "<br/>" +
                    "<hr/><strong>Category</strong>";

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                sCatInnerHtml += "<br><a href='#' class='CatLink' onclick='Category(" + dt1.Rows[i]["CategoryID"].ToString() + ");'>" + dt1.Rows[i]["CategoryName"].ToString() + "</a>";
            }

            sCatInnerHtml += @"<hr>
	            <strong>Service Type</strong><br>
	            Security Equipment - Products<br>
                Tools - Machinery - Industrial<br>
                TV - DVD - Multimedia<br>
                Video Games - Consoles<br>
                <hr>
	            <strong>Service Days</strong><br>
	            Monday<br>
	            Tuesday<br>
	            Wednesday<br>
                Thursday<br>
                Friday<br>
                Saturday<br>
                Sunday<br>
                <hr>
                <strong>Others</strong><br>
	            Everything Else<br>
                Home & Lifestyle<br><br>
                ";

            divCategory.InnerHtml = sCatInnerHtml;
        }

        public void LoadService()
        {
            objService = new ServeAtDoorstepService();
            DataTable dtServ = objService.GetServiceById(intServiceID);

            if (dtServ.Rows.Count > 0)
            {
                intCatID = Convert.ToInt32(dtServ.Rows[0]["CategoryId"].ToString());
                lblServiceName.Text = dtServ.Rows[0]["ServiceName"].ToString();
                lblServiceType.Text = dtServ.Rows[0]["ServiceType"].ToString();
                lblBrandName.Text = dtServ.Rows[0]["BrandName"].ToString();
                lblBrandType.Text = dtServ.Rows[0]["BrandType"].ToString();
                lblCategoryName.Text = dtServ.Rows[0]["CategoryName"].ToString();
                lblDescription.Text = dtServ.Rows[0]["ServiceDescription"].ToString();
                lblPriceRange.Text ="From "+ dtServ.Rows[0]["PriceRangeFrom"].ToString() +" To "+ dtServ.Rows[0]["PriceRangeTo"].ToString();
            }
        }

        public void BindVendorGrid()
        {
            objService = new ServeAtDoorstepService();
            DataTable dtVend = objService.SelectVendorByService(intServiceID);

            if (dtVend.Rows.Count > 0)
            {
                //decimal dPageSize = (dt.Rows.Count / 4M);
                //GridView1.PagerSettings.PageButtonCount = Convert.ToInt32(Math.Floor(dPageSize));
                //GridView1.PageSize = Convert.ToInt32(Math.Ceiling(dPageSize));
            }
            gvVendor.DataSource = dtVend;
            gvVendor.DataBind();
        }

        public void LoadVendorDiv()
        {
            objService = new ServeAtDoorstepService();
            DataTable dtVendor = objService.SelectVendorByService(intServiceID);
            int intCityCount = 0;
            string[] strVendorCity = new string[dtVendor.Rows.Count];
            string strDivVendor = "";
            if (dtVendor.Rows.Count > 0)
            {
                for(int i=0;i<dtVendor.Rows.Count;i++)
                {
                    strVendorCity[i] = dtVendor.Rows[i]["VendorCity"].ToString();
                }
            }

            int intTotalCount = 0;
            for (int i = 0;( i < strVendorCity.Length && intTotalCount < strVendorCity.Length); i++)
            {
                intCityCount=0;
                int Available = 0;
                for (int j = i; j < strVendorCity.Length; j++)
                {
                    for (int k = 0; k < i; k++)
                    {
                        if (strVendorCity[i] == strVendorCity[k])
                            Available = 1;
                    }

                    if (Available == 1) break;
                    if (strVendorCity[i] == strVendorCity[j] )
                    {
                        intTotalCount++;
                        intCityCount++;
                    }
                }

                if (Available == 0)
                {
                    strDivVendor += "<img src='image/locationg.png' height='40px' width='40px' />&nbsp;&nbsp;" +
                                         strVendorCity[i] + "(&nbsp;<span style='color:blue;'><strong>" + intCityCount.ToString() + "</span></strong>&nbsp;)<br/>";
                }
            }

            divVendor.InnerHtml = strDivVendor;
            if (dtVendor.Rows.Count == 0)
                divVendor.InnerHtml = "No Vendors";


        }

        protected void imgbtn_Click(object sender, ImageClickEventArgs e)
        {
            //ImageButton btndetails = sender as ImageButton;
            //GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            //lblID.Text = gvdetails.DataKeys[gvrow.RowIndex].Value.ToString();
            //lblusername.Text = gvrow.Cells[1].Text;
            //txtfname.Text = gvrow.Cells[2].Text;
            //txtlname.Text = gvrow.Cells[3].Text;
            //this.ModalPopupExtender1.Show();
        }
    }
}
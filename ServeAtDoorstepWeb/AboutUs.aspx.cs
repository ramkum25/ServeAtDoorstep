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
    public partial class AboutUs : System.Web.UI.Page
    {
        ServeAtDoorstepService objService = null;

        string strcurrentLocation = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadCategoryDiv();
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

        void LoadCategoryDiv()
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
    }
}
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
    public partial class index : System.Web.UI.Page
    {
        ServeAtDoorstepService objService = null;

        string strcurrentLocation = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategoryDiv();
                LoadAllServiceDiv();
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

        void LoadCategoryDiv()
        {
            objService = new ServeAtDoorstepService();
            DataTable dt1 = objService.SelectAllCategory();

            string sCatInnerHtml = "";
            if (strcurrentLocation == "") strcurrentLocation = "Current Location";
            sCatInnerHtml = @"<br/>
                    <strong>
                        <label id='currentLocation' runat='server'>"+ strcurrentLocation+"</label></strong>"+
                    "<small style='color: #C03;'>&nbsp;&nbsp;&nbsp;[Change]</small>"+
                    "<br/>"+
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

        void LoadAllServiceDiv()
        {
            objService = new ServeAtDoorstepService();
            DataTable dtServ = objService.SelectAllService();

            string sServiceInnerHtml = "";
            string strCategoryImagePath = "";
        	
        	//<div style="font-size:12px">description of the item description of the item description of the item description of the item</div> 
        	//<div><strong>$136.00</strong></div>
            //</div>";

            for (int i = 0; i < dtServ.Rows.Count; i++)
            {
                if (dtServ.Rows[i]["CategoryName"].ToString().ToUpper().Contains("BELT"))
                {
                    strCategoryImagePath = "image/category/BELT.jpg";
                }
                else if (dtServ.Rows[i]["CategoryName"].ToString().ToUpper().Contains("CLOTH"))
                {
                    strCategoryImagePath = "image/category/CLOTH.jpg";
                }
                else if (dtServ.Rows[i]["CategoryName"].ToString().ToUpper().Contains("COAT"))
                {
                    strCategoryImagePath = "image/category/COAT.jpg";
                }
                else if (dtServ.Rows[i]["CategoryName"].ToString().ToUpper().Contains("ENGRAV"))
                {
                    strCategoryImagePath = "image/category/ENGRAVE.jpg";
                }
                else if (dtServ.Rows[i]["CategoryName"].ToString().ToUpper().Contains("BAG"))
                {
                    strCategoryImagePath = "image/category/HANDBAG.jpg";
                }
                else if (dtServ.Rows[i]["CategoryName"].ToString().ToUpper().Contains("KEY"))
                {
                    strCategoryImagePath = "image/category/KEYCUT.jpg";
                }
                else if (dtServ.Rows[i]["CategoryName"].ToString().ToUpper().Contains("LUGGAGE"))
                {
                    strCategoryImagePath = "image/category/LUGGAGE.jpg";
                }
                else if (dtServ.Rows[i]["CategoryName"].ToString().ToUpper().Contains("SHOE"))
                {
                    strCategoryImagePath = "image/category/SHOE.jpg";
                }
                else if (dtServ.Rows[i]["CategoryName"].ToString().ToUpper().Contains("WATCH"))
                {
                    strCategoryImagePath = "image/category/WATCH.jpg";
                }
                else
                {
                    strCategoryImagePath = "image/serveathome.jpg";
                }

                sServiceInnerHtml += @"<div id='HighlightItem2' style='padding:3px'>";
                sServiceInnerHtml += "<div><strong>" + dtServ.Rows[i]["ServiceName"].ToString() + "</strong></div>";
                sServiceInnerHtml += "<div class='bubbleInfo'>";
                sServiceInnerHtml += "<div><a href='ViewService.aspx?sID=" + dtServ.Rows[i]["ServiceID"].ToString() + "'><img class='trigger' src='" + strCategoryImagePath + "' width='125px' height='150px' /></a></div>";
                sServiceInnerHtml += @"<table id='dpop' class='popup'>
        	                                <tbody><tr>
        		                                <td id='topleft' class='corner'></td>
        		                                <td class='top'></td>
        		                                <td id='topright' class='corner'></td>
        	                                </tr>

        	                                <tr>
        		                                <td class='left'></td>
        		                                <td><table class='popup-contents'>
        			                                <tbody><tr>
        				                                <th>Category:</th>
        				                                <td>&nbsp;&nbsp;" + dtServ.Rows[i]["CategoryName"].ToString() + "</td>" +
        			                                "</tr>" +
        			                                "<tr>" +
        				                                "<th>Service Type:</th>" +
                                                        "<td>&nbsp;&nbsp;" + dtServ.Rows[i]["ServiceType"].ToString() + "</td>" +
        			                                "</tr>" +
        			                                "<tr>" +
        				                                "<th>Brand Name:</th>" +
                                                        "<td>&nbsp;&nbsp;" + dtServ.Rows[i]["BrandName"].ToString() + "</td>" +
        			                                "</tr>" +
        			                                "<tr>" +
        				                                "<th>Brand Type:</th>" +
                                                        "<td>&nbsp;&nbsp;" + dtServ.Rows[i]["BrandType"].ToString() + "</td>" +
        			                                "</tr>" +						
        		                                "</tbody></table>" +

        		                                "</td>" +
        		                                "<td class='right'></td>  " +  
        	                                "</tr>" +

        	                                "<tr>" +
        		                                "<td class='corner' id='bottomleft'></td>" +
        		                                "<td class='bottom'><img width='30' height='29' alt='popup tail' src='image/bubble/bubble-tail2.png'/></td>" +
        		                                "<td id='bottomright' class='corner'></td>" +
        	                                "</tr>" +
                                        "</tbody></table></div>";
                //sServiceInnerHtml += "<div style='font-size:14px'>" + dtServ.Rows[i]["CategoryName"].ToString() + "</div>";
                //sServiceInnerHtml += "<div style='font-size:12px'>" + dtServ.Rows[i]["ServiceType"].ToString() + "</div>";
                sServiceInnerHtml += "<div style='width:100%;height:50px;text-align:center;vertical-align:middle;'><strong><table style='width:100%;'><tr><td class='priceFrom'>From <br/>" + dtServ.Rows[i]["PriceRangeFrom"].ToString() + "</td><td class='priceTo'>To<br/> " + dtServ.Rows[i]["PriceRangeTo"].ToString() + "</td></tr></table></strong></div>";
                sServiceInnerHtml += "</div>";
            }

            divMainItem.InnerHtml = sServiceInnerHtml;
        }
            
    }
}
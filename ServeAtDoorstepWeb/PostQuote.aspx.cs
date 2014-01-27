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
    public partial class PostQuote : System.Web.UI.Page
    {
        ServeAtDoorstepService objService = null;
        private string fileSavePath;

        string strcurrentLocation = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                LoadCategoryDiv();
                LoadCategory();
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
            #region .. VALIDATION ..

            int intError = 0;
            string strErrorMsg = "";
            if (txtQuoteTitle.Value.ToString() == "")
            {
                strErrorMsg += "&nbsp;&nbsp;<img src='image/error.jpg' height='40px' width='40px' />&nbsp;&nbsp;Quiry Title should not be empty. <br/>";
                intError++;
            }
            if (ddlCategory.SelectedIndex == 0)
            {
                strErrorMsg += "&nbsp;&nbsp;<img src='image/error.jpg' height='40px' width='40px' />&nbsp;&nbsp;Please Select Category. <br/>";
                intError++;
            }
            if (FileUpload1.PostedFile.ContentLength == 0 || Request.Form["fileName1"] == null)
            {
                strErrorMsg += "&nbsp;&nbsp;<img src='image/error.jpg' height='40px' width='40px' />&nbsp;&nbsp;Please Upload atleast one image. <br/>";
                intError++;
            }
            if (FileUpload1.PostedFile != null)
            {
                if (FileUpload1.PostedFile.ContentLength > (50 * 1024))
                {
                    strErrorMsg += "&nbsp;&nbsp;<img src='image/error.jpg' height='40px' width='40px' />&nbsp;&nbsp;" + FileUpload1.PostedFile.FileName + " Exceeds maximum limit 50 KB. <br/>";
                    intError++;
                }
            }
            if (FileUpload2.PostedFile != null)
            {
                if (FileUpload2.PostedFile.ContentLength > (50 * 1024))
                {
                    strErrorMsg += "&nbsp;&nbsp;<img src='image/error.jpg' height='40px' width='40px' />&nbsp;&nbsp;" + FileUpload2.PostedFile.FileName + " Exceeds maximum limit 50 KB. <br/>";
                    intError++;
                }
            }
            if (FileUpload3.PostedFile != null)
            {
                if (FileUpload3.PostedFile.ContentLength > (50 * 1024))
                {
                    strErrorMsg += "&nbsp;&nbsp;<img src='image/error.jpg' height='40px' width='40px' />&nbsp;&nbsp;" + FileUpload3.PostedFile.FileName + " Exceeds maximum limit 50 KB. <br/>";
                    intError++;
                }
            }
            if (FileUpload4.PostedFile != null)
            {
                if (FileUpload4.PostedFile.ContentLength > (50 * 1024))
                {
                    strErrorMsg += "&nbsp;&nbsp;<img src='image/error.jpg' height='40px' width='40px' />&nbsp;&nbsp;" + FileUpload4.PostedFile.FileName + " Exceeds maximum limit 50 KB. <br/>";
                    intError++;
                }
            }
            if (FileUpload5.PostedFile != null)
            {
                if (FileUpload5.PostedFile.ContentLength > (50 * 1024))
                {
                    strErrorMsg += "&nbsp;&nbsp;<img src='image/error.jpg' height='40px' width='40px' />&nbsp;&nbsp;" + FileUpload5.PostedFile.FileName + " Exceeds maximum limit 50 KB. <br/>";
                    intError++;
                }
            }

            if (FileUploadVid.PostedFile != null)
            {
                if (FileUploadVid.PostedFile.ContentLength > (500 * 1024))
                {
                    strErrorMsg += "&nbsp;&nbsp;<img src='image/error.jpg' height='40px' width='40px' />&nbsp;&nbsp;" + FileUploadVid.PostedFile.FileName + " Exceeds maximum limit 500 KB. <br/>";
                    intError++;
                }
            }
            #endregion

            if (intError == 0)
            {
                InquiryDetails objQuiry = new InquiryDetails();
                objQuiry.InquiryID = 0;
                objQuiry.InquiryTitle = txtQuoteTitle.Value.ToString();
                objQuiry.Description = txtQuoteDesc.Value.ToString();
                objQuiry.Keywords = "";// txtQuoteKey.Value.ToString();
                objQuiry.CategoryId = Convert.ToInt32(ddlCategory.Value.ToString());
                objQuiry.CustomerId = Convert.ToInt32(Session["LoginId"].ToString());
                objQuiry.CityId = 0;
                objQuiry.ImagePath = "";
                objQuiry.VideoPath = "";

                objService = new ServeAtDoorstepService();
                int intQuoId = objService.AddInquiryDetails(objQuiry);

                #region .. CREATE INQUIRY IMAGE ..

                string path = string.Empty;
                string strImgFinalPath = "";
                string finalPath = string.Empty;
                string filePath = string.Empty;
                int iLoginId = Convert.ToInt32(Session["LoginId"].ToString());
                string sFilename = "";
                if (FileUpload1.PostedFile != null)
                {
                    HttpPostedFile myFile = FileUpload1.PostedFile;
                    int nFileLen = myFile.ContentLength;
                    if (nFileLen != 0)
                    {
                        DirectoryInfo dirInfo = null;
                        fileSavePath = "/Data/IQU_" + iLoginId + "_" + intQuoId + "/Images/";
                        path = Server.MapPath("~" + fileSavePath);
                        if (!Directory.Exists(path))
                        {
                            dirInfo = Directory.CreateDirectory(path);
                        }
                        sFilename = System.IO.Path.GetFileName(myFile.FileName);
                        path = path + "/" + sFilename;
                        FileUpload1.PostedFile.SaveAs(path);

                        finalPath = Path.Combine(fileSavePath, sFilename);
                    }
                }
                strImgFinalPath = finalPath;

                if (FileUpload2.PostedFile != null)
                {
                    HttpPostedFile myFile = FileUpload2.PostedFile;
                    int nFileLen = myFile.ContentLength;
                    if (nFileLen != 0)
                    {
                        path = Server.MapPath("~" + fileSavePath);
                        sFilename = System.IO.Path.GetFileName(myFile.FileName);
                        path = path + "/" + sFilename;
                        FileUpload2.PostedFile.SaveAs(path);

                        finalPath = Path.Combine(fileSavePath, sFilename);

                        strImgFinalPath = strImgFinalPath + ":" + finalPath;
                    }
                }

                if (FileUpload3.PostedFile != null)
                {
                    HttpPostedFile myFile = FileUpload3.PostedFile;
                    int nFileLen = myFile.ContentLength;
                    if (nFileLen != 0)
                    {
                        path = Server.MapPath("~" + fileSavePath);
                        sFilename = System.IO.Path.GetFileName(myFile.FileName);
                        path = path + "/" + sFilename;
                        FileUpload3.PostedFile.SaveAs(path);

                        finalPath = Path.Combine(fileSavePath, sFilename);
                        strImgFinalPath = strImgFinalPath + ":" + finalPath;
                    }
                }

                if (FileUpload4.PostedFile != null)
                {
                    HttpPostedFile myFile = FileUpload4.PostedFile;
                    int nFileLen = myFile.ContentLength;
                    if (nFileLen != 0)
                    {
                        path = Server.MapPath("~" + fileSavePath);
                        sFilename = System.IO.Path.GetFileName(myFile.FileName);
                        path = path + "/" + sFilename;
                        FileUpload4.PostedFile.SaveAs(path);

                        finalPath = Path.Combine(fileSavePath, sFilename);
                        strImgFinalPath = strImgFinalPath + ":" + finalPath;
                    }
                }

                if (FileUpload5.PostedFile != null)
                {
                    HttpPostedFile myFile = FileUpload5.PostedFile;
                    int nFileLen = myFile.ContentLength;
                    if (nFileLen != 0)
                    {
                        path = Server.MapPath("~" + fileSavePath);
                        sFilename = System.IO.Path.GetFileName(myFile.FileName);
                        path = path + "/" + sFilename;
                        FileUpload5.PostedFile.SaveAs(path);

                        finalPath = Path.Combine(fileSavePath, sFilename);
                        strImgFinalPath = strImgFinalPath + ":" + finalPath;
                    }
                }

                sFilename = ""; finalPath = "";
                if (FileUploadVid.PostedFile != null)
                {
                    HttpPostedFile myFile = FileUploadVid.PostedFile;
                    int nFileLen = myFile.ContentLength;
                    if (nFileLen != 0)
                    {
                        DirectoryInfo dirInfo = null;
                        fileSavePath = "/Data/IQU_" + iLoginId + "_" + intQuoId + "/Video/";
                        path = Server.MapPath("~" + fileSavePath);
                        if (!Directory.Exists(path))
                        {
                            dirInfo = Directory.CreateDirectory(path);
                        }
                        sFilename = System.IO.Path.GetFileName(myFile.FileName);
                        path = path + "/" + sFilename;
                        FileUploadVid.PostedFile.SaveAs(path);

                        finalPath = Path.Combine(fileSavePath, sFilename);
                    }
                }
                string strVidFinalPath = finalPath;


                InquiryDetails objIQ = new InquiryDetails();
                objIQ.InquiryID = intQuoId;
                objIQ.ImagePath = strImgFinalPath;
                objIQ.VideoPath = strVidFinalPath;

                objService.UpdateInquiryImages(objIQ);


                #endregion

                #region .. GET CUSTOMER CITY AND ZIPCODE ..
               
                string strCusCity = "";
                string strCusZipcode = "";
                string strVACity = "";
                string strVAZipcode = "";
                DataTable dtCus = objService.GetCustomerById(Convert.ToInt32(Session["LoginId"].ToString()));
                if (dtCus.Rows.Count > 0)
                {
                    strCusCity = dtCus.Rows[0]["CityName"].ToString();
                    strCusZipcode = dtCus.Rows[0]["ZipCode"].ToString();
                }

                #endregion

                DataTable dt = objService.SelectVendorByCategory(objQuiry.CategoryId);
                if (dt.Rows.Count > 0)
                {
                    for (int intVen = 0; intVen < dt.Rows.Count; intVen++)
                    {
                        string sVenEmail = dt.Rows[intVen]["VendorEmail"].ToString();


                        #region .. GET VENDOR AREA ..
                        strVACity = "";
                        strVAZipcode = "";
                        DataTable dtVenArea = objService.SelectAreaByVendorId(Convert.ToInt32(dt.Rows[intVen]["VendorID"].ToString()));
                        if (dtVenArea.Rows.Count > 0)
                        {
                            
                            for (int k = 0; k < dtVenArea.Rows.Count; k++)
                            {
                                strVACity = dtVenArea.Rows[k]["VACityName"].ToString();
                                strVAZipcode = dtVenArea.Rows[k]["VAZipcode"].ToString();

                                if (strVAZipcode == strCusZipcode)
                                {
                                    VendorMessageDetails objVenMsgDet = new VendorMessageDetails();
                                    objVenMsgDet.VendorMessageId = 0;
                                    objVenMsgDet.VendorId = Convert.ToInt32(dt.Rows[intVen]["VendorID"].ToString());
                                    objVenMsgDet.SendCustomerId = objQuiry.CustomerId;
                                    objVenMsgDet.QuiryId = intQuoId;
                                    objVenMsgDet.CategoryId = Convert.ToInt32(objQuiry.CategoryId);
                                    objVenMsgDet.MessageTitle = txtQuoteTitle.Value.ToString();
                                    objVenMsgDet.Description = txtQuoteDesc.Value.ToString();
                                    objVenMsgDet.Status = "0";

                                    int intVenMsg = objService.AddVendorMessage(objVenMsgDet);
                                }
                            }
                        }

                        #endregion
                       
                    }
                }

                divErrorMessage.InnerHtml = "";
                divMessage.InnerHtml = "Your Inquiry posted sucessfully.";

                txtQuoteTitle.Value = "";
                txtQuoteDesc.Value = "";
                ddlCategory.SelectedIndex = 0;
            }
            else
            {
                divErrorMessage.InnerHtml = strErrorMsg;
            }
        }
    }
}
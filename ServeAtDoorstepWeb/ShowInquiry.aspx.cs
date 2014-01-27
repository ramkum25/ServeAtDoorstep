using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using AjaxControlToolkit;
using System.Web.Services;
using System.Web.Hosting;
using System.Web.Script.Services;
using System.Collections.Generic;

namespace ServeAtDoorstepWeb
{
    public partial class ShowInquiry : System.Web.UI.Page
    {
        string sQuiryID = "";
        string sAction = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["sQID"] != null)
            {
                sQuiryID = Request.QueryString["sQID"].ToString();
            }
            if (Request.QueryString["sAct"] != null)
            {
                sAction = Request.QueryString["sAct"].ToString();
            }
        }

        [WebMethod]
        [ScriptMethod]
        public static Slide[] GetImages()
        {
            List<Slide> slides = new List<Slide>();
            string path1 = ConfigurationManager.AppSettings["ApplicationPath"].ToString() + "/Data/IQU/Images/";

            string path = HttpContext.Current.Server.MapPath("/data/iqu/");
            if (path.EndsWith("\\"))
            {
                path = path.Remove(path.Length - 1);
            }
            Uri pathUri = new Uri(path, UriKind.Absolute);
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                Uri filePathUri = new Uri(file, UriKind.Absolute);
                slides.Add(new Slide
                {
                    Name = Path.GetFileNameWithoutExtension(file),
                    Description = Path.GetFileNameWithoutExtension(file) + " Description.",
                    ImagePath = pathUri.MakeRelativeUri(filePathUri).ToString()
                });
            }
            return slides.ToArray();
        }

    }
}
    using SmallestDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmallestDotNet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            bool showGetDotNet = false;
            bool checkDotNet = false;

            var userAgent = HttpUtility.HtmlEncode(Request.UserAgent);
            var userResult = "";

            if (Request.QueryString["realversion"] != null)
            {
                userResult = Helpers.GetUpdateInformation(Request.QueryString["realversion"], Request.Browser.ClrVersion);
            }
            else
            {
                userResult = Helpers.GetUpdateInformation(Request.UserAgent, Request.Browser.ClrVersion);
            }

            if (userResult.Contains("can't")) //This is the worst thing I've ever done. We will fix it soon.
            {
                showGetDotNet = false;
                checkDotNet = true;
            }

            if (userResult.Contains("Mac") || userResult.Contains("Linux")) //No, THIS is the worst thing I've ever done. We will fix it soon.
            {
                showGetDotNet = false;
                checkDotNet = false;
            }

            var developerResult = new DeveloperResult 
            {
                DeveloperOfflineResult = String.Format(@"If you are a developer and are distributing your code on CD or DVD, you might want to download the <a href=""{0}"">FULL OFFLINE .NET 4.5 installation</a> on your media. The download is about 48 MB", Constants.DotNetOffline),
                DeveloperOnlineResult = String.Format(@"If your users have internet connectivity, the .NET Framework is only between 10 and 60 megs. Why such a wide range? Well, it depends on if they already have some version of .NET. If you point your users to the online setup for the {0}, that 980 KB download will automatically detect and download the smallest archive possible to get the job done.", Constants.DotNetOnline)
            };

            var smallestNetModel = new SmallestNetModel 
            {
                DeveloperResult = developerResult,
                UserResult = userResult,
                CheckDotNet = checkDotNet,
                ShowGetDotNet = showGetDotNet,
                UserAgent = userAgent
            };

            return View(smallestNetModel);
        }
    }
}
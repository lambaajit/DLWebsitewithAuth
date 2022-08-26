using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DLWebsiteWithAuth.Controllers
{
    [Authorize]
    public class SMSController : Controller
    {
        WEBDLEntities dbweb = new WEBDLEntities();
        // GET: SMS
        [Authorize]
        public ActionResult Index()
        {
            List<string> staffnumbers = new List<string>();

            staffnumbers = dbweb.Mobiles.Where(x => x.Mobile_no.StartsWith("07") && x.Mobile_no.Length == 11).Select(x => x.Mobile_no).ToList();
            return View(staffnumbers);
        }

        [HttpPost]
        public ActionResult SendSMS(string SMS)
        {
            foreach (var item in dbweb.Mobiles.Where(x => x.Mobile_no.StartsWith("07") && x.Mobile_no.Length == 11).Select(x => x.Mobile_no).ToList())
            {
                sendSMSMessage(SMS, item.Substring(1));
            }
            return RedirectToAction("Thanks", "Home", new { id = "You have sucessfully send SMS to all staff" });
        }

        public string sendSMSMessage(string message1, string number)
        {
            String message = HttpUtility.UrlEncode(message1);
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.txtlocal.com/send/", new NameValueCollection()
                {
                {"apikey" , "NDUzODczNGM1MDRhNmY2NTY4NzI2MzZjNzQ2ZjM3NTA="},
                {"numbers" , "44" + number},
                {"message" , message},
                {"sender" , "Duncan Lewis"}
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                return result;
            }
        }
    }
}
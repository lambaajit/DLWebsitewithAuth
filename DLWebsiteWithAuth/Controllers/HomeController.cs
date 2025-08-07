using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLWebsiteWithAuth;
using DLWebsiteWithAuth.Models;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using CaptchaMvc.HtmlHelpers;
using AutoMapper;
using static System.Net.Mime.MediaTypeNames;
using System.Configuration;
using CaptchaMvc.HtmlHelpers;

namespace DLWebsiteWithAuth.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Contact(string dept, string subDepartment = "", int? hdlId = null)
        {
            WEBDLEntities db = new WEBDLEntities();
            if (db.SubDepartments.Where(x => x.Department == dept).FirstOrDefault() != null)
            {
                ViewBag.dept = dept;
                ViewBag.HousingDisrepairCalculatorId = hdlId;
                if (db.SubDepartments.Where(x => x.SubDepartment1 == subDepartment).FirstOrDefault() != null)
                    ViewBag.SubDepartment = subDepartment;



                //ContactModel cm = new ContactModel();
                //if (subDepartment == "International" && id == 6)
                //{

                //    cm.Ref_SubDepartment = "International Issues [D]";
                //}
                //else
                //    cm.Ref_SubDepartment = "";
                ViewBag.id = "0";
                return View();
            }
            else
            {
                ViewBag.id = "0";
                return View();
            }
        }

        [HttpPost]
        public ActionResult Contact(ContactModel contactModel, string PotentialClaim = "")
        {
            if (this.IsCaptchaValid("Captcha is not valid"))
            {
                WEBDLEntities db = new WEBDLEntities();
                List<string> listOfHackers = db.HackersLists.Select(x => x.emailAddress).Distinct().ToList();
                var _date = DateTime.Now.Date;
                var _checkTodaysEmail = db.EmailScrutinies.Where(x => x.dateOfReferral == _date && x.email.ToLower() == contactModel.Client_email.ToLower()).ToList();
                if (_checkTodaysEmail.Count > 1)
                {
                    return RedirectToAction("Confirmation", "Home", new { id = 5 });
                }
                else
                {
                    EmailScrutiny emailScrutiny = new EmailScrutiny()
                    {
                        dateOfReferral = DateTime.Now.Date,
                        email = contactModel.Client_email,
                    };
                    db.EmailScrutinies.Add(emailScrutiny);
                    db.SaveChanges();
                }
                if (ModelState.IsValid)
                {
                    if (contactModel.QueryType != "Admin" && !listOfHackers.Contains(contactModel.Client_email.ToLower()))
                    {
                        contactModel.Description = contactModel.Description.ReplaceString("select", "^select^");
                        contactModel.Description = contactModel.Description.ReplaceString("drop", "^drop^");
                        contactModel.Description = contactModel.Description.ReplaceString("update", "^update^");
                        contactModel.Description = contactModel.Description.ReplaceString("insert", "^insert^");
                        contactModel.Description = contactModel.Description.ReplaceString("delete", "^delete^");
                        contactModel.Description = contactModel.Description.ReplaceString("script", "^story^");

                        contactModel.Clientname = contactModel.Client_Forename + " " + contactModel.Client_Surname;
                        contactModel.CustomerServiceMember = "Ajit Lamba";
                        contactModel.Step = 1;
                        contactModel.FeeEarner = "Jason Bruce";
                        contactModel.FeeEarnerDepartment = "Switchboard-Team";
                        if (contactModel.Ref_Department == "Education")
                        {
                            contactModel.Description = contactModel.Ref_SubDepartment + Environment.NewLine + contactModel.Description;
                            contactModel.Ref_SubDepartment = "Education";
                            contactModel.Ref_Department = "Public Law";
                        }
                        contactModel.Ref_Department = contactModel.Ref_Department.Replace("Immigration - Asylum and Human Rights", "Immigration").Replace("Immigration - Private and Business", "Business Immigration");


                        contactModel.Preferred_Location = "To Be Evaluated";
                        contactModel.Location = "To Be Evaluated";
                        contactModel.DateRef1 = DateTime.Now;
                        contactModel.Ref_Feeearner = "";
                        contactModel.New_FeeEarner = "";
                        contactModel.Referral_to = "";
                        contactModel.RoomBooked = "No";
                        contactModel.RoomBooked = "No";
                        contactModel.Source = "Online Referral";

                        if (!string.IsNullOrEmpty(PotentialClaim))
                            contactModel.Description = contactModel.Description + Environment.NewLine + Environment.NewLine + "Potential value of claim/dispute: " + PotentialClaim.ToString();


                        ClientReferral cr = new ClientReferral();
                        cr = Mapper.Map<ClientReferral>(contactModel);
                        cr.Cancel = "No";

                        db.ClientReferrals.Add(cr);
                        db.SaveChanges();

                        long maxidstr = db.ClientReferrals.Max(x => x.ID);




                        if (contactModel.Client_email.Contains("@"))
                        {
                            emailfields em = new emailfields();
                            em.To_whom = contactModel.Client_email;
                            em.from_whom = "contact@duncanlewis.com";
                            em.subject = "Your Query with Duncan Lewis";

                            em.msg = "Dear " + contactModel.Clientname + "</br><br />" +
                        "<strong>Thank you for contacting Duncan Lewis Solicitors recently.</strong><br /><br />This automated-reply is to let you know that your query and contact details have been forwarded to the relevant legal team at Duncan Lewis. One of our legal team will contact you at their earliest opportunity (during office hours) to explore if we are able to assist you in this matter. If we are not able to assist you, you will be advised of this by phone or email and signposted accordingly. </br></br>" +
                "<strong> Contact us</strong></br>" +
                "</br>" +
                "For any queries before our first contact with you, please do not hesitate to contact us on 033 3772 0409 and cite your Client Referral ID number, which is " + maxidstr.ToString() + ".<br /><br />" +
            "<strong>Duncan Lewis - We Give People a Voice</strong></br>" +
            "</br>" +
            "We are headquartered in the City of London and have offices nationwide. We are recognised by The Legal 500 and Chambers & Partners UK independent legal directories as a top-tier law firm – \"a diligent and professional team that is prepared to go the extra mile for its clients\".<br /><br />To learn more about Duncan Lewis please visit our website – <a href=\"https://www.duncanlewis.co.uk\">www.duncanlewis.co.uk</a><br /><br />" +
            "<br /><br />Yours Sincerely<br /><br />Duncan Lewis";

                            ExtensionsMethods.sendemail(em);

                        }

                    }
                    else if (!listOfHackers.Contains(contactModel.Client_email.ToLower()))
                    {
                        string msg = "You have received a new DL Online Query under " + contactModel.Ref_Department + ". Please see details below.<br /><br />";
                        msg = msg + ("Query Type: " + contactModel.Ref_Department + "</br>");
                        msg = msg + ("First name * " + contactModel.Client_Forename + "</br></br>");
                        msg = msg + ("Surname *" + contactModel.Client_Surname + "</br></br>");
                        msg = msg + ("Post code * " + contactModel.Client_Postcode + "</br></br>");
                        msg = msg + ("Telephone/Mobile number *" + contactModel.Client_Mob + "</br></br>");
                        msg = msg + ("Email address * " + contactModel.Client_email + "</br></br>");
                        msg = msg + ("Details below:</br>");
                        msg = msg + (contactModel.Description + "</br></br>");
                        msg = msg + ("DateTime: " + DateTime.Now.Date.ToString() + "</br></br>");

                        emailfields em = new emailfields();

                        em.from_whom = contactModel.Client_email;
                        em.To_whom = "jasonb@duncanlewis.com";
                        em.msg = msg;
                        em.cclist = new List<string>();
                        em.bcclist = new List<string>();
                        if (contactModel.Ref_Department == "Client Care")
                            em.cclist.Add("ClientCareTeam@Duncanlewis.com");
                        else if (contactModel.Ref_Department == "Feedback")
                            em.cclist.Add("ClientCareTeam@Duncanlewis.com");
                        else if (contactModel.Ref_Department == "Complaint")
                            em.cclist.Add("ClientCareTeam@Duncanlewis.com");
                        else if (contactModel.Ref_Department == "Facilities")
                            em.cclist.Add("HollieA@Duncanlewis.com");
                        else if (contactModel.Ref_Department == "Finance")
                            em.cclist.Add("KlaudiaD@Duncanlewis.com");
                        else if (contactModel.Ref_Department == "Human Resources")
                            em.cclist.Add("hrindia@duncanlewis.com");
                        else if (contactModel.Ref_Department == "Marketing")
                            em.cclist.Add("Marketing@Duncanlewis.com");
                        else if (contactModel.Ref_Department == "Other")
                        {
                            em.cclist.Add("admin@duncanlewis.com");
                            em.cclist.Add("hrindia@duncanlewis.com");
                            em.cclist.Add("ClientCareTeam@Duncanlewis.com");
                            em.cclist.Add("NarayanaraoP@Duncanlewis.com");
                            em.cclist.Add("MumtazS@Duncanlewis.com");
                        }
                        else if (contactModel.Ref_Department == "Media Enquiry")
                            em.cclist.Add("Marketing@Duncanlewis.com");
                        else if (contactModel.Ref_Department == "Existing Clients")
                        {
                            em.cclist.Add("NewClientSwitchboardTeam@duncanlewis.com");
                            em.cclist.Add("Newclient@duncanlewis.com");
                            em.cclist.Add("clientcareteam@duncanlewis.com");
                        }
                        else if (contactModel.Ref_Department == "Data Protection")
                            em.cclist.Add("DataProtection@duncanlewis.com");


                        em.subject = "DL Online Enquiry - " + contactModel.Ref_Department;
                        em.bcclist.Add("ajitl@duncanlewis.com");
                        em.bcclist.Add("nadiabe@duncanlewis.com");
                        ExtensionsMethods.sendemail(em);
                    }




                    return RedirectToAction("Confirmation", "Home", new { id = 5 });
                }
                else
                    return View(contactModel);
            }
            else
            {
                return View(contactModel);
            }
        }

        // GET: Payment
        [HttpGet]
        [Route("Pay")]
        [Route("Home/Payment")]
        public ActionResult Payment()
        {
            return View();
        }


        [HttpPost]
        public ActionResult PaymentPost([Bind(Include = "ClientReference, ClientName, Caseworker, Amount, Description, Email, ConfirmEmail")] PaymentModel paymentModel)
        {
            if (ModelState.IsValid)
            {
                paymentModel.Date = DateTime.Now;
                Payment _payment = new DLWebsiteWithAuth.Payment();
                _payment = Mapper.Map<DLWebsiteWithAuth.Payment>(paymentModel);

                WEBDLEntities db = new WEBDLEntities();
                db.Payments.Add(_payment);
                db.SaveChanges();
                long cartid = db.Payments.Max(x => x.ID);
                return Redirect("https://secure.worldpay.com/wcc/purchase?instId=434C52C6C192A9130047DE67496&cartId=" + cartid.ToString() + "&amount=" + paymentModel.Amount.ToString() + "&currency=GBP&testMode=0");
            }
            return View();
        }



        public ActionResult Internship()
        {

            TempData["Area"] = GetDepartments();

            TempData["Office"] = GetOffices();

            return View();
        }



        [HttpPost]
        public ActionResult Internship(Internship internship, HttpPostedFileBase FileUpload1, HttpPostedFileBase FileUpload2)
        {
            WEBDLEntities db = new WEBDLEntities();

            Internship i = new Internship();
            bool cv = false, CL = false;
            using (Stream fs = FileUpload1.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    CL = MimeType.ValidateMime(bytes, FileUpload1.FileName);
                    i.Cover_Letter = bytes;

                }
            }
            using (Stream fs = FileUpload2.InputStream)
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    cv = MimeType.ValidateMime(bytes, FileUpload2.FileName);
                    i.CV = bytes;
                }
            }
            if (cv == CL == true)
            {
                i.Name = internship.Name;
                i.Email = internship.Email;
                i.Telephone = internship.Telephone;
                i.Duration = internship.Duration;
                i.LPC = internship.LPC;
                i.BVC = internship.BVC;
                i.LLB = internship.LLB;
                i.Date_Available = internship.Date_Available;
                i.Area1 = internship.Area1;
                i.Area2 = internship.Area2;
                i.Area3 = internship.Area3;
                i.Office1 = internship.Office1;
                i.Office2 = internship.Office2;
                i.Office3 = internship.Office3;
                i.Comments = internship.Comments;
                i.Filename1 = FileUpload1.FileName;
                i.Filename2 = FileUpload2.FileName;
                i.Mon_ST = "10:00";
                i.Mon_ET = "17:00";
                i.Tue_ST = "10:00";
                i.Tue_ET = "17:00";
                i.Wed_ST = "10:00";
                i.Wed_ET = "17:00";
                i.Thu_ST = "10:00";
                i.Thu_ET = "17:00";
                i.Fri_ST = "10:00";
                i.Fri_ET = "17:00";
                i.Status = "Received";
                db.Internships.Add(i);
                db.SaveChanges();
            }
            return RedirectToAction("Confirmation", "Home", new { id = 7 });
        }

        public List<SelectListItem> GetOffices()
        {
            WEBDLEntities db = new WEBDLEntities();

            List<SelectListItem> myOffices = new List<SelectListItem>(){
                new SelectListItem {
            Text = "", Value = ""
        },
                 new SelectListItem {
            Text = "All Offices", Value = "All Offices"
        },
            };
            List<string> str = db.Offices.Where(x => x.Active == true).Select(y => y.Name).ToList();

            foreach (var item in str)
            {
                myOffices.Add(
                new SelectListItem
                {
                    Text = item,
                    Value = item
                });

            }

            return myOffices;
        }

        public List<SelectListItem> GetDepartments()
        {
            List<SelectListItem> myOffices = new List<SelectListItem>(){
                new SelectListItem {
            Text = "", Value = ""
        },
                 new SelectListItem {
            Text = "All Departments", Value = "All Departments"
        },
            };

            WEBDLEntities db = new WEBDLEntities();
            List<string> str = db.Database.SqlQuery<string>("select distinct(Ref_Department) from ClientReferrals where id > 27000000 and Ref_Department <> '' order by Ref_Department").ToList();


            foreach (var item in str)
            {
                myOffices.Add(
                new SelectListItem
                {
                    Text = item,
                    Value = item
                });

            }

            return myOffices;
        }




        [HttpGet]
        public ActionResult Apply(int id = 0)
        {
            WEBDLEntities db = new WEBDLEntities();
            if (id == 0)
            {
                ViewBag.Post_ID = db.Recruitment_DlWeb.Where(x => x.Live == true).Select(y => new SelectListItem { Text = y.Job_Title, Value = y.Job_Ref_Code.ToString(), Selected = (y.Job_Ref_Code == id ? true : false) });
                ViewBag.JobTitle = "Apply for Jobs at Duncan Lewis Solicitors";
            }
            else
            {
                if (db.Recruitment_DlWeb.Where(x => x.Live == true && x.Job_Ref_Code == id).Count() > 0)
                {
                    ViewBag.Post_ID = db.Recruitment_DlWeb.Where(x => x.Live == true && x.Job_Ref_Code == id).Select(y => new SelectListItem { Text = y.Job_Title, Value = y.Job_Ref_Code.ToString(), Selected = (y.Job_Ref_Code == id ? true : false) });
                    ViewBag.JobTitle = db.Recruitment_DlWeb.Where(x => x.Live == true && x.Job_Ref_Code == id).Select(y => "Job Ref Code: " + y.Job_Ref_Code).FirstOrDefault();

                }
                else
                    return RedirectToAction("Confirmation", "Home", new { id = 6 });


            }

            return View();
        }


        public ActionResult Download(string id = null)
        {
            if (id != null && id.Contains("-") && System.IO.File.Exists(Server.MapPath("~") + "\\" + id.Replace("-", ".")))
            {
                var filename = Server.MapPath("~") + "\\" + id.Replace("-", ".");

                Response.Headers["Content-Disposition"] = $"inline; filename=" + id.Replace("-", ".");
                var fileContentResult = new FileContentResult(System.IO.File.ReadAllBytes(filename), "application/" + id.Substring(id.IndexOf("-")))
                {
                    FileDownloadName = id.Replace("-", ".")
                };
                return fileContentResult;
            }
            else
                return null;
        }

        [HttpPost]
        public ActionResult Apply([Bind(Include = "Post_ID,Email,ConfirmEmail,Source,Source_Others,Forename,Surname,consent, eligible_to_work,require_a_visa,details_visa,convicted_by_court,details_convicted_by_court,police_enquires, details_police_enquires, connected_to_DLStaff, previously_worked_DL")] ApplyModel applyModel)
        {
            WEBDLEntities dbweb = new WEBDLEntities();
            //if (this.IsCaptchaValid("Captcha is not valid"))
            //{



            string fileext = "";
            string fileext1 = "";

            HttpPostedFileBase Filename = Request.Files["Filename"];
            HttpPostedFileBase Filename_CoverLetter = Request.Files["Filename_CoverLetter"];

            if (Filename.ContentLength > 10485760 || Filename.FileName.Contains(".") == false || Filename_CoverLetter.ContentLength > 10485760 || Filename_CoverLetter.FileName.Contains(".") == false)
            {
                WEBDLEntities db = new WEBDLEntities();
                ViewBag.Post_ID = db.Recruitment_DlWeb.Where(x => x.Live == true).Select(y => new SelectListItem { Text = y.Job_Title, Value = y.Job_Ref_Code.ToString() });
                return View();
            }



            fileext = Filename.FileName.Substring(Filename.FileName.LastIndexOf("."));
            fileext1 = Filename_CoverLetter.FileName.Substring(Filename_CoverLetter.FileName.LastIndexOf("."));


            //Testing file contents
            Stream fs = Filename.InputStream;
            BinaryReader br = new BinaryReader(fs);
            byte[] bytes = br.ReadBytes((Int32)fs.Length);

            Stream fs1 = Filename_CoverLetter.InputStream;
            BinaryReader br1 = new BinaryReader(fs1);
            byte[] bytes1 = br1.ReadBytes((Int32)fs1.Length);



            if (MimeType.ValidateMime(bytes, Filename.FileName) == true && MimeType.ValidateMime(bytes1, Filename_CoverLetter.FileName) == true && ModelState.IsValid)
            {

                WEBDLEntities db = new WEBDLEntities();

                applyModel.Added_By = "Applicant";
                applyModel.Notes = "Date:" + DateTime.Now.ToString() + Environment.NewLine + "Added By: Applicant " + Environment.NewLine + "Notes Type: General Notes CV added By Applicant**";
                applyModel.Agency = "Online_Application";
                applyModel.Date_CV = DateTime.Now;
                applyModel.Name = applyModel.Forename + " " + applyModel.Surname;
                applyModel.Status = "Application Recieved";
                applyModel.Post_Title = db.Recruitment_DlWeb.Where(x => x.Job_Ref_Code == applyModel.Post_ID).Select(y => y.Job_Title).FirstOrDefault();
                applyModel.Job_ID = applyModel.Post_ID;


                Recruitment _Apply = new Recruitment();
                _Apply = Mapper.Map<Recruitment>(applyModel);
                _Apply.Filename = Filename.FileName;
                _Apply.Filename_CoverLetter = Filename_CoverLetter.FileName;
                db.Recruitments.Add(_Apply);
                db.SaveChanges();

                int lastid = db.Recruitments.Max(x => x.ID);

                if (fileext != "")
                {
                    //applyModel.Filename.SaveAs(Server.MapPath("~") + "/Recruitment_CV/" + lastid + fileext);
                    Recruitment_CV_Binary RCB = new Recruitment_CV_Binary();
                    //using (BinaryReader reader = new BinaryReader(Filename.InputStream))
                    //{
                    RCB.Content = bytes;
                    RCB.FileName = Filename.FileName;
                    RCB.MainId = lastid;
                    RCB.TypeOfDocument = "CV";
                    db.Recruitment_CV_Binary.Add(RCB);
                    db.SaveChanges();
                    //}
                }

                if (fileext1 != "")
                {
                    //applyModel.Filename_CoverLetter.SaveAs(Server.MapPath("~") + "/Recruitment_CV/" + lastid + "_CoverLetter" + fileext1);
                    Recruitment_CV_Binary RCB1 = new Recruitment_CV_Binary();
                    using (var reader = new BinaryReader(Filename_CoverLetter.InputStream))
                    {
                        RCB1.Content = bytes1;
                        RCB1.FileName = Filename_CoverLetter.FileName;
                        RCB1.MainId = lastid;
                        RCB1.TypeOfDocument = "Cover Letter";
                        db.Recruitment_CV_Binary.Add(RCB1);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Confirmation", "Home", new { id = 1 });
            }
            else
            {

                //ViewBag.Post_ID = db.Recruitment_DlWeb.Where(x => x.Live == true).Select(y => new SelectListItem { Text = y.Job_Title, Value = y.Job_Ref_Code.ToString() });
                ViewBag.ErorMsg = "Some Error Occured. Please check the files you are uploading.";
                ViewBag.Post_ID = dbweb.Recruitment_DlWeb.Where(x => x.Live == true && x.Job_Ref_Code == applyModel.Post_ID).Select(y => new SelectListItem { Text = y.Job_Title, Value = y.Job_Ref_Code.ToString(), Selected = (y.Job_Ref_Code == applyModel.Post_ID ? true : false) });
                ViewBag.JobTitle = dbweb.Recruitment_DlWeb.Where(x => x.Live == true && x.Job_Ref_Code == applyModel.Post_ID).Select(y => "Job Ref Code: " + y.Job_Ref_Code).FirstOrDefault();

                return View();
            }

            //}
            //else
            //{
            //    ViewBag.Post_ID = dbweb.Recruitment_DlWeb.Where(x => x.Live == true && x.Job_Ref_Code == applyModel.Post_ID).Select(y => new SelectListItem { Text = y.Job_Title, Value = y.Job_Ref_Code.ToString(), Selected = (y.Job_Ref_Code == applyModel.Post_ID ? true : false) });
            //    ViewBag.JobTitle = dbweb.Recruitment_DlWeb.Where(x => x.Live == true && x.Job_Ref_Code == applyModel.Post_ID).Select(y => "Job Ref Code: " + y.Job_Ref_Code).FirstOrDefault();
            //    ViewBag.ErorMsg = "Error: captcha is not valid.";
            //    return View();
            //}
        }




        public ActionResult Confirmation(int id = 0)
        {





            string message = "";
            if (id != 0)
            {
                if (id == 1)
                    message = "We would like to thank you for the interest shown in our vacancy and our firm.  Due to the high volume of applications received, these are normally processed within the course of a period lasting up to twelve weeks.  It will not be necessary for you to resubmit your application during this period.<br><br> Unfortunately, we are only able to contact candidates short listed for an interview and this is normally done over the telephone or by e-mail (we would use the details provided by you earlier on in the process of application).  In the event that you have not received any further communication from us within the course of twelve weeks after the closing date, your application would have been deemed unsuccessful on this occasion.<br><br> All CVs are destroyed at the end of our recruitment campaigns (after twelve weeks from the published closing date";
                else if (id == 2)
                    message = "Unfortunately we will not be able to process your application on this occasion, as your current skills/knowledge do not appear to match the Essential Selection Criteria for this role.";
                else if (id == 3)
                    message = "Thank you for your confirmation. We look forward to seeing you on the night.";
                else if (id == 4)
                    message = "Thank you for your confirmation.";
                else if (id == 5)
                    message = "Thank you for your enquiry.<br /> Your enquiry has been directed to the relevant department and one of our legal specialists will be in touch with you soon.";
                else if (id == 6)
                    message = "The role for which you are trying to apply is now closed, please go to our career section to see live vacancies";
                else if (id == 7)
                    message = "We have successfully recieved you Internship application. We will contact you when we have suitable requirement";
            }
            //else
            //{
            //    string url = "http://api.ipstack.com/" + HttpContext.Request.ServerVariables["REMOTE_ADDR"].ToString() + "?access_key=d02efa3fc0a43d581d1df1d7feb6a0b0";
            //    var request = System.Net.WebRequest.Create(url);
            //    using (WebResponse wrs = request.GetResponse())
            //    using (Stream stream = wrs.GetResponseStream())
            //    using (StreamReader reader = new StreamReader(stream))
            //    {
            //        string json = reader.ReadToEnd();
            //        var obj = JToken.Parse(json);

            //        //string City = (string)obj["city"];
            //        //string Country = (string)obj["region_name"];
            //        //string CountryCode = (string)obj["country_code"];

            //        DateTime timeUtc = System.DateTime.UtcNow;
            //        TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            //        DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);

            //        var fieldsCollector = new JsonFieldsCollector(obj);
            //        var fields = fieldsCollector.GetAllFields();

            //        string jsonstr = "";

            //        foreach (var field in fields)
            //            jsonstr = jsonstr + $"{field.Key}: '{field.Value}' <br />";
            //        //Response.Write(City + " --- " + Country + " ---- " + CountryCode + " --- " + timeUtc.ToLongTimeString());
            //        Response.Write(jsonstr);
            //    }
            //}
            return View("~/Views/Home/Confirmation.cshtml", null, message);
        }

        [Route("CiscoJabber")]
        public ActionResult JabberVideo()
        {
            return View();
        }

        public ActionResult ParsePage(string htmlpage, string dept = null)
        {
            //StreamWriter fp;
            //fp = System.IO.File.CreateText(Server.MapPath("~") + "/parsepages.txt");
            //fp.WriteLine(htmlpage);
            //if (dept != null)
            //    fp.WriteLine(dept);

            //if (System.IO.File.Exists(Server.MapPath("~") + "/" + dept + "_ourteam/" + htmlpage))
            //{
            //    return File(Server.MapPath("~") + "/" + dept + "_ourteam/" + htmlpage, "text/html");
            //}
            //else
            //{

            parsepagemodel _parsepagemodel = new parsepagemodel();
            if ((dept != null && dept.Contains("_ourteam")) || (Regex.Match(htmlpage, "^[A-Za-z\\d-]+-(Lawyer|Solicitor)-(Barnet|Birmingham|Bradford|Cardiff|Croydon|Hackney|Harrow|Islington|Leeds|Leicester|Liverpool|Luton|Milton-Keynes|New-Cross-Gate|Shepherds-Bush|Slough|Swansea|Tonbridge|Tooting|Dalston|Lewisham)-[A-Za-z\\d-]*$", RegexOptions.IgnoreCase)).Success == true)
            {
                string staffname = "";
                if (htmlpage.Contains("Lawyer") || htmlpage.Contains("Solicitor"))
                    staffname = htmlpage.Substring(0, htmlpage.IndexOf("-", htmlpage.IndexOf("-") + 1)).Replace("-", " ");
                else
                    staffname = htmlpage.Substring(0, htmlpage.IndexOf(".html")).Replace("_", " ");


                WEBDLEntities db = new WEBDLEntities();
                //fp.WriteLine("Ajit");
                //fp.Close();





                if (!string.IsNullOrEmpty(db.StaffWith404Error.Where(x => x.StaffName == staffname).Select(y => y.StaffName).FirstOrDefault()))
                    return View("PageNotFound");


                //team pages





                _parsepagemodel.title = htmlpage.Replace("_", " ").Replace("-", " ").Replace(".html", "");
                _parsepagemodel.keywords = htmlpage.Replace("_", " ").Replace("-", " ").Replace(".html", "");
                _parsepagemodel.description = htmlpage.Replace("_", " ").Replace("-", " ").Replace(".html", "");
                _parsepagemodel.category = "StaffPage";
                _parsepagemodel.h1tag = staffname;

                Staff_Details sd = new Staff_Details();
                sd = db.Staff_Details.Where(x => htmlpage.Contains(x.forename.Replace(" ", "-") + "-" + x.surname.Replace(" ", "-")) || htmlpage.Contains(x.forename + "_" + x.surname)).FirstOrDefault();
                string deptname = (dept != null && dept.Contains("_ourteam")) ? dept : htmlpage;

                if (sd == null)
                {
                    _parsepagemodel.title = _parsepagemodel.title + " " + resolveteampages(deptname).Replace("_ourteam.html", "").Replace("about_managementboard.html", "Our Staff ");
                    _parsepagemodel.description = _parsepagemodel.description + " " + resolveteampages(deptname).Replace("_ourteam.html", "").Replace("about_managementboard.html", "Our Staff ");
                    _parsepagemodel.h1tag = _parsepagemodel.h1tag;// + " - " + resolveteampages(deptname).Replace("_ourteam.html", "").Replace("about_managementboard.html", "Our Staff ");
                    _parsepagemodel.text = "<h3>This individual no longer works for Duncan Lewis. Click here to view our " + resolveteampages(deptname).Replace("_ourteam.html", "").Replace("about_managementboard.html", "Our Staff ") + " team.</h3> <br /><br /><a href=\"/" + resolveteampages(deptname) + "\" class=\"btn btn-primary\" />Please click here to visit our " + resolveteampages(deptname).Replace("_ourteam.html", "").Replace("about_managementboard.html", "Our Staff ") + " team</a>";
                }
                else
                {
                    string url = getRewriteUrlLinkForStaff(sd);
                    if (System.IO.File.Exists(Server.MapPath("~") + "/" + sd.department_it.Replace(" ", "") + "_ourteam/" + sd.forename + "_" + sd.surname + ".html"))
                    {
                        //return File(Server.MapPath("~") + "/" + sd.department_it.Replace(" ", "") + "_ourteam/" + sd.forename + "_" + sd.surname + ".html", "text/html");
                        string url1 = "https://www.duncanlewis.co.uk/" + sd.department_it.Replace(" ", "") + "_ourteam/" + sd.forename + "_" + sd.surname + ".html";
                        _parsepagemodel.text = "Please click <a href=\"" + url1 + "\" style=\"font-size:24px !Important; font-weight:bold !Important\">here</a> to see the Profile of " + staffname;
                        return Redirect(url1);
                    }
                    else
                    {
                        _parsepagemodel.text = "Please click <a href=\"/" + url + "\" style=\"font-size:24px !Important; font-weight:bold !Important\">here</a> to see the Profile of " + staffname;
                        return Redirect(url);
                    }

                }

            }

            return View(_parsepagemodel);
            //}
        }

        [HttpGet]
        public ActionResult Unsubscribe()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Unsubscribe(UnsubscribeEmail unsubscribeEmail)
        {
            if (ModelState.IsValid)
            {
                WEBDLEntities db = new WEBDLEntities();
                unsubscribeEmail.DateOfRequest = DateTime.Now;
                db.UnsubscribeEmails.Add(unsubscribeEmail);
                db.SaveChanges();
                emailfields em = new emailfields();
                em.from_whom = "it@duncanlewis.com";
                em.To_whom = "dataprotection@duncanlewis.com";
                em.subject = "Request to remove " + unsubscribeEmail.email + " from Marketing email list";
                em.msg = "We have received a request from " + unsubscribeEmail.email + " on " + unsubscribeEmail.DateOfRequest.Value.ToShortDateString() + ", requesting to be removed from marketing email list.";
                ExtensionsMethods.sendemail(em);
            }
            else
            {
                return View();
            }
            return RedirectToAction("Thanks", "Home", new { id = "Unsubscribe" });
        }


        public ActionResult HousingDisrepairCalculator(int? Id = null)
        {
            WEBDLEntities db = new WEBDLEntities();
            if (Id == null)
                return View();
            else
                return View(db.HousingDisrepairCalculators.Where(x => x.Id == Id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult HousingDisrepairCalculatorPost(HousingDisrepairCalculator housingDisrepairCalculator, List<string> TypesOfDisrepair)
        {
            WEBDLEntities db = new WEBDLEntities();
            housingDisrepairCalculator.TypesOfDisrepair = string.Join(",", TypesOfDisrepair);
            var _numberOfMonths = (DateTime.Now - housingDisrepairCalculator.DateDisrepairReported).Value.Days / 30;
            if (housingDisrepairCalculator.DisrepairRectified == "Yes" && housingDisrepairCalculator.DateDisrepairRectified != null)
            {
                _numberOfMonths = (housingDisrepairCalculator.DateDisrepairRectified - housingDisrepairCalculator.DateDisrepairReported).Value.Days / 30;
            }
            var _cost = (_numberOfMonths * housingDisrepairCalculator.Rent) * (((decimal)housingDisrepairCalculator.SeverityOfDisrepair * 20) / 100);
            if (housingDisrepairCalculator.RentArrearsValue != null && housingDisrepairCalculator.RentArrearsValue > 0)
                _cost = _cost - housingDisrepairCalculator.RentArrearsValue;

            if (housingDisrepairCalculator.PersonalBelongingsValue != null && housingDisrepairCalculator.PersonalBelongingsValue > 0)
                _cost = _cost + housingDisrepairCalculator.PersonalBelongingsValue;

            housingDisrepairCalculator.Cost = _cost;


            db.HousingDisrepairCalculators.Add(housingDisrepairCalculator);
            db.SaveChanges();
            var id = db.HousingDisrepairCalculators.Max(x => x.Id);
            return RedirectToAction("Thanks", "Home", new { id = "HousingDisrepairCalculator", housingDesrepairCost = housingDisrepairCalculator.Cost, hdlId = id });
        }


        public ActionResult GoogleReviewOffice()
        {
            return View();
        }


        public JsonResult getDepartmentsvalues()
        {
            WEBDLEntities db = new WEBDLEntities();
            List<dropdownlistvalues> sds = db.SubDepartments.Where(x => x.Active == true).GroupBy(y => y.Department).OrderBy(z => z.Key).Select(x => new dropdownlistvalues { text = x.Key.Trim(), Value = x.Key.Trim() }).ToList();
            return Json(sds, JsonRequestBehavior.AllowGet);
        }


        public JsonResult getSubDepartments(string id)
        {
            WEBDLEntities db = new WEBDLEntities();
            List<string> sds = db.SubDepartments.Where(x => x.Department == id).GroupBy(m => m.SubDepartment1).OrderBy(y => y.Key).Select(x => x.Key.Trim()).ToList();
            if (sds.Contains("Others") == false && id != "Education Law")
                sds.Add("Others");
            return Json(sds, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Thanks(string id, decimal? housingDesrepairCost = null, int hdlId = 0)
        {
            if (id != null)
            {
                if (id.Equals("OANConfirmation"))
                {
                    ViewBag.Message = @"<br/><br/> You have submitted your Outdoor Attendance Sheet. This has been sent to your Supervisor for his / her approval.<br/><br/> 
                                        Please note you can only print this attendance sheet from your outdoor attendance inbox once it has been approved by your Supervisor.";
                }
                else if (id.Equals("Unsubscribe"))
                {
                    ViewBag.Message = @"<br/><br/> Sorry to see you go... We have received your request to unsubscribe from our mailing list. Please allow 72 hours to process your request after which you should no longer receive any emails from us. <br /><br/>
                                        However please note that this will only unsubscribe you from our marketing emails and any case related emails will still be sent to this email address.";
                }
                else if (id.Equals("Subscribe"))
                {
                    ViewBag.Message = "<br/><br/>Thank you for subscribing to our legal updates and newsletter.<br/><br/>" +
                    "We take your data privacy very seriously and will always treat your information as such. If at any point you would like to review how we communicate with you, or if you are interested in other areas of Duncan Lewis’ work you can contact us at <a href=\"mailto:marketing@duncanlewis.com\">marketing@duncanlewis.com</a><br/><br/> " +
                    "Thank you for your continued interest.<br/><br/>" +
                    "Best wishes<br/><br/>" +
                    "Duncan Lewis Marketing Department";
                }
                else if (id.Equals("SlotBooking"))
                {
                    ViewBag.Message = "<br/><br/>Your request for the video call has been submitted successfully.<br/><br/>" +
                    "We will confirm you via email when your request is accepted by a legal representative.<br/><br/> " +
                    "Thank you for your interest.<br/><br/>" +
                    "Best wishes<br/><br/>" +
                    "Duncan Lewis Solicitors";
                }
                else if (id.Equals("HousingDisrepairCalculator"))
                {
                    ViewBag.Message = "<br/><br/>Based on your details submitted your claim could be worth* an estimated: " + (housingDesrepairCost ?? 0) + "<br/><br/>" +
                    "<p style=\"font-size:12px !important\">*This tool provides an estimate of compensation in a housing disrepair claim or unfitness for human habitation claim (Homes Act). This is not necessarily the amount of compensation you will be awarded. Actual compensation may be higher or lower as each case is different, and some cases may settle for a different amount before reaching trial. Our aim is to look at your case and give you a breakdown of what you may claim.<br/><br/> " +
                    "For a more accurate and detailed estimation of how much compensation you could be owed, please contact our Housing team via the Contact Us button below. A copy of your completed calculator submission will be sent to our Housing team to consider before their first contact with you.</p><br/>" +
                    "<div class=\"deptcontactus dept_Housing lightkolor\"><span class=\"dept_Housing forecolor\">PLEASE CONTACT US TO MAKE A DISREPAIR CLAIM NOW</span><a class=\"deptcontactus dept_Housing kolor\" href=\"/Home/Contact/?dept=Housing&amp;subDepartment=Disrepair - Tenant&amp;hdlId=" + hdlId + "\">Contact Us</a></div>";
                }
                else
                {
                    ViewBag.Message = "<h5>" + id + "</h5>";
                }


                return View();
            }
            else
            {
                return Redirect("https://www.duncanlewis.co.uk/");
            }
        }

        public static string getRewriteUrlLinkForStaff(Staff_Details _Empdetails)
        {
            string Name = _Empdetails.forename + ' ' + _Empdetails.surname;
            string jobtitle1 = "";

            if (_Empdetails.nonadmitted_staff == "1")
                jobtitle1 = "Lawyer";
            else
                jobtitle1 = "Solicitor";

            string url = "";

            url = Name.ToString().Replace(" ", "-") + "-" + _Empdetails.department_it.ToString().Replace(" ", "-") + "-" + jobtitle1 + "-" + _Empdetails.office_name.Replace(" ", "-") + "-/";
            return url;
        }

        [Route("remote")]
        public ActionResult Remote()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Download/";
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + "DLRemote2.rdp");
            string fileName = "DLRemote2.rdp";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [Route("HarrowRemoteServer")]
        public ActionResult RemoteHarrow()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Download/";
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + "DLRemote1.rdp");
            string fileName = "DLRemote2.rdp";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [Route("Jabber")]
        public ActionResult Remote2()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Download/";
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + "CiscoJabberSetup.msi");
            string fileName = "CiscoJabberSetup.msi";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [Route("ciscovpn")]
        public ActionResult Remote3()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Download/";
            byte[] fileBytes = System.IO.File.ReadAllBytes(path + "anyconnect-win-4.8.03036-core-vpn-webdeploy-k9.exe");
            string fileName = "anyconnect-win-4.8.03036-core-vpn-webdeploy-k9.exe";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        public string resolveteampages(string htmlpage)
        {
            if (htmlpage.ToLower().Contains("action-against-public-authorities")) { return "Action-Against-Public-Authorities_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("business-immigration")) { return "businessimmigration_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("child-care")) { return "childcare_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("clinical-negligence")) { return "ClinicalNegligence_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("community-care")) { return "communitycare_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("crime")) { return "crime_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("debt")) { return "debt_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("employment")) { return "employment_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("wills-and-probate")) { return "willsprobate_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("family")) { return "family_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("housing")) { return "housing_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("civil-liberties-and-human-rights")) { return "HumanRights_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("islamic-law")) { return "IslamicLaw_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("civil-litigation")) { return "litigation_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("mental-health")) { return "mentalhealth_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("personal-injury")) { return "personalinjury_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("prison-law")) { return "prisonlaw_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("professional-negligence")) { return "ProfessionalNegligence_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("public-law")) { return "publiclaw_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("welfare-benefits")) { return "welfarebenefits_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("regulatory-law")) { return "ProfessionalRegulations_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("court-of-protection")) { return "courtofprotection_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("motoring-law")) { return "motoringlaw_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("commercial-&-company")) { return "Commercial_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("commercial-litigation-&-disputes")) { return "Commercial_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("commercial-property-services")) { return "Commercial_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("business-crime-&-investigation")) { return "Crime_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("international-disputes")) { return "InternationalDisputes_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("charities")) { return "Charities_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("businessimmigration")) { return "businessimmigration_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("childcare")) { return "childcare_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("clinicalnegligence")) { return "ClinicalNegligence_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("communitycare")) { return "communitycare_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("willsandprobate")) { return "willsprobate_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("civillibertiesandhumanrights")) { return "HumanRights_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("islamiclaw")) { return "IslamicLaw_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("civillitigation")) { return "litigation_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("litigation")) { return "litigation_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("mentalhealth")) { return "mentalhealth_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("personalinjury")) { return "personalinjury_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("prisonlaw")) { return "prisonlaw_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("professionalnegligence")) { return "ProfessionalNegligence_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("publiclaw")) { return "publiclaw_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("welfarebenefits")) { return "welfarebenefits_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("regulatorylaw")) { return "ProfessionalRegulations_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("courtofprotection")) { return "courtofprotection_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("motoringlaw")) { return "motoringlaw_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("internationaldisputes")) { return "InternationalDisputes_ourteam.html"; }
            else if (htmlpage.ToLower().Contains("immigration")) { return "Immigration_ourteam.html"; }
            else { return "about_managementboard.html"; }

        }


        [HttpPost]
        public void TrustPilotReview()
        {
            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();
            TrustpilotObject _TrustpilotObject = JsonConvert.DeserializeObject<TrustpilotObject>(json);
            StreamWriter fp;
            fp = System.IO.File.CreateText(Server.MapPath("~") + "/test.txt");
            foreach (var item in _TrustpilotObject.events)
            {
                fp.WriteLine(item.eventData.referenceId + Environment.NewLine);
                fp.WriteLine(item.eventData.text + Environment.NewLine);
            }
            fp.WriteLine(Environment.NewLine);
            fp.WriteLine(json);

            fp.Close();

            foreach (var item in _TrustpilotObject.events)
            {
                Trustpilot_Webhooks TPWH = new Trustpilot_Webhooks();
                TPWH.ConsumerId = item.eventData.consumer.id;
                TPWH.ConsumerName = item.eventData.consumer.name;
                TPWH.createdAt = item.eventData.createdAt;
                TPWH.EventId = item.eventData.id;
                TPWH.IsVerified = item.eventData.isVerified;
                TPWH.Language = item.eventData.language;
                TPWH.Link = item.eventData.link;
                TPWH.LocationId = item.eventData.locationId;
                TPWH.ReferenceId = item.eventData.referenceId;
                TPWH.Stars = item.eventData.stars;
                TPWH.Text = item.eventData.text;
                TPWH.Title = item.eventData.title;
                WEBDLEntities dbweb = new WEBDLEntities();
                dbweb.Trustpilot_Webhooks.Add(TPWH);
                dbweb.SaveChanges();

            }


        }


        [HttpPost]
        public void ReviewSolicitors()
        {
            Stream req = Request.InputStream;
            req.Seek(0, System.IO.SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();
            //ReviewSolilitorsModel _reviewSolilitorsModel = JsonConvert.DeserializeObject<ReviewSolilitorsModel>(json);
            StreamWriter fp;
            fp = System.IO.File.CreateText(Server.MapPath("~") + "/test" + DateTime.Now.ToString() + ".txt");
            fp.WriteLine("Ajit");
            fp.WriteLine(json);
            fp.WriteLine(Environment.NewLine);
            fp.Close();

            //foreach (var item in _TrustpilotObject.events)
            //{
            //    Trustpilot_Webhooks TPWH = new Trustpilot_Webhooks();
            //    TPWH.ConsumerId = item.eventData.consumer.id;
            //    TPWH.ConsumerName = item.eventData.consumer.name;
            //    TPWH.createdAt = item.eventData.createdAt;
            //    TPWH.EventId = item.eventData.id;
            //    TPWH.IsVerified = item.eventData.isVerified;
            //    TPWH.Language = item.eventData.language;
            //    TPWH.Link = item.eventData.link;
            //    TPWH.LocationId = item.eventData.locationId;
            //    TPWH.ReferenceId = item.eventData.referenceId;
            //    TPWH.Stars = item.eventData.stars;
            //    TPWH.Text = item.eventData.text;
            //    TPWH.Title = item.eventData.title;
            //    WEBDLEntities dbweb = new WEBDLEntities();
            //    dbweb.Trustpilot_Webhooks.Add(TPWH);
            //    dbweb.SaveChanges();

            //}


        }


    }


    public class dropdownlistvalues
    {
        public string text { get; set; }
        public string Value { get; set; }
    }

    public class JsonFieldsCollector
    {
        private readonly Dictionary<string, JValue> fields;

        public JsonFieldsCollector(JToken token)
        {
            fields = new Dictionary<string, JValue>();
            CollectFields(token);
        }

        private void CollectFields(JToken jToken)
        {
            switch (jToken.Type)
            {
                case JTokenType.Object:
                    foreach (var child in jToken.Children<JProperty>())
                        CollectFields(child);
                    break;
                case JTokenType.Array:
                    foreach (var child in jToken.Children())
                        CollectFields(child);
                    break;
                case JTokenType.Property:
                    CollectFields(((JProperty)jToken).Value);
                    break;
                default:
                    fields.Add(jToken.Path, (JValue)jToken);
                    break;
            }
        }

        public IEnumerable<KeyValuePair<string, JValue>> GetAllFields() => fields;
    }

    public class Consumer
    {
        public string id { get; set; }
        public string name { get; set; }
        public string link { get; set; }
    }

    public class EventData
    {
        public string id { get; set; }
        public string language { get; set; }
        public int stars { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public string locationId { get; set; }
        public string referenceId { get; set; }
        public DateTime createdAt { get; set; }
        public string link { get; set; }
        public bool isVerified { get; set; }
        public Consumer consumer { get; set; }
    }

    public class Event
    {
        public string eventName { get; set; }
        public string version { get; set; }
        public EventData eventData { get; set; }
    }

    public class TrustpilotObject
    {
        public List<Event> events { get; set; }
    }

    public class ReviewSolilitorsModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string text { get; set; }
        public int rating { get; set; }
        public Stats stats { get; set; }
        public string areaOfLaw { get; set; }
        public string solicitor { get; set; }
        public string caseReference { get; set; }
        public bool satisfied { get; set; }
        public bool recommended { get; set; }
    }

    public class Stats
    {
        public int services { get; set; }
        public int knowledge { get; set; }
        public int approachability { get; set; }
        public int professionalism { get; set; }
        public int value_for_money { get; set; }
        public int initial_impression { get; set; }
    }

    public class MimeType
    {

        private static readonly byte[] DOC = { 208, 207, 17, 224, 161, 177, 26, 225 };
        private static readonly byte[] PDF = { 37, 80, 68, 70, 45, 49, 46 };
        private static readonly byte[] DOCX = { 80, 75, 3, 4 };
        public static bool ValidateMime(byte[] file, string fileName)
        {

            if (file.Take(8).SequenceEqual(DOC) || file.Take(7).SequenceEqual(PDF) || (file.Take(4).SequenceEqual(DOCX) && (fileName.Contains(".docx") || fileName.Contains(".DOCX") || fileName.Contains(".Docx"))))
                return true;
            else
                return false;

        }
    }



}
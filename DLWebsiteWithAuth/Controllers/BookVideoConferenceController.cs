using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DLWebsiteWithAuth.Controllers
{
    public class BookVideoConferenceController : Controller
    {

        WEBDLEntities db = new WEBDLEntities();
        // GET: BookVideoConference

        [Route("Video-Consultation-with-Solicitor-Lawyer")]
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult getslotsPV(string department)
        {
            List<Slots> slots = getslots(department);
            return PartialView("~/Views/BookVideoConference/TimeSlotsPartial.cshtml",slots);
        }


        public static List<Slots> getslots(string department)
        {
            List<Slots> slots = new List<Slots>();
            int RNo = 1;
            for (int i = 1; i <= 7; i++)
            {
                DateTime dt1 = DateTime.Now.AddDays(i);
                if (new DateTime(dt1.Year, dt1.Month, dt1.Day).DayOfWeek != DayOfWeek.Saturday && new DateTime(dt1.Year, dt1.Month, dt1.Day).DayOfWeek != DayOfWeek.Sunday)
                {
                    for (int x = 9; x <= 17; x++)
                    {
                        for (int j = 0; j <= 59; j = j + 30)
                        {
                            DateTime dt2 = new DateTime(dt1.Year, dt1.Month, dt1.Day, x, j > 0 ? 30 : 0, 0);
                            WEBDLEntities db = new WEBDLEntities();
                            var slotbooked = db.VideoCallRequests.Where(m => m.Timeslot == dt2 && m.Department == department).FirstOrDefault();

                            if (slotbooked == null)
                            {
                                slots.Add(new Slots { Slot = dt2, Active = true, DayNumber = i, HourNumber = x, MinuteNumber = j,  id = RNo, department=department });
                            }
                            else
                            {
                                slots.Add(new Slots { Slot = dt2, Active = false, DayNumber = i, HourNumber = x, MinuteNumber = j, id = RNo, department = department });
                            }
                            RNo++;
                        }
                    }
                }
                //DateTime dt = new DateTime(dt1.Year, dt1.Month, dt1.Day, dt1.Hour, dt1.Minute > 30 ? 30 : 0, 0);
            }

            slots = slots.OrderBy(x => x.Slot).ToList();
            return slots;
        }

        public ActionResult CLientDetails(string department, int? id = null)
        {
            if (id != null)
            {
                List<Slots> slots = getslots(department);
                VideoCallRequest videoCallRequest = new VideoCallRequest();
                videoCallRequest.Timeslot = slots.Where(x => x.id == id).Select(y => y.Slot).FirstOrDefault();
                ViewBag.Department = department;
                //ViewBag.Department = db.Database.SqlQuery<SelectListItem>("select name as Text, name as Value from Website_Department_Structure where departmenttype = 'AreaOfLaw' order by Name").ToList();
                return View(videoCallRequest);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public ActionResult ClientDetailsUpdate(VideoCallRequest videoCallRequest)
        {
            if (videoCallRequest != null)
            {
                videoCallRequest.Status = "Pending";
                videoCallRequest.SubmittedDate = DateTime.Now;
                db.VideoCallRequests.Add(videoCallRequest);
                db.SaveChanges();
                return RedirectToAction("Thanks", "Home", new { id = "SlotBooking" });
            }
            else
            {
                ViewBag.Department = db.Database.SqlQuery<string>("select name from Website_Department_Structure where departmenttype = 'AreaOfLaw' order by Name").ToList();
                return View(videoCallRequest);
            }
        }
    }
}
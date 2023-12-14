using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DLWebsiteWithAuth;

namespace DLWebsiteWithAuth.Controllers
{
    public class OfficesController : ApiController
    {
        private WEBDLEntities db = new WEBDLEntities();

        // GET: api/Offices
        public IQueryable<Office> GetOffices()
        {
            return db.Offices;
        }

        // GET: api/Offices/5
        [ResponseType(typeof(Office))]
        public IHttpActionResult GetOffice(int id)
        {
            Office office = db.Offices.Find(id);
            if (office == null)
            {
                return this.NotFound();
            }

            return this.Ok(office);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OfficeExists(int id)
        {
            return db.Offices.Count(e => e.ID == id) > 0;
        }
    }
}
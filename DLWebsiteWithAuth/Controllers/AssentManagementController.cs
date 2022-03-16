using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace DLWebsiteWithAuth.Controllers
{
    public class AssentManagementController : ApiController
    {
        public List<AssentManagement_ProductDetails> GetProducts()
        {
            WEBDLEntities db = new WEBDLEntities();
            var result = db.AssentManagement_ProductDetails.ToList();
            return result;
        }

        [System.Web.Http.HttpGet]
        public AssentManagement_ProductDetails ProductDetails(int id)
        {
            WEBDLEntities db = new WEBDLEntities();
            var result = db.AssentManagement_ProductDetails.Where(x => x.ID == id).FirstOrDefault();
            return result;
        }
    }
}

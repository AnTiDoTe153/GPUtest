using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GPUTest2.DLA;
using GPUTest2.Models;
using Newtonsoft.Json;

namespace GPUTest2.Controllers
{
    public class DataController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Data
        public ActionResult Index()
        {
            return View(db.Datas.ToList());
        }

        // GET: Data/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data data = db.Datas.Find(id);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }


        [HttpPost]
        public ActionResult Create(String json)
        {

            dynamic asd = JsonConvert.DeserializeObject(json);
            int unique = asd.UniqueId;
            Data myData = db.Datas.SingleOrDefault(user => user.UniqueId == unique);

            if (myData != null)
            {
                myData.UniqueId = asd.UniqueId;
                myData.Score = asd.Score;
                myData.Specifications = asd.Specifications;

            }
            else
            {

                db.Datas.Add(new Data()
                {
                    UniqueId = asd.UniqueId,
                    Score = asd.Score,
                    Specifications = asd.Specifications
                });
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

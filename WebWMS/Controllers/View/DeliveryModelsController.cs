using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebWMS.Models;

namespace WebWMS.Controllers.View
{
    public class DeliveryModelsController : Controller
    {
        private WebWMSContext db = new WebWMSContext();

        // GET: DeliveryModels
        public ActionResult Index()
        {
            return View(db.DeliveryModels.ToList());
        }

        // GET: DeliveryModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryModel deliveryModel = db.DeliveryModels.Find(id);
            if (deliveryModel == null)
            {
                return HttpNotFound();
            }
            return View(deliveryModel);
        }

        // GET: DeliveryModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeliveryModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ExpectedDate,Customer,State,StateChangeTime")] DeliveryModel deliveryModel)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryModels.Add(deliveryModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deliveryModel);
        }

        // GET: DeliveryModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryModel deliveryModel = db.DeliveryModels.Find(id);
            if (deliveryModel == null)
            {
                return HttpNotFound();
            }
            return View(deliveryModel);
        }

        // POST: DeliveryModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ExpectedDate,Customer,State,StateChangeTime")] DeliveryModel deliveryModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryModel).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deliveryModel);
        }

        // GET: DeliveryModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryModel deliveryModel = db.DeliveryModels.Find(id);
            if (deliveryModel == null)
            {
                return HttpNotFound();
            }
            return View(deliveryModel);
        }

        // POST: DeliveryModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryModel deliveryModel = db.DeliveryModels.Find(id);
            db.DeliveryModels.Remove(deliveryModel);
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

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
    public class DeliveryLineModelsController : Controller
    {
        private WebWMSContext db = new WebWMSContext();

        // GET: DeliveryLineModels
        public ActionResult Index()
        {
            var deliveryLineModels = db.DeliveryLineModels.Include(d => d.DeliveryLineId);
            return View(deliveryLineModels.ToList());
        }

        // GET: DeliveryLineModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryLineModel deliveryLineModel = db.DeliveryLineModels.Find(id);
            if (deliveryLineModel == null)
            {
                return HttpNotFound();
            }
            return View(deliveryLineModel);
        }

        // GET: DeliveryLineModels/Create
        public ActionResult Create()
        {
            ViewBag.DeliveryID = new SelectList(db.DeliveryModels, "ID", "Name");
            return View();
        }

        // POST: DeliveryLineModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,DeliveryID,Product,ExpectedQty,AcceptedQty,RejectedQty,isUsedForStock")] DeliveryLineModel deliveryLineModel)
        {
            if (ModelState.IsValid)
            {
                db.DeliveryLineModels.Add(deliveryLineModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeliveryID = new SelectList(db.DeliveryModels, "ID", "Name", deliveryLineModel.DeliveryId);
            return View(deliveryLineModel);
        }

        // GET: DeliveryLineModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryLineModel deliveryLineModel = db.DeliveryLineModels.Find(id);
            if (deliveryLineModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeliveryID = new SelectList(db.DeliveryModels, "ID", "Name", deliveryLineModel.DeliveryId);
            return View(deliveryLineModel);
        }

        // POST: DeliveryLineModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,DeliveryID,Product,ExpectedQty,AcceptedQty,RejectedQty,isUsedForStock")] DeliveryLineModel deliveryLineModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deliveryLineModel).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeliveryID = new SelectList(db.DeliveryModels, "ID", "Name", deliveryLineModel.DeliveryId);
            return View(deliveryLineModel);
        }

        // GET: DeliveryLineModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeliveryLineModel deliveryLineModel = db.DeliveryLineModels.Find(id);
            if (deliveryLineModel == null)
            {
                return HttpNotFound();
            }
            return View(deliveryLineModel);
        }

        // POST: DeliveryLineModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeliveryLineModel deliveryLineModel = db.DeliveryLineModels.Find(id);
            db.DeliveryLineModels.Remove(deliveryLineModel);
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

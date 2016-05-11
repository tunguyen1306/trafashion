using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTraFashion.Models;

namespace WebTraFashion.Controllers
{
    public class tbl_slide_traController : Controller
    {
        private TrafashionEntities db = new TrafashionEntities();

        // GET: tbl_slide_tra
        public ActionResult Index()
        {
            return View(db.tbl_slide_tra.ToList());
        }

        // GET: tbl_slide_tra/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_slide_tra tbl_slide_tra = db.tbl_slide_tra.Find(id);
            if (tbl_slide_tra == null)
            {
                return HttpNotFound();
            }
            return View(tbl_slide_tra);
        }

        // GET: tbl_slide_tra/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_slide_tra/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_slide_tra,img_slide_tra,title_slide_tra,des_slide_tra,status_slide_tra")] tbl_slide_tra tbl_slide_tra)
        {
            if (ModelState.IsValid)
            {
                db.tbl_slide_tra.Add(tbl_slide_tra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_slide_tra);
        }

        // GET: tbl_slide_tra/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_slide_tra tbl_slide_tra = db.tbl_slide_tra.Find(id);
            if (tbl_slide_tra == null)
            {
                return HttpNotFound();
            }
            return View(tbl_slide_tra);
        }

        // POST: tbl_slide_tra/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_slide_tra,img_slide_tra,title_slide_tra,des_slide_tra,status_slide_tra")] tbl_slide_tra tbl_slide_tra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_slide_tra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_slide_tra);
        }

        // GET: tbl_slide_tra/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_slide_tra tbl_slide_tra = db.tbl_slide_tra.Find(id);
            if (tbl_slide_tra == null)
            {
                return HttpNotFound();
            }
            return View(tbl_slide_tra);
        }

        // POST: tbl_slide_tra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_slide_tra tbl_slide_tra = db.tbl_slide_tra.Find(id);
            db.tbl_slide_tra.Remove(tbl_slide_tra);
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

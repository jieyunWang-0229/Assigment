using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_Assigment.Models;


namespace FIT5032_Assigment.Controllers
{
    public class AttractionsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Attractions
        public ActionResult Index()
        {
            var attractions = db.Attractions.Include(a => a.Category);
            return View(attractions.ToList());
        }

        // GET: Attractions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attraction attraction = db.Attractions.Find(id);
            if (attraction == null)
            {
                return HttpNotFound();
            }
            return View(attraction);
        }

        // GET: Attractions/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: Attractions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize (Roles ="Administrator")]
        public ActionResult Create([Bind(Include = "AttractionId,AttractionName,Location,Longitude,Latitude,Detail,Image,CategoryId")] Attraction attraction, HttpPostedFileBase postedFile)
        {
            ModelState.Clear();
            var myUniqueFileName = string.Format(@"{0}", Guid.NewGuid());
            attraction.Image = myUniqueFileName;
            TryValidateModel(attraction);

            if (ModelState.IsValid)
            {
                string serverPath = Server.MapPath("~/Uploads/");
                string fileExtension = Path.GetExtension(postedFile.FileName);
                string filePath = attraction.Image + fileExtension;
                attraction.Image = filePath;
                postedFile.SaveAs(serverPath + attraction.Image);



                 db.Attractions.Add(attraction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", attraction.CategoryId);
            return View(attraction);
        }

        // GET: Attractions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attraction attraction = db.Attractions.Find(id);
            if (attraction == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", attraction.CategoryId);
            return View(attraction);
        }

        // POST: Attractions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind(Include = "AttractionId,AttractionName,Location,Longitude,Latitude,Detail,Image,CategoryId")] Attraction attraction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attraction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", attraction.CategoryId);
            return View(attraction);
        }

        // GET: Attractions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attraction attraction = db.Attractions.Find(id);
            if (attraction == null)
            {
                return HttpNotFound();
            }
            return View(attraction);
        }

        // POST: Attractions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            Attraction attraction = db.Attractions.Find(id);
            db.Attractions.Remove(attraction);
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

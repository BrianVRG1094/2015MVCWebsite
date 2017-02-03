using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.IO;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BrandController : Controller
    {
        private BrandContext db = new BrandContext();

        // GET: /Brand/
        public ActionResult Index()
        {
            return View(db.Brands.ToList());
        }

        // GET: /Brand/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // GET: /Brand/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Brand/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BrandID,Name,PhotoFile,ImageMimeType,Description")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Brands.Add(brand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(brand);
        }

        // GET: /Brand/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: /Brand/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BrandID,Name,PhotoFile,ImageMimeType,Description")] Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brand);
        }

        // GET: /Brand/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Brand brand = db.Brands.Find(id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        // POST: /Brand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Brand brand = db.Brands.Find(id);
            db.Brands.Remove(brand);
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

        public FileContentResult GetBrandImage(int BrandID)
        {
            //Get the right coffee
            Brand requestedBrand = db.Brands.FirstOrDefault(c => c.BrandID == BrandID);
            if (requestedBrand != null)
            {
                FileContentResult image;
                try
                {
                    image = File(requestedBrand.PhotoFile, requestedBrand.ImageMimeType);
                    if (image != null)
                        return image;
                }
                catch
                {
                    string path = @"C:\Users\Brian\Documents\Visual Studio 2013\Projects\BrianCoffeeShop\WebApplication1\Content\images\Not-found.jpg";
                    FileStream fs = new FileStream(path, FileMode.Open);
                    byte[] fileBytes;
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        fileBytes = br.ReadBytes((int)fs.Length);
                    }
                    image = File(fileBytes, "image/jpg");
                    return image;
                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}

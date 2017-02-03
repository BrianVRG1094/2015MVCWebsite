using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.IO;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CoffeeController : Controller
    {
        private CoffeeContext db = new CoffeeContext();

        // GET: /Coffee/
        public ActionResult Index()
        {
            return View(db.Coffees.ToList());
        }

        // GET: /Coffee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coffee coffee = db.Coffees.Find(id);
            if (coffee == null)
            {
                return HttpNotFound();
            }
            return View(coffee);
        }

        // GET: /Coffee/Create
        public ActionResult Create()
        {
            ViewBag.BrandID = new SelectList(db.Brands, "BrandID", "Name");
            return View();
        }

        // POST: /Coffee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CoffeeID,BrandID,Name,PhotoFile,ImageMimeType,Description,UserName")] Coffee coffee, HttpPostedFileBase image)
        {
            if (!ModelState.IsValid)
            {
                return View(coffee);
            }

            else
            {
                if (coffee != null)
                {
                    //Load the new coffee's image
                    coffee.ImageMimeType = image.ContentType;
                    coffee.PhotoFile = new byte[image.ContentLength];
                    image.InputStream.Read(coffee.PhotoFile, 0, image.ContentLength);

                    //Save Username
                    if (!User.Identity.IsAuthenticated)
                        coffee.UserName = "Anonymous";
                    else
                        coffee.UserName = User.Identity.Name;
                }

                db.Coffees.Add(coffee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // GET: /Coffee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coffee coffee = db.Coffees.Find(id);
            if (coffee == null)
            {
                return HttpNotFound();
            }
            return View(coffee);
        }

        // POST: /Coffee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CoffeeID,BrandID,Name,PhotoFile,ImageMimeType,Description,UserName")] Coffee coffee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coffee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coffee);
        }

        // GET: /Coffee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coffee coffee = db.Coffees.Find(id);
            if (coffee == null)
            {
                return HttpNotFound();
            }
            return View(coffee);
        }

        // POST: /Coffee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coffee coffee = db.Coffees.Find(id);
            db.Coffees.Remove(coffee);
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

        //This action gets the coffee for a given ID
        public FileContentResult GetCoffeeImage(int CoffeeID)
        {
            //Get the right coffee
            Coffee requestedCoffee = db.Coffees.FirstOrDefault(c => c.CoffeeID == CoffeeID);
            if (requestedCoffee != null)
            {
                FileContentResult image;
                try
                {
                    image = File(requestedCoffee.PhotoFile, requestedCoffee.ImageMimeType);
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

        public string GetBrandName(int BrandID)
        {
            Brand requestedBrand = db.Brands.Find(BrandID);
            return requestedBrand.Name;
        }
    }
}

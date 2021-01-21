using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAT.DATA;
using SAT.Utilities;

namespace SAT.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private SATDBEntities db = new SATDBEntities();

        // GET: Students
        //[Authorize(Roles = "Scheduling")]
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.StudentStatus);
            return View(students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,FirstName,LastName,Major,Address,City,State,ZipCode,Phone,Email,PhotoUrl,SSID")] Student student, HttpPostedFileBase studentImage)
        {
            if (ModelState.IsValid)
            {
                #region File Upload
                string file = "noimage.png";

                if (studentImage != null)
                {
                    file = studentImage.FileName;
                    string ext = file.Substring(file.LastIndexOf('.'));
                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };

                    // Check that the uploaded file exts is in our list of good file extensions
                    if (goodExts.Contains(ext))
                    {
                        // If valid, check file size <= 4mb (Max by default from ASP.NET)
                        // Can change this using the MaxRequestLength in the web.config
                        if (studentImage.ContentLength <= 4194304) // 4 mb in bytes
                        {
                            // Create a new file name using a guid
                            file = Guid.NewGuid() + ext;

                            #region Resize Image
                            string savePath = Server.MapPath("~/Content/assets/img/Records/");

                            // Points to the contents of te file (bookCover) and converts it to an
                            // image dataype
                            Image convertedImage = Image.FromStream(studentImage.InputStream);

                            // Pixel size
                            int maxImageSize = 150;
                            int maxThumbSize = 100;

                            // Resize our image and save it as a default and thumbnail version in our path
                            ImageService.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);
                            #endregion
                        }
                        student.PhotoUrl = file;
                    }
                }
                #endregion
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName", student.SSID);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName", student.SSID);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,FirstName,LastName,Major,Address,City,State,ZipCode,Phone,Email,PhotoUrl,SSID")] Student student, HttpPostedFileBase studentImage)
        {
            if (ModelState.IsValid)
            {
                #region File Upload
                string file = "noimage.png";

                if (studentImage != null)
                {
                    file = studentImage.FileName;
                    string ext = file.Substring(file.LastIndexOf('.'));
                    string[] goodExts = { ".jpeg", ".jpg", ".png", ".gif" };

                    // Check that the uploaded file exts is in our list of good file extensions
                    if (goodExts.Contains(ext))
                    {
                        // If valid, check file size <= 4mb (Max by default from ASP.NET)
                        // Can change this using the MaxRequestLength in the web.config
                        if (studentImage.ContentLength <= 4194304) // 4 mb in bytes
                        {
                            // Create a new file name using a guid
                            file = Guid.NewGuid() + ext;

                            #region Resize Image
                            string savePath = Server.MapPath("~/Content/assets/img/Records/");

                            // Points to the contents of te file (bookCover) and converts it to an
                            // image dataype
                            Image convertedImage = Image.FromStream(studentImage.InputStream);

                            // Pixel size
                            int maxImageSize = 150;
                            int maxThumbSize = 100;

                            // Resize our image and save it as a default and thumbnail version in our path
                            ImageService.ResizeImage(savePath, file, convertedImage, maxImageSize, maxThumbSize);
                            #endregion
                        }
                        student.PhotoUrl = file;
                    }
                }
                #endregion
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SSID = new SelectList(db.StudentStatuses, "SSID", "SSName", student.SSID);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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

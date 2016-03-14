using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LandScaping.Models;
using LandScaping.CustomFilters;
using Microsoft.AspNet.Identity;
using System.Net.Mail;

namespace LandScaping.Controllers
{
    public class JobsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Jobs
        public ActionResult Index()
        {

                var UserID = User.Identity.GetUserId();
                var UserInfo = db.jobs.Where(userid => userid.UserID == UserID);
                return View(UserInfo.ToList());
            //return View(db.jobs.ToList());
        }

        [AuthLog(Roles = "Admin")]
        public ActionResult AdminIndex()
        {
            return View(db.jobs.ToList());
        }

        public ActionResult BuyNow()
        {
            return View();
        }

        // GET: Jobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobs jobs = db.jobs.Find(id);
            if (jobs == null)
            {
                return HttpNotFound();
            }
            return View(jobs);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            return View();
        }

        

        public void sendEmail()
        {
            

            var message = new MailMessage("xxxdeathstarmlgxxx@gmail.com", "Nephithys@gmail.com");
            message.Subject = "New Request";
            message.Body = "You Have a new service request!";
            SmtpClient mailer = new SmtpClient("smtp.gmail.com", 587);
            mailer.Credentials = new NetworkCredential("xxxdeathstarmlgxxx@gmail.com", "AAAFCAFCAEEEFCA#FCAFCA");
            mailer.EnableSsl = true;
            mailer.Send(message);
       
        }
        public void sendEmail2()
        {
            var UserID = User.Identity.GetUserId();
            var UserInfo = db.client.Where(userid => userid.UserID == UserID);
            var client = db.client.Select(x => x).Where(y => y.UserID == UserID).FirstOrDefault();

            var UserInfo2 = db.jobs.Where(userid => userid.UserID == UserID);
            var service = db.jobs.Select(x => x).Where(y => y.UserID == UserID).FirstOrDefault();

            var message = new MailMessage("xxxdeathstarmlgxxx@gmail.com", client.Email);
            message.Subject = "Thank You";
            message.Body = "Your total was $" + service.TotalCost;
            SmtpClient mailer = new SmtpClient("smtp.gmail.com", 587);
            mailer.Credentials = new NetworkCredential("xxxdeathstarmlgxxx@gmail.com", "AAAFCAFCAEEEFCA#FCAFCA");
            mailer.EnableSsl = true;
            mailer.Send(message);
        }


        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Service,Rate,Acre,TotalCost,Day,Month,Comments")] Jobs jobs)
        {
            jobs.UserID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                sendEmail();
                db.jobs.Add(jobs);
                db.SaveChanges();
                changeCost(jobs.ID);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobs);
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobs jobs = db.jobs.Find(id);
            if (jobs == null)
            {
                return HttpNotFound();
            }
            return View(jobs);
        }

        public void changeCost(int id)
        {
            Jobs jobs = db.jobs.Find(id);
            jobs.TotalCost = jobs.Acre * jobs.Rate;
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Service,Rate,Acre,TotalCost,Day,Month,Comments")] Jobs jobs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobs);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobs jobs = db.jobs.Find(id);
            if (jobs == null)
            {
                return HttpNotFound();
            }
            return View(jobs);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jobs jobs = db.jobs.Find(id);
            db.jobs.Remove(jobs);
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

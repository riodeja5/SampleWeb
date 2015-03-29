using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SumidaWeb.Models;

namespace SumidaWeb.Controllers
{
    public class RollsController : Controller
    {
        private SumidaWebContext db = new SumidaWebContext();

        // GET: Rolls
        public ActionResult Index()
        {
            return View(db.Rolls.ToList());
        }

        // GET: Rolls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roll roll = db.Rolls.Find(id);
            if (roll == null)
            {
                return HttpNotFound();
            }
            return View(roll);
        }

        // GET: Rolls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rolls/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RollName")] Roll roll)
        {
            if (ModelState.IsValid)
            {
                db.Rolls.Add(roll);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roll);
        }

        // GET: Rolls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roll roll = db.Rolls.Find(id);
            if (roll == null)
            {
                return HttpNotFound();
            }
            return View(roll);
        }

        // POST: Rolls/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RollName")] Roll roll)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roll).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roll);
        }

        // GET: Rolls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Roll roll = db.Rolls.Find(id);
            if (roll == null)
            {
                return HttpNotFound();
            }
            return View(roll);
        }

        // POST: Rolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Roll roll = db.Rolls.Find(id);
            db.Rolls.Remove(roll);
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

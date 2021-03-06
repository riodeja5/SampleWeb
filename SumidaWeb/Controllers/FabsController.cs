﻿using System;
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
    public class FabsController : Controller
    {
        private SumidaWebContext db = new SumidaWebContext();

        // GET: Fabs
        public ActionResult Index()
        {
            var fabs = db.Fabs.Include(f => f.User);
            return View(fabs.ToList());
        }

        // GET: Fabs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fab fab = db.Fabs.Find(id);
            if (fab == null)
            {
                return HttpNotFound();
            }
            return View(fab);
        }

        // GET: Fabs/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: Fabs/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserID,FabName")] Fab fab)
        {
            if (ModelState.IsValid)
            {
                db.Fabs.Add(fab);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "Id", "UserName", fab.UserID);
            return View(fab);
        }

        // GET: Fabs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fab fab = db.Fabs.Find(id);
            if (fab == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "UserName", fab.UserID);
            return View(fab);
        }

        // POST: Fabs/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserID,FabName")] Fab fab)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fab).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "Id", "UserName", fab.UserID);
            return View(fab);
        }

        // GET: Fabs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fab fab = db.Fabs.Find(id);
            if (fab == null)
            {
                return HttpNotFound();
            }
            return View(fab);
        }

        // POST: Fabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fab fab = db.Fabs.Find(id);

            // 削除時に関連するWorkstationを読み込んでおかないと、関連するWorkstationが判別できないためエラーとなる
            var workstations = fab.Workstations;

            db.Fabs.Remove(fab);
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

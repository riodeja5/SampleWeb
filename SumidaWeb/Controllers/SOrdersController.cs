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
    public class SOrdersController : Controller
    {
        private SumidaWebContext db = new SumidaWebContext();

        // GET: SOrders
        public ActionResult Index()
        {
            var sOrders = db.SOrders.Include(s => s.Machine);
            return View(sOrders.ToList());
        }

        // GET: SOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOrder sOrder = db.SOrders.Find(id);
            if (sOrder == null)
            {
                return HttpNotFound();
            }
            return View(sOrder);
        }

        // GET: SOrders/Create
        public ActionResult Create()
        {
            ViewBag.MachineID = new SelectList(db.Machines, "Id", "MachineType");
            return View();
        }

        // POST: SOrders/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MachineID,LicenseName,LicenseDetail,LicenseJap,LicenseEng,Date")] SOrder sOrder)
        {
            if (ModelState.IsValid)
            {
                db.SOrders.Add(sOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MachineID = new SelectList(db.Machines, "Id", "MachineType", sOrder.MachineID);
            return View(sOrder);
        }

        // GET: SOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOrder sOrder = db.SOrders.Find(id);
            if (sOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.MachineID = new SelectList(db.Machines, "Id", "MachineType", sOrder.MachineID);
            return View(sOrder);
        }

        // POST: SOrders/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MachineID,LicenseName,LicenseDetail,LicenseJap,LicenseEng,Date")] SOrder sOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MachineID = new SelectList(db.Machines, "Id", "MachineType", sOrder.MachineID);
            return View(sOrder);
        }

        // GET: SOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOrder sOrder = db.SOrders.Find(id);
            if (sOrder == null)
            {
                return HttpNotFound();
            }
            return View(sOrder);
        }

        // POST: SOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SOrder sOrder = db.SOrders.Find(id);
            db.SOrders.Remove(sOrder);
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

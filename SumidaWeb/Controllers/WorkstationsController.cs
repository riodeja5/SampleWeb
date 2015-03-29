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
    public class WorkstationsController : Controller
    {
        private SumidaWebContext db = new SumidaWebContext();

        // GET: Workstations
        public ActionResult Index()
        {
            var workstations = db.Workstations.Include(w => w.Fab).Include(w => w.Machine);
            return View(workstations.ToList());
        }

        // GET: Workstations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workstation workstation = db.Workstations.Find(id);
            if (workstation == null)
            {
                return HttpNotFound();
            }
            return View(workstation);
        }

        // GET: Workstations/Create
        public ActionResult Create()
        {
            ViewBag.FabId = new SelectList(db.Fabs, "Id", "FabName");
            ViewBag.MachineId = new SelectList(db.Machines, "Id", "MachineType");
            return View();
        }

        // POST: Workstations/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FabId,MachineId,EquipmentNo,MapAddress,Comment,Date,EmargencyMapAddress")] Workstation workstation)
        {
            if (ModelState.IsValid)
            {
                db.Workstations.Add(workstation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FabId = new SelectList(db.Fabs, "Id", "FabName", workstation.FabId);
            ViewBag.MachineId = new SelectList(db.Machines, "Id", "MachineType", workstation.MachineId);
            return View(workstation);
        }

        // GET: Workstations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workstation workstation = db.Workstations.Find(id);
            if (workstation == null)
            {
                return HttpNotFound();
            }
            ViewBag.FabId = new SelectList(db.Fabs, "Id", "FabName", workstation.FabId);
            ViewBag.MachineId = new SelectList(db.Machines, "Id", "MachineType", workstation.MachineId);
            return View(workstation);
        }

        // POST: Workstations/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FabId,MachineId,EquipmentNo,MapAddress,Comment,Date,EmargencyMapAddress")] Workstation workstation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workstation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FabId = new SelectList(db.Fabs, "Id", "FabName", workstation.FabId);
            ViewBag.MachineId = new SelectList(db.Machines, "Id", "MachineType", workstation.MachineId);
            return View(workstation);
        }

        // GET: Workstations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workstation workstation = db.Workstations.Find(id);
            if (workstation == null)
            {
                return HttpNotFound();
            }
            return View(workstation);
        }

        // POST: Workstations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Workstation workstation = db.Workstations.Find(id);
            db.Workstations.Remove(workstation);
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

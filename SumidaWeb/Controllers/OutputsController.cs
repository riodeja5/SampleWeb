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
    public class OutputsController : Controller
    {
        private SumidaWebContext db = new SumidaWebContext();

        // GET: Outputs
        public ActionResult Index()
        {
            var outputs = db.Outputs.Include(o => o.Member).Include(o => o.SOrder).Include(o => o.Workstation);
            return View(outputs.ToList());
        }

        // GET: Outputs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Output output = db.Outputs.Find(id);
            if (output == null)
            {
                return HttpNotFound();
            }
            return View(output);
        }

        // GET: Outputs/Create
        public ActionResult Create()
        {
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name");
            ViewBag.SOrderId = new SelectList(db.SOrders, "Id", "LicenseName");
            ViewBag.WorkstationId = new SelectList(db.Workstations, "Id", "MapAddress");
            return View();
        }

        // POST: Outputs/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WorkstationId,SOrderId,PublicationApproval,MemberId,PublicationData,Validity,DownloadStat,DownloadDate,DownloadNum,EmergencyStat")] Output output)
        {
            if (ModelState.IsValid)
            {
                db.Outputs.Add(output);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", output.MemberId);
            ViewBag.SOrderId = new SelectList(db.SOrders, "Id", "LicenseName", output.SOrderId);
            ViewBag.WorkstationId = new SelectList(db.Workstations, "Id", "MapAddress", output.WorkstationId);
            return View(output);
        }

        // GET: Outputs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Output output = db.Outputs.Find(id);
            if (output == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", output.MemberId);
            ViewBag.SOrderId = new SelectList(db.SOrders, "Id", "LicenseName", output.SOrderId);
            ViewBag.WorkstationId = new SelectList(db.Workstations, "Id", "MapAddress", output.WorkstationId);
            return View(output);
        }

        // POST: Outputs/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、http://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WorkstationId,SOrderId,PublicationApproval,MemberId,PublicationData,Validity,DownloadStat,DownloadDate,DownloadNum,EmergencyStat")] Output output)
        {
            if (ModelState.IsValid)
            {
                db.Entry(output).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberId = new SelectList(db.Members, "Id", "Name", output.MemberId);
            ViewBag.SOrderId = new SelectList(db.SOrders, "Id", "LicenseName", output.SOrderId);
            ViewBag.WorkstationId = new SelectList(db.Workstations, "Id", "MapAddress", output.WorkstationId);
            return View(output);
        }

        // GET: Outputs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Output output = db.Outputs.Find(id);
            if (output == null)
            {
                return HttpNotFound();
            }
            return View(output);
        }

        // POST: Outputs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Output output = db.Outputs.Find(id);
            db.Outputs.Remove(output);
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

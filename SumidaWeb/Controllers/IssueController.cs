using SumidaWeb.Models;
using System.Web.Mvc;
using System.Linq;


namespace SumidaWeb.Controllers
{
    public class IssueController : Controller
    {
        private SumidaWebContext db = new SumidaWebContext();
        // GET: Issue
        public ActionResult Index()
        {
            ViewBag.Id = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        public ActionResult FabSearch(User user)
        {
            if (Request.IsAjaxRequest())
            {
                var fabs = db.Fabs
                    .Where(f => f.UserID == user.Id)
                    .OrderBy(f => f.Id);
                return PartialView("_FabSearch", fabs);
            }
            return Content("Ajax通信以外のアクセスはできません。");
        }
    }
}
using System;
using System.Web.Mvc;
using AdvancedMVC2.ActionResults;
using AdvancedMVC2.Models;

namespace AdvancedMVC2.Controllers
{
    [HandleError(ExceptionType=typeof(HttpAntiForgeryException),View="AntiForgeryError")]
    [HandleError]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult AddUser()
        {
            return View("AddUser", new NewUserModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUser(NewUserModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View("AddUser", model);
        }

        public ActionResult Calendar()
        {
            var meeting = new Meeting
                              {
                                  Date = DateTime.Now.AddDays(7),
                                  Name = "49. User Treffen der .net user group Köln",
                                  Location = "Köln",
                                  Description = "Die Beschreibung",
                                  Duration = 180
                              };
            return new IcsResult(meeting);
        }

    }
}
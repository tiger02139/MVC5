using System;
using System.Web.Mvc;

namespace TestingDemo {

    public class AdminController : Controller {
        private IUserRepository repository;


        public AdminController(IUserRepository repo) {
            repository = repo;
        }

        /// <summary>
        /// Apparently since a constructor requiring a parameter has been created,
        /// C# no longer supplies an implied parameterless constructor, so we have
        /// to supply one ourself.
        /// https://www.codeproject.com/Questions/1088244/Get-error-is-no-parameterless-constructor-defined
        /// </summary>
        public AdminController()
        {
        }

        public ActionResult ChangeLoginName(string oldName, string newName) {
            User user = repository.FetchByLoginName(oldName);
            user.LoginName = newName;
            repository.SubmitChanges();
            // render some view to show the result
            return View();
        }

        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }
    }
}

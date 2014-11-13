using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using X2.Domain.Entity;
using X2.Services.Runtime.Repository;

namespace X2.Web.Controllers
{
    public class HomeController : Controller
    {
        private IRepositoryService repositoryService;
        public HomeController(IRepositoryService repositoryService)
        {
            this.repositoryService = repositoryService;
        }

        public ActionResult Index()
        {
            //var repositoryService = DependencyResolver.Current.GetService<IRepositoryService<UserInfor>>();

            var userInfor = repositoryService.Queryover<UserInfor>().First(x => x.Pin == "1234");

            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application. User Infor :" + userInfor.UserID;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}

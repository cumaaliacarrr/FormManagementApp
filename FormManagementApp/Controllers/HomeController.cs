using FormManagementApp.Entity;
using FormManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormManagementApp.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string userName, string password)
        {
            var userInfo = _context.UserModels;
            var succes = userInfo.Where(p => p.UserName == userName && p.Password == password).Count() > 0 ? true : false;
            var param = new Status();
            if (succes)
            {
                int userId = userInfo.Select(p => p.Id).FirstOrDefault();
                Session["UserId"] = userId;

                param.ErrorStatus = false;
                param.Id = userInfo.Select(p => p.Id).FirstOrDefault();
                param.Url = "Form/Index/";
                return Json(param, JsonRequestBehavior.AllowGet);
            }
            else
            {
                    param.ErrorStatus = true;
                    param.Url = "Home/Index/";
                
                ViewBag.ErrorMessage = "Kullanıcı Adı veya şifre hatalı";
                return Json(param, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult LogOut()
        {
            Session["UserId"] = null;
            return RedirectToAction("Index", "Home", "");
        }
       
    }
}

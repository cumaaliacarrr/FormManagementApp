using FormManagementApp.Data;
using FormManagementApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormManagementApp.Content
{
    public class FormController : Controller
    {
        DataContext _context = new DataContext();
        public int UserId  { get; set; }
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
                
            UserId = Convert.ToInt32(Session["UserId"]);

            var formList = FormRepository.Forms.Where(p => p.UserId == UserId).ToList();
            return View(formList);
        }

        public ActionResult List(string txtSearch)
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            UserId = Convert.ToInt32(Session["UserId"]);
            
            var formList=FormRepository.Forms.Where(p => p.UserId == UserId).ToList();

            if (!string.IsNullOrEmpty(txtSearch))
            {
                formList = formList.Where(p => p.Name.ToLower().Contains(txtSearch.ToLower())).ToList();
            }

            return View("List",formList);
        }
        public ActionResult Details(int id)
        {
            var formDetail = FormRepository.GetFormById(id);
            return View(formDetail);
        }
        public ActionResult Delete(int id)
        {
             FormRepository.DeleteForm(id);
            
            return RedirectToAction("List");
        }
        [HttpPost]
        public ActionResult Add(Form form)
        {
            UserId = Convert.ToInt32(Session["UserId"]);
            form.UserId = UserId;
            form.CreatedAt = DateTime.Now;
            FormRepository.AddForm(form);
            
            return View("List");
        }
    }
}
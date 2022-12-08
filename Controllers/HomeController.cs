using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDFamilyApplication.Controllers
{
    public class HomeController : Controller
    {
        FAMILYEntities _context = new FAMILYEntities();
        public ActionResult Index()
        {
            var listofData = _context.Members.ToList();
            return View(listofData);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Member model)
        {
            if (model.MemberID > 0 && !string.IsNullOrEmpty(model.FirstName) && !string.IsNullOrEmpty(model.LastName))
            {
                _context.Members.Add(model);
                _context.SaveChanges();
                ViewBag.Message = "Data Insert Successfully";
                return View();
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Members.Where(x => x.MemberID == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Member Model)
        {
            var data = _context.Members.Where(x => x.MemberID == Model.MemberID).FirstOrDefault();
            if (data != null)
            {
                data.MemberID = Model.MemberID;
                data.FirstName = Model.FirstName;
                data.LastName = Model.LastName;
                data.Street = Model.Street;
                _context.SaveChanges();
            }

            return RedirectToAction("index");
        }

        public ActionResult Detail(int id)
        {
            var data = _context.Members.Where(x => x.MemberID == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = _context.Members.Where(x => x.MemberID == id).FirstOrDefault();
            _context.Members.Remove(data);
            _context.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("index");
        }

    }
}
using BankAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BankAssignment.Controllers
{
    public class DefaultController : Controller
    {
        CustomerEntities cust = new CustomerEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Info model)
        {
            Info arv =cust.Infoes.Where(abc => abc.Name ==model.Name).FirstOrDefault();
            if (arv != null)
            {
                ViewBag.availBal = Convert.ToString(arv.availBal);
            }
            else
            {
                ViewBag.availBal = "";
                ModelState.AddModelError("", "Customer not found.");
            }
            return View("Index",model);
        }
    }
}
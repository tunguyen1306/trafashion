using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTraFashion.Models;

namespace WebTraFashion.Controllers
{
    public class DefaultController : Controller
    {
        TrafashionEntities db = new TrafashionEntities();
        // GET: Default
        public ActionResult Default()
        {
            return View();
        }
        public ActionResult Header()
        {
            return View();
        }
        public ActionResult Slider()
        {
            
            return View();
        }
        public ActionResult ListProducts()
        {

            return View();
        }
        public ActionResult Detail()
        {

            return View();
        }
        public ActionResult container()
        {

            return View();
        }
    }
}
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
        public ActionResult Detail(string id )
        {
            var id_ = int.Parse(id.Split('-').Last());
            var qr = from dataNew in db.tbl_products_tra
                     where dataNew.status_products_tra == 1 && dataNew.id_products_tra == id_
                     select dataNew;
            return View(qr.ToList());
           
        }
      
        public ActionResult container()
        {

            return View();
        }
    }
}
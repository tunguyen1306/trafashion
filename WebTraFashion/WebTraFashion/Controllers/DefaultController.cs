using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        public ActionResult ListProducts(string id)
        {
            var id_ = int.Parse(id.Split('-').Last());
            var qr = from dataNew in db.tbl_products_tra
                     where dataNew.status_products_tra == 1 && dataNew.type_products_tra == id_
                     select dataNew;
            //"ListProductsByID", qr.ToList().ToPagedList(pageNumber: 1, pageSize: 1)
            return View(qr.ToList().ToPagedList(pageNumber: 1, pageSize: 12));

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
        public ActionResult relatedProduct()
        {

            return View();
        }

        public PartialViewResult PartialDemo(int page = 1, int pagesize = 12)
        {
            var dataNew = (from datanew in db.tbl_products_tra where datanew.status_products_tra == 1 && (datanew.type_products_tra == 1) orderby datanew.id_products_tra descending select datanew).ToList();
            return PartialView("ListProductsByID", dataNew.ToPagedList(page, pagesize));
        }


        [HttpPost]
        public ActionResult RegisMail(string email)
        {
            var t = email;
            var mail = new MailMessage();
            mail.To.Add("tunguyen.it.dev@gmail.com");
            mail.From = new MailAddress("tunguyen.it.dev@gmail.com");
            mail.Subject = "Email hách hàng đăng ký nhận tin";
            mail.Body = "Email của khách là:"+email;
            mail.IsBodyHtml = true;
            var smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential
                ("tunguyen.it.dev@gmail.com", "Anhyeuem3");
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return View("Default");
        }
    }
}
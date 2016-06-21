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
        public ActionResult ListProducts(string id,int idd)
        {
            var id_ = int.Parse(id.Split('-').Last());
            if (id_ == 1)
            {
                ViewData["showname"]="Ví";
                   
                    
            }
            if (id_ == 2)
            {
                  
                    ViewData["showname"] = "Balo";
            }
            if (id_ == 3)
            {
                   
                    ViewData["showname"] = "Vali";
            }
            if (id_ == 4)
            {
                   
                    ViewData["showname"] = "Phụ kiện";
            }
            if (id_ == 5)
            {
                  
                    ViewData["showname"] = "Sale";
            }
            if (id_ == 6)
            {
                  
                    ViewData["showname"] = "Túi xách";
            }
            if (idd==123)
            {
                var queryProducts =
                from data in db.tbl_products_tra
                join datapic in db.tblSysPictures on data.id_products_tra equals datapic.advert_id
                where data.status_products_tra == 1 && datapic.position == 1 && (data.type_products_tra == id_ || data.discount_products_tra!=null)
                orderby data.id_products_tra descending
                select new ClassAll { tblProdu = data, tblPicture = datapic };
                return View(queryProducts.ToList().ToPagedList(pageNumber: 1, pageSize: 12));
            }
            else
            {
                var queryProducts1 =
               from data in db.tbl_products_tra
               join datapic in db.tblSysPictures on data.id_products_tra equals datapic.advert_id
               where data.status_products_tra == 1 && datapic.position == 1 && data.type_products_tra == id_
               orderby data.id_products_tra descending
               select new ClassAll { tblProdu = data, tblPicture = datapic };
                return View(queryProducts1.ToList().ToPagedList(pageNumber: 1, pageSize: 12));
            }

        }

        public ActionResult Detail(string id)
        {

            var id_ = int.Parse(id.Split('-').Last());
            var qr = from data in db.tbl_products_tra
                     join datapic in db.tblSysPictures on data.id_products_tra equals datapic.advert_id
                     where data.status_products_tra == 1 && datapic.position == 1 && data.id_products_tra == id_
                     orderby data.id_products_tra descending
                     select new ClassAll { tblProdu = data, tblPicture = datapic };

            ClassAll pic = new ClassAll { tblistPro = db.tbl_products_tra.Where(t => t.id_products_tra == id_).ToList(), tblistPicture = db.tblSysPictures.Where(t => t.advert_id == id_).ToList() };
            return View(pic);

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
            mail.To.Add("trafashion.com@gmail.com");
            mail.From = new MailAddress("trafashion.com@gmail.com");
            mail.Subject = "Email khách hàng đăng ký nhận tin";
            mail.Body = "Email của khách là:" + email;
            mail.IsBodyHtml = true;
            var smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential
                ("mailorderthung@gmail.com", "a1234@1234");
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return View("Default");
        }
        [HttpPost]
        public ActionResult buy(string email, string name, string phone, string content, string nameproduct,string codeproduct,string price,string idpro)
        {
            var index = 0;
            if (name=="")
            {
                ViewData["error"] = "vui lòng nhập ho và tên";
                index++;
            }
            if (phone == "")
            {
                ViewData["error"] = "vui lòng nhập ho và tên";
                index++;
            }
            if (email == "")
            {
                ViewData["error"] = "vui lòng nhập ho và tên";
                index++;
            }
            if (index==0)
            {

                var t = email;
                var mail = new MailMessage();
                mail.To.Add("trafashion.com@gmail.com");
                mail.From = new MailAddress("trafashion.com@gmail.com");
                mail.Subject = "Khách hàng mua sản phẩm: " + " " + nameproduct + " ------- Mã sản phẩm " + codeproduct + " -------Giá: " + price;
                mail.Body = "<label style='color:red'>Tên khách hàng: </label><label style='color:blue'>" + name + " </label><br> <label style='color:red'>Số điện thoại:</label><label style='color:blue'> " + phone + " </label><br><label style='color:red'>Email của khách là:</label><label style='color:blue'> " + email + " </label><br> <label style='color:red'>Nội dung: </label><label style='color:blue'>" + content + " </label>";
                mail.IsBodyHtml = true;
                var smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential
                   ("mailorderthung@gmail.com", "a1234@1234");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return RedirectToAction("Detail", new { id = idpro });
            }
            return RedirectToAction("Detail", new { id = idpro });
        }
        [HttpPost]
        public ActionResult Order(string emailo, string nameo, string phoneo, string contento, string nameproducto, string codeproducto, string priceo, string idproo)
        {
            var index = 0;
            if (nameo == "")
            {
                ViewData["error"] = "vui lòng nhập ho và tên";
                index++;
            }
            if (phoneo == "")
            {
                ViewData["error"] = "vui lòng nhập ho và tên";
                index++;
            }
            if (emailo == "")
            {
                ViewData["error"] = "vui lòng nhập ho và tên";
                index++;
            }
            if (index == 0)
            {
                var mail = new MailMessage();
                mail.To.Add("trafashion.com@gmail.com");
                mail.From = new MailAddress("trafashion.com@gmail.com");
                mail.Subject = "Khách hàng đặt sản phẩm: " + " " + nameproducto + " ------- Mã sản phẩm " + codeproducto + " -------Giá: " + priceo;
                mail.Body = "<label style='color:red'>Tên khách hàng: </label><label style='color:blue'>" + nameo + " </label><br> <label style='color:red'>Số điện thoại:</label><label style='color:blue'> " + phoneo + " </label><br><label style='color:red'>Email của khách là:</label><label style='color:blue'> " + emailo + " </label><br> <label style='color:red'>Nội dung: </label><label style='color:blue'>" + contento + " </label>";
                mail.IsBodyHtml = true;
                var smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential
                   ("mailorderthung@gmail.com", "a1234@1234");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return RedirectToAction("Detail", new { id = idproo });
            }
            return RedirectToAction("Detail", new { id = idproo });
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMail(string email, string name, string phone, string content)
        {
            var t = email;
            var mail = new MailMessage();
            mail.To.Add("trafashion.com@gmail.com");
            mail.From = new MailAddress("trafashion.com@gmail.com");
            mail.Subject = "Thông tin khách hàng";
            mail.Body = "<label style='color:red'>Tên khách hàng: </label><label style='color:blue'>" + name + " </label><br> <label style='color:red'>Số điện thoại:</label><label style='color:blue'> " + phone + " </label><br><label style='color:red'>Email của khách là:</label><label style='color:blue'> " + email + " </label><br> <label style='color:red'>Nội dung: </label><label style='color:blue'>" + content + " </label>";
            mail.IsBodyHtml = true;
            var smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential
               ("mailorderthung@gmail.com", "a1234@1234");
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return View("Contact");
        }
    }
}
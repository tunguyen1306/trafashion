using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTraFashion.Models
{
    public class ClassAll
    {
        public tblSysPicture tblPicture { get; set; }
        public List<tblSysPicture> tblistPicture { get; set; }
        public tbl_products_tra tblProdu { get; set; }
        public List<tbl_products_tra> tblistPro { get; set; }
    }
   
}
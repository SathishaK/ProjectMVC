using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoutigueShop.Models
{
    public class Shop
    {
        public int Did { get; set; }        public string Dname { get; set; }        public string DStyle { get; set; }        public int Dprice { get; set; }
        public int Dsize { get; set; }
        
    }
}
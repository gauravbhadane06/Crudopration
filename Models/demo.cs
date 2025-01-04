using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Crudopration.Models
{
    public class demo
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> categoryId { get; set; }
        public string categoryName { get; set; }
    }
   
}
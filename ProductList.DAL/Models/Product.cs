using System;
using System.Collections.Generic;

#nullable disable

namespace ProductList.DAL.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Catergory { get; set; }
        public int? Price { get; set; }
        public string Type { get; set; }
    }
}

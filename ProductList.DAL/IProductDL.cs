using ProductList.DAL.Models;
using System.Collections.Generic;

namespace ProductList.DAL
{
    public interface IProductDL
    {
        List<Product> GetAllProduct();
    }
}
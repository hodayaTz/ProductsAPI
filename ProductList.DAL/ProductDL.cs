using ProductList.DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProductList.DAL
{
    public class ProductDL : IProductDL
    {

        ProductContext _context;
        public ProductDL(ProductContext context)
        {
            this._context = context;

        }

      //  string fileUrl = @"S:\הנדסאים יד תשפא\Web APi - .Net Core\שיעור_2\ProductsAPI\user.txt";

        //List<Product> products = new List<Product>()
        //{
        //  new Product{ Id = 1 , Name = "Milk" , Price = 8},
        //  new Product { Id = 2 , Name = "Bread" , Price = 8}
        //};


        // פונקציה שנגשת לקובץ טקסט ובודקת האם id נמצא בקובץ
        //public Product GetProductById(int id)
        //{
        //    using (StreamReader reader = System.IO.File.OpenText(fileUrl))
        //    {
        //        string currentProduct;

        //        while ((currentProduct = reader.ReadLine()) != null)
        //        {
        //            // להמיר מ-json אוביקט
        //            Product product = JsonConvert.DeserializeObject<Product>(currentProduct);
        //            if (product != null && product.Id == id)
        //            {
        //                return product;
        //            }
        //        }
        //    }
        //    return null;

        //}


        public List<Product> GetAllProduct()
        {
            //
           var products =  this._context.Products.ToList();
            return products;
        }
    }
}


    //public class GetDataFromSql
    //{
    //    public List<Product> GetAllProduct()
    //    {

    //        /// 
    //        // select * from TblProducts; 

    //       // return products;
    //    }
    //}

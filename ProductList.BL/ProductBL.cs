using DTO;
using ProductList.DAL;
using System;
using System.Collections.Generic;

namespace ProductList.BL
{
    public class ProductBL : IProductBL
    {
        // מגדירים משתנה מסוג הממשק
        IProductDL _productDl;
        IDI _di;
        public ProductBL(IProductDL productDl , IDI di)
        {
            this._productDl = productDl;
            this._di = di; 
        }

        public List<ProductDTO> GetAllProduct()
        {
            // יצרתי מופע מסוג המחלקה
         //   ProductDL productDl = new ProductDL();
            var products = _productDl.GetAllProduct();
            List<ProductDTO> productDTOList = new List<ProductDTO>();

            foreach (var item in products)
            {
                productDTOList.Add(new ProductDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Price = (int)item.Price

                }) ;
            }
            return productDTOList;
        }

        public int IncreaseX()
        {
           return _di.IncreaseX();
        }
    }
}

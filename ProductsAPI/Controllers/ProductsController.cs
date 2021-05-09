using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductList.BL;
using ProductList.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        List<ProductDTO> products = new List<ProductDTO>()
        {
          new ProductDTO { Id = 1 , Name = "Milk" , Price = 8},
          new ProductDTO { Id = 2 , Name = "Bread" , Price = 8}
        };
        IProductBL _productBl;
        IDI _di;
        public ProductsController(IProductBL productBl , IDI di  )
        {
            this._productBl = productBl;
            this._di = di; 
        }

        // Get api/Products/GetAllProduct
        [Route("[action]")]
        [HttpGet]
        public ActionResult<List<ProductDTO>> GetAllProduct()
        {
            //ProductBL productBl = new ProductBL();

            List<ProductDTO> products1 = _productBl.GetAllProduct();
            if (products1 == null)
            {
                return NoContent();
            }
            return Ok(products1);

        }

        [Route("[action]")]
        [HttpGet]
        public int IncreaseX()
         {
           return _di.IncreaseX(); 

        }



        // Get api/Products
        [HttpGet]
        public string Get()
        {
            return "hello"; 
            
        }

        //  GET api/Product/GetById/1
        [HttpGet("[action]/{id}")]
        public ActionResult<ProductDTO> GetById([FromRoute] int id)
        {
            var currentProduct = products.SingleOrDefault(i => i.Id == id);
           if(currentProduct == null)
            {
                return NotFound();
            }
            return Ok();
        }

        // api/Products/SearchProductByName?name=xxx
        [HttpGet("[action]/{id}")]
        public ProductDTO SearchProductByName([FromQuery] string name, [FromRoute] int id)
        {
            var currentProduct = products.SingleOrDefault(i => i.Name == name);
            return currentProduct;
        }
        // Post api/Products
        [HttpPost]
        public void AddProduct([FromBody] ProductDTO currentProduct)
        {
            if(currentProduct != null)
            {
                products.Add(currentProduct);
            }
        }

        [HttpPut("{id}")]
        public void UpdateProduct([FromBody] ProductDTO p, [FromRoute] int id)
        {
            if(p != null)
            {
                var productToUpdate = products.Where(i => i.Id == id).FirstOrDefault();
                productToUpdate.Id = p.Id;
                productToUpdate.Name = p.Name;
                productToUpdate.Price = p.Price;
            }

        }

        [HttpDelete("[action]/{id}")]
        public void DeleteById([FromRoute] int id)
        {
            var currentProductToRemove = products.SingleOrDefault(i => i.Id == id);
            products.Remove(currentProductToRemove);
        }

    }
}

using DTO;
using System.Collections.Generic;

namespace ProductList.BL
{
    public interface IProductBL
    {
        List<ProductDTO> GetAllProduct();
        public int IncreaseX();
    }
}
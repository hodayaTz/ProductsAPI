using System;
using System.Collections.Generic;
using System.Text;

namespace ProductList.DAL
{
    public class DI : IDI
    {
        int x = 0;
        public int IncreaseX()
        {
            x++;
            return x;
        }
    }
}

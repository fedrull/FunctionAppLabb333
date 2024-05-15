using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionAppLabb333
{
    public class Product
    {
        public string Id { get; set; }  = Guid.NewGuid().ToString();

        public string Name { get; set; }
        public int Price { get; set; }

    }

    //internal class CreatingProduct
    //{
    //    public string ProductName { get; set; } = Guid.NewGuid().ToString();
    //}

    //internal class UppdateingProduct
    //{
    //    public string ProductName { get; set; }
    //    public bool Collected { get; set; }
    //}
}

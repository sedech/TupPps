using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussnessEntities
{
    public class ProductToCreateBe
    {
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public float PriceSales { get; set; }
        public float PricePurchase { get; set; }
        public string Img { get; set; }
    }
}

﻿
namespace DataModels.Entities
{
    public class Category:EntityBase
    {
    
        public string Name { get; set; }
        //public string Description { get; set; }

        public List<Product> Products { get; set; }

    }
}

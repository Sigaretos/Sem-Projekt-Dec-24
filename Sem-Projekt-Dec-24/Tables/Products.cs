﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_Projekt_Dec_24.Tables
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public int ProductStock { get; set; }

        public Products(int productId, string productName, string productCategory, int productStock)
        {
            ProductId = productId;
            ProductName = productName;
            ProductCategory = productCategory;
            ProductStock = productStock;
        }
        public string ProductInformation
        {
            get { return $"{ProductName}, {ProductCategory}, {ProductStock}"; }
        }
    }
}

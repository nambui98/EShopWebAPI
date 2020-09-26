using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopWebAPI.DTO
{
    public class ProductDTO
    {
        int ProductID;
        int? CategoryID;
        string ProductName;
        int? unitPrice;
        int? quantity;

        public ProductDTO(int productID, int? categoryID, string productName, int? unitPrice, int? quantity)
        {
            ProductID = productID;
            CategoryID = categoryID;
            ProductName = productName;
            this.unitPrice = unitPrice;
            this.quantity = quantity;
        }

        public int productID { get => ProductID; set => ProductID = value; }
        public int? categoryID { get => CategoryID; set => CategoryID = value; }
        public string productName { get => ProductName; set => ProductName = value; }
        public int? UnitPrice { get => unitPrice; set => unitPrice = value; }
        public int? Quantity { get => quantity; set => quantity = value; }
    }
}
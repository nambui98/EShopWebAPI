using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EShopWebAPI.DTO
{
    public class CategoryDTO
    {
        int CategoryID;
        string CategoryName;
        string Description;

        public CategoryDTO(int categoryID, string categoryName, string description)
        {
            CategoryID = categoryID;
            CategoryName = categoryName;
            Description = description;
        }

        public int categoryID { get => CategoryID; set => CategoryID = value; }
        public string categoryName { get => CategoryName; set => CategoryName = value; }
        public string description { get => Description; set => Description = value; }
    }
}
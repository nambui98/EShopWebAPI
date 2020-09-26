using EShopWebAPI.DTO;
using EShopWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EShopWebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        // GET: api/Category
        public HttpResponseMessage Get()
        {
            using (EShopEntities db = new EShopEntities())
            {
                var result = db.Categories.ToList();
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result.ToList());
                }
                else
                {
                    return null;
                }
            }
        }


        // GET: api/Category/5
        public CategoryDTO Get(int id)
        {
            using (EShopEntities db = new EShopEntities())
            {
                Category c = db.Categories.SingleOrDefault(x => x.CategoryID == id);
                if (c != null)
                {
                    return new CategoryDTO(c.CategoryID,c.CategoryName,c.Description ); 
                }
                else
                {
                    return null;
                }
            }
        }

        // POST: api/Category
        public HttpResponseMessage Post([FromBody]Category cate)
        {
            try
            {
                using (EShopEntities db = new EShopEntities())
                {
                    db.Categories.Add(cate);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT: api/Category/5
        public HttpResponseMessage Put(int id, [FromBody] Category value)
        {
            try
            {

                using (EShopEntities db = new EShopEntities())
                {
                    Category s = db.Categories.SingleOrDefault(b => b.CategoryID == id);
                    if (s != null)
                    {
                        s.CategoryID = id;
                        s.CategoryName = value.CategoryName;
                        s.Description = value.Description;
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, s);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // DELETE: api/Category/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (EShopEntities db = new EShopEntities())
                {
                    Category s = db.Categories.SingleOrDefault(x => x.CategoryID == id);
                    db.Categories.Remove(s);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}

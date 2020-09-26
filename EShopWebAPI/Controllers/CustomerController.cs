using EShopWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EShopWebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        // GET: api/GetAllCustomers
        public HttpResponseMessage GetAllCustomers()
        {
            using (EShopEntities db = new EShopEntities())
            {
                var result = db.Customers.ToList();
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

        // GET: api/GetCustomerByID/5
        public HttpResponseMessage GetCustomerByID(int id)
        {
            using (EShopEntities db = new EShopEntities())
            {
                Customer c = db.Customers.SingleOrDefault(x => x.CustomerID == id);
                if (c != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, c);
                }
                else
                {
                    return null;
                }
            }
        }

        // POST: api/AddCustomer
        public HttpResponseMessage AddCustomer([FromBody]Customer cus)
        {
            try
            {
                using (EShopEntities db = new EShopEntities())
                {
                    db.Customers.Add(cus);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
        [HttpGet]
        public List<Customer> GetCustomerByAddress(string address)
        {
            using (EShopEntities db = new EShopEntities())
            {
                List<Customer> listcus = new List<Customer>();


                listcus = db.Customers.Where(s => s.Address.Contains(address)).ToList();
                
                return listcus;
            }
        }
    }
}

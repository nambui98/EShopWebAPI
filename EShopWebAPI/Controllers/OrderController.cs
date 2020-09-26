using EShopWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EShopWebAPI.Controllers
{
    public class OrderController : ApiController
    {
        // GET: api/GetAllOrders
        public HttpResponseMessage GetAllOrders()
        {
            using (EShopEntities db = new EShopEntities())
            {
                var result = db.Orders.ToList();
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

        // GET: api/GetOrderByID/5
        public HttpResponseMessage GetOrderByID(int id)
        {
            using (EShopEntities db = new EShopEntities())
            {
                Order o = db.Orders.SingleOrDefault(x => x.OrderID == id);
                if (o != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, o);
                }
                else
                {
                    return null;
                }
            }
        }

        // POST: api/AddOrder
        public HttpResponseMessage AddOrder([FromBody]Order order)
        {

            try
            {
                using (EShopEntities db = new EShopEntities())
                {
                    db.Orders.Add(order);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT: api/EditOrder/5
        public HttpResponseMessage EditOrder(int id, [FromBody]Order order)
        {
            try
            {

                using (EShopEntities db = new EShopEntities())
                {
                    Order s = db.Orders.SingleOrDefault(b => b.OrderID == id);
                    if (s != null)
                    {
                        s.OrderID = id;
                        s.CustomerID = order.CustomerID;
                        s.OrderDate = order.OrderDate;
                        s.ShipAddress = order.ShipAddress;
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

        // DELETE: api/DeleteOrder/5
        public HttpResponseMessage DeleteOrder(int id)
        {
            try
            {
                using (EShopEntities db = new EShopEntities())
                {
                    Order o = db.Orders.SingleOrDefault(x => x.OrderID == id);
                    db.Orders.Remove(o);
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

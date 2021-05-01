using PMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PMS_WebAPI.Controllers
{
    public class ProductController : ApiController
    {
        ProductManagementSystemEntities db = new ProductManagementSystemEntities
    }

    public IHttpActionResult orderById()
    {
        IList<dbo_Order> orders = null;

        using (var ctx = new ProductManagementSystemEntities())
        {
            orders = ctx.Orders.include("")

            .Select(s => new dbo_Order()
            {
                Id = s.OrderId,
                ProductQuantity = s.ProductQuantity,
                BookingOn = s.BookingOn,
            }).ToList<dbo_Order>();
        }

        if (orders.Count == 0)
        {
            return NotFound();
        }
        return Ok(orders);

    }
}

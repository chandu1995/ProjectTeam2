﻿using PMS_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;


namespace PMS_WebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class ProductController : ApiController
    {
        PMSEntities db = new PMSEntities();


        [HttpGet]
        [Route("api/GetProducts")]
        public IEnumerable<Product> GetProduct()
        {
            IList<Product> products = db.Products.ToList<Product>();
            List<Product> products1 = new List<Product>();
            foreach (var p in products)
            {
                Product List = new Product()
                {
                    PID = p.PID,
                    PName = p.PName,
                    ImageName = p.ImageName,
                    ImageCode = p.ImageCode,
                    Discount = p.Discount,
                    IsStock = p.IsStock,
                    Quantity = p.Quantity,
                    Price = p.Price
                };

                products1.Add(List);
            }
            return products.OrderByDescending(p => p.PID);
        }

        [HttpGet]
        [Route("api/GetProduct/{PName}")]
        public Product GetProduct(string PName)
        {
            Product product = (from p in db.Products
                               where p.PName == PName
                               select p).FirstOrDefault();
            Product product1 = new Product()
            {
                PID = product.PID,
                PName = product.PName,
                ImageName = product.ImageName,
                ImageCode = product.ImageCode,
                Discount = product.Discount,
                IsStock = product.IsStock,
                Quantity = product.Quantity,
                Price = product.Price
            };
            return product1;
        }

        [HttpPost]
        [Route("api/AddProduct")]
        public HttpResponseMessage AddProduct()
        {
            Product product = new Product();
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            product.PName = httpRequest["PName"];
            product.Price = Convert.ToInt32(httpRequest["Price"]);
            product.Discount = Convert.ToInt32(httpRequest["Discount"]);
            product.Quantity = Convert.ToInt32(httpRequest["Quantity"]);

            if (httpRequest["IsStock"] == "true")
                product.IsStock = true;
            else
                product.IsStock = false;

            if (httpRequest.Files.Count > 0)
            {
                //var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var allowedExtensions = new[] {
                  ".jpg", ".png", ".jpg", "jpeg"
                };

                    var postedFile = httpRequest.Files[file];

                    var fileName = Path.GetFileName(postedFile.FileName); //getting only file name(ex-ganesh.jpg)  
                    var ext = Path.GetExtension(postedFile.FileName); //getting the extension(ex-.jpg)  
                    if (allowedExtensions.Contains(ext.ToLower())) //check what type of extension  
                    {
                        Stream stream = postedFile.InputStream;
                        BinaryReader binaryReader = new BinaryReader(stream);
                        Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                        product.ImageName = fileName;
                        product.ImageCode = bytes;
                        db.Products.Add(product);
                        db.SaveChanges();

                    }
                }
                result = Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }

        [HttpPut]
        [Route("api/UpdateProduct/{id}")]
        public HttpResponseMessage UpdateProduct(int id)
        {
            Product product = new Product();
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            product.PID = id;
            product.PName = httpRequest["PName"];
            product.Discount = Convert.ToInt32(httpRequest["Discount"]);
            product.Price = Convert.ToInt32(httpRequest["Price"]);
            product.Quantity = Convert.ToInt32(httpRequest["Quantity"]);

            if (httpRequest["IsStock"] == "true")
                product.IsStock = true;
            else
                product.IsStock = false;

            if (httpRequest.Files.Count > 0)
            {
                //var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var allowedExtensions = new[] {
                  ".jpg", ".png", ".jpg", "jpeg"
                };

                    var postedFile = httpRequest.Files[file];

                    var fileName = Path.GetFileName(postedFile.FileName); //getting only file name(ex-ganesh.jpg)  
                    var ext = Path.GetExtension(postedFile.FileName); //getting the extension(ex-.jpg)  
                    if (allowedExtensions.Contains(ext.ToLower())) //check what type of extension  
                    {
                        Stream stream = postedFile.InputStream;
                        BinaryReader binaryReader = new BinaryReader(stream);
                        Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                        product.ImageName = fileName;
                        product.ImageCode = bytes;

                        db.Entry(product).State = EntityState.Modified;
                        try
                        {
                            db.SaveChanges();
                        }
                        catch (DbUpdateConcurrencyException)
                        {
                            if (!ProductExists(id))
                            {
                                return Request.CreateResponse(HttpStatusCode.BadRequest);
                            }
                            else
                            {
                                throw;
                            }
                        }

                    }
                }
                result = Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.PID == id) > 0;
        }
<<<<<<< HEAD
<<<<<<< Updated upstream
=======

=======
>>>>>>> main
        [HttpPost]
        [Route("api/AddToCart")]
        public void AddToCart(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();
        }
<<<<<<< HEAD

=======
>>>>>>> main
        [HttpDelete]
        [Route("api/DeleteCart")]
        public void DeleteCart(int cartId)
        {
            Cart cart = (from c in db.Carts
                         where c.CartId == cartId
                         select c).FirstOrDefault();
            if(cart == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                db.Carts.Remove(cart);
            }
        }
<<<<<<< HEAD
        
        [Route("api/DeleteProduct")]
=======
        [Route("api/DeleteProduct")]
        // [AcceptVerbs("Get")]
>>>>>>> main
        public void DeleteProduct(int id)
        {
            Product product = (from p in db.Products
                               where p.PID == id
                               select p).FirstOrDefault();
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                db.Products.Remove(product);
            }
        }
<<<<<<< HEAD
        
=======
>>>>>>> main
        [HttpPost]
        [Route("api/AddOrder")]
        public HttpResponseMessage AddOrder()
        {
            Order order = new Order();
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            // order.OrderId = Convert.ToInt32(httpRequest["OrderId"]);
            order.ProductId = Convert.ToInt32(httpRequest["ProductId"]);
            order.ProductQuantity = Convert.ToInt32(httpRequest["ProductQuantity"]);
            order.UserId = Convert.ToInt32(httpRequest["UserId"]);
            order.BookingOn = Convert.ToDateTime(httpRequest["BookingOn"]);
            order.DeliveredOn = Convert.ToDateTime(httpRequest["DeliveredOn"]);
            db.Orders.Add(order);
            db.SaveChanges();
            var max = db.Orders.OrderByDescending(p => p.OrderId).FirstOrDefault().OrderId;
            result = Request.CreateResponse(HttpStatusCode.Created);

            // return max;
            return result;
        }

        [HttpGet]
        [Route("api/GetOrder")]
        [AcceptVerbs("GET")]
        public IEnumerable<Order> GetOrder()
        {
            IList<Order> orders = db.Orders.ToList<Order>();
            List<Order> orders1 = new List<Order>();
            using (var context = new PMSEntities())
            {
                var query = from st in context.Orders
                            select st;

            }
            foreach (var p in orders)
            {
                Order List = new Order()
                {
                    OrderId = p.OrderId,
                    ProductId = p.ProductId,
                    ProductQuantity = p.ProductQuantity,
                    UserId = p.UserId,
                    BookingOn = p.BookingOn,
                    DeliveredOn = p.DeliveredOn,

                };

                orders1.Add(List);
            }
            return orders1;
        }

        [HttpGet]
        [Route("api/GetOrder/{id}")]
        public Order GetOrder(int id)
        {
            Order order = (from p in db.Orders
                           where p.OrderId == id
                           select p).FirstOrDefault();
            Order orders1 = new Order()
            {
                OrderId = order.OrderId,
                ProductId = order.ProductId,
                ProductQuantity = order.ProductQuantity,
                UserId = order.UserId,
                BookingOn = order.BookingOn,
                DeliveredOn = order.DeliveredOn,
            };
            //byte[] imgData = product.ImageCode;
            //MemoryStream ms = new MemoryStream(imgData);
            //HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            //response.Content = new StreamContent(ms);
            //response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpg");
            return orders1;
        }

<<<<<<< HEAD
=======
        //Chandu
        [HttpGet]
        [Route("api/GetPaymentDetails")]
        [AcceptVerbs("GET")]
        public IEnumerable<Payment> GetPaymentDetails()
        {
            IList<Payment> payments = db.Payments.ToList<Payment>();
            List<Payment> payments1 = new List<Payment>();
            using (var context = new PMSEntities())
            {
                var query = from st in context.Payments
                            select st;

            }
            foreach (var p in payments)
            {
                Payment List = new Payment()
                {
                    PayId = p.PayId,
                    OrderId = p.OrderId,
                    UserId = p.UserId,
                    BankName = p.BankName,
                    CardNo = p.CardNo,
                    NameOnCard = p.NameOnCard,
                    ExpiryDate = p.ExpiryDate

                };

                payments1.Add(List);
            }
            return payments1;
        }

        [HttpGet]
        [Route("api/GetPaymentDetails/{id}")]

        public Payment GetPaymentDetails(int id)
        {
            Payment payment = (from p in db.Payments where p.PayId == id select p).FirstOrDefault();
            Payment payment1 = new Payment()
            {
                PayId = payment.PayId,
                OrderId = payment.OrderId,
                UserId = payment.UserId,
                CardNo = payment.CardNo,
                BankName = payment.BankName,
                NameOnCard = payment.NameOnCard,
                ExpiryDate = payment.ExpiryDate
            };
            return payment1;


        }



>>>>>>> main
        [HttpPost]
        [Route("api/AddPayment")]
        public HttpResponseMessage AddPayment()
        {
            Payment payments = new Payment();
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;

            payments.OrderId = Convert.ToInt32(httpRequest["OrderId"]);
            payments.UserId = Convert.ToInt32(httpRequest["UserId"]);
            payments.CardNo = Convert.ToString(httpRequest["CardNo"]);
            payments.BankName = Convert.ToString(httpRequest["BankName"]);
            payments.NameOnCard = Convert.ToString(httpRequest["NameOnCard"]);
            payments.ExpiryDate = Convert.ToDateTime(httpRequest["ExpiryDate"]);
            db.Payments.Add(payments);
            db.SaveChanges();
            // var max = db.Orders.OrderByDescending(p => p.OrderId).FirstOrDefault().OrderId;
            result = Request.CreateResponse(HttpStatusCode.Created);

            // return max;
            return result;
        }
<<<<<<< HEAD
>>>>>>> Stashed changes
=======


>>>>>>> main
    }



}

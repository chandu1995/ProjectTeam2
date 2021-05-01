using PMS_DAL.Models;
using System;
using System.Collections.Generic;
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
            //product.Quantity = Convert.ToInt32(httpRequest["Quantity"]);
            
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

    }

}


using Microsoft.AspNetCore.Mvc;
using ShoppingSiteAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSiteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Products> Get()
        {
            using (var context = new ShoppingSiteDBContext())
            {
                return context.Products.ToList();
            }
        }

        [HttpGet("{id}")]
        public Products Get(int id)
        {
            using (var context = new ShoppingSiteDBContext())
            {
                return context.Products.Where(p => p.Id == id).FirstOrDefault();
            }
        }

        [HttpPost]
        public IEnumerable<Products> Post(Products product)
        {
            using (var context = new ShoppingSiteDBContext())
            {
                context.Products.Add(product);

                context.SaveChanges();

                return context.Products.ToList();
            }
        }

        [HttpPut]
        public IEnumerable<Products> Put(Products product)
        {
            using (var context = new ShoppingSiteDBContext())
            {
                var prod = context.Products.Where(p => p.Id == product.Id).FirstOrDefault();

                prod.Title = product.Title;
                prod.Description = product.Description;
                prod.Price = product.Price;
                prod.ImageSrc = product.ImageSrc;

                context.SaveChanges();

                return context.Products.ToList();
            }
        }

        [HttpDelete("{id}")]
        public IEnumerable<Products> Delete(int id)
        {
            using (var context = new ShoppingSiteDBContext())
            {
                var prod = context.Products.Where(p => p.Id == id).FirstOrDefault();

                context.Products.Remove(prod);

                context.SaveChanges();

                return context.Products.ToList();
            }
        }
    }
}

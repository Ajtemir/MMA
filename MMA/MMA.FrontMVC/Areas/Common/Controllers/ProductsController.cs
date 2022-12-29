using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MMA.DAL.Common;
using MMA.Domain.Common;

namespace MMA.FrontMVC.Areas.Common.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using var context = new CommonContext();
            var entities = context.Products
                .Include(x=>x.Category)
                .ToList();
            ViewData[nameof(entities)] = entities;
            
            return View();
        }

        
        // [HttpGet]
        // public ActionResult AddOrUpdate(int? entityId)
        // {
        //     using var context = new CommonContext();
        //     ViewData["entity"] = entityId is null
        //         ? new Product()
        //         : context.Products
        //             .Include(x=>x.Category)
        //             .Include(x=>x.Category.ProductPropertyKeys.Select(y=>y.CategoryId))
        //             .FirstOrDefault(x => x.ProductId == entityId);
        //     ViewData["categories"] = 
        //     
        // }
        
        // var dict = context.Categories
        //     .Include(x => x.ProductPropertyKeys.Select(k=>k.PropertyValues))
        //     .FirstOrDefault(x => x.CategoryId == categoryId)?
        //     .ProductPropertyKeys
        //     .GroupBy(x => x)
        //     .ToDictionary(x => x.Key, 
        //         x => x.Key.PropertyValues);
        // ViewData["properties"] = dict;


        [HttpGet]
        public ActionResult Delete(long entityId)
        {
            using var context = new CommonContext();
            var entity = context.Products.FirstOrDefault(x => x.ProductId == entityId);
            if (entity is not null)
            {
                context.Products.Remove(entity);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Products", new { Area = "Common" });
        }

        [HttpGet]
        public ActionResult Add()
        {
            using var context = new CommonContext();
            var categories = context.Categories
                .Include(x => x.SubCategories)
                .Where(x => x.SubCategories.Count == 0)
                .ToList();
            ViewData[nameof(categories)] = categories;
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product entity)
        {
            using var context = new CommonContext();
            context.Products.Add(entity);
            context.SaveChanges();
            return RedirectToAction("Index","Products", new{Area="Common"});
        }

        public ActionResult Update(int entityId)
        {
            using var context = new CommonContext();
           
            Product current = context.Products
                .Include(x => x.Category)
                .Include(x=>x.ProductProperties)
                .FirstOrDefault(x=>x.ProductId==entityId);

            if (current is null) throw new Exception("Не найден товар по идентификатору");

            HashSet<int> selectedProperties = current.ProductProperties.Select(x => x.ProductPropertyValueId).ToHashSet();
            // throw new Exception(string.Join(" ",selectedProperties.ToList()));
            Dictionary<ProductPropertyKey, ICollection<ProductPropertyValue>> properties = context.Categories
                .Include(x => x.ProductPropertyKeys.Select(k=>k.PropertyValues))
                .FirstOrDefault(x => x.CategoryId == current.CategoryId)?
                .ProductPropertyKeys
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, 
                    x => x.Key.PropertyValues);
            if (current.Price == null) throw new Exception("Price null");
            ViewData[nameof(properties)] = properties;
            ViewData[nameof(current)] = current;
            ViewData[nameof(selectedProperties)] = selectedProperties;
            
            return View();
        }

        [HttpPost]
        public ActionResult Update(Product product,params string[] properties)
        {
            using var context = new CommonContext();
            context.Products.AddOrUpdate(product);
            context.Database.ExecuteSqlCommand($"delete from dbo.ProductProperties where ProductId={product.ProductId}");
            if (properties != null)
            {
                var addedProperties = properties.Where(x => !string.IsNullOrWhiteSpace(x))
                    .Select(ProductProperty.CreateInstance).ToList();
                context.ProductProperties.AddRange(addedProperties);
            }
            context.SaveChanges();
            return RedirectToAction("Update","Products",new{Area="Common", entityId=product.ProductId});
        }
        
    }
}
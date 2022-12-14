using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using MMA.DAL.Common;
using MMA.Domain.Common;
using TemporaryStorage;

namespace MMA.FrontMVC.Areas.Common.Controllers
{
    public class ProductPropertyValuesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            using var context = new CommonContext();
            var entities = context.ProductPropertyValues
                .Include(x => x.ProductPropertyKey)
                .Include(x => x.ProductPropertyKey.Category)
                .ToList();
            ViewData[nameof(entities)] = entities;
            var headers = Utility.GetGridHeaders<ProductPropertyValue>();
            ViewData[nameof(headers)] = headers;
            return View();
        }
        
        public ActionResult AddOrUpdate(int? entityId)
        {
            using var context = new CommonContext();
            Dictionary<string, List<ProductPropertyKey>> propertyKeys = context
                .ProductPropertyKeys
                .Include(x => x.Category)
                .GroupBy(x => x.Category.CategoryName)
                .ToDictionary(x=>x.Key, x=>x.ToList());
            ViewData[nameof(propertyKeys)] = propertyKeys;
            if (entityId is not null)
            {
                var entity = context.ProductPropertyValues.First(x=>x.ProductPropertyValueId==entityId);
                ViewData[nameof(entity)] = entity;
            }
            else
            {
                ViewData["entity"] = new ProductPropertyValue();
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddOrUpdate(ProductPropertyValue entity)
        {
            using var context = new CommonContext();
            context.ProductPropertyValues.AddOrUpdate(entity);
            context.SaveChanges();
            return RedirectToAction("Index", "ProductPropertyValues", new { Area = "Common" });
        }

        [HttpGet]
        public ActionResult Delete(int entityId)
        {
            using var context = new CommonContext();
            var entity = context.ProductPropertyValues.FirstOrDefault(x => x.ProductPropertyValueId == entityId);
            if (entity is not null)
            {
                context.ProductPropertyValues.Remove(entity);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "ProductPropertyValues", new { Area = "Common" });
        }
    }
}
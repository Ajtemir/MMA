using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;
using MMA.DAL.Common;
using MMA.Domain.Common;

namespace MMA.FrontMVC.Areas.Common.Controllers
{
    public class ProductPropertyKeysController : Controller
    {
        private CommonContext _context;

        public ProductPropertyKeysController()
        {
            _context = new CommonContext();
        }
        public ActionResult Index()
        {
            using var context = new CommonContext();
            var productPropertyKeys = context
                .ProductPropertyKeys
                .Include(x=>x.Category)
                .ToList();
            ViewData[nameof(productPropertyKeys)] = productPropertyKeys;
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            using var context = new CommonContext();
            var categories = context
                .Categories
                .Include(x=>x.SubCategories.Select(c=>c.ParentCategory))
                .Where(x => x.SubCategories.Count == 0)
                .ToList();
            ViewData[nameof(categories)] = categories;
            return View();
        }

        [HttpPost]
        public ActionResult Add(ProductPropertyKey productPropertyKey)
        {
            using var context = new CommonContext();
            context.ProductPropertyKeys.Add(productPropertyKey);
            context.SaveChanges();
            return RedirectToAction("Index","ProductPropertyKeys",new {Area="Common"});
        }

        [HttpPost]
        public ActionResult Update(ProductPropertyKey entity)
        {
            using var context = new CommonContext();
            context.ProductPropertyKeys.AddOrUpdate(entity);
            context.SaveChanges();
            return RedirectToAction("Index", "ProductPropertyKeys", new { Area = "Common" });
        }

        public ActionResult Update(int entityId)
        {
            using var context = new CommonContext();
            var current = context.ProductPropertyKeys
                .FirstOrDefault(x => x.ProductPropertyKeyId.Equals(entityId));
            if (current == null) throw new Exception("Entity not found");
            var categories = context.Categories
                .Include(x => x.SubCategories)
                .Where(x => x.SubCategories.Count == 0)
                .ToList();
            ViewData[nameof(current)] = current;
            ViewData[nameof(categories)] = categories;
            return View();
        }
        
        [HttpGet]
        public ActionResult Delete(int entityId)
        {
            using var context = new CommonContext();
            var entity = context.ProductPropertyKeys.FirstOrDefault(x => x.ProductPropertyKeyId == entityId);
            if (entity is not null)
            {
                context.ProductPropertyKeys.Remove(entity);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "ProductPropertyKeys", new { Area = "Common" });
        }
        
    }
}
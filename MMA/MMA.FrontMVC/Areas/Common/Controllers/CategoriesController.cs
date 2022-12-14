using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MMA.DAL.Common;
using MMA.Domain.Common;

namespace MMA.FrontMVC.Areas.Common.Controllers
{
    public class CategoriesController : Controller
    {
        public ActionResult Index()
        {
            using var context = new CommonContext(false);
            ViewData["Categories"] = context.Categories.ToList();
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            using var context = new CommonContext();
            var categories = context.Categories
                .Include(x=>x.ParentCategory)
                .ToList();
            ViewData["Categories"] = categories;
            return View();
        }
        
        [HttpGet]
        public ActionResult Update(int categoryId)
        {
            using var context = new CommonContext();
            var current = context.Categories
                .Include(x=>x.ParentCategory)
                .FirstOrDefault(x => x.CategoryId == categoryId);
            if (current is null) 
                return RedirectToAction("Index","Categories",new {Area="Common"});
            var categories = context.Categories
                .Where(x=>x.CategoryId!=categoryId && x.CategoryId!=current.ParentCategoryId)
                .ToList();
            ViewData["categories"] = categories;
            ViewData["current"] = current;
            return View();
        }
        
        [HttpPost]
        public ActionResult Update(Category category)
        {
            using var context = new CommonContext();
            var current = context.Categories.FirstOrDefault(x => x.CategoryId == category.CategoryId);
            if (current != null)
            {
                current.CategoryName = category.CategoryName;
                current.ParentCategoryId = category.ParentCategoryId;
                context.SaveChanges();
            }
            return RedirectToAction("Index","Categories",new {Area="Common"});
        }
        
        
        [HttpPost]
        public ActionResult Add(Category category)
        {
            using var context = new CommonContext();
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index","Categories",new {Area="Common"});
        }

        [HttpGet]
        public ActionResult Delete(int categoryId)
        {
            using var context = new CommonContext();
            var category = context.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category is not null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
            return RedirectToAction("Index", "Categories", new { Area = "Common" });
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Models.Repository;

namespace WebApp.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var Categories = CategoriesRepository.GetCategories();
            return View(Categories);
        }

        public IActionResult Edit(int? id) 
        {
            ViewBag.Action = "Edit";
            //var category = new Category { CategoryId = id.HasValue ? id.Value : 0 };
            var category = CategoriesRepository.GetCategoryById(id.HasValue ? id.Value : 0);
            return View(category);  
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if(!ModelState.IsValid)
            {
                return View(category);
            }
            CategoriesRepository.UpdateCategory(category.CategoryId, category);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if(!ModelState.IsValid)
            {
                return View(category);
            }
            CategoriesRepository.AddCategory(category);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int categoryId)
        {
            CategoriesRepository.DeleteCategory(categoryId);
            return RedirectToAction(nameof(Index));
        }
    }
}

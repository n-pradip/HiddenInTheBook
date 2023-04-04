using HiddenInTheBook.Models;
using HiddenInTheBook.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace HiddenInTheBook.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _db;

        public CategoryController(ICategoryRepository db)
        {
            _db = db;
        }

        //Read operation for category
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.GetAll();
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //Create operations for categories
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder and Name connot match exactly");
            }
            if(ModelState.IsValid)
            {
                _db.Add(obj);
                _db.Save();
                TempData["success"] = "Category Added sucessfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Update operation for category

        //GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _db.Categories.Find(id);
            var categoryFromDb = _db.GetFirstOrDefault(u=>u.Id == id);
            
            if (categoryFromDb == null){
                return NotFound();
            }
            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("CustomError", "The DisplayOrder and Name connot match exactly");
            }
            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.Save();
                TempData["success"] = "Category Updated sucessfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Delete operation of category

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDbFirst = _db.GetFirstOrDefault(u => u.Id==id);

            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }
            return View(categoryFromDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Remove(obj);
            _db.Save();
            TempData["success"] = "Category Deleted sucessfully";
            return RedirectToAction("Index");
        }
    }
}

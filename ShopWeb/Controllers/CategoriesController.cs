using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWeb.Data.Dtos;
using ShopWeb.Data.Interfaces;

namespace ShopWeb.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategories categoriesDb;

        public CategoriesController(ICategories categoriesDb)
        {
            this.categoriesDb = categoriesDb;
        }
        public ActionResult Index()
        {
            var category = this.categoriesDb.GetCategories();
            return View(category);
        }

        // GET: CategoriesController/Details/5
        public ActionResult Details(int id)
        {
            var category = this.categoriesDb.GetCategoryById(id);
            return View(category);
        }

        // GET: CategoriesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriesAddDto addDto)
        {
            try
            {
                addDto.CreationDate = DateTime.Now;
                addDto.CreationUser = 2;
                this.categoriesDb.SaveCategory(addDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = this.categoriesDb.GetCategoryById(id);
            return View(category);
        }

        // POST: CategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriesUpdateDto updateDto)
        {
            try
            {
                updateDto.ModifyDate = DateTime.Now;
                updateDto.ModifyUser = 2;
                this.categoriesDb.UpdateCategory(updateDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        
        }
    }
}

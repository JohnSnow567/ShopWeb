using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWeb.Data.Dtos;
using ShopWeb.Data.Interfaces;

namespace ShopWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProducts productsDb;

        public ProductsController(IProducts productsDb)
        {
            this.productsDb = productsDb;
        }

        // GET: ProductsController
        public ActionResult Index()
        {
            var product = this.productsDb.GetProducts();
            return View(product);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            var product = this.productsDb.GetProductById(id);
            return View(product);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductsAddDto addDto)
        {
            try
            {
                addDto.CreationDate = DateTime.Now;
                addDto.CreationUser = 2;
                this.productsDb.SaveProduct(addDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductsUpdateDto updateDto)
        {
            try
            {
                updateDto.ModifyDate = DateTime.Now;
                updateDto.ModifyUser = 2;
                this.productsDb.UpdateProduct(updateDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

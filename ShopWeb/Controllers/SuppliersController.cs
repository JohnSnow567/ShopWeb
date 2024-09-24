using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWeb.Data.Dtos;
using ShopWeb.Data.Interfaces;

namespace ShopWeb.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISuppliers supplierDb;

        public SuppliersController(ISuppliers supplierDb)
        {
            this.supplierDb = supplierDb;
        }
        public ActionResult Index()
        {
            var suppliers = this.supplierDb.GetSuppliers();
            return View(suppliers);
        }
        public ActionResult Details(int id)
        {
            var supplier = this.supplierDb.GetSupplierById(id);
            return View(supplier);
        }

        // GET: SuppliersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuppliersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuppliersAddDto addDto)
        {
            try
            {
                addDto.CreationDate = DateTime.Now;
                addDto.CreationUser = 2;
                this.supplierDb.SaveSupplier(addDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuppliersController/Edit/5
        public ActionResult Edit(int id)
        {
            var supplier = this.supplierDb.GetSupplierById(id);
            return View(supplier);
        }

        // POST: SuppliersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuppliersUpdateDto updateDto)
        {
            try
            {
                updateDto.ModifyDate = DateTime.Now;
                updateDto.ModifyUser = 2;
                this.supplierDb.UpdateSupplier(updateDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

      
    }
}

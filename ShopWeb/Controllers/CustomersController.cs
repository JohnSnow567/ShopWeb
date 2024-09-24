using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopWeb.Data.Dtos;
using ShopWeb.Data.Interfaces;

namespace ShopWeb.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomers customersDb;

        public CustomersController(ICustomers customersDb)
        {
            this.customersDb = customersDb;
        }

        // GET: CustomersController
        public ActionResult Index()
        {
            var customer = this.customersDb.GetCustomers();
            return View(customer);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            var customer = this.customersDb.GetCustomerById(id);
            return View(customer);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomersAddDto addDto)
        {
            try
            {
                addDto.CreationDate = DateTime.Now;
                addDto.CreationUser = 2;
                this.customersDb.SaveCustomer(addDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomersUpdateDto updateDto)
        {
            try
            {
                updateDto.ModifyDate = DateTime.Now;
                updateDto.ModifyUser = 2;
                this.customersDb.UpdateCustomer(updateDto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

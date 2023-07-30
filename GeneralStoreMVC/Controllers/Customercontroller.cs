using Microsoft.AspNetCore.Mvc;
using GeneralStoreMVC.Data;
using GeneralStoreMVC.ViewModels.CustomerVM;
using Microsoft.EntityFrameworkCore;
using GeneralStoreMVC.Models;

namespace GeneralStoreMVC.Controllers
{

    public class Customercontroller : Controller
    {
        private readonly GeneralStoreDb23Context _ctx;
        public Customercontroller(GeneralStoreDb23Context ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var customers = await _ctx.Customers.Select(customer => new CustomerIndexModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email
            }).ToListAsync();

            return View(customers);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerCreateModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMsg"] = "Model State is Invalid";
                return View(model);
            }
            await _ctx.Customers.AddAsync(
                new Customer
                {
                    Name = model.Name,
                    Email = model.Email
                }
            );
            if (await _ctx.SaveChangesAsync() == 1)
            {
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMsg"] = "Unable to save to the database. Please try again later.";
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await _ctx.Customers.FindAsync(id);
            if (customer is null)
            {
                return NotFound();
            }
            var model = new CustomerDetailModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await _ctx.Customers.FindAsync(id);
            if (customer is null)
            {
                return NotFound();
            }
            var model = new CustomerEditModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CustomerEditModel model)
        {
            var customer = await _ctx.Customers.FindAsync(id);
            if (customer is null)
            {
                return NotFound();
            }
            customer.Name = model.Name;
            customer.Email = model.Email;

            if (await _ctx.SaveChangesAsync() == 1)
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await _ctx.Customers.FindAsync(id);
            if (customer is null)
            {
                return NotFound();
            }
            var model = new CustomerDetailModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _ctx.Customers.FindAsync(id);
            if (customer is null)
            {
                return NotFound();
            }
            
            _ctx.Customers.Remove(customer);
            await _ctx.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
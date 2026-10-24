using CRUD_Operations_In_ASP.NET_Core_Using_Entity_Framework_Core_Code_First.DbEntities;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Operations_In_ASP.NET_Core_Using_Entity_Framework_Core_Code_First.Models
{
    public class CustomerController : Controller
    {
        private readonly CRUDContext context;

        public CustomerController(CRUDContext context)
        {
            this.context = context;
        }

        // READ: list all customers
        [HttpGet]
        public IActionResult Index()
        {
            var model = context.Set<Customer>()
                .ToList()
                .Select(s => new CustomerViewModel
                {
                    Id = s.Id,
                    Name = $"{s.FirstName} {s.LastName}",
                    Email = s.Email,
                    MobileNo = s.MobileNo
                });

            return View(model);
        }

        // CREATE / UPDATE: show the form (empty for add, filled for edit)
        [HttpGet]
        public IActionResult AddEditCustomer(long? id)
        {
            var model = new CustomerViewModel();

            if (id.HasValue)
            {
                var customer = context.Set<Customer>().SingleOrDefault(c => c.Id == id.Value);
                if (customer == null)
                {
                    return NotFound();
                }

                model.Id = customer.Id;
                model.FirstName = customer.FirstName;
                model.LastName = customer.LastName;
                model.Email = customer.Email;
                model.MobileNo = customer.MobileNo;
            }

            return View(model);
        }

        // CREATE / UPDATE: save the form
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEditCustomer(long? id, CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool isNew = !id.HasValue;
            Customer? customer = isNew
                ? new Customer { AddedDate = DateTime.UtcNow }
                : context.Set<Customer>().SingleOrDefault(c => c.Id == id!.Value);

            if (customer == null)
            {
                return NotFound();
            }

            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.Email = model.Email;
            customer.MobileNo = model.MobileNo;
            customer.IPAddress = HttpContext.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            customer.ModifiedDate = DateTime.UtcNow;

            if (isNew)
            {
                context.Add(customer);
            }

            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // DELETE: show the confirmation page
        [HttpGet]
        public IActionResult DeleteCustomer(long id)
        {
            var customer = context.Set<Customer>().SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            var model = new CustomerViewModel
            {
                Id = customer.Id,
                Name = $"{customer.FirstName} {customer.LastName}"
            };

            return View(model);
        }

        // DELETE: actually delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCustomer(long id, CustomerViewModel model)
        {
            var customer = context.Set<Customer>().SingleOrDefault(c => c.Id == id);
            if (customer != null)
            {
                context.Remove(customer);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}

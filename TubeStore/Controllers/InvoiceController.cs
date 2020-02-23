using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TubeStore.DataLayer;
using TubeStore.Models;

namespace TubeStore.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IGenericRepository<Invoice> invoices;
        private readonly IGenericRepository<Tube> tubes;
        private readonly UserManager<Customer> userManager;

        public InvoiceController(IGenericRepository<Invoice> invoices,
                                 IGenericRepository<Tube> tubes,
                               UserManager<Customer> userManager)
        {
            this.invoices = invoices;
            this.tubes = tubes;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            Customer customer = userManager.Users.First(x => x.UserName == this.User.Identity.Name);

            IEnumerable<Invoice> customerInvoices = await
                invoices.FindAllAsync(x => x.CustomerId == customer.Id);
 
            return View(customerInvoices);
        }

        public IActionResult SetInactive(int id)
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            Invoice invoice = invoices.GetIncluding(x => x.InvoiceId == id,
                    x => x.Customer,
                    x => x.ShippingAddress,
                    x => x.InvoicesInfo).First();

            for (int i = 0; i < invoice.InvoicesInfo.Count; i++)
            {
                invoice.InvoicesInfo[i].Tube = await tubes.GetAsync(invoice.InvoicesInfo[i].TubeId);
            }
            
            return View(invoice);
        }

        public IActionResult PayInvoce(int id)
        {
            return View();
        }
    }
}
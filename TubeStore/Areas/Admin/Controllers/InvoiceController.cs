using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TubeStore.DataLayer;
using TubeStore.Models;

namespace TubeStore.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class InvoiceController : Controller
    {
        private readonly IGenericRepository<Invoice> invoices;
        private readonly IGenericRepository<Tube> tubes;
        private readonly ILogger<InvoiceController> logger;

        public InvoiceController(IGenericRepository<Invoice> invoices,
                                 IGenericRepository<Tube> tubes,
                                 ILogger<InvoiceController> logger)
        {
            this.invoices = invoices;
            this.tubes = tubes;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? page)
        {
            IQueryable<Invoice> invoiceList = invoices.GetAllIncluding(x => x.Customer);

            int pageSize = 15;
            int pageNumber = (page ?? 1);           
            return View(await PaginatedList<Invoice>.CreateAsync(invoiceList, 
                                                                 pageNumber, 
                                                                 pageSize));
        }

        [HttpGet]
        public async Task<IActionResult> SetInactive(int id)
        {
            Invoice invoice = invoices.GetIncluding(x => x.InvoiceId == id,
                    x => x.Customer,
                    x => x.ShippingAddress,
                    x => x.InvoicesInfo).First();

            invoice.Status = EnumStatus.Cancelled;
            await invoices.UpdateAsync(invoice);

            Tube tempTube;

            foreach (var item in invoice.InvoicesInfo)
            {
                tempTube = await tubes.GetAsync(item.TubeId);
                tempTube.Quantity += item.Quantity;
                await tubes.UpdateAsync(tempTube);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Invoice invoice = invoices.GetIncluding(x => x.InvoiceId == id,
                    x => x.Customer,
                    x => x.ShippingAddress,
                    x => x.Coupon,
                    x => x.InvoicesInfo).First();

            for (int i = 0; i < invoice.InvoicesInfo.Count; i++)
            {
                invoice.InvoicesInfo[i].Tube = await tubes.GetAsync(invoice.InvoicesInfo[i].TubeId);
            }
            return View(invoice);
        }

        [HttpGet]
        public async Task<IActionResult> SetPayed(int id)
        {
            Invoice invoice = await invoices.GetAsync(id);
            invoice.Status = EnumStatus.Paid;
            await invoices.UpdateAsync(invoice);
            return RedirectToAction("Index");
        }
    }
}

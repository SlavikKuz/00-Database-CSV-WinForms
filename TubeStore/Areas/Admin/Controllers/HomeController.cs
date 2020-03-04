using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TubeStore.DataLayer;
using TubeStore.Models;
using TubeStore.ViewModels;

namespace TubeStore.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IGenericRepository<Tube> tubes;
        private readonly IGenericRepository<Invoice> invoices;
        

        public HomeController(IGenericRepository<Tube> tubes,
                              IGenericRepository<Invoice> invoices)
        {
            this.tubes = tubes;
            this.invoices = invoices;
        }

        public IActionResult ChatWindow()
        {
            return PartialView("_ChatWindow");
        }
        
        public async Task<IActionResult> Index()
        {
            ICollection<Invoice> invoicesAllPaid =
                invoices.GetAllIncluding(x => x.InvoicesInfo)
                .Where(x => x.Status == EnumStatus.Paid)
                .ToList();
            
            DashboardViewModel model = new DashboardViewModel();
            model.CountProducts = await tubes.CountAsync();
            model.CountInvoices = invoicesAllPaid.Count();
            model.CountVisitors = Int32.Parse(this.HttpContext.Session.GetString("Counter"));

            foreach (var invoice in invoicesAllPaid)
            {
                foreach (var tube in invoice.InvoicesInfo)
                {
                    model.CountTubeSold += tube.Quantity;
                }
            }

            ICollection<Invoice> invoicesTwoWeeks =
                invoicesAllPaid.Where(x => x.OrderDate > DateTime.Now.AddDays(-14)).ToList();

            ChartViewModel chartViewModel = new ChartViewModel()
            {
                RangeX = GetRange(invoicesTwoWeeks),
                RangeYThisWeek = GetDates(7),
                RangeYLastWeek = GetDates(14),
                ChartPointsThisWeek = GetChartPoints(GetDates(7), invoicesTwoWeeks),
                ChartPointsLastWeek = GetChartPoints(GetDates(14), invoicesTwoWeeks),
                DeltaSales = GetDeltaSales(invoicesTwoWeeks)
            };

            model.ChartView = chartViewModel;
            
            List<int> tubeIds = new List<int>();
            foreach (var invoice in invoicesAllPaid)
            {
                foreach (var info in invoice.InvoicesInfo)
                {
                    info.Tube = await tubes.FindAsync(x => x.TubeId == info.TubeId);
                    tubeIds.Add(info.TubeId);
                }
            }

            List<TableViewModel> tableViews = new List<TableViewModel>();
            tubeIds = tubeIds.Distinct().ToList();

            Tube tempTube;
            foreach (int tubeId in tubeIds)
            {
                tempTube = await tubes.FindAsync(x => x.TubeId == tubeId);
                tableViews.Add(new TableViewModel()
                {
                    TubeId = tubeId,
                    UrlImageTube = tempTube.ImageThumbnailUrl,
                    TubeName = tempTube.Type + " " + tempTube.Brand,
                    PriceTube = tempTube.Price
                });
            }

            foreach (var tableView in tableViews)
            {
                foreach (var invoice in invoicesAllPaid)
                {
                    foreach (var info in invoice.InvoicesInfo)
                    {
                        if(info.TubeId == tableView.TubeId)
                            tableView.SoldTubes += info.Quantity;
                    }
                }
            }

            model.TableView = tableViews;

            return View(model);
        }

        private double GetDeltaSales(ICollection<Invoice> invoicesTwoWeeks)
        {
            int thisWeek = invoicesTwoWeeks.Where(x => x.OrderDate >= DateTime.Now.AddDays(-7)).Count();
            int lastWeek = invoicesTwoWeeks.Where(x => x.OrderDate < DateTime.Now.AddDays(-7)).Count();

            if (lastWeek == 0) lastWeek = 1;
        
            return (double)thisWeek / lastWeek - 1;
        }

        public int GetRange(ICollection<Invoice> invoices)
        {
            return (int)(Math.Ceiling((invoices.Count() * 1.4) / 10) * 10);
        }

        public List<ChartPointViewModel> GetChartPoints(List<string> dates, ICollection<Invoice> invoices)
        {
            List<ChartPointViewModel> chartPoints = new List<ChartPointViewModel>();
            foreach (var date in dates)
            {
                chartPoints.Add(new ChartPointViewModel()
                {
                    Date = date,

                    Value = invoices.Where(x =>
                        x.OrderDate.ToShortDateString() == date)
                        .Count()
                });
            }
            return chartPoints;
        }

        public List<string> GetDates(int offset)
        {
            List<string> dates = new List<string>();
            
            for(int i = 0; i<7; i++)
            {
                dates.Add(DateTime.Now.AddDays(i-offset).ToShortDateString());
            }
            return dates;
        }
    }
}
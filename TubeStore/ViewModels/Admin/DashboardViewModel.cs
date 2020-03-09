using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.ViewModels
{
    public class DashboardViewModel
    {
        public int CountProducts { get; set; }
        public int CountInvoices { get; set; }
        public int CountVisitors { get; set; }
        public int CountTubeSold { get; set; }

        public ChartViewModel ChartView { get; set; }

        public List<TableViewModel> TableView { get; set; }
                = new List<TableViewModel>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.ViewModels
{
    public class ChartViewModel
    {
        public int RangeX { get; set; }
        public List<string> RangeYThisWeek { get; set; }
        public List<string> RangeYLastWeek { get; set; }

        public double  DeltaSales { get; set; }

        public List<ChartPointViewModel> ChartPointsThisWeek { get; set; }
            = new List<ChartPointViewModel>();

        public List<ChartPointViewModel> ChartPointsLastWeek { get; set; }
    = new List<ChartPointViewModel>();
    }
}

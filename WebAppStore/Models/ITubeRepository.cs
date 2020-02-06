using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppStore.Models
{
    public interface ITubeRepository
    {
        IEnumerable<Tube> AllTubes { get; }
        IEnumerable<Tube> TubesOfTheWeek { get; }

        Tube GetTubeById(int tubeId);

    }
}

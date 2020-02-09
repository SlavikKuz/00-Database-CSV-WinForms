using System;
using System.Collections.Generic;
using System.Text;
using TubeStore.Domain.Models;

namespace TubeStore.App.Repository
{
    public interface ITubeRepository
    {
        IEnumerable<Tube> GetAllTubes { get; }

        Tube GetTubeById(int tubeId);
    }
}

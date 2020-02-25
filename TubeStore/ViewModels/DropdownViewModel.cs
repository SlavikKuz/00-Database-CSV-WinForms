using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TubeStore.ViewModels
{
    public class DropdownViewModel 
    {
        public List<string> DropdownItems { get; set; }
             = new List<string>();

        public string DropdownName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Edux.Models.PageViewModels
{
    public class DisplayViewModel
    {
        public Page Page { get; set; }
        public List<ComponentType> ComponentTypes { get; set; }
        public List<Component> Components { get; set; }
        public Component Component { get; set; }
        public List<Parameter> Parameters { get; set; }
        public bool IsFromHome { get; set; }
    }
}

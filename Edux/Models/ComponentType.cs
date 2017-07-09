using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Models
{
    public class ComponentType : BaseEntity
    {
        public ComponentType() : base()
        {
            Parameters = new HashSet<Parameter>();
            UpdateDate = DateTime.Now;
            UpdatedBy = "username";
        }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string DisplayName { get; set; }
        public virtual ICollection<Parameter> Parameters { get; set; }
    }
}

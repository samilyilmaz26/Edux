using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Models
{
    public class Component : BaseEntity
    {
        public Component() : base()
        {
            ParameterValues = new HashSet<ParameterValue>();
            View = "Default";
            UpdateDate = DateTime.Now;
        }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string DisplayName { get; set; }
        public long ComponentTypeId { get; set; }
        [ForeignKey("ComponentTypeId")]
        public ComponentType ComponentType { get; set; }
        public virtual ICollection<ParameterValue> ParameterValues { get; set; }
        [StringLength(200)]
        public string View { get; set; }
        public long? ParentComponentId { get; set; }
        public Component ParentComponent { get; set; }
        public virtual ICollection<Component> ChildComponents { get; set; }
        public virtual ICollection<PageComponent> PageComponents { get; set; }
    }
}

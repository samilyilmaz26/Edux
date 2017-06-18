using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Models
{
    public class Entity : BaseEntity
    {
        public Entity() : base()
        {
            Properties = new HashSet<Property>();
            PropertyValues = new HashSet<PropertyValue>();
            CreateDate = DateTime.Now;
            CreatedBy = "username";
            UpdateDate = DateTime.Now;
            UpdatedBy = "username";
        }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string PluralName { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
        public virtual ICollection<PropertyValue> PropertyValues { get; set; }
    }
}

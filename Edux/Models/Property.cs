using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Models
{
    public class Property : BaseEntity
    {
        public Property() : base()
        {
            PropertyValues = new HashSet<PropertyValue>();
            CreateDate = DateTime.Now;
            CreatedBy = "username";
            UpdateDate = DateTime.Now;
            UpdatedBy = "username";
        }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(200)]
        public string DisplayName { get; set; }
        public DataType? DataType { get; set; }
        public bool IsRequired { get; set; }
        public PropertyType PropertyType { get; set; }
        public int StringLength { get; set; }
        public long EntityId { get; set; }
        [ForeignKey("EntityId")]
        public Entity Entity { get; set; }
        public virtual ICollection<PropertyValue> PropertyValues { get; set; }
        public int Position { get; set; }
    }
}

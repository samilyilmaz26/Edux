using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Models
{
    public class PropertyValue : BaseEntity
    {
        public PropertyValue() : base()
        {
            CreateDate = DateTime.Now;
            CreatedBy = "username";
            UpdateDate = DateTime.Now;
            UpdatedBy = "username";
        }
        public string Value { get; set; }
        public long? EntityId { get; set; }
        [ForeignKey("EntityId")]
        public Entity Entity { get; set; }
        public long? PropertyId { get; set; }
        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
    }
}

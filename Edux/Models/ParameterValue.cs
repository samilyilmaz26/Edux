using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Models
{
    public class ParameterValue : BaseEntity
    {
        public ParameterValue() : base()
        {
            CreateDate = DateTime.Now;
            CreatedBy = "username";
            UpdateDate = DateTime.Now;
            UpdatedBy = "username";
        }
        public string Value { get; set; }
        public long? ComponentId { get; set; }
        [ForeignKey("ComponentId")]
        public Component Component { get; set; }
        public long? ParameterId { get; set; }
        [ForeignKey("ParameterId")]
        public Parameter Parameter { get; set; }
    }
}

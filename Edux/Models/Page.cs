using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Models
{
    public class Page : BaseEntity
    {
        public Page() : base()
        {
            IsPublished = true;
            ViewCount = 0;
            ChildPages = new HashSet<Page>();
            CreateDate = DateTime.Now;
            CreatedBy = "username";
            UpdateDate = DateTime.Now;
            UpdatedBy = "username";
        }
        [StringLength(200)]
        public string Title { get; set; }
        [StringLength(200)]
        public string Slug { get; set; }
        [StringLength(200)]
        public string View { get; set; }
        [StringLength(200)]
        public string LayoutView { get; set; }
        public virtual ICollection<PageComponent> PageComponents { get; set; }
        public long? ParentPageId { get; set; }
        [ForeignKey("ParentPageId")]
        public Page ParentPage { get; set; }
        public virtual ICollection<Page> ChildPages { get; set; }

        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }

        public bool IsPublished { get; set; }
        public long ViewCount { get; set; }
        public long Position { get; set; }
        public string AllowedRoles { get; set; }
    }
}

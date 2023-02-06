using StiGovKg.Domain.Common;
using StiGovKg.Domain.Enums;
using System;
using System.Collections.Generic;

namespace StiGovKg.Domain.Entities
{
    public class Theme : BaseEntity
    {
        public Theme()
        {
            Documents = new List<Document>();
        }

        public string Title { get; set; }
        public string TitleRu { get; set; }
        public string TitleKg { get; set; }
        public string TitleEn { get; set; }

        public Guid SubsectionId { get; set; }

        public Subsection Subsection { get; set; }

        public bool IsAdditionalFile { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsPost { get; set; }
        public bool IsBreakdownByYear { get; set; }
        public bool IsLeadership { get; set; }
        public bool IsUrl { get; set; }
        
        public ContentType ContentType { get; set; }

        public virtual IList<Document> Documents { get; set; }
        public int ThemeOrder { get; set; } 
        public string ThemeIcon { get;set; }
    }
}
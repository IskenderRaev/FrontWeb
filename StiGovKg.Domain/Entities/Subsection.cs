using StiGovKg.Domain.Common;
using StiGovKg.Domain.Enums;
using System;
using System.Collections.Generic;

namespace StiGovKg.Domain.Entities
{
    public class Subsection : BaseEntity
    {
        public Subsection()
        {
            Themes = new List<Theme>();
        }

        public string Title { get; set; }
        public string TitleRu { get; set; }
        public string TitleKg { get; set; }
        public string TitleEn { get; set; }
        public SectionType SectionType { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? ParentId { get; set; }
        public Subsection Parent { get; set; }
        public IList<Theme> Themes { get; set; }
        public int SubsectionOrder { get; set; }
    }
}
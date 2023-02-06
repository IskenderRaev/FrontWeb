using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Application.MediatR.Subsections.Queries.GetSearchItem
{
    public class FoundDocumentsEntity
    {
        public Guid Id { get; set; }
        public Guid ThemeId { get; set; }
        public Guid SubsectionId { get; set; }
        public string HeaderRu { get; set; }
        public string HeaderKG { get; set; }
        public string HeaderEn { get; set; }
        public string ShortDescriptionRu { get; set; }
        public string ShortDescriptionKG { get; set; }
        public string ShortDescriptionEn { get; set; }
        public string HtmlStringRu { get; set; }
        public string HtmlStringKg { get; set; }
        public string HtmlStringEn { get; set; }
        public int SearchedType { get; set; }
    }
}

using StiGovKg.Domain.Common;
using StiGovKg.Domain.Enums;
using System;
using System.Collections.Generic;

namespace StiGovKg.Domain.Entities
{
    public class Document : BaseEntity
    {
        public string ImagePath { get; set; }
        public string HeaderKG { get; set; }
        public string ShortDescriptionKG { get; set; }
        public string LongDescriptionKG { get; set; }
        public string HeaderRu { get; set; }
        public string ShortDescriptionRu { get; set; }
        public string LongDescriptionRu { get; set; }
        public string HeaderEn { get; set; }
        public string ShortDescriptionEn { get; set; }
        public string LongDescriptionEn { get; set; }
        public string DocNumber { get; set; }
        public DateTime? DocDate { get; set; }
        public string DocNumberRu { get; set; }
        public string DocNumberKg { get; set; }
        public string DocNumberEn { get; set; }
        public string DocDescription { get; set; }
        public string HtmlStringRu { get; set; }
        public string HtmlStringKg { get; set; }
        public string HtmlStringEn { get; set; }
        public string FileUriRu { get; set; }
        public string FileUriKg { get; set; }
        public string FileUriEn { get; set; }
        public string AdditionalFileUriRu { get; set; }
        public string AdditionalFileUriKg { get; set; }
        public string AdditionalFileUriEn { get; set; }
        public string Url { get; set; }
        public Leadership Leadership { get; set; }
        public Guid ThemeId { get; set; }
        public Theme Theme { get; set; }
        public int DocumentOrder { get; set; }
        public string FileIcon { get; set; }
        public string AdditionalFileIcon { get; set; }
        public string UrlIcon { get; set; }
    }
}
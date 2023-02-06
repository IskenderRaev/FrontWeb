using StiGovKg.Domain.Common;
using System;
using System.Collections.Generic;

namespace StiGovKg.Domain.Entities
{
    public class News : AuditableEntity
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get;set; }
        public string HeaderKg { get; set; }
        public string ShortDescriptionKg { get; set; }
        public string LongDescriptionKg { get; set; }
        public string HeaderRu { get; set; }
        public string ShortDescriptionRu { get; set; }
        public string LongDescriptionRu { get; set; }
        public string HeaderEn { get; set; }
        public string ShortDescriptionEn { get; set; }
        public string LongDescriptionEn { get; set; }
        public bool IsActual { get; set; }
        public DateTimeOffset PublishDate { get; set; }
        public IList<NewsSliderImage> SliderImage { get; set; }
        public IList<NewsImages> Images { get; set; }
        public News()
        {
            SliderImage = new List<NewsSliderImage>();
            Images = new List<NewsImages>();
        }
    }
}
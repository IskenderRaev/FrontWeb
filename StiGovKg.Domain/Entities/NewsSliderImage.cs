using StiGovKg.Domain.Common;
using System;

namespace StiGovKg.Domain.Entities
{
    public class NewsSliderImage : BaseEntity
    {
        public string ImagePath { get; set; }
        public Guid NewsId { get; set; }
        public News News { get; set; }
    }
}
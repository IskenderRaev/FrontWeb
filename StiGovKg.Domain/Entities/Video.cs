using StiGovKg.Domain.Common;
using System;

namespace StiGovKg.Domain.Entities
{
    public class Video : AuditableEntity
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string ImagePath { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
using StiGovKg.Domain.Common;
using System;

namespace StiGovKg.Domain.Entities
{
    public class Banner : AuditableEntity
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string ImagePath { get; set; }
        public DateTimeOffset PublishDate { get; set; }
    }
}
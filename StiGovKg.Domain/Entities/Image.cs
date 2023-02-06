using StiGovKg.Domain.Common;
using System;

namespace StiGovKg.Domain.Entities
{
    public class Image : AuditableEntity
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public Guid GalleryId { get; set; }
        public Gallery Gallery { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
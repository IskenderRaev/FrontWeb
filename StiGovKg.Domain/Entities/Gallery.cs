using StiGovKg.Domain.Common;
using System;
using System.Collections.Generic;

namespace StiGovKg.Domain.Entities
{
    public class Gallery : AuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public IList<Image> Images { get; set; }

        public Gallery()
        {
            Images = new List<Image>();
        }
    }
}
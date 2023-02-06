using StiGovKg.Domain.Common;

namespace StiGovKg.Domain.Entities
{
    public class DictPartner : AuditableEntity
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Url { get; set; }
    }
}
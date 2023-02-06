using StiGovKg.Domain.Common;

namespace StiGovKg.Domain.Entities
{
    public class PressRelease : AuditableEntity
    {
        public string Text { get; set; }
        public string Description { get; set; }
        public string DocumentPath { get; set; }
    }
}
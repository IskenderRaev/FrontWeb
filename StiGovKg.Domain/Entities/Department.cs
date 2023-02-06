using StiGovKg.Domain.Common;
using System;

namespace StiGovKg.Domain.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid RegionId { get; set; }
        public DictRegion DictRegion { get; set; }
    }
}
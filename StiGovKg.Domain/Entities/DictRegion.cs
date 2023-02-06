using StiGovKg.Domain.Common;
using System.Collections.Generic;

namespace StiGovKg.Domain.Entities
{
    public class DictRegion : BaseEntity
    {
        public string Name { get; set; }
        public IList<Department> Departments { get; set; }

        public DictRegion()
        {
            Departments = new List<Department>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Domain.Entities
{
    public partial class Language
    {
        public Language()
        {
            StringResources = new HashSet<StringResource>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Culture { get; set; }

        public virtual ICollection<StringResource> StringResources { get; set; }
    }
}

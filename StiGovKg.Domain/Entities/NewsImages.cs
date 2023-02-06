using StiGovKg.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Domain.Entities
{
    public class NewsImages : BaseEntity
    {
        public string ImagePath { get; set; }
        public Guid NewsId { get; set; }
        public News News { get; set; }
    }
}

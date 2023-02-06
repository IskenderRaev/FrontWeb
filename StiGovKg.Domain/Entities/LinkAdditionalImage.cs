using StiGovKg.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Domain.Entities
{
    public class LinkAdditionalImage : BaseEntity
    {
        public string ImagePath { get; set; }
        public Guid LinkId { get; set; }
        public Link Link { get; set; }
    }
}

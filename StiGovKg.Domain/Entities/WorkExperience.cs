using StiGovKg.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Domain.Entities
{
    public  class WorkExperience : BaseEntity
    {
        public Guid LeadershipId { get; set; }
        public Leadership Leadership { get; set; }
        public string YearEntryExit { get; set; } 
        public string CompanyNameRu { get; set; }
        public string CompanyNameKg { get; set; }
        public string CompanyNameEn { get; set; }
        public string PositionRu { get; set; }
        public string PositionKg { get; set; }
        public string PositionEn { get; set; }
        public int WorkExperienceOrder { get; set; }

    }
}

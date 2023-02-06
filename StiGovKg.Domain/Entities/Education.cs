using StiGovKg.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Domain.Entities
{
    public  class Education : BaseEntity
    {
        public Guid LeadershipId { get; set; }
        public Leadership Leadership { get; set; }
        public string EducationTypeRu { get; set; }
        public string EducationTypeKg { get; set; }
        public string EducationTypeEn { get; set; }
        public string UniversityNameRu { get; set; }
        public string UniversityNameKg { get; set; }
        public string UniversityNameEn { get; set; }
        public string SpecialityRu { get; set; }
        public string SpecialityKg { get; set; }
        public string SpecialityEn { get; set; }

    }
}

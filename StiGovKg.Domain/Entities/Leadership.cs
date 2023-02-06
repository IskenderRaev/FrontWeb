using StiGovKg.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Domain.Entities
{
    public class Leadership : BaseEntity
    {
        public string FullNameRu { get; set; }
        public string FullNameKg { get; set; }
        public string FullNameEn { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlaceRu {get;set; }
        public string BirthPlaceKg { get; set; }
        public string BirthPlaceEn { get; set; }
        public string PositionRu { get; set; }
        public string PositionKg { get; set; }
        public string PositionEn { get; set; }
        public string RankInSpecialityRu { get; set; }
        public string RankInSpecialityKg { get; set; }
        public string RankInSpecialityEn { get; set; }
        public string Email { get; set; }
        public string TimeOfReceiptRu { get; set; }
        public string TimeOfReceiptKg { get; set; }
        public string TimeOfReceiptEn { get; set; }
        public Guid DocumentId { get; set; }
        public Document Document { get; set; }
        public List<Education> Education { get; set; }
        public List<WorkExperience> WorkExperiences { get; set; }

    }
}

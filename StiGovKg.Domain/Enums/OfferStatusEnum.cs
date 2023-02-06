using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StiGovKg.Domain.Enums
{
    public enum OfferStatusEnum
    {
        [Display(Name = "Не рассмотрен")]
        NotReviewed,
        [Display(Name = "Рассмотрен")]
        Reviewed,
    }
}

using StiGovKg.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Domain.Entities
{
    public class Offer
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public OfferStatusEnum OfferStatusEnum { get; set; }
    }
}

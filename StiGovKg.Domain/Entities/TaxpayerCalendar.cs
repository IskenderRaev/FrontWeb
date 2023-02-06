using StiGovKg.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Domain.Entities
{
    public class TaxpayerCalendar
    {
        public Guid Id { get; set; }
        public string CalendarPath { get; set; }
        public LanguageType LanguageType { get; set; }
        public int CalendarDate { get; set; }

    }
}

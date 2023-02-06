using StiGovKg.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Domain.Entities
{
    public class Notifications : AuditableEntity
    {
        public string Title { get; set; }
        public string TitleRu { get; set; }
        public string TitleKg { get; set; }
        public string TitleEn { get; set; }
        public DateTimeOffset NotificationDate { get; set; }
    }
}

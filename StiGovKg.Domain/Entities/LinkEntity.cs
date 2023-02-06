using StiGovKg.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Domain.Entities
{
    public class LinkEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string TitleRu { get; set; }
        public string TitleKg { get; set; }
        public string TitleEn { get; set; }
        public string LinkSource { get; set; }
        public LinkType LinkType { get; set; }
        public string MainImagePath { get; set; }
        public string AdditionalImagePath { get; set; }
    }
}

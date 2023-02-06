using StiGovKg.Domain.Common;
using StiGovKg.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Domain.Entities
{
    public class Link : AuditableEntity
    {
        public string ImagePath { get; set; }
        public string Title { get; set; }
        public string TitleRu { get; set; }
        public string TitleKg { get; set; }
        public string TitleEn { get; set; }
        public string LinkSource { get; set; }
        public LinkType LinkType { get; set; }
        public LinkMainImage LinkMainImage { get; set; }
        public LinkAdditionalImage LinkAdditionalImage { get; set; }
        public Link()
        {
            LinkMainImage = new LinkMainImage();
            LinkAdditionalImage = new LinkAdditionalImage();
        }
    }
}

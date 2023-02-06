using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StiGovKg.Domain.Enums
{
    public enum LinkType
    {
        [Display(Name = "Полезные ссылки")]
        Useful = 1,

        [Display(Name = "Другие ссылки")]
        Others = 2,
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Domain.Enums
{
    public enum Estimation
    {
        [Description("Не выбрано")]
        NotChosen,
        [Description("Отлично")]
        Excellent,
        [Description("Хорошо")]
        Good,
        [Description("Удовлетворительно")]
        Satisfactory,
        [Description("Неудовлетворительно")]
        Unsatisfactory,
        [Description("Компетентен")]
        Competent,
        [Description("Некомпетентен")]
        Incompetent,
        [Description("Комфортно")]
        Comfortable,
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Domain.Enums
{
    public enum WaitingTime
    {
        [Description("Не выбрано")]
        NotChosen,
        [Description("Очереди не было")]
        NoQueue,
        [Description("До 15 минут")]
        UpTo15Min,
        [Description("Более 25 минут")]
        MoreThan25,
        [Description("Менее 2 минут")]
        LessThan2Min,
        [Description("Более 7 минут")]
        MoreThan7Min,
        [Description("Не дозвонился")]
        DidntAnswer,
    }
}

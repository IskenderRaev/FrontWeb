using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Domain.Enums
{
    public enum WayOfAddress
    {
        [Description("Не выбрано")]
        NotChosen,
        [Description("Лично в территориальный УГНС")]
        PersonallyToUGNS,
        [Description("Через электронные сервисы ГНС")]
        ThroughTheElectronicServices,
        [Description("По телефону в территориальный УГНС или в Call-центр")]
        ByPhoneToUGNS,
    }
}

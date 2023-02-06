using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Domain.Enums
{
    public enum Answer
    {
        [Description("Не выбрано")]
        NotChosen,
        [Description("Да")]
        Yes,
        [Description("Нет")]
        No,    
        [Description("Услуга предоставлена в срок")]
        ServiceProvidedOnTime,
        [Description("Услуга предоставлена с нарушением срока")]
        ServiceDontProvidedOnTime,                 
        [Description("Личный кабинет налогоплательщика")]
        TaxpayerPersonalAccount,
        [Description("Официальный сайт ГНС")]
        OfficalWebSiteSTI,
        [Description("Электронный патент")]
        ElectronicPatent,
        [Description("Электронная счет-фактура")]
        ElectronicInvoice,
        [Description("Электронная товарно-транспортная накладная")]
        ElectronicBillOfLading,
        [Description("Расчет налога на имущество")]
        CalculationOfPropertyTax,
        [Description("Помощник по заполнению формы STI-161")]
        AssistantFormSTI161
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StiGovKg.Domain.Enums
{
    public enum Service
    {
        [Description("Не выбрано")]
        NotChosen,
        [Description("Налоговая и/или учетная регистрация")]
        TaxOrAccountingRegistration,
        [Description("для открытия расчетного счета")]
        OpenCurrentAccount,
        [Description("для целей импорта товаров из государств членов ЕАЭС")]
        ImportingGoodsFromTheEAEU,
        [Description("о неимении задолженности")]
        AboutNotDebt,
        [Description("Получение патента или электронного патента")]
        GettingPatent,
        [Description("Сдача налоговой отчетности, деклараций и расчетов")]
        SubmissionTax

    }
}

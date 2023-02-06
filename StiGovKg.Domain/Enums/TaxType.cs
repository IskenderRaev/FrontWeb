using System.ComponentModel.DataAnnotations;

namespace StiGovKg.Domain.Enums
{
    /// <summary>Тип налогового режима</summary>
    public enum TaxType
    {
        /// <summary>Налоги уплачиваемые физическим лицом</summary>
        [Display(Name = "Налоги уплачиваемые физическим лицом")]
        Individual = 0,

        /// <summary>Общий налоговый режим</summary>
        [Display(Name = "Общий налоговый режим")]
        General = 1,

        /// <summary>Специальный налоговый режим</summary>
        [Display(Name = "Специальный налоговый режим")]
        Special = 2,

        /// <summary>Налоговый контроль</summary>
        [Display(Name = "Налоговый контроль")]
        TaxControl = 3,

        /// <summary>Нормативно правовые акты</summary>
        [Display(Name = "Нормативно правовые акты")]
        Regulations = 4,
    }
}
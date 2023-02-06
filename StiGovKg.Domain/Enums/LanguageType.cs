using System.ComponentModel.DataAnnotations;

namespace StiGovKg.Domain.Enums
{
    public enum LanguageType
    {
        [Display(Name = "Кыргызский язык")]
        KG = 0,

        [Display(Name = "Русский язык")]
        RU = 1,

        [Display(Name = "Английский")]
        EN = 2,
    }
}
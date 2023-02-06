using System.ComponentModel.DataAnnotations;

namespace StiGovKg.Domain.Enums
{
    public enum SectionType
    {
        [Display(Name = "Навигационная панель")]
        Nav = 0,

        [Display(Name = "Боковое меню")]
        LeftNav = 1,

        [Display(Name = "Типы лиц на Главной странице")]
        TypeOfPerson = 2,
    }
}
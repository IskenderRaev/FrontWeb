using System.ComponentModel.DataAnnotations;

namespace StiGovKg.Domain.Enums
{
    public enum DocumentType
    {
        [Display(Name = "Руководство")]
        Leadership = 0,

        [Display(Name = "Файл")]
        File = 1,

        [Display(Name = "Видео")]
        Video = 2,

        [Display(Name = "Изображение")]
        Image = 3,

    }
}
using System.ComponentModel.DataAnnotations;

namespace StiGovKg.Domain.Enums
{
    public enum ContentType
    {
        [Display(Name = "Новости")]
        News = 0,

        [Display(Name = "Статья")]
        Post = 1,

        [Display(Name = "Ссылка")]
        Link = 2,

        [Display(Name = "Руководство")]
        Bio = 3,

        [Display(Name = "Файл")]
        File = 4
    }
}
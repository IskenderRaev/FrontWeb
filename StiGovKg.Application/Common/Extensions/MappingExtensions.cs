using Shared.Core.Extensions;
using StiGovKg.Application.Common.Constants;
using StiGovKg.Application.MediatR.Calendar.Queries.GetCalendar;
using StiGovKg.Application.MediatR.Departments.Queries;
using StiGovKg.Application.MediatR.DictRegions.Queries;
using StiGovKg.Application.MediatR.Documents.Queries;
using StiGovKg.Application.MediatR.Galleries.Queries;
using StiGovKg.Application.MediatR.Images.Queries;
using StiGovKg.Application.MediatR.Links.Queries;
using StiGovKg.Application.MediatR.News.Queries;
using StiGovKg.Application.MediatR.Notification.Queries;
using StiGovKg.Application.MediatR.PressReleases.Queries.GetPressReleases;
using StiGovKg.Application.MediatR.Subsections.Queries.GetSearchItem;
using StiGovKg.Application.MediatR.Subsections.Queries.GetSubsections;
using StiGovKg.Application.MediatR.Themes.Queries;
using StiGovKg.Application.MediatR.Videos.Queries.GetVideos;
using StiGovKg.Domain.Entities;

namespace StiGovKg.Application.Common.Extensions
{
    public static class MappingExtensions
    {
        public static NewsDto AsDto(this News news)
        {
            return new NewsDto(
                news.Id, news.HeaderRu, news.HeaderKg, news.HeaderEn, news.ShortDescriptionRu, news.ShortDescriptionKg, news.ShortDescriptionEn, news.LongDescriptionRu, news.LongDescriptionKg, news.LongDescriptionEn, news.PublishDate, news.IsActual
             );
        }

        public static NewsCommandDto AsDto(this News news, string cultureName)
        {
            return new NewsCommandDto(
              news.Id,
              Title: cultureName == WebStiLanguages.English ? news.HeaderEn : cultureName == WebStiLanguages.Kyrgyz ? news.HeaderKg : news.HeaderRu,
              ShortDescription: cultureName == WebStiLanguages.English ? news.ShortDescriptionEn : cultureName == WebStiLanguages.Kyrgyz ? news.ShortDescriptionKg : news.ShortDescriptionRu,
              LongDescription: cultureName == WebStiLanguages.English ? news.LongDescriptionEn : cultureName == WebStiLanguages.Kyrgyz ? news.LongDescriptionKg : news.LongDescriptionRu,
              news.PublishDate,
              news.IsActual
           );
        }
        public static ActualNewsCommandDto AsDto(this ActualNewsDto news, string cultureName)
        {
            return new ActualNewsCommandDto(
               news.Id,
               Title: cultureName == WebStiLanguages.English ? news.HeaderEn : cultureName == WebStiLanguages.Kyrgyz ? news.HeaderKg : news.HeaderRu,
               ShortDescription: cultureName == WebStiLanguages.English ? news.ShortDescriptionEn : cultureName == WebStiLanguages.Kyrgyz ? news.ShortDescriptionKg : news.ShortDescriptionRu,
               LongDescription: cultureName == WebStiLanguages.English ? news.LongDescriptionEn : cultureName == WebStiLanguages.Kyrgyz ? news.LongDescriptionKg : news.LongDescriptionRu,
               news.PublishDate, 
               news.IsActual,
               news.ImagePath
            );
        }

        public static DepartmentDto AsDto(this Department department)
        {
            return new DepartmentDto(
                department.Id, department.Name, department.Email, department.DictRegion.Id, department.DictRegion.Name
             );
        }

        public static DictRegionWithDepartmentsDto AsRegionWithDepartments(this DictRegion dictRegion)
        {
            return new DictRegionWithDepartmentsDto(
                dictRegion.Id, dictRegion.Name, dictRegion.Departments
                                               .Select(p => new DepartmentDto(p.Id, p.Name, p.Email, dictRegion.Id, dictRegion.Name)).ToList()
             );
        }

        public static SubsectionDto AsDto(this Subsection entity, string cultureName)
        {
            return new SubsectionDto(
                entity.Id, 
                Title: cultureName == WebStiLanguages.English ? entity.TitleEn: cultureName == WebStiLanguages.Kyrgyz ? entity.TitleKg : entity.Title, 
                entity.SectionType, 
                entity.SectionType.GetDisplayValue(), 
                ParentId: entity.Parent != null? entity.ParentId.ToString(): "", 
                ParentName: entity.Parent != null ? entity.Parent.Title.ToString() : "",
                entity.SubsectionOrder);
        }

        public static SubsectionCommandDto AsDto(this Subsection entity)
        {
            return new SubsectionCommandDto(
                entity.Id,
                entity.TitleKg,
                entity.TitleRu,
                entity.TitleEn,
                entity.SectionType,
                entity.SectionType.GetDisplayValue(),
                ParentId: entity.Parent != null ? entity.ParentId.ToString() : "",
                ParentName: entity.Parent != null ? entity.Parent.Title.ToString() : "");
        }

        public static ThemeDto AsDto(this Theme entity, string cultureName)
        {
            return new ThemeDto(
                entity.Id,
                Title: cultureName == WebStiLanguages.English ? entity.TitleEn : cultureName == WebStiLanguages.Kyrgyz ? entity.TitleKg : entity.Title,
                entity.SubsectionId,
                entity.Subsection?.Title,
                entity.IsAdditionalFile,
                entity.IsBreakdownByYear,
                entity.IsUrl,
                entity.Subsection.SectionType,
                entity.IsPost,
                entity.IsLeadership,
                entity.ThemeOrder,
                entity.ThemeIcon);
        }

        public static ThemeCommandDto AsDto(this Theme entity)
        {
            return new ThemeCommandDto(entity.Id, entity.TitleKg, entity.TitleRu, entity.TitleEn, entity.SubsectionId, entity.Subsection?.Title, entity.IsAdditionalFile, entity.IsBreakdownByYear, entity.IsUrl, entity.Subsection.SectionType, entity.IsPost, entity.IsLeadership, entity.ThemeIcon);
        }
        public static DocumentDto AsDto(this Document entity, string cultureName)
        {
            return new DocumentDto(
            entity.Id,
            Title: cultureName == WebStiLanguages.English ? entity.HeaderEn : cultureName == WebStiLanguages.Kyrgyz ? entity.HeaderKG : entity.HeaderRu,
            DocNumber: cultureName == WebStiLanguages.English ? entity.DocNumberEn : cultureName == WebStiLanguages.Kyrgyz ? entity.DocNumberKg : entity.DocNumberRu,
            entity.DocDate?.ToString("dd MMMM yyyy"), 
            FileUri: cultureName == WebStiLanguages.English ? entity.FileUriEn : cultureName == WebStiLanguages.Kyrgyz ? entity.FileUriKg : entity.FileUriRu,
            AdditionalFileUri: cultureName == WebStiLanguages.English ? entity.AdditionalFileUriEn : cultureName == WebStiLanguages.Kyrgyz ? entity.AdditionalFileUriKg : entity.AdditionalFileUriRu,
            entity.ThemeId, entity.Theme?.Title, entity.Theme.IsAdditionalFile, entity.Url,
            HtmlString: cultureName == WebStiLanguages.English ? entity.HtmlStringEn : cultureName == WebStiLanguages.Kyrgyz ? entity.HtmlStringKg : entity.HtmlStringRu,
            entity.DocumentOrder, Leadership: entity.Leadership != null ? entity.Leadership.AsDto(cultureName): null, entity.FileIcon, entity.AdditionalFileIcon, entity.UrlIcon);
        }
        
        public static LeadershipDto AsDto(this Leadership entity, string cultureName) => new LeadershipDto(
            FullName: cultureName == WebStiLanguages.English ? entity.FullNameEn : cultureName == WebStiLanguages.Kyrgyz ? entity.FullNameKg : entity.FullNameRu,
            entity.BirthDate,
            BirthPlace: cultureName == WebStiLanguages.English ? entity.BirthPlaceEn : cultureName == WebStiLanguages.Kyrgyz ? entity.BirthPlaceKg : entity.BirthPlaceRu,
            Position: cultureName == WebStiLanguages.English ? entity.PositionEn : cultureName == WebStiLanguages.Kyrgyz ? entity.PositionKg : entity.PositionRu,
            RankInSpeciality: cultureName == WebStiLanguages.English ? entity.RankInSpecialityEn : cultureName == WebStiLanguages.Kyrgyz ? entity.RankInSpecialityKg : entity.RankInSpecialityRu,
            entity.Email,
            TimeOfReceipt: cultureName == WebStiLanguages.English ? entity.TimeOfReceiptEn : cultureName == WebStiLanguages.Kyrgyz ? entity.TimeOfReceiptKg : entity.TimeOfReceiptRu,
            DocumentId: entity.DocumentId,
            entity.Education,
            entity.WorkExperiences);

        public static ImageDto AsDto(this Image image)
        {
            return new ImageDto(
                image.Id, image.Title, image.ImagePath, image.Gallery, image.PublishDate
             );
        }

        public static GalleryDto AsDto(this Gallery gallery)
        {
            return new GalleryDto(
                gallery.Id, gallery.Title, gallery.Description, gallery.PublishDate, gallery.Images
                                                                                    .Select(p => new ImageDto(p.Id, p.Title, p.ImagePath, p.Gallery, p.PublishDate)).ToList()
                );
        }

        public static VideoDto AsDto(this Video video)
        {
            return new VideoDto(
                video.Id, video.Title, video.Link, video.PublishDate, video.ImagePath
                );
        }

        public static PressReleaseDto AsDto(this PressRelease news)
        {
            return new PressReleaseDto(
                news.Id, news.Text, news.Description, news.DocumentPath
             );
        }
        public static NotificationCommandDto AsDto(this Notifications notifications, string cultureName)
        {
            return new NotificationCommandDto(
                notifications.Id,
                Title: cultureName == WebStiLanguages.English ? notifications.TitleEn : cultureName == WebStiLanguages.Kyrgyz ? notifications.TitleKg : notifications.TitleRu,
                notifications.NotificationDate
             );
        }
        public static LinkCommandDto AsDto(this LinkEntity link, string cultureName)
        {
            return new LinkCommandDto(
            link.Id,
            Title: cultureName == WebStiLanguages.English ? link.TitleEn : cultureName == WebStiLanguages.Kyrgyz ? link.TitleKg : link.TitleRu,
            link.LinkSource,
            link.LinkType,
            link.MainImagePath,
            link.AdditionalImagePath
             );
        }
        public static FoundDocumentsDto AsDto(this FoundDocumentsEntity document, string cultureName)
        {
            return new FoundDocumentsDto(
            document.Id,
            document.ThemeId,
            document.SubsectionId,
            Header: cultureName == WebStiLanguages.English ? document.HeaderEn : cultureName == WebStiLanguages.Kyrgyz ? document.HeaderKG : document.HeaderRu,
            ShortDescription: cultureName == WebStiLanguages.English ? document.ShortDescriptionEn : cultureName == WebStiLanguages.Kyrgyz ? document.ShortDescriptionKG : document.ShortDescriptionRu,
            HtmlString: cultureName == WebStiLanguages.English ? document.HtmlStringEn : cultureName == WebStiLanguages.Kyrgyz ? document.HtmlStringKg : document.HtmlStringRu,
            document.SearchedType
             );
        }
        public static CalendarDto AsDto(this TaxpayerCalendar document)
        {
            return new CalendarDto(
                document.Id,
                document.CalendarPath,
                document.LanguageType,
                document.CalendarDate
                );
        }

    }
}
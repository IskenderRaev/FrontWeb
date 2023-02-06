
namespace StiGovKg.Application.MediatR.Documents.Queries
{
    public record DocumentDto(
        Guid Id,
        string Title,
        string DocNumber,
        string DocDate,
        string FileUri,
        string AdditionalFileUri,
        Guid ThemeId,
        string ThemeName,
        bool isAdditionalFile,
        string Url,
        string HtmlString,
        int DocumentOrder,
        LeadershipDto Leadership,
        string FileIcon,
        string AdditionalFileIcon,
        string UrlIcon);
}


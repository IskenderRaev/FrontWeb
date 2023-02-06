using StiGovKg.Domain.Enums;
using System;

namespace StiGovKg.Application.MediatR.Themes.Queries
{
    public record ThemeCommandDto(Guid Id, string TitleKg, string TitleRu, string TitleEn, Guid SubsectionId, string SubsectionName, bool IsAdditionalFile, bool IsBreakdownByYear, bool IsUrl, SectionType SectionType, bool IsPost, bool IsLeadership, string ThemeIcon);
}
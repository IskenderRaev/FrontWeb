using StiGovKg.Domain.Enums;
using System;

namespace StiGovKg.Application.MediatR.Themes.Queries
{
    public record ThemeDto(Guid Id, string Title, Guid SubsectionId, string SubsectionName, bool IsAdditionalFile, bool IsBreakdownByYear, bool IsUrl, SectionType SectionType, bool IsPost, bool IsLeadership, int ThemeOrder, string ThemeIcon);
}
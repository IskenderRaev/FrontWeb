using StiGovKg.Domain.Enums;
using System;

namespace StiGovKg.Application.MediatR.Subsections.Queries.GetSubsections
{
    public record SubsectionCommandDto(Guid Id, string TitleKg, string TitleRu, string TitleEn, SectionType SectionType, string SectionName, string ParentId, string ParentName);
}
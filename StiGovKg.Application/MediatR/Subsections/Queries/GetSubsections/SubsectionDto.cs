using StiGovKg.Domain.Enums;
using System;

namespace StiGovKg.Application.MediatR.Subsections.Queries.GetSubsections
{
    public record SubsectionDto(Guid Id, string Title, SectionType SectionType, string SectionName, string ParentId, string ParentName, int SubsectionOrder);
}
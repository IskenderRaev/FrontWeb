using System;

namespace StiGovKg.Application.MediatR.PressReleases.Queries.GetPressReleases
{
    public record PressReleaseDto(
     Guid Id, string Text, string Description, string DocumentPath
 );
}
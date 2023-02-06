using StiGovKg.Domain.Enums;

namespace StiGovKg.Application.MediatR.Links.Queries
{
    public record LinkCommandDto(Guid Id, string Title, string LinkSource, LinkType linkType, string MainImagePath, string AdditionalImagePath);
}

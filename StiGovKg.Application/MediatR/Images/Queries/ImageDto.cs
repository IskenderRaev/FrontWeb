using System;
using StiGovKg.Domain.Entities;

namespace StiGovKg.Application.MediatR.Images.Queries
{
    public record ImageDto(Guid Id, string Title, string ImagePath, Gallery Gallery, DateTime PublishDate);
}
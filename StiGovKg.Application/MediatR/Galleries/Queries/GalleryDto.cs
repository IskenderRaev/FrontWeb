using StiGovKg.Application.MediatR.Images.Queries;
using System;
using System.Collections.Generic;

namespace StiGovKg.Application.MediatR.Galleries.Queries
{
    public record GalleryDto(Guid Id, string Title, string Description, DateTime PublishDate, IList<ImageDto> Images);
}

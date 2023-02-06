using System;

namespace StiGovKg.Application.MediatR.Videos.Queries.GetVideos
{
    public record VideoDto(Guid Id, string Title, string Link, DateTime PublishDate, string ImagePath);
}
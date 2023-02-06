using System;

namespace StiGovKg.Application.MediatR.Banners.Queries.GetBanners
{
    public record BannerDto(Guid Id, string Title, string Link, string ImagePath, DateTimeOffset PublishDate);
}
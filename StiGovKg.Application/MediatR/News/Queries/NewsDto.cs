using System;
using System.Collections.Generic;

namespace StiGovKg.Application.MediatR.News.Queries
{
    public record NewsDto(
        Guid Id, string HeaderRu, string HeaderKg, string HeaderEn, string ShortDescriptionRu, string ShortDescriptionKg, string ShortDescriptionEn,
        string LongDescriptionRu, string LongDescriptionKg, string LongDescriptionEn, DateTimeOffset PublishDate, bool IsActual
    )
    {
        public List<string> ImagePaths { get; set; } = new();
    };
}
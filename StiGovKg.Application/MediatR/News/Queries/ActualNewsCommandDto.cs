using System;
using System.Collections.Generic;

namespace StiGovKg.Application.MediatR.News.Queries
{
    public record ActualNewsCommandDto(
        Guid Id,
        string Title,
        string ShortDescription,
        string LongDescription,
        DateTimeOffset PublishDate,
        bool IsActual,
        string ImagePath
    );
}
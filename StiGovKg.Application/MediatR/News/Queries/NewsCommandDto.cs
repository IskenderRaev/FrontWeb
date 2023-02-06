namespace StiGovKg.Application.MediatR.News.Queries
{
    public record NewsCommandDto(
       Guid Id,
       string Title,
       string ShortDescription,
       string LongDescription,
       DateTimeOffset PublishDate,
       bool IsActual
   )
    {
        public List<string> ImagePaths { get; internal set; }
    }
}

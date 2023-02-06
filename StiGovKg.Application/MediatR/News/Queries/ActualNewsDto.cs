namespace StiGovKg.Application.MediatR.News.Queries
{
    public record ActualNewsDto
    {
        public Guid Id { get; set; }
        public string HeaderKg { get; set; }
        public string HeaderRu { get; set; }
        public string HeaderEn { get; set; }

        public string ShortDescriptionKg { get; set; }
        public string ShortDescriptionRu { get; set; }
        public string ShortDescriptionEn { get; set; }

        public string LongDescriptionKg { get; set; }
        public string LongDescriptionRu { get; set; }
        public string LongDescriptionEn { get; set; }

        public DateTimeOffset PublishDate { get; set; }
        public bool IsActual { get; set; }
        public string ImagePath { get; set; }
    }
}

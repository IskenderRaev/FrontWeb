using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using P.Pager;
using System.ComponentModel.DataAnnotations;

namespace StiGovKg.Application.MediatR.News.Queries
{
    public enum NewsState
    {
        [Display(Name = "Все новости")]
        AllNews = 0,

        [Display(Name = "Новые")]
        LatestNews = 1,

        [Display(Name = "Актуальное")]
        IsActual = 2,

        [Display(Name = "Обновление")]
        UpdatedNews

    }

    public class GetNewsQueryUI : IRequest<IPager<NewsCommandDto>>
    {
        public int Page { get; set; } = 1;
        public string SearchWord { get; set; }
        public DateTime? DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string Date { get; set; }
        public NewsState NewsState { get; set; }
    }

    public class GetNewsQueryUIHandler : IRequestHandler<GetNewsQueryUI, IPager<NewsCommandDto>>
    {
        private readonly IStigovkgDbContext _context;

        public GetNewsQueryUIHandler(IStigovkgDbContext context)
        {
            _context = context;
        }

        public Task<IPager<NewsCommandDto>> Handle(GetNewsQueryUI request, CancellationToken cancellationToken)
        {
            var query = _context.News.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(request.SearchWord))
                query = query.Where(c => EF.Functions.Like(c.HeaderRu.ToUpper(), $"%{request.SearchWord.ToUpper()}%") ||
                                         EF.Functions.Like(c.LongDescriptionRu.ToUpper(), $"%{request.SearchWord.ToUpper()}%"));

            if (request.DateStart.HasValue || request.DateEnd.HasValue)
            {
                query = query.Where(d => (request.DateStart.HasValue ? request.DateStart <= d.PublishDate : true) && (request.DateEnd.HasValue ? request.DateEnd >= d.PublishDate : true));
            }

            if (!string.IsNullOrEmpty(request.Date))
            {
                int year = int.Parse(request.Date);
                query = query.Where(d => d.PublishDate.Date.Year == year);
            }

            switch (request.NewsState)
            {
                case NewsState.AllNews:
                    break;
                case NewsState.IsActual:
                    query = query.Where(p => p.IsActual == true);
                    break;
                case NewsState.LatestNews:
                    query = query.Where(p => p.PublishDate.AddDays(-7).Date <= DateTime.Now.Date);
                    break;
                case NewsState.UpdatedNews:
                    query = query.Where(p => p.LastModified != null);
                    break;
            }

            var culture = System.Globalization.CultureInfo.CurrentCulture;
            return query.OrderByDescending(p => p.PublishDate).Select(x => x.AsDto(culture.Name)).ToPagerListAsync(request.Page, 5, cancellationToken);
        }
    }
}
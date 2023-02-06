using MediatR;
using Microsoft.EntityFrameworkCore;
using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;

namespace StiGovKg.Application.MediatR.News.Queries
{
    public class GetLastNewsUI : IRequest<List<NewsCommandDto>>
    {
        public int Page { get; set; }
    }

    public class GetLastNewsUIQueryHandler : IRequestHandler<GetLastNewsUI, List<NewsCommandDto>>
    {
        private readonly IStigovkgDbContext _context;

        public GetLastNewsUIQueryHandler(IStigovkgDbContext context)
        {
            _context = context;
        }

        public Task<List<NewsCommandDto>> Handle(GetLastNewsUI request, CancellationToken cancellationToken)
        {
            var culture = System.Globalization.CultureInfo.CurrentCulture;
            var query = _context.News.AsNoTracking();
            var items = query.Select(x => x.AsDto(culture.Name)).Take(10).ToList();

            return Task.FromResult(items);

        }
    }
}

using MediatR;
using Microsoft.EntityFrameworkCore;
using P.Pager;
using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;
using System.Globalization;

namespace StiGovKg.Application.MediatR.Documents.Queries
{
    public class GetDocumentsBreakByYearQuery : IRequest<List<DocumentDto>>
    {
        public Guid ThemeId { get; set; }
        public string Title { get; set; }
        public int DocumentYear { get; set; }
    }

    public class GetDocumentsBreakByYearQueryHandler : IRequestHandler<GetDocumentsBreakByYearQuery, List<DocumentDto>>
    {
        private readonly IStigovkgDbContext _context;

        public GetDocumentsBreakByYearQueryHandler(IStigovkgDbContext context)
        {
            _context = context;
        }

        public async Task<List<DocumentDto>> Handle(GetDocumentsBreakByYearQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Documents.Include(x => x.Theme).Where(x => x.ThemeId == request.ThemeId);

            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;

            if (request.DocumentYear != 0)
            {
                query = query.Where(q => q.DocDate.HasValue && q.DocDate.Value.Date.Year == request.DocumentYear);
            }
            var items = await query.Select(x => x.AsDto(currentCulture.Name)).ToListAsync();
            return items;
        }
    }
}

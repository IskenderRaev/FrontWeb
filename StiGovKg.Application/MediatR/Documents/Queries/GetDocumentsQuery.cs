using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using P.Pager;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Globalization;
using StiGovKg.Application.Common.Constants;

namespace StiGovKg.Application.MediatR.Documents.Queries
{
    public class GetDocumentsQuery : IRequest<IPager<DocumentDto>>
    {
        public Guid ThemeId { get; set; }

        public string Title { get; set; }
        public int DocumentYear { get; set; }
        public int Page { get; set; } = 1;
    }

    public class GetDocumentsQueryHandler : IRequestHandler<GetDocumentsQuery, IPager<DocumentDto>>
    {
        private readonly IStigovkgDbContext _context;

        public GetDocumentsQueryHandler(IStigovkgDbContext context)
        {
            _context = context;
        }

        public Task<IPager<DocumentDto>> Handle(GetDocumentsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Documents.Include(x => x.Theme)
                .Include(x => x.Leadership).ThenInclude(x => x.WorkExperiences)
                .Include(x => x.Leadership).ThenInclude(x => x.Education).Where(x => x.ThemeId == request.ThemeId);

            CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;

            if (!string.IsNullOrWhiteSpace(request.Title))
            {
                if (currentCulture.Name == WebStiLanguages.Russian)
                {
                    query = query.Where(c => EF.Functions.Like(c.HeaderRu.ToUpper(), $"%{request.Title.ToUpper()}%")).OrderByDescending(x => x.DocDate);
                }
                if (currentCulture.Name == WebStiLanguages.Kyrgyz)
                {
                    query = query.Where(c => EF.Functions.Like(c.HeaderKG.ToUpper(), $"%{request.Title.ToUpper()}%")).OrderByDescending(x => x.DocDate);
                }
                if (currentCulture.Name == WebStiLanguages.English)
                {
                    query = query.Where(c => EF.Functions.Like(c.HeaderEn.ToUpper(), $"%{request.Title.ToUpper()}%")).OrderByDescending(x => x.DocDate);
                }
            }
            if (request.DocumentYear != 0)
            {
                query = query.Where(q => q.DocDate.HasValue && q.DocDate.Value.Date.Year == request.DocumentYear);
            }

            return query.Select(x => x.AsDto(currentCulture.Name)).ToPagerListAsync(request.Page, 20, cancellationToken);
        }
    }
}
using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using P.Pager;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace StiGovKg.Application.MediatR.Themes.Queries
{
    public class GetThemesQuery : IRequest<IPager<ThemeDto>>
    {
        public Guid SubsectionId { get; set; }

        public string Title { get; set; }

        public int Page { get; set; } = 1;
    }

    public class GetThemesQueryHandler : IRequestHandler<GetThemesQuery, IPager<ThemeDto>>
    {
        private readonly IStigovkgDbContext _context;

        public GetThemesQueryHandler(IStigovkgDbContext context)
        {
            _context = context;
        }

        public Task<IPager<ThemeDto>> Handle(GetThemesQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Themes.Include(x => x.Subsection).Where(x => x.SubsectionId == request.SubsectionId && !x.IsDeleted);

            if (!string.IsNullOrEmpty(request.Title))
            {
                query = query.Where(q => EF.Functions.Like(q.Title.ToUpper(), $"%{request.Title.ToUpper()}%"));
            }

            var culture = System.Globalization.CultureInfo.CurrentCulture;
            return query.Select(x => x.AsDto(culture.Name)).ToPagerListAsync(request.Page, 21, cancellationToken);
        }
    }
}
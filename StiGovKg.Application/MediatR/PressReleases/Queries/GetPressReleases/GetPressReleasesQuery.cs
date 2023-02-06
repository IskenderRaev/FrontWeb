using MediatR;
using Microsoft.EntityFrameworkCore;
using P.Pager;
using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;

namespace StiGovKg.Application.MediatR.PressReleases.Queries.GetPressReleases
{
    public class GetPressReleasesQuery : IRequest<IPager<PressReleaseDto>>
    {
        public int Page { get; set; } = 1;

        public string Description { get; set; }
    }

    public class GetPressReleasesQueryHandler : IRequestHandler<GetPressReleasesQuery, IPager<PressReleaseDto>>
    {
        private readonly IStigovkgDbContext _context;

        public GetPressReleasesQueryHandler(IStigovkgDbContext context)
        {
            _context = context;
        }

        public Task<IPager<PressReleaseDto>> Handle(GetPressReleasesQuery request, CancellationToken cancellationToken)
        {
            var query = _context.PressReleases.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Description))
                query = query.Where(c => c.Description == request.Description);

            return query.Select(x => x.AsDto()).ToPagerListAsync(request.Page, 10, cancellationToken);
        }
    }
}
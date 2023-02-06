using MediatR;
using Microsoft.EntityFrameworkCore;
using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;

namespace StiGovKg.Application.MediatR.PressReleases.Queries.GetPressReleases
{
    public class GetPressReleaseByIdQuery : IRequest<PressReleaseDto>
    {
        public Guid Id { get; set; }
    }

    public class GetPressReleaseByIdQueryHandler : IRequestHandler<GetPressReleaseByIdQuery, PressReleaseDto>
    {
        private readonly IStigovkgDbContext _context;

        public GetPressReleaseByIdQueryHandler(IStigovkgDbContext context)
        {
            _context = context;
        }

        public async Task<PressReleaseDto> Handle(GetPressReleaseByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.PressReleases.Where(x => x.Id == request.Id).Select(p => p.AsDto()).SingleOrDefaultAsync(cancellationToken);
        }
    }
}
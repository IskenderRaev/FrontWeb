using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace StiGovKg.Application.MediatR.Themes.Queries
{
    public class GetThemeByIdQuery : IRequest<ThemeCommandDto>
    {
        public Guid Id { get; set; }
    }

    public class GetThemeByIdQueryHandler : IRequestHandler<GetThemeByIdQuery, ThemeCommandDto>
    {
        private readonly IStigovkgDbContext _context;

        public GetThemeByIdQueryHandler(IStigovkgDbContext context)
        {
            _context = context;
        }

        public async Task<ThemeCommandDto> Handle(GetThemeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Themes.Include(x => x.Subsection).Include(x => x.Documents).ThenInclude(x => x.Leadership).Where(x => x.Id == request.Id && !x.IsDeleted).Select(p => p.AsDto()).SingleOrDefaultAsync(cancellationToken);
        }
    }
}
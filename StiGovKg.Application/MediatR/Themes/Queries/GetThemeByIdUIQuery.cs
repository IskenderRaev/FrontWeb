using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace StiGovKg.Application.MediatR.Themes.Queries
{
    public class GetThemeByIdUIQuery : IRequest<ThemeDto>
    {
        public Guid Id { get; set; }
    }

    public class GetThemeByIdUIQueryHandler : IRequestHandler<GetThemeByIdUIQuery, ThemeDto>
    {
        private readonly IStigovkgDbContext _context;

        public GetThemeByIdUIQueryHandler(IStigovkgDbContext context)
        {
            _context = context;
        }

        public async Task<ThemeDto> Handle(GetThemeByIdUIQuery request, CancellationToken cancellationToken)
        {
            var culture = System.Globalization.CultureInfo.CurrentCulture;
            return await _context.Themes
                .Include(x => x.Subsection)
                .Include(x => x.Documents)
                .ThenInclude(x => x.Leadership)
                .Where(x => x.Id == request.Id && !x.IsDeleted)
                .Select(p => p.AsDto(culture.Name))
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
using MediatR;
using Microsoft.EntityFrameworkCore;
using P.Pager;
using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;

namespace StiGovKg.Application.MediatR.Themes.Queries
{

    public class GetThemesQueryByPersonTypeUI : IRequest<List<ThemeDto>>
    {
        public Guid SubsectionId { get; set; }

        public string Title { get; set; }

        public int Page { get; set; } = 1;
    }

    public class GetThemesQueryByPersonTypeUIHandler : IRequestHandler<GetThemesQueryByPersonTypeUI, List<ThemeDto>>
    {
        private readonly IStigovkgDbContext _context;

        public GetThemesQueryByPersonTypeUIHandler(IStigovkgDbContext context)
        {
            _context = context;
        }

        public async Task<List<ThemeDto>> Handle(GetThemesQueryByPersonTypeUI request, CancellationToken cancellationToken)
        {
            var query = _context.Themes.Include(x => x.Subsection).Where(x => x.SubsectionId == request.SubsectionId && !x.IsDeleted);

            if (!string.IsNullOrEmpty(request.Title))
            {
                query = query.Where(q => EF.Functions.Like(q.Title.ToUpper(), $"%{request.Title.ToUpper()}%"));
            }

            var culture = System.Globalization.CultureInfo.CurrentCulture;
            var items = await query.Select(x => x.AsDto(culture.Name)).ToListAsync();
            return items;
        }
    }
}

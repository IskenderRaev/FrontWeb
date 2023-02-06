using MediatR;
using Microsoft.EntityFrameworkCore;
using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;
using StiGovKg.Domain.Enums;

namespace StiGovKg.Application.MediatR.Subsections.Queries.GetSubsections
{
    public class GetExtraSubsectionQuery : IRequest<List<SubsectionDto>>
    {
        public SectionType? SectionType;
    }

    public class GetExtraSubsectionQueryHandler : IRequestHandler<GetExtraSubsectionQuery, List<SubsectionDto>>
    {
        private readonly IStigovkgDbContext _context;

        public GetExtraSubsectionQueryHandler(IStigovkgDbContext context)
        {
            _context = context;
        }

        public async Task<List<SubsectionDto>> Handle(GetExtraSubsectionQuery request, CancellationToken cancellationToken)
        {

            var query = _context.Subsections.Where(q => !q.IsDeleted);
            if (request.SectionType != null)
            {
                query = query.Where(s => s.SectionType == request.SectionType);
            }
            var culture = System.Globalization.CultureInfo.CurrentCulture;
            var items = await query.Select(x => x.AsDto(culture.Name)).ToListAsync();
            return items;
        }
    }
}

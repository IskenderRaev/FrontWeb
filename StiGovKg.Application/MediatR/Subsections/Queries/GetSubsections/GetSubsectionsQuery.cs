using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;
using StiGovKg.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using P.Pager;

namespace StiGovKg.Application.MediatR.Subsections.Queries.GetSubsections
{
    public class GetSubsectionsQuery : IRequest<List<SubsectionDto>>
    {
        public SectionType? SectionType;
    }

    public class GetSubsectionsQueryHandler : IRequestHandler<GetSubsectionsQuery, List<SubsectionDto>>
    {
        private readonly IStigovkgDbContext _context;

        public GetSubsectionsQueryHandler(IStigovkgDbContext context)
        {
            _context = context;
        }

        public async Task<List<SubsectionDto>> Handle(GetSubsectionsQuery request, CancellationToken cancellationToken)
        {
            
            var query =  _context.Subsections.Where(q => !q.IsDeleted);
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
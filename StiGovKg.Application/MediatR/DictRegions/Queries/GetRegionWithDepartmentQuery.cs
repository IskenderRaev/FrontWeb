using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StiGovKg.Application.MediatR.DictRegions.Queries
{
    public class GetRegionWithDepartmentQuery : IRequest<List<DictRegionWithDepartmentsDto>>
    {
    }

    public class GetRegionWithDepartmentQueryHandler : IRequestHandler<GetRegionWithDepartmentQuery, List<DictRegionWithDepartmentsDto>>
    {
        private readonly IStigovkgDbContext _context;

        public GetRegionWithDepartmentQueryHandler(IStigovkgDbContext context)
        {
            _context = context;
        }

        public async Task<List<DictRegionWithDepartmentsDto>> Handle(GetRegionWithDepartmentQuery request, CancellationToken cancellationToken)
        {
            var query = _context.DictRegions.Include(p => p.Departments).AsNoTracking();

            return await query.OrderBy(q => q.Id).Select(x => x.AsRegionWithDepartments()).ToListAsync();
        }
    }
}
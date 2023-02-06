using MediatR;
using Microsoft.EntityFrameworkCore;
using P.Pager;
using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StiGovKg.Application.MediatR.Videos.Queries.GetVideos
{
    public class GetVideosQuery : IRequest<IPager<VideoDto>>
    {
        public string Title { get; set; }

        public int Page { get; set; } = 1;
    }

    public class GetVideoQueryHandler : IRequestHandler<GetVideosQuery, IPager<VideoDto>>
    {
        private readonly IStigovkgDbContext _context;

        public GetVideoQueryHandler(IStigovkgDbContext context)
        {
            _context = context;
        }

        public Task<IPager<VideoDto>> Handle(GetVideosQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Videos.AsNoTracking();

            if (!string.IsNullOrEmpty(request.Title))
            {
                query = query.Where(q => EF.Functions.Like(q.Title.ToUpper(), $"%{request.Title.ToUpper()}%"));
            }

            return query.Select(x => x.AsDto()).ToPagerListAsync(request.Page, 20, cancellationToken);
        }
    }
}
using MediatR;
using Microsoft.EntityFrameworkCore;
using P.Pager;
using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;
using StiGovKg.Application.MediatR.Videos.Queries.GetVideos;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StiGovKg.Application.MediatR.Video.Queries.GetVideosToClientSide
{
    public class GetVideosQueryUI : IRequest<IPager<VideoDto>>
    {
        public string Title { get; set; }

        public int Page { get; set; } = 1;

        public string Date { get; set; }
    }

    public class GetVideosQueryUIHandler : IRequestHandler<GetVideosQueryUI, IPager<VideoDto>>
    {
        private readonly IStigovkgDbContext _context;

        public GetVideosQueryUIHandler(IStigovkgDbContext context)
        {
            _context = context;
        }

        public Task<IPager<VideoDto>> Handle(GetVideosQueryUI request, CancellationToken cancellationToken)
        {
            var query = _context.Videos.AsNoTracking();

            if (!string.IsNullOrEmpty(request.Title))
            {
                query = query.Where(q => EF.Functions.Like(q.Title.ToUpper(), $"%{request.Title.ToUpper()}%"));
            }

            if (!string.IsNullOrEmpty(request.Date))
            {
                int year = int.Parse(request.Date);
                query = query.Where(d => d.PublishDate.Date.Year == year);
            }

            return query.Select(x => x.AsDto()).ToPagerListAsync(request.Page, 6, cancellationToken);
        }
    }
}
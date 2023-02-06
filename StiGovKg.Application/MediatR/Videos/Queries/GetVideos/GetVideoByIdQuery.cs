using MediatR;
using Microsoft.EntityFrameworkCore;
using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StiGovKg.Application.MediatR.Videos.Queries.GetVideos
{
    public class GetVideoByIdQuery : IRequest<VideoDto>
    {
        public Guid Id { get; set; }
    }

    public class GetVideoByIdQueryHandler : IRequestHandler<GetVideoByIdQuery, VideoDto>
    {
        private readonly IStigovkgDbContext _context;

        public GetVideoByIdQueryHandler(IStigovkgDbContext context)
        {
            _context = context;
        }

        public async Task<VideoDto> Handle(GetVideoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Videos.Where(x => x.Id == request.Id).Select(p => p.AsDto()).SingleOrDefaultAsync(cancellationToken);
        }
    }
}
using MediatR;
using Microsoft.EntityFrameworkCore;
using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;

namespace StiGovKg.Application.MediatR.News.Queries
{

    public class GetNewsQueryByIdUI : IRequest<NewsCommandDto>
    {
        public Guid Id { get; set; }
    }

    public class GetNewsQueryByIdUIHandler : IRequestHandler<GetNewsQueryByIdUI, NewsCommandDto>
    {
        private readonly IStigovkgDbContext _context;

        public GetNewsQueryByIdUIHandler(IStigovkgDbContext context)
        {
            _context = context;
        }

        public async Task<NewsCommandDto> Handle(GetNewsQueryByIdUI request, CancellationToken cancellationToken)
        {
            var culture = System.Globalization.CultureInfo.CurrentCulture;
            var news = await _context.News.Where(x => x.Id == request.Id).Select(p => p.AsDto(culture.Name)).SingleOrDefaultAsync(cancellationToken);

            if (news == null)
            {
                return null;
            }

            news.ImagePaths = await _context.NewsImages.Where(x => x.NewsId == news.Id).Select(x => x.ImagePath).ToListAsync(cancellationToken);

            return news;
        }
    }
}

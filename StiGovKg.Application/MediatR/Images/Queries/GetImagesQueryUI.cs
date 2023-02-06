using MediatR;
using Microsoft.EntityFrameworkCore;
using P.Pager;
using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;

namespace StiGovKg.Application.MediatR.Images.Queries
{
    public class GetImagesQueryUI : IRequest<IPager<ImageDto>>
    {
        public Guid GalleryId { get; set; }

        public int Page { get; set; } = 1;

        public string Title { get; set; }
    }

    public class GetImagesQueryUIHandler : IRequestHandler<GetImagesQueryUI, IPager<ImageDto>>
    {
        private readonly IStigovkgDbContext _context;

        public GetImagesQueryUIHandler(IStigovkgDbContext context)
        {
            _context = context;
        }

        public Task<IPager<ImageDto>> Handle(GetImagesQueryUI request, CancellationToken cancellationToken)
        {
            var query = _context.Images.Include(g => g.Gallery).Where(p => p.GalleryId == request.GalleryId);

            if (!string.IsNullOrWhiteSpace(request.Title))
                query = query.Where(c => EF.Functions.Like(c.Title.ToUpper(), $"%{request.Title.ToUpper()}%"));

            return query.OrderByDescending(x => x.PublishDate).Select(x => x.AsDto())
                .ToPagerListAsync(request.Page, 10, cancellationToken);
        }
    }
}
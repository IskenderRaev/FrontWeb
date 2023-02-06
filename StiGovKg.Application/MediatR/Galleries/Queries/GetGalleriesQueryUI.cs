using MediatR;
using Microsoft.EntityFrameworkCore;
using P.Pager;
using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;

namespace StiGovKg.Application.MediatR.Galleries.Queries
{
    public class GetGalleriesQueryUI : IRequest<IPager<GalleryDto>>
    {
        public int Page { get; set; } = 1;

        public string Title { get; set; }

        public string Description { get; set; }

        public string Date { get; set; }
    }

    public class GetGalleriesQueryUIHandler : IRequestHandler<GetGalleriesQueryUI, IPager<GalleryDto>>
    {
        private readonly IStigovkgDbContext _context;

        public GetGalleriesQueryUIHandler(IStigovkgDbContext context)
        {
            _context = context;
        }

        public Task<IPager<GalleryDto>> Handle(GetGalleriesQueryUI request, CancellationToken cancellationToken)
        {
            var query = _context.Galleries.AsNoTracking();

            if (!string.IsNullOrEmpty(request.Title))
                query = query.Where(q => EF.Functions.Like(q.Title.ToUpper(), $"%{request.Title.ToUpper()}%"));

            if (!string.IsNullOrEmpty(request.Description))
                query = query.Where(q => EF.Functions.Like(q.Description.ToUpper(), $"%{request.Description.ToUpper()}%"));

            if (!string.IsNullOrEmpty(request.Date))
            {
                int year = int.Parse(request.Date);
                query = query.Where(d => d.PublishDate.Date.Year == year);
            }

            return query.Select(x => x.AsDto()).ToPagerListAsync(request.Page, 5, cancellationToken);
        }
    }
}
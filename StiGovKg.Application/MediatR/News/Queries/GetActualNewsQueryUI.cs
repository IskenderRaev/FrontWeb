using MediatR;
using Microsoft.EntityFrameworkCore;
using P.Pager;
using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;

namespace StiGovKg.Application.MediatR.News.Queries
{
    public class GetActualNewsQueryUI : IRequest<IPager<ActualNewsCommandDto>>
    {
    }

    public class GetActualNewsQueryQueryHandler : IRequestHandler<GetActualNewsQueryUI, IPager<ActualNewsCommandDto>>
    {
        private readonly IStigovkgDbContext _context;

        public GetActualNewsQueryQueryHandler(IStigovkgDbContext context)
        {
            _context = context;
        }

        public Task<IPager<ActualNewsCommandDto>> Handle(GetActualNewsQueryUI request, CancellationToken cancellationToken)
        {
            List<ActualNewsDto> list = new();
            var querys = _context.News.Where(x => x.IsActual == true).AsNoTracking().ToList();
            foreach (var item in querys)
            {
                var ImageFromContext = _context.NewsSliderImage.Where(x => x.NewsId == item.Id).ToList();
                if (ImageFromContext != null)
                {
                    var val = new ActualNewsDto
                    {
                        Id = item.Id,
                        HeaderRu = item.HeaderRu,
                        HeaderKg = item.HeaderKg,
                        HeaderEn = item.HeaderEn,
                        ShortDescriptionRu = item.ShortDescriptionRu,
                        ShortDescriptionKg = item.ShortDescriptionKg,
                        ShortDescriptionEn = item.ShortDescriptionEn,
                        LongDescriptionRu = item.LongDescriptionRu,
                        LongDescriptionKg = item.LongDescriptionKg,
                        LongDescriptionEn = item.LongDescriptionEn,
                        PublishDate = item.PublishDate,
                        IsActual = item.IsActual,
                        ImagePath = ImageFromContext.FirstOrDefault().ImagePath,
                    };
                    list.Add(val);
                }
            }
            var culture = System.Globalization.CultureInfo.CurrentCulture;
            var items = list.Select(x => x.AsDto(culture.Name)).ToList();
            return items.ToPagerListAsync(1, 5, cancellationToken);
        }
    }
}

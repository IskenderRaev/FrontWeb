using Dapper;
using MediatR;
using Shared.Core.Helpers;
using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;
using StiGovKg.Domain.Entities;
using StiGovKg.Domain.Enums;
using System.Data;

namespace StiGovKg.Application.MediatR.Links.Queries
{

    public class GetAllLinksQueryUI : IRequest<List<LinkCommandDto>>
    {
        public LinkType LinkType { get; set; }
    }

    public class GetUsefulLinksQueryHandler : IRequestHandler<GetAllLinksQueryUI, List<LinkCommandDto>>
    {
        private readonly IStigovkgDbContext _context;
        private readonly IStiGovKgDapperContext _dapper;

        public GetUsefulLinksQueryHandler(IStigovkgDbContext context, IStiGovKgDapperContext dapper)
        {
            _context = context;
            _dapper = dapper;
        }

        public async Task<List<LinkCommandDto>> Handle(GetAllLinksQueryUI request, CancellationToken cancellationToken)
        {
            try
            {
                string sql = @"SELECT /**select**/ FROM /**from**/ /**join**/ /**where**/ /**orderby**/ /**offset**/ /**limit**/";
                DynamicParameters dp = new();
                dp.Add("@LinkType", request.LinkType, DbType.Int32);

                SqlBuilder builder = new SqlBuilder()
                        .Select(@"l.""Id""")
                        .Select(@"""Title"", ""TitleRu"", ""TitleKg"",""TitleEn"", ""LinkSource"",""LinkType"", lm.""ImagePath"" AS ""MainImagePath"", lam.""ImagePath"" AS ""AdditionalImagePath""")
                        .From(@"""Link"" l")
                        .Join(@"""LinkImage"" lm ON l.""Id"" = lm.""LinkId""")
                        .Join(@"""LinkAdditionalImage"" lam ON l.""Id"" = lam.""LinkId""")
                        .Where(@"l.""LinkType"" = @LinkType", request.LinkType);
                builder
                    .AddParameters(dp);
                var rowsTemplate = builder.AddTemplate(sql);
                var rows = await _dapper.Query<LinkEntity>(rowsTemplate.RawSql, (DynamicParameters)rowsTemplate.Parameters);
                var culture = System.Globalization.CultureInfo.CurrentCulture;
                var items = rows.Select(x => x.AsDto(culture.Name)).ToList();
                return items;
            }
            catch (Exception ex)
            {
                return null!;
            }
        }
    }
}

using Dapper;
using MediatR;
using P.Pager;
using Shared.Core.Extensions;
using Shared.Core.Helpers;
using StiGovKg.Application.Common.Constants;
using StiGovKg.Application.Common.Extensions;
using StiGovKg.Application.Common.Interfaces;
using System.Data;
using static Dapper.SqlMapper;

namespace StiGovKg.Application.MediatR.Subsections.Queries.GetSearchItem
{
    public class GetSearchTextQuery : IRequest<IPager<FoundDocumentsDto>>
    {
        public int Page { get; set; } = 1;
        public string SearchWord { get; set; }
    }

    public class GetSearchTextQueryHandler : IRequestHandler<GetSearchTextQuery, IPager<FoundDocumentsDto>>
    {
        private readonly IStigovkgDbContext _context;
        private readonly IStiGovKgDapperContext _dapper;

        public GetSearchTextQueryHandler(IStigovkgDbContext context, IStiGovKgDapperContext dapper)
        {
            _context = context;
            _dapper = dapper;
        }

        public async Task<IPager<FoundDocumentsDto>> Handle(GetSearchTextQuery request, CancellationToken cancellationToken)
        {
            var culture = System.Globalization.CultureInfo.CurrentCulture;
            string sqlRu = @"SELECT d.""Id"", ""ThemeId"", ""SubsectionId"", 
                            ""HeaderRu"", ""HeaderKG"", ""HeaderEn"",
                            ""ShortDescriptionRu"", ""ShortDescriptionKG"", ""ShortDescriptionEn"",
                            ""HtmlStringRu"",  ""HtmlStringKg"",  ""HtmlStringEn"",
                            1 as ""SearchedType""
                         FROM public.""Documents"" d
	                     INNER JOIN public.""Themes"" t ON t.""Id""=d.""ThemeId""
                         WHERE 
                            t.""IsDeleted""=false and (
                            ""HeaderRu"" LIKE CONCAT('%', @SearchString, '%')
                            or ""ShortDescriptionRu"" LIKE CONCAT('%', @SearchString, '%')
                            or ""HtmlStringRu"" LIKE CONCAT('%', @SearchString, '%'))

                            UNION ALL

                            SELECT ""Id"", ""Id"", ""Id"", 
                            ""HeaderRu"", ""HeaderKg"", ""HeaderEn"", 
                            ""ShortDescriptionRu"", ""ShortDescriptionKg"", ""ShortDescriptionEn"",
                            ""LongDescriptionRu"", ""LongDescriptionKg"", ""LongDescriptionEn"",
                            2 as ""SearchedType""
                         FROM public.""News"" 
                         WHERE 
                            ""HeaderRu"" LIKE CONCAT('%', @SearchString, '%')
                            or ""ShortDescriptionRu"" LIKE CONCAT('%', @SearchString, '%')
                            or ""LongDescriptionRu"" LIKE CONCAT('%', @SearchString, '%')";

            string sqlKg = @"SELECT d.""Id"", ""ThemeId"", ""SubsectionId"", 
                            ""HeaderRu"", ""HeaderKG"", ""HeaderEn"",
                            ""ShortDescriptionRu"", ""ShortDescriptionKG"", ""ShortDescriptionEn"",
                            ""HtmlStringRu"",  ""HtmlStringKg"",  ""HtmlStringEn"",
                            1 as ""SearchedType""
                         FROM public.""Documents"" d
	                     INNER JOIN public.""Themes"" t ON t.""Id""=d.""ThemeId""
                         WHERE 
                            t.""IsDeleted""=false and (
                            ""HeaderKG"" LIKE CONCAT('%', @SearchString, '%')
                            or ""ShortDescriptionKG"" LIKE CONCAT('%', @SearchString, '%')
                            or ""HtmlStringKg"" LIKE CONCAT('%', @SearchString, '%'))

                            UNION ALL

                            SELECT ""Id"", ""Id"", ""Id"", 
                            ""HeaderRu"", ""HeaderKg"", ""HeaderEn"", 
                            ""ShortDescriptionRu"", ""ShortDescriptionKg"", ""ShortDescriptionEn"",
                            ""LongDescriptionRu"", ""LongDescriptionKg"", ""LongDescriptionEn"",
                            2 as ""SearchedType""
                         FROM public.""News"" 
                         WHERE 
                            ""HeaderKg"" LIKE CONCAT('%', @SearchString, '%')
                            or ""ShortDescriptionKg"" LIKE CONCAT('%', @SearchString, '%')
                            or ""LongDescriptionKg"" LIKE CONCAT('%', @SearchString, '%')";

            string sqlEn = @"SELECT d.""Id"", ""ThemeId"", ""SubsectionId"", 
                            ""HeaderRu"", ""HeaderKG"", ""HeaderEn"",
                            ""ShortDescriptionRu"", ""ShortDescriptionKG"", ""ShortDescriptionEn"",
                            ""HtmlStringRu"",  ""HtmlStringKg"",  ""HtmlStringEn"",
                            1 as ""SearchedType""
                         FROM public.""Documents"" d
	                     INNER JOIN public.""Themes"" t ON t.""Id""=d.""ThemeId""
                         WHERE 
                            t.""IsDeleted""=false and (
                            ""HeaderEn"" LIKE CONCAT('%', @SearchString, '%')
                            or ""ShortDescriptionEn"" LIKE CONCAT('%', @SearchString, '%')
                            or ""HtmlStringEn"" LIKE CONCAT('%', @SearchString, '%'))

                            UNION ALL

                            SELECT ""Id"", ""Id"", ""Id"", 
                            ""HeaderRu"", ""HeaderKg"", ""HeaderEn"", 
                            ""ShortDescriptionRu"", ""ShortDescriptionKg"", ""ShortDescriptionEn"",
                            ""LongDescriptionRu"", ""LongDescriptionKg"", ""LongDescriptionEn"",
                            2 as ""SearchedType""
                         FROM public.""News"" 
                         WHERE 
                            ""HeaderEn"" LIKE CONCAT('%', @SearchString, '%')
                            or ""ShortDescriptionEn"" LIKE CONCAT('%', @SearchString, '%')
                            or ""LongDescriptionEn"" LIKE CONCAT('%', @SearchString, '%')";

            DynamicParameters dp = new();
            dp.Add("@SearchString", request.SearchWord, DbType.String);

            SqlBuilder builder = new SqlBuilder()
               .WithPagination(request.Page)
               .AddParameters(dp);

            SqlBuilder builderCount = new SqlBuilder()
            .AddParameters(dp);

            string sglTemplate = culture.Name == WebStiLanguages.English ? sqlEn : culture.Name == WebStiLanguages.Kyrgyz ? sqlKg : sqlRu;
            var countTemplate = builderCount.AddTemplate(sglTemplate);
            var rowsTemplate = builder.AddTemplate(sglTemplate);            

            var count = await _dapper.Query<FoundDocumentsEntity>(countTemplate.RawSql, (DynamicParameters)countTemplate.Parameters);
            var rows = await _dapper.Query<FoundDocumentsEntity>(rowsTemplate.RawSql, (DynamicParameters)rowsTemplate.Parameters);
            var mappedRow = rows.Select(x => x.AsDto(culture.Name));            

            return mappedRow.ToPagerList(count.AsList().Count, request.Page, 10);
        }
    }
}

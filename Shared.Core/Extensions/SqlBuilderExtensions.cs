﻿using Shared.Core.Constants;
using Shared.Core.Helpers;

namespace Shared.Core.Extensions
{
    public static class SqlBuilderExtensions
    {
        public static SqlBuilder WhereIf(this SqlBuilder builder, string sql, bool expression)
        {
            return expression
                ? builder.Where(sql)
                : builder;
        }

        public static SqlBuilder WithPagination(this SqlBuilder builder, int pageNumber)
        {
            return builder
                .Offset("@Skip", new { Skip = (pageNumber - 1) * Pagination.PAGE_SIZE })
                .Limit("@Take", new { Take = Pagination.PAGE_SIZE });
        }

        public static SqlBuilder.Template CountTemplate(this SqlBuilder builder, string table)
        {
            return builder.AddTemplate(@$"SELECT COUNT(*) FROM {table} /**join**/ /**leftjoin**/ /**rightjoin**/ /**where**/");
        }
        public static SqlBuilder.Template CountGroupingTemplate(this SqlBuilder builder, string table)
        {
            return builder.AddTemplate(@$"SELECT COUNT(*) FROM (SELECT 1 FROM {table} /**join**/ /**leftjoin**/ /**rightjoin**/ /**where**/ /**groupby**/ ) as Z");
        }
    }
}
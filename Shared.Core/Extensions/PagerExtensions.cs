using P.Pager;
using Shared.Core.Constants;

namespace Shared.Core.Extensions
{
    public static class PagerExtensions
    {
        public static IPager<T> ToPagerList<T>(this IEnumerable<T> items, int totalItemsCount, int pageIndex = 1, int pageSize = Pagination.PAGE_SIZE)
        {
            return new Pager<T>(items.AsQueryable(), pageIndex, pageSize, totalItemsCount);
        }
        
        public static List<List<T>> ChunkList<T>(IEnumerable<T> data, int size)
        {
            return data
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / size)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
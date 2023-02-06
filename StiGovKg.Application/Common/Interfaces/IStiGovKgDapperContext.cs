using Dapper;
using System.Data;

namespace StiGovKg.Application.Common.Interfaces
{
    public interface IStiGovKgDapperContext
    {
        Task<T> GetOne<T>(string sql, DynamicParameters dp, CommandType commandType = CommandType.Text);

        Task<IEnumerable<T>> Query<T>(string sql, DynamicParameters dp, CommandType commandType = CommandType.Text);
    }
}

using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Manager
{
    public interface IDbManager
    {
        Task<Dictionary<int, T>> ExecuteQueryAsync<T>(string sql, params SqliteParameter[] parameters) where T : new();
        Task<int> ExecuteNonQueryAsync(string sql, params SqliteParameter[] parameters);
        Task<T> ExecuteScalarAsync<T>(string sql, params SqliteParameter[] parameters);
    }

}

using Microsoft.Data.Sqlite;
using QuanLyThuVienCaNhan.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace QuanLyThuVienCaNhan.Manager
{
    public class DbManager : IDbManager
    {
        private readonly string _connectionString;

        public DbManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Dictionary<int, T>> ExecuteQueryAsync<T>(string sql, params SqliteParameter[] parameters) where T : new()
        {
            var result = new Dictionary<int, T>();
            var keyProperty = typeof(T).GetProperty("Id");
            if (keyProperty == null) throw new InvalidOperationException($"Type {typeof(T).Name} không có property 'Id'.");
            if (keyProperty.PropertyType != typeof(int) && keyProperty.PropertyType != typeof(int?))
                throw new InvalidOperationException($"Property 'Id' của type {typeof(T).Name} phải là int hoặc int?.");

            using (var conn = new SqliteConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                        while (await reader.ReadAsync())
                        {
                            var obj = new T();
                            foreach (var prop in props)
                            {
                                if (!reader.HasColumn(prop.Name)) continue;

                                var value = reader[prop.Name];
                                if (value is DBNull)
                                {
                                    prop.SetValue(obj, null);
                                }
                                else
                                {
                                    var targetType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                                    prop.SetValue(obj, Convert.ChangeType(value, targetType));
                                }
                            }

                            var keyValue = keyProperty.GetValue(obj);
                            if (keyValue != null)
                            {
                                var key = (int)keyValue;
                                if (!result.ContainsKey(key))
                                    result.Add(key, obj);
                            }
                        }
                    }
                }
            }

            return result;
        }

        public async Task<int> ExecuteNonQueryAsync(string sql, params SqliteParameter[] parameters)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<T> ExecuteScalarAsync<T>(string sql, params SqliteParameter[] parameters)
        {
            using (var conn = new SqliteConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    object result = await cmd.ExecuteScalarAsync();
                    return (result == null || result is DBNull) ? default(T) : (T)Convert.ChangeType(result, typeof(T));
                }
            }
        }
    }
}

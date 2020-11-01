using MySqlConnector;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace db_controller
{
    class DB
    {
        private readonly string CON_STR;
        public DB(string connectionString)
        {
            CON_STR = connectionString;
        }

        public async Task<int> nonQuery(string query, Dictionary<string, object> values)
        {   // UPDATE AND DELETE queries, returns number of rows affected
            using (var connection = new MySqlConnection(CON_STR))
            {
                await connection.OpenAsync();
                using (var command = new MySqlCommand(query, connection))
                {
                    foreach (var value in values)
                        command.Parameters.AddWithValue(value.Key, value.Value);

                    return await command.ExecuteNonQueryAsync();
                }
            }
        }
        public async Task<object> scalar(string query, Dictionary<string, object> values)
        {   // fetch single row single column
            using (var connection = new MySqlConnection(CON_STR))
            {
                await connection.OpenAsync();
                using (var command = new MySqlCommand(query, connection))
                {
                    foreach (var value in values)
                        command.Parameters.AddWithValue(value.Key, value.Value);

                    return await command.ExecuteScalarAsync();
                }
            }
        }
        public async Task<DataTable> query(string query, Dictionary<string, object> values)
        {   // SELECT queries
            var dataTable = new DataTable();
            using (var connection = new MySqlConnection(CON_STR))
            {
                await connection.OpenAsync();
                using (var command = new MySqlCommand(query, connection))
                {
                    foreach (var value in values)
                        command.Parameters.AddWithValue(value.Key, value.Value);

                    dataTable.Load(await command.ExecuteReaderAsync());
                    return dataTable;
                }
            }
        }
    }
}


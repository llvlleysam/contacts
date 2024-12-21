

using contact.Model.Table;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace contact.Utility
{
    public class CRUD
    {
        private SqlConnection db;
        public CRUD(SqlConnection db)
        {
            this.db = db;
        }
        public bool DeleteById<T>(int id)
        {
            Type type = typeof(T);

            string table = type.Name.Replace("Table", "");

            string sql = $"DELETE FROM [dbo].[{table}] WHERE Id = @Id";

            return this.db.Execute(sql, new { Id = id }) > 0;

        }

        public int Insert<T>(T model)
        {
            Type type = typeof(T);

            string table = type.Name.Replace("Table", "");

            PropertyInfo[] properties = type.GetProperties();

            List<string> fields = new();
            List<string> parameters = new();

            string output = "";

            foreach (PropertyInfo property in properties)
            {
                if (property.Name == "Id")
                {
                    output = "OUTPUT INSERTED.Id";  
                    continue;
                }

                fields.Add($"[{property.Name}]");
                parameters.Add($"@{property.Name}");
            }

            string csvFields = string.Join(", ", fields);
            string csvParams = string.Join(", ", parameters);

            string sql = $"INSERT INTO [dbo].[{table}] ({csvFields}) {output} VALUES ({csvParams})";

            return this.db.ExecuteScalar<int>(sql, model);

        }

        public bool UpdateById<T>(T model)
        {
            Type type = typeof(T);

            string table = type.Name.Replace("Table", "");

            PropertyInfo[] properties = type.GetProperties();

            List<string> equals = new();

            foreach (PropertyInfo property in properties)
            {
                if (property.Name == "Id")
                {
                    continue;
                }

                equals.Add($"[{property.Name}] = @{property.Name}");

            }

            string csvEquals = string.Join(", ", equals);

            string sql = $"UPDATE [dbo].[{table}] SET {csvEquals} WHERE Id = @Id";

            return this.db.ExecuteScalar<int>(sql, model) > 0;

        }

        public T GetById<T>(int id)
        {
            Type type = typeof(T);

            string table = type.Name.Replace("Table", "");

            string sql = $"SELECT * FROM [dbo].[{table}] WHERE Id = @Id";

            return this.db.QuerySingle<T>(sql , new { Id = id});

        }

        public IEnumerable<T> Select<T>()
        {
            Type type = typeof(T);

            string table = type.Name.Replace("Table","") ;

            string sql = $"SELECT * FROM [dbo].[{table}]";

            return this.db.Query<T>(sql);
        }
    }
}

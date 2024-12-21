

using contact.Model.Table;
using contact.Utility;
using Dapper;
using Microsoft.Data.SqlClient;

namespace contact.Data
{
    public class UserData
    {
        private SqlConnection db;
        private CRUD CRUD;
        public UserData()
        {
            string connectionString = "Server=.;Database=Contacts;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";
            this.db = new(connectionString);
            this.CRUD = new(this.db);
        }
        public int insert(UserTable table)
        {
            return this.CRUD.Insert(table);
        }

        public int GetUserId(string username, byte[] password)
        {
            string sql = "select Id from dbo.[User] where Username = @Username AND Password = @Password";

            int id = db.ExecuteScalar<int>(sql,new {Username = username ,Password = password });

            return id;

        }

        public UserTable GetUserInfoById(int id)
        {
            string sql = "select Username , Fullname , Avatar from dbo.[User] where Id = @Id";

            UserTable table = db.QuerySingle<UserTable>(sql, new { Id = id });

            return table;

        }

        public void Test()
        {
            UserTable user = this.CRUD.GetById<UserTable>(1005);

            user.Fullname = "HashemJOOn";

            this.CRUD.UpdateById<UserTable>(user);
        }
    }
}

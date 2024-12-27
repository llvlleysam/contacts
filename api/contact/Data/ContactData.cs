using contact.Model;
using contact.Model.Table;
using contact.Utility;
using Microsoft.Data.SqlClient;

namespace contact.Data
{
    public class ContactData
    {
        private SqlConnection db;
        private CRUD CRUD;
        public ContactData()
        {
            string connectionString = "Server=.;Database=Contacts;Integrated Security=True;Encrypt=True;Trust Server Certificate=True;";
            this.db = new(connectionString);
            this.CRUD = new(this.db);
        }

        public IEnumerable<PhoneTypeTable> GetPhoneTypeData()
        {
            return this.CRUD.Select<PhoneTypeTable>();        
        }
    }
}

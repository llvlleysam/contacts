

using contact.Data;
using contact.Model;
using contact.Model.Table;

namespace contact.Business
{
    public class ContactBusiness
    {
       private ContactData data;

        public ContactBusiness()
        {
            this.data = new ContactData();
        }

        public BusinessResult<IEnumerable<PhoneTypeTable>> GetPhoneTypeBusiness()
        {
            BusinessResult<IEnumerable<PhoneTypeTable>> result = new();
            result.Success = true;
            result.Data = this.data.GetPhoneTypeData();

            return result;
        }
    }
}

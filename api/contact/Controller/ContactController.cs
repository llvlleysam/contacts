using contact.Business;
using contact.Model;
using contact.Model.Table;
using Microsoft.AspNetCore.Mvc;

namespace contact.Controller
{
    [ApiController]
    [Route("contact")]
    public class ContactController
    {
        private ContactBusiness business;
        public ContactController() 
        {
            this.business = new ContactBusiness();
        }

        [HttpGet("phonetypes")]
        public BusinessResult<IEnumerable<PhoneTypeTable>> GetPhoneType()
        {
            return business.GetPhoneTypeBusiness();
        }
    }
}

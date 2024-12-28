using contact.Business;
using contact.Model;
using contact.Model.Table;
using contact.Model.Table.User;
using Microsoft.AspNetCore.Mvc;

namespace contact.Controller
{
    [ApiController]
    [Route("user")]
    public class UserController
    {
        private UserBusiness business;

        public UserController()
        {
            this.business = new UserBusiness();
        }

        [HttpPost("login")]
        public BusinessResult<int> login(UserLoginModel model)
        {
            return this.business.LoginBusiness(model);
        }


        [HttpPost("register")] 
        public BusinessResult<int> Register(UserAddModel model)
        {
            return this.business.RegisterBusiness(model);
        }

        [HttpGet("profile")]
        public BusinessResult<UserProfileModel> Profile(int userId)
        {
            return this.business.ProfileBusiness(userId);
        }
    }
}

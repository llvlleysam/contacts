

using contact.Data;
using contact.Model;
using contact.Model.Table;
using contact.Model.Table.User;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace contact.Business
{
    public class UserBusiness
    {
        public BusinessResult<int> RegisterBusiness(UserAddModel model)
        {
            BusinessResult<int> result = new();

            byte[] password = MD5.HashData(Encoding.UTF8.GetBytes(model.Password));

            string vvv = model.ImageData.Split(',')[1];

            model.ImageData = vvv;

            byte[] avatar = Convert.FromBase64String(model.ImageData);

            if (!Directory.Exists(@"E:\full stack\contact project\contacts\api\contact\bin\Debug\net9.0\Avatar\"))
            {
                Directory.CreateDirectory(@"E:\full stack\contact project\contacts\api\contact\bin\Debug\net9.0\Avatar\");
            }

            string file = @$"E:\full stack\contact project\contacts\api\contact\bin\Debug\net9.0\Avatar\\{model.Username.ToLower()}.png";

            if (File.Exists(file))
            {
                File.Delete(file);
            }

            File.WriteAllBytes(file, avatar);

            UserTable user = new()
            {
                Username = model.Username,
                Password = password,
                Fullname = model.FullName,
                Avatar = $"{model.Username.ToLower()}.png"
            };

            result.Data = new UserData().insert(user);

            result.Success = true;

            return result;
        }

        public BusinessResult<int> LoginBusiness(UserLoginModel model)
        {
            byte[] password = MD5.HashData(Encoding.UTF8.GetBytes(model.Password));

            int id = new UserData().GetUserId(model.Username, password);

            if (id == 0)
            {
                return new BusinessResult<int>()
                {
                    Success = false,
                    ErrorCode = 2002,
                    ErrorMessage = "Invalid Username or Password"
                };
            }

            return new BusinessResult<int>()
            {
                Success = true,
                Data = id
            };
        }

        public BusinessResult<UserProfileModel> ProfileBusiness(int userId) 
        {
            UserTable table = new UserData().GetUserInfoById(userId);

            string file = @$"E:\full stack\contact project\contacts\api\contact\bin\Debug\net9.0\Avatar\{table.Username.ToLower()}.png";

            string data = Convert.ToBase64String(File.ReadAllBytes(file));
            return new BusinessResult<UserProfileModel>()
            {
                Success = true,
                Data = new UserProfileModel()
                {
                    Avatar = data,
                    FullName = table.Fullname,
                    UserName = table.Username
                }
            };
        }
    }
}

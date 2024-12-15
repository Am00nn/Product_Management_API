using Product_Management_API.Models;
using Product_Management_API.Repository;

namespace Product_Management_API.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userrepo;

        public UserService(IUserRepo userrepo)
        {
            _userrepo = userrepo;
        }


        public void AddUser(User user)
        {

            _userrepo.AddUser(user);
        }

        public User GetUser(string email, string password)
        {
            return _userrepo.GetUSer(email, password);

        }

    }
}

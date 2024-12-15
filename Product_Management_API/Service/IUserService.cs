using Product_Management_API.Models;

namespace Product_Management_API.Service
{
    public interface IUserService
    {
        void AddUser(User user);
        User GetUser(string email, string password);
    }
}
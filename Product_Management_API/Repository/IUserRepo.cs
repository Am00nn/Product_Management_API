using Product_Management_API.Models;

namespace Product_Management_API.Repository
{
    public interface IUserRepo
    {
        void AddUser(User user);
        User GetUSer(string email, string password);
    }
}
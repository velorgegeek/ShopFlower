
using DOMAIN;

namespace Date.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetUsers(role rol);
        bool AddUsers(string email, string Fio, string password,string Phone,role Role);
        void UpdateRole(User user, role role);
        User GetByLogin(string login, string pass);
    }

}

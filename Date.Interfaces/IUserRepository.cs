
using DOMAIN;

namespace Date.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetUsers(role rol);
        bool AddUsers(string email, string Fio, string password,string Phone,role Role);
        string CreateSHA256(string input);
        void UpdateRole(User user, role role);
        bool GetByLogin(string login, string pass);
    }

}

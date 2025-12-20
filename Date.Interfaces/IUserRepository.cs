
using DOMAIN;

namespace Date.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetUsers(role rol);
        bool Add(User user);
        bool Add(string email, string Fio, string password,string Phone,role Role);
        void UpdateRole(string login, role role);
        User GetByLogin(string login, string pass);
        bool Update(User user);
        bool Remove(User user);
        List <User> GetAll();
    }

}

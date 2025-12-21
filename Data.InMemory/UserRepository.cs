
using Date.Interfaces;
using DOMAIN;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;
using System.Runtime.CompilerServices;
namespace Data.InMemory
{
    public class UserRepository : IUserRepository
    {

        List<User> Users { get; set; } = new List<User>() { 
        };
        
        int count = 0;
        public List<User> GetUsers(role rol) {
            return Users.Where(u=> u.Role == rol).ToList();
        }
        public List<User> GetAll()
        {
            return Users.ToList();
        }
        public bool Add(User user)
        {
            if(user == null)  return false;
            Users.Add(user);
            return true;    
        }
        public bool Add(string email, string Fio, string password, string Phone,role Role)
        {
            string hashPassword = CreateSHA256(password);
            count++;
            User us = new User(count, Fio, Phone, email, hashPassword,Role);
            Users.Add(us);
            return true;
        }
        public static string CreateSHA256(string input)
        {
            using SHA256 hash = SHA256.Create();
            return Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(input)));
        }
        public User GetByLogin(string login,string pass)
        {
            User tmp = Users.FirstOrDefault(u => u.Phone == login); 
            if(tmp == null) return null;
            if (tmp.HashPassword == CreateSHA256(pass)) return tmp;
            return null;
        }
        public bool Remove(User user)
        {
            return false;
        }
        public bool Update(User user)
        {
            return false;
        }
         public void UpdateRole(string login, role role)
        {
            User tmp = Users.FirstOrDefault(u => u.Phone == login);
            if(tmp == null) return;
            if (tmp.Role == role) return;
            tmp.Role = role;
         }
    }
}

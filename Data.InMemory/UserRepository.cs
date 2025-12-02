
using Date.Interfaces;
using DOMAIN;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;
namespace Data.InMemory
{
    public class UserRepository : IUserRepository
    {

        List<User> Users { get; set; } = new List<User>() { 
            new User(1,"da","+79050944341","da",CreateSHA256("da")),
            new User(2,"da","7905","daq",CreateSHA256("dadd")),
        };
        
        int count = 2;
        public List<User> GetUsers(role rol) {
            return Users.Where(u=> u.Role == rol).ToList();
        }
        public bool AddUsers(string email, string Fio, string password, string Phone,role Role)
        {
            string hashPassword = CreateSHA256(password);
            count++;
            User us = new User(count, Fio, Phone, email, hashPassword);
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
         public void UpdateRole(User user, role role)
        {

        }
    }

}

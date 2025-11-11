
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
            new User(0,"da","+7905","da","da"),
            new User(1,"da","+7905","daq","dadd"),
        };
        
        int count = 0;
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
        public string CreateSHA256(string input)
        {
            using SHA256 hash = SHA256.Create();
            return Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(input)));
        }
        public bool GetByLogin(string login,string pass)
        {
            User tmp = Users.FirstOrDefault(u => u.Mail == login);
            if(tmp == null) return false;
            if (tmp.HashPassword == CreateSHA256(pass)) return true;
            return false;
        }
         public void UpdateRole(User user, role role)
        {

        }
    }

}

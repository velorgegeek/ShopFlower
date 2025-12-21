using Date.Interfaces;
using DOMAIN;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace FlowerShopDB.Data.SqlServer
{
    public class UserRepository : IUserRepository
    {
        private readonly ShopDBContext _dbContext;
        public UserRepository(ShopDBContext context) { 
            _dbContext = context;
        }
        public List<User> GetAll()
        {
            return _dbContext.users.ToList();
        }
        public static string CreateSHA256(string input)
        {
            using SHA256 hash = SHA256.Create();
            return Convert.ToHexString(hash.ComputeHash(Encoding.ASCII.GetBytes(input)));
        }
        public List<User> GetUsers(role rol)
        {
            return _dbContext.users.Where(r=> r.Role == rol).ToList();
        }
        public User GetByLogin(string login, string pass)
        {
            var temp = _dbContext.users.Where(u => u.Phone == login).FirstOrDefault();
            if(temp == null) return null;
            if(temp.HashPassword == CreateSHA256(pass)) return temp;
            return null;
        }
        public bool Add(User user)
        {
            if(user == null) return false;
            if(_dbContext.users.FirstOrDefault(i => i.Phone == user.Phone) != null) return false;
            _dbContext.users.Add(user);
            _dbContext.SaveChanges();
            return true;
        }
        public bool Add(string email, string Fio, string password, string Phone, role Role)
        {
            var temp = _dbContext.users.Where(u => u.Phone == Phone).FirstOrDefault();
            if(temp != null) return false;  
            string hashPassword = CreateSHA256(password);
            User us = new User {Fio = Fio,Phone = Phone,Mail= email,HashPassword = hashPassword,Role = Role };
            _dbContext.users.Add(us);   
            _dbContext.SaveChanges();
            return true;
        }
        public bool Update(User user)
        {
            if(user == null) return false;
            _dbContext.Entry(user).CurrentValues.SetValues(user);
            return true;
        }
        public bool Remove(User user)
        {
            if(user == null) return false;
            _dbContext.Remove(user);
            _dbContext.SaveChanges();
            return true;
        }
        public void UpdateRole(string login, role role)
        {
            User tmp = _dbContext.users.FirstOrDefault(u => u.Phone == login);
            if (tmp == null) return;
            if (tmp.Role == role) return;
            tmp.Role = role;
            _dbContext.Entry(tmp).CurrentValues.SetValues(tmp);
            _dbContext.SaveChanges();
        }
    }
}

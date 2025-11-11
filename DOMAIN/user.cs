

using System.Xml.Linq;

namespace DOMAIN
{
    public enum role
    {
        User,
        Admin,
    }
    public class User
    {
        public int ID { get; set; }
        public string Fio{ get; set; }
        public string Phone { get; set; }
        public string? Mail { get; set; }
        public string HashPassword { get; set; }
        public role Role { get; set; } = role.User;
        public User(int id, string fio, string phone, string mail, string hashPassword)
        {
            ID = id;
            Fio = fio;
            Phone = phone;
            Mail = mail;
            HashPassword = hashPassword;
        }
        public override string ToString()
        {
            return Fio;
        }
    }
}

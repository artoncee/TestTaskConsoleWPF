using ServerApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Controller
{
    internal class AuthService
    {
        public static string RegistrationUser(string username, string password, string orgName)
        {           
            foreach (Organization organization in DataHandler.Organizations)
            {
                foreach (User user in organization.Users)
                {
                    if (user.Username == username)
                    {
                        return ConstRequest.UserIsAlreadyRegistered;
                    }
                }
            }
           
            Organization org = DataService.GetOrganizationByName(orgName);
            string hashedPassword = HashPassword(password);
            User newUser = new User
            {
                Username = username,
                Password = hashedPassword
            };

            org.Users.Add(newUser);
            DataHandler.SaveData();
            Console.WriteLine($"Пользователь {username} успешно зарегистрирован в организации {orgName}");
            return ConstRequest.RegistrationSuccess;
        }

        public static string LoginUser1(string username, string password)
        {
            string hashedPassword = HashPassword(password);

            foreach (Organization org in DataHandler.Organizations)
            {
                foreach (User user in org.Users)
                {
                    if (user.Username == username && user.Password == hashedPassword)
                    {
                        Console.WriteLine($"Авторизация {username} прошла успешно");
                        return ConstRequest.LoginSuccess;
                    }
                }
            }
            Console.WriteLine("Авторизация не удалась");
            return ConstRequest.LoginFailed;
        }

        public static string LoginUser2(string username, string password, string orgName)
        {
            Organization org = DataService.GetOrganizationByName(orgName);
            string hashedPassword = HashPassword(password);
            foreach (User user in org.Users)
            {
                if (user.Username == username && user.Password == hashedPassword)
                {
                    Console.WriteLine($"Авторизация {username} прошла успешно");
                    return ConstRequest.LoginSuccess;
                }
            }
            Console.WriteLine("Авторизация не удалась");
            return ConstRequest.LoginFailed;
        }

        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                string passwordHash = string.Empty;
                foreach (byte b in bytes)
                {
                    passwordHash += b.ToString("x2");
                }

                return passwordHash;
            }
        }

    }
}

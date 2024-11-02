using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Controller
{
    internal class AuthService
    {

        public static string RegistrationUser(string username, string password, string orgName)
        {
            Organization org = DataHandler.GetOrganizationByName(orgName);

            foreach (User user in org.Users)
            {
                if (user.Username == username)
                {                    
                    return "USER_IS_ALREADY_REGISTERED";
                }
            }
            User newUser = new User
            {
                Username = username,
                Password = password
            };

            org.Users.Add(newUser);
            Data.SaveData();
            Console.WriteLine($"Пользователь {username} успешно зарегистрирован в организации {orgName}");
            return "REGISTRATION_SUCCESS";
        }

        public static string LoginUser1(string username, string password)
        {
            foreach (Organization org in DataHandler.GetAllOrganizations())
            {
                foreach (User user in org.Users)
                {
                    if (user.Username == username && user.Password == password)
                    {
                        Console.WriteLine($"Авторизация {username} прошла успешно");
                        return "LOGIN_SUCCESS";
                    }
                }
            }
            Console.WriteLine("Авторизация не удалась");
            return "LOGIN_FAILED";
        }

        public static string LoginUser2(string username, string password, string orgName)
        {
            Organization org = DataHandler.GetOrganizationByName(orgName);
            foreach (User user in org.Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    Console.WriteLine($"Авторизация {username} прошла успешно");
                    return "LOGIN_SUCCESS";
                }
            }
            Console.WriteLine("Авторизация не удалась");
            return "LOGIN_FAILED";
        }
    }
}

using ServerApp.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    internal static class CommandHandler
    {
        public static string HandleRequest(string request)
        {
            string[] parts = request.Split('|');
            string command = parts[0];

            switch (command)
            {
                case "GET_ORGANIZATIONS":
                    return DataHandler.GetOrganizationsBySelect();
                case "GET_USERS":
                    return DataHandler.GetUsersBySelect(parts[1]);
                case "REGISTRATION":
                    return AuthService.RegistrationUser(parts[1], parts[2], parts[3]);
                case "LOGIN1":
                    return AuthService.LoginUser1(parts[1], parts[2]);
                case "LOGIN2":
                    return AuthService.LoginUser2(parts[1], parts[2], parts[3]);
                default:
                    return "UNKNOWN_COMMAND";
            }
        }
    }
}


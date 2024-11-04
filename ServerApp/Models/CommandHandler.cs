using ServerApp.Controller;
using ServerApp.Utils;
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
                case ConstRequest.GetOrganizations:
                    return DataService.GetOrganizationsBySelect();

                case ConstRequest.GetUsers:
                    if (parts.Length < 2) return ConstRequest.UknownCommand;
                    return DataService.GetUsersBySelect(parts[1]);

                case ConstRequest.RegistrationRequest:
                    if (parts.Length < 4) return ConstRequest.UknownCommand;
                    return AuthService.RegistrationUser(parts[1], parts[2], parts[3]);

                case ConstRequest.Login1Request:
                    if (parts.Length < 3) return ConstRequest.UknownCommand;
                    return AuthService.LoginUser1(parts[1], parts[2]);

                case ConstRequest.Login2Request:
                    if (parts.Length < 4) return ConstRequest.UknownCommand;
                    return AuthService.LoginUser2(parts[1], parts[2], parts[3]);

                default:
                    return ConstRequest.UknownCommand;
            }
        }
    }
}


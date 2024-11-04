using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Utils
{
    internal class ConstRequest
    {
        public const string LoginSuccess = "LOGIN_SUCCESS";
        public const string LoginFailed = "LOGIN_FAILED";
        public const string RegistrationSuccess = "REGISTRATION_SUCCESS";
        public const string UserIsAlreadyRegistered = "USER_IS_ALREADY_REGISTERED";
        public const string GetOrganizations = "GET_ORGANIZATIONS";
        public const string GetUsers = "GET_USERS";
        public const string RegistrationRequest = "REGISTRATION";
        public const string Login1Request = "LOGIN1";
        public const string Login2Request = "LOGIN2";
        public const string UknownCommand = "UNKNOWN_COMMAND";    
            
    }
}

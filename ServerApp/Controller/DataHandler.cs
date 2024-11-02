using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp.Controller
{
    internal class DataHandler
    {
        public static Organization GetOrganizationByName(string name)
        {
            foreach (Organization org in Data.Organizations)
            {
                if (org.Name == name)
                {
                    return org;
                }
            }
            return null;
        }

        public static string GetOrganizationsBySelect()
        {
            List<string> orgNames = new List<string>();

            foreach (Organization org in Data.Organizations)
            {
                orgNames.Add(org.Name);
            }
            return string.Join(",", orgNames);
        }

        public static string GetUsersBySelect(string orgName)
        {
            Organization org = GetOrganizationByName(orgName);

            List<string> usernames = new List<string>();
            foreach (User user in org.Users)
            {
                usernames.Add(user.Username);
            }
            return string.Join(",", usernames);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp9
{
    public class ValidatorService
    {
        public bool ValidateUser(string username, string password, string creds)
        {
            return !string.IsNullOrWhiteSpace(username) && CheckPassword(password) && !string.IsNullOrWhiteSpace(creds);
        }

        public bool CheckPassword(string password)
        {
            return (password?.Length ?? 0) >= 8;
        }
    }
}

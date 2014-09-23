using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class UserLoginOption : MenuOption
    {
        private LoginAction _action = new LoginAction();

        public String displayOption()
        {
            return ActivationKey + " -> " + Prompt + "\n";
        }

        public char ActivationKey {
            get
            {
                return 'L';
            }
            set { }
        }

        public String Prompt { 
            get
            {
                return "Login";
            }
            set { }
        }

        public LoginAction Action {
            get
            {
                return _action;
            }
            set { }
        }
    }

}

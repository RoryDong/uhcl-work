using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class NewAccountOption : MenuOption
    {
        private NewAccountAction _action = new NewAccountAction();

        public String displayOption()
        {
            return ActivationKey + " -> " + Prompt + "\n";
        }

        public char ActivationKey {
            get
            {
                return 'C';
            }
            set { }
        }

        public String Prompt { 
            get
            {
                return "Create New Account";
            }
            set { }
        }

        public NewAccountAction Action {
            get
            {
                return _action;
            }
            set { }
        }
    }

}

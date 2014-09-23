using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class SwitchUserOption : MenuOption
    {

        public String displayOption()
        {
            return ActivationKey + " -> " + Prompt + "\n";
        }

        public char ActivationKey {
            get
            {
                return 'S';
            }
            set { }
        }

        public String Prompt { 
            get
            {
                return "Switch User Account";
            }
            set { }
        }

    }

}

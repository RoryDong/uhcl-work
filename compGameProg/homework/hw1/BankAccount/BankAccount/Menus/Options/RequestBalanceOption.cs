using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class RequestBalanceOption : MenuOption
    {
        private RequestBalanceAction _action = new RequestBalanceAction();

        public String displayOption()
        {
            return ActivationKey + " -> " + Prompt + "\n";
        }

        public char ActivationKey {
            get
            {
                return 'R';
            }
            set { }
        }

        public String Prompt { 
            get
            {
                return "Request Balance";
            }
            set { }
        }

        public RequestBalanceAction Action {
            get
            {
                return _action;
            }
            set { }
        }
    }

}

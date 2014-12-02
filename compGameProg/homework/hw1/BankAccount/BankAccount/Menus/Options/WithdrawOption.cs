using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class WithdrawOption : MenuOption
    {
        private WithdrawAction _action = new WithdrawAction();

        public String displayOption()
        {
            return ActivationKey + " -> " + Prompt + "\n";
        }

        public char ActivationKey {
            get
            {
                return 'W';
            }
            set { }
        }

        public String Prompt { 
            get
            {
                return "Withdraw Money";
            }
            set { }
        }

        public WithdrawAction Action {
            get
            {
                return _action;
            }
            set { }
        }
    }

}

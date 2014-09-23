using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class DepositOption : MenuOption
    {
        private DepositAction _action = new DepositAction();

        public String displayOption()
        {
            return ActivationKey + " -> " + Prompt + "\n";
        }

        public char ActivationKey {
            get
            {
                return 'D';
            }
            set { }
        }

        public String Prompt { 
            get
            {
                return "Deposit Money";
            }
            set { }
        }

        public DepositAction Action {
            get
            {
                return _action;
            }
            set { }
        }
    }

}

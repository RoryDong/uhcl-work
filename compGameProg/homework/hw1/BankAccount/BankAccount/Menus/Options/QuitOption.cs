using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class QuitOption : MenuOption
    {
        private QuitAction _action = new QuitAction();

        public String displayOption()
        {
            return ActivationKey + " -> " + Prompt + "\n";
        }

        public char ActivationKey {
            get
            {
                return 'Q';
            }
            set { }
        }

        public String Prompt { 
            get
            {
                return "Quit";
            }
            set { }
        }

        public QuitAction Action {
            get
            {
                return _action;
            }
            set { }
        }
    }

}

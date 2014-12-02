using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace BankAccount
{
    class RequestBalanceAction : BankAction
    {
        private UserAccount _userAccnt = new UserAccount();

        public void performAction()
        {
            Console.WriteLine("");
            Console.WriteLine("Your current balance is : " + _userAccnt.Balance.ToString());
            Console.WriteLine("");
        }

        public UserAccount UserAccnt
        {
            set
            {
                _userAccnt = value;
            }

        }    }
}

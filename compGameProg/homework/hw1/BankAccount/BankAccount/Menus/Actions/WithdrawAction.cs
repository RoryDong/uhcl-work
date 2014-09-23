using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace BankAccount
{
    class WithdrawAction : BankAction
    {
        private UserAccount _userAccnt = new UserAccount();

        public void performAction()
        {
            float withdrawAmount = _collectWithdraw();
            Console.WriteLine("");
            Console.WriteLine("Amount of your withdrawal : " + withdrawAmount.ToString());
            _userAccnt.Balance -= withdrawAmount;
            Console.WriteLine("");
            Console.WriteLine("Your new balance : " + _userAccnt.Balance.ToString());
            Console.WriteLine("");
        }

        private float _collectWithdraw()
        {
            float return_float = 0.0f;
            Console.WriteLine("Please enter the amount to withdraw from your account : ");
            try
            {
                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
                return_float = float.Parse(Console.ReadLine(), culture);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid withdrawal amount. \n" + e.ToString());
            }
            return return_float;
        }

        public UserAccount UserAccnt
        {
            set
            {
                _userAccnt = value;
            }

        }
    }
}

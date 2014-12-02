using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace BankAccount
{
    class DepositAction : BankAction
    {
        private UserAccount _userAccnt = new UserAccount();

        public void performAction()
        {
            float depositAmount = _collectDeposit();
            Console.WriteLine("");
            Console.WriteLine("Amount of deposit : " + depositAmount.ToString());
            Console.WriteLine("");
            _userAccnt.Balance += depositAmount;
            Console.WriteLine("Your new balance : " + _userAccnt.Balance.ToString());
            Console.WriteLine("");
        }

        private float _collectDeposit()
        {
            float return_float = 0.0f;
            Console.WriteLine("Please enter your deposit amount : ");
            try
            {
                CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
                return_float = float.Parse(Console.ReadLine(), culture);
            }catch (Exception e)
            {
                Console.WriteLine("Invalid deposit amount. \n" + e.ToString());
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

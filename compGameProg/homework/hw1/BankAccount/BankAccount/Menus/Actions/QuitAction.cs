using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount
{
    class QuitAction : BankAction
    {
        public void performAction()
        {
            Console.WriteLine("You have chosen to exit the application. Goodbye!");
            Environment.Exit(1);
        }

    }
}

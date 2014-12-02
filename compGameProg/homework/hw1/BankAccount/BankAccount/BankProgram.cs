using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class BankProgram
    {
        static void Main(string[] args)
        {
            BankCLI _bankCLI = new BankCLI();
            if (_bankCLI.IsInitialized)
            {
                _bankCLI.run();
            }else
            {
                Console.WriteLine("Bank command line program failed to initialize. Exiting...");
            }
        }


    }
}

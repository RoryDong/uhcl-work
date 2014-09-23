using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount
{
    public interface MenuOption
    {
        String displayOption();

        char ActivationKey { get; set; }

        String Prompt { get; set; }

    }
}

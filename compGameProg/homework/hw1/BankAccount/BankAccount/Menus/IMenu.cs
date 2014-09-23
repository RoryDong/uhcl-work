using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount
{
    interface IMenu
    {
        List<MenuOption> MenuOptionsList
        { 
            get;
            set;
        }

        Dictionary<String, MenuOption> MenuOptionsDict
        {
            get;
            set;
        }

        String displayMenu();

        bool IsInitialized
        {
            get;
            set;
        }
    }
}

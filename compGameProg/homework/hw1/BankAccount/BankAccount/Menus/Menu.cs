using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount
{
    public class Menu : IMenu
    {
        protected Dictionary<String, MenuOption> _menuOptionsDict = new Dictionary<String,MenuOption>();
        protected List<MenuOption> _menuOptionsList = new List<MenuOption>();
        private bool _isInitialized = false;

        public Menu()
        {
            _isInitialized = _initializeMenu();
        }

        public bool IsInitialized
        {
            get
            {
                return _isInitialized;
            }
            set
            {
            }
        }

        protected virtual bool _initializeMenu()
        {
            return true;
        }

        public virtual String displayMenu()
        {
            String return_string = "";
            foreach (MenuOption option in _menuOptionsList)
            {
                return_string += option.displayOption();
            }
            return return_string;
        }

        public List<MenuOption> MenuOptionsList
        {
            get { return _menuOptionsList; }
            set { }
        }

        public Dictionary<String, MenuOption> MenuOptionsDict
        {
            get { return _menuOptionsDict; }
            set { }
        }

    }



}

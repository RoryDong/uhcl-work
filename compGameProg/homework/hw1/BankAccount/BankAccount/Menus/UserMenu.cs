using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount
{
    class UserMenu : Menu
    {
        private DepositOption _depositOption = new DepositOption();
        private WithdrawOption _withdrawOption = new WithdrawOption();
        private RequestBalanceOption _requestBalanceOption = new RequestBalanceOption();
        private SwitchUserOption _switchUserOption = new SwitchUserOption();
        private QuitOption _quitOption = new QuitOption();
        private bool _switchUser = false;

        protected override bool _initializeMenu()
        {
            _menuOptionsList.Add(_depositOption);
            _menuOptionsList.Add(_withdrawOption);
            _menuOptionsList.Add(_requestBalanceOption );
            _menuOptionsList.Add(_switchUserOption);
            _menuOptionsList.Add(_quitOption );
            _menuOptionsDict.Add("Deposit", _depositOption);
            _menuOptionsDict.Add("Withdraw", _withdrawOption);
            _menuOptionsDict.Add("Request Balance", _requestBalanceOption );
            _menuOptionsDict.Add("Switch User", _switchUserOption );
            _menuOptionsDict.Add("Quit", _quitOption );
            return true;
        }

        public void performUserMenuOption(string cmd, UserAccount user)
        {
            _switchUser = false;
            switch(cmd)
            {
                case "D":
                    Console.WriteLine("");
                    _depositOption.Action.UserAccnt = user;
                    _depositOption.Action.performAction();
                    break;
                case "W":
                    Console.WriteLine("");
                    _withdrawOption.Action.UserAccnt = user;
                    _withdrawOption.Action.performAction();
                    break;
                case "R":
                    Console.WriteLine("");
                    _requestBalanceOption.Action.UserAccnt = user;
                    _requestBalanceOption.Action.performAction();
                    break;
                case "S":
                    Console.WriteLine("");
                    _switchUser = true;
                    break;
                case "Q":
                    Console.WriteLine("");
                    _quitOption.Action.performAction();
                    break;
                default:
                    Console.WriteLine("");
                    Console.WriteLine("Invalid menu option! Please hit the 'l' key to login, the 'c' key to create an account, and the 'q' key to quit.");
                    break;
            }
        }

        public bool SwitchUser 
        {
            get
            {
                return _switchUser;
            }
            set
            {
            }
        }

    }


}

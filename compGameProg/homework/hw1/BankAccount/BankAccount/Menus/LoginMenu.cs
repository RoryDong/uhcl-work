using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount
{
    public class LoginMenu : Menu
    {
        private UserLoginOption _userLoginOption = new UserLoginOption();
        private NewAccountOption _newAccntOption = new NewAccountOption();
        private QuitOption _quitOption = new QuitOption();
        private UserAccount _activeUser = new UserAccount();
        private bool _loginSuccess = false;
        private bool _loginFail = false;

        protected override bool _initializeMenu()
        {
            _menuOptionsList.Add(_userLoginOption);
            _menuOptionsList.Add(_newAccntOption);
            _menuOptionsList.Add(_quitOption );
            _menuOptionsDict.Add("Login", _userLoginOption);
            _menuOptionsDict.Add("New Account", _newAccntOption);
            _menuOptionsDict.Add("Quit", _quitOption );
            return true;
        }

        public void performLoginMenuOption(String cmd, List<UserAccount> userAccnts)
        {
            _loginSuccess = false;
            _loginFail = false;
            switch(cmd)
            {
                case "L":
                    Console.WriteLine("");
                    _userLoginOption.Action.UserAccounts = userAccnts;
                    _doUserLogin();
                    break;
                case "C":
                    Console.WriteLine("");
                    _newAccntOption.Action.UserAccounts = userAccnts;
                    _newAccntOption.Action.performAction();
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

        private void _doUserLogin()
        {
            _userLoginOption.Action.performAction();
            _loginSuccess = _userLoginOption.Action.SuccessfulLogin;
            if (_loginSuccess)
            {
                _activeUser = _userLoginOption.Action.ValidUser;
            }else
            {
                _loginFail = true;
            }
        }

        public UserAccount ActiveUser 
        {
            get
            {
                return _activeUser;
            }
            set
            {
            }
        }

        public bool LoginSuccess 
        {
            get
            {
                return _loginSuccess;
            }
            set
            {
            }
        }

        public bool LoginFail 
        {
            get
            {
                return _loginFail;
            }
            set
            {
            }
        }
    }



}

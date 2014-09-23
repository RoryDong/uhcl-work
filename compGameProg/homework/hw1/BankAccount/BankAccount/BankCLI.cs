using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public enum BankUserState
    {
        USER_NOT_LOGGED_IN,
        USER_LOGGED_IN
    }

    class BankCLI
    {
        private String _welcomeMsg = "Welcome to our bank!";
        private String _introPrompt = "Please select an option from the menu below: \n\n";
        private String _loginSuccessText = "******** YOU ARE LOGGED IN! ********\n";
        private String _loginFailText = "******** LOGIN FAILED! ********\n";
        private LoginMenu _loginMenu = new LoginMenu();
        private UserMenu _userMenu = new UserMenu();
        private List<UserAccount> _userAccnts = new List<UserAccount>();
        private UserAccount _activeUser = new UserAccount();
        private BankUserState _userState = new BankUserState();
        private bool _isInitialized = false;

        public BankCLI()
        {
            _isInitialized = _initialize();
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

        private bool _initialize()
        {
            _displayWelcomeMsg();
            _displayIntroPrompt();
            _createAdminAccount();
            return (_loginMenu.IsInitialized && _userMenu.IsInitialized);
        }

        public void run()
        {
            while(true)
            {
                _updateUserState();
            }
        }

        private void _updateUserState()
        {
            switch(_userState)
            {
                case BankUserState.USER_NOT_LOGGED_IN:
                    _loginMenu.performLoginMenuOption(_menuPrompt(_loginMenu), _userAccnts);
                    if(_loginMenu.LoginSuccess)
                    {
                        _displayLoginSuccessText();
                        _userState = BankUserState.USER_LOGGED_IN;
                    }else if (_loginMenu.LoginFail)
                    {
                        _displayLoginFailText();
                        _userState = BankUserState.USER_NOT_LOGGED_IN;
                    }
                    break;
                case BankUserState.USER_LOGGED_IN:
                    _userMenu.performUserMenuOption(_menuPrompt(_userMenu), _loginMenu.ActiveUser);
                    if(_userMenu.SwitchUser)
                    {
                        _userState = BankUserState.USER_NOT_LOGGED_IN;
                    }else
                    {
                        _userState = BankUserState.USER_LOGGED_IN;
                    }
                    break;
                default:
                    break;
            }
        }
        
        private String _menuPrompt(Menu menu)
        {
            _displayMenu(menu);
            return Console.ReadKey().Key.ToString();
        }

        private void _createAdminAccount(){
            UserAccount adminAccount = new UserAccount();
            adminAccount.UserId = "admin";
            adminAccount.UserPassword = "pass123";
            adminAccount.Balance = 9999.99f;
            _userAccnts.Add(adminAccount);
        }

        private void _displayWelcomeMsg(){
            Console.WriteLine(_welcomeMsg);
        }

        private void _displayIntroPrompt(){
            Console.WriteLine(_introPrompt);
        }

        private void _displayMenu(Menu menu){
            Console.WriteLine(menu.displayMenu());
        }

        private void _displayLoginSuccessText(){
            Console.WriteLine(_loginSuccessText);
        }

        private void _displayLoginFailText(){
            Console.WriteLine(_loginFailText);
        }
    }
}

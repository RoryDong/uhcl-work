using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount
{
    class LoginAction : BankAction
    {
        private List<UserAccount> _userAccnts = new List<UserAccount>();
        private UserAccount _validUser = new UserAccount();
        private bool _successfulLogin = false;

        public void performAction()
        {
            UserAccount user = _collectUserInfo();
            _validateUser(user);
        }

        public bool SuccessfulLogin
        {
            get
            {
                return _successfulLogin;
            }
            set
            {
                _successfulLogin = value;
            }
        }

        private void _validateUser(UserAccount user)
        {
            _successfulLogin = false;
            foreach(UserAccount user_accnt in _userAccnts)
            {
                if(user.UserId == user_accnt.UserId && user.UserPassword == user_accnt.UserPassword)
                {
                    _successfulLogin = true;
                    _validUser = user_accnt;
                }
            }
        }

        public List<UserAccount> UserAccounts
        {
            get
            {
                return _userAccnts;
            }
            set
            {
                _userAccnts = value;
            }
        }

        public UserAccount ValidUser
        {
            get
            {
                return _validUser;
            }
            set
            {
            }
        }

        private UserAccount _collectUserInfo()
        {
            UserAccount user_account = new UserAccount();
            user_account.UserId = _collectUserId();
            user_account.UserPassword = _collectUserPassword();
            return user_account;
        }

        private String _collectUserId()
        {
            Console.WriteLine("Please enter your user ID: ");
            return Console.ReadLine();
        }

        private String _collectUserPassword()
        {
            Console.WriteLine("Please enter your password: ");
            return Console.ReadLine();
        }

    }
}

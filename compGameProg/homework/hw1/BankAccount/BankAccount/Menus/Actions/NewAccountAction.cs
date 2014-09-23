using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccount
{
    class NewAccountAction : BankAction
    {
        private List<UserAccount> _userAccnts = new List<UserAccount>();
        private UserAccount _validUser = new UserAccount();

        public void performAction()
        {
            Console.WriteLine("Creating a new user account. Follow the steps below. ");
            _createNewUser();
        }

        private bool _validateAccnt(UserAccount newUser)
        {
            foreach(UserAccount existingUsers in _userAccnts)
            {
                if(newUser.UserId == existingUsers.UserId)
                {
                    return false;
                }
            }
            return true;
        }

        private void _createNewUser()
        {
            UserAccount newAccount = new UserAccount();
            newAccount.UserId = _collectNewUserId();
            newAccount.UserPassword = _collectNewUserPw();
            newAccount.Balance = 0.0f;
            if (_validateAccnt(newAccount))
            {
                _userAccnts.Add(newAccount);
                Console.WriteLine("******** NEW ACCOUNT CREATED! ********");
            }
            else
            {
                Console.WriteLine("******** AN ACCOUNT WITH THAT USERNAME ALREADY EXISTS! ********");
            }
        }

        private String _collectNewUserId()
        {
            Console.WriteLine("Enter your desired user ID: ");
            return Console.ReadLine();
        }

        private String _collectNewUserPw()
        {
            Console.WriteLine("Enter your desired password: ");
            return Console.ReadLine();
        }

        public List<UserAccount> UserAccounts
        {
            set
            {
                _userAccnts = value;
            }
        }
    }
}

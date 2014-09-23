using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class UserAccount
    {
        private float _balance;
        private String _userId;
        private String _userPw;

        public float Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        public String UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public String UserPassword
        {
            get { return _userPw; }
            set { _userPw = value; }
        }
    }
}

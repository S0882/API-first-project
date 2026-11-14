using System;
using System.Collections.Generic;
//fix: removed the duplicate using lines
using System.Text;
using Zxcvbn;

namespace Services
{
    public class PasswordService
    {
        public int Post( string password)
        {
             return Zxcvbn.Core.EvaluatePassword(password).Score;
           
        }
    }
}

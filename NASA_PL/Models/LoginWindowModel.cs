using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NASA_BL;

namespace NASA_PL.Models
{
    class LoginWindowModel
    {
        BL bl;

        public LoginWindowModel()
        {
            bl = new BL();
        }

        public bool CheckUserAndPassword(string user, string password)
        {
            return bl.CheckUserAndPassword(user, password);
        }

    }

}
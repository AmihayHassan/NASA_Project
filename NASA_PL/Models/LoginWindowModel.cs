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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_BE
{
    public class User: IRecord
    {
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Models
{
    class User
    {
        
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string[] Interests { get; set; }
        public string[] Following { get; set; }
        public string[] Followers { get; set; }
        public string[] Posts { get; set; }
        public string[] Comments { get; set; }

    }
}

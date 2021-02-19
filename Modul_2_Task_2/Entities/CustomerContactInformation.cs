using System;
using System.Collections.Generic;
using System.Text;

namespace Modul_2_Practice_1.Entities
{
    public class CustomerContactInformation
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public Country Country { get; set; }
    }
}

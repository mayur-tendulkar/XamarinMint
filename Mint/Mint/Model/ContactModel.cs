using System;
using System.Collections.Generic;
using System.Text;

namespace Mint.Model
{
    public class ContactModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> Emails { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public string ReferredBy { get; set; }
        public bool ContactedYet { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}

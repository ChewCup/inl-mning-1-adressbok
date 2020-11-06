using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inlämning_1_adressbok.Contacts
{
    public class ContactList
    {
        // Källa: https://www.youtube.com/watch?v=cp19RhiHHok&ab_channel=DaniKrossing
        public string Name, Address, Phone, Mail;
        public ContactList(string name, string address, string phone, string mail)
        {
            this.Name = name; this.Address = address; this.Phone = phone; this.Mail = mail;
        }
    }
}

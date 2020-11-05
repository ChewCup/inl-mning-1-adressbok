using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using inlämning_1_adressbok.Contacts;

namespace inlämning_1_adressbok
{
    class Program
    {

        static void Main(string[] args)
        {
            // declare
            string command = "";
            string filepath;
            List<ContactList> contact = new List<ContactList>();
            Console.WriteLine("****Commands****\nType 'add' to add new contact to your list.\nType 'show' to show your contact list.\n" +
                "Type 'remove' to remove contact from list.\nType 'save' to save and update your contact list file.\nType 'quit' to exit the program.\n");
            filepath = @"C:\Users\vikke\Desktop\AdressLista.txt";
            // Källa: https://www.c-sharpcorner.com/UploadFile/mahesh/how-to-read-a-text-file-in-C-Sharp/
            // Read file using StreamReader. Reads file line by line
            Console.WriteLine("---- Your contactlist ----");
            using (StreamReader textlines = new StreamReader(filepath))
            {
                string line;
                // Källa: https://stackoverflow.com/questions/16725848/how-to-split-text-into-words
                while ((line = textlines.ReadLine()) != null)
                {
                    string[] words = line.Split(' '); //string[] words = line.Split(new char[] { ' ' }, StringSplitOptions.None);
                    contact.Add(new ContactList(words[0], words[1], words[2], words[3]));
                }
                textlines.Close();
            }
            Console.WriteLine("{0,-20}{1,-25}{2,-25}{3,-25}",
                              "Name", "Address", "Phone", "Mail");
            for (int i = 0; i < contact.Count(); i++)
            {
                if (contact[i] != null)
                {
                    Console.WriteLine("{0,-20}{1,-25}{2,-25}{3,-25}",
                                      contact[i].Name, contact[i].Address, contact[i].Phone, contact[i].Mail);
                }
            }
            Console.WriteLine("--------------------------");
            do
            {
                Console.Write(">");
                command = Console.ReadLine().ToLower();
                if (command == "add")
                {
                    Console.Write("Name of your contact: ");
                    string name = Console.ReadLine();
                    Console.Write("The address: ");
                    string address = Console.ReadLine();
                    Console.Write("The Phone number: ");
                    string phone = Console.ReadLine();
                    Console.Write("The E-mail: ");
                    string mail = Console.ReadLine();
                    contact.Add(new ContactList(name, address, phone, mail));
                }
                else if (command == "show")
                {
                    Console.WriteLine("{0,-20}{1,-25}{2,-25}{3,-25}",
                              "Name", "Address", "Phone", "Mail");
                    Console.WriteLine("--------------------------");
                    for (int i = 0; i < contact.Count(); i++)
                    {
                        if (contact[i] != null)
                        {
                            Console.WriteLine("{0,-20}{1,-25}{2,-25}{3,-25}",
                                      contact[i].Name, contact[i].Address, contact[i].Phone, contact[i].Mail);
                        }
                    }
                    Console.WriteLine("--------------------------");
                }
                else if (command == "remove")
                {
                    Console.Write("Type in the persons name to remove contact: ");
                    string name = Console.ReadLine().ToLower();
                    for (int i = 0; i < contact.Count; i++)
                    {
                        if (name == contact[i].Name.ToLower())
                        {
                            Console.WriteLine($"Removed {name} from contact list");
                            contact.RemoveAt(i);
                        }
                    }
                }
                else if (command == "save")
                {
                    Console.Write("Saved and updated your contact list file!");
                    using (StreamWriter overwriter = new StreamWriter(filepath))
                    {
                        for (int i = 0; i < contact.Count(); i++)
                        {
                            overwriter.WriteLine("{0} {1} {2} {3}", contact[i].Name, contact[i].Address, contact[i].Phone, contact[i].Mail);
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Unknown command: {command}");
                }

            } while (true);
        }
    }
}

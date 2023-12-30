using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Newtonsoft.Json;

namespace Contact_Management
{
    class Program
    {
        static void Main()
        {
            ContactManager contactManager = new ContactManager();
            contactManager.LoadContacts(); // Ladda befintliga kontakter vid uppstart

            while (true)
            {
                Console.WriteLine("\tVälj ett av alternativen nedanför.\n");
                Console.WriteLine("\t1. Lägg till kontakt");
                Console.WriteLine("\t2. Lista alla kontakter");
                Console.WriteLine("\t3. Visa detaljerad information om en kontakt");
                Console.WriteLine("\t4. Ta bort kontakt");
                Console.WriteLine("\t5. Avsluta");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        contactManager.AddContact();
                        break;
                    case 2:
                        contactManager.ListAllContacts();
                        break;
                    case 3:
                        contactManager.ShowContactDetails();
                        break;
                    case 4:
                        contactManager.RemoveContact();
                        break;
                    case 5:
                        contactManager.SaveContacts(); // Spara kontakter innan avslut
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\tOgiltigt val. Försök igen.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }

    /// <summary>
    /// Hanterar kontakter och dess funktioner.
    /// </summary>
    public class ContactManager
    {
        private List<Contact> contacts = new List<Contact>();
        private string filePath = "contacts.json";

        /// <summary>
        /// Laddar befintliga kontakter från filen.
        /// </summary>
        public void LoadContacts()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
            }
        }

        /// <summary>
        /// Sparar kontakter till filen.
        /// </summary>
        public void SaveContacts()
        {
            string json = JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Lägger till en ny kontakt.
        /// </summary>
        public void AddContact()
        {
            Console.WriteLine("\n\tLägg till ny kontakt:\n");

            Contact newContact = new Contact();

            Console.Write("\tFörnamn: ");
            newContact.FirstName = Console.ReadLine();

            Console.Write("\tEfternamn: ");
            newContact.LastName = Console.ReadLine();

            Console.Write("\tTelefonnummer: ");
            newContact.PhoneNumber = Console.ReadLine();

            Console.Write("\tE-postadress: ");
            newContact.Email = Console.ReadLine();

            Console.Write("\tAdress: ");
            newContact.Address = Console.ReadLine();

            contacts.Add(newContact);

            Console.WriteLine("\n\tKontakt tillagd!\n");
        }

        /// <summary>
        /// Listar upp alla kontakter.
        /// </summary>
        public void ListAllContacts()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("\tAlla kontakter:\n");

            foreach (var contact in contacts)
            {
                Console.WriteLine($"\tEmail: {contact.Email}");
            }
            Console.WriteLine("-------------------------------------\n");

        }

        /// <summary>
        /// Visar detaljerad information om en kontakt.
        /// </summary>
        public void ShowContactDetails()
        {
            Console.WriteLine("\n\tAnge e-postadress för den kontakt du vill visa detaljer för:");
            string inputEmail = Console.ReadLine();

            Contact contactToShow = contacts.Find(contact => contact.Email == inputEmail);

            if (contactToShow != null)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"\tDetaljer för kontakt med e-postadress {inputEmail}:\n");
                Console.WriteLine($"\tFörnamn: {contactToShow.FirstName}");
                Console.WriteLine($"\tEfternamn: {contactToShow.LastName}");
                Console.WriteLine($"\tTelefonnummer: {contactToShow.PhoneNumber}");
                Console.WriteLine($"\tE-postadress: {contactToShow.Email}");
                Console.WriteLine($"\tAdress: {contactToShow.Address}");
                Console.WriteLine("-------------------------------------");

            }
            else
            {
                Console.WriteLine($"\tIngen kontakt med e-postadress {inputEmail} hittades.\n");
            }
        }

        /// <summary>
        /// Tar bort en kontakt med hjälp av e-postadress.
        /// </summary>
        public void RemoveContact()
        {
            Console.WriteLine("Ange e-postadress för den kontakt du vill ta bort:");
            string inputEmail = Console.ReadLine();

            Contact contactToRemove = contacts.Find(contact => contact.Email == inputEmail);

            if (contactToRemove != null)
            {
                contacts.Remove(contactToRemove);
                Console.WriteLine($"\tKontakt med e-postadress {inputEmail} har tagits bort.\n");
            }
            else
            {
                Console.WriteLine($"\tIngen kontakt med e-postadress {inputEmail} hittades.\n");
            }
        }
    }

    /// <summary>
    /// Representerar en kontakt.
    /// </summary>
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}

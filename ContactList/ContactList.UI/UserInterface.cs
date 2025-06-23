using ContactList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.UI
{
    public class UserInterface
    {
        private UserIO userIO;

        public UserInterface()
        {
            userIO = new UserIO();
        }

        public int ShowMenuAndGetUserChoice() 
        {
            Console.WriteLine("\nEnter a choice from the menu: ");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Show all Contacts");
            Console.WriteLine("3. Look up Contact");
            Console.WriteLine("4. Edit Contact");
            Console.WriteLine("5. Remove Contact");
            Console.WriteLine("6. Exit App");
            int userChoice = userIO.ReadInt("Enter your choice: ",1,6);

            return userChoice;
        }

        public Contact GetNewContactInformation()
        {
            Contact contact = new Contact();

            contact.FirstName = userIO.ReadString("\nEnter the first name: ");
            contact.LastName = userIO.ReadString("\nEnter the last name: ");
            contact.Email = userIO.ReadString("\nEnter the email address: ");
            contact.PhoneNumber = userIO.ReadString("\nEnter the phone number: ");

            return contact;
        }


        public void DisplayContact(Contact contact) 
        {
            Console.WriteLine($"\nContact Id:    {contact.ContactId}");
            Console.WriteLine($"  First Name:    {contact.FirstName}");
            Console.WriteLine($"   Last Name:    {contact.LastName}");
            Console.WriteLine($"       Email:    {contact.Email}");
            Console.WriteLine($"Phone Number:    {contact.PhoneNumber}");
        }

        
        public void ShowActionSuccess(string actionName)
        {
            Console.WriteLine($"\n{actionName} executed successfully!");
        }

        public void ShowActionFailure(string actionName)
        {
            Console.WriteLine($"\n{actionName} failed to execute properly!");
        }
    }
}

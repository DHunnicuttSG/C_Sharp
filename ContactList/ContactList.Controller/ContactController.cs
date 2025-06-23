using ContactList.Data;
using ContactList.Models;
using ContactList.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Controller
{
    public class ContactController
    {
        private UserInterface userInterface;
        private ContactRepository repository;

        public ContactController()
        {
            userInterface = new UserInterface();
            repository = new ContactRepository();
        }

        public void Run()
        {
            bool keepRunning = true;

            while (keepRunning)
            {
                int menuChoice = userInterface.ShowMenuAndGetUserChoice();

                switch (menuChoice)
                {
                    case 1:
                        AddContact();
                        break;
                    case 2:
                        ShowAllContacts();
                        break;
                    case 3:
                        ShowContactById();
                        break;
                    case 4:
                        EditContactById();
                        break;
                    case 5:
                        DeleteContactById();
                        break;
                    case 6:
                        keepRunning = false;
                        break;
                }
            }
        } // end of Run method

        private void AddContact()
        {
            Contact newContact = userInterface.GetNewContactInformation();
            Contact addedContact = repository.CreateContact(newContact);

            if (addedContact != null)
            {
                userInterface.DisplayContact(addedContact);
                userInterface.ShowActionSuccess("Add Contact");
            }
            else
            {
                userInterface.ShowActionFailure("Add Contact");
            }
        }

        private void ShowAllContacts()
        {
            Contact[] contacts = repository.GetAllContacts();
            foreach (Contact contact in contacts)
            {
                if (contact != null)
                {
                    userInterface.DisplayContact(contact);
                }
            }
        }

        private void ShowContactById()
        {
            UserIO userIO = new UserIO();
            int id = userIO.ReadInt("\nEnter in the contact id: ");
            repository.GetContactById(id);
        }

        private void EditContactById()
        {
            UserIO userIO = new UserIO();
            int id = userIO.ReadInt("\nEnter in the contact id: ");
            Contact retreivedContact = repository.GetContactById(id);
            Contact newContact = userInterface.GetNewContactInformation();
            newContact.ContactId = id;
            repository.UpdateContact(newContact);
        }

        private void DeleteContactById()
        {
            UserIO userIO = new UserIO();
            int id = userIO.ReadInt("\nEnter in the contact id: ");
            repository.DeleteContactById(id);
        }
    }
}

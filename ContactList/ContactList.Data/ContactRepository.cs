using ContactList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ContactList.Data
{
    public class ContactRepository
    {
        Contact[] contacts;

        // Constructor
        public ContactRepository() 
        { 
            contacts = new Contact[10];

            Contact contact0 = new Contact();
            contact0.ContactId = 0;
            contact0.FirstName = "Bill";
            contact0.LastName = "Gates";
            contact0.PhoneNumber = "123-456-7890";
            contact0.Email = "Bill@microsoft.com";

            contacts[0] = contact0;

            Contact contact1 = new Contact();
            contact1.ContactId = 1;
            contact1.FirstName = "Elon";
            contact1.LastName = "Musk";
            contact1.PhoneNumber = "555-123-4567";
            contact1.Email = "Elon@Tesla.com";
            
            contacts[1] = contact1;
        }

        public Contact CreateContact(Contact contact)
        {
            for (int i = 0; i < contacts.Length; i++) 
            { 
                if (contacts[i] == null)
                {
                    contact.ContactId = i;
                    contacts[i] = contact;
                    return contact;
                }
            }
            // The array was full. Cannot add contact
            return null;
        }
        public Contact[] GetAllContacts() { 
            return contacts;
        }

        public Contact GetContactById(int contactId)
        {
            return contacts[contactId];
        }

        public void DeleteContactById(int contactId)
        {
            contacts[contactId] = null;
        }

        public Contact UpdateContact(Contact contact) 
        {
            DeleteContactById(contact.ContactId);
            Contact UpdatedContact = CreateContact(contact);
            return UpdatedContact;
        }


    }
}

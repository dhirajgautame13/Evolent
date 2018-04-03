using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Evolent.Api.Models;
using System.Data.Entity.Infrastructure;

namespace Evolent.Api.Context
{
    public class ContactRepository :IContactRepository
    {
        private DatabaseContext db = new DatabaseContext();

        public void Update(Contact updatedContact)
        {
            var contact = this.Get(updatedContact.ContactID);
            contact.FirstName = updatedContact.FirstName;
            contact.LastName = updatedContact.LastName;
            contact.Email = updatedContact.Email;
            contact.PhoneNumber = updatedContact.PhoneNumber;
            contact.Status = updatedContact.Status;
       
            db.SaveChanges();
        }

        public Contact Get(int id)
        {
            Contact contact = db.Contacts.Find(id);
            return contact;
        }

        public IQueryable<Contact> GetAll()
        {
            return db.Contacts;
        }

        public void Post(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
        }

        public Contact Delete(int id)
        {
            Contact contact = Get(id);
            if (contact == null)
            {
                return null;
            }

            db.Contacts.Remove(contact);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }

            return contact;
        }
    }
}
using Evolent.Api.Context;
using Evolent.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Evolent.Api.Controllers
{
    public class ContactController : ApiController
    {
        private readonly IContactRepository repository;

        public ContactController(IContactRepository repository)
        {
            this.repository = repository;
        }

        //Creating a method to return Json data   
        /// <summary>
        /// Get all contacts.
        /// </summary>
        /// <returns></returns>
        [Queryable]
        [HttpGet]

        public IEnumerable<Contact> Get()
        {
            return this.repository.GetAll();
            //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned 
        }

        /// <summary>
        /// Get contact by ID.
        /// </summary>
        /// <param name="id">Contact ID</param>
        /// <returns>The contact with the specified ID</returns>
        public Contact Get(int id)
        {
            var contact = this.repository.Get(id);
            if (contact == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return contact;
        }


        /// <summary>
        /// Add a new contact.
        /// </summary>
        /// <param name="contact">Contact to add.</param>
        /// <returns>The added contact</returns>
        public HttpResponseMessage Post(Contact contact)
        {
            if (this.ModelState.IsValid)
            {
                this.repository.Post(contact);
                var response = Request.CreateResponse<Contact>(HttpStatusCode.Created, contact);
                response.Headers.Location = GetContactLocation(contact.ContactID);
                return response;
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        Uri GetContactLocation(int contactId)
        {
            var controller = this.Request.GetRouteData().Values["controller"];
            return new Uri(this.Url.Link("DefaultApi", new { controller = controller, id = contactId }));
        }

        /// <summary>
        /// Update an existing contact.
        /// </summary>
        /// <param name="id">Contact ID.</param>
        /// <param name="contact">Contact update.</param>
        /// <returns>the updated contact.</returns>
        public Contact Put(int id, Contact contact)
        {
            contact.ContactID = id;
            this.repository.Update(contact);
            return contact;
        }

        /// <summary>
        /// Delete a contact.
        /// </summary>
        /// <param name="id">Contact ID.</param>
        /// <returns>The deleted contact.</returns>
        public Contact Delete(int id)
        {
            var deleted = this.repository.Get(id);
            if (deleted == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            this.repository.Delete(id);
            return deleted;
        }


    }
}

using RestAPICourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPICourse.Controllers
{
    [RoutePrefix("api/Contact")]
    public class ContactController : ApiController
    {
        Contact[] contacts = new Contact[]
        {
            new Contact()
            {
                Id = 0, FirstName = "Sai", LastName="Srivatsan"
            },
            new Contact()
            {
                Id = 1, FirstName = "Sindhu", LastName="Sai"
            },
            new Contact()
            {
                Id = 2, FirstName="Tejas", LastName="Krishnan"
            }
        };
        // GET: api/Contact
        [Route("")]
        public IEnumerable<Contact> Get()
        {
            return contacts;
        }

        // GET: api/Contact/5
        [Route("{id:int}")]
        public Contact Get(int id)
        {
            Contact contact = contacts.FirstOrDefault(c => c.Id == id);
            if(contact != null)
            {
                return contact;
            }
            else
            {
                return null;
            }
        }

        [Route("{lastName}")]
        public IEnumerable<Contact> GetContactsByName(string lastName)
        {
            Contact[] resultSet = contacts.Where(x => x.LastName == lastName).ToArray();
            return resultSet;
        }



        // POST: api/Contact
        [Route("")]
        public IHttpActionResult Post([FromBody]Contact contact)
        {
            if (contact != null)
            {
                List<Contact> contactList = contacts.ToList();
                contactList.Add(contact);
                contacts = contactList.ToArray();
                return Ok(contacts);
            }
            else
            {
                throw new ArgumentException("Invalid contact. The contact that you attempted to add cannot be null");
            }
        }

        // PUT: api/Contact/5
        [Route("{id:int}")]
        public IHttpActionResult Put(int id, [FromBody]Contact c)
        {
            Contact contact = contacts.FirstOrDefault(x => x.Id == id);
            if (contact != null)
            {
                contact.FirstName = c.FirstName;
                contact.LastName = c.LastName;
                return Ok(contacts);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Contact/5
        [Route("{id:int}")]
        public IEnumerable<Contact> Delete(int id)
        {
            return contacts = contacts.Where(x => x.Id != id).ToArray();
        }
    }
}

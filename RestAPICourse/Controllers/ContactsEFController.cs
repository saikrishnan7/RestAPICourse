using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using RestAPICourse.Models;

namespace RestAPICourse.Controllers
{
    [RoutePrefix("api/ContactEF")]
    public class ContactsEFController : ApiController
    {
        private RestAPICourseContext db = new RestAPICourseContext();

        // GET: api/ContactsEF
        [Route("")]
        public IQueryable<Contact> GetContacts()
        {
            return db.Contacts;
        }

        // GET: api/ContactsEF/5
        [ResponseType(typeof(Contact))]
        [Route("{id:int}")]
        public IHttpActionResult GetContact(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        // PUT: api/ContactsEF/5
        [ResponseType(typeof(void))]
        [Route("{id:int}")]
        public IHttpActionResult PutContact(int id, Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.Id)
            {
                return BadRequest();
            }

            db.Entry(contact).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                return Ok(contact);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/ContactsEF
        [ResponseType(typeof(Contact))]
        [Route("")]
        public IHttpActionResult PostContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contacts.Add(contact);
            db.SaveChanges();

            return Ok(contact);
        }

        // DELETE: api/ContactsEF/5
        [ResponseType(typeof(Contact))]
        [Route("{id:int}")]
        public IHttpActionResult DeleteContact(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return NotFound();
            }

            db.Contacts.Remove(contact);
            db.SaveChanges();

            return Ok(contact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactExists(int id)
        {
            return db.Contacts.Count(e => e.Id == id) > 0;
        }
    }
}
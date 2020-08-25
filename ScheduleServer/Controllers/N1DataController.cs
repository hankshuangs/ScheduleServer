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
using ScheduleServer.Models;

namespace ScheduleServer.Controllers
{
    public class N1DataController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/N1Data
        public IQueryable<N1Data> GetN1Data()
        {
            return db.N1Data;
        }

        // GET: api/N1Data/5
        [ResponseType(typeof(N1Data))]
        public IHttpActionResult GetN1Data(int id)
        {
            N1Data n1Data = db.N1Data.Find(id);
            if (n1Data == null)
            {
                return NotFound();
            }

            return Ok(n1Data);
        }

        // PUT: api/N1Data/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutN1Data(int id, N1Data n1Data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != n1Data.Id)
            {
                return BadRequest();
            }

            db.Entry(n1Data).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!N1DataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/N1Data
        [ResponseType(typeof(N1Data))]
        public IHttpActionResult PostN1Data(N1Data n1Data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.N1Data.Add(n1Data);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = n1Data.Id }, n1Data);
        }

        // DELETE: api/N1Data/5
        [ResponseType(typeof(N1Data))]
        public IHttpActionResult DeleteN1Data(int id)
        {
            N1Data n1Data = db.N1Data.Find(id);
            if (n1Data == null)
            {
                return NotFound();
            }

            db.N1Data.Remove(n1Data);
            db.SaveChanges();

            return Ok(n1Data);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool N1DataExists(int id)
        {
            return db.N1Data.Count(e => e.Id == id) > 0;
        }
    }
}
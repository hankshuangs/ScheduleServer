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
    public class A1DataController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/A1Data
        public IQueryable<A1Data> GetA1Data()
        {
            return db.A1Data;
        }

        // GET: api/A1Data/5
        [ResponseType(typeof(A1Data))]
        public IHttpActionResult GetA1Data(int id)
        {
            A1Data a1Data = db.A1Data.Find(id);
            if (a1Data == null)
            {
                return NotFound();
            }

            return Ok(a1Data);
        }

        // PUT: api/A1Data/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutA1Data(int id, A1Data a1Data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != a1Data.Id)
            {
                return BadRequest();
            }

            db.Entry(a1Data).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!A1DataExists(id))
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

        // POST: api/A1Data
        [ResponseType(typeof(A1Data))]
        public IHttpActionResult PostA1Data(A1Data a1Data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.A1Data.Add(a1Data);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = a1Data.Id }, a1Data);
        }

        // DELETE: api/A1Data/5
        [ResponseType(typeof(A1Data))]
        public IHttpActionResult DeleteA1Data(int id)
        {
            A1Data a1Data = db.A1Data.Find(id);
            if (a1Data == null)
            {
                return NotFound();
            }

            db.A1Data.Remove(a1Data);
            db.SaveChanges();

            return Ok(a1Data);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool A1DataExists(int id)
        {
            return db.A1Data.Count(e => e.Id == id) > 0;
        }
    }
}
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
    public class A2DataController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/A2Data
        public IQueryable<A2Data> GetA2Data()
        {
            return db.A2Data;
        }

        // GET: api/A2Data/5
        [ResponseType(typeof(A2Data))]
        public IHttpActionResult GetA2Data(int id)
        {
            A2Data a2Data = db.A2Data.Find(id);
            if (a2Data == null)
            {
                return NotFound();
            }

            return Ok(a2Data);
        }

        // PUT: api/A2Data/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutA2Data(int id, A2Data a2Data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != a2Data.Id)
            {
                return BadRequest();
            }

            db.Entry(a2Data).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!A2DataExists(id))
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

        // POST: api/A2Data
        [ResponseType(typeof(A2Data))]
        public IHttpActionResult PostA2Data(A2Data a2Data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.A2Data.Add(a2Data);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = a2Data.Id }, a2Data);
        }

        // DELETE: api/A2Data/5
        [ResponseType(typeof(A2Data))]
        public IHttpActionResult DeleteA2Data(int id)
        {
            A2Data a2Data = db.A2Data.Find(id);
            if (a2Data == null)
            {
                return NotFound();
            }

            db.A2Data.Remove(a2Data);
            db.SaveChanges();

            return Ok(a2Data);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool A2DataExists(int id)
        {
            return db.A2Data.Count(e => e.Id == id) > 0;
        }
    }
}
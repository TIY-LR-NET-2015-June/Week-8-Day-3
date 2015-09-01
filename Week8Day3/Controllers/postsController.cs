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
using Week8Day3.Models;

namespace Week8Day3.Controllers
{
    public class postsController : ApiController
    {
        private postdbcontext db = new postdbcontext();

        // GET: api/posts
        public IQueryable<post> GetPosts()
        {
            return db.Posts;
        }

        // GET: api/posts/5
        [ResponseType(typeof(post))]
        public IHttpActionResult Getpost(int id)
        {
            post post = db.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // PUT: api/posts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpost(int id, post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != post.Id)
            {
                return BadRequest();
            }

            db.Entry(post).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!postExists(id))
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

        // POST: api/posts
        [ResponseType(typeof(post))]
        public IHttpActionResult Postpost(post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Posts.Add(post);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = post.Id }, post);
        }

        // DELETE: api/posts/5
        [ResponseType(typeof(post))]
        public IHttpActionResult Deletepost(int id)
        {
            post post = db.Posts.Find(id);
            if (post == null)
            {
                return NotFound();
            }

            db.Posts.Remove(post);
            db.SaveChanges();

            return Ok(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool postExists(int id)
        {
            return db.Posts.Count(e => e.Id == id) > 0;
        }
    }
}
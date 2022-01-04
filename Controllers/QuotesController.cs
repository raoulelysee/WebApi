using QuotesApi.Data;
using QuotesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuotesApi.Controllers
{
    public class QuotesController : ApiController
    {
        QuotesDbContext quotesDbContext = new QuotesDbContext();
        // GET: api/Quotes
        public IHttpActionResult Get()
        {
            var quote = quotesDbContext.Quotes;
            return Ok(quote);
        }

        // GET: api/Quotes/5
        public IHttpActionResult Get(int id)
        {
            var quote = quotesDbContext.Quotes.Find(id);

            return Ok(quote);
        }

        // POST: api/Quotes
        public IHttpActionResult Post([FromBody] Quote quote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            quotesDbContext.Quotes.Add(quote);
            quotesDbContext.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }

        // PUT: api/Quotes/5-
        public IHttpActionResult Put(int id, [FromBody] Quote quote)
        {
            var entity = quotesDbContext.Quotes.FirstOrDefault(q => q.Id == id);
            if(entity == null)
            {
                return BadRequest("No record has been found for thid Id.");
            }
            entity.Title = quote.Title;
            entity.Author = quote.Author;
            entity.Description = quote.Description;
            quotesDbContext.SaveChanges();
            return Ok("Record updated successfully.");
        }

        // DELETE: api/Quotes/5
        public IHttpActionResult Delete(int id)
        {
            var quote = quotesDbContext.Quotes.Find(id);
            if (quote == null)
            {
                return BadRequest("No record has been found for this Id.");
            }
            quotesDbContext.Quotes.Remove(quote);
            quotesDbContext.SaveChanges();
            return Ok("Record deleted.");
        }
    }
}

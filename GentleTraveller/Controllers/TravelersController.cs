using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoDB.Driver;
using GentleTraveller.Models;
using System.Threading.Tasks;
using GentleTraveller.Repository;

namespace GentleTraveller.Controllers
{
    public class TravelersController : ApiController
    {
        TravelerContext _travelerContext;
        public TravelersController()
        {
            _travelerContext = new TravelerContext();
        }
        // GET: api/Trips
        public IEnumerable<Traveler> Get()
        {
            IEnumerable<Traveler> travelers = TravelerRepository.Query(t => true);

            //using (var stravelers = _travelerContext.Travelers.Find(t => true).ToListAsync())
            //{
            //    stravelers.Wait();
            //    travelers = stravelers.Result;
            //}
            return travelers;
        }
        
        // GET: api/Trips/5
        public Traveler Get(string id)
        {
            using (var straveler = _travelerContext.Travelers.Find(t => t.Id == id).FirstOrDefaultAsync())
            {
                straveler.Wait();
                return straveler.Result;
            }
        }

        // POST: api/Trips
        public void Post([FromBody]Traveler newTravler)
        {
            var insertTask = _travelerContext.Travelers.InsertOneAsync(newTravler);
            insertTask.Wait();
        }

        //// PUT: api/Trips/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Trips/5
        //public void Delete(int id)
        //{
        //}
    }
}

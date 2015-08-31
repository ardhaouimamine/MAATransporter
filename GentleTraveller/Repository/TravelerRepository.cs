using GentleTraveller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TravelerDataProvider;

namespace GentleTraveller.Repository
{
    public class TravelerRepository
    {

        private static IDatabase<Traveler> _db = new MongoDatabase<Traveler>("travelers", "mongodb", "gentletravelerdb");

        public static Traveler Spawn()
        {
            Traveler t = new Traveler() { FirstName = "TestNom", LastName = "TestPrenom", Email = "t1@yopmail.com" };
            _db.Add(t);
            return t;
        }

        public static bool Remove(Traveler t)
        {
            return _db.Delete(t);
        }

        public static void Add(Traveler t)
        {
            _db.Add(t);
        }

        public static IEnumerable<Traveler> Query(Expression<Func<Traveler, bool>> expression)
        {
            return _db.Where(expression).OrderBy(s => s.Id).ThenBy(s => s.LastName).AsEnumerable();
        }

        public static IEnumerable<Traveler> ToList()
        {
            return _db.Where(t => true).AsEnumerable();
        }
    }
}
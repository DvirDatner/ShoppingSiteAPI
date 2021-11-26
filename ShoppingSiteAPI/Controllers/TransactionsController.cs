using Microsoft.AspNetCore.Mvc;
using ShoppingSiteAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSiteAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Transactions> Get()
        {
            using (var context = new ShoppingSiteDBContext())
            {
                return context.Transactions.ToList();
            }
        }

        [HttpGet("pastfive")]
        public IEnumerable<Transactions> PastFive()
        {
            using (var context = new ShoppingSiteDBContext())
            {
                var list = context.Transactions.ToList();

                var fiveDaysAgoQuery = from t in list
                                       where t.Date.Day > DateTime.Today.AddDays(-5).Day
                                       select t;

                return fiveDaysAgoQuery.ToList();
            }
        }

        [HttpPost]
        public IEnumerable<Transactions> Post(Transactions transaction)
        {
            using (var context = new ShoppingSiteDBContext())
            {
                context.Transactions.Add(transaction);

                context.SaveChanges();

                return context.Transactions.ToList();
            }
        }
    }
}

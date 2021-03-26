using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Api.Model;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Api.Controllers
{
    public class DapperTestController : BaseController
    {

        private readonly Database _options;
        public DapperTestController(IOptionsMonitor<Database> options)
        {
            _options = options.CurrentValue;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetSample()
        {
            using (var db = new SqlConnection(_options.ConnectionStrings))
            {
                var results = await db.QueryAsync<Customer>("Select * From Customers");
                return results.ToList();
            }
        }

    }
}
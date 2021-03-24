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
        private readonly IConfiguration _configuration;

        public DapperTestController(IConfiguration configuration, IOptionsMonitor<Database> options)
        {
            _configuration = configuration;
            _options = options.CurrentValue;
        }

        [HttpGet]
        public async Task<ActionResult<List<Sample>>> GetSample()
        {
            using (var db = new SqlConnection(_options.ConnectionStrings))
            {
                var results = await db.QueryAsync<Sample>("Select * From Customers");
                return results.ToList();
            }
        }
    }
}
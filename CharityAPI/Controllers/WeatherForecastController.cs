using CharityAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace CharityAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<TestModel> Get()
        {
            List<TestModel> list1 = new List<TestModel>();
            string conn = ConfigurationManager.ConnectionStrings["ConnectionStringToCharity"].ConnectionString;
            MySqlConnection mySql = new MySqlConnection(conn);
            string query = "select * from test";
            MySqlCommand com = new MySqlCommand(query);
            com.Connection = mySql;
            mySql.Open();
            MySqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                list1.Add(new TestModel
                {
                    test = dr["test"].ToString()
                });
            }
            mySql.Close();
            return list1;
        }
    }
}

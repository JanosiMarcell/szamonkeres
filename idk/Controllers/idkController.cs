using idk.Model;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using static idk.DTO.Dto;

namespace idk.Controllers
{
    [Route("idk")]
    [ApiController]
    public class idkController : ControllerBase
    {
        private Connect conn = new();

        [HttpGet]
        public List<Targy> Get()
        {
            List<Targy> targyak = new();
            string sql = "SELECT * FROM meanstokys";

            conn.Connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            reader.Read();

            do
            {
                var result = new Targy
                {
                    Id = reader.GetGuid(0),
                    targy = reader.GetString(1),
                    ar = reader.GetInt32(2),
                };

                targyak.Add(result);
            }
            while (reader.Read());

            conn.Connection.Close();

            return targyak;
        }
        [HttpPost]
        public ActionResult<Targy> Post(CreateTargyDto targyak)
        {
            var result = new Targy
            {
                Id = Guid.NewGuid(),
                targy = targyak.targy,
                ar = targyak.ar,
            };
            string sql = $"INSERT INTO `meanstokys`(`id`, `targy`, `ar`) VALUES ('{result.Id}','{result.targy}','{result.ar}'";
            conn.Connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            conn.Connection.Close();
            return StatusCode(281, result);
        }

        [HttpPut]
        public ActionResult<Targy> Put(CreateTargyDto targyak)
        {
            var result = new Targy
            {
                Id = Guid.NewGuid(),
                targy = targyak.targy,
                ar = targyak.ar,
            };
            string sql = $"UPDATE `meanstokys` SET `id`='{result.Id}',`targy`='{result.targy}',`ar`='{result.ar}'";
            conn.Connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            conn.Connection.Close();
            return StatusCode(281, result);
        }



    }
}

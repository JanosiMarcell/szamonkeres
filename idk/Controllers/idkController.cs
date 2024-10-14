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
                    Azon = reader.GetGuid(0),
                    Jegy = reader.GetInt32(1),
                    Leiras = reader.GetString(2),
                    Letrehozas=reader.GetDateTime(3),   
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
                Azon = Guid.NewGuid(),
                Jegy = targyak.Jegy,
                Leiras = targyak.Leiras,
                Letrehozas=targyak.Letrehozas,
            };
            string sql = $"INSERT INTO `meanstokys`(`Azon`, `Jegy`, `Leiras`, `Letrehozas`) VALUES ('{result.Azon}','{result.Jegy}','{result.Leiras}','{result.Letrehozas}')";
            conn.Connection.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            conn.Connection.Close();
            return StatusCode(281, result);
        }

        [HttpPut]
        public ActionResult<Targy> Put(UpdateTargyDto targyak)
        {
            var result = new Targy
            {
                Azon = Guid.NewGuid(),
                Jegy = targyak.Jegy,
                Leiras = targyak.Leiras,
                Letrehozas = targyak.Letrehozas,
            };
            string sql = $"UPDATE `meanstokys` SET `Azon`='{result.Azon}',`Jegy`='{result.Jegy}',`Leiras`='{result.Leiras}',`Letrehozas`='{result.Letrehozas}'";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            conn.Connection.Close();
            return StatusCode(281, result);
        }

    }
}

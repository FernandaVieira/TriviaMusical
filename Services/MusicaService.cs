using TriviaMusical.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TriviaMusical.Services
{
    public class MusicaService
    {
        private readonly string _connectionString;

        public MusicaService(IConfiguration connectionString)
        {
            _connectionString = connectionString.GetConnectionString("TriviaMusicalDB");
        }

        public Musica ObterMusicaAleatoria()
        {
            string query = "SELECT TOP 1 IdMusica, NomeDoCantor, AnoLancamento, NomeDaMusica FROM Musicas ORDER BY NEWID()";
            Musica musica = new Musica();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    musica.IdMusica = reader["IdMusica"].ToString();
                    musica.NomeDoCantor = reader["NomeDoCantor"].ToString();
                    musica.AnoLancamento = Convert.ToInt32(reader["AnoLancamento"]);
                    musica.NomeMusica = reader["NomeDaMusica"].ToString();
                }
            }

            return musica;
        }
    }
}

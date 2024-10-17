using TriviaMusical.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TriviaMusical.Services
{
    public class MusicaService
    {
        private readonly string _connectionString;
        private List<Musica> _listaMusicasTemporaria = new List<Musica>(); // Lista temporária de músicas
        private Random _random = new Random();

        public MusicaService(IConfiguration connectionString)
        {
            _connectionString = connectionString.GetConnectionString("TriviaMusicalDB");
            CarregarMusicas();
        }

        public void CarregarMusicas()
        {
            string query = "SELECT IdMusica, NomeDoCantor, AnoLancamento, NomeDaMusica FROM Musicas";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Musica musica = new Musica
                    {
                        IdMusica = reader["IdMusica"].ToString(),
                        NomeDoCantor = reader["NomeDoCantor"].ToString(),
                        AnoLancamento = Convert.ToInt32(reader["AnoLancamento"]),
                        NomeMusica = reader["NomeDaMusica"].ToString()
                    };

                    _listaMusicasTemporaria.Add(musica); // Adiciona cada música à lista temporária
                }
            }
        }
        public Musica ObterMusicaAleatoria()
        {
            if (_listaMusicasTemporaria.Count == 0)
            {
                return null; // Retorna null se não houver mais músicas disponíveis
            }

            int indexAleatorio = _random.Next(_listaMusicasTemporaria.Count); // Seleciona um índice aleatório
            Musica musicaSelecionada = _listaMusicasTemporaria[indexAleatorio]; // Obtém a música selecionada

            _listaMusicasTemporaria.RemoveAt(indexAleatorio); // Remove a música da lista temporária para evitar repetição

            return musicaSelecionada; // Retorna a música selecionada
        }
        public List<Musica> ObterMusicas()
        {
            return _listaMusicasTemporaria;
        }
    }
}
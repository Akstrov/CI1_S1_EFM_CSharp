using System.Data.SqlClient;
using efm_c_.Models;

namespace efm_c_.APIs
{
    internal class ClubApi
    {
        private readonly SqlConnection _connection;

        public ClubApi(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        // CRUD operations for Club
        public Club CreateClub(Club club)
        {
            _connection.Open();
            var commandText = "INSERT INTO club (nom, id_gerant, date_creation) VALUES (@Nom, @IdGerant, @DateCreation); SELECT SCOPE_IDENTITY();";
            using (var command = new SqlCommand(commandText, _connection))
            {
                command.Parameters.AddWithValue("@Nom", club.Nom);
                command.Parameters.AddWithValue("@IdGerant", club.IdGerant);
                command.Parameters.AddWithValue("@DateCreation", club.DateCreation);
                var newId = Convert.ToInt32(command.ExecuteScalar());
                club.Id = newId;
            }
            _connection.Close();
            return club;
        }

        public Club GetClub(int clubId)
        {
            _connection.Open();
            var commandText = "SELECT * FROM club WHERE id = @ClubId";
            using (var command = new SqlCommand(commandText, _connection))
            {
                command.Parameters.AddWithValue("@ClubId", clubId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Club
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Nom = reader.GetString(reader.GetOrdinal("nom")),
                            IdGerant = reader.IsDBNull(reader.GetOrdinal("id_gerant")) ? null : (int?)reader.GetInt32(reader.GetOrdinal("id_gerant")),
                            DateCreation = reader.GetDateTime(reader.GetOrdinal("date_creation"))
                        };
                    }
                }
            }
            _connection.Close();
            return null;
        }

        public void UpdateClub(Club club)
        {
            _connection.Open();
            var commandText = "UPDATE club SET nom = @Nom, id_gerant = @IdGerant, date_creation = @DateCreation WHERE id = @ClubId";
            using (var command = new SqlCommand(commandText, _connection))
            {
                command.Parameters.AddWithValue("@Nom", club.Nom);
                command.Parameters.AddWithValue("@IdGerant", club.IdGerant);
                command.Parameters.AddWithValue("@DateCreation", club.DateCreation);
                command.Parameters.AddWithValue("@ClubId", club.Id);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public void DeleteClub(int clubId)
        {
            _connection.Open();
            var commandText = "DELETE FROM club WHERE id = @ClubId";
            using (var command = new SqlCommand(commandText, _connection))
            {
                command.Parameters.AddWithValue("@ClubId", clubId);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }
    }
}

using System.Data.SqlClient;
using efm_c_.Models;

namespace efm_c_.APIs
{
    internal class EvenementApi
    {
        private readonly SqlConnection _connection;

        public EvenementApi(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        // CRUD operations for Evenement
        public Evenement CreateEvenement(Evenement evenement)
        {
            _connection.Open();
            var commandText = "INSERT INTO evenement (titre, description, id_club, date_debut, date_fin, status, prix) VALUES (@Titre, @Description, @IdClub, @DateDebut, @DateFin, @Status, @Prix); SELECT SCOPE_IDENTITY();";
            using (var command = new SqlCommand(commandText, _connection))
            {
                command.Parameters.AddWithValue("@Titre", evenement.Titre);
                command.Parameters.AddWithValue("@Description", evenement.Description);
                command.Parameters.AddWithValue("@IdClub", evenement.IdClub);
                command.Parameters.AddWithValue("@DateDebut", evenement.DateDebut);
                command.Parameters.AddWithValue("@DateFin", evenement.DateFin);
                command.Parameters.AddWithValue("@Status", evenement.Status);
                command.Parameters.AddWithValue("@Prix", evenement.Prix ?? (object)DBNull.Value); // Handle nullable types
                var newId = Convert.ToInt32(command.ExecuteScalar());
                evenement.Id = newId;
            }
            _connection.Close();
            return evenement;
        }

        public Evenement GetEvenement(int evenementId)
        {
            _connection.Open();
            var commandText = "SELECT * FROM evenement WHERE id = @EvenementId";
            using (var command = new SqlCommand(commandText, _connection))
            {
                command.Parameters.AddWithValue("@EvenementId", evenementId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Evenement
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Titre = reader.GetString(reader.GetOrdinal("titre")),
                            Description = reader.GetString(reader.GetOrdinal("description")),
                            IdClub = reader.GetInt32(reader.GetOrdinal("id_club")),
                            DateDebut = reader.GetDateTime(reader.GetOrdinal("date_debut")),
                            DateFin = reader.GetDateTime(reader.GetOrdinal("date_fin")),
                            Status = reader.GetString(reader.GetOrdinal("status")),
                            Prix = reader.IsDBNull(reader.GetOrdinal("prix")) ? null : (double?)reader.GetDouble(reader.GetOrdinal("prix")) // Handle nullable types
                        };
                    }
                }
            }
            _connection.Close();
            return null;
        }

        public void UpdateEvenement(Evenement evenement)
        {
            _connection.Open();
            var commandText = "UPDATE evenement SET titre = @Titre, description = @Description, id_club = @IdClub, date_debut = @DateDebut, date_fin = @DateFin, status = @Status, prix = @Prix WHERE id = @EvenementId";
            using (var command = new SqlCommand(commandText, _connection))
            {
                command.Parameters.AddWithValue("@Titre", evenement.Titre);
                command.Parameters.AddWithValue("@Description", evenement.Description);
                command.Parameters.AddWithValue("@IdClub", evenement.IdClub);
                command.Parameters.AddWithValue("@DateDebut", evenement.DateDebut);
                command.Parameters.AddWithValue("@DateFin", evenement.DateFin);
                command.Parameters.AddWithValue("@Status", evenement.Status);
                command.Parameters.AddWithValue("@Prix", evenement.Prix ?? (object)DBNull.Value); // Handle nullable types
                command.Parameters.AddWithValue("@EvenementId", evenement.Id);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public void DeleteEvenement(int evenementId)
        {
            _connection.Open();
            var commandText = "DELETE FROM evenement WHERE id = @EvenementId";
            using (var command = new SqlCommand(commandText, _connection))
            {
                command.Parameters.AddWithValue("@EvenementId", evenementId);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }
    }
}

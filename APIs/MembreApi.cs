using System.Data.SqlClient;
using efm_c_.Models;

namespace efm_c_.APIs
{
    internal class MembreApi
    {
        private readonly SqlConnection _connection;

        public MembreApi(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        // CRUD operations for Membre
        public Membre CreateMembre(Membre membre)
        {
            _connection.Open();
            var commandText = "INSERT INTO membre (nom, telephone, email, date_inscription, role) VALUES (@Nom, @Telephone, @Email, @DateInscription, @Role); SELECT SCOPE_IDENTITY();";
            using (var command = new SqlCommand(commandText, _connection))
            {
                command.Parameters.AddWithValue("@Nom", membre.Nom);
                command.Parameters.AddWithValue("@Telephone", membre.Telephone);
                command.Parameters.AddWithValue("@Email", membre.Email);
                command.Parameters.AddWithValue("@DateInscription", membre.DateInscription);
                command.Parameters.AddWithValue("@Role", membre.Role);
                var newId = Convert.ToInt32(command.ExecuteScalar());
                membre.Id = newId;
            }
            _connection.Close();
            return membre;
        }

        public Membre GetMembre(int membreId)
        {
            _connection.Open();
            var commandText = "SELECT * FROM membre WHERE id = @MembreId";
            using (var command = new SqlCommand(commandText, _connection))
            {
                command.Parameters.AddWithValue("@MembreId", membreId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Membre
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Nom = reader.GetString(reader.GetOrdinal("nom")),
                            Telephone = reader.GetString(reader.GetOrdinal("telephone")),
                            Email = reader.GetString(reader.GetOrdinal("email")),
                            DateInscription = reader.GetDateTime(reader.GetOrdinal("date_inscription")),
                            Role = reader.GetString(reader.GetOrdinal("role"))
                        };
                    }
                }
            }
            _connection.Close();
            return null;
        }

        public void UpdateMembre(Membre membre)
        {
            _connection.Open();
            var commandText = "UPDATE membre SET nom = @Nom, telephone = @Telephone, email = @Email, date_inscription = @DateInscription, role = @Role WHERE id = @MembreId";
            using (var command = new SqlCommand(commandText, _connection))
            {
                command.Parameters.AddWithValue("@Nom", membre.Nom);
                command.Parameters.AddWithValue("@Telephone", membre.Telephone);
                command.Parameters.AddWithValue("@Email", membre.Email);
                command.Parameters.AddWithValue("@DateInscription", membre.DateInscription);
                command.Parameters.AddWithValue("@Role", membre.Role);
                command.Parameters.AddWithValue("@MembreId", membre.Id);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }

        public void DeleteMembre(int membreId)
        {
            _connection.Open();
            var commandText = "DELETE FROM membre WHERE id = @MembreId";
            using (var command = new SqlCommand(commandText, _connection))
            {
                command.Parameters.AddWithValue("@MembreId", membreId);
                command.ExecuteNonQuery();
            }
            _connection.Close();
        }
    }
}

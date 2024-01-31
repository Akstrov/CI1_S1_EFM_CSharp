using System.Data;
using System.Data.SqlClient;
using efm_c_.Models;

namespace efm_c_.APIs
{
    internal class MembreApi
    {
        private readonly SqlConnection _connection;

        public MembreApi()
        {
            _connection = Program.GetConnexion();
        }

        // CRUD operations for Membre
        public Membre CreateMembre(Membre membre)
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
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


        public List<(Membre, Club)> GetAllMembersWithClubs()
        {
            var membersWithClubs = new List<(Membre, Club)>();

            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }

            var commandText = "SELECT m.id AS membre_id, m.nom AS membre_nom, m.telephone AS membre_telephone, " +
                  "m.email AS membre_email, m.date_inscription AS membre_date_inscription, m.role AS membre_role, " +
                  "c.id AS club_id, c.nom AS club_nom, c.id_gerant AS club_id_gerant, c.date_creation AS club_date_creation, " +
                  "gm.id AS gerant_id, gm.nom AS gerant_nom, gm.telephone AS gerant_telephone, " +
                  "gm.email AS gerant_email, gm.date_inscription AS gerant_date_inscription, gm.role AS gerant_role " +
                  "FROM membre m " +
                  "JOIN club_membre cm ON m.id = cm.id_membre " +
                  "JOIN club c ON cm.id_club = c.id " +
                  "LEFT JOIN membre gm ON c.id_gerant = gm.id"; // Left join to include clubs without a manager

            using (var command = new SqlCommand(commandText, _connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var member = new Membre
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("membre_id")),
                            Nom = reader.GetString(reader.GetOrdinal("membre_nom")),
                            Telephone = reader.GetString(reader.GetOrdinal("membre_telephone")),
                            Email = reader.GetString(reader.GetOrdinal("membre_email")),
                            DateInscription = reader.GetDateTime(reader.GetOrdinal("membre_date_inscription")),
                            Role = reader.GetString(reader.GetOrdinal("membre_role"))
                        };

                        var club = new Club
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("club_id")),
                            Nom = reader.GetString(reader.GetOrdinal("club_nom")),
                            IdGerant = reader.IsDBNull(reader.GetOrdinal("club_id_gerant")) ? null : (int?)reader.GetInt32(reader.GetOrdinal("club_id_gerant")),
                            DateCreation = reader.GetDateTime(reader.GetOrdinal("club_date_creation")),
                            Gerant = reader.IsDBNull(reader.GetOrdinal("gerant_id")) ? null : new Membre
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("gerant_id")),
                                Nom = reader.GetString(reader.GetOrdinal("gerant_nom")),
                                Telephone = reader.GetString(reader.GetOrdinal("gerant_telephone")),
                                Email = reader.GetString(reader.GetOrdinal("gerant_email")),
                                DateInscription = reader.GetDateTime(reader.GetOrdinal("gerant_date_inscription")),
                                Role = reader.GetString(reader.GetOrdinal("gerant_role"))
                            }
                        };

                        membersWithClubs.Add((member, club));
                    }
                }
            }

            _connection.Close();

            return membersWithClubs;
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

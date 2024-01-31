using System.Data;
using System.Data.SqlClient;
using efm_c_.Models;

namespace efm_c_.APIs
{
    internal class UserApi
    {
        private readonly SqlConnection _connection;

        public UserApi()
        {
            _connection = Program.GetConnexion();
        }
        // CRUD operations for User
        public User CreateUser(User user)
        {
                _connection.Open();
                var commandText = "INSERT INTO users (nom, nom_utilisateur, mot_de_passe, role) VALUES (@Nom, @NomUtilisateur, @MotDePasse, @Role); SELECT SCOPE_IDENTITY();";
                using (var command = new SqlCommand(commandText, _connection))
                {
                    command.Parameters.AddWithValue("@Nom", user.Nom);
                    command.Parameters.AddWithValue("@NomUtilisateur", user.NomUtilisateur);
                    command.Parameters.AddWithValue("@MotDePasse", user.MotDePasse);
                    command.Parameters.AddWithValue("@Role", user.Role);
                    var newId = Convert.ToInt32(command.ExecuteScalar());
                    user.Id = newId;
                }
            return user;
        }

        // Get user by username and password
        public User GetUser(string username, string password)
        {
            if (_connection.State == ConnectionState.Closed) { 
                _connection.Open();
            }

                var commandText = "SELECT * FROM users WHERE nom_utilisateur = @Username AND mot_de_passe = @Password";
                using (var command = new SqlCommand(commandText, _connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                Nom = reader.GetString(reader.GetOrdinal("nom")),
                                NomUtilisateur = reader.GetString(reader.GetOrdinal("nom_utilisateur")),
                                MotDePasse = reader.GetString(reader.GetOrdinal("mot_de_passe")),
                                Role = reader.GetString(reader.GetOrdinal("role"))
                            };
                        }
                    }
            }
            return null; // User not found with the provided username and password
        }

        public User GetUser(int userId)
        {
                _connection.Open();
                var commandText = "SELECT * FROM users WHERE id = @UserId";
                using (var command = new SqlCommand(commandText, _connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("id")),
                                Nom = reader.GetString(reader.GetOrdinal("nom")),
                                NomUtilisateur = reader.GetString(reader.GetOrdinal("nom_utilisateur")),
                                MotDePasse = reader.GetString(reader.GetOrdinal("mot_de_passe")),
                                Role = reader.GetString(reader.GetOrdinal("role"))
                            };
                        }
                    }
                }
            return null;
        }

        public void UpdateUser(User user)
        {
                _connection.Open();
                var commandText = "UPDATE users SET nom = @Nom, nom_utilisateur = @NomUtilisateur, mot_de_passe = @MotDePasse, role = @Role WHERE id = @UserId";
                using (var command = new SqlCommand(commandText, _connection))
                {
                    command.Parameters.AddWithValue("@Nom", user.Nom);
                    command.Parameters.AddWithValue("@NomUtilisateur", user.NomUtilisateur);
                    command.Parameters.AddWithValue("@MotDePasse", user.MotDePasse);
                    command.Parameters.AddWithValue("@Role", user.Role);
                    command.Parameters.AddWithValue("@UserId", user.Id);
                    command.ExecuteNonQuery();
                }
        }

        public void DeleteUser(int userId)
        {
                _connection.Open();
                var commandText = "DELETE FROM users WHERE id = @UserId";
                using (var command = new SqlCommand(commandText, _connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.ExecuteNonQuery();
                }
            }
        }
}

using MaterialSkin2DotNet.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace efm_c_
{
    public partial class LoginForm : MaterialForm
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public static string role;

        public LoginForm()
        {
            InitializeComponent();
            con = Program.GetConnexion();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Tout les champs sont requis !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (con.State == ConnectionState.Closed)
                con.Open();

            String query = "select role from users where nom_utilisateur=@username and mot_de_passe=@password";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                role = dr["role"].ToString();

                if (role.Equals("admin"))
                    new AdminForm().Show();
                else
                    new GerantForm().Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Mot de passe ou nom d'utilisateur incorrect !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

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
    public partial class MembersManagement : MaterialForm
    {
        SqlConnection con;
        DataSet ds;
        SqlDataAdapter adapter;
        private int clubId;

        public MembersManagement()
        {
            InitializeComponent();

            con = Program.GetConnexion();
            ds = new DataSet();

            fetch();

            txtId.Visible = false;
        }

        public MembersManagement(int clubId)
        {
            InitializeComponent();

            this.clubId = clubId;
            con = Program.GetConnexion();
            ds = new DataSet();

            fetch();

            txtId.Visible = false;
        }

        private void fetch()
        {
            var command = new SqlCommand("SELECT id, nom, telephone, email, date_inscription as 'date inscription', role FROM membre inner join club_membre on membre.id = club_membre.id_membre WHERE club_membre.id_club = @ClubId", con);
            command.Parameters.AddWithValue("@ClubId", clubId);

            if (con.State == ConnectionState.Closed)
                con.Open();

            var reader = command.ExecuteReader();

            var dataTable = new DataTable();
            dataTable.Load(reader);
            dgvMembers.DataSource = dataTable;

            txtId.DataBindings.Clear();
            txtName.DataBindings.Clear();
            txtPhone.DataBindings.Clear();
            txtEmail.DataBindings.Clear();

            txtId.DataBindings.Add("Text", dataTable, "id");
            txtName.DataBindings.Add("Text", dataTable, "nom");
            txtPhone.DataBindings.Add("Text", dataTable, "telephone");
            txtEmail.DataBindings.Add("Text", dataTable, "email");

        }
        private string ClubTitle()
        {
            try
            {
                var command = new SqlCommand("SELECT nom FROM club WHERE id = @ClubId", con);

                command.Parameters.AddWithValue("@ClubId", clubId);

                con.Open();
                var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return reader["nom"].ToString();
                }


            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}

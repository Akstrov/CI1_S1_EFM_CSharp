using efm_c_.APIs;
using efm_c_.Models;
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
    public partial class ClubsManagement : MaterialForm
    {
        SqlConnection con;
        DataSet ds;
        SqlDataAdapter adapter;
        ClubApi clubApi;

        public ClubsManagement()
        {
            InitializeComponent();
            con = Program.GetConnexion();
            ds = new DataSet();
            fetch();

            txtId.Visible = false;
            btnUpdate.Visible = false;
            btnFetchMembers.Visible = false;
            btnFetshEvents.Visible = false;

            clubApi = new ClubApi(@"Server=.\SQLEXPRESS; DataBase=efm_cs; Integrated Security=true");
        }

        private void fetch()
        {
            adapter = new SqlDataAdapter("SELECT club.id, club.nom, membre.nom as gerant, " +
                "club.date_creation as \"date creation\" FROM club " +
                "LEFT JOIN membre ON club.id_gerant = membre.id", con);

            adapter.Fill(ds, "clubs");
            dgvClubs.DataSource = ds.Tables[0];

            txtId.DataBindings.Clear();
            txtNom.DataBindings.Clear();

            txtId.DataBindings.Add("Text", ds.Tables[0], "id");
            txtNom.DataBindings.Add("Text", ds.Tables[0], "nom");
        }

        private void ClubsManagement_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNom.Text = "";
            txtId.Visible = false;
            btnUpdate.Visible = false;
            btnFetchMembers.Visible = false;
            btnFetshEvents.Visible = false;
            btnAdd.Enabled = true;
        }

        private void dgvClubs_Click(object sender, EventArgs e)
        {
            txtId.Visible = true;
            btnUpdate.Visible = true;
            btnFetchMembers.Visible = true;
            btnFetshEvents.Visible = true;
            btnAdd.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string nom = txtNom.Text;
            int? idGerant = null;
            DateTime dateCreation = DateTime.Now;

            Club nouveauClub = new Club
            {
                Nom = nom,
                IdGerant = idGerant,
                DateCreation = dateCreation
            };

            clubApi.CreateClub(nouveauClub);
            fetch();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nom = txtNom.Text;
            int? idGerant = null;
            DateTime dateCreation = DateTime.Now;

            Club clubMisAJour = new Club
            {
                Id = id,
                Nom = nom,
                IdGerant = idGerant,
                DateCreation = dateCreation
            };

            clubApi.UpdateClub(clubMisAJour);
            fetch();
        }

        private void btnFetchMembers_Click(object sender, EventArgs e)
        {
            new MembersManagement().Show();
            Hide();
        }
    }

}

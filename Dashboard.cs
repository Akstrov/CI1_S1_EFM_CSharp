using MaterialSkin2DotNet.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace efm_c_
{
    public partial class Dashboard : MaterialForm
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public static String role = LoginForm.role;

        public Dashboard()
        {
            InitializeComponent();
            con = Program.GetConnexion();

            lblClub1.Text = "";
            lblGerant1.Text = "";
            lblMembres1.Text = "";
            lblClub2.Text = "";
            lblGerant2.Text = "";
            lblMembres2.Text = "";
            lblClub3.Text = "";
            lblGerant3.Text = "";
            lblMembres3.Text = "";
            lblClub4.Text = "";
            lblGerant4.Text = "";

            lblMembres4.Text = "";
            lblEvent1.Text = "";
            lblParticipants1.Text = "";
            lblEvent2.Text = "";
            lblParticipants2.Text = "";
            lblEvent3.Text = "";
            lblParticipants3.Text = "";
            lblEvent4.Text = "";
            lblParticipants4.Text = "";

            btnMyClub.Visible = false;
            btnEvents.Location = btnMyClub.Location;
            btnEvents.Size = btnMyClub.Size;

            FillClubLbls();
        }

        public void FillClubLbls()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();

            String query = $"SELECT TOP 4 club.id, club.nom as club_name, membre.nom AS gerant_name, COUNT(club_membre.id_membre) AS 'membre_count' FROM club " +
                $"LEFT JOIN club_membre ON club.id = club_membre.id_club " +
                $"LEFT JOIN membre ON club.id_gerant = membre.id " +
                $"GROUP BY club.id, club.nom, membre.nom " +
                $"HAVING COUNT(club_membre.id_membre) != 0 " +
                $"ORDER BY COUNT(club_membre.id_membre) DESC ";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<int> ids = new List<int>();
            int clubsCount = 1;
            while (dr.Read())
            {
                String clubName = dr["club_name"].ToString();
                String clubGerant = dr["gerant_name"].ToString();
                int clubMembre = Convert.ToInt32(dr["membre_count"]);
                int id = Convert.ToInt32(dr["id"]);

                ids.Add(id);

                if (clubsCount == 1)
                {
                    lblClub1.Text = clubName;
                    lblGerant1.Text = clubGerant;
                    lblMembres1.Text = clubMembre.ToString();
                }
                else if (clubsCount == 2)
                {
                    lblClub2.Text = clubName;
                    lblGerant2.Text = clubGerant;
                    lblMembres2.Text = clubMembre.ToString();
                }
                else if (clubsCount == 3)
                {
                    lblClub3.Text = clubName;
                    lblGerant3.Text = clubGerant;
                    lblMembres3.Text = clubMembre.ToString();
                }
                else if (clubsCount == 4)
                {
                    lblClub4.Text = clubName;
                    lblGerant4.Text = clubGerant;
                    lblMembres4.Text = clubMembre.ToString();
                }
                clubsCount++;
            }
            dr.Close();

            query = $"SELECT evenement.id as event_id, evenement.titre as event_title, COUNT(paiement.id_membre) as membre_count " +
                $"FROM evenement " +
                $"INNER JOIN paiement ON evenement.id = paiement.id_evenement " +
                $"GROUP BY evenement.id, evenement.titre " +
                $"HAVING COUNT(paiement.id_membre) != 0 " +
                $"ORDER BY membre_count DESC";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            int partcipantsCount = 1;
            while (dr.Read())
            {
                String eventName = dr["event_title"].ToString();
                int eventMembre = Convert.ToInt32(dr["membre_count"]);

                if (partcipantsCount == 1)
                {
                    lblEvent1.Text = eventName;
                    lblParticipants1.Text = eventMembre.ToString();
                }
                else if (partcipantsCount == 2)
                {
                    lblEvent2.Text = eventName;
                    lblParticipants2.Text = eventMembre.ToString();
                }
                else if (partcipantsCount == 3)
                {
                    lblEvent3.Text = eventName;
                    lblParticipants3.Text = eventMembre.ToString();
                }
                else if (partcipantsCount == 4)
                {
                    lblEvent4.Text = eventName;
                    lblParticipants4.Text = eventMembre.ToString();
                }
                partcipantsCount++;
            }

            if (role != "admin")
            {
                btnClubs.Visible = false;
                btnEvents.Visible = true;
                materialCard1.Click -= materialCard1_Click;
                materialCard2.Click -= materialCard2_Click;
                materialCard3.Click -= materialCard3_Click;
                materialCard4.Click -= materialCard4_Click;
                materialCard5.Click -= materialCard5_Click;
                materialCard6.Click -= materialCard6_Click;
                materialCard7.Click -= materialCard7_Click;
                materialCard8.Click -= materialCard8_Click;
                btnMyClub.Visible = true;
                btnMyClub.Location = btnClubs.Location;
                btnMyClub.Size = btnClubs.Size;
            }
        }

        // Club cards
        private void materialCard1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void materialCard2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void materialCard5_Click(object sender, EventArgs e)
        {

        }

        private void materialCard6_Click(object sender, EventArgs e)
        {

        }

        // Events cards
        private void materialCard3_Click(object sender, EventArgs e)
        {

        }

        private void materialCard4_Click(object sender, EventArgs e)
        {

        }

        private void materialCard7_Click(object sender, EventArgs e)
        {

        }

        private void materialCard8_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class AdminForm : MaterialForm
    {
        SqlConnection con;
        MembreApi membreApi;
        SqlCommand cmd;
        SqlDataReader dr;
        public static String role;

        public AdminForm()
        {
            InitializeComponent();
            con = Program.GetConnexion();
            membreApi =new MembreApi();
            FillClubLbls();
        }

        public void FillClubLbls()
        {

            List<(Membre, Club)> membreToClub = membreApi.GetAllMembersWithClubs();
            int clubsCount = 1;
            foreach ((Membre, Club) membre in membreToClub)
            {
                String clubName = membre.Item2.Nom;
                String clubGerant = membre.Item2.Gerant.Nom;
                clubsCount++;
            }

            //if (con.State == ConnectionState.Closed)
            //    con.Open();

            //String query = $"SELECT club.id, club.nom as club_name, membre.nom AS gerant_name, COUNT(club_membre.id_membre) AS 'membre_count' FROM club " +
            //    $"LEFT JOIN club_membre ON club.id = club_membre.id_club " +
            //    $"LEFT JOIN membre ON club.id_gerant = membre.id " +
            //    $"GROUP BY club.id, membre.nom " +
            //    $"ORDER BY COUNT(club_membre.id_membre) DESC limit 4";
            //cmd = new SqlCommand(query, con);
            //dr = cmd.ExecuteReader();

            //int clubsCount = 1;
            //while (dr.Read())
            //{
            //    String clubName = dr["club_name"].ToString();
            //    String clubGerant = dr["gerant_name"].ToString();
            //    int clubMembre = Convert.ToInt32(dr["membre_count"]);

            //    if (clubsCount == 1)
            //    {
            //        lblClub1.Text = clubName;
            //        lblGerant1.Text = clubGerant;
            //        lblMembres1.Text = clubMembre.ToString();
            //        Console.WriteLine(lblClub1.Text);
            //    }
            //    clubsCount++;
            //}
        }
    }
}

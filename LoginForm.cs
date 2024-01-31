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
    public partial class LoginForm : MaterialForm
    {
        UserApi userApi;

        public LoginForm()
        {
            InitializeComponent();
            userApi = new UserApi();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Tout les champs sont requis !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User user = userApi.GetUser(txtUsername.Text, txtPassword.Text);
            if (user == null)
            {
                MessageBox.Show("Mot de passe ou nom d'utilisateur incorrect !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }else if (user.Role.Equals("admin"))
                    new AdminForm().Show();
                else
                    new GerantForm().Show();
                Hide();
        }
    }
}

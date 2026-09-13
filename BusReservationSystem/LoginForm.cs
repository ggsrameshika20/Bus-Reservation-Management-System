using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace BusReservationSystem
{
    public partial class LoginForm : Form
    {
      
        public LoginForm()
        { 
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string role = cmbRole.Text.Trim();

            if (string.IsNullOrEmpty(username) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please enter Username, Password and Role!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "server=localhost;database=bus_reservation_db;uid=root;pwd=;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT * FROM users
                             WHERE username=@user
                             AND password=@pass
                             AND role=@role";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", username);
                        cmd.Parameters.AddWithValue("@pass", password);
                        cmd.Parameters.AddWithValue("@role", role);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                UserSession.UserID = Convert.ToInt32(reader["user_id"]);
                                UserSession.Username = reader["username"].ToString();
                                UserSession.FullName = reader["full_name"].ToString(); 
                                UserSession.Email = reader["email"].ToString();
                                UserSession.Role = reader["role"].ToString();

                                MessageBox.Show("Login Successful!",
                                    "Success",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                if (UserSession.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                                {
                                    AdminDashboard admin = new AdminDashboard();
                                    admin.Show();
                                }
                                else
                                {
                                    UserDashboard user = new UserDashboard();
                                    user.Show();
                                }

                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid Username, Password or Role!",
                                    "Login Failed",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error : " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.Show();
            this.Hide();
        }

        private void LoginForm_Load(object sender, EventArgs e) { }
        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
    }
}
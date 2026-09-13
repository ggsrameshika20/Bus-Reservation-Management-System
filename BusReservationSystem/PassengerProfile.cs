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
    public partial class PassengerProfile : Form
    {
        string connectionString = "server=localhost;database=bus_reservation_db;uid=root;pwd=;";
        public PassengerProfile()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Title = "Select Profile Photo";
            open.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(open.FileName);
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

     

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            UserDashboard passengerDashboard = new UserDashboard();
            passengerDashboard.Show();
            this.Hide();
        }

        private void PassengerProfile_Load(object sender, EventArgs e)
        {
            label2.Text = UserSession.FullName;

            txtUsername.ReadOnly = true;
            txtPassword.ReadOnly = true;

            txtFullName.Enabled = false;
            txtEmail.Enabled = false;
            txtPhone.Enabled = false;
            txtAddress.Enabled = false;
            txtNIC.Enabled = false;

            LoadProfile();
        }
        private void LoadProfile()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM users WHERE user_id=@id";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", UserSession.UserID);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtFullName.Text = reader["full_name"].ToString();
                    txtUsername.Text = reader["username"].ToString();
                    txtEmail.Text = reader["email"].ToString();
                    txtPhone.Text = reader["phone"].ToString();
                    txtAddress.Text = reader["address"].ToString();
                    txtNIC.Text = reader["nic"].ToString();

                    if (reader["password"] != DBNull.Value)
                        txtPassword.Text = reader["password"].ToString();
                }

                reader.Close();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtFullName.Enabled = true;
            txtEmail.Enabled = true;
            txtPhone.Enabled = true;
            txtAddress.Enabled = true;
            txtNIC.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"UPDATE users SET full_name=@name,email=@email,phone=@phone,address=@address,nic=@nic,password=@password WHERE user_id=@id";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@name", txtFullName.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@nic", txtNIC.Text);
                cmd.Parameters.AddWithValue("@id", UserSession.UserID);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                cmd.ExecuteNonQuery();

                UserSession.FullName = txtFullName.Text;

                label2.Text = UserSession.FullName;

                MessageBox.Show("Profile Updated Successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtFullName.Enabled = false;
                txtEmail.Enabled = false;
                txtPhone.Enabled = false;
                txtAddress.Enabled = false;
                txtNIC.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadProfile();

            txtFullName.Enabled = false;
            txtEmail.Enabled = false;
            txtPhone.Enabled = false;
            txtAddress.Enabled = false;
            txtNIC.Enabled = false;
        }
        private void UserDashboard_Load(object sender, EventArgs e)
        {
            label2.Text = "Welcome, " + UserSession.FullName;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            txtPassword.ReadOnly = false;
            txtPassword.UseSystemPasswordChar = false; 
            txtPassword.Focus();

            MessageBox.Show("Enter your new password and click UPDATE.",
                            "Change Password",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
        

        private void btnSearchBus_Click(object sender, EventArgs e)
        {
            SearchBusForm search = new SearchBusForm();
            search.Show();
            this.Close();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            ReservationForm reservation = new ReservationForm();
            reservation.Show();
            this.Close();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            PaymentForm payment = new PaymentForm();
            payment.Show();
            this.Close();
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            MyReservationForm_history_ history = new MyReservationForm_history_();
            history.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            UserSession.UserID = 0;
            UserSession.Username = "";
            UserSession.FullName = "";
            UserSession.Email = "";
            UserSession.Role = "";

            LoginForm login = new LoginForm();
            login.Show();

            this.Close();
        }
    }
}

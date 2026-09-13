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
    public partial class UserDashboard : Form
    {

        private string connectionString ="server=localhost;database=bus_reservation_db;uid=root;pwd=;";
        public UserDashboard()
        {
            InitializeComponent();
            label2.Text = UserSession.FullName;

        }


        private void UserDashboard_Load(object sender, EventArgs e)
        {
            LoadDashboardCounts();

            label2.Text = UserSession.FullName;
        }
        private void LoadDashboardCounts()
        {
            int userID = UserSession.UserID;


            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();


                    // My Reservations Count
                    string reservationQuery =
                    @"SELECT COUNT(*) 
                      FROM reservations 
                      WHERE user_id=@uid";


                    MySqlCommand cmd1 =
                    new MySqlCommand(reservationQuery, conn);

                    cmd1.Parameters.AddWithValue("@uid", userID);


                    label4.Text =
                    cmd1.ExecuteScalar().ToString();



                    // My Payments Count
                    string paymentQuery =
                    @"SELECT COUNT(*)
                      FROM payments p
                      INNER JOIN reservations r
                      ON p.reservation_id=r.reservation_id
                      WHERE r.user_id=@uid";


                    MySqlCommand cmd2 =
                    new MySqlCommand(paymentQuery, conn);

                    cmd2.Parameters.AddWithValue("@uid", userID);


                    label10.Text =
                    cmd2.ExecuteScalar().ToString();



                    // Upcoming Trips Count

                    string upcomingQuery =
                    @"SELECT COUNT(*)
                      FROM reservations
                      WHERE user_id=@uid
                      AND travel_date > CURDATE()
                      AND status='Confirmed'";


                    MySqlCommand cmd3 =
                    new MySqlCommand(upcomingQuery, conn);


                    cmd3.Parameters.AddWithValue("@uid", userID);


                    label8.Text =
                    cmd3.ExecuteScalar().ToString();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void btnSearchBus_Click(object sender, EventArgs e)
        {
            SearchBusForm searchBus = new SearchBusForm();
            searchBus.Show();
            this.Hide();
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            ReservationForm seatBooking = new ReservationForm();
            seatBooking.Show();
            this.Hide();
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            MyReservationForm_history_ history = new MyReservationForm_history_();
            history.Show();
            this.Hide();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            PassengerProfile profile = new PassengerProfile();
            profile.Show();
            this.Hide();
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
            this.Hide();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            PaymentForm payment = new PaymentForm();
            payment.Show();
            this.Hide();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            SearchBusForm searchBus = new SearchBusForm();
            searchBus.Show();
            this.Hide();
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            PaymentForm payment = new PaymentForm();
            payment.Show();
            this.Hide();
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            MyReservationForm_history_ history = new MyReservationForm_history_();
            history.Show();
            this.Hide();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            PassengerProfile profile = new PassengerProfile();
            profile.Show();
            this.Hide();
        }

      

        private void panel1_Click(object sender, EventArgs e)
        {
            MyReservationForm_history_ frm =new MyReservationForm_history_();

            frm.Show();
            this.Hide();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            MyReservationForm_history_ frm = new MyReservationForm_history_();
            frm.UpcomingOnly = true;
            frm.Show();
            this.Hide();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            RecentPayments recent = new RecentPayments();
            recent.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PassengerProfile profile = new PassengerProfile();
            profile.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
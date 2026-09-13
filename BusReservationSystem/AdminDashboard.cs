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
    public partial class AdminDashboard : Form
    {

        private string connectionString = "server=localhost;database=bus_reservation_db;uid=root;pwd=";
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {

            LoadDashboardCards();

            LoadRecentReservations();

        }
        private void LoadDashboardCards()
        {

            using (MySqlConnection con =
            new MySqlConnection(connectionString))
            {

                con.Open();


                // TOTAL BUSES

                MySqlCommand cmd1 =
                new MySqlCommand(
                "SELECT COUNT(*) FROM buses",
                con);


                label4.Text =
                cmd1.ExecuteScalar().ToString();



                // TOTAL RESERVATIONS

                MySqlCommand cmd2 =
                new MySqlCommand(
                "SELECT COUNT(*) FROM reservations",
                con);



                label3.Text =
                cmd2.ExecuteScalar().ToString();




                // TOTAL USERS


                MySqlCommand cmd3 =
                new MySqlCommand(
                "SELECT COUNT(*) FROM users",
                con);



                label7.Text =
                cmd3.ExecuteScalar().ToString();



                MySqlCommand cmd4 =
                new MySqlCommand(

               "SELECT IFNULL(SUM(amount_paid),0) FROM payments",

                con);



                double revenue =
                Convert.ToDouble(cmd4.ExecuteScalar());


                label9.Text =
                revenue.ToString("N2");

            }

        }

        private void LoadRecentReservations()
        {

            dgvRecentReservations.Rows.Clear();


            using (MySqlConnection con =
            new MySqlConnection(connectionString))
            {

                string query =

                @"SELECT 
            r.reservation_id,
            u.full_name,
            b.bus_name,
            b.route,
            r.booking_date,
            p.amount_paid,
            r.status

          FROM reservations r

          INNER JOIN users u
          ON r.user_id = u.user_id

          INNER JOIN buses b
          ON r.bus_id = b.bus_id

          LEFT JOIN payments p
          ON r.reservation_id = p.reservation_id

          ORDER BY r.reservation_id DESC

          LIMIT 5";


                MySqlCommand cmd =
                new MySqlCommand(query, con);



                con.Open();


                MySqlDataReader dr =
                cmd.ExecuteReader();



                while (dr.Read())
                {

                    dgvRecentReservations.Rows.Add(

                        dr["reservation_id"].ToString(),

                        dr["full_name"].ToString(),

                        dr["bus_name"].ToString(),

                        dr["route"].ToString(),

                        Convert.ToDateTime(
                        dr["booking_date"])
                        .ToString("yyyy-MM-dd"),

                        dr["amount_paid"].ToString(),

                        dr["status"].ToString()

                    );

                }

            }



            // Status Color

            foreach (DataGridViewRow row in dgvRecentReservations.Rows)
            {

                if (row.Cells["colStatus"].Value != null)
                {

                    string status =
                    row.Cells["colStatus"].Value.ToString();


                    if (status == "Confirmed")
                    {
                        row.Cells["colStatus"].Style.ForeColor =
                        Color.Green;
                    }

                    else if (status == "Pending")
                    {
                        row.Cells["colStatus"].Style.ForeColor =
                        Color.Orange;
                    }

                }

            }

        }
        private void btnManageBuses_Click(object sender, EventArgs e)
        {
            
            ManageBusForm manageBus = new ManageBusForm();
            manageBus.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManageBusForm manageBus = new ManageBusForm();
            manageBus.Show();
             this.Hide();
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            ManageReservations manageReservations = new ManageReservations();
            manageReservations.Show();
            this.Hide();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            ManageUsers manageUsers = new ManageUsers();
            manageUsers.Show();
            this.Hide();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            ManagePayments managePayments = new ManagePayments();
            managePayments.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReportForm manageReports = new ReportForm();
            manageReports.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

        }

        private void dgvRecentReservations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            ManageBusForm form =new ManageBusForm();

            form.Show();

            this.Hide();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            ManageReservations form =new ManageReservations();


            form.Show();

            this.Hide();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            ManageUsers form =new ManageUsers();


            form.Show();

            this.Hide();

        }

        private void panel4_Click(object sender, EventArgs e)
        {

            ManagePayments form =new ManagePayments();


            form.Show();

            this.Hide();
        }
    }
}

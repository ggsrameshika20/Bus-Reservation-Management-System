using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BusReservationSystem
{
    public partial class RecentPayments : Form
    {

        private string connectionString ="server=localhost;database=bus_reservation_db;uid=root;pwd=;";


        public RecentPayments()
        {
            InitializeComponent();
        }


        private void RecentPayments_Load(object sender, EventArgs e)
        {
            LoadPayments();
        }


        private void LoadPayments()
        {

            {
                dataGridView1.Rows.Clear();

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();

                        string query = @"
                    SELECT
                        p.payment_id,
                        p.reservation_id,
                        b.bus_name,
                        b.route,
                        p.payment_date,
                        p.amount_paid,
                        p.payment_method,
                        p.status

                    FROM payments p

                    INNER JOIN reservations res
                        ON p.reservation_id = res.reservation_id

                    INNER JOIN buses b
                        ON res.bus_id = b.bus_id

                    WHERE res.user_id = @userid

                    ORDER BY p.payment_date DESC";

                        MySqlCommand cmd = new MySqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@userid", UserSession.UserID);

                        MySqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            dataGridView1.Rows.Add(
                                dr["payment_id"],
                                dr["reservation_id"],
                                dr["bus_name"],
                                dr["route"],
                                Convert.ToDateTime(dr["payment_date"]).ToString("yyyy-MM-dd"),
                                dr["amount_paid"],
                                dr["payment_method"],
                                dr["status"]
                            );
                        }

                        dr.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }


            }
        }



        private void btnBack_Click(object sender, EventArgs e)
        {

            UserDashboard dashboard =
            new UserDashboard();

            dashboard.Show();

            this.Hide();

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
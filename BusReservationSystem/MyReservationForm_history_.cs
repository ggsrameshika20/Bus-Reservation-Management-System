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
    public partial class MyReservationForm_history_ : Form
    {
        private string connectionString ="server=localhost;database=bus_reservation_db;uid=root;pwd=;";

        private int loggedInUserID;
        public bool UpcomingOnly = false;
        public MyReservationForm_history_()
        {
            InitializeComponent();

            dgvReservations.AutoGenerateColumns = false;
            loggedInUserID = UserSession.UserID;
        }

        private void LoadReservations()
        {
            dgvReservations.AutoGenerateColumns = false;
            dgvReservations.Rows.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query;

                if (UpcomingOnly)
                {
                    query = @"SELECT
                r.reservation_id,
                b.bus_name,
                b.route,
                r.travel_date,
                r.seat_no,
                r.amount,
                r.status
              FROM reservations r
              INNER JOIN buses b
              ON r.bus_id=b.bus_id
              WHERE r.user_id=@userID
              AND r.travel_date>=CURDATE()
              ORDER BY r.travel_date ASC";
                }
                else
                {
                    query = @"SELECT
                r.reservation_id,
                b.bus_name,
                b.route,
                r.travel_date,
                r.seat_no,
                r.amount,
                r.status
              FROM reservations r
              INNER JOIN buses b
              ON r.bus_id=b.bus_id
              WHERE r.user_id=@userID
              ORDER BY r.reservation_id DESC";
                }

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@userID", loggedInUserID);

                try
                {
                    conn.Open();

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dgvReservations.Rows.Add(
                            reader["reservation_id"],
                            reader["bus_name"],
                            reader["route"],
                            Convert.ToDateTime(reader["travel_date"]).ToString("yyyy-MM-dd"),
                            reader["seat_no"],
                            reader["amount"],
                            reader["status"],
                            "VIEW"
                        );
                    }

                    reader.Close();

                    foreach (DataGridViewRow row in dgvReservations.Rows)
                    {
                        if (row.Cells[6].Value != null)
                        {
                            string status = row.Cells[6].Value.ToString();

                            if (status == "Confirmed")
                            {
                                row.Cells[6].Style.ForeColor = Color.Green;
                            }
                            else
                            {
                                row.Cells[6].Style.ForeColor = Color.Red;
                            }
                        }

                        row.Cells[7].Style.BackColor = Color.LightGray;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void MyReservationForm_history__Load(object sender, EventArgs e)
        {

                LoadReservations();         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserDashboard passengerDashboard = new UserDashboard();
            passengerDashboard.Show();
            this.Hide(); 
            
        }

        private void dgvReservations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 7)   
            {
                string reservationID = dgvReservations.Rows[e.RowIndex].Cells[0].Value.ToString();
                string busName = dgvReservations.Rows[e.RowIndex].Cells[1].Value.ToString();
                string route = dgvReservations.Rows[e.RowIndex].Cells[2].Value.ToString();
                string date = dgvReservations.Rows[e.RowIndex].Cells[3].Value.ToString();
                string seat = dgvReservations.Rows[e.RowIndex].Cells[4].Value.ToString();
                string amount = dgvReservations.Rows[e.RowIndex].Cells[5].Value.ToString();

                CancelReservation frm = new CancelReservation(
                    reservationID,
                    busName,
                    route,
                    date,
                    seat,
                    amount
                );

                frm.Show();
                this.Hide();
            }
        }

       
    }
}

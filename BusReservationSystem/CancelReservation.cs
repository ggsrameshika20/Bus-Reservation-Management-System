using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace BusReservationSystem
{
    public partial class CancelReservation : Form
    {

        private string connectionString ="server=localhost;database=bus_reservation_db;uid=root;pwd=;";

        private string reservationID;
        private string bus;
        private string date;
        private string seat;
        private string amount;
        private string route;


        public CancelReservation(string id, string busName, string routeName,string travelDate, string seatNo, string total)
        {
            InitializeComponent();


            reservationID = id;
            bus = busName;
            route = routeName;
            date = travelDate;
            seat = seatNo;
            amount = total;

        }



        private void CancelReservation_Load(object sender, EventArgs e)
        {
            label8.Text = reservationID;
            label9.Text = bus;
            label10.Text = date;
            label11.Text = seat;
            label12.Text = "LKR " + amount;


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                    "Are you sure you want to cancel this reservation?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    MySqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // 1. Delete payment
                        string paymentQuery =
                        "DELETE FROM payments WHERE reservation_id=@id";

                        MySqlCommand cmdPayment =
                            new MySqlCommand(paymentQuery, conn, transaction);

                        cmdPayment.Parameters.AddWithValue("@id", reservationID);

                        cmdPayment.ExecuteNonQuery();


                        // 2. Free the seat
                        string seatQuery =
                        @"UPDATE seat_availability
                  SET is_booked=0
                  WHERE bus_id =
                  (
                      SELECT bus_id
                      FROM reservations
                      WHERE reservation_id=@id
                  )
                  AND travel_date =
                  (
                      SELECT travel_date
                      FROM reservations
                      WHERE reservation_id=@id
                  )
                  AND seat_no =
                  (
                      SELECT seat_no
                      FROM reservations
                      WHERE reservation_id=@id
                  )";

                        MySqlCommand cmdSeat =
                            new MySqlCommand(seatQuery, conn, transaction);

                        cmdSeat.Parameters.AddWithValue("@id", reservationID);

                        cmdSeat.ExecuteNonQuery();


                        // 3. Delete reservation
                        string reservationQuery =
                        "DELETE FROM reservations WHERE reservation_id=@id";

                        MySqlCommand cmdReservation =
                            new MySqlCommand(reservationQuery, conn, transaction);

                        cmdReservation.Parameters.AddWithValue("@id", reservationID);

                        int rows = cmdReservation.ExecuteNonQuery();


                        transaction.Commit();

                        if (rows > 0)
                        {
                            MessageBox.Show(
                                "Reservation Cancelled Successfully.",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            MyReservationForm_history_ frm =
                                new MyReservationForm_history_();

                            frm.Show();

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Reservation not found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();

                        MessageBox.Show(
                            ex.Message,
                            "Database Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void btnKeep_Click(object sender, EventArgs e)
        {

            MyReservationForm_history_ payment =new MyReservationForm_history_();


            payment.Show();

            this.Hide();
        }
    }
}
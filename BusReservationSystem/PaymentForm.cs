using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BusReservationSystem
{
    public partial class PaymentForm : Form
    {
        private string connectionString ="server=localhost;database=bus_reservation_db;uid=root;pwd=;";

        private string busName;
        private string route;
        private string travelDate;
        private string passenger;
        private string phone;
        private string seatNo;
        private string totalAmount;
        private string reservationID;

        public PaymentForm()
        {
            InitializeComponent();
        }

        public PaymentForm(string bus,string rte,string date,string passengerName,string phone,string seats,string total, string id)
        {
            InitializeComponent();

            reservationID = id;
            busName = bus;
            route = rte;
            travelDate = date;
            passenger = passengerName;
            this.phone = phone;
            seatNo = seats;
            totalAmount = total;

            lblBusName.Text = bus;
            lblRoute.Text = rte;
            lblDate.Text = date;
            lblPassenger.Text = passengerName;
            lblPhone.Text = phone;
            lblSeat.Text = seats;
            label9.Text = "LKR " + total;
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblBusName_Click(object sender, EventArgs e)
        {

        }

        private void cmbPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPayment.Text == "Cash")
            {
                txtCard.Enabled = false;
                txtCVV.Enabled = false;
                txtHolder.Enabled = false;

                txtCard.Clear();
                txtCVV.Clear();
                txtHolder.Clear();
            }
            else
            {
                txtCard.Enabled = true;
                txtCVV.Enabled = true;
                txtHolder.Enabled = true;
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void btnPayNow_Click(object sender, EventArgs e)
        {
            if (cmbPayment.Text == "Card")
            {
                if (txtCard.Text == "")
                {
                    MessageBox.Show("Enter Card Number");
                    return;
                }

                if (txtCVV.Text == "")
                {
                    MessageBox.Show("Enter CVV");
                    return;
                }

                if (txtHolder.Text == "")
                {
                    MessageBox.Show("Enter Card Holder Name");
                    return;
                }
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Insert payment
                    string query = @"INSERT INTO payments
                            (reservation_id, payment_method, amount_paid, status)
                            VALUES
                            (@reservationID, @method, @amount, 'Paid')";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@reservationID", reservationID);
                    cmd.Parameters.AddWithValue("@method", cmbPayment.Text);
                    cmd.Parameters.AddWithValue("@amount", Convert.ToDecimal(totalAmount));

                    cmd.ExecuteNonQuery();

                    conn.Close();

                    MessageBox.Show("Payment Successful!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    BookingConfirmation confirm =
                        new BookingConfirmation(reservationID,busName,route,travelDate,seatNo,totalAmount);
                        confirm.Show();
                        this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Payment Failed : " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelReservation cancel = new CancelReservation(reservationID,busName,route,travelDate,seatNo,totalAmount);

            cancel.Show();

            this.Hide();

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UserDashboard passengerDashboard = new UserDashboard();
            passengerDashboard.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PaymentForm_Load(object sender, EventArgs e)
        {
            
            cmbPayment.Items.Clear();

            cmbPayment.Items.Add("Card");
            cmbPayment.Items.Add("Cash");

            cmbPayment.SelectedIndex = 0;
        }
        

        private void lblRoute_Click(object sender, EventArgs e)
        {

        }
    }
}

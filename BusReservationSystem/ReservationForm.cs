using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace BusReservationSystem
{
    public partial class ReservationForm : Form
    {
        private string connectionString = "server=localhost;database=bus_reservation_db;uid=root;pwd=;";
        private string busID, busName, route, travelDate, fare, departureTime, arrivalTime;
        private int seatCount;

        private int loggedInUserID;

        private List<string> selectedSeatsList = new List<string>();

        public ReservationForm()
        {
            InitializeComponent();


            lblSelectedSeat.Text = "--";
            lblTotal.Text = "0.00";
        }

        public ReservationForm(string id,string name,string rte,string date,string departure,string arrival,string price, int seats)
        {
            InitializeComponent();
            loggedInUserID = UserSession.UserID;

            busID = id;
            busName = name;
            route = rte;
            travelDate = date;
            fare = price;
            departureTime = departure;
            arrivalTime = arrival;
            seatCount = seats;

            lblBusName.Text = busName;
            lblRoute.Text = route;
            lblDate.Text = travelDate;
            lblFare.Text = fare;
            lblDeparture.Text = departure;
            lblArrival.Text = arrival;

            lblSelectedSeat.Text = "--";
            lblTotal.Text = "0.00";

        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            GenerateSeats();
            LoadBookedSeats();
        }

        private void LoadBookedSeats()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT seat_no FROM seat_availability WHERE bus_id = @busID AND travel_date = @date AND is_booked = 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@busID", busID);
                cmd.Parameters.AddWithValue("@date", travelDate);

                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string bookedSeat = reader["seat_no"].ToString();

                        Control[] foundButtons = this.Controls.Find("btn" + bookedSeat, true);
                        if (foundButtons.Length > 0 && foundButtons[0] is Button)
                        {
                            Button seatBtn = (Button)foundButtons[0];
                            seatBtn.BackColor = Color.Red;
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading seats: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Seat_Click(object sender, EventArgs e)
        {
            Button seat = (Button)sender;

            if (seat.BackColor == Color.Red)
            {
                MessageBox.Show("Seat already booked!");
                return;
            }

            if (selectedSeatsList.Contains(seat.Text))
            {
                selectedSeatsList.Remove(seat.Text);
                seat.BackColor = Color.LimeGreen;
            }
            else
            {
                selectedSeatsList.Add(seat.Text);
                seat.BackColor = Color.RoyalBlue;
            }

            UpdateSelectionUI();
        }

       
      

        private void UpdateSelectionUI()
        {
            if (selectedSeatsList.Count > 0)
            {
                lblSelectedSeat.Text = string.Join(", ", selectedSeatsList);
            }
            else
            {
                lblSelectedSeat.Text = "--";
            }

            if (decimal.TryParse(fare, out decimal singleFare))
            {
                decimal totalAmount = selectedSeatsList.Count * singleFare;
                lblTotal.Text = totalAmount.ToString("0.00");
            }
            else
            {
                lblTotal.Text = "0.00";
            }
        }

        private void btnConfirmBooking_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassenger.Text) || string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Please enter Passenger Details.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedSeatsList.Count == 0)
            {
                MessageBox.Show("Please select at least one seat before confirming.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    decimal singleFare = Convert.ToDecimal(fare);
                    long lastReservationID = 0;

                    foreach (string seatNo in selectedSeatsList)
                    {
                        string resQuery = "INSERT INTO reservations (user_id, bus_id, travel_date, seat_no, amount, status) " +
                                          "VALUES (@userID, @busID, @tDate, @seatNo, @amount, 'Confirmed')";

                        MySqlCommand cmdRes = new MySqlCommand(resQuery, conn, transaction);
                        cmdRes.Parameters.AddWithValue("@userID", loggedInUserID);
                        cmdRes.Parameters.AddWithValue("@busID", busID);
                        cmdRes.Parameters.AddWithValue("@tDate", travelDate);
                        cmdRes.Parameters.AddWithValue("@seatNo", seatNo);
                        cmdRes.Parameters.AddWithValue("@amount", singleFare);
                        cmdRes.ExecuteNonQuery();
                        lastReservationID = cmdRes.LastInsertedId;

                        string availQuery = "INSERT INTO seat_availability (bus_id, travel_date, seat_no, is_booked) " +
                                            "VALUES (@busID, @tDate, @seatNo, 1) " +
                                            "ON DUPLICATE KEY UPDATE is_booked = 1";

                        MySqlCommand cmdAvail = new MySqlCommand(availQuery, conn, transaction);
                        cmdAvail.Parameters.AddWithValue("@busID", busID);
                        cmdAvail.Parameters.AddWithValue("@tDate", travelDate);
                        cmdAvail.Parameters.AddWithValue("@seatNo", seatNo);
                        cmdAvail.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("All Bookings Confirmed Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    PaymentForm payment = new PaymentForm(busName,route,travelDate,txtPassenger.Text,txtPhone.Text,string.Join(", ", selectedSeatsList),lblTotal.Text,lastReservationID.ToString());

                    payment.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Booking Failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            selectedSeatsList.Clear();

            foreach (Control c in this.Controls)
            {
                ResetSeatButtons(c);
            }

            lblSelectedSeat.Text = "--";
            lblTotal.Text = "0.00";
        }

        private void ResetSeatButtons(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Button btn)
                {
                    if (btn.BackColor == Color.RoyalBlue)
                    {
                        btn.BackColor = Color.LimeGreen;
                    }
                }

                if (c.HasChildren)
                {
                    ResetSeatButtons(c);
                }
            }
        }

        private void GenerateSeats()
        {
            flpSeats.Controls.Clear();

            int row = 1;

            for (int i = 1; i <= seatCount; i++)
            {
                Button btn = new Button();

                btn.Width = 70;
                btn.Height = 40;

                btn.BackColor = Color.LimeGreen;
                btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                int column = (i - 1) % 4;

                string letter = "";

                switch (column)
                {
                    case 0:
                        letter = "A";
                        break;

                    case 1:
                        letter = "B";
                        break;

                    case 2:
                        letter = "C";
                        break;

                    case 3:
                        letter = "D";
                        break;
                }

                btn.Text = row + letter;

                btn.Name = "btn" + btn.Text;

                btn.Click += Seat_Click;

                flpSeats.Controls.Add(btn);

                if (column == 3)
                    row++;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UserDashboard passengerDashboard = new UserDashboard();
            passengerDashboard.Show();
            this.Hide();
        }
    }
}
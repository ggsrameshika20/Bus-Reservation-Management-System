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
    public partial class ManageBusForm : Form
    {
      
        private string connectionString = "server=localhost;database=bus_reservation_db;uid=root;pwd=;";

        public ManageBusForm()
        {
            InitializeComponent();
        }

        private void ManageBusForm_Load(object sender, EventArgs e)
        {
            dgvBuses.AutoGenerateColumns = false;
            dgvBuses.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvBuses.EnableHeadersVisualStyles = false;
            dgvBuses.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;

            LoadBusData();
        }

        private void ManageBuses_Load(object sender, EventArgs e)
        {
            // LoadBusData();
        }

        private void LoadBusData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                        string query = @"SELECT bus_id,bus_name,route,departure_time,arrival_time,seat_count,fare FROM buses";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvBuses.AutoGenerateColumns = false;

                        dgvBuses.Columns[0].DataPropertyName = "bus_id";
                        dgvBuses.Columns[1].DataPropertyName = "bus_name";
                        dgvBuses.Columns[2].DataPropertyName = "route";
                        dgvBuses.Columns[3].DataPropertyName = "departure_time";
                        dgvBuses.Columns[4].DataPropertyName = "arrival_time";
                        dgvBuses.Columns[5].DataPropertyName = "seat_count";
                        dgvBuses.Columns[6].DataPropertyName = "fare";

                        dgvBuses.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string busId = txtBusID.Text;
            string busName = txtBusName.Text;
            string route = txtRoute.Text;
            string seatCount = txtSeatCount.Text;
            string fare = txtFare.Text;
            TimeSpan departure = dtDeparture.Value.TimeOfDay;
            TimeSpan arrival = dtArrival.Value.TimeOfDay;

            if (string.IsNullOrEmpty(busId) ||string.IsNullOrEmpty(busName) ||string.IsNullOrEmpty(route) ||string.IsNullOrEmpty(seatCount) ||string.IsNullOrEmpty(fare))
            {
                MessageBox.Show("Please fill all required fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"INSERT INTO buses
                                    (bus_id,bus_name,route,
                                    source_city,destination_city,
                                    departure_time,arrival_time,
                                    seat_count,fare)

                                    VALUES

                                    (@id,@name,@route,
                                    'N/A','N/A',
                                    @departure,@arrival,
                                    @seat,@fare)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", busId);
                        cmd.Parameters.AddWithValue("@name", busName);
                        cmd.Parameters.AddWithValue("@route", route);
                        cmd.Parameters.AddWithValue("@departure", departure);
                        cmd.Parameters.AddWithValue("@arrival", arrival);
                        cmd.Parameters.AddWithValue("@seat", Convert.ToInt32(seatCount));
                        cmd.Parameters.AddWithValue("@fare", Convert.ToDecimal(fare));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Bus Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBusData();
                            ClearFields();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string busId = txtBusID.Text;
            string busName = txtBusName.Text;
            string route = txtRoute.Text;
            string seatCount = txtSeatCount.Text;

            if (string.IsNullOrEmpty(busId) || string.IsNullOrEmpty(busName))
            {
                MessageBox.Show("Please select a bus to update!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"UPDATE buses SET bus_name=@name,route=@route,departure_time=@departure,arrival_time=@arrival,seat_count=@seat,fare=@fare WHERE bus_id=@id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", busId);
                        cmd.Parameters.AddWithValue("@name", busName);
                        cmd.Parameters.AddWithValue("@route", route);
                        cmd.Parameters.AddWithValue("@departure", dtDeparture.Value.TimeOfDay);
                        cmd.Parameters.AddWithValue("@arrival", dtArrival.Value.TimeOfDay);
                        cmd.Parameters.AddWithValue("@seat", Convert.ToInt32(seatCount));
                        cmd.Parameters.AddWithValue("@fare", Convert.ToDecimal(txtFare.Text));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Bus Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBusData();
                            ClearFields();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string busId = txtBusID.Text;

            if (string.IsNullOrEmpty(busId))
            {
                MessageBox.Show("Please select a bus to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete this bus?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "DELETE FROM buses WHERE bus_id=@id";

                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", busId);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Bus Deleted Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBusData();
                            ClearFields();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Database Error: Cannot delete this bus because it has active reservations. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvBuses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBuses.Rows[e.RowIndex];

                txtBusID.Text = row.Cells[0].Value.ToString();
                txtBusName.Text = row.Cells[1].Value.ToString();
                txtRoute.Text = row.Cells[2].Value.ToString();

                dtDeparture.Value = DateTime.Today.Add(
                    (TimeSpan)row.Cells[3].Value);

                dtArrival.Value = DateTime.Today.Add(
                    (TimeSpan)row.Cells[4].Value);

                txtSeatCount.Text = row.Cells[5].Value.ToString();
                txtFare.Text = row.Cells[6].Value.ToString();

                txtBusID.ReadOnly = true;
            }
        }

        private void dgvBuses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void ClearFields()
        {
            txtBusID.Clear();
            txtBusName.Clear();
            txtRoute.Clear();
            txtSeatCount.Clear();
            txtFare.Clear();

            dtDeparture.Value = DateTime.Now;
            dtArrival.Value = DateTime.Now;

            txtBusID.ReadOnly = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
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

        private void label4_Click(object sender, EventArgs e) { }
        private void txtRoute_TextChanged(object sender, EventArgs e) { }
        private void txtBusName_TextChanged(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }

        private void txtBusID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
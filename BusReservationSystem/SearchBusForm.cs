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
    public partial class SearchBusForm : Form
    {
        private string connectionString = "server=localhost;database=bus_reservation_db;uid=root;pwd=;";
        public SearchBusForm()
        {
            InitializeComponent();
        }

        private void dgvBuses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.RowIndex >= 0)
            {
                string selectedBusID = dgvBuses.Rows[e.RowIndex].Cells[0].Value.ToString();
                string selectedBusName = dgvBuses.Rows[e.RowIndex].Cells[1].Value.ToString();
                string selectedRoute = dgvBuses.Rows[e.RowIndex].Cells[2].Value.ToString();
                MessageBox.Show("Fare = " + dgvBuses.Rows[e.RowIndex].Cells[5].Value.ToString());
                string fare = dgvBuses.Rows[e.RowIndex].Cells[5].Value.ToString();
                string travelDate = DateTime.Now.ToString("yyyy-MM-dd");
                string departure = dgvBuses.Rows[e.RowIndex].Cells[3].Value.ToString();
                string arrival = dgvBuses.Rows[e.RowIndex].Cells[4].Value.ToString();
                int seats = Convert.ToInt32(dgvBuses.CurrentRow.Cells[6].Value);

                ReservationForm seatScreen = new ReservationForm(selectedBusID, selectedBusName, selectedRoute, travelDate,departure,arrival, fare, seats);

                seatScreen.Show();
                this.Hide();
            }

        }

        private void SearchBusForm_Load(object sender, EventArgs e)
        {
            LoadCitiesFromDatabase();

            dgvBuses.AutoGenerateColumns = false;

            dgvBuses.Columns[0].DataPropertyName = "bus_id";
            dgvBuses.Columns[1].DataPropertyName = "bus_name";
            dgvBuses.Columns[2].DataPropertyName = "route";
            dgvBuses.Columns[3].DataPropertyName = "departure_time";
            dgvBuses.Columns[4].DataPropertyName = "arrival_time";
            dgvBuses.Columns[5].DataPropertyName = "fare";
            dgvBuses.Columns[6].DataPropertyName = "seat_count";
        }

        private void LoadCitiesFromDatabase()
        {
            cmbFrom.Items.Clear();
            cmbTo.Items.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT DISTINCT route FROM buses WHERE route IS NOT NULL AND route != ''";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string fullRoute = reader["route"].ToString(); 

                        if (fullRoute.Contains("-"))
                        {
                            string[] cities = fullRoute.Split('-');

                            if (cities.Length >= 2)
                            {
                                string source = cities[0].Trim();      // Colombo
                                string destination = cities[1].Trim(); // Kandy

                                if (!cmbFrom.Items.Contains(source))
                                {
                                    cmbFrom.Items.Add(source);
                                }

                                if (!cmbTo.Items.Contains(destination))
                                {
                                    cmbTo.Items.Add(destination);
                                }
                            }
                        }
                    }
                    reader.Close();

                    if (cmbFrom.Items.Count > 0) cmbFrom.SelectedIndex = 0;
                    if (cmbTo.Items.Count > 0) cmbTo.SelectedIndex = 0;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Anable to Load Data from Database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

     

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cmbFrom.SelectedItem == null || cmbTo.SelectedItem == null)
            {
                MessageBox.Show("Please select both From and To locations.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fromCity = cmbFrom.SelectedItem.ToString();
            string toCity = cmbTo.SelectedItem.ToString();
            string expectedRoute = fromCity + " - " + toCity;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT bus_id, bus_name, route, departure_time, arrival_time, fare, seat_count " +
                                   "FROM buses WHERE route = @route";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@route", expectedRoute);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvBuses.AutoGenerateColumns = false;

                    dgvBuses.DataSource = dt;

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No buses found for this route.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UserDashboard passengerDashboard = new UserDashboard();
            passengerDashboard.Show();
            this.Hide();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dgvBuses.CurrentRow != null && dgvBuses.CurrentRow.Index >= 0)
            {
                string selectedBusID = dgvBuses.CurrentRow.Cells[0].Value.ToString(); 
                string selectedBusName = dgvBuses.CurrentRow.Cells[1].Value.ToString(); 
                string selectedRoute = dgvBuses.CurrentRow.Cells[2].Value.ToString();
                MessageBox.Show("Fare = " + dgvBuses.CurrentRow.Cells[5].Value.ToString());
                string fare = dgvBuses.CurrentRow.Cells[5].Value.ToString(); 
                string travelDate = DateTime.Now.ToString("yyyy-MM-dd");
                string departure = dgvBuses.CurrentRow.Cells[3].Value.ToString();
                string arrival = dgvBuses.CurrentRow.Cells[4].Value.ToString();
                int seats = Convert.ToInt32(dgvBuses.CurrentRow.Cells[6].Value);

                ReservationForm seatSelection = new ReservationForm(selectedBusID, selectedBusName, selectedRoute, travelDate, departure,arrival, fare, seats);

                seatSelection.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a bus from the list before clicking Next.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

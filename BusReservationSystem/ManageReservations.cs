using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BusReservationSystem
{
    public partial class ManageReservations : Form
    {
        private string connectionString = "Server=localhost;Database=bus_reservation_db;Uid=root;Pwd=;";

        public ManageReservations()
        {
            InitializeComponent();
        }

        private void ManageReservations_Load(object sender, EventArgs e)
        {
            dgvReservations.AutoGenerateColumns = false;
            dgvReservations.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
            dgvReservations.EnableHeadersVisualStyles = false;
            dgvReservations.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;

            LoadAllReservations();
            LoadRoutesToComboBox();
            LoadStatusesToComboBox();
        }

        private void LoadAllReservations()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT r.reservation_id, u.full_name, b.bus_id, b.route, 
                                            r.travel_date, r.seat_no, r.amount, r.status 
                                     FROM reservations r
                                     JOIN users u ON r.user_id = u.user_id
                                     JOIN buses b ON r.bus_id = b.bus_id";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvReservations.Columns[0].DataPropertyName = "reservation_id";
                        dgvReservations.Columns[1].DataPropertyName = "full_name";
                        dgvReservations.Columns[2].DataPropertyName = "bus_id";
                        dgvReservations.Columns[3].DataPropertyName = "route";
                        dgvReservations.Columns[4].DataPropertyName = "travel_date";
                        dgvReservations.Columns[5].DataPropertyName = "seat_no";
                        dgvReservations.Columns[6].DataPropertyName = "amount";
                        dgvReservations.Columns[7].DataPropertyName = "status";

                        dgvReservations.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading reservations: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadRoutesToComboBox()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                cmbRoute.Items.Clear();
                cmbRoute.Items.Add("All Routes");

                string query = "SELECT DISTINCT route FROM buses";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmbRoute.Items.Add(reader["route"].ToString());
                }

                cmbRoute.SelectedIndex = 0;
            }
        }

        private void LoadStatusesToComboBox()
        {
            cmbStatus.Items.Clear();

            cmbStatus.Items.Add("All Status");
            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Confirmed");
            cmbStatus.Items.Add("Cancelled");

            cmbStatus.SelectedIndex = 0;
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"SELECT r.reservation_id, u.full_name, b.bus_id, b.route, 
                                            r.travel_date, r.seat_no, r.amount, r.status 
                                     FROM reservations r
                                     JOIN users u ON r.user_id = u.user_id
                                     JOIN buses b ON r.bus_id = b.bus_id
                                     WHERE r.travel_date BETWEEN @FromDate AND @ToDate";

                    if (cmbRoute.Text != "All Routes" && !string.IsNullOrEmpty(cmbRoute.Text))
                    {
                        query += " AND b.route = @Route";
                    }

                    if (cmbStatus.Text != "All Status" && !string.IsNullOrEmpty(cmbStatus.Text))
                    {
                        query += " AND r.status = @Status";
                    }

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FromDate", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@ToDate", dateTimePicker2.Value.ToString("yyyy-MM-dd"));

                        if (cmbRoute.Text != "All Routes" && !string.IsNullOrEmpty(cmbRoute.Text))
                        {
                            cmd.Parameters.AddWithValue("@Route", cmbRoute.Text);
                        }

                        if (cmbStatus.Text != "All Status" && !string.IsNullOrEmpty(cmbStatus.Text))
                        {
                            cmd.Parameters.AddWithValue("@Status", cmbStatus.Text);
                        }

                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dgvReservations.DataSource = dt;

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("No reservations found for the given criteria.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancelReservation_Click_1(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count > 0)
            {
                string resId = dgvReservations.SelectedRows[0].Cells[0].Value.ToString();
                string busId = dgvReservations.SelectedRows[0].Cells[2].Value.ToString();
                string seatNo = dgvReservations.SelectedRows[0].Cells[5].Value.ToString();
                string travelDate = Convert.ToDateTime(dgvReservations.SelectedRows[0].Cells[4].Value).ToString("yyyy-MM-dd");

                DialogResult result = MessageBox.Show("Are you sure you want to cancel this reservation?", "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();
                        MySqlTransaction trans = conn.BeginTransaction();

                        try
                        {
                            string updateRes = "UPDATE reservations SET status = 'Cancelled' WHERE reservation_id = @ResID";
                            MySqlCommand cmd1 = new MySqlCommand(updateRes, conn, trans);
                            cmd1.Parameters.AddWithValue("@ResID", resId);
                            cmd1.ExecuteNonQuery();

                            string updateSeat = "UPDATE seat_availability SET is_booked = 0 WHERE bus_id = @BusID AND seat_no = @SeatNo AND travel_date = @TravelDate";
                            MySqlCommand cmd2 = new MySqlCommand(updateSeat, conn, trans);
                            cmd2.Parameters.AddWithValue("@BusID", busId);
                            cmd2.Parameters.AddWithValue("@SeatNo", seatNo);
                            cmd2.Parameters.AddWithValue("@TravelDate", travelDate);
                            cmd2.ExecuteNonQuery();

                            trans.Commit();
                            MessageBox.Show("Reservation Cancelled Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAllReservations();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            MessageBox.Show("Transaction Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a reservation row from the table to cancel!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            cmbRoute.SelectedIndex = -1;
            cmbStatus.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Today.AddDays(-30);
            dateTimePicker2.Value = DateTime.Today.AddDays(30);
            LoadAllReservations();
        }


        private void btnExport_Click(object sender, EventArgs e)
        {

        }


        private void btnBack_Click_1(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Hide();
        }


        private void btnDashboard_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManageBusForm manageBus = new ManageBusForm();
            manageBus.Show();
            this.Hide();
        }

        private void btnReservation_Click(object sender, EventArgs e) { }

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

        private void dgvReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == 8)
            {

                DataGridViewRow row = dgvReservations.Rows[e.RowIndex];


                string details =
                    "Reservation ID : " + row.Cells[0].Value.ToString()
                    + "\nPassenger : " + row.Cells[1].Value.ToString()
                    + "\nBus : " + row.Cells[2].Value.ToString()
                    + "\nRoute : " + row.Cells[3].Value.ToString()
                    + "\nDate : " + row.Cells[4].Value.ToString()
                    + "\nSeat : " + row.Cells[5].Value.ToString()
                    + "\nAmount : LKR " + row.Cells[6].Value.ToString()
                    + "\nStatus : " + row.Cells[7].Value.ToString();


                MessageBox.Show(
                    details,
                    "Reservation Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

            }

        }


        private void label3_Click(object sender, EventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void cmbRoute_SelectedIndexChanged(object sender, EventArgs e) { }

        private void btnExport_Click_1(object sender, EventArgs e)
        {

            try
            {
                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "PDF Files|*.pdf";
                save.Title = "Export Reservations PDF";
                save.FileName = "Reservations_Report.pdf";


                if (save.ShowDialog() == DialogResult.OK)
                {

                    Document doc = new Document();

                    PdfWriter.GetInstance(doc, new FileStream(save.FileName, FileMode.Create));


                    doc.Open();


                    Paragraph title = new Paragraph(
                        "Bus Reservation Report"
                    );

                    title.Alignment = Element.ALIGN_CENTER;

                    doc.Add(title);

                    doc.Add(new Paragraph("\n"));


                    PdfPTable table = new PdfPTable(dgvReservations.Columns.Count - 1);


                    foreach (DataGridViewColumn column in dgvReservations.Columns)
                    {

                        if (column.HeaderText != "Action")
                        {
                            PdfPCell cell = new PdfPCell(
                                new Phrase(column.HeaderText)
                            );

                            table.AddCell(cell);
                        }

                    }


                    foreach (DataGridViewRow row in dgvReservations.Rows)
                    {

                        foreach (DataGridViewCell cell in row.Cells)
                        {

                            if (cell.ColumnIndex != 8)
                            {
                                table.AddCell(
                                    cell.Value?.ToString()
                                );
                            }

                        }

                    }


                    doc.Add(table);

                    doc.Close();


                    MessageBox.Show(
                        "Reservations exported successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Export Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }

}

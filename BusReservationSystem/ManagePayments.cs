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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace BusReservationSystem
{
    public partial class ManagePayments : Form
    {
        private string connectionString = "server=localhost;database=bus_reservation_db;uid=root;pwd=;";

        public ManagePayments()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
            //ManagePayments managePayments = new ManagePayments();
           // managePayments.Show();
            //this.Hide();

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

        private void ManagePayments_Load(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 0;

            dtFrom.Value = DateTime.Today.AddMonths(-1);
            dtTo.Value = DateTime.Today;

            dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayments.MultiSelect = false;
            dgvPayments.AllowUserToAddRows = false;
            dgvPayments.AllowUserToDeleteRows = false;
            dgvPayments.ReadOnly = true;
            dgvPayments.RowHeadersVisible = false;

            LoadPayments();
        }
        private void LoadPayments()
        {
            try
            {
                dgvPayments.Rows.Clear();

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"SELECT
                                    p.payment_id,
                                    p.reservation_id,
                                    u.full_name,
                                    p.payment_method,
                                    p.amount_paid,
                                    p.status,
                                    p.payment_date

                                    FROM payments p

                                    INNER JOIN reservations r
                                    ON p.reservation_id=r.reservation_id

                                    INNER JOIN users u
                                    ON r.user_id=u.user_id

                                    ORDER BY p.payment_date DESC";

                    MySqlCommand cmd = new MySqlCommand(query, con);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dgvPayments.Rows.Add(
                            reader["payment_id"],
                            reader["reservation_id"],
                            reader["full_name"],
                            reader["payment_method"],
                            "Rs. " + Convert.ToDecimal(reader["amount_paid"]).ToString("N2"),
                            reader["status"],
                            Convert.ToDateTime(reader["payment_date"]).ToString("dd-MM-yyyy"),
                            "View"
                        );
                    }

                    reader.Close();
                    dgvPayments.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvPayments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvPayments.Columns[e.ColumnIndex].Name == "colStatus")
            {
                if (e.Value == null)
                    return;

                string status = e.Value.ToString();

                if (status == "Paid")
                {
                    e.CellStyle.ForeColor = Color.Green;
                    e.CellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                else if (status == "Pending")
                {
                    e.CellStyle.ForeColor = Color.DarkOrange;
                    e.CellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                else if (status == "Refunded")
                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
                else if (status == "Failed")
                {
                    e.CellStyle.ForeColor = Color.DarkRed;
                    e.CellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtFrom.Value.Date > dtTo.Value.Date)
            {
                MessageBox.Show("From Date cannot be greater than To Date.");
                return;
            }
            try
            {
                dgvPayments.Rows.Clear();

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    string query = @"SELECT
                            p.payment_id,
                            p.reservation_id,
                            u.full_name,
                            p.payment_method,
                            p.amount_paid,
                            p.status,
                            p.payment_date

                            FROM payments p

                            INNER JOIN reservations r
                            ON p.reservation_id=r.reservation_id

                            INNER JOIN users u
                            ON r.user_id=u.user_id

                            WHERE DATE(p.payment_date)
                            BETWEEN @from AND @to";

                    if (cmbStatus.Text != "All Status")
                    {
                        query += " AND p.status=@status";
                    }

                    query += " ORDER BY p.payment_date DESC";

                    MySqlCommand cmd = new MySqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@from", dtFrom.Value.Date);
                    cmd.Parameters.AddWithValue("@to", dtTo.Value.Date);

                    if (cmbStatus.Text != "All Status")
                    {
                        cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                    }

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dgvPayments.Rows.Add(
                            reader["payment_id"],
                            reader["reservation_id"],
                            reader["full_name"],
                            reader["payment_method"],
                            "Rs. " + Convert.ToDecimal(reader["amount_paid"]).ToString("N2"),
                            reader["status"],
                            Convert.ToDateTime(reader["payment_date"]).ToString("dd-MM-yyyy"),
                            "View"
                        );
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cmbStatus.SelectedIndex = 0;

            dtFrom.Value = DateTime.Today.AddMonths(-1);
            dtTo.Value = DateTime.Today;

            LoadPayments();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashboard dashboard = new AdminDashboard();
            dashboard.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvPayments.CurrentRow == null)
            {
                MessageBox.Show("Please select a payment.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string paymentID = dgvPayments.CurrentRow.Cells[0].Value.ToString();
            string currentStatus = dgvPayments.CurrentRow.Cells[5].Value.ToString();

            if (currentStatus == "Refunded")
            {
                MessageBox.Show("This payment is already refunded.");
                return;
            }

            if (currentStatus != "Paid")
            {
                MessageBox.Show("Only Paid payments can be refunded.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to refund this payment?",
                "Confirm Refund",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        con.Open();

                        MySqlTransaction transaction = con.BeginTransaction();

                        try
                        {
                            string paymentQuery = @"UPDATE payments
                                            SET status='Refunded'
                                            WHERE payment_id=@id";

                            MySqlCommand paymentCmd = new MySqlCommand(paymentQuery, con, transaction);
                            paymentCmd.Parameters.AddWithValue("@id", paymentID);
                            paymentCmd.ExecuteNonQuery();

                           
                            string reservationQuery = @"UPDATE reservations
                                                SET status='Refunded'
                                                WHERE reservation_id =
                                                (SELECT reservation_id
                                                 FROM payments
                                                 WHERE payment_id=@id)";

                            MySqlCommand reservationCmd = new MySqlCommand(reservationQuery, con, transaction);
                            reservationCmd.Parameters.AddWithValue("@id", paymentID);
                            reservationCmd.ExecuteNonQuery();

                            transaction.Commit();

                            MessageBox.Show("Payment refunded successfully.",
                                "Success",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

                            LoadPayments();
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }
        private void dgvPayments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvPayments.Columns[e.ColumnIndex].Name == "colAction")
            {
                string paymentID = dgvPayments.Rows[e.RowIndex].Cells["colPaymentID"].Value.ToString();

                try
                {
                    using (MySqlConnection con = new MySqlConnection(connectionString))
                    {
                        con.Open();

                        string query = @"SELECT
                                    p.payment_id,
                                    p.payment_method,
                                    p.amount_paid,
                                    p.payment_date,
                                    p.status,
                                    r.reservation_id,
                                    r.travel_date,
                                    r.seat_no,
                                    u.full_name,
                                    u.phone,
                                    u.email
                                FROM payments p
                                INNER JOIN reservations r
                                    ON p.reservation_id = r.reservation_id
                                INNER JOIN users u
                                    ON r.user_id = u.user_id
                                WHERE p.payment_id=@id";

                        MySqlCommand cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@id", paymentID);

                        MySqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            string details =
                                "========= PAYMENT DETAILS =========\n\n" +
                                "Payment ID      : " + reader["payment_id"] + "\n" +
                                "Reservation ID : " + reader["reservation_id"] + "\n\n" +

                                "Passenger Name : " + reader["full_name"] + "\n" +
                                "Phone          : " + reader["phone"] + "\n" +
                                "Email          : " + reader["email"] + "\n\n" +

                                "Travel Date    : " +
                                Convert.ToDateTime(reader["travel_date"]).ToString("dd-MM-yyyy") + "\n" +

                                "Seat Number    : " + reader["seat_no"] + "\n\n" +

                                "Payment Method : " + reader["payment_method"] + "\n" +
                                "Amount Paid    : Rs. " +
                                Convert.ToDecimal(reader["amount_paid"]).ToString("N2") + "\n" +

                                "Status         : " + reader["status"] + "\n" +

                                "Payment Date   : " +
                                Convert.ToDateTime(reader["payment_date"]).ToString("dd-MM-yyyy");

                            MessageBox.Show(
                                details,
                                "Payment Details",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvPayments.Rows.Count == 0)
            {
                MessageBox.Show("No payment records to export.");
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF Files|*.pdf";
            save.Title = "Save Payment Report";
            save.FileName = "Payment_Report.pdf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Document doc = new Document(PageSize.A4.Rotate(), 10, 10, 20, 20);

                    PdfWriter.GetInstance(doc, new FileStream(save.FileName, FileMode.Create));

                    doc.Open();

                    Paragraph title = new Paragraph("Bus Reservation Management System\n\nPayment Report\n\nGenerated Date : " + DateTime.Now.ToString("dd-MM-yyyy HH:mm") + "\n\n");
                    title.Alignment = Element.ALIGN_CENTER;
                    title.SpacingAfter = 20;

                    doc.Add(title);

                    PdfPTable table = new PdfPTable(dgvPayments.Columns.Count - 1);

                    table.WidthPercentage = 100;

                    for (int i = 0; i < dgvPayments.Columns.Count; i++)
                    {
                        if (dgvPayments.Columns[i].Name == "colAction")
                            continue;

                        table.AddCell(new Phrase(dgvPayments.Columns[i].HeaderText));
                    }

                    foreach (DataGridViewRow row in dgvPayments.Rows)
                    {
                        if (row.IsNewRow)
                            continue;

                        for (int i = 0; i < dgvPayments.Columns.Count; i++)
                        {
                            if (dgvPayments.Columns[i].Name == "colAction")
                                continue;

                            table.AddCell(row.Cells[i].Value?.ToString());
                        }
                    }

                    doc.Add(table);

                    doc.Close();

                    MessageBox.Show("PDF exported successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}

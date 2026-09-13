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
using System.Drawing.Printing;

namespace BusReservationSystem
{
    public partial class ReportForm : Form
    {
        string connectionString ="server=localhost;database=bus_reservation_db;uid=root;pwd=";

        PrintDocument printDocument = new PrintDocument();

        public ReportForm()
        {
            InitializeComponent();
            printDocument.PrintPage += printDocument_PrintPage;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            dgvReport.EnableHeadersVisualStyles = false;

            dgvReport.ColumnHeadersDefaultCellStyle.BackColor =
                Color.Navy;

            dgvReport.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvReport.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);


            dgvReport.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cmbReportType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select report type");
                return;
            }


            // Update Report Preview Header

            label6.Text = cmbReportType.SelectedItem.ToString();


            label7.Text =
            "From : " + dtpFrom.Value.ToString("yyyy-MM-dd") +
            "     To : " +
            dtpTo.Value.ToString("yyyy-MM-dd");




            string type = cmbReportType.SelectedItem.ToString();



            if (type == "Daily Booking Report")
            {
                LoadDailyReport();
            }


            else if (type == "Monthly Booking Report")
            {
                LoadMonthlyReport();
            }


            else if (type == "Revenue Report")
            {
                LoadRevenueReport();
            }


            else if (type == "Bus Reservation Report")
            {
                LoadBusReport();
            }

        }

        private void LoadDailyReport()
        {

            dgvReport.Rows.Clear();

            dgvReport.Columns.Clear();


            dgvReport.Columns.Add("Date", "Date");
            dgvReport.Columns.Add("Reservations", "Total Reservations");
            dgvReport.Columns.Add("Revenue", "Revenue");


            using (MySqlConnection con =
                new MySqlConnection(connectionString))
            {

                string query =
                @"SELECT 
                DATE(booking_date),
                COUNT(*),
                SUM(amount)

                FROM reservations

                WHERE booking_date BETWEEN @from AND @to

                GROUP BY DATE(booking_date)";


                MySqlCommand cmd =
                new MySqlCommand(query, con);


                cmd.Parameters.AddWithValue("@from",
                dtpFrom.Value.Date);


                cmd.Parameters.AddWithValue("@to",
                dtpTo.Value.Date);



                con.Open();


                MySqlDataReader dr =
                cmd.ExecuteReader();


                while (dr.Read())
                {

                    dgvReport.Rows.Add(
                    dr[0],
                    dr[1],
                    dr[2] + " LKR");

                }

            }


        }

        private void LoadMonthlyReport()
        {

            dgvReport.Rows.Clear();


            dgvReport.Columns.Clear();


            dgvReport.Columns.Add("Month", "Month");
            dgvReport.Columns.Add("Total", "Reservations");
            dgvReport.Columns.Add("Income", "Revenue");



            using (MySqlConnection con =
            new MySqlConnection(connectionString))
            {

                string query =

                @"SELECT 
                MONTHNAME(booking_date),
                COUNT(*),
                SUM(amount)

                FROM reservations

                WHERE booking_date BETWEEN @from AND @to

                GROUP BY MONTH(booking_date)";


                MySqlCommand cmd =
                new MySqlCommand(query, con);


                cmd.Parameters.AddWithValue("@from",
                dtpFrom.Value.Date);


                cmd.Parameters.AddWithValue("@to",
                dtpTo.Value.Date);


                con.Open();


                MySqlDataReader dr =
                cmd.ExecuteReader();


                while (dr.Read())
                {

                    dgvReport.Rows.Add(
                    dr[0],
                    dr[1],
                    dr[2] + " LKR");

                }

            }

        }

        private void LoadRevenueReport()
        {

            dgvReport.Rows.Clear();


            dgvReport.Columns.Clear();


            dgvReport.Columns.Add("Date", "Date");
            dgvReport.Columns.Add("Income", "Income");



            using (MySqlConnection con =
            new MySqlConnection(connectionString))
            {


                string query =

                @"SELECT 
                DATE(booking_date),
                SUM(amount)

                FROM reservations

                WHERE booking_date BETWEEN @from AND @to

                GROUP BY DATE(booking_date)";



                MySqlCommand cmd =
                new MySqlCommand(query, con);


                cmd.Parameters.AddWithValue("@from",
                dtpFrom.Value.Date);


                cmd.Parameters.AddWithValue("@to",
                dtpTo.Value.Date);



                con.Open();


                MySqlDataReader dr =
                cmd.ExecuteReader();



                while (dr.Read())
                {

                    dgvReport.Rows.Add(
                    dr[0],
                    dr[1] + " LKR");

                }

            }


        }

        private void LoadBusReport()
        {

            dgvReport.Rows.Clear();


            dgvReport.Columns.Clear();


            dgvReport.Columns.Add("Bus", "Bus ID");
            dgvReport.Columns.Add("Seats", "Seats Booked");



            using (MySqlConnection con =
            new MySqlConnection(connectionString))
            {


                string query =

                @"SELECT 
                bus_id,
                COUNT(seat_no)

                FROM reservations

                WHERE booking_date BETWEEN @from AND @to

                GROUP BY bus_id";


                MySqlCommand cmd =
                new MySqlCommand(query, con);


                cmd.Parameters.AddWithValue("@from",
                dtpFrom.Value.Date);


                cmd.Parameters.AddWithValue("@to",
                dtpTo.Value.Date);



                con.Open();


                MySqlDataReader dr =
                cmd.ExecuteReader();



                while (dr.Read())
                {

                    dgvReport.Rows.Add(
                    dr[0],
                    dr[1]);

                }


            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
            this.Hide();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog preview =
           new PrintPreviewDialog();


            preview.Document = printDocument;


            preview.ShowDialog();
        }

        private void printDocument_PrintPage(object sender,
       PrintPageEventArgs e)
        {


            Bitmap bmp =
            new Bitmap(dgvReport.Width,
            dgvReport.Height);


            dgvReport.DrawToBitmap(
            bmp,
            dgvReport.ClientRectangle);



            e.Graphics.DrawString(
            "Bus Reservation Report",
            new Font("Arial", 18, FontStyle.Bold),
            Brushes.Black,
            100, 50);



            e.Graphics.DrawImage(
            bmp,
            50,
            100);

        }
    }

}

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

namespace BusReservationSystem
{
    public partial class ManageUsers : Form
    {
        private string connectionString = "Server=localhost;Database=bus_reservation_db;Uid=root;Pwd=;";
        public ManageUsers()
        {
            InitializeComponent();
            LoadUsers();

            dgvUsers.CellClick += dgvUsers_CellClick;
            btnRefresh.Click += btnRefresh_Click;
            btnExport.Click += btnExport_Click;
            btnSearch.Click += btnSearch_Click;
            btnBack.Click += btnBack_Click;
        }

        private void LoadUsers()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    string query =
                    "SELECT user_id, full_name, username, email, phone, role, status FROM users";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, con);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvUsers.Rows.Clear();


                    foreach (DataRow row in dt.Rows)
                    {
                        dgvUsers.Rows.Add(
                            row["user_id"],
                            row["full_name"],
                            row["username"],
                            row["email"],
                            row["phone"],
                            row["role"],
                            row["status"]
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void ManageUsers_Load(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }
        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == 7)
            {

                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];


                MessageBox.Show(
                "User ID : " + row.Cells[0].Value +
                "\nName : " + row.Cells[1].Value +
                "\nUsername : " + row.Cells[2].Value +
                "\nEmail : " + row.Cells[3].Value +
                "\nPhone : " + row.Cells[4].Value +
                "\nRole : " + row.Cells[5].Value +
                "\nStatus : " + row.Cells[6].Value,

                "User Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            }

        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {

                using (MySqlConnection con = new MySqlConnection(connectionString))
                {

                    con.Open();


                    string query =
                    @"SELECT user_id, full_name, username, email, phone, role, status
                      FROM users
                      WHERE full_name LIKE @search
                      OR username LIKE @search
                      OR email LIKE @search";


                    MySqlCommand cmd = new MySqlCommand(query, con);


                    cmd.Parameters.AddWithValue("@search",
                    "%" + txtSearch.Text + "%");


                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    DataTable dt = new DataTable();

                    da.Fill(dt);


                    dgvUsers.Rows.Clear();


                    foreach (DataRow row in dt.Rows)
                    {
                        dgvUsers.Rows.Add(
                            row["user_id"],
                            row["full_name"],
                            row["username"],
                            row["email"],
                            row["phone"],
                            row["role"],
                            row["status"]
                        );
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStatus.Text == "All Status")
            {
                LoadUsers();
                return;
            }


            using (MySqlConnection con = new MySqlConnection(connectionString))
            {

                con.Open();


                string query =
                "SELECT user_id,full_name,username,email,phone,role,status FROM users WHERE status=@status";


                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@status",
                cmbStatus.Text);



                MySqlDataReader dr = cmd.ExecuteReader();


                dgvUsers.Rows.Clear();


                while (dr.Read())
                {

                    dgvUsers.Rows.Add(
                        dr["user_id"],
                        dr["full_name"],
                        dr["username"],
                        dr["email"],
                        dr["phone"],
                        dr["role"],
                        dr["status"]
                    );

                }

            }

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "PDF Files|*.pdf";
                save.Title = "Export Users PDF";
                save.FileName = "Users_Report.pdf";


                if (save.ShowDialog() == DialogResult.OK)
                {

                    Document doc = new Document();


                    PdfWriter.GetInstance(
                        doc,
                        new FileStream(save.FileName, FileMode.Create)
                    );


                    doc.Open();


                    Paragraph title = new Paragraph(
                        "Manage Users Report",
                        FontFactory.GetFont(
                            FontFactory.HELVETICA_BOLD,
                            16
                        )
                    );


                    title.Alignment = Element.ALIGN_CENTER;


                    doc.Add(title);


                    doc.Add(new Paragraph("\n"));



                    // Create Table
                    PdfPTable table = new PdfPTable(
                        dgvUsers.Columns.Count
                    );


                    table.WidthPercentage = 100;



                    // Column Headers
                    foreach (DataGridViewColumn column in dgvUsers.Columns)
                    {

                        if (column.HeaderText != "Action")
                        {
                            PdfPCell cell = new PdfPCell(
                                new Phrase(column.HeaderText)
                            );

                            table.AddCell(cell);
                        }

                    }



                    // Rows
                    foreach (DataGridViewRow row in dgvUsers.Rows)
                    {

                        if (row.IsNewRow)
                            continue;


                        foreach (DataGridViewCell cell in row.Cells)
                        {

                            table.AddCell(
                                cell.Value?.ToString()
                            );

                        }

                    }



                    doc.Add(table);


                    doc.Close();



                    MessageBox.Show(
                        "Users exported successfully!",
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            AdminDashboard dashboard = new AdminDashboard();

            dashboard.Show();

            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();

                    string query =
                    @"SELECT user_id, full_name, username, email, phone, role, status
                        FROM users
                        WHERE full_name LIKE @name
                        AND status LIKE @status";


                    MySqlCommand cmd = new MySqlCommand(query, con);


                    cmd.Parameters.AddWithValue("@name",
                    "%" + txtSearch.Text + "%");


                    string status = cmbStatus.Text;


                    if (status == "All Status" || status == "")
                    {
                        status = "%";
                    }
                    else
                    {
                        status = cmbStatus.Text;
                    }


                    cmd.Parameters.AddWithValue("@status",
                    status);



                    MySqlDataReader dr = cmd.ExecuteReader();


                    dgvUsers.Rows.Clear();


                    while (dr.Read())
                    {

                        dgvUsers.Rows.Add(
                            dr["user_id"],
                            dr["full_name"],
                            dr["username"],
                            dr["email"],
                            dr["phone"],
                            dr["role"],
                            dr["status"]
                        );

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = ShowInputBox("Enter Full Name");
                string username = ShowInputBox("Enter Username");
                string email = ShowInputBox("Enter Email");
                string phone = ShowInputBox("Enter Phone Number");


                if (name == "" || username == "" || email == "" || phone == "")
                {
                    MessageBox.Show(
                        "Please enter all details",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }


                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();


                    string query =
                    @"INSERT INTO users
                        (full_name, username, email, phone, role, status)
                        VALUES
                        (@name,@username,@email,@phone,'User','Active')";


                    MySqlCommand cmd = new MySqlCommand(query, con);


                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phone", phone);


                    int result = cmd.ExecuteNonQuery();


                    if (result > 0)
                    {
                        MessageBox.Show(
                            "User Added Successfully",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);


                        LoadUsers();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string ShowInputBox(string message)
        {
            Form prompt = new Form();

            prompt.Width = 300;
            prompt.Height = 150;
            prompt.Text = "Add User";


            Label textLabel = new Label();
            textLabel.Text = message;
            textLabel.Left = 20;
            textLabel.Top = 20;
            textLabel.AutoSize = true;


            TextBox inputBox = new TextBox();
            inputBox.Left = 20;
            inputBox.Top = 50;
            inputBox.Width = 240;


            Button confirmation = new Button();
            confirmation.Text = "OK";
            confirmation.Left = 100;
            confirmation.Top = 80;
            confirmation.DialogResult = DialogResult.OK;


            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.Controls.Add(confirmation);


            prompt.AcceptButton = confirmation;


            if (prompt.ShowDialog() == DialogResult.OK)
            {
                return inputBox.Text;
            }

            return "";
        }
    }

}

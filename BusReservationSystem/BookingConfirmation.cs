using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace BusReservationSystem
{
    public partial class BookingConfirmation : Form
    {
        private string reservationID;
        private string busName;
        private string route;
        private string travelDate;
        private string seatNo;
        private string amount;

        public BookingConfirmation()
        {
            InitializeComponent();
        }

        public BookingConfirmation(
            string id,
            string bus,
            string routeName,
            string date,
            string seat,
            string total)
        {
            InitializeComponent();

            reservationID = id;
            busName = bus;
            route = routeName;
            travelDate = date;
            seatNo = seat;
            amount = total;
        }

        private void BookingConfirmation_Load(object sender, EventArgs e)
        {
            lblReservationID.Text = reservationID;
            lblBus.Text = busName;
            lblRoute.Text = route;
            lblDate.Text = travelDate;
            lblSeat.Text = seatNo;
            lblAmount.Text = "LKR " + amount;
        }

        private void btnPrintTicket_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ticket Printed Successfully!");
        }

        private void btnViewMyReservations_Click(object sender, EventArgs e)
        {
            MyReservationForm_history_ frm = new MyReservationForm_history_();
            frm.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UserDashboard dashboard = new UserDashboard();
            dashboard.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnPrintTicket_Click_1(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();

            pd.PrintPage += (s, ev) =>
            {
                Font titleFont = new Font("Arial", 18, FontStyle.Bold);
                Font bodyFont = new Font("Arial", 12);

                int y = 50;

                ev.Graphics.DrawString("BUS RESERVATION TICKET", titleFont, Brushes.Black, 100, y);

                y += 50;
                ev.Graphics.DrawString("Reservation ID : " + lblReservationID.Text, bodyFont, Brushes.Black, 100, y);

                y += 30;
                ev.Graphics.DrawString("Bus : " + lblBus.Text, bodyFont, Brushes.Black, 100, y);

                y += 30;
                ev.Graphics.DrawString("Route : " + lblRoute.Text, bodyFont, Brushes.Black, 100, y);

                y += 30;
                ev.Graphics.DrawString("Date : " + lblDate.Text, bodyFont, Brushes.Black, 100, y);

                y += 30;
                ev.Graphics.DrawString("Seat : " + lblSeat.Text, bodyFont, Brushes.Black, 100, y);

                y += 30;
                ev.Graphics.DrawString("Amount : " + lblAmount.Text, bodyFont, Brushes.Black, 100, y);
            };

            PrintPreviewDialog preview = new PrintPreviewDialog();
            preview.Document = pd;
            preview.ShowDialog();
        }

        private void btnViewMyReservations_Click_1(object sender, EventArgs e)
        {
            MyReservationForm_history_ frm = new MyReservationForm_history_();
            frm.Show();
            this.Hide();

        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            UserDashboard dashboard = new UserDashboard();
            dashboard.Show();
            this.Hide();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
namespace BusReservationSystem
{
    partial class ManageBusForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtArrival = new System.Windows.Forms.DateTimePicker();
            this.txtFare = new System.Windows.Forms.TextBox();
            this.dtDeparture = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtSeatCount = new System.Windows.Forms.TextBox();
            this.txtRoute = new System.Windows.Forms.TextBox();
            this.txtBusName = new System.Windows.Forms.TextBox();
            this.txtBusID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvBuses = new System.Windows.Forms.DataGridView();
            this.colBusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeparture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArrival = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeatCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnReservation = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuses)).BeginInit();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(255, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Buses";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.dtArrival);
            this.panel1.Controls.Add(this.txtFare);
            this.panel1.Controls.Add(this.dtDeparture);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btndelete);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.txtSeatCount);
            this.panel1.Controls.Add(this.txtRoute);
            this.panel1.Controls.Add(this.txtBusName);
            this.panel1.Controls.Add(this.txtBusID);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(260, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(838, 237);
            this.panel1.TabIndex = 1;
            // 
            // dtArrival
            // 
            this.dtArrival.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtArrival.Location = new System.Drawing.Point(226, 125);
            this.dtArrival.Name = "dtArrival";
            this.dtArrival.Size = new System.Drawing.Size(180, 22);
            this.dtArrival.TabIndex = 23;
            // 
            // txtFare
            // 
            this.txtFare.Location = new System.Drawing.Point(432, 125);
            this.txtFare.Name = "txtFare";
            this.txtFare.Size = new System.Drawing.Size(180, 22);
            this.txtFare.TabIndex = 22;
            // 
            // dtDeparture
            // 
            this.dtDeparture.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtDeparture.Location = new System.Drawing.Point(20, 126);
            this.dtDeparture.Name = "dtDeparture";
            this.dtDeparture.Size = new System.Drawing.Size(180, 22);
            this.dtDeparture.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(427, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 28);
            this.label9.TabIndex = 19;
            this.label9.Text = "Fare";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(221, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 28);
            this.label8.TabIndex = 18;
            this.label8.Text = "Arrivel Time";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(20, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(155, 28);
            this.label7.TabIndex = 17;
            this.label7.Text = "Departure Time";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightGray;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(638, 177);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(180, 40);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.button3_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.Red;
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndelete.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.Color.White;
            this.btndelete.Location = new System.Drawing.Point(432, 177);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(180, 40);
            this.btndelete.TabIndex = 15;
            this.btndelete.Text = "DELETE";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(226, 177);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(180, 40);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.LimeGreen;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.Location = new System.Drawing.Point(20, 177);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(180, 40);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtSeatCount
            // 
            this.txtSeatCount.Location = new System.Drawing.Point(638, 53);
            this.txtSeatCount.Name = "txtSeatCount";
            this.txtSeatCount.Size = new System.Drawing.Size(180, 22);
            this.txtSeatCount.TabIndex = 7;
            // 
            // txtRoute
            // 
            this.txtRoute.Location = new System.Drawing.Point(432, 53);
            this.txtRoute.Name = "txtRoute";
            this.txtRoute.Size = new System.Drawing.Size(180, 22);
            this.txtRoute.TabIndex = 6;
            this.txtRoute.TextChanged += new System.EventHandler(this.txtRoute_TextChanged);
            // 
            // txtBusName
            // 
            this.txtBusName.Location = new System.Drawing.Point(226, 53);
            this.txtBusName.Name = "txtBusName";
            this.txtBusName.Size = new System.Drawing.Size(180, 22);
            this.txtBusName.TabIndex = 5;
            this.txtBusName.TextChanged += new System.EventHandler(this.txtBusName_TextChanged);
            // 
            // txtBusID
            // 
            this.txtBusID.Location = new System.Drawing.Point(20, 53);
            this.txtBusID.Name = "txtBusID";
            this.txtBusID.Size = new System.Drawing.Size(180, 22);
            this.txtBusID.TabIndex = 4;
            this.txtBusID.TextChanged += new System.EventHandler(this.txtBusID_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(633, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 28);
            this.label5.TabIndex = 3;
            this.label5.Text = "Seat Count";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(427, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 28);
            this.label4.TabIndex = 2;
            this.label4.Text = "Route";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(221, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 28);
            this.label3.TabIndex = 1;
            this.label3.Text = "Bus Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "Bus ID";
            // 
            // dgvBuses
            // 
            this.dgvBuses.AllowUserToAddRows = false;
            this.dgvBuses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBuses.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBuses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBusID,
            this.colBusName,
            this.colRoute,
            this.colDeparture,
            this.colArrival,
            this.colSeatCount,
            this.colFare,
            this.colDelete,
            this.colEdit});
            this.dgvBuses.GridColor = System.Drawing.Color.White;
            this.dgvBuses.Location = new System.Drawing.Point(262, 305);
            this.dgvBuses.Name = "dgvBuses";
            this.dgvBuses.ReadOnly = true;
            this.dgvBuses.RowHeadersWidth = 51;
            this.dgvBuses.RowTemplate.Height = 24;
            this.dgvBuses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBuses.Size = new System.Drawing.Size(836, 304);
            this.dgvBuses.TabIndex = 2;
            this.dgvBuses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBuses_CellClick);
            this.dgvBuses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBuses_CellContentClick);
            // 
            // colBusID
            // 
            this.colBusID.HeaderText = "Bus ID";
            this.colBusID.MinimumWidth = 6;
            this.colBusID.Name = "colBusID";
            this.colBusID.ReadOnly = true;
            // 
            // colBusName
            // 
            this.colBusName.HeaderText = "Bus Name";
            this.colBusName.MinimumWidth = 6;
            this.colBusName.Name = "colBusName";
            this.colBusName.ReadOnly = true;
            // 
            // colRoute
            // 
            this.colRoute.HeaderText = "Route";
            this.colRoute.MinimumWidth = 6;
            this.colRoute.Name = "colRoute";
            this.colRoute.ReadOnly = true;
            // 
            // colDeparture
            // 
            this.colDeparture.HeaderText = "Departure";
            this.colDeparture.MinimumWidth = 6;
            this.colDeparture.Name = "colDeparture";
            this.colDeparture.ReadOnly = true;
            // 
            // colArrival
            // 
            this.colArrival.HeaderText = "Arrival";
            this.colArrival.MinimumWidth = 6;
            this.colArrival.Name = "colArrival";
            this.colArrival.ReadOnly = true;
            // 
            // colSeatCount
            // 
            this.colSeatCount.HeaderText = "Seat Count";
            this.colSeatCount.MinimumWidth = 6;
            this.colSeatCount.Name = "colSeatCount";
            this.colSeatCount.ReadOnly = true;
            // 
            // colFare
            // 
            this.colFare.HeaderText = "Fare";
            this.colFare.MinimumWidth = 6;
            this.colFare.Name = "colFare";
            this.colFare.ReadOnly = true;
            // 
            // colDelete
            // 
            this.colDelete.HeaderText = "Action";
            this.colDelete.MinimumWidth = 6;
            this.colDelete.Name = "colDelete";
            this.colDelete.ReadOnly = true;
            this.colDelete.Text = "🗑";
            this.colDelete.UseColumnTextForButtonValue = true;
            // 
            // colEdit
            // 
            this.colEdit.HeaderText = "Action";
            this.colEdit.MinimumWidth = 6;
            this.colEdit.Name = "colEdit";
            this.colEdit.ReadOnly = true;
            this.colEdit.Text = "✏";
            this.colEdit.UseColumnTextForButtonValue = true;
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.Navy;
            this.panelSidebar.Controls.Add(this.btnPayment);
            this.panelSidebar.Controls.Add(this.btnReservation);
            this.panelSidebar.Controls.Add(this.btnProfile);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.button4);
            this.panelSidebar.Controls.Add(this.button1);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Controls.Add(this.label6);
            this.panelSidebar.Controls.Add(this.pictureBox1);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(250, 630);
            this.panelSidebar.TabIndex = 3;
            // 
            // btnPayment
            // 
            this.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayment.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.ForeColor = System.Drawing.Color.White;
            this.btnPayment.Image = global::BusReservationSystem.Properties.Resources.payee1n;
            this.btnPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayment.Location = new System.Drawing.Point(25, 391);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnPayment.Size = new System.Drawing.Size(200, 45);
            this.btnPayment.TabIndex = 12;
            this.btnPayment.Text = "Payment";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnReservation
            // 
            this.btnReservation.BackColor = System.Drawing.Color.Navy;
            this.btnReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservation.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReservation.ForeColor = System.Drawing.Color.White;
            this.btnReservation.Image = global::BusReservationSystem.Properties.Resources.bus21;
            this.btnReservation.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReservation.Location = new System.Drawing.Point(25, 243);
            this.btnReservation.Name = "btnReservation";
            this.btnReservation.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnReservation.Size = new System.Drawing.Size(200, 45);
            this.btnReservation.TabIndex = 11;
            this.btnReservation.Text = "Reservation";
            this.btnReservation.UseVisualStyleBackColor = false;
            this.btnReservation.Click += new System.EventHandler(this.btnReservation_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.ForeColor = System.Drawing.Color.White;
            this.btnProfile.Image = global::BusReservationSystem.Properties.Resources.users1;
            this.btnProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.Location = new System.Drawing.Point(25, 318);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnProfile.Size = new System.Drawing.Size(200, 45);
            this.btnProfile.TabIndex = 10;
            this.btnProfile.Text = "Users";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = global::BusReservationSystem.Properties.Resources.logout;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(25, 529);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnLogout.Size = new System.Drawing.Size(200, 45);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = global::BusReservationSystem.Properties.Resources.report1new;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(25, 460);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.button4.Size = new System.Drawing.Size(200, 45);
            this.button4.TabIndex = 8;
            this.button4.Text = "Reports";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::BusReservationSystem.Properties.Resources.manage1;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(25, 176);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(200, 45);
            this.button1.TabIndex = 5;
            this.button1.Text = "Buses";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.Navy;
            this.btnDashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = global::BusReservationSystem.Properties.Resources.dashboard;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(25, 104);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(200, 45);
            this.btnDashboard.TabIndex = 4;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(118, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 28);
            this.label6.TabIndex = 1;
            this.label6.Text = "Admin";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BusReservationSystem.Properties.Resources.administrator_male1;
            this.pictureBox1.Location = new System.Drawing.Point(32, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ManageBusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1129, 630);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.dgvBuses);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ManageBusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Buses";
            this.Load += new System.EventHandler(this.ManageBusForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuses)).EndInit();
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBusName;
        private System.Windows.Forms.TextBox txtBusID;
        private System.Windows.Forms.TextBox txtSeatCount;
        private System.Windows.Forms.TextBox txtRoute;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvBuses;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnReservation;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtArrival;
        private System.Windows.Forms.TextBox txtFare;
        private System.Windows.Forms.DateTimePicker dtDeparture;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeparture;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArrival;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeatCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFare;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
        private System.Windows.Forms.DataGridViewButtonColumn colEdit;
    }
}
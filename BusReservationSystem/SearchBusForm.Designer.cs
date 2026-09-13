namespace BusReservationSystem
{
    partial class SearchBusForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.cmbFrom = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBuses = new System.Windows.Forms.DataGridView();
            this.colBusID = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colBusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRoute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeparture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArrival = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeats = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSelectBus = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuses)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dtDate);
            this.panel1.Controls.Add(this.cmbTo);
            this.panel1.Controls.Add(this.cmbFrom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 131);
            this.panel1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(813, 54);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(148, 38);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtDate
            // 
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(486, 66);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(165, 22);
            this.dtDate.TabIndex = 6;
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(265, 64);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(182, 24);
            this.cmbTo.TabIndex = 5;
            // 
            // cmbFrom
            // 
            this.cmbFrom.FormattingEnabled = true;
            this.cmbFrom.Location = new System.Drawing.Point(26, 64);
            this.cmbFrom.Name = "cmbFrom";
            this.cmbFrom.Size = new System.Drawing.Size(194, 24);
            this.cmbFrom.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(481, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(260, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "To";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(21, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "From";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(19, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Available Buses";
            // 
            // dgvBuses
            // 
            this.dgvBuses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvBuses.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBuses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBuses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBusID,
            this.colBusName,
            this.colRoute,
            this.colDeparture,
            this.colArrival,
            this.colFare,
            this.colSeats,
            this.btnSelectBus});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBuses.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBuses.Location = new System.Drawing.Point(19, 200);
            this.dgvBuses.Name = "dgvBuses";
            this.dgvBuses.RowHeadersWidth = 51;
            this.dgvBuses.RowTemplate.Height = 24;
            this.dgvBuses.Size = new System.Drawing.Size(942, 291);
            this.dgvBuses.TabIndex = 2;
            this.dgvBuses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBuses_CellContentClick);
            // 
            // colBusID
            // 
            this.colBusID.DataPropertyName = "bus_id";
            this.colBusID.HeaderText = "Bus ID";
            this.colBusID.MinimumWidth = 6;
            this.colBusID.Name = "colBusID";
            this.colBusID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBusID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colBusID.Width = 72;
            // 
            // colBusName
            // 
            this.colBusName.DataPropertyName = "bus_name";
            this.colBusName.HeaderText = "Bus Name";
            this.colBusName.MinimumWidth = 6;
            this.colBusName.Name = "colBusName";
            this.colBusName.Width = 117;
            // 
            // colRoute
            // 
            this.colRoute.DataPropertyName = "route";
            this.colRoute.HeaderText = "Route";
            this.colRoute.MinimumWidth = 6;
            this.colRoute.Name = "colRoute";
            this.colRoute.Width = 92;
            // 
            // colDeparture
            // 
            this.colDeparture.DataPropertyName = "departure_time";
            this.colDeparture.HeaderText = "Departure Time";
            this.colDeparture.MinimumWidth = 6;
            this.colDeparture.Name = "colDeparture";
            this.colDeparture.Width = 160;
            // 
            // colArrival
            // 
            this.colArrival.DataPropertyName = "arrival_time";
            this.colArrival.HeaderText = "Arrival Time";
            this.colArrival.MinimumWidth = 6;
            this.colArrival.Name = "colArrival";
            this.colArrival.Width = 133;
            // 
            // colFare
            // 
            this.colFare.DataPropertyName = "fare";
            this.colFare.HeaderText = "Fare";
            this.colFare.MinimumWidth = 6;
            this.colFare.Name = "colFare";
            this.colFare.Width = 76;
            // 
            // colSeats
            // 
            this.colSeats.DataPropertyName = "seat_count";
            this.colSeats.HeaderText = "Available Seats";
            this.colSeats.MinimumWidth = 6;
            this.colSeats.Name = "colSeats";
            this.colSeats.Width = 155;
            // 
            // btnSelectBus
            // 
            this.btnSelectBus.DataPropertyName = "btnSelectBus";
            this.btnSelectBus.HeaderText = "Select";
            this.btnSelectBus.MinimumWidth = 6;
            this.btnSelectBus.Name = "btnSelectBus";
            this.btnSelectBus.Text = "Select";
            this.btnSelectBus.UseColumnTextForButtonValue = true;
            this.btnSelectBus.Width = 69;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Silver;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.Location = new System.Drawing.Point(19, 507);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(175, 46);
            this.btnBack.TabIndex = 18;
            this.btnBack.Text = "BACK";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(786, 507);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(175, 46);
            this.btnNext.TabIndex = 19;
            this.btnNext.Text = "NEXT";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // SearchBusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(982, 571);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvBuses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SearchBusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Bus";
            this.Load += new System.EventHandler(this.SearchBusForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.ComboBox cmbFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.DataGridView dgvBuses;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.DataGridViewButtonColumn colBusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeparture;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArrival;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFare;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSeats;
        private System.Windows.Forms.DataGridViewButtonColumn btnSelectBus;
    }
}
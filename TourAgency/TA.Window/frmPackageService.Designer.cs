namespace TA.Window
{
    partial class frmPackageService
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPackage = new System.Windows.Forms.ComboBox();
            this.dgvPackageDetails = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpCardExpiry = new System.Windows.Forms.DateTimePicker();
            this.txtHolderName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCardName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCardPin = new System.Windows.Forms.TextBox();
            this.txtCardType = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dtpExpiry = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassport = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lbPassenger = new System.Windows.Forms.ListBox();
            this.btnBookRoom = new System.Windows.Forms.Button();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGuestName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGuestPassport = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtGuestAccount = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dgvRoomDetails = new System.Windows.Forms.DataGridView();
            this.dgvFlightInformation = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackageDetails)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlightInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Package Selection";
            // 
            // cmbPackage
            // 
            this.cmbPackage.FormattingEnabled = true;
            this.cmbPackage.Location = new System.Drawing.Point(116, 31);
            this.cmbPackage.Name = "cmbPackage";
            this.cmbPackage.Size = new System.Drawing.Size(407, 21);
            this.cmbPackage.TabIndex = 1;
            this.cmbPackage.SelectedIndexChanged += new System.EventHandler(this.cmbPackage_SelectedIndexChanged);
            // 
            // dgvPackageDetails
            // 
            this.dgvPackageDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPackageDetails.Location = new System.Drawing.Point(15, 66);
            this.dgvPackageDetails.Name = "dgvPackageDetails";
            this.dgvPackageDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPackageDetails.Size = new System.Drawing.Size(942, 150);
            this.dgvPackageDetails.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dtpCardExpiry);
            this.groupBox1.Controls.Add(this.txtHolderName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtCardName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtCardPin);
            this.groupBox1.Controls.Add(this.txtCardType);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(15, 222);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 201);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Details";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "CV2";
            // 
            // dtpCardExpiry
            // 
            this.dtpCardExpiry.Location = new System.Drawing.Point(82, 162);
            this.dtpCardExpiry.Name = "dtpCardExpiry";
            this.dtpCardExpiry.Size = new System.Drawing.Size(200, 20);
            this.dtpCardExpiry.TabIndex = 28;
            // 
            // txtHolderName
            // 
            this.txtHolderName.Location = new System.Drawing.Point(82, 19);
            this.txtHolderName.Name = "txtHolderName";
            this.txtHolderName.Size = new System.Drawing.Size(200, 20);
            this.txtHolderName.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Expiry";
            // 
            // txtCardName
            // 
            this.txtCardName.Location = new System.Drawing.Point(82, 54);
            this.txtCardName.Name = "txtCardName";
            this.txtCardName.Size = new System.Drawing.Size(200, 20);
            this.txtCardName.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Holder Name";
            // 
            // txtCardPin
            // 
            this.txtCardPin.Location = new System.Drawing.Point(82, 88);
            this.txtCardPin.Name = "txtCardPin";
            this.txtCardPin.Size = new System.Drawing.Size(200, 20);
            this.txtCardPin.TabIndex = 25;
            // 
            // txtCardType
            // 
            this.txtCardType.Location = new System.Drawing.Point(82, 121);
            this.txtCardType.Name = "txtCardType";
            this.txtCardType.Size = new System.Drawing.Size(200, 20);
            this.txtCardType.TabIndex = 45;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 128);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 44;
            this.label14.Text = "Card Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Card Name";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(534, 346);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 23);
            this.button3.TabIndex = 38;
            this.button3.Text = "Remove Passenger";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(422, 346);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 23);
            this.button2.TabIndex = 37;
            this.button2.Text = "Add Passenger";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dtpExpiry
            // 
            this.dtpExpiry.Location = new System.Drawing.Point(454, 314);
            this.dtpExpiry.Name = "dtpExpiry";
            this.dtpExpiry.Size = new System.Drawing.Size(200, 20);
            this.dtpExpiry.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(398, 322);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 35;
            this.label7.Text = "Expiry";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(398, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Passport";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(398, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Name";
            // 
            // txtPassport
            // 
            this.txtPassport.Location = new System.Drawing.Point(454, 276);
            this.txtPassport.Name = "txtPassport";
            this.txtPassport.Size = new System.Drawing.Size(200, 20);
            this.txtPassport.TabIndex = 32;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(454, 237);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 31;
            // 
            // lbPassenger
            // 
            this.lbPassenger.DisplayMember = "passengerName";
            this.lbPassenger.FormattingEnabled = true;
            this.lbPassenger.Location = new System.Drawing.Point(697, 222);
            this.lbPassenger.Name = "lbPassenger";
            this.lbPassenger.Size = new System.Drawing.Size(260, 160);
            this.lbPassenger.TabIndex = 30;
            this.lbPassenger.ValueMember = "passengerName";
            // 
            // btnBookRoom
            // 
            this.btnBookRoom.Location = new System.Drawing.Point(697, 390);
            this.btnBookRoom.Name = "btnBookRoom";
            this.btnBookRoom.Size = new System.Drawing.Size(260, 23);
            this.btnBookRoom.TabIndex = 56;
            this.btnBookRoom.Text = "Book Package";
            this.btnBookRoom.UseVisualStyleBackColor = true;
            this.btnBookRoom.Click += new System.EventHandler(this.btnBookRoom_Click);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(757, 32);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtpStartDate.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(682, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 52;
            this.label2.Text = "Start Date";
            // 
            // txtGuestName
            // 
            this.txtGuestName.Location = new System.Drawing.Point(321, 595);
            this.txtGuestName.Name = "txtGuestName";
            this.txtGuestName.Size = new System.Drawing.Size(148, 20);
            this.txtGuestName.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 595);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Guest Name";
            // 
            // txtGuestPassport
            // 
            this.txtGuestPassport.Location = new System.Drawing.Point(529, 592);
            this.txtGuestPassport.Name = "txtGuestPassport";
            this.txtGuestPassport.Size = new System.Drawing.Size(148, 20);
            this.txtGuestPassport.TabIndex = 48;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(475, 595);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 47;
            this.label12.Text = "Passport";
            // 
            // txtGuestAccount
            // 
            this.txtGuestAccount.Location = new System.Drawing.Point(96, 592);
            this.txtGuestAccount.Name = "txtGuestAccount";
            this.txtGuestAccount.Size = new System.Drawing.Size(148, 20);
            this.txtGuestAccount.TabIndex = 43;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 595);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 13);
            this.label15.TabIndex = 42;
            this.label15.Text = "Guest Account";
            // 
            // dgvRoomDetails
            // 
            this.dgvRoomDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoomDetails.Location = new System.Drawing.Point(15, 429);
            this.dgvRoomDetails.MultiSelect = false;
            this.dgvRoomDetails.Name = "dgvRoomDetails";
            this.dgvRoomDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoomDetails.Size = new System.Drawing.Size(508, 150);
            this.dgvRoomDetails.TabIndex = 40;
            // 
            // dgvFlightInformation
            // 
            this.dgvFlightInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFlightInformation.Location = new System.Drawing.Point(534, 429);
            this.dgvFlightInformation.Name = "dgvFlightInformation";
            this.dgvFlightInformation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFlightInformation.Size = new System.Drawing.Size(423, 150);
            this.dgvFlightInformation.TabIndex = 57;
            // 
            // frmPackageService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 620);
            this.Controls.Add(this.dgvFlightInformation);
            this.Controls.Add(this.btnBookRoom);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGuestName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGuestPassport);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtGuestAccount);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dgvRoomDetails);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dtpExpiry);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPassport);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lbPassenger);
            this.Controls.Add(this.dgvPackageDetails);
            this.Controls.Add(this.cmbPackage);
            this.Controls.Add(this.label1);
            this.Name = "frmPackageService";
            this.Text = "s";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackageDetails)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlightInformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPackage;
        private System.Windows.Forms.DataGridView dgvPackageDetails;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpCardExpiry;
        private System.Windows.Forms.TextBox txtHolderName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCardName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCardPin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dtpExpiry;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassport;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ListBox lbPassenger;
        private System.Windows.Forms.Button btnBookRoom;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGuestName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGuestPassport;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtCardType;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtGuestAccount;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dgvRoomDetails;
        private System.Windows.Forms.DataGridView dgvFlightInformation;
    }
}
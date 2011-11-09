namespace TA.Window
{
    partial class frmHotelService
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
            this.dgvRoomDetails = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGuestAccount = new System.Windows.Forms.TextBox();
            this.txtCardType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGuestPassport = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGuestName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nudDuration = new System.Windows.Forms.NumericUpDown();
            this.nudGuestNumber = new System.Windows.Forms.NumericUpDown();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnBookRoom = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGuestNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRoomDetails
            // 
            this.dgvRoomDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoomDetails.Location = new System.Drawing.Point(12, 12);
            this.dgvRoomDetails.MultiSelect = false;
            this.dgvRoomDetails.Name = "dgvRoomDetails";
            this.dgvRoomDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoomDetails.Size = new System.Drawing.Size(549, 150);
            this.dgvRoomDetails.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(431, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Load Rooms";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Guest Account";
            // 
            // txtGuestAccount
            // 
            this.txtGuestAccount.Location = new System.Drawing.Point(102, 209);
            this.txtGuestAccount.Name = "txtGuestAccount";
            this.txtGuestAccount.Size = new System.Drawing.Size(148, 20);
            this.txtGuestAccount.TabIndex = 4;
            // 
            // txtCardType
            // 
            this.txtCardType.Location = new System.Drawing.Point(102, 358);
            this.txtCardType.Name = "txtCardType";
            this.txtCardType.Size = new System.Drawing.Size(148, 20);
            this.txtCardType.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Card Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Duration";
            // 
            // txtGuestPassport
            // 
            this.txtGuestPassport.Location = new System.Drawing.Point(102, 283);
            this.txtGuestPassport.Name = "txtGuestPassport";
            this.txtGuestPassport.Size = new System.Drawing.Size(148, 20);
            this.txtGuestPassport.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Passport";
            // 
            // txtGuestName
            // 
            this.txtGuestName.Location = new System.Drawing.Point(102, 246);
            this.txtGuestName.Name = "txtGuestName";
            this.txtGuestName.Size = new System.Drawing.Size(148, 20);
            this.txtGuestName.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Guest Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(279, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "No Of Guest";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(279, 283);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Start Date";
            // 
            // nudDuration
            // 
            this.nudDuration.Location = new System.Drawing.Point(102, 317);
            this.nudDuration.Name = "nudDuration";
            this.nudDuration.Size = new System.Drawing.Size(148, 20);
            this.nudDuration.TabIndex = 16;
            // 
            // nudGuestNumber
            // 
            this.nudGuestNumber.Location = new System.Drawing.Point(365, 317);
            this.nudGuestNumber.Name = "nudGuestNumber";
            this.nudGuestNumber.Size = new System.Drawing.Size(146, 20);
            this.nudGuestNumber.TabIndex = 17;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(365, 283);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtpStartDate.TabIndex = 18;
            // 
            // btnBookRoom
            // 
            this.btnBookRoom.Location = new System.Drawing.Point(416, 366);
            this.btnBookRoom.Name = "btnBookRoom";
            this.btnBookRoom.Size = new System.Drawing.Size(145, 23);
            this.btnBookRoom.TabIndex = 19;
            this.btnBookRoom.Text = "Book Room";
            this.btnBookRoom.UseVisualStyleBackColor = true;
            this.btnBookRoom.Click += new System.EventHandler(this.btnBookRoom_Click);
            // 
            // frmHotelService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 401);
            this.Controls.Add(this.btnBookRoom);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.nudGuestNumber);
            this.Controls.Add(this.nudDuration);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtGuestName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGuestPassport);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCardType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtGuestAccount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgvRoomDetails);
            this.Name = "frmHotelService";
            this.Text = "frmHotelService";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoomDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGuestNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRoomDetails;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGuestAccount;
        private System.Windows.Forms.TextBox txtCardType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGuestPassport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGuestName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudDuration;
        private System.Windows.Forms.NumericUpDown nudGuestNumber;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Button btnBookRoom;
    }
}
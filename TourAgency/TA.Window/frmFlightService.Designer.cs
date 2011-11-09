namespace TA.Window
{
    partial class frmFlightService
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
            this.cmbFrom = new System.Windows.Forms.ComboBox();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvFlightInformation = new System.Windows.Forms.DataGridView();
            this.lbPassenger = new System.Windows.Forms.ListBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPassport = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpExpiry = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCardName = new System.Windows.Forms.TextBox();
            this.txtHolderName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCardPin = new System.Windows.Forms.TextBox();
            this.dtpCardExpiry = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlightInformation)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbFrom
            // 
            this.cmbFrom.FormattingEnabled = true;
            this.cmbFrom.Location = new System.Drawing.Point(74, 12);
            this.cmbFrom.Name = "cmbFrom";
            this.cmbFrom.Size = new System.Drawing.Size(200, 21);
            this.cmbFrom.TabIndex = 0;
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(74, 54);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(200, 21);
            this.cmbTo.TabIndex = 1;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(74, 94);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(200, 20);
            this.dtpStart.TabIndex = 2;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(74, 134);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(200, 20);
            this.dtpEnd.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Start Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "End Date";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(74, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Query Flight Details";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvFlightInformation
            // 
            this.dgvFlightInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFlightInformation.Location = new System.Drawing.Point(19, 239);
            this.dgvFlightInformation.Name = "dgvFlightInformation";
            this.dgvFlightInformation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFlightInformation.Size = new System.Drawing.Size(321, 150);
            this.dgvFlightInformation.TabIndex = 9;
            // 
            // lbPassenger
            // 
            this.lbPassenger.DisplayMember = "passengerName";
            this.lbPassenger.FormattingEnabled = true;
            this.lbPassenger.Location = new System.Drawing.Point(373, 239);
            this.lbPassenger.Name = "lbPassenger";
            this.lbPassenger.Size = new System.Drawing.Size(232, 147);
            this.lbPassenger.TabIndex = 10;
            this.lbPassenger.ValueMember = "passengerName";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(405, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 11;
            // 
            // txtPassport
            // 
            this.txtPassport.Location = new System.Drawing.Point(405, 55);
            this.txtPassport.Name = "txtPassport";
            this.txtPassport.Size = new System.Drawing.Size(200, 20);
            this.txtPassport.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(349, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Passport";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(349, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Expiry";
            // 
            // dtpExpiry
            // 
            this.dtpExpiry.Location = new System.Drawing.Point(405, 93);
            this.dtpExpiry.Name = "dtpExpiry";
            this.dtpExpiry.Size = new System.Drawing.Size(200, 20);
            this.dtpExpiry.TabIndex = 17;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(373, 192);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Add Passenger";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(485, 192);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "Remove Passenger";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(236, 521);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 23);
            this.button4.TabIndex = 20;
            this.button4.Text = "Reserve Flight";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Holder Name";
            // 
            // txtCardName
            // 
            this.txtCardName.Location = new System.Drawing.Point(82, 54);
            this.txtCardName.Name = "txtCardName";
            this.txtCardName.Size = new System.Drawing.Size(200, 20);
            this.txtCardName.TabIndex = 22;
            // 
            // txtHolderName
            // 
            this.txtHolderName.Location = new System.Drawing.Point(82, 15);
            this.txtHolderName.Name = "txtHolderName";
            this.txtHolderName.Size = new System.Drawing.Size(200, 20);
            this.txtHolderName.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(309, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(27, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "CV2";
            // 
            // txtCardPin
            // 
            this.txtCardPin.Location = new System.Drawing.Point(384, 15);
            this.txtCardPin.Name = "txtCardPin";
            this.txtCardPin.Size = new System.Drawing.Size(200, 20);
            this.txtCardPin.TabIndex = 25;
            // 
            // dtpCardExpiry
            // 
            this.dtpCardExpiry.Location = new System.Drawing.Point(384, 51);
            this.dtpCardExpiry.Name = "dtpCardExpiry";
            this.dtpCardExpiry.Size = new System.Drawing.Size(200, 20);
            this.dtpCardExpiry.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(309, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Expiry";
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
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(19, 405);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 100);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Details";
            // 
            // frmFlightService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 566);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dtpExpiry);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPassport);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lbPassenger);
            this.Controls.Add(this.dgvFlightInformation);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.cmbFrom);
            this.Name = "frmFlightService";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlightInformation)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFrom;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvFlightInformation;
        private System.Windows.Forms.ListBox lbPassenger;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPassport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpExpiry;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCardName;
        private System.Windows.Forms.TextBox txtHolderName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCardPin;
        private System.Windows.Forms.DateTimePicker dtpCardExpiry;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}


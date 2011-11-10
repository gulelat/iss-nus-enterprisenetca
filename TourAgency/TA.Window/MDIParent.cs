using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TA.Window
{
    public partial class MDIParent : Form
    {
        private int childFormNumber = 0;

        public MDIParent()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void flightBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFlightService childForm = new frmFlightService();
            childForm.MdiParent = this;
            childForm.Text = childForm.Text;
            childForm.Show();
        }

        private void hotelBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHotelService childForm = new frmHotelService();
            childForm.MdiParent = this;
            childForm.Text = childForm.Text;
            childForm.Show();
        }

        private void packageBookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPackageService childForm = new frmPackageService();
            childForm.MdiParent = this;
            childForm.Text = childForm.Text;
            childForm.Show();
        }
    }
}

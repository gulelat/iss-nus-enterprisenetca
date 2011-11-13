using System;
using System.Windows.Forms;

namespace Receiver
{
    public partial class Receiver : Form
    {
        private ReceiverPresenter _presenter;

        public Receiver()
        {
            InitializeComponent();
            _presenter = new ReceiverPresenter(this);

            label1.Text = "";
        }

        int slice = 4;
        public void SetData(int data)
        {
            label1.Text += data + " ".PadRight(8 - data.ToString().Length);
            slice++;
            if (slice % 4 == 0)
                label1.Text += "\n";
        }
    }
}

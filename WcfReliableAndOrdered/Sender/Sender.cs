using System;
using System.Windows.Forms;

namespace Sender
{
    public partial class Sender : Form
    {
        private SenderPresenter _presenter;

        public Sender()
        {
            InitializeComponent();
            _presenter = new SenderPresenter();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] dataStore = new int[4, 4];
            string str = string.Empty;
            int i = 1;
            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    dataStore[y, x] = i++;
                    str += dataStore[y, x] + " ".PadRight(8 - i.ToString().Length);
                }

                str += "\n";
            }

            label1.Text = str;
            _presenter.SendImage(dataStore);
        }
    }
}

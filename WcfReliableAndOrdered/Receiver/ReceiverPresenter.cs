using System;
using System.Diagnostics;
using System.IO;
using System.ServiceModel;
using System.Threading;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using WpfBase;

namespace Receiver
{
    public class ReceiverPresenter : PresenterBase<ReceiverViewModel>
    {
        public ReceiverPresenter(Receiver form)
        {
            Form = form;
            ViewModel = new ReceiverViewModel();

            ImageSenderService service = new ImageSenderService();
            service.ImageReceived += new EventHandler<ImageReceivedEventArgs>(service_ImageReceived);
            service.ClearReceived += new EventHandler(service_ClearReceived);
            service.DimensionsReceived += new EventHandler<DimensionsReceivedEventArgs>(service_DimensionsReceived);
            try
            {
                ServiceHost host = new ServiceHost(service);
                host.Open();
            }
            catch (Exception exc)
            {
                Debug.WriteLine(exc);
            }
        }

        void service_DimensionsReceived(object sender, DimensionsReceivedEventArgs e)
        {
            Form.BeginInvoke(
                new ThreadStart(delegate
                {
                }));
        }

        void service_ClearReceived(object sender, EventArgs e)
        {
            Form.BeginInvoke(
               new ThreadStart(delegate
               {
                   ViewModel.Images.Clear();
               }));
        }

        void service_ImageReceived(object sender, ImageReceivedEventArgs e)
        {
            Form.BeginInvoke(
                new ThreadStart(delegate
                {
                    ((Receiver)Form).SetData(e.Data);
                }));
        }
    }
}

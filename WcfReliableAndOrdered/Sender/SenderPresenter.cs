using System.ServiceModel;
using System.Threading;
using ImageSenderContract;
using Microsoft.Win32;
using WpfBase;

namespace Sender
{
    public class SenderPresenter : PresenterBase<SenderViewModel>
    {
        private const int SLICES = 4;

        public SenderPresenter()
        {
            ViewModel = new SenderViewModel();
        }

        public void SendImage(int[,] dataStore)
        {
            ViewModel.StartBackgroundActivity();
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object state)
                {
                    InternalSendImage(dataStore);
                }));

        }

        public static ManualResetEvent GlobalStateSharedResetEvent = new ManualResetEvent(false);

        private void InternalSendImage(int[,] dataStore)
        {
            IImageSender sender = new ChannelFactory<IImageSender>("Destination").CreateChannel();

            ViewModel.ChunksSent = 0;
            sender.Clear();

            sender.SetDimension(SLICES);

            GlobalStateSharedResetEvent.Set();

            for (int y = 0; y < SLICES; y++)
            {
                for (int x = 0; x < SLICES; x++)
                {

                    int data = dataStore[y, x];

                    // Wait here until the last message made it through most of the 
                    // WCF stack. Messages only get held up at the last hurdle, at that
                    // point we can continue to send messages from here.
                    GlobalStateSharedResetEvent.WaitOne();
                    GlobalStateSharedResetEvent.Reset();

                    ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object state)
                        {
                            sender.SendImage(data);
                        }), null);

                    ViewModel.ChunksSent++;
                }
            }

            ViewModel.CompleteBackgroundActivity();
        }
    }
}

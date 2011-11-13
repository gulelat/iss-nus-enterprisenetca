using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;
using Sender;

namespace Extensibility
{
    [ServiceContract]
    public interface IBridge
    {
        [OperationContract]
        int GetDropRate();
        [OperationContract]
        void ReportReceivedCount();
        [OperationContract]
        void ReportDroppedCount();
        [OperationContract]
        void ReportForwardedCount();
    }

    public class MessageInterceptor : IMessageInterceptor
    {

        private int _dropRate = 5;
        private Random _randomizer = null;
        
        public MessageInterceptor()
        {
            _randomizer = new Random(DateTime.Now.Millisecond);
        }

        public void ProcessSend(ref Message message)
        {
            SenderPresenter.GlobalStateSharedResetEvent.Set();
            Thread.Sleep(_randomizer.Next(250));
            string action = message.Headers.Action;
            if (!(action.Contains("IImageSender/SendImage")))
            {
                return;
            }
            int randomNumber = _randomizer.Next(100);
            if ((_dropRate != 0) && (randomNumber <= _dropRate))
            {
                message = null;
                return;
            }
        }

        public void ProcessReceive(ref Message message)
        {

        }
    }


    public interface IMessageInterceptor
    {
        void ProcessReceive(ref Message message);
        void ProcessSend(ref Message message);
    }

}

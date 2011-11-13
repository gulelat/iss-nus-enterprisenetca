using System;
using System.ServiceModel;
using ImageSenderContract;

namespace Receiver
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ImageSenderService : IImageSender
    {
        public void SendImage(int content)
        {
            if (ImageReceived != null)
                ImageReceived(this, new ImageReceivedEventArgs(content));
        }

        public void Clear()
        {
            if (ClearReceived != null)
                ClearReceived(this, EventArgs.Empty);
        }

        public void SetDimension(int slices)
        {
            if (DimensionsReceived != null)
                DimensionsReceived(this, new DimensionsReceivedEventArgs(slices));
        }

        public event EventHandler<ImageReceivedEventArgs> ImageReceived;
        public event EventHandler ClearReceived;
        public event EventHandler<DimensionsReceivedEventArgs> DimensionsReceived;
    }

    public class ImageReceivedEventArgs : EventArgs
    {
        public ImageReceivedEventArgs(int data)
        {
            Data = data;
        }

        public int Data { get; set; }
    }

    public class DimensionsReceivedEventArgs : EventArgs
    {
        public DimensionsReceivedEventArgs(int slices)
        {
            Slices = slices;
        }

        public int Slices { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace ImageSenderContract
{
    [ServiceContract(Namespace = "urn:thejoyofcode-com:image-sender:2007-11")]
    public interface IImageSender
    {
        [OperationContract(IsOneWay = true)]
        void SendImage(int content);

        [OperationContract(IsOneWay = true)]
        void Clear();

        [OperationContract(IsOneWay = true)]
        void SetDimension(int slices);
    }
}

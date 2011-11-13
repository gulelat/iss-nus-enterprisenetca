using System;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.Text;

namespace Extensibility
{
    class MyCustomDuplexSessionChannelFactory<TChannel>: ChannelFactoryBase<IDuplexSessionChannel>
    {
        IChannelFactory<TChannel> innerChannelFactory = null; 

        public MyCustomDuplexSessionChannelFactory(MyCustomBindingElement bindingElement, BindingContext context)
            : base(context.Binding)
        {
            this.innerChannelFactory = context.BuildInnerChannelFactory<TChannel>();
            if (this.innerChannelFactory == null)
            {
                throw new InvalidOperationException("InspectingChannelFactory requires an inner IChannelFactory.");
            }
        }

        protected override IDuplexSessionChannel OnCreateChannel(System.ServiceModel.EndpointAddress address, Uri via)
        {
            IDuplexSessionChannel innerChannel = (IDuplexSessionChannel)this.innerChannelFactory.CreateChannel(address, via);
            return new MyCustomDuplexSessionChannel(innerChannel);
        }

        protected override IAsyncResult OnBeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override void OnEndOpen(IAsyncResult result)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        protected override void OnOpen(TimeSpan timeout)
        {
            this.innerChannelFactory.Open(timeout);
        }
    }
}

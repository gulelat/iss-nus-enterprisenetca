using System;
using System.Collections.Generic;
using System.Globalization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace Extensibility
{
    public class MyCustomBindingElement: BindingElement
    {
        public MyCustomBindingElement()
        {
        }

        

        public MyCustomBindingElement(MyCustomBindingElement original)
        {
        }

        
        public override BindingElement Clone()
        {
            return new MyCustomBindingElement(this);
        }

        public override T GetProperty<T>(BindingContext context)
        {
            return context.GetInnerProperty<T>();
        }

        public override bool CanBuildChannelFactory<TChannel>(BindingContext context)
        {
            return typeof(TChannel) == typeof(IDuplexSessionChannel);
        }

        public override bool CanBuildChannelListener<TChannel>(BindingContext context)
        {
           return false;
        }

        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            if ((typeof(TChannel)) == typeof(IDuplexSessionChannel))
            {
                return (IChannelFactory<TChannel>)(object)new MyCustomDuplexSessionChannelFactory<TChannel>(this, context);
            }
            throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Unsupported channel type: {0}.", typeof(TChannel).Name));
        }

        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
        {
            return null;
        }
    }
}

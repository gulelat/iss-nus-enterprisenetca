using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.Text;

namespace Extensibility
{
    class MyCustomBindingElementExtensionElement : BindingElementExtensionElement
    {
        public override Type BindingElementType
        {
            get { return typeof(MyCustomBindingElement); }
        }

        protected override BindingElement CreateBindingElement()
        {
            MyCustomBindingElement bindingElement = new MyCustomBindingElement();
            return bindingElement;
        }
    }
}

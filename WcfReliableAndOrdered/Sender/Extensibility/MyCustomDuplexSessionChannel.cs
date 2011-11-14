using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Diagnostics;
using System.Xml;
using System.Text.RegularExpressions;

namespace Extensibility
{
    class MyCustomDuplexSessionChannel : IDuplexSessionChannel
    {
        private IDuplexSessionChannel innerChannel = null;
        private IMessageInterceptor interceptor = null;

        public MyCustomDuplexSessionChannel(IDuplexSessionChannel innerChannel)
        {
            this.innerChannel = innerChannel;

            this.innerChannel.Closed += new EventHandler(innerChannel_Closed);
            this.innerChannel.Closing += new EventHandler(innerChannel_Closing);
            this.innerChannel.Faulted += new EventHandler(innerChannel_Faulted);
            this.innerChannel.Opened += new EventHandler(innerChannel_Opened);
            this.innerChannel.Opening += new EventHandler(innerChannel_Opening);

            this.interceptor = new MessageInterceptor();
        }

        void innerChannel_Opening(object sender, EventArgs e)
        {
            if (this.Opening != null)
            {
                this.Opening(sender, e);
            }
        }

        void innerChannel_Opened(object sender, EventArgs e)
        {
            if (this.Opened != null)
            {
                this.Opened(sender, e);
            }
        }

        void innerChannel_Faulted(object sender, EventArgs e)
        {
            if (this.Faulted != null)
            {
                this.Faulted(sender, e);
            }
        }

        void innerChannel_Closing(object sender, EventArgs e)
        {
            if (this.Closing != null)
            {
                this.Closing(sender, e);
            }
        }

        void innerChannel_Closed(object sender, EventArgs e)
        {
            if (this.Closed != null)
            {
                this.Closed(sender, e);
            }
        }

        #region IInputChannel Members

        public IAsyncResult BeginReceive(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.innerChannel.BeginReceive(timeout, callback, state);
        }

        public IAsyncResult BeginReceive(AsyncCallback callback, object state)
        {
            return this.innerChannel.BeginReceive(callback, state);
        }

        public IAsyncResult BeginTryReceive(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.innerChannel.BeginTryReceive(timeout, callback, state);
        }

        public IAsyncResult BeginWaitForMessage(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.innerChannel.BeginWaitForMessage(timeout, callback, state);
        }

        public Message EndReceive(IAsyncResult result)
        {
            return this.innerChannel.EndReceive(result);
        }

        public bool EndTryReceive(IAsyncResult result, out Message message)
        {
            return this.innerChannel.EndTryReceive(result, out message);
        }

        public bool EndWaitForMessage(IAsyncResult result)
        {
            return this.innerChannel.EndWaitForMessage(result);
        }

        public EndpointAddress LocalAddress
        {
            get
            {
                return this.innerChannel.LocalAddress;
            }
        }

        public Message Receive(TimeSpan timeout)
        {
            return this.innerChannel.Receive(timeout);
        }

        public Message Receive()
        {
            return this.innerChannel.Receive();
        }

        public bool TryReceive(TimeSpan timeout, out Message message)
        {
            return this.innerChannel.TryReceive(timeout, out message);
        }

        public bool WaitForMessage(TimeSpan timeout)
        {
            return this.innerChannel.WaitForMessage(timeout);
        }

        #endregion

        #region IChannel Members

        public T GetProperty<T>() where T : class
        {
            return this.innerChannel.GetProperty<T>();
        }

        #endregion

        #region ICommunicationObject Members

        public void Abort()
        {
            this.innerChannel.Abort();
        }

        public IAsyncResult BeginClose(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.innerChannel.BeginClose(timeout, callback, state);
        }

        public IAsyncResult BeginClose(AsyncCallback callback, object state)
        {
            return this.innerChannel.BeginClose(callback, state);
        }

        public IAsyncResult BeginOpen(TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.innerChannel.BeginOpen(timeout, callback, state);
        }

        public IAsyncResult BeginOpen(AsyncCallback callback, object state)
        {
            return this.innerChannel.BeginOpen(callback, state);
        }

        public void Close(TimeSpan timeout)
        {
            this.innerChannel.Close(timeout);
        }

        public void Close()
        {
            this.innerChannel.Close();
        }

        public event EventHandler Closed;

        public event EventHandler Closing;

        public void EndClose(IAsyncResult result)
        {
            this.innerChannel.EndClose(result);
        }

        public void EndOpen(IAsyncResult result)
        {
            this.innerChannel.EndOpen(result);
        }

        public event EventHandler Faulted;

        public void Open(TimeSpan timeout)
        {
            this.innerChannel.Open(timeout);
        }

        public void Open()
        {
            this.innerChannel.Open();
        }

        public event EventHandler Opened;

        public event EventHandler Opening;

        public CommunicationState State
        {
            get
            {
                return this.innerChannel.State;
            }
        }

        #endregion

        #region IOutputChannel Members

        public IAsyncResult BeginSend(Message message, TimeSpan timeout, AsyncCallback callback, object state)
        {
            return this.innerChannel.BeginSend(message, timeout, callback, state);
        }

        public IAsyncResult BeginSend(Message message, AsyncCallback callback, object state)
        {
            return this.innerChannel.BeginSend(message, callback, state);
        }

        public void EndSend(IAsyncResult result)
        {
            this.innerChannel.EndSend(result);
        }

        public EndpointAddress RemoteAddress
        {
            get
            {
                return this.innerChannel.RemoteAddress;
            }
        }


        public void Send(Message message, TimeSpan timeout)
        {
            this.interceptor.ProcessSend(ref message);
            if (message != null)
            {
                string s = message.ToString();
                Regex r = new Regex("<content>.*?</content>");
                Match m = r.Match(s);
                Debug.WriteLine(m.Groups[0].Value);
            }
            if (!(message == null))
            {
                this.innerChannel.Send(message, timeout);
            }
        }

        public void Send(Message message)
        {
            this.innerChannel.Send(message);
        }

        public Uri Via
        {
            get
            {
                return this.innerChannel.Via;
            }
        }

        #endregion

        #region ISessionChannel<IDuplexSession> Members

        public IDuplexSession Session
        {
            get
            {
                return this.innerChannel.Session;
            }
        }

        #endregion
    }
}

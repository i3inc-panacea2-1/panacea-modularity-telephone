using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Panacea.Modularity.Telephone
{
    public abstract class TelephoneBase : IDisposable
    {
        protected TelephoneBase(ITelephoneAccount account)
        {
            Account = account;
        }

        

        public string CurrentNumber { get; protected set; }
        public virtual bool IsBusy { get; protected set; }
        public virtual bool IsInCall { get; protected set; }
        public virtual bool IsIncoming { get; protected set; }
        public ITelephoneAccount Account { get; protected set; }
        public virtual UIElement LocalVideoControl
        {
            get { return new Grid(); }
            protected set
            {

            }
        }

        public virtual UIElement RemoteVideoControl
        {
            get { return new Grid(); }
            protected set
            {

            }
        }

        public event EventHandler<string> IncomingCall;
        public event EventHandler<string> Ringing;
        public event EventHandler<string> Answered;
        public event EventHandler<string> Cancelled;
        public event EventHandler<string> Failed;
        public event EventHandler<string> Closed;
        public event EventHandler<string> Busy;
        public event EventHandler<string> Trying;
        public event EventHandler<string> Rejected;
        public event EventHandler<string> MissedCall;

        protected void OnIncomingCall(string str)
        {
            IncomingCall?.Invoke(this, str);
        }
        protected void OnRinging(string str)
        {
            Ringing?.Invoke(this, str);
        }
        protected void OnAnswered(string str)
        {
            Answered?.Invoke(this, str);
        }
        protected void OnCancelled(string str)
        {
            Cancelled?.Invoke(this, str);
        }
        protected void OnFailed(string str)
        {
            Failed?.Invoke(this, str);
        }
        protected void OnClosed(string str)
        {
            Closed?.Invoke(this, str);
        }
        protected void OnTrying(string str)
        {
            Trying?.Invoke(this, str);
        }
        protected void OnBusy(string str)
        {
            Busy?.Invoke(this, str);
        }
        protected void OnRejected(string str)
        {
            Rejected?.Invoke(this, str);
        }
        protected void OnMissedCall(string str)
        {
            MissedCall?.Invoke(this, str);
        }

        public abstract Task Call(string number, bool hasVideo = false);
        public abstract Task HangUp();
        public abstract Task Answer(bool withVideo = false);
        public abstract Task Reject();
        public abstract Task StartDtmf(string k);
        public abstract Task StopDtmf(string k);
        public abstract Task Register();
        public abstract Task Unregister();
        public abstract void Mute();
        public abstract void Unmute();

        public virtual void Dispose()
        {
            ClearEvents(
                IncomingCall,
                Ringing,
                Answered,
                Cancelled,
                Failed,
                Closed,
                Busy
                );
        }

        protected void ClearEvents(params EventHandler<string>[] handlers)
        {
            foreach (var d in handlers.SelectMany(handler => handler.GetInvocationList()))
                IncomingCall -= (EventHandler<string>)d;
        }
    }
}

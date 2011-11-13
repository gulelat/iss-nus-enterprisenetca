using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;

namespace WpfBase
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {

        private int _activeBackgroundActivities;

        public void StartBackgroundActivity()
        {
            Interlocked.Increment(ref _activeBackgroundActivities);
            FirePropertyChanged("IsBusy");
        }

        public void CompleteBackgroundActivity()
        {
            Interlocked.Decrement(ref _activeBackgroundActivities);
            FirePropertyChanged("IsBusy");
        }

        private bool _isBusy = false;

        public bool IsBusy
        {
            get { return _activeBackgroundActivities > 0; }
        }

        protected virtual void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}

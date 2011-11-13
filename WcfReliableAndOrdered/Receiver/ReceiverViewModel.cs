using System.Collections.ObjectModel;
using WpfBase;

namespace Receiver
{
    public class ReceiverViewModel : ViewModelBase
    {
        private readonly ObservableCollection<int> _images = new ObservableCollection<int>();

        public ObservableCollection<int> Images
        {
            get
            {
                return _images;
            }
        }
    }
}

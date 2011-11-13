using System.Windows.Forms;

namespace WpfBase
{
    public class PresenterBase<TViewModel> where TViewModel : ViewModelBase
    {
        public Form Form { get; set; }
        public TViewModel ViewModel { get; set; }
    }
}

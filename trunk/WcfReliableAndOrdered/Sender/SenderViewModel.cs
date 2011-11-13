using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using WpfBase;
using System.IO;

namespace Sender
{
    public class SenderViewModel : ViewModelBase
    {
        private string _imageSrc = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            "DefaultImage.jpg");

        public string ImageSrc
        {
            get { return _imageSrc; }
            set
            {
                _imageSrc = value;
                FirePropertyChanged("ImageSrc");
            }
        }

        private int _chunksSent = 0;

        public int ChunksSent
        {
            get { return _chunksSent; }
            set
            {
                _chunksSent = value;
                FirePropertyChanged("ChunksSent");
            }
        }
    }
}

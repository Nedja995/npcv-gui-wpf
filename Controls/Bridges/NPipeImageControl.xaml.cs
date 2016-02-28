using NPGui.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NPGui.Controls.Bridges
{
    /// <summary>
    /// Interaction logic for NPipeImageControl.xaml
    /// </summary>
    public partial class NPipeImageControl : UserControl
    {

        public NPipeImageControl()
        {
            InitializeComponent();
        }

        public void Process(byte[] request)
        {
            NamedPipeNpcv npipeImage = new NamedPipeNpcv();
            // Open pipe, send and recive
            byte[] by = npipeImage.Process(request);

            // Make image from bytes array
            MemoryStream fs = new MemoryStream(by);
            BitmapImage bi = WPFImageUtils.GetBitmapImage(by);
            image.Source = bi;
        }
    }
}

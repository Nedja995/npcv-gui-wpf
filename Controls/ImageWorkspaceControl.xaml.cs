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

namespace NPGui.Controls
{
    /// <summary>
    /// Interaction logic for ImageWorkspaceControl.xaml
    /// </summary>
    public partial class ImageWorkspaceControl : UserControl
    {
        public ImageWorkspaceControl()
        {
            InitializeComponent();
        }

        public void AddImage(BitmapImage image)
        {
            //imageTabsControl.DataContext
        }
    }
}

using NPGui.utils;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace NPGui.Controls.Images
{
    /// <summary>
    /// Interaction logic for ImageNpcvControl.xaml
    /// </summary>
    public partial class ImageNpcvControl : UserControl
    {
        public ImageNpcvControl()
        {
            InitializeComponent();
        }

        #region LISTENERS
        private void processBtn_Click(object sender, RoutedEventArgs e)
        {

           // pipeImage.Process(req);
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            //   Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            //if (result == true)
            //{
            //    // Open document 
            //    string filename = dlg.FileName;
            //    mainImage.Source = new BitmapImage(new Uri(dlg.FileName));
            //}

            pipeImage.image.Source = new BitmapImage(new Uri("D:\\Projects\\CompVision\\npcv2\\samples\\data\\input\\lena.jpg"));
        }
        #endregion LISTENERS
    }
}

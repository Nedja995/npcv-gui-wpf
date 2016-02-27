using NPGui.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
            if(pipeImage.image.Source == null)
            {
                // No images
                MessageBox.Show("No image!");
                return;
            }
           // dlg1.ShowDialog();

            DynamicTabsControl workspace = FindParent<DynamicTabsControl>(this);
            ImageMatrixControl matrixImage = new ImageMatrixControl();

            matrixImage.FilteredImage.pipeImage.image.Source = pipeImage.image.Source.Clone();
            matrixImage.FilteredImage._originalImage = pipeImage.image.Source.Clone();

            workspace.SetValue(DynamicTabsControl.NextTabNameProperty, "Matrix");

            workspace.AddNewTab(matrixImage);
        }

        public static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            //get parent item
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            //we've reached the end of the tree
            if (parentObject == null) return null;

            //check if the parent matches the type we're looking for
            T parent = parentObject as T;
            if (parent != null)
                return parent;
            else
                return FindParent<T>(parentObject);
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            if(_originalImage == null)
            {
                                // No images
                MessageBox.Show("No image!");
                return;
            }
            pipeImage.image.Source = _originalImage.Clone();
        }

        private void browseBtn_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";
            dlg.InitialDirectory = "D:\\Projects\\CompVision\\npcv2\\samples\\data\\input";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            //Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                pipeImage.image.Source = new BitmapImage(new Uri(dlg.FileName));
                // store original image
                _originalImage = pipeImage.image.Source.Clone();
            }

            //pipeImage.image.Source = new BitmapImage();

            //
            // CHANGE WORKSPACE NAME
            ImageWorkspaceControl workspace = FindParent<ImageWorkspaceControl>(this);
            string name = System.IO.Path.GetFileNameWithoutExtension(dlg.FileName);

            ImageWorkspaceControl.SetImageNameProperty(workspace, name);
            DynamicTabsControl tabs = FindParent<DynamicTabsControl>(workspace);
            tabs.RenameTab("tab1", name);
            tabs = FindParent<DynamicTabsControl>(this);
            tabs.RenameTab("tab1", "Original");
        }
        #endregion LISTENERS

        #region PRIVATE
        public ImageSource _originalImage;
        #endregion PRIVATE

    }
}

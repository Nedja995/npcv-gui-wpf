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
               
    #region PROPERTIES
    /*
    * IMAGE NAME PROPERTY
    */
    public static readonly DependencyProperty ImageNameProperty = DependencyProperty.RegisterAttached("ImageName",
                                                                 typeof(string), 
                                                                 typeof(ImageWorkspaceControl),
                                                                 new FrameworkPropertyMetadata(null));
    public static string GetImageNameProperty(UIElement element)
    {
        if (element == null)
            throw new ArgumentNullException("element");
        return (string)element.GetValue(ImageNameProperty);
    }
    public static void SetImageNameProperty(UIElement element, string value)
    {
        if (element == null)
            throw new ArgumentNullException("element");
        element.SetValue(ImageNameProperty, value);
    }
    #endregion PROPERTIES

        public ImageWorkspaceControl()
        {
            InitializeComponent();

           // ProcessingTabs.newTab = typeof(Images.ImageNpcvControl);
        }

        public void AddImage(BitmapImage image)
        {
            //imageTabsControl.DataContext
        }
    }
}

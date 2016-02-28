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
    /// Interaction logic for ImageSampling.xaml
    /// </summary>
    public partial class ImageSampling : UserControl
    {
        public ImageSampling()
        {
            InitializeComponent();
        }

        #region LISTENERS
        private void cutting_Click(object sender, RoutedEventArgs e)
        {
            int sampleWidth = 20;
            int sampleHeight = 20;
            
            if(!int.TryParse(widthTxt.Text, out sampleWidth))
            {
                sampleWidth = 20;
            }
            if (!int.TryParse(heightTxt.Text, out sampleHeight))
            {
                sampleHeight = 20;
            }

            var ci = CutImage(FilteredImage._originalImage as BitmapImage, sampleWidth, sampleHeight);

            int i = 0;
            for(int x = 0; x < ci.Count; x++) {
                RowDefinition row = new RowDefinition();
                
                //row.Height = new GridLength(30);
                samplesDynGrid.RowDefinitions.Add(row);
                for (int y = 0; y < ci[x].Count; y++) {
                    ColumnDefinition col = new ColumnDefinition();
                    
                    samplesDynGrid.ColumnDefinitions.Add(col);
                    Image img = new Image();
                    img.Source = ci[x][y];
                    
                    Border margin = new Border();
                    margin.Padding = new Thickness(3);
                    margin.Child = img;
                    Grid.SetColumn(margin, y);
                    Grid.SetRow(margin, x);
                    samplesDynGrid.Children.Add(margin);
                }
            }
            ci.Clear();
           // FilteredImage.pipeImage.image.Source = ci[0];
        }

        private IList<IList<CroppedBitmap>> CutImage(BitmapImage image, int width, int height)
        {
            IList<IList<CroppedBitmap>> ret = new List<IList<CroppedBitmap>>();
            int yi = 0;
            for (int y = 0; y < image.PixelHeight - height; y += height)
            {
                ret.Add(new List<CroppedBitmap>());
                for (int x = 0; x < image.PixelWidth - width; x += width)
                {
                    ret[yi].Add(new CroppedBitmap(image, new Int32Rect(x, y, width, height)));
                }
                yi++;
            }
            return ret;
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            samplesDynGrid.RowDefinitions.Clear();
            samplesDynGrid.ColumnDefinitions.Clear();
         
            foreach(Border img in samplesDynGrid.Children)
            {
                ((Image)img.Child).Source = null;
            }
            samplesDynGrid.Children.Clear();
        }
        #endregion LISTENERS
    }
}

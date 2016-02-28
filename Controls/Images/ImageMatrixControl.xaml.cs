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
    /// Interaction logic for NPImageMatrix.xaml
    /// </summary>
    public partial class ImageMatrixControl : UserControl
    {
        public ImageMatrixControl()
        {
            InitializeComponent();
        }

        public float[] getMatrix()
        {
            
            int mWidth = int.Parse(matWidthTxt.Text);
            int mHeight = int.Parse(matHeightTxt.Text);
            float[] matrix = new float[mWidth * mHeight];
            int i = 0;
            for(int x = 0; x < mWidth; x++)
            {
                for(int y = 0; y < mHeight; y++)
                {
                    string txtBoxName = "m" + x.ToString() + y.ToString();
                    TextBox tb = (TextBox)FindName(txtBoxName);
                    matrix[i++] = float.Parse(tb.Text);
                }
            }
            return matrix;
        }

        private void processBtn_Click(object sender, RoutedEventArgs e)
        {
            float factor = float.Parse(factorTxt.Text);
            float bias = float.Parse(biasTxt.Text);
            int mWidth = int.Parse(matWidthTxt.Text);
            int mHeight = int.Parse(matHeightTxt.Text);
            float[] matrix = getMatrix();

            byte[] req = NPipeMessage.MRApplyMatrix(FilteredImage.pipeImage.image.Source as BitmapImage,//image to process
                                                     factor,// factor
                                                     bias,       // bias
                                                     mWidth, mHeight,       //matrix width and height 
                                                     matrix);    //matrix float array
            FilteredImage.pipeImage.Process(req);
        }
    }
}

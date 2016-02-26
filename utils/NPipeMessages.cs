using NPGui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace NPGui.utils
{
    public static class NPipeMessage
    {
    

        public static byte[] MakeRequestImageProcess(BitmapImage image, string processName, string parametars)
        {
            byte[] ret;
            // Message
            string message = "REQUEST:{"+processName+"}_PARAMS:{"+parametars+"}";//ResponseMessage;
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);
            // Image to bytes
            byte[] imageBytes = WPFImageUtils.getJPGFromImageControl(image);

            // Copy data
            ret = new byte[messageBytes.Length + imageBytes.Length];
            messageBytes.CopyTo(ret, 0);
            imageBytes.CopyTo(ret, messageBytes.Length);

            return ret;
        }

        public static byte[] MRApplyMatrix(BitmapImage image, float factor, float bias, int mWidth, int mHeight, float[] matrix)
        {
            string parametars = "";
            parametars += mWidth.ToString() + ","
                       + mHeight.ToString() + ","
                       + bias.ToString() + ","
                       + factor.ToString();

            for (int i = 0; i < mWidth * mHeight; i++)
            {
                parametars += "," + matrix[i].ToString();
            }

            return MakeRequestImageProcess(image, "matrix", parametars);
        }
    }
}

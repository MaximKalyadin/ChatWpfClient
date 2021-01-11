using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace ClientToServerApi
{
    public class Converter
    {
        public BitmapImage ConvertByteToImage(byte[] binaryImage)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = new System.IO.MemoryStream(binaryImage);
            image.EndInit();
            return image;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Xamarin.Forms;


namespace PM2E10064.Funciones
{
    public class ByteArrayToImageSourceConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ImageSource retSource = null; //Se valida que el valor no venga null
            if (value != null)
            {
                byte[] imageAsBytes = (byte[])value;
                retSource = ImageSource.FromStream(() => new MemoryStream(imageAsBytes));
            }
            return retSource;
        }

        public object ConvertBack(object value,
               Type targetType,
               object parameter,
               System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

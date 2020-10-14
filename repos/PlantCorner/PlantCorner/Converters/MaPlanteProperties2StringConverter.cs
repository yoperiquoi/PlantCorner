using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace PlantCorner
{
    /// <summary>
    /// Classe définissant un MultiValueConverter convertissant la description et la note personnelle en une seule chaîne de caractère
    /// </summary>
    public class MaPlanteProperties2StringConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string[] strings = new string[2];

            for(int i=0; i< Math.Min(2, values.Length); i++)
            {
                strings[i] = values[i] as string;
            }

            string description = string.IsNullOrWhiteSpace(strings[0]) ? "" : $"{strings[0]}";
            string note = string.IsNullOrWhiteSpace(strings[1]) ? "" : $"{strings[1]}";

            return $"{description}\n" +
                $"Note Personnel : {note}";

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

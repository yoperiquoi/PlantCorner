using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace PlantCorner
{
    /// <summary>
    /// Classe définissant un converter pour l'affichage du nom de la plante suivie de son nom scientique en une seule chaîne grâce à un MultiValueConverter
    /// notamment utiliser dans la documentation
    /// </summary>
    public class PlanteProperties2StringConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string[] strings = new string[2];

            for (int i = 0; i < Math.Min(2, values.Length); i++)
            {
                strings[i] = values[i] as string;
            }

            string nom = string.IsNullOrWhiteSpace(strings[0]) ? "" : $"{strings[0]}";
            string nomScientifique = string.IsNullOrWhiteSpace(strings[1]) ? "" : $"{strings[1]}";

            return $"{nom} \"{nomScientifique}\"";

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

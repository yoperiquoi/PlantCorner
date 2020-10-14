using Modèle;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace PlantCorner
{
    /// <summary>
    /// Classe définissant un converter permettant d'afficher un message lorsque la liste des plantes personnelles est vide.
    /// </summary>
    [ValueConversion(typeof(object), typeof(Visibility))]
    public class NullToVisibilityConverterMesPlantes : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null)
            {
                var nbPlantes = (int)value;
                if (nbPlantes == 0)
                {
                    return Visibility.Visible; //Si la liste est vide alors le message est visible
                }
                else
                {
                    return Visibility.Hidden; //Sinon il ne l'est pas.
                }
            }
            return Visibility.Hidden;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

    }
}

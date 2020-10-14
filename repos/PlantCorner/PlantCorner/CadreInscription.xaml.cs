using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlantCorner
{
    /// <summary>
    /// Logique d'interaction pour CadreInscription.xaml (non fonctionnel dans l'application)
    /// </summary>
    public partial class CadreInscription : UserControl
    {
        public Navigator Navigator => (Application.Current as App).Navigator;
        public CadreInscription()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Navigator.NavigateTo("SelectionMode");
        }
    }
}

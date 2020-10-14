using Modèle;
using Modèle.Documentation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace PlantCorner
{
    /// <summary>
    /// Interaction logic for SearchBox.xaml
    /// </summary>
    public partial class SearchBox : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// Récupération de la documentation instancié dans App.xaml
        /// </summary>
        public Doc Doc => (Application.Current as App).Documentation;

        /// <summary>
        /// Dependency property permettant la notification de la vue 
        /// </summary>
        private static DependencyProperty SearchTextProperty =
                                                    DependencyProperty.Register("SearchText", typeof(string), typeof(SearchBox),
                                                    new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault |
                                                                                         FrameworkPropertyMetadataOptions.Inherits));

        /// <summary>
        /// Le texte de recherche utilisé dans la TextBox
        /// </summary>
        public string SearchText
        {
            get { return (string)GetValue(SearchTextProperty); }
            set
            {
                SetValue(SearchTextProperty, value);
            }
        }

        /// <summary>
        /// Constructeur de la SearchBox
        /// </summary>
        public SearchBox()
        {
            InitializeComponent();
            DataContext = Doc;
        }


        private void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Méthode récupérent la valeur inscripte dans la search box lorsqu'elle obtient le focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var t = (TextBox)sender;
            t.SelectAll();
        }
        /// <summary>
        /// Méthode récupérent la valeur inscripte dans la search box lorsqu'elle obtient le focus de par la souris
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void SearchTextBox_GotMouseCapture(object sender, MouseEventArgs e)
        {
            var t = (TextBox)sender;
            t.SelectAll();
        }

        /// <summary>
        /// Methode déclkanchant la recherche
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            OnSearchEvent();
        }

        public static readonly RoutedEvent SearchEvent = EventManager.RegisterRoutedEvent(
                                                                                            "Search", // Event name
                                                                                            RoutingStrategy.Bubble, // Bubble means the event will bubble up through the tree
                                                                                            typeof(RoutedEventHandler), // The event type
                                                                                            typeof(SearchBox)
                                                                                         ); // Belongs to ChildControlBase

        public event RoutedEventHandler Search
        {
            add { AddHandler(SearchEvent, value); }
            remove { RemoveHandler(SearchEvent, value); }
        }

        /// <summary>
        /// Méthode lançant la recherche lors de l'appuie de la touche entrée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Enter))
            {
                OnSearchEvent();
            }
        }

        /// <summary>
        /// Méthode définissant ce qu'il se passe lors de l'événement de recherche
        /// </summary>
        private void OnSearchEvent()
        {
            SearchText = SearchTextBox.Text; // Récupération du texte de recherche
            Doc.LesPlantes = Doc.Recherche(SearchText); // Recherche via l'algorithme de Leveinstein avec le texte récupéré dans la texte box. Ordonne alors la liste dans l'ordre de "distance"
            var newEventArgs = new RoutedEventArgs(SearchBox.SearchEvent);
            RaiseEvent(newEventArgs);
        }
    }
}

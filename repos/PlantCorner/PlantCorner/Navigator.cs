using PlantCorner.UserControlNavigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;

namespace PlantCorner
{
    /// <summary>
    /// Classe permettant la navigation dans l'application
    /// </summary>
    public class Navigator : INotifyPropertyChanged
    {
        /// <summary>
        /// Pile assurant l'empilage des user controls permettant de faire le bouton de retour
        /// </summary>
        private Stack<string> RetourPile = new Stack<string>();

        /// <summary>
        /// Dictionaire avec une association clé/valeur avec le nom du usercontrol en clé et son instanciation en valeur
        /// </summary>
        private Dictionary<string, UserControl> userControls = new Dictionary<string, UserControl>()
        {
            ["Documentation"] = new UserDoc(),
            ["MesPlantes"] = new UserMesPlantes(),
            ["Chargement"] = new UserChargement(),
            ["SelectionMode"] = new UserSelectionMode(),
            ["Jeu"] = new UserJeu(),
            ["Succès"] = new UserSuccès(),
            ["Inscription"] = new UserInscription(),
            ["Connexion"] = new UserConnexion(),
            ["SelectionConnexion"] = new UserSelectionConnexion(),



    };

        /// <summary>
        /// Mise en plus des événement lié au bouton et leur méthode associé pour la navigation dans l'application
        /// </summary>
        private void InitUserControls()
        {
            (userControls["SelectionMode"] as UserSelectionMode).ButtonClickDoc += (sender, args) => NavigateTo("Documentation");
            (userControls["SelectionMode"] as UserSelectionMode).ButtonClickJeu += (sender, args) => NavigateTo("Jeu");
            (userControls["Documentation"] as UserDoc).ButtonClickMesPlantes += (sender, args) => NavigateTo("MesPlantes");
            (userControls["Jeu"] as UserJeu).ButtonClickSuccès += (sender, args) => NavigateTo("Succès");
            (userControls["SelectionConnexion"] as UserSelectionConnexion).ButtonClickConnexion += (sender, args) => NavigateTo("Connexion");
            (userControls["SelectionConnexion"] as UserSelectionConnexion).ButtonClickInscription += (sender, args) => NavigateTo("Inscription");

            NavigateTo("Chargement");
        }

        /// <summary>
        /// Constructeur du navigator
        /// </summary>
        public Navigator()
        {
            InitUserControls();
        }

        /// <summary>
        /// Dépile deux élément de la pile permettant de revenir en arrière dans la navigation de l'application
        /// </summary>
        public void Back()
        {
            RetourPile.Pop();
            NavigateTo(RetourPile.Pop());
        }
       
        /// <summary>
        /// Propriété désignant le usercontrol actuellement sélectionné
        /// </summary>
        public UserControl SelectedUserControl
        {
            get => selectedUserControl;
            set
            {
                selectedUserControl = value;
                OnPropertyChanged();
            }
        }
        private UserControl selectedUserControl;

        /// <summary>
        /// Instanciation de property changed permettant de notifier la vue
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedUserControl)));

        /// <summary>
        /// Méthode permettant de naviguer vers un user control grâce à son nom
        /// </summary>
        /// <param name="userControl">Nom du user control vers lequel naviguer</param>
        public void NavigateTo(string userControl)
        {
            RetourPile.Push(userControl);
            SelectedUserControl = userControls.GetValueOrDefault(userControl);
        }

        
    }
}

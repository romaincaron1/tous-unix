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

namespace TousUnixPourRaoul
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Stake> stakes = new List<Stake>();
        int count_question = 1;
        int nb_stakes = 0;
        Stake temp_stake;
        struct Stake
        {
            public float x;
            public float y;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void onClick(object sender, RoutedEventArgs e)
        {
            //Veuillez saisir le nombre de piquets 
            if(count_question == 1 && nb_stakes == 0) {
                //initialisation de nb_stakes à x la valeur saisie par l'utilisateur
            }
            //Veuillez saisir la coordonnée x du piquet ...
            if(count_question%2 == 0 && count_question < nb_stakes) {
                //Le n-ième piquet est créé et son x est définit 
            } else { //Veuillez saisir la cordonnée y du piquet
                //Son y est définit
                //Ajout du piquet dans la liste
            }
            //Juste avant de terminer la saisie
            if(count_question == nb_stakes - 1) {
                //Changement de la valeur OK du bouton en "Obtenir le résultat"
            }
            //Plus de piquet à saisir
            if(count_question == nb_stakes) {
                //Appel d'une fonction pour traiter les valeurs et afficher le résultat
            }
            count_question++;
        }
    }
}

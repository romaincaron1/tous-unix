using System;
using System.Collections.Generic;
using System.Windows;

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
        String error;
        int temp_x;
        public struct Stake
        {
            public int x;
            public int y;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void onClick(object sender, RoutedEventArgs e)
        {
            int value;
            bool isValid = false;
            if (int.TryParse(tbox_input.Text, out value))
            {
                //Veuillez saisir le nombre de piquets 
                if (count_question == 1 && nb_stakes == 0)
                {
                    //Vérification de la valeur saisie (entre 1 et 50)
                    if (value < 1 || value > 50)
                    {
                        error = "Veuillez entrer un nombre valide de piquet (1-50)";
                        count_question = 1;
                    } else {
                        //Vérfication OK
                        isValid = true;
                        error = "";
                        lb_input.Content = "Veuillez saisir la coordonnée x du piquet n°" + (stakes.Count + 1);
                        nb_stakes = value;
                    }
                }

                //Veuillez saisir la coordonnée x du piquet ...
                if (count_question%2 == 0)
                {
                    temp_x = 0;
                    lb_input.Content = "Veuillez saisir la coordonnée y du piquet n°" + (stakes.Count + 1);
                    temp_x = value;
                    isValid = true;
                }
                else
                { //Veuillez saisir la cordonnée y du piquet
                    if(count_question != 1)
                    { 
                        Stake temp_stake;
                        temp_stake.x = 0;
                        temp_stake.y = 0;

                        temp_stake.x = temp_x;
                        temp_stake.y = value;
                        stakes.Add(temp_stake);
                        lb_input.Content = "Veuillez saisir la coordonnée x du piquet n°" + (stakes.Count + 1);
                        isValid = true;
                    }
                }

                if(stakes.Count == nb_stakes - 1 && count_question%2 == 0 && isValid == true)
                {
                    btn_input.Content = "Terminer la saisie";
                }

                if(stakes.Count == nb_stakes && isValid == true)
                {
                    tbox_input.Text = "";
                    lb_input.Content = "Saisie terminée";
                    btn_input.IsEnabled = false;
                    tbox_input.IsEnabled = false;

                    //Résultats à afficher
                    GetResults results = new GetResults();

                    String square = results.getSquare(stakes);
                    String center_of_gravity = results.getCenterOfGravity(stakes);
                    String cow_position = results.getCowPosition(stakes);


                    //Affichage des résultats
                    gb_results.Visibility = Visibility.Visible;
                    lb_square.Content = square;
                    lb_cog.Content = center_of_gravity;
                    lb_cow_position.Content = cow_position;
                }
                if(isValid)
                {
                    tbox_input.Text = "";
                    count_question++;
                }
            } else
            {
                error = "Veuillez saisir un nombre";
            }
            lb_error.Content = error;
        }
    }
}

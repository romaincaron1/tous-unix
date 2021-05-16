using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
        String error;
        double temp_x;

        //Piquet
        public struct Stake
        {
            public double x;
            public double y;
        }
        public MainWindow()
        {
            InitializeComponent();
            Line line = new Line();
            SolidColorBrush test = new SolidColorBrush();
            test.Color = Color.FromRgb(230, 230, 250);
            line.Fill = test;
            line.Width = 2;
            line.Height = 2;
            line.X1 = 0;
            line.Y1 = 90;
            line.X2 = 180;
            line.Y2 = 90;
            cv_draw.Children.Add(line);
        }

        private void onClick(object sender, RoutedEventArgs e)
        {
            double value;
            bool isValid = false;

            //Focus sur le champs de saisie
            tbox_input.Focus();

            if (double.TryParse(tbox_input.Text, out value))
            {
                //Veuillez saisir le nombre de piquets 
                if (count_question == 1 && nb_stakes == 0)
                {
                    //Vérification de la valeur saisie (entre 1 et 50)
                    if (value < 3 || value > 50)
                    {
                        error = "Veuillez entrer un nombre valide de piquet (3-50)";
                        count_question = 1;
                    }
                    else if ((int)value != value)
                    {
                        error = "Veuillez saisir une valeur entière";
                        count_question = 1;
                    }
                    else
                    {
                        //Vérfication OK
                        isValid = true;
                        error = "";
                        lb_input.Content = "Veuillez saisir la coordonnée x du piquet n°" + (stakes.Count + 1);
                        nb_stakes = (int)value;
                    }
                }

                //Veuillez saisir la coordonnée x du piquet ...
                if (count_question % 2 == 0)
                {
                    temp_x = 0;
                    lb_input.Content = "Veuillez saisir la coordonnée y du piquet n°" + (stakes.Count + 1);
                    temp_x = value;
                    isValid = true;
                    
                }
                else
                { //Veuillez saisir la cordonnée y du piquet
                    if (count_question != 1)
                    {
                        Stake temp_stake;
                        temp_stake.x = 0;
                        temp_stake.y = 0;

                        temp_stake.x = temp_x;
                        temp_stake.y = value;
                        stakes.Add(temp_stake);
                        lb_input.Content = "Veuillez saisir la coordonnée x du piquet n°" + (stakes.Count + 1);
                        isValid = true;

                        //Canvas
                        Ellipse point = new Ellipse();
                        SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                        mySolidColorBrush.Color = Color.FromRgb(230, 230, 250);
                        point.Fill = mySolidColorBrush;
                        point.Width = 2;
                        point.Height = 2;
                        Canvas.SetTop(point, 90 - temp_stake.y);
                        Canvas.SetLeft(point, 90 + temp_stake.x);
                        cv_draw.Children.Add(point);
                    }
                }

                if (stakes.Count == nb_stakes - 1 && count_question % 2 == 0 && isValid == true)
                {
                    btn_input.Content = "Terminer la saisie";
                }

                if (stakes.Count == nb_stakes && isValid == true)
                {
                    //Résultats à afficher
                    GetResults results = new GetResults();

                    double square = Math.Abs(results.getSquare(stakes));
                    double[] center_of_gravity = results.getCenterOfGravity(stakes, square);
                    bool cow_position = results.getCowPosition(stakes);

                    //Zone de saisie cachée
                    sp_input.Visibility = Visibility.Hidden;
                    btn_input.Visibility = Visibility.Hidden;

                    //Affichage des résultats
                    gb_results.Visibility = Visibility.Visible;
                    lb_square.Content = "Aire : " + square;
                    lb_cog.Content = "Centre de gravité : (" + Math.Round(center_of_gravity[0],3) + ";" + Math.Round(center_of_gravity[1],3) + ")";
                    if (cow_position)
                    {
                        lb_cow_position.Content = "La vache est à l'intérieur de l'enclos";
                    }
                    else
                    {
                        lb_cow_position.Content = "La vache est à l'extérieur de l'enclos";
                    }

                    //Ajout du centre de gravité dans le canvas
                    Ellipse point = new Ellipse();
                    SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                    mySolidColorBrush.Color = Color.FromRgb(255, 0, 0);
                    point.Fill = mySolidColorBrush;
                    point.Width = 3;
                    point.Height = 3;
                    Canvas.SetTop(point, 90 - Math.Round(center_of_gravity[1], 3));
                    Canvas.SetLeft(point, 90 + Math.Round(center_of_gravity[0], 3));
                    cv_draw.Children.Add(point);

                }
                if (isValid)
                {
                    tbox_input.Text = "";
                    error = "";
                    count_question++;
                }
            }
            else
            {
                error = "Veuillez saisir un nombre valide";
            }
            lb_error.Content = error;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TousUnixPourRaoul
{
    public class GetResults
    {
        public double getSquare(List<MainWindow.Stake> stakes)
        {
            int nb_stake = stakes.Count;
            double square = 0;
            double sum = 0;
            int next_i = 0;
            double x0 = 0.0; double y0 = 0.0;
            double x1 = 0.0; double y1 = 0.0;
            for (int i = 0; i < nb_stake; i++)
            {
                next_i = (i + 1) % (nb_stake);

                x0 = stakes[i].x;
                y0 = stakes[i].y;
                x1 = stakes[next_i].x;
                y1 = stakes[next_i].y;

                sum = sum + x0 * y1 - x1 * y0;
            }
            square = sum / 2;
            return square;
        }

        public double[] getCenterOfGravity(List<MainWindow.Stake> stakes, double square)
        {
            double[] results = new double[2];

            double center_of_gravity_x = 0;
            double center_of_gravity_y = 0;
            int i;
            int next_i = 0;
            for (i = 0; i <= (stakes.Count) - 1; i++)
            {
                next_i = (i + 1) % (stakes.Count);

                center_of_gravity_x += (stakes[i].x + stakes[next_i].x) * (stakes[i].x * stakes[next_i].y - stakes[next_i].x * stakes[i].y);

                center_of_gravity_y += (stakes[i].y + stakes[next_i].y) * (stakes[i].x * stakes[next_i].y - stakes[next_i].x * stakes[i].y);

            }

            center_of_gravity_x /= (6 * square);
            center_of_gravity_y /= (6 * square);

            results[0] = center_of_gravity_x;
            results[1] = center_of_gravity_y;

            return results;
        }

        public bool getCowPosition(List<MainWindow.Stake> stakes)
        {
            double sum = 0;
            double thetai = 0;
            int nb_stake = stakes.Count;
            int next_i = 0; int next_i_a = 0;

            for (int i = 0; i < nb_stake; i++)
            {
                double scalar_p = 0;
                double norm_u = 0;
                double norm_v = 0;
                double det = 0;
                double[] vect_u = new double[2];
                double[] vect_v = new double[2];
                next_i = (i + 1) % (nb_stake);
                next_i_a = (i + 2) % (nb_stake);

                //Calcul des coordonnées du vecteur U
                vect_u[0] = (stakes[next_i].x - stakes[i].x);
                vect_u[1] = (stakes[next_i].y - stakes[i].y);

                //Calcul des coordonnées du vecteur V
                vect_v[0] = (stakes[next_i_a].x - stakes[next_i].x);
                vect_v[1] = (stakes[next_i_a].y - stakes[next_i].y);

                //Calcul du produit scalaire
                scalar_p = (vect_u[0] * vect_v[0]) + (vect_u[1] * vect_v[1]);
                //Calcul de la norme du vecteur U (premier vecteur)
                norm_u = Math.Sqrt(Math.Pow(vect_u[0], 2) + Math.Pow(vect_u[1], 2));
                //Calcul de la norme du vecteur V (deuxième vecteur)
                norm_v = Math.Sqrt(Math.Pow(vect_v[0], 2) + Math.Pow(vect_v[1], 2));

                thetai = Math.Acos(scalar_p / (norm_u * norm_v));

                //Calcul du determinant
                det = (vect_u[0] * vect_v[1]) - (vect_u[1] * vect_v[0]);
                if (det < 0)
                {
                    thetai = thetai * -1;
                }
                else
                {
                    thetai = Math.Abs(thetai);
                }

                //Calculer Thetai
                sum = sum + thetai;
            }
            if (sum == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
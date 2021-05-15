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

            return results;
        }

        public bool getCowPosition(List<MainWindow.Stake> stakes)
        {

            return false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TousUnixPourRaoul
{
    public class GetResults
    {

        public string getSquare(List<MainWindow.Stake> stakes)
        {
            for(int i = 0; i < stakes.Count; i++)
            {
                Console.WriteLine("AVANT: Piquet n°"+i+" : " + stakes[i].x + " / " + stakes[i].y);
            }
            int nb_stake = stakes.Count;
            float square = 0;
            float sum = 0;
            for(int i = 0; i < nb_stake - 1; i++)
            {
                sum = sum + (stakes[i].x * stakes[i + 1].y - stakes[i + 1].x * stakes[i].y);
                Console.WriteLine("PENDANT: SUM = " + sum);
            }
            Console.WriteLine("APRES: SUM = " + sum);
            square = sum/2;
            Console.WriteLine("APRES: SQUARE = " + square);
            return "Aire : " + square;
        }

        public string getCenterOfGravity(List<MainWindow.Stake> stakes)
        {
            return "Centre de gravité : xxx";
        }

        public string getCowPosition(List<MainWindow.Stake> stakes)
        {
            return "Position de la vache : La vache est xxx";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI____Robot_Localization
{
    public class RegionMap
    {
        private const double O = 0.00;
        private const double F = 4.35;
        private double[,] floorPlan =
        {
            { F, F, F, F, F, F },
            { F, O, O, O, O, F },
            { F, O, F, F, O, F },
            { F, O, F, F, F, F },
            { F, F, F, F, F, F }
        };

        public void Print()
        {
            for (int row = 0; row < floorPlan.GetLength(0); row++)
            {
                for (int col = 0; col < floorPlan.GetLength(1); col++)
                {
                    var temp = String.Format("{0:d3} ", floorPlan[row, col]);
                    Console.Write(temp);
                }
                Console.WriteLine();
            }
        }

        public double this[int row, int col]
        {
            set
            {
                floorPlan[row, col] = value;
            }

            get
            {
                if (row < floorPlan.GetLength(0) && col < floorPlan.GetLength(1))
                {
                    return floorPlan[row, col];
                }
                else // treat invalid indices as obstacles
                {
                    return 0d;
                }
            }
        }

        public List<double> GetAllPossibleLocations(string reading)
        {
            List<double> locations = new List<double>();
            reading.Split(); 
        }
    }

}

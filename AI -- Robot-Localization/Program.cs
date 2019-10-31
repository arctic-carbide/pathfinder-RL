 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI____Robot_Localization
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

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
                // TODO: IF OUT OF BOUNDS, TREAT AS OBSTACLE
                return floorPlan[row, col];
            }
        }
    }
    public class Robot
    {
        private const double ObstacleDetectRate = 0.9;
        private const double ObstacleFalsePositiveRate = 0.05;
        private const double DriftChance = 0.1;
        private const int rowStart = 0;
        private const int colStart = 1;

        private RegionMap maze = new RegionMap();
        private Random roll = new Random();

        public void MoveUp() { }
        public void MoveDown() { }
        public void MoveLeft() { }
        public void MoveRight() { }
        public void Sense() { }

        private void Drift()
        {
            if (roll.NextDouble() <= DriftChance)
            {

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI____Robot_Localization
{
    public class Robot
    {
        private const double ObstacleDetectRate = 0.9;
        private const double ObstacleFalsePositiveRate = 0.05;
        private const double ForwardChance = 0.8;
        private const double DriftChance = 0.1;
        private string[] sensorReadings = { "---o", "o---", "oo--", "-oo-" };

        private RegionMap _maze = new RegionMap();

        public Robot()
        {
            _maze.Print();
        }

        public void MotionUpdate(string direction)
        {
            // total summation


            _maze.Print();
        }

        public void SensorUpdate(string reading)
        {
            // update all maps values by matching sensor reading to location
            // if the location does not match, use false positive value
            // if the location matches, use
            double targetValue;
            double matchValue;
            double mismatchValue;
            bool match;

            List<double> allMatches = new List<double>();
            List<double> matches = new List<double>();
            List<double> mismatches = new List<double>();

            // figure how many matches there are
            for (int row = 0; row < _maze.Rows; row++)
            {
                for (int col = 0; col < _maze.Columns; col++)
                {
                    targetValue = _maze[row, col];
                    match = _maze.IsMatch(reading, row, col);
                    
                    

                    allMatches.Add(_maze[row, col]);
                    if (match)
                    {
                        matches.Add(ObstacleDetectRate * _maze[row, col]);
                    }
                    else
                    {
                        mismatches.Add(ObstacleFalsePositiveRate * _maze[row, col]);
                    }

                }

            }

            double matchSum = matches.Sum();
            double mismatchSum = mismatches.Sum();
            double divisor = matchSum + mismatchSum;

            for (int row = 0; row < _maze.Rows; row++)
            {
                for (int col = 0; col < _maze.Columns; col++)
                {
                    _maze[row, col] = _maze[row, col] / divisor;
                }
            }

            _maze.Print();
        }

    }

}

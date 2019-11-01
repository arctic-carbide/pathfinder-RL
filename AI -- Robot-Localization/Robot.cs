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
        private const double DriftChance = 0.1;
        private string[] sensorReadings = { "----", "o---", "oo--", "-oo-" };
        private enum Heading { North, East };
        private Heading[] headingOrder = { Heading.North, Heading.North, Heading.East };

        private Queue<Heading> direction;
        private Queue<string> sensorSequence;
        

        public Robot()
        {
            sensorSequence = new Queue<string>(sensorReadings);
            direction = new Queue<Heading>(headingOrder);
        }

        public void MoveNorth() { }
        public void MoveEast() { }

        public void UpdateMotion(RegionMap rm)
        {
            Heading h = direction.Dequeue();
            switch (h)
            {
                case Heading.North:
                    MoveNorth();
                    break;
                case Heading.East:
                    MoveEast();
                    break;
            }
        }

        public void UpdateSensor(RegionMap rm)
        {
            string reading = sensorSequence.Dequeue();
        }

    }

}

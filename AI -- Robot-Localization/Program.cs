 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI____Robot_Localization
{
    class Program
    {
        private static string[] sensorReadings = { "---o", "o---", "oo--", "-oo-" };
        private static string[] motions = { "north", "north", "east" };
        static void Main(string[] args)
        {
            Robot r = new Robot();



            r.SensorUpdate(sensorReadings[0]);
            r.MotionUpdate(motions[0]);
            r.SensorUpdate(sensorReadings[1]);
            r.MotionUpdate(motions[1]);
            r.SensorUpdate(sensorReadings[2]);
            r.MotionUpdate(motions[2]);
            r.SensorUpdate(sensorReadings[3]);


        }
    }

}

 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI____Robot_Localization
{
    class Program
    {
        private const int MaxTurns = 7;
        static void Main(string[] args)
        {
            RegionMap rm = new RegionMap();
            Robot r = new Robot();

            for (int turnNumber = 0; turnNumber < MaxTurns; turnNumber++)
            {
                if (turnNumber % 2 == 1)
                {
                    r.UpdateSensor(rm);
                }
                else
                {
                    r.UpdateMotion(rm);
                }
            }


        }
    }

}

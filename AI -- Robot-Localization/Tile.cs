using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI____Robot_Localization
{
    public abstract class Tile
    {
        public double CurrentValue { get; set; }
        public Tile(double d)
        {
            CurrentValue = d;
        }

       
    }
}

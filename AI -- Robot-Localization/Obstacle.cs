using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI____Robot_Localization
{
    public class Obstacle : Tile
    {
        private const double DefaultValue = 0.00;
        public Obstacle(double d = DefaultValue) : base(d) { }
    }
}

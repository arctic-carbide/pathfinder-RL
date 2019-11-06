using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI____Robot_Localization
{
    public class Floor : Tile
    {
        private const double DefaultValue = 4.35;
        public Floor(double d = DefaultValue) : base(d) { }
    }
}

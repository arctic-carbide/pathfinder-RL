using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI____Robot_Localization
{
    public abstract class Evidence
    {
        public string Value { get; private set; }

        public Evidence(string data)
        {
            Value = data;
        }   
    }
}

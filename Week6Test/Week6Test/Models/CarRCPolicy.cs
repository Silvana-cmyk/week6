using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Test.Models
{
    public class CarRCPolicy : Policy
    {
        public string Plate { get; set; }
        public int Displacement { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Plate: {Plate} - Displacememt {Displacement} ";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Test.Models
{
    public class TheftPolicy : Policy
    {
        public int PercentageCoverage { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Percentage Coverage: {PercentageCoverage}";
        }
    }
}

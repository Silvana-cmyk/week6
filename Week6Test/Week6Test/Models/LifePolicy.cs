using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Test.Models
{
    public class LifePolicy : Policy
    {
        public int Years { get; set; }

        public override string ToString()
        {
            return base.ToString() + $" Years: {Years}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Test.Models
{
    public class Policy
    {
        public int Number { get; set; }
        public DateTime StipulationDate { get; set; }
        public float InsuranceAmount { get; set; }
        public float MonthlyInstallment { get; set; }

        public string ClientCF { get; set; }
        public Client Client { get; set; }

        public override string ToString()
        {
            return $"nUMBER: {Number} - Stipulation Date;{StipulationDate} - Insuranced Amount. {InsuranceAmount} - Montly Installment : {MonthlyInstallment}";
        }
    }
}

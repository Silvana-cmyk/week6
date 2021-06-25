using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Test.Models
{
    public class Client
    {
        public string CF { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }

        public ICollection<Policy> Policies { get; set; } = new List<Policy>();

        public override string ToString()
        {
            return $"CF: {CF} - {FirstName} - {LastName} - {Address}";
        }
    }
}

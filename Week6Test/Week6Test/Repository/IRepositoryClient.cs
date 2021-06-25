using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6Test.Models;

namespace Week6Test.Repository
{
    public interface IRepositoryClient : IRepository<Client>
    {
        public Client GetByCF(string s);
    }
}

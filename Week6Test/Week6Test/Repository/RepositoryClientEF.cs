using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6Test.Context;
using Week6Test.Models;

namespace Week6Test.Repository
{
    public class RepositoryClientEF : IRepositoryClient
    {
        public Client Create(Client item)
        {
            using (var ctx = new PolizzeContext())
            {
                if (item != null)
                {
                    try
                    {
                        ctx.Entry<Client>(item).State = EntityState.Added;
                        ctx.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                }
            }
            return item;
        }

        public ICollection<Client> GetAll()
        {
            using (var ctx = new PolizzeContext())
            {
                return ctx.Clients.ToList();
            }
        }

        public Client GetByCF(string s)
        {
            using (var ctx = new PolizzeContext())
            {
                if (s == null)
                {
                    return null;
                }
                return ctx.Clients.Include(p => p.Policies)
                                  .FirstOrDefault(n => n.CF == s);
            }
        }
    }
}

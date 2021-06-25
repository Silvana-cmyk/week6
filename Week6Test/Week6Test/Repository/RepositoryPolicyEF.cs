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
    public class RepositoryPolicyEF : IRepositoryPolicy
    {
        public Policy Create(Policy item)
        {
            using (var ctx = new PolizzeContext())
            {
                if (item != null)
                {
                    try
                    {
                        ctx.Entry<Policy>(item).State = EntityState.Added;
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

        public ICollection<Policy> GetAll()
        {
            using (var ctx = new PolizzeContext())
            {
                return ctx.Policies.ToList();
            }
        }

        public Policy GetByNumber(int i)
        {
            using (var ctx = new PolizzeContext())
            {
                return ctx.Policies.Find(i);
            }
        }
    }
}

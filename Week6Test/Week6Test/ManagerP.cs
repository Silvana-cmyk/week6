using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week6Test.Models;
using Week6Test.Repository;

namespace Week6Test
{

    public static class ManagerP
    {
        static IRepositoryClient repoClient = new RepositoryClientEF();
        static IRepositoryPolicy repoPolicy = new RepositoryPolicyEF();

        internal static bool Menu()
        {

            Console.WriteLine("Hello!");
            Console.WriteLine("1. Add client");
            Console.WriteLine("2. Add policy");
            Console.WriteLine("3. View data");
            Console.WriteLine("4. Exit");
            int scelta = 0;
            try
            {
                scelta = Convert.ToInt32(Console.ReadLine());
                while (scelta < 0 || scelta > 5)
                {
                    Console.WriteLine("Please, insert a number between 1 and 4");
                    scelta = Convert.ToInt32(Console.ReadLine());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Choice(scelta);
        }

        private static bool Choice(int scelta)
        {
            bool continua = true;
            switch (scelta)
            {
                case 1:
                    AddClient();
                    break;
                case 2:
                    AddPolicy();
                    break;
                case 3:
                    Stampa();
                    break;
                case 4:
                    continua = false;
                    Console.WriteLine("---End---");
                    break;
            }
            return continua;
        }

        private static void AddClient()
        {
            Console.WriteLine("Add cf");
            string cf = Console.ReadLine();
            Console.WriteLine("Add first name");
            string fn = Console.ReadLine();
            Console.WriteLine("Add last name");
            string ln = Console.ReadLine();
            Console.WriteLine("Add address");
            string a = Console.ReadLine();

            var clientCreated = repoClient.Create(new Client()
            {
                CF = cf,
                FirstName = fn,
                LastName = ln,
                Address = a
            }); 

            if (clientCreated != null)
            {
                Console.WriteLine("Client created!");
            }
            else
            {
                Console.WriteLine("Operation failed...");
            }
        }

        private static void AddPolicy()
        {
            try
            {
                Policy policyToInsert;
                Console.WriteLine("Insert stipulation date");
                DateTime ds = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Insert insurance amount");
                float ia = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Insert monthly installment");
                float mi = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Insert type of policy");
                Console.WriteLine("1- Car RC 2- Theft 3- Life");
                var aux = Convert.ToInt32(Console.ReadLine());
                if (aux == 1)
                {
                    Console.WriteLine("Insert plate");
                    string p = Console.ReadLine();
                    Console.WriteLine("Insert displacement");
                    int d = Convert.ToInt32(Console.ReadLine());
                    policyToInsert = new CarRCPolicy()
                    {
                        StipulationDate = ds,
                        InsuranceAmount = ia,
                        MonthlyInstallment = mi,
                        Plate = p,
                        Displacement = d
                    };
                }
                else if (aux == 2)
                {
                    Console.WriteLine("Insert percentage coverage");
                    int pc = Convert.ToInt32(Console.ReadLine());
                    policyToInsert = new TheftPolicy()
                    {
                        StipulationDate = ds,
                        InsuranceAmount = ia,
                        MonthlyInstallment = mi,
                        PercentageCoverage = pc
                    };
                }
                else if (aux == 3)
                {
                    Console.WriteLine("Insert years");
                    int y = Convert.ToInt32(Console.ReadLine());
                    policyToInsert = new LifePolicy()
                    {
                        StipulationDate = ds,
                        InsuranceAmount = ia,
                        MonthlyInstallment = mi,
                        Years = y
                    };
                }
                else
                {
                    Console.WriteLine("Wrong number!");
                    return;
                }
                Console.WriteLine("Add CF Client");
                string cf = Console.ReadLine();
                var aux2 = repoClient.GetByCF(cf);
                if (aux2 != null)
                {
                    var client = repoClient.GetByCF(cf);
                    policyToInsert.Client = client;
                    repoPolicy.Create(policyToInsert);
                }
                else
                {
                    Console.WriteLine("There is no client with this cf...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private static void Stampa()
        {

            try
            {

                var p = repoPolicy.GetAll();
                foreach (var temp in p)
                {
                    Console.WriteLine(temp.ToString());
                    StampaUser(temp.ClientCF);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void StampaUser(string s)
        {
            float count = 0;
            var p = repoPolicy.GetAll();
            foreach (var temp in p)
            {
                if (temp.ClientCF == s)
                    count = count + temp.InsuranceAmount;
            }
            Console.WriteLine(repoClient.GetByCF(s).FirstName);
            Console.WriteLine("Total: " + count);
        }
    }
}

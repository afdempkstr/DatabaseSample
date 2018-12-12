using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bank = new BankEntities())
            {
                //var customers = 
                //    from customer in bank.Customers1
                //    where customer.lastname.StartsWith("Α")
                //    select customer;

                //    //bank.Customers1.
                //    //Where(customer => customer.lastname.StartsWith("Α"));

                //foreach (var customer in customers)
                //{
                //    Console.WriteLine(customer.lastname);
                //}

                //var topAccounts = bank.Customers1.Include("account")
                //    .Select(c => c.accounts)
                //    .Select(acc => acc.OrderByDescending(a => a.balance))
                //    .First();

                //foreach (var acc in topAccounts)
                //{
                //    Console.WriteLine($"{acc.accno} {acc.bcode} {acc.branch.bname} {acc.balance}");
                //}

                //var account = bank.Accounts1.Find("A905");

                //var branch = account.branch;

                var accountWithBranch = bank.Accounts1.Include("branch")
                    .First(acc => acc.accno == "A905");

                //branch = account.branch;

                //var account = new Account()
                //{
                //    accno = "A999",
                //    balance = 500,
                //    bcode = 150
                //};

                //bank.Accounts1.Add(account);
                //bank.SaveChanges();

                //var account = bank.Accounts1.Find("A999");
                //account.balance = 4000;
                //account.customers.Add(bank.Customers1.Find(7));

                //bank.SaveChanges();

                //var account = bank.Accounts1.Find("A999");
                //bank.Accounts1.Remove(account);
                //bank.SaveChanges();
            }

            Console.Read();
        }
    }
}

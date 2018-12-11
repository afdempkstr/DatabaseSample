using System.Linq;

namespace EFModelFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bank = new bankEntities())
            {
                var account = bank.accounts
                    .Where(acc => acc.balance > 20000).FirstOrDefault();

            }
        }
    }
}

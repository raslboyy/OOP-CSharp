using System.Collections.Generic;
using System.Linq;
using Banks.Entities.AccountModule;
using Banks.Entities.BankModule.BankConfigurationModule;
using Banks.Tools;

namespace Banks.Entities.BankModule
{
    public class CentralBank
    {
        private CentralBank()
        {
        }

        private static CentralBank Instance { get; set; }
        private static List<IBankManager> Banks { get; } = new List<IBankManager>();
        private static int DaysCount { get; set; }

        public static CentralBank GetInstance() => Instance ??= new CentralBank();

        public static IBank RegisterBank(string name, BankConfiguration configuration)
        {
            var bank = new Bank(name, configuration);
            Banks.Add(bank);
            return bank;
        }

        public static AAccount FindAccount(int id)
        {
            IBankManager bank = Banks.FirstOrDefault(bank => bank.FindAccount(id) != null);
            return bank?.FindAccount(id);
        }

        public static void SkipDays(int n = 1)
        {
            Banks.ForEach(bank => bank.SkipDays(n));
        }
    }
}
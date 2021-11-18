using System;
using System.Collections.Generic;
using Banks.Entities.BankModule.ConfigurationModule;

namespace Banks.Entities.BankModule
{
    public class CentralBank
    {
        private CentralBank()
        {
        }

        private static CentralBank Instance { get; set; }
        private static List<IBankManager> Banks { get; set; }

        public static CentralBank GetInstance() => Instance ??= new CentralBank();

        public static IBank RegisterBank(string name, BankConfiguration configuration)
        {
            var bank = new Bank(name, configuration);
            Banks.Add(bank);
            return bank;
        }
    }
}
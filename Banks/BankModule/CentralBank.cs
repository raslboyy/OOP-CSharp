using System.Collections.Generic;

namespace Banks.BankModule
{
    public class CentralBank
    {
        private CentralBank()
        {
        }

        private static CentralBank Instance { get; set; }
        private static List<IBankManager> Banks { get; set; }

        public static CentralBank GetInstance() => Instance ??= new CentralBank();

        public static IBank RegisterBank(BankBuilder builder)
        {
        }
    }
}
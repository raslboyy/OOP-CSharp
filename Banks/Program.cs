using System;
using Banks.UI;
using Banks.UI.Services;

namespace Banks
{
    internal static class Program
    {
        private static void Main()
        {
            var service = new BanksService(new ConsoleUserInterface());
            service.Run();
        }
    }
}
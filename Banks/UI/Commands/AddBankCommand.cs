using System;
using System.Collections.Generic;
using Banks.Entities.BankModule;
using Banks.Entities.BankModule.BankConfigurationModule;
using Banks.Entities.BankModule.BankConfigurationModule.AccountConditionModule;
using Banks.Entities.BankModule.BankConfigurationModule.CreditConditionModule;
using Banks.Entities.BankModule.BankConfigurationModule.DebitConditionModule;
using Banks.Entities.BankModule.BankConfigurationModule.DepositConditionModule;
using static System.Double;

namespace Banks.UI.Commands
{
    public class AddBankCommand : ANonTerminatingCommand, IParameterisedCommand
    {
        public AddBankCommand(IUserInterface userInterface)
            : base(userInterface)
        {
        }

        private string Name { get; set; }
        private string CreditLimit { get; set; }
        private string CreditCommission { get; set; }
        private string DepositPercent { get; set; }
        private string DebitPercent { get; set; }
        private string WithdrawalLimit { get; set; }
        private string TransferLimit { get; set; }
        private string LimitForBadClients { get; set; }
        private BankConfiguration Configuration { get; set; }

        public bool GetParameters()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                Name = GetParameter("name");
                return false;
            }

            if (IsNotCompletedDouble(CreditLimit))
            {
                CreditLimit = GetParameter("credit limit");
                return false;
            }

            if (IsNotCompletedDouble(CreditCommission))
            {
                CreditCommission = GetParameter("credit commission");
                return false;
            }

            if (IsNotCompletedDouble(DepositPercent))
            {
                DepositPercent = GetParameter("deposit percent");
                return false;
            }

            if (IsNotCompletedDouble(DebitPercent))
            {
                DebitPercent = GetParameter("debit percent");
                return false;
            }

            if (IsNotCompletedDouble(WithdrawalLimit))
            {
                WithdrawalLimit = GetParameter("withdrawal limit");
                return false;
            }

            if (IsNotCompletedDouble(TransferLimit))
            {
                TransferLimit = GetParameter("transfer limit");
                return false;
            }

            if (IsNotCompletedDouble(LimitForBadClients))
            {
                LimitForBadClients = GetParameter("limit for bad clients");
                return false;
            }

            return true;
        }

        protected override bool InternalCommand()
        {
            try
            {
                TryParse(CreditCommission, out double creditCommission);
                TryParse(CreditLimit, out double creditLimit);
                TryParse(DebitPercent, out double debitPercent);
                TryParse(DepositPercent, out double depositPercent);
                TryParse(WithdrawalLimit, out double withdrawalLimit);
                TryParse(TransferLimit, out double transferLimit);
                TryParse(LimitForBadClients, out double limitForBadClients);
                Configuration = new BankConfiguration(
                    new CreditCondition(creditCommission, creditLimit),
                    new DebitCondition(debitPercent),
                    new DepositCondition(new List<ValuePercent> { new (depositPercent, MaxValue) }),
                    new AccountCondition(withdrawalLimit, transferLimit, limitForBadClients));
                CentralBank.RegisterBank(Name, Configuration);
            }
            catch (Exception exception)
            {
                Interface.WriteWarning(exception.Message);
            }

            return true;
        }

        private static bool IsNotCompletedDouble(string value)
        {
            return string.IsNullOrWhiteSpace(value) || !double.TryParse(value, out double _);
        }
    }
}
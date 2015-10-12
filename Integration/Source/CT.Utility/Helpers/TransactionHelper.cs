using System;
using System.Configuration;
using System.Transactions;

namespace CT.Utility.Helpers
{
    public static class TransactionHelper
    {
        public static TransactionScope CreateReadCommittedTransactionScope(
            TransactionScopeOption transactionScopeOption = TransactionScopeOption.Required,
            IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            var transactionOptions = new TransactionOptions {IsolationLevel = isolationLevel};

            var defaultSetting =
                (System.Transactions.Configuration.DefaultSettingsSection)
                ConfigurationManager.GetSection("system.transactions/defaultSettings");

            if(defaultSetting != null)
                transactionOptions.Timeout = defaultSetting.Timeout;

            return new TransactionScope(transactionScopeOption, transactionOptions);
        }
    }
}
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using System.Collections.Generic;

namespace MicroRabbit.Banking.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private BankingDbContext _ctx;

        public AccountRepository(BankingDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _ctx.Accounts;
        }

        public void UpdateAccountBalance(int from, int to, decimal v)
        {

            var fromAccount = _ctx.Accounts.Find(from);
            if (fromAccount != null)
            {
                fromAccount.AccountBalance -= v;
                _ctx.SaveChanges();
            }
            var toAccount = _ctx.Accounts.Find(to);
            if (toAccount != null)
            {
                toAccount.AccountBalance += v;
                _ctx.SaveChanges();
            }

        }
    }
}

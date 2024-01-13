using MicroRabbit.Banking.Domain.Events;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Domain.EventHandlers
{
    public class TransferExecutedEventHandler : IEventHandler<TransferExecutedEvent>
    {
        private readonly IAccountRepository _accountRepository;

        public TransferExecutedEventHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Task Handle(TransferExecutedEvent @event)
        {
            _accountRepository.UpdateAccountBalance(@event.From, @event.To, @event.Amount);
            return Task.CompletedTask;
        }
    }
}

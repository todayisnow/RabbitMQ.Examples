using MediatR;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Domain.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace MicroRabbit.Transfer.Domain.CommandHandlers
{
    public class ExecuteTransferCommandHandler : IRequestHandler<ExecuteTransferCommand, bool>
    {
        private readonly IEventBus _bus;
        public ExecuteTransferCommandHandler(IEventBus bus)
        {
            _bus = bus;

        }

        public Task<bool> Handle(ExecuteTransferCommand request, CancellationToken cancellationToken)
        {
            _bus.Publish(new Transfer.Domain.Events.TransferExecutedEvent(request.From, request.To, request.Amount));


            return Task.FromResult(true);
        }


    }
}

namespace MicroRabbit.Transfer.Domain.Commands
{
    public class ExecuteTransferCommand : TransferCommand
    {
        public ExecuteTransferCommand(int from, int to, decimal amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }
    }
}

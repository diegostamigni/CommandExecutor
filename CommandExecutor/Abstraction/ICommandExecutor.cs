using System.Threading;
using System.Threading.Tasks;

namespace CommandExecutor.Abstraction
{
	public interface ICommandExecutor<in TCommand> where TCommand : ICommand
	{
		Task ExecuteAsync(TCommand command, CancellationToken token = default);
	}
}
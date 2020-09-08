using System.Threading;
using System.Threading.Tasks;

namespace CommandExecutor.Core.Abstraction
{
	public interface ICommandExecutor<in TCommand> where TCommand : ICommand
	{
		Task ExecuteAsync(TCommand command, CancellationToken token = default);
	}

	public interface ICommandExecutor<in TCommand, TResult> where TCommand : ICommand
	{
		Task<TResult> ExecuteAsync(TCommand command, CancellationToken token = default);
	}
}
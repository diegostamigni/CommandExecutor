using System.Threading;
using System.Threading.Tasks;

namespace CommandExecutor.Abstraction
{
	public interface ICommandExecutor<in TCommand, TResult> where TCommand : ICommand
	{
		Task<TResult> ExecuteAsync(TCommand command, CancellationToken token = default);
	}
}
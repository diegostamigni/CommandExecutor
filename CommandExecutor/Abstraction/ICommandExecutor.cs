using System.Threading;
using System.Threading.Tasks;

namespace CommandExecutor.Abstraction
{
	public interface ICommandExecutor
	{
		Task ExecuteAsync(ICommand command, CancellationToken token = default);
	}
}
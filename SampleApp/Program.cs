using System.Threading.Tasks;
using CommandExecutor.Abstraction;
using CommandExecutor.DependencyInjection;
using Lamar;
using SampleApp.Commands;
using SampleApp.DependencyInjection;

namespace SampleApp
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var container = new Container(cfg =>
			{
				cfg.IncludeRegistry<CommandExecutorRegistry>();
				cfg.IncludeRegistry<HelloCommandExecutorRegistry>();
			});

			var commandExecutorResolver = container.GetInstance<ICommandExecutorResolver>();
			var command = new HelloCommand();

			var commandExecutor1 = commandExecutorResolver.Resolve<HelloCommand, bool>(command);
			await commandExecutor1.ExecuteAsync(command).ConfigureAwait(false);

			var commandExecutor2 = commandExecutorResolver.Resolve<HelloCommand>(command);
			await commandExecutor2.ExecuteAsync(command).ConfigureAwait(false);
		}
	}
}

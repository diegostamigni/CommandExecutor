using System.Threading.Tasks;
using CommandExecutor.Abstraction;
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
				cfg.IncludeRegistry<HelloCommandExecutorRegistry>();
			});

			var commandExecutorResolver = container.GetInstance<ICommandExecutorResolver>();
			var command = new HelloCommand();
			var commandExecutor = commandExecutorResolver.Resolve<HelloCommand, bool>(command);
			var result = await commandExecutor.ExecuteAsync(command).ConfigureAwait(false);
		}
	}
}

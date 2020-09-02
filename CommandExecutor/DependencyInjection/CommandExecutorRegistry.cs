using CommandExecutor.Abstraction;
using Lamar;

namespace CommandExecutor.DependencyInjection
{
	public class CommandExecutorRegistry : ServiceRegistry
	{
		public CommandExecutorRegistry()
		{
			For<ICommandExecutorResolver>()
				.Use<CommandExecutorResolver>()
				.Singleton();
		}
	}
}

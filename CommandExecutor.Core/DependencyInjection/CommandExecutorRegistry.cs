using Lamar;
using Microsoft.Extensions.DependencyInjection;

namespace CommandExecutor.Core.DependencyInjection
{
	public class CommandExecutorRegistry : ServiceRegistry
	{
		public CommandExecutorRegistry()
			: this(ServiceLifetime.Scoped)
		{
		}

		public CommandExecutorRegistry(ServiceLifetime serviceLifetime)
		{
			Scan(s =>
			{
				s.TheCallingAssembly();
				s.WithDefaultConventions(serviceLifetime);
			});
		}
	}
}

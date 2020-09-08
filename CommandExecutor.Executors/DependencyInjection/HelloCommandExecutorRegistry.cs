using CommandExecutor.Core.DependencyInjection;
using Lamar;
using Microsoft.Extensions.DependencyInjection;

namespace CommandExecutor.Executors.DependencyInjection
{
	public class HelloCommandExecutorRegistry : ServiceRegistry
	{
		public HelloCommandExecutorRegistry()
			: this(ServiceLifetime.Scoped)
		{
		}

		public HelloCommandExecutorRegistry(ServiceLifetime serviceLifetime)
		{
			Scan(s =>
			{
				s.AssemblyContainingType<HelloCommandSimpleExecutor>();
				s.With(new CommandExecutorRegistrationConvention(serviceLifetime));
			});

			IncludeRegistry(new CommandExecutorRegistry(serviceLifetime));
		}
	}
}

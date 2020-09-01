using CommandExecutor;
using CommandExecutor.Abstraction;
using Lamar;

namespace SampleApp.DependencyInjection
{
	public class HelloCommandExecutorRegistry : ServiceRegistry
	{
		public HelloCommandExecutorRegistry()
		{
			Scan(s =>
			{
				s.TheCallingAssembly();
				s.With(new HelloCommandExecutorRegistrationConvention());
			});

			For<ICommandExecutorResolver>()
				.Use<CommandExecutorResolver>()
				.Singleton();
		}
	}
}

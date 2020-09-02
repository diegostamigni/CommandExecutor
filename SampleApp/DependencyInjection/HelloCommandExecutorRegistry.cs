using CommandExecutor.DependencyInjection;
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
				s.With(new CommandExecutorRegistrationConvention());
			});

			IncludeRegistry<CommandExecutorRegistry>();
		}
	}
}

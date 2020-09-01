using System.Linq;
using System.Reflection;
using BaselineTypeDiscovery;
using CommandExecutor.Abstraction;
using CommandExecutor.Attributes;
using Lamar;
using Lamar.Scanning.Conventions;
using TypeExtensions = LamarCodeGeneration.Util.TypeExtensions;

namespace SampleApp.DependencyInjection
{
	public class HelloCommandExecutorRegistrationConvention : IRegistrationConvention
	{
		public void ScanTypes(TypeSet types, ServiceRegistry services)
		{
			var commandExecutorTypes = types
				.AllTypes()
				.Where(x => typeof(ICommandExecutor).IsAssignableFrom(x) && x.IsClass && !x.IsAbstract && TypeExtensions.HasAttribute<SupportsCommandAttribute>(x));

			foreach (var commandExecutorType in commandExecutorTypes)
			{
				var attr = commandExecutorType.GetCustomAttribute<SupportsCommandAttribute>();
				if (attr is null)
				{
					continue;
				}

				services
					.For(typeof(ICommandExecutor))
					.Use(commandExecutorType)
					.Named(attr.CommandType.Name)
					.Scoped();
			}
		}
	}
}
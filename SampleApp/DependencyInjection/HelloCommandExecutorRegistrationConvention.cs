using System.Linq;
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
				.Where(x => x.IsClass && !x.IsAbstract && TypeExtensions.HasAttribute<SupportsCommandAttribute>(x));

			foreach (var commandExecutorType in commandExecutorTypes)
			{
				var interfaceType = commandExecutorType
					.GetInterfaces()
					.Where(x => x.Name == typeof(ICommandExecutor<>).Name)
					.Select(x => new
					{
						Interface = x,
						Command = x.GenericTypeArguments.SingleOrDefault()
					})
					.SingleOrDefault();

				if (interfaceType is null)
				{
					continue;
				}

				services
					.For(interfaceType.Interface)
					.Use(commandExecutorType)
					.Named(interfaceType.Command?.Name)
					.Scoped();
			}
		}
	}
}
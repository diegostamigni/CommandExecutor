using System.Collections.Generic;
using System.Linq;
using BaselineTypeDiscovery;
using CommandExecutor.Abstraction;
using Lamar;
using Lamar.Scanning.Conventions;

namespace CommandExecutor.DependencyInjection
{
	public class CommandExecutorRegistrationConvention : IRegistrationConvention
	{
		private static readonly HashSet<string> SupportedCommandExecutors = new HashSet<string>
		{
			typeof(ICommandExecutor<>).Name,
			typeof(ICommandExecutor<,>).Name
		};

		public void ScanTypes(TypeSet types, ServiceRegistry services)
		{
			var commandExecutorTypes = types
				.AllTypes()
				.Where(x => x.IsClass && !x.IsAbstract)
				.Select(x => new
				{
					Type = x,
					Interface = x.GetInterfaces().SingleOrDefault(z => SupportedCommandExecutors.Contains(z.Name))
				})
				.Where(x => x.Interface != null)
				.Select(x => new
				{
					x.Type,
					x.Interface,
					Command = x.Interface.GenericTypeArguments.FirstOrDefault()
				})
				.ToList();

			if (commandExecutorTypes.Count == 0)
			{
				return;
			}

			foreach (var commandExecutorType in commandExecutorTypes)
			{
				services
					.For(commandExecutorType.Interface)
					.Use(commandExecutorType.Type)
					.Named(commandExecutorType.Command?.Name)
					.Scoped();
			}
		}
	}
}
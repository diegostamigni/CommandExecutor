using System.Collections.Generic;
using System.Linq;
using BaselineTypeDiscovery;
using CommandExecutor.Core.Abstraction;
using Lamar;
using Lamar.Scanning.Conventions;
using Microsoft.Extensions.DependencyInjection;

namespace CommandExecutor.Core.DependencyInjection
{
	public class CommandExecutorRegistrationConvention : IRegistrationConvention
	{
		private readonly ServiceLifetime serviceLifetime;

		private static readonly HashSet<string> SupportedCommandExecutors = new HashSet<string>
		{
			typeof(ICommandExecutor<>).Name,
			typeof(ICommandExecutor<,>).Name
		};

		public CommandExecutorRegistrationConvention(ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
		{
			this.serviceLifetime = serviceLifetime;
		}

		public void ScanTypes(TypeSet types, ServiceRegistry services)
		{
			var commandExecutorTypes = types
				.AllTypes()
				.Where(x => x.IsClass && !x.IsAbstract && x.GetInterfaces().Any(z => SupportedCommandExecutors.Contains(z.Name)))
				.Select(x => new
				{
					Type = x,
					Interface = x.GetInterfaces().SingleOrDefault(z => SupportedCommandExecutors.Contains(z.Name))
				})
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
				var instance = services
					.For(commandExecutorType.Interface)
					.Use(commandExecutorType.Type)
					.Named(commandExecutorType.Command?.Name)
					.Scoped();

				instance.Lifetime = this.serviceLifetime;
			}
		}
	}
}
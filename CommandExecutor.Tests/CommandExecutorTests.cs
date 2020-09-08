using System;
using System.Threading.Tasks;
using CommandExecutor.Core.Abstraction;
using CommandExecutor.Executors.DependencyInjection;
using CommandExecutor.ServiceModel;
using Lamar;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Shouldly;

namespace CommandExecutor.Tests
{
	[TestFixture]
	public class CommandExecutorTests
	{
		private Container container;
		private ICommandExecutorResolver commandExecutorResolver;

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			this.container = new Container(cfg =>
			{
				cfg.IncludeRegistry(new HelloCommandExecutorRegistry(ServiceLifetime.Scoped));
			});

			var containerScan = this.container.WhatDidIScan();
			Console.WriteLine(containerScan);

			var containerContent = this.container.WhatDoIHave();
			Console.WriteLine(containerContent);

			this.commandExecutorResolver = this.container.GetInstance<ICommandExecutorResolver>();
		}

		[Test]
		public void AssertConfigurationIsValid()
		{
			this.container.AssertConfigurationIsValid();
		}

		[Test]
		public async Task ShouldResolveCommandWithReturnValue()
		{
			var command = new HelloCommand();

			var commandExecutor1 = this.commandExecutorResolver.Resolve<HelloCommand, bool>(command);
			var result = await commandExecutor1.ExecuteAsync(command).ConfigureAwait(false);
			result.ShouldBe(true);
		}

		[Test]
		public async Task ShouldResolveCommandWithoutReturnValue()
		{
			var command = new HelloCommand();

			var commandExecutor2 = this.commandExecutorResolver.Resolve(command);
			await commandExecutor2.ExecuteAsync(command).ConfigureAwait(false);
		}
	}
}

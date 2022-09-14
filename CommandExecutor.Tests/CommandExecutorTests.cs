using CommandExecutor.Abstractions;
using Lamar;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Shouldly;
using IContainer = CommandExecutor.Abstractions.IContainer;

namespace CommandExecutor.Tests;

[TestFixture]
public class CommandExecutorTests
{
	private Container lamarContainer;
	private ICommandExecutorResolver commandExecutorResolver;

	[OneTimeSetUp]
	public void OneTimeSetUp()
	{
		this.lamarContainer = new(cfg =>
		{
			cfg.Scan(s =>
			{
				s.AssemblyContainingType<HelloCommandSimpleExecutor>();
				s.AddAllTypesOf(typeof(ICommandExecutor<>), ServiceLifetime.Scoped);
				s.AddAllTypesOf(typeof(ICommandExecutor<,>), ServiceLifetime.Scoped);
				s.WithDefaultConventions(ServiceLifetime.Scoped);
			});

			cfg.For<IContainer>().Use<ContainerWrapper>().Lifetime = ServiceLifetime.Scoped;
			cfg.For<ICommandExecutorResolver>().Use<CommandExecutorResolver>().Lifetime = ServiceLifetime.Scoped;
		});

		this.commandExecutorResolver = this.lamarContainer.GetInstance<ICommandExecutorResolver>();
	}

	[Test]
	public void AssertConfigurationIsValid()
	{
		this.lamarContainer.AssertConfigurationIsValid();
	}

	[Test]
	public async Task ShouldResolveCommandWithReturnValue()
	{
		var command = new HelloCommand();

		var commandExecutor1 = this.commandExecutorResolver.Resolve<HelloCommand, bool>();

		var result = await commandExecutor1.ExecuteAsync(command);

		result.ShouldBe(true);
	}

	[Test]
	public async Task ShouldResolveCommandWithoutReturnValue()
	{
		var command = new HelloCommand();

		var commandExecutor2 = this.commandExecutorResolver.Resolve<HelloCommand>();

		await commandExecutor2.ExecuteAsync(command);
	}
}
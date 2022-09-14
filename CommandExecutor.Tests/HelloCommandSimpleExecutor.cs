using CommandExecutor.Abstractions;

namespace CommandExecutor.Tests;

public class HelloCommandSimpleExecutor : ICommandExecutor<HelloCommand>
{
	public Task ExecuteAsync(HelloCommand command, CancellationToken token = default)
	{
		Console.WriteLine($"{GetType().Name}: {command.Description}");
		return Task.CompletedTask;
	}
}
using CommandExecutor.Abstractions;

namespace CommandExecutor.Tests;

public class HelloCommandWithReturnExecutor : ICommandExecutor<HelloCommand, bool>
{
	public Task<bool> ExecuteAsync(HelloCommand command, CancellationToken token = default)
	{
		Console.WriteLine($"{GetType().Name}: {command.Description}");
		return Task.FromResult(true);
	}
}
using CommandExecutor.Abstractions;

namespace CommandExecutor.Tests;

public class HelloCommand : ICommand
{
	public string Description => "Hello, world!";
}
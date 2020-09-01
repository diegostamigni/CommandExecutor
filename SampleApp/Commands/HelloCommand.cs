using CommandExecutor.Abstraction;

namespace SampleApp.Commands
{
	public class HelloCommand : ICommand
	{
		public string Description => "Hello, world!";
	}
}
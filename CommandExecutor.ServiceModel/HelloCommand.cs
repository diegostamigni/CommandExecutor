using CommandExecutor.Core.Abstraction;

namespace CommandExecutor.ServiceModel
{
	public class HelloCommand : ICommand
	{
		public string Description => "Hello, world!";
	}
}
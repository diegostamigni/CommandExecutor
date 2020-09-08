using System;
using System.Threading;
using System.Threading.Tasks;
using CommandExecutor.Core.Abstraction;
using CommandExecutor.ServiceModel;

namespace CommandExecutor.Executors
{
	public class HelloCommandSimpleExecutor : ICommandExecutor<HelloCommand>
	{
		public Task ExecuteAsync(HelloCommand command, CancellationToken token = default)
		{
			Console.WriteLine($"{GetType().Name}: {command.Description}");
			return Task.CompletedTask;
		}
	}
}
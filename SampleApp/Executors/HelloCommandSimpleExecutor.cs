using System;
using System.Threading;
using System.Threading.Tasks;
using CommandExecutor.Abstraction;
using SampleApp.Commands;

namespace SampleApp.Executors
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
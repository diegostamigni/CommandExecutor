using System;
using System.Threading;
using System.Threading.Tasks;
using CommandExecutor.Abstraction;
using CommandExecutor.Attributes;
using SampleApp.Commands;

namespace SampleApp.Executors
{
	[SupportsCommand(typeof(HelloCommand))]
	public class HelloCommandExecutor : ICommandExecutor<HelloCommand, bool>
	{
		public Task<bool> ExecuteAsync(HelloCommand command, CancellationToken token = default)
		{
			Console.WriteLine(command.Description);

			return Task.FromResult(true);
		}
	}
}
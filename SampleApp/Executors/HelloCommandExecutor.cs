using System;
using System.Threading;
using System.Threading.Tasks;
using CommandExecutor.Abstraction;
using CommandExecutor.Attributes;
using SampleApp.Commands;

namespace SampleApp.Executors
{
	[SupportsCommand(typeof(HelloCommand))]
	public class HelloCommandExecutor : ICommandExecutor
	{
		public Task ExecuteAsync(ICommand command, CancellationToken token = default)
		{
			throw new NotImplementedException();
		}
	}
}
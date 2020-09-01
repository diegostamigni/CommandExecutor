using System;
using CommandExecutor.Abstraction;

namespace CommandExecutor
{
	public class CommandExecutorResolver : ICommandExecutorResolver
	{
		private readonly Func<string, ICommandExecutor> commandExecutors;

		public CommandExecutorResolver(Func<string, ICommandExecutor> commandExecutors)
		{
			this.commandExecutors = commandExecutors;
		}

		public ICommandExecutor Resolve(ICommand command)
			=> this.commandExecutors(command.GetType().Name);
	}
}
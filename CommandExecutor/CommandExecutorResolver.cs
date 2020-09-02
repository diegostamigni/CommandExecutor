using CommandExecutor.Abstraction;
using Lamar;

namespace CommandExecutor
{
	public class CommandExecutorResolver : ICommandExecutorResolver
	{
		private readonly IContainer container;

		public CommandExecutorResolver(IContainer container)
		{
			this.container = container;
		}

		public ICommandExecutor<TCommand> Resolve<TCommand>(TCommand command) where TCommand : ICommand
			=> this.container.GetInstance<ICommandExecutor<TCommand>>(command.GetType().Name);

		public ICommandExecutor<TCommand, TResult> Resolve<TCommand, TResult>(TCommand command) where TCommand : ICommand
			=> this.container.GetInstance<ICommandExecutor<TCommand, TResult>>(command.GetType().Name);
	}
}
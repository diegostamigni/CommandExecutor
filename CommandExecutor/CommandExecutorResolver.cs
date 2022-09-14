using CommandExecutor.Abstractions;

namespace CommandExecutor;

public class CommandExecutorResolver : ICommandExecutorResolver
{
	private readonly IContainer container;

	public CommandExecutorResolver(IContainer container)
	{
		this.container = container;
	}

	public ICommandExecutor<TCommand> Resolve<TCommand>() where TCommand : ICommand
		=> this.container.GetInstance<ICommandExecutor<TCommand>>();

	public ICommandExecutor<TCommand, TResult> Resolve<TCommand, TResult>() where TCommand : ICommand
		=> this.container.GetInstance<ICommandExecutor<TCommand, TResult>>();
}
namespace CommandExecutor.Abstractions;

public interface ICommandExecutorResolver
{
	ICommandExecutor<TCommand> Resolve<TCommand>() where TCommand : ICommand;

	ICommandExecutor<TCommand, TResult> Resolve<TCommand, TResult>() where TCommand : ICommand;
}
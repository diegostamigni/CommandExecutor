namespace CommandExecutor.Abstraction
{
	public interface ICommandExecutorResolver
	{
		ICommandExecutor<TCommand, TResult> Resolve<TCommand, TResult>(TCommand command) where TCommand : ICommand;
	}
}
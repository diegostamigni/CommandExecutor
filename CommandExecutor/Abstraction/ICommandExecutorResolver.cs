namespace CommandExecutor.Abstraction
{
	public interface ICommandExecutorResolver
	{
		ICommandExecutor<TCommand> Resolve<TCommand>(TCommand command) where TCommand : ICommand;
	}
}
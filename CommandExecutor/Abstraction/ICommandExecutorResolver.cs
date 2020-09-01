namespace CommandExecutor.Abstraction
{
	public interface ICommandExecutorResolver
	{
		ICommandExecutor Resolve(ICommand command);
	}
}
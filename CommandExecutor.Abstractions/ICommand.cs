namespace CommandExecutor.Abstractions;

public interface ICommand
{
}
public interface IContainer
{
	T GetInstance<T>();
}
using CommandExecutor.Abstractions;
using ILamarContainer = Lamar.IContainer;

namespace CommandExecutor.Tests;

sealed internal class ContainerWrapper : IContainer
{
	private readonly ILamarContainer lamarContainer;

	public ContainerWrapper(ILamarContainer lamarContainer) => this.lamarContainer = lamarContainer;

	public T GetInstance<T>() => this.lamarContainer.GetInstance<T>();
}
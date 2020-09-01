using System;

namespace CommandExecutor.Attributes
{
	[AttributeUsage(AttributeTargets.Class)]
	public class SupportsCommandAttribute : Attribute
	{
		public Type CommandType { get; set; }

		public SupportsCommandAttribute(Type commandType)
		{
			this.CommandType = commandType;
		}
	}
}
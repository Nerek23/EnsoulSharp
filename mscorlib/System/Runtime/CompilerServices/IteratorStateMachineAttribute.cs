using System;

namespace System.Runtime.CompilerServices
{
	/// <summary>Indicates whether a method in Visual Basic is marked with the <see langword="Iterator" /> modifier.</summary>
	// Token: 0x020008BE RID: 2238
	[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class IteratorStateMachineAttribute : StateMachineAttribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.CompilerServices.IteratorStateMachineAttribute" /> class.</summary>
		/// <param name="stateMachineType">The type object for the underlying state machine type that's used to implement a state machine method.</param>
		// Token: 0x06005CEA RID: 23786 RVA: 0x00145AB5 File Offset: 0x00143CB5
		[__DynamicallyInvokable]
		public IteratorStateMachineAttribute(Type stateMachineType) : base(stateMachineType)
		{
		}
	}
}

using System;

namespace System.Runtime.CompilerServices
{
	/// <summary>Indicates whether a method is marked with either the Async or async modifier.</summary>
	// Token: 0x020008C0 RID: 2240
	[AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class AsyncStateMachineAttribute : StateMachineAttribute
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.CompilerServices.AsyncStateMachineAttribute" /> class.</summary>
		/// <param name="stateMachineType">The type object for the underlying state machine type that's used to implement a state machine method.</param>
		// Token: 0x06005CED RID: 23789 RVA: 0x00145ABE File Offset: 0x00143CBE
		[__DynamicallyInvokable]
		public AsyncStateMachineAttribute(Type stateMachineType) : base(stateMachineType)
		{
		}
	}
}

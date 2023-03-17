using System;

namespace System.Runtime.CompilerServices
{
	/// <summary>Represents state machines that are generated for asynchronous methods. This type is intended for compiler use only.</summary>
	// Token: 0x020008C6 RID: 2246
	[__DynamicallyInvokable]
	public interface IAsyncStateMachine
	{
		/// <summary>Moves the state machine to its next state.</summary>
		// Token: 0x06005D1B RID: 23835
		[__DynamicallyInvokable]
		void MoveNext();

		/// <summary>Configures the state machine with a heap-allocated replica.</summary>
		/// <param name="stateMachine">The heap-allocated replica.</param>
		// Token: 0x06005D1C RID: 23836
		[__DynamicallyInvokable]
		void SetStateMachine(IAsyncStateMachine stateMachine);
	}
}

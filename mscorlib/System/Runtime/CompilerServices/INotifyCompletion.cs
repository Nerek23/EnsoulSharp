﻿using System;

namespace System.Runtime.CompilerServices
{
	/// <summary>Represents an operation that schedules continuations when it completes.</summary>
	// Token: 0x020008C7 RID: 2247
	[__DynamicallyInvokable]
	public interface INotifyCompletion
	{
		/// <summary>Schedules the continuation action that's invoked when the instance completes.</summary>
		/// <param name="continuation">The action to invoke when the operation completes.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="continuation" /> argument is null (Nothing in Visual Basic).</exception>
		// Token: 0x06005D1D RID: 23837
		[__DynamicallyInvokable]
		void OnCompleted(Action continuation);
	}
}

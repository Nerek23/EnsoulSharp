﻿using System;
using System.Security;

namespace System.Runtime.CompilerServices
{
	/// <summary>Represents an awaiter that schedules continuations when an await operation completes.</summary>
	// Token: 0x020008C8 RID: 2248
	[__DynamicallyInvokable]
	public interface ICriticalNotifyCompletion : INotifyCompletion
	{
		/// <summary>Schedules the continuation action that's invoked when the instance completes.</summary>
		/// <param name="continuation">The action to invoke when the operation completes.</param>
		/// <exception cref="T:System.ArgumentNullException">The <paramref name="continuation" /> argument is null (Nothing in Visual Basic).</exception>
		// Token: 0x06005D1E RID: 23838
		[SecurityCritical]
		[__DynamicallyInvokable]
		void UnsafeOnCompleted(Action continuation);
	}
}

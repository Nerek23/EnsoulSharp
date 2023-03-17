using System;

namespace System.Threading.Tasks
{
	/// <summary>Provides data for the event that is raised when a faulted <see cref="T:System.Threading.Tasks.Task" />'s exception goes unobserved.</summary>
	// Token: 0x0200054C RID: 1356
	[__DynamicallyInvokable]
	public class UnobservedTaskExceptionEventArgs : EventArgs
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Threading.Tasks.UnobservedTaskExceptionEventArgs" /> class with the unobserved exception.</summary>
		/// <param name="exception">The Exception that has gone unobserved.</param>
		// Token: 0x06004100 RID: 16640 RVA: 0x000F1B3B File Offset: 0x000EFD3B
		[__DynamicallyInvokable]
		public UnobservedTaskExceptionEventArgs(AggregateException exception)
		{
			this.m_exception = exception;
		}

		/// <summary>Marks the <see cref="P:System.Threading.Tasks.UnobservedTaskExceptionEventArgs.Exception" /> as "observed," thus preventing it from triggering exception escalation policy which, by default, terminates the process.</summary>
		// Token: 0x06004101 RID: 16641 RVA: 0x000F1B4A File Offset: 0x000EFD4A
		[__DynamicallyInvokable]
		public void SetObserved()
		{
			this.m_observed = true;
		}

		/// <summary>Gets whether this exception has been marked as "observed."</summary>
		/// <returns>true if this exception has been marked as "observed"; otherwise false.</returns>
		// Token: 0x170009B9 RID: 2489
		// (get) Token: 0x06004102 RID: 16642 RVA: 0x000F1B53 File Offset: 0x000EFD53
		[__DynamicallyInvokable]
		public bool Observed
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_observed;
			}
		}

		/// <summary>The Exception that went unobserved.</summary>
		/// <returns>The Exception that went unobserved.</returns>
		// Token: 0x170009BA RID: 2490
		// (get) Token: 0x06004103 RID: 16643 RVA: 0x000F1B5B File Offset: 0x000EFD5B
		[__DynamicallyInvokable]
		public AggregateException Exception
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_exception;
			}
		}

		// Token: 0x04001ABA RID: 6842
		private AggregateException m_exception;

		// Token: 0x04001ABB RID: 6843
		internal bool m_observed;
	}
}

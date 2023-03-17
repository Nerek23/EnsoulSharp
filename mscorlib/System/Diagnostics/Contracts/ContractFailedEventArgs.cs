using System;
using System.Runtime.ConstrainedExecution;
using System.Security;

namespace System.Diagnostics.Contracts
{
	/// <summary>Provides methods and data for the <see cref="E:System.Diagnostics.Contracts.Contract.ContractFailed" /> event.</summary>
	// Token: 0x020003EA RID: 1002
	[__DynamicallyInvokable]
	public sealed class ContractFailedEventArgs : EventArgs
	{
		/// <summary>Provides data for the <see cref="E:System.Diagnostics.Contracts.Contract.ContractFailed" /> event.</summary>
		/// <param name="failureKind">One of the enumeration values that specifies the contract that failed.</param>
		/// <param name="message">The message for the event.</param>
		/// <param name="condition">The condition for the event.</param>
		/// <param name="originalException">The exception that caused the event.</param>
		// Token: 0x060032FB RID: 13051 RVA: 0x000C20DC File Offset: 0x000C02DC
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		[__DynamicallyInvokable]
		public ContractFailedEventArgs(ContractFailureKind failureKind, string message, string condition, Exception originalException)
		{
			this._failureKind = failureKind;
			this._message = message;
			this._condition = condition;
			this._originalException = originalException;
		}

		/// <summary>Gets the message that describes the <see cref="E:System.Diagnostics.Contracts.Contract.ContractFailed" /> event.</summary>
		/// <returns>The message that describes the event.</returns>
		// Token: 0x17000792 RID: 1938
		// (get) Token: 0x060032FC RID: 13052 RVA: 0x000C2101 File Offset: 0x000C0301
		[__DynamicallyInvokable]
		public string Message
		{
			[__DynamicallyInvokable]
			get
			{
				return this._message;
			}
		}

		/// <summary>Gets the condition for the failure of the contract.</summary>
		/// <returns>The condition for the failure.</returns>
		// Token: 0x17000793 RID: 1939
		// (get) Token: 0x060032FD RID: 13053 RVA: 0x000C2109 File Offset: 0x000C0309
		[__DynamicallyInvokable]
		public string Condition
		{
			[__DynamicallyInvokable]
			get
			{
				return this._condition;
			}
		}

		/// <summary>Gets the type of contract that failed.</summary>
		/// <returns>One of the enumeration values that specifies the type of contract that failed.</returns>
		// Token: 0x17000794 RID: 1940
		// (get) Token: 0x060032FE RID: 13054 RVA: 0x000C2111 File Offset: 0x000C0311
		[__DynamicallyInvokable]
		public ContractFailureKind FailureKind
		{
			[__DynamicallyInvokable]
			get
			{
				return this._failureKind;
			}
		}

		/// <summary>Gets the original exception that caused the <see cref="E:System.Diagnostics.Contracts.Contract.ContractFailed" /> event.</summary>
		/// <returns>The exception that caused the event.</returns>
		// Token: 0x17000795 RID: 1941
		// (get) Token: 0x060032FF RID: 13055 RVA: 0x000C2119 File Offset: 0x000C0319
		[__DynamicallyInvokable]
		public Exception OriginalException
		{
			[__DynamicallyInvokable]
			get
			{
				return this._originalException;
			}
		}

		/// <summary>Indicates whether the <see cref="E:System.Diagnostics.Contracts.Contract.ContractFailed" /> event has been handled.</summary>
		/// <returns>
		///   <see langword="true" /> if the event has been handled; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000796 RID: 1942
		// (get) Token: 0x06003300 RID: 13056 RVA: 0x000C2121 File Offset: 0x000C0321
		[__DynamicallyInvokable]
		public bool Handled
		{
			[__DynamicallyInvokable]
			get
			{
				return this._handled;
			}
		}

		/// <summary>Sets the <see cref="P:System.Diagnostics.Contracts.ContractFailedEventArgs.Handled" /> property to <see langword="true" />.</summary>
		// Token: 0x06003301 RID: 13057 RVA: 0x000C2129 File Offset: 0x000C0329
		[SecurityCritical]
		[__DynamicallyInvokable]
		public void SetHandled()
		{
			this._handled = true;
		}

		/// <summary>Indicates whether the code contract escalation policy should be applied.</summary>
		/// <returns>
		///   <see langword="true" /> to apply the escalation policy; otherwise, <see langword="false" />. The default is <see langword="false" />.</returns>
		// Token: 0x17000797 RID: 1943
		// (get) Token: 0x06003302 RID: 13058 RVA: 0x000C2132 File Offset: 0x000C0332
		[__DynamicallyInvokable]
		public bool Unwind
		{
			[__DynamicallyInvokable]
			get
			{
				return this._unwind;
			}
		}

		/// <summary>Sets the <see cref="P:System.Diagnostics.Contracts.ContractFailedEventArgs.Unwind" /> property to <see langword="true" />.</summary>
		// Token: 0x06003303 RID: 13059 RVA: 0x000C213A File Offset: 0x000C033A
		[SecurityCritical]
		[__DynamicallyInvokable]
		public void SetUnwind()
		{
			this._unwind = true;
		}

		// Token: 0x0400165C RID: 5724
		private ContractFailureKind _failureKind;

		// Token: 0x0400165D RID: 5725
		private string _message;

		// Token: 0x0400165E RID: 5726
		private string _condition;

		// Token: 0x0400165F RID: 5727
		private Exception _originalException;

		// Token: 0x04001660 RID: 5728
		private bool _handled;

		// Token: 0x04001661 RID: 5729
		private bool _unwind;

		// Token: 0x04001662 RID: 5730
		internal Exception thrownDuringHandler;
	}
}

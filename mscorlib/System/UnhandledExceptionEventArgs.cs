using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace System
{
	/// <summary>Provides data for the event that is raised when there is an exception that is not handled in any application domain.</summary>
	// Token: 0x02000156 RID: 342
	[ComVisible(true)]
	[Serializable]
	public class UnhandledExceptionEventArgs : EventArgs
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.UnhandledExceptionEventArgs" /> class with the exception object and a common language runtime termination flag.</summary>
		/// <param name="exception">The exception that is not handled.</param>
		/// <param name="isTerminating">
		///   <see langword="true" /> if the runtime is terminating; otherwise, <see langword="false" />.</param>
		// Token: 0x06001566 RID: 5478 RVA: 0x0003EB85 File Offset: 0x0003CD85
		public UnhandledExceptionEventArgs(object exception, bool isTerminating)
		{
			this._Exception = exception;
			this._IsTerminating = isTerminating;
		}

		/// <summary>Gets the unhandled exception object.</summary>
		/// <returns>The unhandled exception object.</returns>
		// Token: 0x17000260 RID: 608
		// (get) Token: 0x06001567 RID: 5479 RVA: 0x0003EB9B File Offset: 0x0003CD9B
		public object ExceptionObject
		{
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			get
			{
				return this._Exception;
			}
		}

		/// <summary>Indicates whether the common language runtime is terminating.</summary>
		/// <returns>
		///   <see langword="true" /> if the runtime is terminating; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000261 RID: 609
		// (get) Token: 0x06001568 RID: 5480 RVA: 0x0003EBA3 File Offset: 0x0003CDA3
		public bool IsTerminating
		{
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			get
			{
				return this._IsTerminating;
			}
		}

		// Token: 0x04000710 RID: 1808
		private object _Exception;

		// Token: 0x04000711 RID: 1809
		private bool _IsTerminating;
	}
}

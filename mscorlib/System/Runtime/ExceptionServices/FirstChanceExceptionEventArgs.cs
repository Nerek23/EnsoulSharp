using System;
using System.Runtime.ConstrainedExecution;

namespace System.Runtime.ExceptionServices
{
	/// <summary>Provides data for the notification event that is raised when a managed exception first occurs, before the common language runtime begins searching for event handlers.</summary>
	// Token: 0x0200077C RID: 1916
	public class FirstChanceExceptionEventArgs : EventArgs
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs" /> class with a specified exception.</summary>
		/// <param name="exception">The exception that was just thrown by managed code, and that will be examined by the <see cref="E:System.AppDomain.UnhandledException" /> event.</param>
		// Token: 0x060053E2 RID: 21474 RVA: 0x00129733 File Offset: 0x00127933
		public FirstChanceExceptionEventArgs(Exception exception)
		{
			this.m_Exception = exception;
		}

		/// <summary>The managed exception object that corresponds to the exception thrown in managed code.</summary>
		/// <returns>The newly thrown exception.</returns>
		// Token: 0x17000DD8 RID: 3544
		// (get) Token: 0x060053E3 RID: 21475 RVA: 0x00129742 File Offset: 0x00127942
		public Exception Exception
		{
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			get
			{
				return this.m_Exception;
			}
		}

		// Token: 0x04002664 RID: 9828
		private Exception m_Exception;
	}
}

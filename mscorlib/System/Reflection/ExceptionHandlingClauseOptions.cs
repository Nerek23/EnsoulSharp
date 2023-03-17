using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Identifies kinds of exception-handling clauses.</summary>
	// Token: 0x020005E4 RID: 1508
	[Flags]
	[ComVisible(true)]
	public enum ExceptionHandlingClauseOptions
	{
		/// <summary>The clause accepts all exceptions that derive from a specified type.</summary>
		// Token: 0x04001D0F RID: 7439
		Clause = 0,
		/// <summary>The clause contains user-specified instructions that determine whether the exception should be ignored (that is, whether normal execution should resume), be handled by the associated handler, or be passed on to the next clause.</summary>
		// Token: 0x04001D10 RID: 7440
		Filter = 1,
		/// <summary>The clause is executed whenever the try block exits, whether through normal control flow or because of an unhandled exception.</summary>
		// Token: 0x04001D11 RID: 7441
		Finally = 2,
		/// <summary>The clause is executed if an exception occurs, but not on completion of normal control flow.</summary>
		// Token: 0x04001D12 RID: 7442
		Fault = 4
	}
}

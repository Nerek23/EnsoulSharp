using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Serialization.Formatters
{
	/// <summary>Logs tracing messages when the .NET Framework serialization infrastructure is compiled.</summary>
	// Token: 0x02000735 RID: 1845
	[SecurityCritical]
	[ComVisible(true)]
	public sealed class InternalRM
	{
		/// <summary>Prints SOAP trace messages.</summary>
		/// <param name="messages">An array of trace messages to print.</param>
		// Token: 0x060051E9 RID: 20969 RVA: 0x0011F14D File Offset: 0x0011D34D
		[Conditional("_LOGGING")]
		public static void InfoSoap(params object[] messages)
		{
		}

		/// <summary>Checks if SOAP tracing is enabled.</summary>
		/// <returns>
		///   <see langword="true" />, if tracing is enabled; otherwise, <see langword="false" />.</returns>
		// Token: 0x060051EA RID: 20970 RVA: 0x0011F14F File Offset: 0x0011D34F
		public static bool SoapCheckEnabled()
		{
			return BCLDebug.CheckEnabled("SOAP");
		}
	}
}

using System;

namespace System.Runtime.ConstrainedExecution
{
	/// <summary>Specifies a reliability contract.</summary>
	// Token: 0x020006FD RID: 1789
	[Serializable]
	public enum Consistency
	{
		/// <summary>In the face of exceptional conditions, the CLR makes no guarantees regarding state consistency; that is, the condition might corrupt the process.</summary>
		// Token: 0x04002375 RID: 9077
		MayCorruptProcess,
		/// <summary>In the face of exceptional conditions, the common language runtime (CLR) makes no guarantees regarding state consistency in the current application domain.</summary>
		// Token: 0x04002376 RID: 9078
		MayCorruptAppDomain,
		/// <summary>In the face of exceptional conditions, the method is guaranteed to limit state corruption to the current instance.</summary>
		// Token: 0x04002377 RID: 9079
		MayCorruptInstance,
		/// <summary>In the face of exceptional conditions, the method is guaranteed not to corrupt state.</summary>
		// Token: 0x04002378 RID: 9080
		WillNotCorruptState
	}
}

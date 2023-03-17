using System;
using System.Runtime.InteropServices;

namespace System.Runtime.Serialization
{
	/// <summary>Defines a set of flags that specifies the source or destination context for the stream during serialization.</summary>
	// Token: 0x02000718 RID: 1816
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum StreamingContextStates
	{
		/// <summary>Specifies that the source or destination context is a different process on the same computer.</summary>
		// Token: 0x040023A9 RID: 9129
		CrossProcess = 1,
		/// <summary>Specifies that the source or destination context is a different computer.</summary>
		// Token: 0x040023AA RID: 9130
		CrossMachine = 2,
		/// <summary>Specifies that the source or destination context is a file. Users can assume that files will last longer than the process that created them and not serialize objects in such a way that deserialization will require accessing any data from the current process.</summary>
		// Token: 0x040023AB RID: 9131
		File = 4,
		/// <summary>Specifies that the source or destination context is a persisted store, which could include databases, files, or other backing stores. Users can assume that persisted data will last longer than the process that created the data and not serialize objects so that deserialization will require accessing any data from the current process.</summary>
		// Token: 0x040023AC RID: 9132
		Persistence = 8,
		/// <summary>Specifies that the data is remoted to a context in an unknown location. Users cannot make any assumptions whether this is on the same computer.</summary>
		// Token: 0x040023AD RID: 9133
		Remoting = 16,
		/// <summary>Specifies that the serialization context is unknown.</summary>
		// Token: 0x040023AE RID: 9134
		Other = 32,
		/// <summary>Specifies that the object graph is being cloned. Users can assume that the cloned graph will continue to exist within the same process and be safe to access handles or other references to unmanaged resources.</summary>
		// Token: 0x040023AF RID: 9135
		Clone = 64,
		/// <summary>Specifies that the source or destination context is a different AppDomain. (For a description of AppDomains, see Application Domains).</summary>
		// Token: 0x040023B0 RID: 9136
		CrossAppDomain = 128,
		/// <summary>Specifies that the serialized data can be transmitted to or received from any of the other contexts.</summary>
		// Token: 0x040023B1 RID: 9137
		All = 255
	}
}

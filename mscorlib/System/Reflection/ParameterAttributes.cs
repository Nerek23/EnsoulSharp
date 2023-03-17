using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Defines the attributes that can be associated with a parameter. These are defined in CorHdr.h.</summary>
	// Token: 0x020005E8 RID: 1512
	[Flags]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum ParameterAttributes
	{
		/// <summary>Specifies that there is no parameter attribute.</summary>
		// Token: 0x04001D26 RID: 7462
		[__DynamicallyInvokable]
		None = 0,
		/// <summary>Specifies that the parameter is an input parameter.</summary>
		// Token: 0x04001D27 RID: 7463
		[__DynamicallyInvokable]
		In = 1,
		/// <summary>Specifies that the parameter is an output parameter.</summary>
		// Token: 0x04001D28 RID: 7464
		[__DynamicallyInvokable]
		Out = 2,
		/// <summary>Specifies that the parameter is a locale identifier (lcid).</summary>
		// Token: 0x04001D29 RID: 7465
		[__DynamicallyInvokable]
		Lcid = 4,
		/// <summary>Specifies that the parameter is a return value.</summary>
		// Token: 0x04001D2A RID: 7466
		[__DynamicallyInvokable]
		Retval = 8,
		/// <summary>Specifies that the parameter is optional.</summary>
		// Token: 0x04001D2B RID: 7467
		[__DynamicallyInvokable]
		Optional = 16,
		/// <summary>Specifies that the parameter is reserved.</summary>
		// Token: 0x04001D2C RID: 7468
		ReservedMask = 61440,
		/// <summary>Specifies that the parameter has a default value.</summary>
		// Token: 0x04001D2D RID: 7469
		[__DynamicallyInvokable]
		HasDefault = 4096,
		/// <summary>Specifies that the parameter has field marshaling information.</summary>
		// Token: 0x04001D2E RID: 7470
		[__DynamicallyInvokable]
		HasFieldMarshal = 8192,
		/// <summary>Reserved.</summary>
		// Token: 0x04001D2F RID: 7471
		Reserved3 = 16384,
		/// <summary>Reserved.</summary>
		// Token: 0x04001D30 RID: 7472
		Reserved4 = 32768
	}
}

using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Specifies the attributes of an event.</summary>
	// Token: 0x020005B4 RID: 1460
	[Flags]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum EventAttributes
	{
		/// <summary>Specifies that the event has no attributes.</summary>
		// Token: 0x04001BDA RID: 7130
		[__DynamicallyInvokable]
		None = 0,
		/// <summary>Specifies that the event is special in a way described by the name.</summary>
		// Token: 0x04001BDB RID: 7131
		[__DynamicallyInvokable]
		SpecialName = 512,
		/// <summary>Specifies a reserved flag for common language runtime use only.</summary>
		// Token: 0x04001BDC RID: 7132
		ReservedMask = 1024,
		/// <summary>Specifies that the common language runtime should check name encoding.</summary>
		// Token: 0x04001BDD RID: 7133
		[__DynamicallyInvokable]
		RTSpecialName = 1024
	}
}

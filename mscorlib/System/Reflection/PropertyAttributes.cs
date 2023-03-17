using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Defines the attributes that can be associated with a property. These attribute values are defined in corhdr.h.</summary>
	// Token: 0x020005ED RID: 1517
	[Flags]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum PropertyAttributes
	{
		/// <summary>Specifies that no attributes are associated with a property.</summary>
		// Token: 0x04001D48 RID: 7496
		[__DynamicallyInvokable]
		None = 0,
		/// <summary>Specifies that the property is special, with the name describing how the property is special.</summary>
		// Token: 0x04001D49 RID: 7497
		[__DynamicallyInvokable]
		SpecialName = 512,
		/// <summary>Specifies a flag reserved for runtime use only.</summary>
		// Token: 0x04001D4A RID: 7498
		ReservedMask = 62464,
		/// <summary>Specifies that the metadata internal APIs check the name encoding.</summary>
		// Token: 0x04001D4B RID: 7499
		[__DynamicallyInvokable]
		RTSpecialName = 1024,
		/// <summary>Specifies that the property has a default value.</summary>
		// Token: 0x04001D4C RID: 7500
		[__DynamicallyInvokable]
		HasDefault = 4096,
		/// <summary>Reserved.</summary>
		// Token: 0x04001D4D RID: 7501
		Reserved2 = 8192,
		/// <summary>Reserved.</summary>
		// Token: 0x04001D4E RID: 7502
		Reserved3 = 16384,
		/// <summary>Reserved.</summary>
		// Token: 0x04001D4F RID: 7503
		Reserved4 = 32768
	}
}

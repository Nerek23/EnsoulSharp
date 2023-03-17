using System;
using System.Runtime.InteropServices;

namespace System.Reflection.Emit
{
	/// <summary>Specifies one of two factors that determine the memory alignment of fields when a type is marshaled.</summary>
	// Token: 0x02000635 RID: 1589
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public enum PackingSize
	{
		/// <summary>The packing size is not specified.</summary>
		// Token: 0x040020EE RID: 8430
		[__DynamicallyInvokable]
		Unspecified,
		/// <summary>The packing size is 1 byte.</summary>
		// Token: 0x040020EF RID: 8431
		[__DynamicallyInvokable]
		Size1,
		/// <summary>The packing size is 2 bytes.</summary>
		// Token: 0x040020F0 RID: 8432
		[__DynamicallyInvokable]
		Size2,
		/// <summary>The packing size is 4 bytes.</summary>
		// Token: 0x040020F1 RID: 8433
		[__DynamicallyInvokable]
		Size4 = 4,
		/// <summary>The packing size is 8 bytes.</summary>
		// Token: 0x040020F2 RID: 8434
		[__DynamicallyInvokable]
		Size8 = 8,
		/// <summary>The packing size is 16 bytes.</summary>
		// Token: 0x040020F3 RID: 8435
		[__DynamicallyInvokable]
		Size16 = 16,
		/// <summary>The packing size is 32 bytes.</summary>
		// Token: 0x040020F4 RID: 8436
		[__DynamicallyInvokable]
		Size32 = 32,
		/// <summary>The packing size is 64 bytes.</summary>
		// Token: 0x040020F5 RID: 8437
		[__DynamicallyInvokable]
		Size64 = 64,
		/// <summary>The packing size is 128 bytes.</summary>
		// Token: 0x040020F6 RID: 8438
		[__DynamicallyInvokable]
		Size128 = 128
	}
}

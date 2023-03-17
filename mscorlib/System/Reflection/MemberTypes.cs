using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	/// <summary>Marks each type of member that is defined as a derived class of <see cref="T:System.Reflection.MemberInfo" />.</summary>
	// Token: 0x020005D6 RID: 1494
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum MemberTypes
	{
		/// <summary>Specifies that the member is a constructor</summary>
		// Token: 0x04001CA3 RID: 7331
		Constructor = 1,
		/// <summary>Specifies that the member is an event.</summary>
		// Token: 0x04001CA4 RID: 7332
		Event = 2,
		/// <summary>Specifies that the member is a field.</summary>
		// Token: 0x04001CA5 RID: 7333
		Field = 4,
		/// <summary>Specifies that the member is a method.</summary>
		// Token: 0x04001CA6 RID: 7334
		Method = 8,
		/// <summary>Specifies that the member is a property.</summary>
		// Token: 0x04001CA7 RID: 7335
		Property = 16,
		/// <summary>Specifies that the member is a type.</summary>
		// Token: 0x04001CA8 RID: 7336
		TypeInfo = 32,
		/// <summary>Specifies that the member is a custom member type.</summary>
		// Token: 0x04001CA9 RID: 7337
		Custom = 64,
		/// <summary>Specifies that the member is a nested type.</summary>
		// Token: 0x04001CAA RID: 7338
		NestedType = 128,
		/// <summary>Specifies all member types.</summary>
		// Token: 0x04001CAB RID: 7339
		All = 191
	}
}

using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x020000B8 RID: 184
	[Guid("14885CC9-BAB0-4f90-B6ED-5C366A2CD03D")]
	public class NumberSubstitution : ComObject
	{
		// Token: 0x060003B1 RID: 945 RVA: 0x0000D41F File Offset: 0x0000B61F
		public NumberSubstitution(Factory factory, NumberSubstitutionMethod substitutionMethod, string localeName, bool ignoreUserOverride)
		{
			factory.CreateNumberSubstitution(substitutionMethod, localeName, ignoreUserOverride, this);
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x00002A7F File Offset: 0x00000C7F
		public NumberSubstitution(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x0000D437 File Offset: 0x0000B637
		public new static explicit operator NumberSubstitution(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new NumberSubstitution(nativePtr);
			}
			return null;
		}
	}
}

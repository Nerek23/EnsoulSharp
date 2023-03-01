using System;
using System.Collections.Generic;

namespace SharpDX.Collections
{
	// Token: 0x020000AF RID: 175
	internal static class EqualityComparer
	{
		// Token: 0x0400123E RID: 4670
		public static readonly IEqualityComparer<IntPtr> DefaultIntPtr = new EqualityComparer.IntPtrComparer();

		// Token: 0x020000B0 RID: 176
		internal class IntPtrComparer : EqualityComparer<IntPtr>
		{
			// Token: 0x0600036A RID: 874 RVA: 0x0000A016 File Offset: 0x00008216
			public override bool Equals(IntPtr x, IntPtr y)
			{
				return x == y;
			}

			// Token: 0x0600036B RID: 875 RVA: 0x0000A01F File Offset: 0x0000821F
			public override int GetHashCode(IntPtr obj)
			{
				return obj.GetHashCode();
			}
		}
	}
}

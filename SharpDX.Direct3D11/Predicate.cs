using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D11
{
	// Token: 0x02000034 RID: 52
	[Guid("9eb576dd-9f77-4d86-81aa-8bab5fe490e2")]
	public class Predicate : Query
	{
		// Token: 0x06000287 RID: 647 RVA: 0x0000AD0A File Offset: 0x00008F0A
		public Predicate(Device device, QueryDescription description) : base(IntPtr.Zero)
		{
			device.CreatePredicate(description, this);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000AD1F File Offset: 0x00008F1F
		public Predicate(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000289 RID: 649 RVA: 0x0000AD28 File Offset: 0x00008F28
		public new static explicit operator Predicate(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Predicate(nativePtr);
			}
			return null;
		}
	}
}

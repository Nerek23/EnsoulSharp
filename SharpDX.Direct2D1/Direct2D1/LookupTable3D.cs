using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000202 RID: 514
	[Guid("53dd9855-a3b0-4d5b-82e1-26e25c5e5797")]
	public class LookupTable3D : Resource
	{
		// Token: 0x06000AFE RID: 2814 RVA: 0x0001F7B1 File Offset: 0x0001D9B1
		public LookupTable3D(DeviceContext2 context2, BufferPrecision precision, int[] extents, byte[] data, int dataCount, int[] strides) : this(IntPtr.Zero)
		{
			context2.CreateLookupTable3D(precision, extents, data, dataCount, strides, this);
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x00016258 File Offset: 0x00014458
		public LookupTable3D(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x0001F7CD File Offset: 0x0001D9CD
		public new static explicit operator LookupTable3D(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new LookupTable3D(nativePtr);
			}
			return null;
		}
	}
}

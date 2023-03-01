using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000300 RID: 768
	[Guid("84ab595a-fc81-4546-bacd-e8ef4d8abe7a")]
	public class EffectContext1 : EffectContext
	{
		// Token: 0x06000D90 RID: 3472 RVA: 0x0002592D File Offset: 0x00023B2D
		public EffectContext1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000D91 RID: 3473 RVA: 0x00025936 File Offset: 0x00023B36
		public new static explicit operator EffectContext1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new EffectContext1(nativePtr);
			}
			return null;
		}

		// Token: 0x06000D92 RID: 3474 RVA: 0x00025950 File Offset: 0x00023B50
		public unsafe void CreateLookupTable3D(BufferPrecision precision, int[] extents, byte[] data, int dataCount, int[] strides, out LookupTable3D lookupTable)
		{
			IntPtr zero = IntPtr.Zero;
			Result result;
			fixed (int[] array = strides)
			{
				void* ptr;
				if (strides == null || array.Length == 0)
				{
					ptr = null;
				}
				else
				{
					ptr = (void*)(&array[0]);
				}
				fixed (byte[] array2 = data)
				{
					void* ptr2;
					if (data == null || array2.Length == 0)
					{
						ptr2 = null;
					}
					else
					{
						ptr2 = (void*)(&array2[0]);
					}
					fixed (int[] array3 = extents)
					{
						void* ptr3;
						if (extents == null || array3.Length == 0)
						{
							ptr3 = null;
						}
						else
						{
							ptr3 = (void*)(&array3[0]);
						}
						result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, precision, ptr3, ptr2, dataCount, ptr, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)24 * (IntPtr)sizeof(void*)));
					}
				}
			}
			if (zero != IntPtr.Zero)
			{
				lookupTable = new LookupTable3D(zero);
			}
			else
			{
				lookupTable = null;
			}
			result.CheckError();
		}
	}
}

using System;
using System.Runtime.InteropServices;

namespace SharpDX.DXGI
{
	// Token: 0x02000026 RID: 38
	[Guid("aba496dd-b617-4cb8-a866-bc44d7eb1fa2")]
	public class Surface2 : Surface1
	{
		// Token: 0x060000FE RID: 254 RVA: 0x00004E09 File Offset: 0x00003009
		public Surface2(Resource1 resource, int index) : base(IntPtr.Zero)
		{
			resource.CreateSubresourceSurface(index, this);
		}

		// Token: 0x060000FF RID: 255 RVA: 0x00004E1E File Offset: 0x0000301E
		public Surface2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000100 RID: 256 RVA: 0x00004E27 File Offset: 0x00003027
		public new static explicit operator Surface2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Surface2(nativePtr);
			}
			return null;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00004E40 File Offset: 0x00003040
		public unsafe void GetResource(Guid riid, out IntPtr parentResourceOut, out int subresourceIndexRef)
		{
			Result result;
			fixed (int* ptr = &subresourceIndexRef)
			{
				void* ptr2 = (void*)ptr;
				fixed (IntPtr* ptr3 = &parentResourceOut)
				{
					void* ptr4 = (void*)ptr3;
					result = calli(System.Int32(System.Void*,System.Void*,System.Void*,System.Void*), this._nativePointer, &riid, ptr4, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}
	}
}

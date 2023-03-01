using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Win32;

namespace SharpDX.DXGI
{
	// Token: 0x02000022 RID: 34
	[Guid("30961379-4609-4a41-998e-54fe567ee0c1")]
	public class Resource1 : Resource
	{
		// Token: 0x060000E8 RID: 232 RVA: 0x00004A75 File Offset: 0x00002C75
		public IntPtr CreateSharedHandle(string name, SharedResourceFlags dwAccess, SecurityAttributes? attributesRef = null)
		{
			return this.CreateSharedHandle(attributesRef, dwAccess, name);
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00004A80 File Offset: 0x00002C80
		public Resource1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060000EA RID: 234 RVA: 0x00004A89 File Offset: 0x00002C89
		public new static explicit operator Resource1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Resource1(nativePtr);
			}
			return null;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00004AA0 File Offset: 0x00002CA0
		internal unsafe void CreateSubresourceSurface(int index, Surface2 surfaceOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Void*), this._nativePointer, index, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)12 * (IntPtr)sizeof(void*)));
			surfaceOut.NativePointer = zero;
			result.CheckError();
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00004AEC File Offset: 0x00002CEC
		internal unsafe IntPtr CreateSharedHandle(SecurityAttributes? attributesRef, SharedResourceFlags dwAccess, string lpName)
		{
			SecurityAttributes value;
			if (attributesRef != null)
			{
				value = attributesRef.Value;
			}
			IntPtr result2;
			Result result;
			fixed (string text = lpName)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, (attributesRef == null) ? null : (&value), dwAccess, ptr, &result2, *(*(IntPtr*)this._nativePointer + (IntPtr)13 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
			return result2;
		}
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.Direct3D11
{
	// Token: 0x020000C2 RID: 194
	[Guid("b2daad8b-03d4-4dbf-95eb-32ab4b63d0ab")]
	public class UserDefinedAnnotation : ComObject
	{
		// Token: 0x060003CF RID: 975 RVA: 0x0000383E File Offset: 0x00001A3E
		public UserDefinedAnnotation(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x0000EFAB File Offset: 0x0000D1AB
		public new static explicit operator UserDefinedAnnotation(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new UserDefinedAnnotation(nativePtr);
			}
			return null;
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060003D1 RID: 977 RVA: 0x0000EFC2 File Offset: 0x0000D1C2
		public RawBool Status
		{
			get
			{
				return this.GetStatus();
			}
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x0000EFCC File Offset: 0x0000D1CC
		public unsafe int BeginEvent(string name)
		{
			int result;
			fixed (string text = name)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			}
			return result;
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00009948 File Offset: 0x00007B48
		public unsafe int EndEvent()
		{
			return calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x0000F00C File Offset: 0x0000D20C
		public unsafe void SetMarker(string name)
		{
			fixed (string text = name)
			{
				char* ptr = text;
				if (ptr != null)
				{
					ptr += RuntimeHelpers.OffsetToStringData / 2;
				}
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x0000EA03 File Offset: 0x0000CC03
		internal unsafe RawBool GetStatus()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
		}
	}
}

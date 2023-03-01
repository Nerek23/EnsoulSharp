using System;
using System.Runtime.InteropServices;

namespace SharpDX.WIC
{
	// Token: 0x0200006E RID: 110
	[Guid("DC2BB46D-3F07-481E-8625-220C4AEDBB33")]
	internal class EnumMetadataItem : ComObject
	{
		// Token: 0x06000230 RID: 560 RVA: 0x00002A7F File Offset: 0x00000C7F
		public EnumMetadataItem(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000231 RID: 561 RVA: 0x0000914C File Offset: 0x0000734C
		public new static explicit operator EnumMetadataItem(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new EnumMetadataItem(nativePtr);
			}
			return null;
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00009164 File Offset: 0x00007364
		public unsafe void Skip(int celt)
		{
			calli(System.Int32(System.Void*,System.Int32), this._nativePointer, celt, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000233 RID: 563 RVA: 0x0000919C File Offset: 0x0000739C
		public unsafe void Reset()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x06000234 RID: 564 RVA: 0x000091D4 File Offset: 0x000073D4
		public unsafe void Clone(out EnumMetadataItem enumMetadataItemOut)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				enumMetadataItemOut = new EnumMetadataItem(zero);
			}
			else
			{
				enumMetadataItemOut = null;
			}
			result.CheckError();
		}
	}
}

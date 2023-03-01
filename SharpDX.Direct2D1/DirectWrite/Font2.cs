using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000129 RID: 297
	[Guid("29748ed6-8c9c-4a6a-be0b-d912e8538944")]
	public class Font2 : Font1
	{
		// Token: 0x06000534 RID: 1332 RVA: 0x00010E09 File Offset: 0x0000F009
		public Font2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x00010E12 File Offset: 0x0000F012
		public new static explicit operator Font2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Font2(nativePtr);
			}
			return null;
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000536 RID: 1334 RVA: 0x00010E29 File Offset: 0x0000F029
		public RawBool IsColorFont
		{
			get
			{
				return this.IsColorFont_();
			}
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x00010E31 File Offset: 0x0000F031
		internal unsafe RawBool IsColorFont_()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)18 * (IntPtr)sizeof(void*)));
		}
	}
}

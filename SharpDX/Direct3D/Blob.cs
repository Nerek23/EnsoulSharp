using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct3D
{
	// Token: 0x0200009D RID: 157
	[Guid("8BA5FB08-5195-40e2-AC58-0D989C3A0102")]
	public class Blob : ComObject
	{
		// Token: 0x06000335 RID: 821 RVA: 0x000096AB File Offset: 0x000078AB
		public static implicit operator DataPointer(Blob blob)
		{
			return new DataPointer(blob.BufferPointer, blob.BufferSize);
		}

		// Token: 0x06000336 RID: 822 RVA: 0x00006A87 File Offset: 0x00004C87
		public Blob(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000337 RID: 823 RVA: 0x000096C3 File Offset: 0x000078C3
		public new static explicit operator Blob(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Blob(nativePtr);
			}
			return null;
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000338 RID: 824 RVA: 0x000096DA File Offset: 0x000078DA
		public IntPtr BufferPointer
		{
			get
			{
				return this.GetBufferPointer();
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000339 RID: 825 RVA: 0x000096E2 File Offset: 0x000078E2
		public PointerSize BufferSize
		{
			get
			{
				return this.GetBufferSize();
			}
		}

		// Token: 0x0600033A RID: 826 RVA: 0x000096EA File Offset: 0x000078EA
		internal unsafe IntPtr GetBufferPointer()
		{
			return calli(System.IntPtr(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
		}

		// Token: 0x0600033B RID: 827 RVA: 0x00009709 File Offset: 0x00007909
		internal unsafe PointerSize GetBufferSize()
		{
			return calli(System.Void*(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
		}
	}
}

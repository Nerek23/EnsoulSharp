using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000083 RID: 131
	[Guid("d31fbe17-f157-41a2-8d24-cb779e0560e8")]
	public class ColorGlyphRunEnumerator : ComObject
	{
		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000280 RID: 640 RVA: 0x0000A198 File Offset: 0x00008398
		public unsafe ColorGlyphRun CurrentRun
		{
			get
			{
				IntPtr value;
				this.GetCurrentRun(out value);
				ColorGlyphRun result = default(ColorGlyphRun);
				result.__MarshalFrom(ref *(ColorGlyphRun.__Native*)((void*)value));
				return result;
			}
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00002A7F File Offset: 0x00000C7F
		public ColorGlyphRunEnumerator(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000282 RID: 642 RVA: 0x0000A1C3 File Offset: 0x000083C3
		public new static explicit operator ColorGlyphRunEnumerator(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ColorGlyphRunEnumerator(nativePtr);
			}
			return null;
		}

		// Token: 0x06000283 RID: 643 RVA: 0x0000A1DC File Offset: 0x000083DC
		public unsafe void MoveNext(out RawBool hasRun)
		{
			hasRun = default(RawBool);
			Result result;
			fixed (RawBool* ptr = &hasRun)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)3 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x06000284 RID: 644 RVA: 0x0000A224 File Offset: 0x00008424
		internal unsafe void GetCurrentRun(out IntPtr colorGlyphRun)
		{
			Result result;
			fixed (IntPtr* ptr = &colorGlyphRun)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}

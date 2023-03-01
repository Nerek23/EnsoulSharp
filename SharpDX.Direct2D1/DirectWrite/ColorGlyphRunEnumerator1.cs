using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000084 RID: 132
	[Guid("7C5F86DA-C7A1-4F05-B8E1-55A179FE5A35")]
	public class ColorGlyphRunEnumerator1 : ColorGlyphRunEnumerator
	{
		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000285 RID: 645 RVA: 0x0000A264 File Offset: 0x00008464
		public new unsafe ColorGlyphRun1 CurrentRun
		{
			get
			{
				IntPtr value;
				this.GetCurrentRun(out value);
				ColorGlyphRun1 result = default(ColorGlyphRun1);
				result.__MarshalFrom(ref *(ColorGlyphRun1.__Native*)((void*)value));
				return result;
			}
		}

		// Token: 0x06000286 RID: 646 RVA: 0x0000A28F File Offset: 0x0000848F
		public ColorGlyphRunEnumerator1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000287 RID: 647 RVA: 0x0000A298 File Offset: 0x00008498
		public new static explicit operator ColorGlyphRunEnumerator1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new ColorGlyphRunEnumerator1(nativePtr);
			}
			return null;
		}

		// Token: 0x06000288 RID: 648 RVA: 0x0000A2B0 File Offset: 0x000084B0
		internal new unsafe void GetCurrentRun(out IntPtr colorGlyphRun)
		{
			Result result;
			fixed (IntPtr* ptr = &colorGlyphRun)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}

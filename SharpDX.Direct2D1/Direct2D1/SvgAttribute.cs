using System;
using System.Runtime.InteropServices;

namespace SharpDX.Direct2D1
{
	// Token: 0x02000231 RID: 561
	[Guid("c9cdb0dd-f8c9-4e70-b7c2-301c80292c5e")]
	public class SvgAttribute : Resource
	{
		// Token: 0x06000CB9 RID: 3257 RVA: 0x00023394 File Offset: 0x00021594
		public SvgAttribute Clone()
		{
			SvgAttribute result;
			this.Clone(out result);
			return result;
		}

		// Token: 0x06000CBA RID: 3258 RVA: 0x00016258 File Offset: 0x00014458
		public SvgAttribute(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000CBB RID: 3259 RVA: 0x000233AA File Offset: 0x000215AA
		public new static explicit operator SvgAttribute(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new SvgAttribute(nativePtr);
			}
			return null;
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000CBC RID: 3260 RVA: 0x000233C4 File Offset: 0x000215C4
		public SvgElement Element
		{
			get
			{
				SvgElement result;
				this.GetElement(out result);
				return result;
			}
		}

		// Token: 0x06000CBD RID: 3261 RVA: 0x000233DC File Offset: 0x000215DC
		internal unsafe void GetElement(out SvgElement element)
		{
			IntPtr zero = IntPtr.Zero;
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)4 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				element = new SvgElement(zero);
				return;
			}
			element = null;
		}

		// Token: 0x06000CBE RID: 3262 RVA: 0x00023428 File Offset: 0x00021628
		internal unsafe void Clone(out SvgAttribute attribute)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)5 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				attribute = new SvgAttribute(zero);
			}
			else
			{
				attribute = null;
			}
			result.CheckError();
		}
	}
}

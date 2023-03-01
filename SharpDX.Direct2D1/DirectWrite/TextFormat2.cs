using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000147 RID: 327
	[Guid("F67E0EDD-9E3D-4ECC-8C32-4183253DFE70")]
	public class TextFormat2 : TextFormat1
	{
		// Token: 0x06000625 RID: 1573 RVA: 0x00014063 File Offset: 0x00012263
		public TextFormat2(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x0001406C File Offset: 0x0001226C
		public new static explicit operator TextFormat2(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new TextFormat2(nativePtr);
			}
			return null;
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000627 RID: 1575 RVA: 0x00014084 File Offset: 0x00012284
		// (set) Token: 0x06000628 RID: 1576 RVA: 0x0001409A File Offset: 0x0001229A
		public LineSpacing LineSpacing
		{
			get
			{
				LineSpacing result;
				this.GetLineSpacing(out result);
				return result;
			}
			set
			{
				this.SetLineSpacing(ref value);
			}
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x000140A4 File Offset: 0x000122A4
		internal unsafe void SetLineSpacing(ref LineSpacing lineSpacingOptions)
		{
			Result result;
			fixed (LineSpacing* ptr = &lineSpacingOptions)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)36 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x000140E8 File Offset: 0x000122E8
		internal unsafe void GetLineSpacing(out LineSpacing lineSpacingOptions)
		{
			lineSpacingOptions = default(LineSpacing);
			Result result;
			fixed (LineSpacing* ptr = &lineSpacingOptions)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)37 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}
	}
}

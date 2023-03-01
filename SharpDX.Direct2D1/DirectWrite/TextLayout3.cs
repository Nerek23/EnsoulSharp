using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x0200014A RID: 330
	[Guid("07DDCD52-020E-4DE8-AC33-6C953D83F92D")]
	public class TextLayout3 : TextLayout2
	{
		// Token: 0x06000645 RID: 1605 RVA: 0x0001452B File Offset: 0x0001272B
		public TextLayout3(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x00014534 File Offset: 0x00012734
		public new static explicit operator TextLayout3(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new TextLayout3(nativePtr);
			}
			return null;
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000647 RID: 1607 RVA: 0x0001454C File Offset: 0x0001274C
		// (set) Token: 0x06000648 RID: 1608 RVA: 0x00014562 File Offset: 0x00012762
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

		// Token: 0x06000649 RID: 1609 RVA: 0x0001456C File Offset: 0x0001276C
		public unsafe void InvalidateLayout()
		{
			calli(System.Int32(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)80 * (IntPtr)sizeof(void*))).CheckError();
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x000145A4 File Offset: 0x000127A4
		internal unsafe void SetLineSpacing(ref LineSpacing lineSpacingOptions)
		{
			Result result;
			fixed (LineSpacing* ptr = &lineSpacingOptions)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)81 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x000145E8 File Offset: 0x000127E8
		internal unsafe void GetLineSpacing(out LineSpacing lineSpacingOptions)
		{
			lineSpacingOptions = default(LineSpacing);
			Result result;
			fixed (LineSpacing* ptr = &lineSpacingOptions)
			{
				void* ptr2 = (void*)ptr;
				result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)82 * (IntPtr)sizeof(void*)));
			}
			result.CheckError();
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x00014630 File Offset: 0x00012830
		public unsafe void GetLineMetrics(LineMetrics1[] lineMetrics, int maxLineCount, out int actualLineCount)
		{
			Result result;
			fixed (int* ptr = &actualLineCount)
			{
				void* ptr2 = (void*)ptr;
				fixed (LineMetrics1[] array = lineMetrics)
				{
					void* ptr3;
					if (lineMetrics == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					result = calli(System.Int32(System.Void*,System.Void*,System.Int32,System.Void*), this._nativePointer, ptr3, maxLineCount, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)83 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}
	}
}

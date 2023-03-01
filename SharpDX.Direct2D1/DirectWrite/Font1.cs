using System;
using System.Runtime.InteropServices;
using SharpDX.Mathematics.Interop;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000128 RID: 296
	[Guid("acd16696-8c14-4f5d-877e-fe3fc1d32738")]
	public class Font1 : Font
	{
		// Token: 0x0600052B RID: 1323 RVA: 0x00010CAC File Offset: 0x0000EEAC
		public Font1(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x00010CB5 File Offset: 0x0000EEB5
		public new static explicit operator Font1(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new Font1(nativePtr);
			}
			return null;
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x0600052D RID: 1325 RVA: 0x00010CCC File Offset: 0x0000EECC
		public new FontMetrics1 Metrics
		{
			get
			{
				FontMetrics1 result;
				this.GetMetrics(out result);
				return result;
			}
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x0600052E RID: 1326 RVA: 0x00010CE4 File Offset: 0x0000EEE4
		public Panose Panose
		{
			get
			{
				Panose result;
				this.GetPanose(out result);
				return result;
			}
		}

		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x0600052F RID: 1327 RVA: 0x00010CFA File Offset: 0x0000EEFA
		public RawBool IsMonospacedFont
		{
			get
			{
				return this.IsMonospacedFont_();
			}
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x00010D04 File Offset: 0x0000EF04
		internal unsafe void GetMetrics(out FontMetrics1 fontMetrics)
		{
			fontMetrics = default(FontMetrics1);
			fixed (FontMetrics1* ptr = &fontMetrics)
			{
				void* ptr2 = (void*)ptr;
				calli(System.Void(System.Void*,System.Void*), this._nativePointer, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)14 * (IntPtr)sizeof(void*)));
			}
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x00010D40 File Offset: 0x0000EF40
		internal unsafe void GetPanose(out Panose anoseRef)
		{
			Panose.__Native _Native = default(Panose.__Native);
			anoseRef = default(Panose);
			calli(System.Void(System.Void*,System.Void*), this._nativePointer, &_Native, *(*(IntPtr*)this._nativePointer + (IntPtr)15 * (IntPtr)sizeof(void*)));
			anoseRef.__MarshalFrom(ref _Native);
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x00010D88 File Offset: 0x0000EF88
		public unsafe void GetUnicodeRanges(int maxRangeCount, UnicodeRange[] unicodeRanges, out int actualRangeCount)
		{
			Result result;
			fixed (int* ptr = &actualRangeCount)
			{
				void* ptr2 = (void*)ptr;
				fixed (UnicodeRange[] array = unicodeRanges)
				{
					void* ptr3;
					if (unicodeRanges == null || array.Length == 0)
					{
						ptr3 = null;
					}
					else
					{
						ptr3 = (void*)(&array[0]);
					}
					result = calli(System.Int32(System.Void*,System.Int32,System.Void*,System.Void*), this._nativePointer, maxRangeCount, ptr3, ptr2, *(*(IntPtr*)this._nativePointer + (IntPtr)16 * (IntPtr)sizeof(void*)));
				}
			}
			result.CheckError();
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x00010DE9 File Offset: 0x0000EFE9
		internal unsafe RawBool IsMonospacedFont_()
		{
			return calli(SharpDX.Mathematics.Interop.RawBool(System.Void*), this._nativePointer, *(*(IntPtr*)this._nativePointer + (IntPtr)17 * (IntPtr)sizeof(void*)));
		}
	}
}

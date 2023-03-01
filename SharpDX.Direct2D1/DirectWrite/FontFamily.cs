using System;
using System.Runtime.InteropServices;

namespace SharpDX.DirectWrite
{
	// Token: 0x02000135 RID: 309
	[Guid("da20d8ef-812a-4c43-9802-62ec4abd7add")]
	public class FontFamily : FontList
	{
		// Token: 0x060005AA RID: 1450 RVA: 0x00012432 File Offset: 0x00010632
		public FontFamily(IntPtr nativePtr) : base(nativePtr)
		{
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x0001243B File Offset: 0x0001063B
		public new static explicit operator FontFamily(IntPtr nativePtr)
		{
			if (!(nativePtr == IntPtr.Zero))
			{
				return new FontFamily(nativePtr);
			}
			return null;
		}

		// Token: 0x170000DD RID: 221
		// (get) Token: 0x060005AC RID: 1452 RVA: 0x00012454 File Offset: 0x00010654
		public LocalizedStrings FamilyNames
		{
			get
			{
				LocalizedStrings result;
				this.GetFamilyNames(out result);
				return result;
			}
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x0001246C File Offset: 0x0001066C
		internal unsafe void GetFamilyNames(out LocalizedStrings names)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Void*), this._nativePointer, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)6 * (IntPtr)sizeof(void*)));
			if (zero != IntPtr.Zero)
			{
				names = new LocalizedStrings(zero);
			}
			else
			{
				names = null;
			}
			result.CheckError();
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x000124C8 File Offset: 0x000106C8
		public unsafe Font GetFirstMatchingFont(FontWeight weight, FontStretch stretch, FontStyle style)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, weight, stretch, style, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)7 * (IntPtr)sizeof(void*)));
			Font result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new Font(zero);
			}
			else
			{
				result2 = null;
			}
			result.CheckError();
			return result2;
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x00012524 File Offset: 0x00010724
		public unsafe FontList GetMatchingFonts(FontWeight weight, FontStretch stretch, FontStyle style)
		{
			IntPtr zero = IntPtr.Zero;
			Result result = calli(System.Int32(System.Void*,System.Int32,System.Int32,System.Int32,System.Void*), this._nativePointer, weight, stretch, style, &zero, *(*(IntPtr*)this._nativePointer + (IntPtr)8 * (IntPtr)sizeof(void*)));
			FontList result2;
			if (zero != IntPtr.Zero)
			{
				result2 = new FontList(zero);
			}
			else
			{
				result2 = null;
			}
			result.CheckError();
			return result2;
		}
	}
}
